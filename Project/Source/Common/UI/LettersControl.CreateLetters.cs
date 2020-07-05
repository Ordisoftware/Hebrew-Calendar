/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2012-10 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide Letters input panel Control class.
  /// </summary>
  public partial class LettersControl
  {

    /// <summary>
    /// Create letters buttons.
    /// </summary>
    private void CreateLetters()
    {
      try
      {
        // TODO calculate labels and buttons size from font size
        PanelLetters.Controls.Clear();
        int dy = 45;
        int dx = -dy;
        int x = 500 + dx;
        int y = 5;
        int n = 1;
        int delta;
        var colorLabel = Color.DimGray;
        var sizeLabelValue = new Size(45, 8);
        var sizeLabelKey = new Size(45, 13);
        var fontLetter = new Font("Hebrew", _FontSizeLetters, FontStyle.Bold);
        var fontValue = new Font("Microsoft Sans Serif", _FontSizeValues);
        var fontKey = new Font("Microsoft Sans Serif", _FontSizeKeys);
        var labelValue = new Label();
        var labelKey = new Label();
        for ( int index = 0; index < HebrewAlphabet.Codes.Length; index++ )
        {
          // Label value
          labelValue = new Label();
          if ( _ShowValues )
          {
            labelValue.Location = new Point(x, y + dy);
            labelValue.Size = sizeLabelKey;
            labelValue.Font = fontValue;
            labelValue.ForeColor = colorLabel;
            labelValue.BackColor = Color.Transparent;
            labelValue.Text = HebrewAlphabet.ValuesSimple[index].ToString();
            labelValue.TextAlign = ContentAlignment.MiddleCenter;
            PanelLetters.Controls.Add(labelValue);
          }
          // Label key
          labelKey = new Label();
          if ( _ShowKeys )
          {
            delta = ( _ShowValues ? labelValue.Height : -2 );
            labelKey.Location = new Point(x, y + dy + delta + 2);
            labelKey.Font = fontKey;
            labelKey.Size = sizeLabelKey;
            labelKey.Text = HebrewAlphabet.Codes[index];
            labelKey.ForeColor = colorLabel;
            labelKey.BackColor = Color.Transparent;
            labelKey.TextAlign = ContentAlignment.MiddleCenter;
            PanelLetters.Controls.Add(labelKey);
          }
          // Button letter
          var buttonLetter = new Button();
          buttonLetter.Location = new Point(x, y);
          buttonLetter.Size = new Size(Math.Abs(dx), dy);
          buttonLetter.FlatStyle = FlatStyle.Flat;
          buttonLetter.FlatAppearance.BorderSize = 0;
          buttonLetter.FlatAppearance.BorderColor = SystemColors.Control;
          buttonLetter.Font = fontLetter;
          buttonLetter.Text = HebrewAlphabet.Codes[index];
          buttonLetter.BackColor = Color.Transparent;
          buttonLetter.TabStop = false;
          buttonLetter.Click += ButtonLetter_Click;
          buttonLetter.ContextMenuStrip = ContextMenuLetter;
          PanelLetters.Controls.Add(buttonLetter);
          // Loop
          n += 1;
          if ( n != 12 )
            x += dx;
          else
          {
            x = 500 + dx;
            y = y + dy + 15
              + ( _ShowValues ? labelValue.Height : -2 )
              + ( _ShowKeys ? labelKey.Height : -2 );
          }
        }
        Height = y + dy + 15
               + PanelSeparator.Height + Input.Height + 2
               + ( _ShowValues ? labelValue.Height : -2 )
               + ( _ShowKeys ? labelKey.Height : -2 );
      }
      catch ( Exception ex )
      {
        ex.Manage(this);
      }
    }

  }

}
