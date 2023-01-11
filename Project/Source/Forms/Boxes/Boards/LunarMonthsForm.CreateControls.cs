/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class LunarMonthsForm : Form
{

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "<En attente>")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "<En attente>")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  public void CreateControls()
  {
    PanelMonths.Controls.Clear();
    const int xpos = 10;
    const int dx1 = 80;
    const int dx2 = 150;
    const int dy1 = 4;
    const int dy2 = 4;
    const int dy3 = 4;
    const int dyline = 5;
    int xmax = 0;
    int ypos = 10;
    const int maxLabelWidth = 900;
    Color[] colorsMonth;
    var colorLinkTextMeaning = SystemColors.ControlText;
    var colorLinkTextLettriq = SystemColors.ControlText;
    Color colorActiveLink;
    switch ( Program.Settings.LunarMonthsFormUseColors )
    {
      case LunarMonthsListColor.System:
        PanelMonths.BackColor = SystemColors.Control;
        colorActiveLink = Color.MediumBlue;
        colorsMonth = ColorsSystem;
        break;
      case LunarMonthsListColor.Pastel:
        PanelMonths.BackColor = Color.Black;
        colorActiveLink = Color.Gainsboro;
        colorLinkTextMeaning = Color.Tomato;
        colorLinkTextLettriq = Color.LightSkyBlue;
        colorsMonth = ColorsPastel;
        break;
      case LunarMonthsListColor.Flashy:
        PanelMonths.BackColor = Color.Black;
        colorActiveLink = Color.Gainsboro;
        colorLinkTextMeaning = Color.Red;
        colorLinkTextLettriq = Color.Cyan;
        colorsMonth = ColorsFlashy;
        break;
      default:
        throw new AdvNotImplementedException(Program.Settings.LunarMonthsFormUseColors);
    }
    for ( int index = 1; index < HebrewMonths.Transcriptions.GetLang().Length; index++ )
    {
      LinkLabel createLabel(int posX, int posY,
                            string text, Color color, Font font,
                            bool tabstop, bool isAlignRight, bool checkWidth)
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
          label.Left = xpos + dx1 - 5 - label.Width;
        if ( checkWidth )
        {
          int dx = label.Left + label.Width;
          if ( xmax < dx ) xmax = dx;
        }
        label.TabStop = tabstop;
        if ( tabstop ) label.TabIndex = index;
        return label;
      }
      createLabel(xpos, ypos,
                  HebrewAlphabet.ToHebrewFont(HebrewMonths.Unicode[index]),
                  colorsMonth[index - 1],
                  new Font("Hebrew", 14f),
                  true, true, false);
      createLabel(xpos + dx1, ypos + dy1,
                  HebrewMonths.Transcriptions.GetLang()[index],
                  colorsMonth[index - 1],
                  new Font("Microsoft Sans Serif", 10f),
                  false, false, false);
      var label3 = createLabel(xpos + dx2, ypos + dy2,
                               Program.LunarMonthsMeanings[Languages.Current][index],
                               colorLinkTextMeaning,
                               new Font("Microsoft Sans Serif", 10f),
                               false, false, true);
      var label4 = createLabel(xpos + dx2, label3.Top + label3.Height + dy3,
                               Program.LunarMonthsLettriqs[Languages.Current][index],
                               colorLinkTextLettriq,
                               new Font("Microsoft Sans Serif", 10f),
                               false, false, true);
      ypos = label4.Top + label4.Height + dyline;
    }
    int width = xmax + 30;
    Width = width < 600 ? 600 : width;
    Height = ypos + PanelBottom.Height + 50;
  }

}
