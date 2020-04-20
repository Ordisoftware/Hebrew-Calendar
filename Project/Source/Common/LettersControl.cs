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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide Letters input panel Control class.
  /// </summary>
  public partial class LettersControl : UserControl
  {

    /// <summary>
    /// Indicates if a key is being processed.
    /// </summary>
    private bool KeyProcessed = false;

    /// <summary>
    /// Indicate if values must be shown.
    /// </summary>
    public bool ShowValues
    {
      get { return _ShowValues; }
      set
      {
        if ( _ShowValues == value ) return;
        _ShowValues = value;
        CreateLetters();
      }
    }
    private bool _ShowValues = true;

    /// <summary>
    /// Indicate the background color of letters panel.
    /// </summary>
    public Color LettersBackground
    {
      get { return Panel.BackColor; }
      set { Panel.BackColor = value; }
    }

    /// <summary>
    /// Indicate the background color of input textbox.
    /// </summary>
    public Color InputBackColor
    {
      get { return Input.BackColor; }
      set { Input.BackColor = value; }
    }

    /// <summary>
    /// Indicate max length of the input text.
    /// </summary>
    public int MaxLength
    {
      get;
      set;
    }

    /// <summary>
    /// Input textbox text changed event.
    /// </summary>
    public event EventHandler InputTextChanged
    {
      add { Input.TextChanged += value; }
      remove { Input.TextChanged -= value; }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public LettersControl()
    {
      InitializeComponent();
      CreateLetters();
      MaxLength = 10;
    }

    /// <summary>
    /// Create letters buttons.
    /// </summary>
    private void CreateLetters()
    {
      try
      {
        Panel.Controls.Clear();
        int dy = 45;
        int dx = -dy;
        int x = 500 + dx;
        int y = 5;
        int n = 1;
        var colorLabel = Color.DimGray;
        var sizeLabelValue = new Size(45, 8);
        var sizeLabelKey = new Size(45, 13);
        var fontLetter = new Font("Hebrew", 20.25F, FontStyle.Bold);
        var fontValue = new Font("Microsoft Sans Serif", 6.25F);
        for ( int index = 0; index < HebrewAlphabet.Codes.Length; index++ )
        {
          var labelValue = new Label();
          if ( _ShowValues )
          {
            labelValue.Location = new Point(x, y + dy);
            labelValue.Size = sizeLabelKey;
            labelValue.Font = fontValue;
            labelValue.ForeColor = colorLabel;
            labelValue.BackColor = Color.Transparent;
            labelValue.Text = HebrewAlphabet.ValuesSimple[index].ToString();
            labelValue.TextAlign = ContentAlignment.MiddleCenter;
            Panel.Controls.Add(labelValue);
          }
          //
          var labelKey = new Label();
          labelKey.Location = new Point(x, y + dy + ( _ShowValues ? labelValue.Height : -2 ) + 2);
          labelKey.Size = sizeLabelKey;
          labelKey.Text = HebrewAlphabet.Codes[index];
          labelKey.ForeColor = colorLabel;
          labelKey.BackColor = Color.Transparent;
          labelKey.TextAlign = ContentAlignment.MiddleCenter;
          Panel.Controls.Add(labelKey);
          //
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
          buttonLetter.Click += delegate (object sender, EventArgs e)
          {
            if (Input.Text.Length < MaxLength)
              Input.Text = ( (Button)sender ).Text + Input.Text;
            OnClick(new LetterEventArgs(( (Button)sender ).Text));
          };
          Panel.Controls.Add(buttonLetter);
          //
          n += 1;
          if ( n != 12 )
            x += dx;
          else
          {
            x = 500 + dx;
            y += dy + ( _ShowValues ? labelValue.Height : -2 ) + labelKey.Height + 15;
          }
        }
      }
      catch ( Exception ex )
      {
        ex.Manage(this);
      }
    }

    /// <summary>
    /// KeyPress event.
    /// </summary>
    private void Input_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ( HebrewAlphabet.Codes.Contains(e.KeyChar.ToString()) )
        KeyProcessed = true;
      else
      if ( Input.SelectedText != "" )
      {
        if ( e.KeyChar == '\u0018' ) // CTRL+X
        {
          Clipboard.SetText(Input.SelectedText);
          int selectionStart = Input.SelectionStart;
          Input.Text = Input.Text.Remove(selectionStart, Input.SelectionLength);
          Input.SelectionStart = selectionStart;
          e.Handled = true;
        }
        else
        if ( e.KeyChar == '\u0003' ) // CTRL+C
        {
          Clipboard.SetText(Input.SelectedText);
          e.Handled = true;
        }
      }
      else
        if ( e.KeyChar == '\u0016' ) // CTRL+V
      {
        string str = HebrewAlphabet.OnlyHebrewFont(Clipboard.GetText()).Replace(" ", "");
        if ( Input.Text.Length + str.Length <= MaxLength )
        {
          int selectionStart = Input.SelectionStart;
          Input.SelectedText = str;
          Input.SelectionStart = selectionStart;
        }
        e.Handled = true;
      }
      else
        e.KeyChar = '\x0';
    }

    /// <summary>
    /// KeyUp event.
    /// </summary>
    private void Input_KeyUp(object sender, KeyEventArgs e)
    {
      if ( KeyProcessed )
      {
        KeyProcessed = false;
        Input.SelectionStart--;
      }
    }

    /// <summary>
    /// KeyDown event.
    /// </summary>
    private void Input_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.Shift && e.KeyCode == Keys.Insert )
        e.SuppressKeyPress = true;
    }

  }

  /// <summary>
  /// Provide LetterEventArgs class.
  /// </summary>
  public class LetterEventArgs : EventArgs
  {
    public string LetterCode { get; private set; }
    public LetterEventArgs(string lettercode) { LetterCode = lettercode; }
  }

}
