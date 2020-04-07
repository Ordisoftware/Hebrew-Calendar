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
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.HebrewWords;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MoonMonthsForm : Form
  {

    public MoonMonthsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ActionEditFiles.Left = ActionSwapColors.Left + ActionSwapColors.Width + 10;
      EventHandler action = (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        //var control1 = ( (ContextMenuStrip)menuitem.OwnerItem.Owner );
        //var control = control1.SourceControl;
        Program.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", MoonMonths.Unicode[(int)LastControl.Tag]));
      };
      int index = 0;
      foreach ( var item in OnlineWordProviders.Items )
      {
        if ( item.Name == "-" )
          ActionSearchOnline.DropDownItems.Insert(index++, new ToolStripSeparator());
        else
          ActionSearchOnline.DropDownItems.Insert(index++, item.CreateMenuItem(action));
      }
      CreateControls();
    }

    private void CreateControls()
    {
      PanelMonths.Controls.Clear();
      MoonMonths.Load();
      bool usecolors = Program.Settings.MoonMonthsFormUseColors;
      int x = 10;
      int dx1 = 80;
      int dx2 = 150;
      int dy1 = 4;
      int dy2 = 4;
      int dy3 = 22;
      int dyline = 45;
      int xmax = 0;
      int y = 10;
      int countColor = 0;
      var colors = new Color[] { Color.Yellow, Color.Fuchsia, Color.Lime, Color.White };
      var colorText1 = Color.Red;
      var colorText2 = Color.Cyan;
      var colorActiveLink = usecolors ? Color.Gainsboro : Color.MediumBlue;
      var colorLink = SystemColors.ControlText;
      if ( usecolors )
        PanelMonths.BackColor = Color.Black;
      else
        PanelMonths.BackColor = SystemColors.Control;
      for ( int index = 1; index < MoonMonths.Names.Length; index++ )
      {
        countColor++;
        var label1 = new LinkLabel();
        label1.Location = new Point(x, y);
        label1.AutoSize = true;
        label1.Font = new Font("Hebrew", 14f);
        label1.LinkBehavior = LinkBehavior.NeverUnderline;
        label1.ActiveLinkColor = colorActiveLink;
        label1.LinkColor = usecolors ? colors[(int)Math.Truncate(countColor / 4f)] : colorLink;
        label1.Text = HebrewLetters.ConvertToHebrewFont(MoonMonths.Unicode[index]);
        var label2 = new LinkLabel();
        label2.Location = new Point(x + dx1, y + dy1);
        label2.AutoSize = true;
        label2.Font = new Font("Microsoft Sans Serif", 10f);
        label2.LinkBehavior = LinkBehavior.NeverUnderline;
        label2.ActiveLinkColor = colorActiveLink;
        label2.LinkColor = usecolors ? colors[(int)Math.Truncate(countColor / 4f)] : colorLink;
        label2.Text = MoonMonths.Names[index];
        var label3 = new LinkLabel();
        label3.Location = new Point(x + dx2, y + dy2);
        label3.AutoSize = true;
        label3.Font = new Font("Microsoft Sans Serif", 10f);
        label3.LinkBehavior = LinkBehavior.NeverUnderline;
        label3.ActiveLinkColor = colorActiveLink;
        label3.LinkColor = usecolors ? colors[(int)Math.Truncate(countColor / 4f)] : colorLink;
        label3.Text = MoonMonths.Meanings[index];
        var label4 = new LinkLabel();
        label4.Location = new Point(x + dx2, y + dy3);
        label4.AutoSize = true;
        label4.Font = new Font("Microsoft Sans Serif", 10f);
        label4.LinkBehavior = LinkBehavior.NeverUnderline;
        label4.ActiveLinkColor = colorActiveLink;
        label4.LinkColor = usecolors ? colors[(int)Math.Truncate(countColor / 4f)] : colorLink;
        label4.Text = MoonMonths.Lettriqs[index];
        PanelMonths.Controls.Add(label1);
        PanelMonths.Controls.Add(label2);
        PanelMonths.Controls.Add(label3);
        PanelMonths.Controls.Add(label4);
        label1.LinkClicked += Label_LinkClicked;
        label2.LinkClicked += Label_LinkClicked;
        label3.LinkClicked += Label_LinkClicked;
        label4.LinkClicked += Label_LinkClicked;
        label1.ContextMenuStrip = ContextMenuStrip;
        label2.ContextMenuStrip = ContextMenuStrip;
        label3.ContextMenuStrip = ContextMenuStrip;
        label4.ContextMenuStrip = ContextMenuStrip;
        label1.Tag = index;
        label2.Tag = index;
        label3.Tag = index;
        label4.Tag = index;
        int dx = label3.Left + label3.Width;
        if ( xmax < dx ) xmax = dx;
        dx = label4.Left + label4.Width;
        if ( xmax < dx ) xmax = dx;
        y = y + dyline;
      }
      Width = xmax + 20;
      Height = y + PanelBottom.Height + 40;
    }

    private Control LastControl;

    private void Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      LastControl = sender as Control;
      if ( e.Button == MouseButtons.Left )
        ContextMenuStrip.Show(LastControl, LastControl.PointToClient(Cursor.Position));
    }

    private void ActionSwapColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Program.Settings.MoonMonthsFormUseColors = !Program.Settings.MoonMonthsFormUseColors;
      Program.Settings.Save();
      CreateControls();
    }

    private void ActionEditFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Close();
      Program.RunShell(Program.AppDocumentsFolderPath + "MoonMonthsMeaningsEN.txt");
      Program.RunShell(Program.AppDocumentsFolderPath + "MoonMonthsMeaningsFR.txt");
      Program.RunShell(Program.AppDocumentsFolderPath + "MoonMonthsLettriqsEN.txt");
      Program.RunShell(Program.AppDocumentsFolderPath + "MoonMonthsLettriqsFR.txt");
    }

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      Program.OpenHebrewLetters(HebrewLetters.ConvertToHebrewFont(MoonMonths.Unicode[index]));
    }

    private void ActionCopyFontChars_Click(object sender, EventArgs e)
    {
      var menuitem = (ToolStripMenuItem)sender;
      var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
      int index = (int)control.Tag;
      Clipboard.SetText(HebrewLetters.ConvertToHebrewFont(MoonMonths.Unicode[index]));
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
