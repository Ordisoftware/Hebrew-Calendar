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
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide view letter details delegate.
  /// </summary>
  public delegate void ViewLetterDetails(LettersControl sender, string code);

  /// <summary>
  /// Provide Letters input panel Control class.
  /// </summary>
  public partial class LettersControl : UserControl
  {

    public const KnownColor DefaultInputBackColor = KnownColor.AliceBlue;
    public const KnownColor DefaultPanelLettersBackColor = KnownColor.LightYellow;
    public const float DefaultFontSizeLetters = 20.25F;
    public const float DefaultFontSizeValues = 6.25F;
    public const float DefaultFontSizeKeys = 8.25F;
    public const float DefaultFontSizeInput = 24F;
    public const int DefaultInputMaxLength = 20;

    /// <summary>
    /// Indicate view letter details event.
    /// </summary>
    public event ViewLetterDetails ViewLetterDetails;

    /// <summary>
    /// Indicate Input TextChanged event.
    /// </summary>
    public event EventHandler InputTextChanged
    {
      add { Input.TextChanged += value; }
      remove { Input.TextChanged -= value; }
    }

    /// <summary>
    /// Indicate Input Text property.
    /// </summary>
    public string InputText
    {
      get => Input.Text;
      set => Input.Text = value;
    }

    /// <summary>
    /// Indicate Input SelectionStart property.
    /// </summary>
    public int InputSelectionStart
    {
      get => Input.SelectionStart;
      set => Input.SelectionStart = value;
    }

    /// <summary>
    /// Indicate Input MaxLength property.
    /// </summary>
    [DefaultValue(DefaultInputMaxLength)]
    public int InputMaxLength
    {
      get => Input.MaxLength;
      set => Input.MaxLength = value;
    }

    /// <summary>
    /// Indicate the background color of letters panel.
    /// </summary>
    [DefaultValue(typeof(Color), "LightYellow")]
    public Color LettersBackColor
    {
      get => PanelLetters.BackColor;
      set => PanelLetters.BackColor = value;
    }

    /// <summary>
    /// Indicate the background color of input textbox.
    /// </summary>
    [DefaultValue(typeof(Color), "AliceBlue")]
    public Color InputBackColor
    {
      get => Input.BackColor;
      set => Input.BackColor = value;
    }

    /// <summary>
    /// Indicate hebrew letters font size
    /// </summary>
    [DefaultValue(DefaultFontSizeLetters)]
    public float FontSizeLetters
    {
      get => _FontSizeLetters;
      set
      {
        if ( _FontSizeLetters == value ) return;
        _FontSizeLetters = value;
        Redraw();
      }
    }
    private float _FontSizeLetters = DefaultFontSizeLetters;

    /// <summary>
    /// Indicate values font size.
    /// </summary>
    [DefaultValue(DefaultFontSizeValues)]
    public float FontSizeValues
    {
      get => _FontSizeValues;
      set
      {
        if ( _FontSizeValues == value ) return;
        _FontSizeValues = value;
        Redraw();
      }
    }
    private float _FontSizeValues = DefaultFontSizeValues;

    /// <summary>
    /// Indicate keys font size.
    /// </summary>
    [DefaultValue(DefaultFontSizeKeys)]
    public float FontSizeKeys
    {
      get => _FontSizeKeys;
      set
      {
        if ( _FontSizeKeys == value ) return;
        _FontSizeKeys = value;
        Redraw();
      }
    }
    private float _FontSizeKeys = DefaultFontSizeKeys;

    /// <summary>
    /// Indicate Input font size.
    /// </summary>
    [DefaultValue(DefaultFontSizeInput)]
    public float FontSizeInput
    {
      get => Input.Font.Size;
      set
      {
        if ( Input.Font.Size == value ) return;
        Input.Font = new Font(Input.Font.FontFamily, value, Input.Font.Style);
        Redraw();
      }
    }

    /// <summary>
    /// Indicate if letters values must be shown.
    /// </summary>
    [DefaultValue(true)]
    public bool ShowValues
    {
      get => _ShowValues;
      set
      {
        if ( _ShowValues == value ) return;
        _ShowValues = value;
        Redraw();
      }
    }
    private bool _ShowValues = true;

    /// <summary>
    /// Indicate if keys codes must be shown.
    /// </summary>
    [DefaultValue(true)]
    public bool ShowKeys
    {
      get => _ShowKeys;
      set
      {
        if ( _ShowKeys == value ) return;
        _ShowKeys = value;
        Redraw();
      }
    }
    private bool _ShowKeys = true;

    /// <summary>
    /// Indicate if an input key is processed.
    /// </summary>
    private bool KeyProcessed;

    /// <summary>
    /// Constructor.
    /// </summary>
    public LettersControl()
    {
      InitializeComponent();
      Input.MaxLength = DefaultInputMaxLength;
      Input.Font = new Font(Input.Font.FontFamily, DefaultFontSizeInput, Input.Font.Style);
      Input.CaretAfterPaste = CaretPositionAfterPaste.Beginning;
      Input.BackColor = Color.FromKnownColor(DefaultInputBackColor);
      PanelLetters.BackColor = Color.FromKnownColor(DefaultPanelLettersBackColor);
      _ShowKeys = true;
      _ShowValues = true;
    }


    /// <summary>
    /// Control load event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LettersControl_Load(object sender, EventArgs e)
    {
      Redraw();
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
    /// Input TextChanging event.
    /// </summary>
    private void Input_TextChanging(object sender, TextUpdating mode, ref string text)
    {
      text = HebrewAlphabet.OnlyHebrewFont(text).Replace(" ", string.Empty);
    }

    /// <summary>
    /// Input KeyPress event.
    /// </summary>
    private void Input_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ( HebrewAlphabet.Codes.Contains(e.KeyChar.ToString()) )
        KeyProcessed = true;
      else
        e.KeyChar = '\x0';
    }

    /// <summary>
    /// Input KeyUp event.
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
    /// Button letter icon click event.
    /// </summary>
    private void ButtonLetter_Click(object sender, EventArgs e)
    {
      Button button = null;
      if ( sender is Button buttonSender )
        button = buttonSender;
      else
      if ( sender is ToolStripMenuItem menuItem )
        button = (Button)( (ContextMenuStrip)menuItem.Owner ).SourceControl;
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
      ViewLetterDetails(this, button.Text);
    }

    private void ContextMenuLetter_Opened(object sender, EventArgs e)
    {
      ActionLetterAddAtBegin.Enabled = Input.Text.Length < Input.MaxLength;
      ActionLetterAddAtEnd.Enabled = ActionLetterAddAtBegin.Enabled;
      ActionLetterAddAtCaret.Enabled = ActionLetterAddAtBegin.Enabled;
      ActionLetterViewDetails.Enabled = ViewLetterDetails != null;
      MenuItemSeparator.Enabled = ActionLetterViewDetails.Enabled;
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
