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
using System.Collections.Generic;
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
    /// Indicate max length of the input text.
    /// </summary>
    public int MaxLength
    {
      get { return _MaxLength; }
      set { _MaxLength = value; }
    }
    private int _MaxLength = 20;

    /// <summary>
    /// Input textbox text changed event.
    /// </summary>
    public event EventHandler InputTextChanged
    {
      add { Input.TextChanged += value; }
      remove { Input.TextChanged -= value; }
    }

    /// <summary>
    /// Indicates if a key is being processed.
    /// </summary>
    private bool KeyProcessed = false;

    private Stack<UndoRedoItem> UndoStack = new Stack<UndoRedoItem>();
    private Stack<UndoRedoItem> RedoStack = new Stack<UndoRedoItem>();

    private UndoRedoItem Previous = new UndoRedoItem();

    private bool UndoRedoMutex;

    /// <summary>
    /// Constructor
    /// </summary>
    public LettersControl()
    {
      InitializeComponent();
      CreateLetters();
    }

    /// <summary>
    /// Update menu items.
    /// </summary>
    private void ContextMenuStripInput_Opened(object sender, EventArgs e)
    {
      ActionCopy.Enabled = Input.SelectedText != "";
      ActionCut.Enabled = ActionCopy.Enabled;
      ActionPaste.Enabled = Clipboard.GetText() != "";
      ActionUndo.Enabled = UndoStack.Count != 0;
      ActionRedo.Enabled = RedoStack.Count != 0;
    }

    /// <summary>
    /// Letter icon click event
    /// </summary>
    private void ButtonLetter_Click(object sender, EventArgs e)
    {
      if ( Input.Text.Length < MaxLength )
      {
        Previous.Set(Input.Text, Input.SelectionStart);
        int pos = Input.SelectionStart;
        Input.Text = Input.Text.Insert(Input.SelectionStart, ( (Button)sender ).Text);
        Input.Focus();
        Input.SelectionLength = 0;
        Input.SelectionStart = pos;
      }
      OnClick(new LetterEventArgs(( (Button)sender ).Text));
    }

    /// <summary>
    /// TextChanged event.
    /// </summary>
    private void Input_TextChanged(object sender, EventArgs e)
    {
      if ( UndoRedoMutex ) return;
      UndoStack.Push(Previous);
      RedoStack.Clear();
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
    /// KeyPress event.
    /// </summary>
    private void Input_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ( HebrewAlphabet.Codes.Contains(e.KeyChar.ToString()) )
        KeyProcessed = true;
      else
      if ( e.KeyChar == '\b' ) // Back Space
      {
        int selectionStart = Input.SelectionStart;
        if ( selectionStart > 0 )
        {
          Input.Text = Input.Text.Remove(selectionStart - 1, 1);
          Input.SelectionStart = selectionStart - 1;
          e.Handled = true;
        }
      }
      else
      if ( Input.SelectedText != "" )
      {
        if ( e.KeyChar == '\u0018' ) // Ctrl+X
        {
          ActionCut.PerformClick();
          e.Handled = true;
        }
        else
        if ( e.KeyChar == '\u0003' ) // Ctrl+C
        {
          ActionCopy.PerformClick();
          e.Handled = true;
        }
      }
      else
      if ( e.KeyChar == '\u0016' ) // Ctrl+V
      {
        ActionPaste.PerformClick();
        e.Handled = true;
      }
      else
        e.KeyChar = '\x0';
    }

    /// <summary>
    /// KeyDown event.
    /// </summary>
    private void Input_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.Control && e.KeyCode == Keys.Z )
      {
        e.SuppressKeyPress = true;
        ActionUndo.PerformClick();
      }
      else
      if ( e.Control && e.KeyCode == Keys.Y )
      {
        e.SuppressKeyPress = true;
        ActionRedo.PerformClick();
      }
      else
      if ( e.Control && e.KeyCode == Keys.A )
      {
        e.SuppressKeyPress = true;
        Input.SelectAll();
      }
      else
      if ( e.Shift && e.KeyCode == Keys.Delete )
      {
        e.SuppressKeyPress = true;
        ActionCut.PerformClick();
      }
      else
      if ( e.Shift && e.KeyCode == Keys.Insert )
      {
        e.SuppressKeyPress = true;
        ActionPaste.PerformClick();
      }
      else
      if ( e.Control && e.KeyCode == Keys.Insert )
      {
        e.SuppressKeyPress = true;
        ActionCopy.PerformClick();
      }
      else
      if ( e.Control && e.KeyCode == Keys.Delete )
        e.SuppressKeyPress = true;
    }

    private void ActionCopy_Click(object sender, EventArgs e)
    {
      if ( Input.SelectedText == "" ) return;
      Clipboard.SetText(Input.SelectedText);
    }

    private void ActionCut_Click(object sender, EventArgs e)
    {
      if ( Input.SelectedText == "" ) return;
      Clipboard.SetText(Input.SelectedText);
      int selectionStart = Input.SelectionStart;
      Input.Text = Input.Text.Remove(selectionStart, Input.SelectionLength);
      Input.SelectionStart = selectionStart;
    }

    private void ActionPaste_Click(object sender, EventArgs e)
    {
      string str = Clipboard.GetText();
      if ( str == "" ) return;
      str = HebrewAlphabet.OnlyHebrewFont(str).Replace(" ", "");
      if ( Input.Text.Length + str.Length <= MaxLength )
      {
        int selectionStart = Input.SelectionStart;
        Input.SelectedText = str;
        Input.SelectionStart = selectionStart;
      }
    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      if ( UndoStack.Count == 0 ) return;
      UndoRedoMutex = true;
      Previous.Set(Input.Text, Input.SelectionStart);
      RedoStack.Push(new UndoRedoItem().Set(Input.Text, Input.SelectionStart));
      var item = UndoStack.Pop();
      Input.Text = item.Text;
      Input.SelectionStart = item.SelectionStart;
      UndoRedoMutex = false;
    }

    private void ActionRedo_Click(object sender, EventArgs e)
    {
      if ( RedoStack.Count == 0 ) return;
      UndoRedoMutex = true;
      UndoStack.Push(new UndoRedoItem().Set(Input.Text, Input.SelectionStart));
      var item = RedoStack.Pop();
      Input.Text = item.Text;
      Input.SelectionStart = item.SelectionStart;
      Previous.Set(Input.Text, Input.SelectionStart);
      UndoRedoMutex = false;
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

  /// <summary>
  ///  Provide undo or redo item
  /// </summary>
  public struct UndoRedoItem
  {
    public string Text;
    public int SelectionStart;
    public UndoRedoItem Set(string text, int selectionStart)
    {
      Text = text;
      SelectionStart = selectionStart;
      return this;
    }
  }

}