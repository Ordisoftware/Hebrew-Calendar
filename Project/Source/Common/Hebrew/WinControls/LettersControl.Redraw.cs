/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2025 Olivier Rogier.
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
/// <edited> 2024-08 </edited>
namespace Ordisoftware.Hebrew;

/// <summary>
/// Provides Letters input panel Control.
/// </summary>
public partial class LettersControl
{

  private bool RedrawMutex;

  /// <summary>
  /// Creates letters buttons and labels.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
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
      int countLetters = HebrewAlphabet.KeyCodes.Length;
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
      int offsetY = TextRenderer.MeasureText("a", fontLetter).Height + 5;
      int offsetX = -(int)Math.Round(( width + 10 - ( offsetY / 2.0 ) ) / 11, MidpointRounding.AwayFromZero);
      var sizeLabelValue = new Size(offsetY, 8);
      var sizeLabelKey = new Size(offsetY, 13);
      const int offsetValue2 = 2;
      const int offsetValue5 = 5;
      const int offsetBetweenLines = 15;
      int posX = width + offsetX + offsetValue2 - _MarginX;
      int posY = _MarginY + offsetValue5;
      int offsetValues = _ShowValues ? sizeLabelValue.Height : -offsetValue2;
      int offsetKeys = _ShowKeys ? sizeLabelKey.Height : -offsetValue2;
      int offsetValuesAndKeys = _ShowValues && _ShowKeys ? offsetValues + offsetValue5 : offsetValues;
      int offsetYAndValuesAndKeys = offsetY + offsetValuesAndKeys + offsetValue2;
      int offsetLine = offsetY + offsetBetweenLines + offsetValues + offsetKeys;
      var colorLabel = Color.DimGray;
      int indexControl = 0;
      for ( int index = 0; index < countLetters; index++ )
      {
        ref string letter = ref HebrewAlphabet.KeyCodes[index];
        // Button letter
        var buttonLetter = new Button
        {
          Location = new Point(posX, posY),
          Size = new Size(offsetY, offsetY),
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
          var textValue = new StringBuilder(9);
          textValue.Append(HebrewAlphabet.ValuesSimple[index]);
          if ( _ShowFinalValues && HebrewAlphabet.ValuesFinal.TryGetValue(letter, out int letterValue) )
            textValue.Append($" | {letterValue}");
          controls[indexControl++] = new Label
          {
            Location = new Point(posX, posY + offsetY),
            Size = sizeLabelKey,
            Font = fontValue,
            ForeColor = colorLabel,
            BackColor = Color.Transparent,
            Text = textValue.ToString(),
            TextAlign = ContentAlignment.MiddleCenter
          };
        }
        // Label key
        if ( _ShowKeys )
        {
          controls[indexControl++] = new Label
          {
            Location = new Point(posX, posY + offsetYAndValuesAndKeys),
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
          posX += offsetX;
        }
        else
        {
          posX = width + offsetX - _MarginX;
          posY += offsetLine;
          lineLetterCount = 0;
        }
      }
      Height = posY + offsetBetweenLines + offsetY + offsetValues + offsetKeys + offsetValue5
             + PanelSeparator.Height + TextBox.Height;
      if ( PanelBottom.Visible ) Height += PanelBottom.Height;
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
