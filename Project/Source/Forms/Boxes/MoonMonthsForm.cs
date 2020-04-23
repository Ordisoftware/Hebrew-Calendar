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
/// <edited> 2020-04 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MoonMonthsForm : Form
  {

    public MoonMonthsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      CreateControls();
      ActiveControl = ActionClose;
      ActionSwapColors.TabStop = false;
      ActionEditFiles.TabStop = false;
      ActionReloadFiles.TabStop = false;
      ActionSearchOnline.InitializeFromProviders(Globals.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        SystemHelper.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", MoonMonths.Unicode[(int)LastControl.Tag]));
      });
    }

    private void MoonMonthsForm_Load(object sender, EventArgs e)
    {
      if ( Location.X == -1 && Location.Y == -1 )
        CenterToScreen();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ActionSwapColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Program.Settings.MoonMonthsFormUseColors = Program.Settings.MoonMonthsFormUseColors.Next();
      Program.Settings.Save();
      CreateControls();
    }

    private void ActionEditFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      SystemHelper.RunShell(Globals.DocumentsFolderPath + "MoonMonthsMeaningsEN.txt");
      SystemHelper.RunShell(Globals.DocumentsFolderPath + "MoonMonthsMeaningsFR.txt");
      SystemHelper.RunShell(Globals.DocumentsFolderPath + "MoonMonthsLettriqsEN.txt");
      SystemHelper.RunShell(Globals.DocumentsFolderPath + "MoonMonthsLettriqsFR.txt");
    }

    private void ActionReloadFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      CreateControls();
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
      Program.OpenHebrewLetters(HebrewAlphabet.ConvertToHebrewFont(MoonMonths.Unicode[index]));
    }

    private void ActionCopyFontChars_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      Clipboard.SetText(HebrewAlphabet.ConvertToHebrewFont(MoonMonths.Unicode[index]));
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      Clipboard.SetText(MoonMonths.Unicode[index]);
    }

    private void ActionCopyLine_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      string str = MoonMonths.Unicode[index] + " ("
                 + MoonMonths.Names[index] + ") : "
                 + MoonMonths.Meanings[index] + " ("
                 + MoonMonths.Lettriqs[index] + ")";
      Clipboard.SetText(str);
    }

  }

}
