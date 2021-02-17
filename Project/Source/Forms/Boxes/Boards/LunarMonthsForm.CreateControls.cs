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
/// <edited> 2020-08 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class LunarMonthsForm : Form
  {

    internal void CreateControls()
    {
      PanelMonths.Controls.Clear();
      int x = 10;
      int dx1 = 80;
      int dx2 = 150;
      int dy1 = 4;
      int dy2 = 4;
      int dy3 = 4;
      int dyline = 5;
      int xmax = 0;
      int y = 10;
      int maxLabelWidth = 900;
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
          throw new NotImplementedExceptionEx(Program.Settings.MoonMonthsFormUseColors);
      }
      for ( int index = 1; index < HebrewMonths.Transliterations.Length; index++ )
      {
        Func<int, int, string, Color, Font, bool, bool, bool, LinkLabel> createLabel
          = (posX, posY, text, color, font, tabstop, isAlignRight, checkWidth) =>
          {
            var label = new LinkLabel();
            PanelMonths.Controls.Add(label);
            label.Location = new Point(posX, posY);
            label.AutoSize = true;
            label.MaximumSize = new Size(maxLabelWidth, 0);
            label.Font = font;
            label.Text = text;
            label.Tag = index;
            label.LinkBehavior = LinkBehavior.NeverUnderline;
            label.ActiveLinkColor = colorActiveLink;
            label.LinkColor = color;
            label.LinkClicked += Label_LinkClicked;
            label.ContextMenuStrip = ContextMenuItems;
            if ( isAlignRight )
              label.Left = x + dx1 - 5 - label.Width;
            if ( checkWidth )
            {
              int dx = label.Left + label.Width;
              if ( xmax < dx ) xmax = dx;
            }
            label.TabStop = tabstop;
            if (tabstop) label.TabIndex = index;
            return label;
          };
        var label1 = createLabel(x, y,
                                 HebrewAlphabet.ConvertToHebrewFont(HebrewMonths.Unicode[index]),
                                 colorsMonth[index - 1],
                                 new Font("Hebrew", 14f),
                                 true, true, false);
        var label2 = createLabel(x + dx1, y + dy1,
                                 HebrewMonths.Transliterations[index],
                                 colorsMonth[index - 1],
                                 new Font("Microsoft Sans Serif", 10f),
                                 false, false, false);
        var label3 = createLabel(x + dx2, y + dy2,
                                 Program.MoonMonthsMeanings[Languages.Current][index],
                                 colorLinkTextMeaning,
                                 new Font("Microsoft Sans Serif", 10f),
                                 false, false, true);
        var label4 = createLabel(x + dx2, label3.Top + label3.Height + dy3,
                                 Program.MoonMonthsLettriqs[Languages.Current][index],
                                 colorLinkTextLettriq,
                                 new Font("Microsoft Sans Serif", 10f),
                                 false, false, true);
        y = label4.Top + label4.Height + dyline;
      }
      int width = xmax + 30;
      Width = width < 600 ? 600 : width;
      Height = y + PanelBottom.Height + 50;
    }

  }

}
