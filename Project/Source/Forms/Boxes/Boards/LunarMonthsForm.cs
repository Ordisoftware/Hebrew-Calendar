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

  public partial class LunarMonthsForm : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static public LunarMonthsForm Instance { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static LunarMonthsForm()
    {
      Instance = new LunarMonthsForm();
    }

    static public void Run()
    {
      Instance.MoonMonthsForm_Load(null, null);
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
      ActionEditFiles.Visible = Program.MoonMonthsMeanings[Languages.Current].Configurable;
      ActionSearchOnline.InitializeFromProviders(ProvidersCollection.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        string str = HebrewAlphabet.MoonMonthsNamesUnicode[(int)LastControl.Tag].Replace(" א", "").Replace(" ב", "");
        SystemManager.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", str));
      });
    }

    internal void Relocalize()
    {
      if ( !Globals.IsReady ) return;
      CreateControls();
    }

    private void MoonMonthsForm_Load(object sender, EventArgs e)
    {
      this.CheckLocationOrCenterToMainFormElseScreen();
    }

    private void MoonMonthsForm_FormClosing(object sender, FormClosingEventArgs e)
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
      Program.Settings.MoonMonthsFormUseColors = Program.Settings.MoonMonthsFormUseColors.Next();
      Program.Settings.Save();
      CreateControls();
    }

    private void ActionViewNotice_Click(object sender, EventArgs e)
    {
      new MessageBoxEx(AppTranslations.NoticeMoonMonthsTitle, AppTranslations.NoticeMoonMonths).ShowDialog();
    }

    private void ActionEditFiles_Click(object sender, EventArgs e)
    {
      var list = new List<DataFile>();
      foreach ( var lang in Languages.Managed )
      {
        list.Add(Program.MoonMonthsMeanings[lang]);
        list.Add(Program.MoonMonthsLettriqs[lang]);
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

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      HebrewTools.OpenHebrewLetters(HebrewAlphabet.ConvertToHebrewFont(HebrewAlphabet.MoonMonthsNamesUnicode[index]),
                                    Program.Settings.HebrewLettersExe);
    }

    private void ActionCopyMonthName(object sender, EventArgs e, Func<int, string> process)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      Clipboard.SetText(process(index));
    }

    private void ActionCopyHebrewChars_Click(object sender, EventArgs e)
    {
      ActionCopyMonthName(sender, e, index => HebrewAlphabet.ConvertToHebrewFont(HebrewAlphabet.MoonMonthsNamesUnicode[index]));
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      ActionCopyMonthName(sender, e, index => HebrewAlphabet.MoonMonthsNamesUnicode[index]);
    }

    private void ActionCopyLine(object sender, EventArgs e, Func<int, string> process)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      string name = HebrewAlphabet.MoonMonthsTransliterations[index];
      string meaning = Program.MoonMonthsMeanings[Languages.Current][index];
      string lettriq = Program.MoonMonthsLettriqs[Languages.Current][index];
      Clipboard.SetText(process(index) + " (" + name + ") : " +  meaning + " (" + lettriq + ")");
    }

    private void ActionCopyLineHebrew_Click(object sender, EventArgs e)
    {
      ActionCopyLine(sender, e, index => HebrewAlphabet.ConvertToHebrewFont(HebrewAlphabet.MoonMonthsNamesUnicode[index]));
    }

    private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
    {
      ActionCopyLine(sender, e, index => HebrewAlphabet.MoonMonthsNamesUnicode[index]);
    }

  }

}
