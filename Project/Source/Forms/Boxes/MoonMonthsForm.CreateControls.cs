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

    internal void CreateControls()
    {
      PanelMonths.Controls.Clear();
      MoonMonths.Load();
      int x = 10;
      int dx1 = 80;
      int dx2 = 150;
      int dy1 = 4;
      int dy2 = 4;
      int dy3 = 4;
      int dyline = 5;
      int xmax = 0;
      int y = 10;
      int maxLabelWidth = 600;
      Color[] colorsMonth = new Color[0];
      Color colorLinkTextMeaning = SystemColors.ControlText;
      Color colorLinkTextLettriq = SystemColors.ControlText;
      Color colorActiveLink;
      switch ( Program.Settings.MoonMonthsFormUseColors )
      {
        case MoonMonthsListColors.System:
          PanelMonths.BackColor = SystemColors.Control;
          colorActiveLink = Color.MediumBlue;
          colorsMonth = ColorsSystem;
          break;
        case MoonMonthsListColors.Pastel:
          PanelMonths.BackColor = Color.Black;
          colorActiveLink = Color.Gainsboro;
          colorLinkTextMeaning = Color.Tomato;
          colorLinkTextLettriq = Color.LightSkyBlue;
          colorsMonth = ColorsPastel;
          break;
        case MoonMonthsListColors.Flashy:
          PanelMonths.BackColor = Color.Black;
          colorActiveLink = Color.Gainsboro;
          colorLinkTextMeaning = Color.Red;
          colorLinkTextLettriq = Color.Cyan;
          colorsMonth = ColorsFlashy;
          break;
        default:
          throw new NotImplementedException();
      }
      for ( int index = 1; index < MoonMonths.Names.Length; index++ )
      {
        Func<int, int, string, Color, Font, bool, bool, LinkLabel> createLabel
          = (posX, posY, text, color, font, isAlignRight, checkWidth) =>
          {
            var linklabel = new LinkLabel();
            PanelMonths.Controls.Add(linklabel);
            linklabel.Location = new Point(posX, posY);
            linklabel.AutoSize = true;
            linklabel.MaximumSize = new Size(maxLabelWidth, 0);
            linklabel.Font = font;
            linklabel.Text = text;
            linklabel.Tag = index;
            linklabel.LinkBehavior = LinkBehavior.NeverUnderline;
            linklabel.ActiveLinkColor = colorActiveLink;
            linklabel.LinkColor = color;
            linklabel.LinkClicked += Label_LinkClicked;
            linklabel.ContextMenuStrip = ContextMenuStrip;
            if ( isAlignRight )
              linklabel.Left = x + dx1 - 5 - linklabel.Width;
            if ( checkWidth )
            {
              int dx = linklabel.Left + linklabel.Width;
              if ( xmax < dx ) xmax = dx;
            }
            return linklabel;
          };
        var label1 = createLabel(x, y,
                                 HebrewAlphabet.ConvertToHebrewFont(MoonMonths.Unicode[index]),
                                 colorsMonth[index - 1],
                                 new Font("Hebrew", 14f),
                                 true, false);
        var label2 = createLabel(x + dx1, y + dy1,
                                 MoonMonths.Names[index],
                                 colorsMonth[index - 1],
                                 new Font("Microsoft Sans Serif", 10f),
                                 false, false);
        var label3 = createLabel(x + dx2, y + dy2,
                                 MoonMonths.Meanings[index],
                                 colorLinkTextMeaning,
                                 new Font("Microsoft Sans Serif", 10f),
                                 false, true);
        var label4 = createLabel(x + dx2, label3.Top + label3.Height + dy3,
                                 MoonMonths.Lettriqs[index],
                                 colorLinkTextLettriq,
                                 new Font("Microsoft Sans Serif", 10f),
                                 false, true);
        y = label4.Top + label4.Height + dyline;
      }
      int width = xmax + 20;
      Width = width < 600 ? 600 : width;
      Height = y + PanelBottom.Height + 40;
    }

  }

}
