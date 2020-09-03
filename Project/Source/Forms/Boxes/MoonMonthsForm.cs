/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MoonMonthsForm : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static public MoonMonthsForm Instance { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static MoonMonthsForm()
    {
      Instance = new MoonMonthsForm();
    }

    static public void Run()
    {
      Instance.MoonMonthsForm_Load(null, null);
      if ( Instance.WindowState == FormWindowState.Minimized )
        Instance.WindowState = FormWindowState.Normal;
      Instance.Show();
      Instance.BringToFront();
    }

    private MoonMonthsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      CreateControls();
      ActiveControl = ActionClose;
      ActionEditFiles.Visible = Program.MoonMonthsMeanings[Languages.Current].Configurable;
      ActionSearchOnline.InitializeFromProviders(Globals.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        string str = Program.MoonMonthsUnicode[(int)LastControl.Tag].Replace(" א", "").Replace(" ב", "");
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
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
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
      Program.MoonMonthsNoticeForm.Show();
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
      Program.OpenHebrewLetters(HebrewAlphabet.ConvertToHebrewFont(Program.MoonMonthsUnicode[index]));
    }

    private void ActionCopyFontChars_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      Clipboard.SetText(HebrewAlphabet.ConvertToHebrewFont(Program.MoonMonthsUnicode[index]));
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      Clipboard.SetText(Program.MoonMonthsUnicode[index]);
    }

    private void ActionCopyLine_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      string str = Program.MoonMonthsUnicode[index] + " ("
                 + Program.MoonMonthsNames[index] + ") : "
                 + Program.MoonMonthsMeanings[Languages.Current][index] + " ("
                 + Program.MoonMonthsLettriqs[Languages.Current][index] + ")";
      Clipboard.SetText(str);
    }

  }

}
