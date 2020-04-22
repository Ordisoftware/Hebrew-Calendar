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
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide Letters input panel Control class.
  /// </summary>
  public partial class LettersControl : UserControl
  {

    /// <summary>
    /// Indicate max length of the input text.
    /// </summary>
    public int InputMaxLength
    {
      get { return Input.MaxLength; }
      set { Input.MaxLength = value; }
    }

    /// <summary>
    /// Indicate the background color of letters panel.
    /// </summary>
    public Color LettersBackground
    {
      get { return PanelLetters.BackColor; }
      set { PanelLetters.BackColor = value; }
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
    /// Indicate hebrew letters font size
    /// </summary>
    public float LettersFontSize
    {
      get { return _LettersFontSize; }
      set
      {
        _LettersFontSize = value;
        CreateLetters();
      }
    }
    private float _LettersFontSize = 20.25F;

    /// <summary>
    /// Indicate labels font size.
    /// </summary>
    public float LabelsFontSize
    {
      get { return _LabelsFontSize; }
      set
      {
        _LabelsFontSize = value;
        CreateLetters();
      }
    }
    private float _LabelsFontSize = 6.25F;

    /// <summary>
    /// Indicate Input font size.
    /// </summary>
    public float InputFontSize
    {
      get { return Input.Font.Size; }
      set
      {
        Input.Font = new Font(Input.Font.FontFamily, value, Input.Font.Style);
        CreateLetters();
      }
    }

    /// <summary>
    /// Indicate if letters values must be shown.
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
    /// Indicate if keys codes must be shown.
    /// </summary>
    public bool ShowKeys
    {
      get { return _ShowKeys; }
      set
      {
        if ( _ShowKeys == value ) return;
        _ShowKeys = value;
        CreateLetters();
      }
    }
    private bool _ShowKeys = true;

    /// <summary>
    /// Input Text property.
    /// </summary>
    public string InputText
    {
      get { return Input.Text; }
      set { Input.Text = value; }
    }

    /// <summary>
    /// Input Text property.
    /// </summary>
    public int InputTextSelectionStart
    {
      get { return Input.SelectionStart; }
      set { Input.SelectionStart = value; }
    }

    /// <summary>
    /// Input Text changed event.
    /// </summary>
    public event EventHandler InputTextChanged
    {
      add { Input.TextChanged += value; }
      remove { Input.TextChanged -= value; }
    }

    /// <summary>
    /// Indicate if an input key is processed.
    /// </summary>
    private bool KeyProcessed;

    /// <summary>
    /// Constructor
    /// </summary>
    public LettersControl()
    {
      InitializeComponent();
      InputMaxLength = 20;
    }

    private void LettersControl_Load(object sender, EventArgs e)
    {
      CreateLetters();
    }

    /// <summary>
    /// Focus.
    /// </summary>
    public new void Focus()
    {
      Input.Focus();
      Input.SelectionLength = 0;
    }

    /// <summary>
    /// Letter icon click event.
    /// </summary>
    private void ButtonLetter_Click(object sender, EventArgs e)
    {
      string str = ( (Button)sender ).Text;
      if ( Input.SelectionLength > 0 && Input.Text.Length - Input.SelectionLength + str.Length <= InputMaxLength )
      {
        int pos = Input.SelectionStart;
        Input.SelectedText = str;
        Input.SelectionStart = pos;
        Input.Focus();
      }
      else
      if ( Input.Text.Length < InputMaxLength )
      {
        int pos = Input.SelectionStart;
        Input.Text = Input.Text.Insert(Input.SelectionStart, str);
        Input.SelectionStart = pos;
        Input.Focus();
      }
    }

    /// <summary>
    /// TextChanging event.
    /// </summary>
    private void Input_TextChanging(object sender, ref string text)
    {
      text = HebrewAlphabet.OnlyHebrewFont(text).Replace(" ", "");
    }

    /// <summary>
    /// KeyPress event.
    /// </summary>
    private void Input_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ( HebrewAlphabet.Codes.Contains(e.KeyChar.ToString()) )
        KeyProcessed = true;
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
        if ( Input.SelectionStart > 0 )
          Input.SelectionStart--;
      }
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
