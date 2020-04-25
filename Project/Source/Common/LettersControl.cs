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

  public delegate void ViewLetterDetails(string code);

  /// <summary>
  /// Provide Letters input panel Control class.
  /// </summary>
  public partial class LettersControl : UserControl
  {

    public event ViewLetterDetails ViewLetterDetails;

    /// <summary>
    /// Indicate max length of the input text.
    /// </summary>
    public int MaxLengthInput
    {
      get { return Input.MaxLength; }
      set { Input.MaxLength = value; }
    }

    /// <summary>
    /// Indicate the background color of letters panel.
    /// </summary>
    public Color BackColorLetters
    {
      get { return PanelLetters.BackColor; }
      set { PanelLetters.BackColor = value; }
    }

    /// <summary>
    /// Indicate the background color of input textbox.
    /// </summary>
    public Color BackColorInput
    {
      get { return Input.BackColor; }
      set { Input.BackColor = value; }
    }

    /// <summary>
    /// Indicate hebrew letters font size
    /// </summary>
    public float FontSizeLetters
    {
      get { return _FontSizeLetters; }
      set
      {
        _FontSizeLetters = value;
        CreateLetters();
      }
    }
    private float _FontSizeLetters = 20.25F;

    /// <summary>
    /// Indicate values font size.
    /// </summary>
    public float FontSizeValues
    {
      get { return _FontSizeValues; }
      set
      {
        _FontSizeValues = value;
        CreateLetters();
      }
    }
    private float _FontSizeValues = 6.25F;

    /// <summary>
    /// Indicate keys font size.
    /// </summary>
    public float FontSizeKeys
    {
      get { return _FontSizeKeys; }
      set
      {
        _FontSizeKeys = value;
        CreateLetters();
      }
    }
    private float _FontSizeKeys = 8.25F;

    /// <summary>
    /// Indicate Input font size.
    /// </summary>
    public float FontSizeInput
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
    public string TextInput
    {
      get { return Input.Text; }
      set { Input.Text = value; }
    }

    /// <summary>
    /// Input Text property.
    /// </summary>
    public int SelectionStartInput
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
      Input.CaretAfterPaste = CaretPositionAfterPaste.Start;
      Input.MaxLength = 20;
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
    /// TextChanging event.
    /// </summary>
    private void Input_TextChanging(object sender, TextInsertingMode mode, ref string text)
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

    /// <summary>
    /// Letter icon click event.
    /// </summary>
    private void ButtonLetter_Click(object sender, EventArgs e)
    {
      Button button = null;
      if ( sender is Button )
        button = (Button)sender;
      else
      if ( sender is ToolStripMenuItem )
        button = (Button)( (ContextMenuStrip)( (ToolStripMenuItem)sender ).Owner ).SourceControl;
      if ( button != null )
        Input.SelectedText = button.Text;
      Input.Focus();
    }

    private void ActionLetterAddAtBegin_Click(object sender, EventArgs e)
    {
      Input.SelectionLength = 0;
      Input.SelectionStart = Input.Text.Length;
      ButtonLetter_Click(sender, e);
    }

    private void ActionLetterAddAtEnd_Click(object sender, EventArgs e)
    {
      Input.SelectionLength = 0;
      Input.SelectionStart = 0;
      ButtonLetter_Click(sender, e);
    }

    private void ActionLetterAddAtCaret_Click(object sender, EventArgs e)
    {
      ButtonLetter_Click(sender, e);
    }

    private void ActionLetterViewDetails_Click(object sender, EventArgs e)
    {
      if ( ViewLetterDetails == null ) return;
      var button = (Button)( (ContextMenuStrip)( (ToolStripMenuItem)sender ).Owner ).SourceControl;
      ViewLetterDetails(button.Text);
    }

    private void ContextMenuLetter_Opened(object sender, EventArgs e)
    {
      ActionLetterViewDetails.Enabled = ViewLetterDetails != null;
      ActionLetterAddAtBegin.Enabled = Input.Text.Length < Input.MaxLength;
      ActionLetterAddAtEnd.Enabled = ActionLetterAddAtBegin.Enabled;
      ActionLetterAddAtCaret.Enabled = ActionLetterAddAtBegin.Enabled;
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
