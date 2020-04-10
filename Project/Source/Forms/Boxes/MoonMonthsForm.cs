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
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MoonMonthsForm : Form
  {

    public MoonMonthsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      EventHandler action = (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        Program.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", MoonMonths.Unicode[(int)LastControl.Tag]));
      };
      int index = 0;
      foreach ( var item in Program.OnlineWordProviders.Items )
        if ( item.Name == "-" )
          ActionSearchOnline.DropDownItems.Insert(index++, new ToolStripSeparator());
        else
          ActionSearchOnline.DropDownItems.Insert(index++, item.CreateMenuItem(action));
      CreateControls();
    }

    private void MoonMonthsForm_Load(object sender, EventArgs e)
    {
      if ( Location.X == -1 && Location.Y == -1 )
        this.CenterToMainForm();
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
      Program.RunShell(Program.AppDocumentsFolderPath + "MoonMonthsMeaningsEN.txt");
      Program.RunShell(Program.AppDocumentsFolderPath + "MoonMonthsMeaningsFR.txt");
      Program.RunShell(Program.AppDocumentsFolderPath + "MoonMonthsLettriqsEN.txt");
      Program.RunShell(Program.AppDocumentsFolderPath + "MoonMonthsLettriqsFR.txt");
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
        ContextMenuStrip.Show(LastControl, LastControl.PointToClient(Cursor.Position));
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

    internal void CreateControls()
    {
      PanelMonths.Controls.Clear();
      MoonMonths.Load();
      int x = 10;
      int dx1 = 80;
      int dx2 = 150;
      int dy1 = 4;
      int dy2 = 4;
      int dy3 = 22;
      int dyline = 45;
      int xmax = 0;
      int y = 10;
      int countMonths = 0;
      Color[] colorsMonth = new Color[0];
      Color colorLinkTextMeaning = SystemColors.ControlText;
      Color colorLinkTextLettriq = SystemColors.ControlText;
      Color colorLink;
      Color colorActiveLink;
      switch ( Program.Settings.MoonMonthsFormUseColors )
      {
        case MoonMonthsListColors.System:
          PanelMonths.BackColor = SystemColors.Control;
          colorLink =
          colorActiveLink = Color.MediumBlue;
          colorsMonth = new Color[] 
          {
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText,
            SystemColors.ControlText
          };
          break;
        case MoonMonthsListColors.Pastel:
          PanelMonths.BackColor = Color.Black;
          colorLink =
          colorActiveLink = Color.Gainsboro;
          colorLinkTextMeaning = Color.Tomato;
          colorLinkTextLettriq = Color.LightSkyBlue;
          colorsMonth = new Color[] 
          {
            Color.FromArgb(255, 230, 80),
            Color.FromArgb(255, 230, 80),
            Color.FromArgb(255, 230, 80),
            Color.Orchid,
            Color.Orchid,
            Color.Orchid,
            Color.SpringGreen,
            Color.SpringGreen,
            Color.SpringGreen,
            Color.White,
            Color.White,
            Color.White,
            Color.White
          };
          break;
        case MoonMonthsListColors.Flashy:
          PanelMonths.BackColor = Color.Black;
          colorLink =
          colorActiveLink = Color.Gainsboro;
          colorLinkTextMeaning = Color.Red;
          colorLinkTextLettriq = Color.Cyan;
          colorsMonth = new Color[] 
          {
            Color.Yellow,
            Color.Yellow,
            Color.Yellow,
            Color.Fuchsia,
            Color.Fuchsia,
            Color.Fuchsia,
            Color.Lime,
            Color.Lime,
            Color.Lime,
            Color.White,
            Color.White,
            Color.White,
            Color.White
          };
          break;
        default:
          throw new NotImplementedException();
      }
      for ( int index = 1; index < MoonMonths.Names.Length; index++ )
      {
        Action<int, int, string, Color, Font, bool, bool> createLabel
          = (posX, posY, text, color, font, isAlignRight, checkWidth) =>
          {
            var label = new LinkLabel();
            PanelMonths.Controls.Add(label);
            label.Location = new Point(posX, posY);
            label.AutoSize = true;
            label.Font = font;
            label.Text = text;
            label.Tag = index;
            label.LinkBehavior = LinkBehavior.NeverUnderline;
            label.ActiveLinkColor = colorActiveLink;
            label.LinkColor = color;
            label.LinkClicked += Label_LinkClicked;
            label.ContextMenuStrip = ContextMenuStrip;
            if ( isAlignRight )
              label.Left = x + dx1 - 5 - label.Width;
            if ( checkWidth )
            {
              int dx = label.Left + label.Width;
              if ( xmax < dx ) xmax = dx;
            }
          };
        createLabel(x, y,
                    HebrewAlphabet.ConvertToHebrewFont(MoonMonths.Unicode[index]),
                    colorsMonth[countMonths],
                    new Font("Hebrew", 14f),
                    true, false);
        createLabel(x + dx1, y + dy1,
                    MoonMonths.Names[index],
                    colorsMonth[countMonths],
                    new Font("Microsoft Sans Serif", 10f),
                    false, false);
        createLabel(x + dx2, y + dy2,
                    MoonMonths.Meanings[index],
                    colorLinkTextMeaning,
                    new Font("Microsoft Sans Serif", 10f),
                    false, true);
        createLabel(x + dx2, y + dy3,
                    MoonMonths.Lettriqs[index],
                    colorLinkTextLettriq,
                    new Font("Microsoft Sans Serif", 10f),
                    false, true);
        y = y + dyline;
        countMonths++;
      }
      Width = xmax + 20;
      Height = y + PanelBottom.Height + 40;
    }

  }

}
