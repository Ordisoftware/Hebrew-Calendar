/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew;

/// <summary>
/// Provides Letters input panel Control.
/// </summary>
partial class LettersControl
{

  private bool RedrawMutex;

  /// <summary>
  /// Creates letters buttons and labels.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
  public void Redraw()
  {
    if ( !Created || RedrawMutex ) return;
    if ( !Globals.IsReady ) return;
    SuspendLayout();
    RedrawMutex = true;
    try
    {
      // TODO calculate buttons and labels size from fonts size at startup and future setting changed
      PanelLetters.Controls.Clear();
      TextBox.Font = new Font(TextBox.Font.Name, _FontSizeInput, TextBox.Font.Style);
      int countLetters = HebrewAlphabet.Codes.Length;
      int countControls = countLetters;
      if ( _ShowValues ) countControls += countLetters;
      if ( _ShowKeys ) countControls += countLetters;
      var controls = new Control[countControls];
      var fontLetter = new Font("Hebrew", _FontSizeLetters, _Bold ? FontStyle.Bold : FontStyle.Regular);
      TextBox.Font = new Font("Hebrew", _FontSizeInput, _Bold ? FontStyle.Bold : FontStyle.Regular);
      using var fontValue = new Font("Microsoft Sans Serif", _FontSizeValues);
      using var fontKey = new Font("Microsoft Sans Serif", _FontSizeKeys);
      const int lettersPerLine = 11;
      int lineLetterCount = 1;
      int width = PanelLetters.Width - 10;
      int deltaY = TextRenderer.MeasureText("a", fontLetter).Height + 5;
      int deltaX = -(int)Math.Round(( width + 10 - ( deltaY / 2.0 ) ) / 11, MidpointRounding.AwayFromZero);
      var sizeLabelValue = new Size(deltaY, 8);
      var sizeLabelKey = new Size(deltaY, 13);
      const int deltaValue2 = 2;
      const int deltaValue5 = 5;
      const int deltaBetweenLines = 15;
      int posX = width + deltaX + deltaValue2 - _MarginX;
      int posY = _MarginY + deltaValue5;
      int deltaValues = _ShowValues ? sizeLabelValue.Height : -deltaValue2;
      int deltaKeys = _ShowKeys ? sizeLabelKey.Height : -deltaValue2;
      int deltaValuesAndKeys = _ShowValues && _ShowKeys ? deltaValues + deltaValue5 : deltaValues;
      int deltaYAndValuesAndKeys = deltaY + deltaValuesAndKeys + deltaValue2;
      int deltaLine = deltaY + deltaBetweenLines + deltaValues + deltaKeys;
      var colorLabel = Color.DimGray;
      for ( int index = 0, indexControl = 0; index < countLetters; index++ )
      {
        ref string letter = ref HebrewAlphabet.Codes[index];
        // Button letter
        var buttonLetter = new Button
        {
          Location = new Point(posX, posY),
          Size = new Size(deltaY, deltaY),
          TabStop = false,
          Cursor = Cursors.Hand,
          Font = fontLetter,
          Text = letter,
          ContextMenuStrip = ContextMenuLetter,
          BackColor = Color.Transparent,
          FlatStyle = FlatStyle.Flat,
        };
        buttonLetter.FlatAppearance.BorderSize = 0;
        buttonLetter.FlatAppearance.BorderColor = SystemColors.Control;
        buttonLetter.Click += ButtonLetter_Click;
        controls[indexControl++] = buttonLetter;
        // Label value
        if ( _ShowValues )
        {
          controls[indexControl++] = new Label
          {
            Location = new Point(posX, posY + deltaY),
            Size = sizeLabelKey,
            Font = fontValue,
            ForeColor = colorLabel,
            BackColor = Color.Transparent,
            Text = HebrewAlphabet.ValuesSimple[index].ToString(),
            TextAlign = ContentAlignment.MiddleCenter
          };
        }
        // Label key
        if ( _ShowKeys )
        {
          controls[indexControl++] = new Label
          {
            Location = new Point(posX, posY + deltaYAndValuesAndKeys),
            Font = fontKey,
            Size = sizeLabelKey,
            Text = letter,
            ForeColor = colorLabel,
            BackColor = Color.Transparent,
            TextAlign = ContentAlignment.MiddleCenter
          };
        }
        // Loop
        lineLetterCount++;
        if ( lineLetterCount <= lettersPerLine )
        {
          posX += deltaX;
        }
        else
        {
          posX = width + deltaX - _MarginX;
          posY += deltaLine;
          lineLetterCount = 0;
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
      RedrawMutex = false;
    }
  }

}
