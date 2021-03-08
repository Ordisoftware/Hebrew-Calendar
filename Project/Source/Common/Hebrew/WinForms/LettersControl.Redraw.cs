/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide Letters input panel Control class.
  /// </summary>
  partial class LettersControl
  {

    /// <summary>
    /// Create letters buttons and labels.
    /// </summary>
    public void Redraw()
    {
      SuspendLayout();
      try
      {
        // TODO calculate buttons and labels size from fonts size
        PanelLetters.Controls.Clear();
        int countLetters = HebrewAlphabet.Codes.Length;
        int countControls = countLetters;
        if ( _ShowValues ) countControls += countLetters;
        if ( _ShowKeys ) countControls += countLetters;
        var controls = new Control[countControls];
        int lettersPerLine = 12;
        int lineLetterCount = 1;
        int width = 500;
        int deltaY = 45;
        int deltaX = -deltaY;
        int deltaXabs = Math.Abs(deltaX);
        int deltaValue2 = 2;
        int deltaValue5 = 5;
        int deltaBetweenLines = 15;
        int posX = width + deltaX + deltaValue2;
        int posY = deltaValue5;
        var fontLetter = new Font("Hebrew", _FontSizeLetters, FontStyle.Bold);
        var fontValue = new Font("Microsoft Sans Serif", _FontSizeValues);
        var fontKey = new Font("Microsoft Sans Serif", _FontSizeKeys);
        var sizeLabelValue = new Size(45, 8);
        var sizeLabelKey = new Size(45, 13);
        int deltaValues = _ShowValues ? sizeLabelValue.Height : -deltaValue2;
        int deltaKeys = _ShowKeys ? sizeLabelKey.Height : -deltaValue2;
        int deltaValuesAndKeys = _ShowValues && _ShowKeys ? deltaValues + deltaValue5 : deltaValues;
        int deltaYAndValuesAndKeys = deltaY + deltaValuesAndKeys;
        int deltaLine = deltaY + deltaBetweenLines + deltaValues + deltaKeys;
        var colorLabel = Color.DimGray;
        Button buttonLetter = null;
        Label labelValue = null;
        Label labelKey = null;
        for ( int index = 0, indexControl = 0; index < countLetters; index++ )
        {
          // Button letter
          buttonLetter = new Button();
          buttonLetter.Location = new Point(posX, posY);
          buttonLetter.Size = new Size(deltaXabs, deltaY);
          buttonLetter.TabStop = false;
          buttonLetter.FlatStyle = FlatStyle.Flat;
          buttonLetter.FlatAppearance.BorderSize = 0;
          buttonLetter.FlatAppearance.BorderColor = SystemColors.Control;
          buttonLetter.Cursor = Cursors.Hand;
          buttonLetter.Font = fontLetter;
          buttonLetter.Text = HebrewAlphabet.Codes[index];
          buttonLetter.BackColor = Color.Transparent;
          buttonLetter.Click += ButtonLetter_Click;
          buttonLetter.ContextMenuStrip = ContextMenuLetter;
          controls[indexControl++] = buttonLetter;
          // Label value
          if ( _ShowValues )
          {
            labelValue = new Label();
            labelValue.Location = new Point(posX, posY + deltaY);
            labelValue.Size = sizeLabelKey;
            labelValue.Font = fontValue;
            labelValue.ForeColor = colorLabel;
            labelValue.BackColor = Color.Transparent;
            labelValue.Text = HebrewAlphabet.ValuesSimple[index].ToString();
            labelValue.TextAlign = ContentAlignment.MiddleCenter;
            controls[indexControl++] = labelValue;
          }
          // Label key
          if ( _ShowKeys )
          {
            labelKey = new Label();
            labelKey.Location = new Point(posX, posY + deltaYAndValuesAndKeys);
            labelKey.Font = fontKey;
            labelKey.Size = sizeLabelKey;
            labelKey.Text = HebrewAlphabet.Codes[index];
            labelKey.ForeColor = colorLabel;
            labelKey.BackColor = Color.Transparent;
            labelKey.TextAlign = ContentAlignment.MiddleCenter;
            controls[indexControl++] = labelKey;
          }
          // Loop
          lineLetterCount++;
          if ( lineLetterCount != lettersPerLine )
            posX += deltaX;
          else
          {
            posX = width + deltaX;
            posY = posY + deltaLine;
          }
        }
        Height = posY + deltaBetweenLines + deltaY + deltaValues + deltaKeys + deltaValue5
               + PanelSeparator.Height + TextBox.Height;
        PanelLetters.Controls.AddRange(controls);
      }
      catch ( Exception ex )
      {
        ex.Manage(this);
      }
      finally
      {
        ResumeLayout();
      }
    }

  }

}
