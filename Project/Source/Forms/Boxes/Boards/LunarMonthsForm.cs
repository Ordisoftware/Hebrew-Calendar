/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-04 </created>
/// <edited> 2020-11 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class LunarMonthsForm : Form
  {

    static public LunarMonthsForm Instance { get; private set; }

    static LunarMonthsForm()
    {
      Instance = new LunarMonthsForm();
    }

    static public void Run()
    {
      Instance.LunarMonthsForm_Load(null, null);
      MainForm.Instance.Restore();
      Instance.Show();
      Instance.BringToFront();
    }

    private LunarMonthsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      CreateControls();
      ActiveControl = ActionClose;
      ActionEditFiles.Visible = Program.LunarMonthsMeanings[Languages.Current].Configurable;
      ActionSearchOnline.InitializeFromProviders(OnlineProviders.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        string word = HebrewMonths.Unicode[(int)LastControl.Tag]
                                  .Replace(" א", string.Empty)
                                  .Replace(" ב", string.Empty);
        HebrewTools.OpenOnlineWordProvider((string)menuitem.Tag, HebrewAlphabet.ToHebrewFont(word));
      });
    }

    public void Relocalize()
    {
      if ( !Globals.IsReady ) return;
      CreateControls();
    }

    private void LunarMonthsForm_Load(object sender, EventArgs e)
    {
      this.CheckLocationOrCenterToMainFormElseScreen();
    }

    private void LunarMonthsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ActionSwapColors_Click(object sender, EventArgs e)
    {
      Program.Settings.LunarMonthsFormUseColors = Program.Settings.LunarMonthsFormUseColors.Next();
      Program.Settings.Save();
      CreateControls();
    }

    private void ActionViewNotice_Click(object sender, EventArgs e)
    {
      new MessageBoxEx(AppTranslations.NoticeLunarMonthsTitle, AppTranslations.NoticeLunarMonths).ShowDialog();
    }

    private void ActionEditFiles_Click(object sender, EventArgs e)
    {
      var list = new List<DataFile>();
      foreach ( var lang in Languages.Managed )
      {
        list.Add(Program.LunarMonthsMeanings[lang]);
        list.Add(Program.LunarMonthsLettriqs[lang]);
      }
      if ( DataFileEditorForm.Run("Moon", list) ) CreateControls();
    }

    private Control LastControl;

    private void Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      LastControl = sender as Control;
      if ( e.Button == MouseButtons.Left )
        ContextMenuItems.Show(LastControl, LastControl.PointToClient(Cursor.Position));
    }

    private void ActionCopyMonthName(object sender, EventArgs e, Func<int, string> process)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      Clipboard.SetText(process(index));
    }

    private void ActionCopyName_Click(object sender, EventArgs e)
    {
      ActionCopyMonthName(sender, e, index => HebrewMonths.Transliterations[index]);
    }

    private void ActionCopyHebrewChars_Click(object sender, EventArgs e)
    {
      ActionCopyMonthName(sender, e, index => HebrewAlphabet.ToHebrewFont(HebrewMonths.Unicode[index]));
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      ActionCopyMonthName(sender, e, index => HebrewMonths.Unicode[index]);
    }

    private void ActionCopyLine(object sender, EventArgs e, Func<int, string> process)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      string name = HebrewMonths.Transliterations[index];
      string meaning = Program.LunarMonthsMeanings[Languages.Current][index];
      string lettriq = Program.LunarMonthsLettriqs[Languages.Current][index];
      Clipboard.SetText($"{process(index)} ({name}) : {meaning} ({lettriq})");
    }

    private void ActionCopyLineHebrew_Click(object sender, EventArgs e)
    {
      ActionCopyLine(sender, e, index => HebrewAlphabet.ToHebrewFont(HebrewMonths.Unicode[index]));
    }

    private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
    {
      ActionCopyLine(sender, e, index => HebrewMonths.Unicode[index]);
    }

    private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
    {
      Program.GrammarGuideForm.Popup();
    }

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      HebrewTools.OpenHebrewLetters(HebrewMonths.Unicode[index],
                                    Program.Settings.HebrewLettersExe);
    }

    private void ActionOpenHebrewWordsSearch_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      HebrewTools.OpenFindHebrewWordsSearchWord(HebrewAlphabet.ToHebrewFont(HebrewMonths.Unicode[index]),
                                                Program.Settings.HebrewWordsExe);
    }

  }

}
