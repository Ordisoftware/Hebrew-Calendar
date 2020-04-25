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
/// <created> 2020-04 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

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

  public enum CaretPositionAfterPaste
  {
    Start,
    End
  }

  public enum TextInsertingMode
  {
    Full,
    Selected
  }

  public delegate void InsertingTextEventHandler(object sender, TextInsertingMode mode, ref string text);

  public partial class UndoRedoTextBox : TextBox
  {

    private bool SetTextMutex;
    private UndoRedoItem Previous = new UndoRedoItem();
    private Stack<UndoRedoItem> UndoStack = new Stack<UndoRedoItem>();
    private Stack<UndoRedoItem> RedoStack = new Stack<UndoRedoItem>();

    public CaretPositionAfterPaste CaretAfterPaste { get; set; }
      = CaretPositionAfterPaste.End;

    public event InsertingTextEventHandler InsertingText;

    public override string Text
    {
      get { return base.Text; }
      set
      {
        if ( value == null ) value = "";
        if ( value == Text ) return;
        if ( InsertingText != null ) InsertingText(this, TextInsertingMode.Full, ref value);
        if ( value.Length > MaxLength ) return;
        try
        {
          bool first = string.IsNullOrEmpty(Text) && UndoStack.Count == 0;
          if ( !SetTextMutex )
          {
            SetTextMutex = true;
            if ( !first ) AddUndo();
          }
          base.Text = value;
          if ( !first ) SetCaret(0, value.Length);
          SelectionLength = 0;
        }
        finally
        {
          SetTextMutex = false;
        }
      }
    }

    public override string SelectedText
    {
      get { return base.SelectedText; }
      set
      {
        if ( value == null ) value = "";
        if ( value == base.SelectedText ) return;
        if ( InsertingText != null ) InsertingText(this, TextInsertingMode.Selected, ref value);
        if ( Text.Length + value.Length - SelectionLength > MaxLength ) return;
        try
        {
          if ( !SetTextMutex )
          {
            SetTextMutex = true;
            AddUndo();
          }
          int selectionStart = SelectionStart;
          base.SelectedText = value;
          SetCaret(selectionStart, value.Length);
        }
        finally
        {
          SetTextMutex = false;
        }
      }
    }

    public UndoRedoTextBox()
    {
      InitializeComponent();
      if ( components == null ) components = new System.ComponentModel.Container();
      if ( ContextMenuEdit == null )
      {
        InitializeContextMenu(components);
        ContextMenuEdit.Opened += ContextMenuEdit_Opened;
        ActionUndo.Click += ActionUndo_Click;
        ActionRedo.Click += ActionRedo_Click;
        ActionCopy.Click += ActionCopy_Click;
        ActionCut.Click += ActionCut_Click;
        ActionPaste.Click += ActionPaste_Click;
        ActionSelectAll.Click += ActionSelectAll_Click;
      }
      ContextMenuStrip = ContextMenuEdit;
    }

    private void UpdateMenuItems(UndoRedoTextBox textbox)
    {
      if ( textbox == null ) return;
      bool b1 = textbox.Enabled;
      bool b2 = textbox.Enabled && !textbox.ReadOnly;
      bool b3 = !string.IsNullOrEmpty(textbox.SelectedText);
      ActionUndo.Enabled = b2 && textbox.UndoStack.Count != 0;
      ActionRedo.Enabled = b2 && textbox.RedoStack.Count != 0;
      ActionCopy.Enabled = b1 && b3;
      ActionCut.Enabled = b2 && b3;
      ActionPaste.Enabled = b2 && !string.IsNullOrEmpty(Clipboard.GetText());
      ActionSelectAll.Enabled = b1 && !string.IsNullOrEmpty(textbox.Text) && textbox.SelectionLength != textbox.TextLength;
    }

    private void ContextMenuEdit_Opened(object sender, EventArgs e)
    {
      UpdateMenuItems(GetTextBoxAndFocus(sender));
    }

    private void AddUndo()
    {
      if ( base.Text == null ) return;
      Previous.Set(base.Text, SelectionStart);
      UndoStack.Push(Previous);
      if ( RedoStack.Count > 0 )
        RedoStack.Clear();
    }

    private void SetCaret(int pos, int length)
    {
      switch ( CaretAfterPaste )
      {
        case CaretPositionAfterPaste.Start:
          SelectionStart = pos;
          break;
        case CaretPositionAfterPaste.End:
          SelectionStart = pos + length;
          break;
        default:
          throw new NotImplementedException();
      }
    }

    private void TextChangedEvent(object sender, EventArgs e)
    {
      if ( SetTextMutex ) return;
      UndoStack.Push(Previous);
      RedoStack.Clear();
    }

    private void KeyPressEvent(object sender, KeyPressEventArgs e)
    {
      if ( e.KeyChar == '\u0018' ) // Ctrl+X
        ActionCut.PerformClick();
      else
      if ( e.KeyChar == '\u0003' ) // Ctrl+C
        ActionCopy.PerformClick();
      else
      if ( e.KeyChar == '\u0016' ) // Ctrl+V
        ActionPaste.PerformClick();
      else
      if ( e.KeyChar == '\b' && SelectionStart > 0 ) // Back Space
      {
        var pos = SelectionStart;
        Text = Text.Remove(SelectionStart - 1, 1);
        SelectionStart = pos - 1;
      }
      else
        return;
      e.Handled = true;
    }

    private void KeyDownEvent(object sender, KeyEventArgs e)
    {
      Func<bool, Keys, Action<object, EventArgs>, bool> check = (condition, key, action) =>
      {
        if ( !condition || e.KeyCode != key ) return false;
        e.SuppressKeyPress = true;
        if ( action != null ) action(this, null);
        return true;
      };
      UpdateMenuItems(this);
      if ( !check(e.Control, Keys.A, ActionSelectAll_Click) )
        if ( !check(e.Control, Keys.Z, ActionUndo_Click) )
          if ( !check(e.Control, Keys.Y, ActionRedo_Click) )
            if ( !check(e.Control, Keys.Insert, ActionCopy_Click) )
              if ( !check(e.Shift, Keys.Delete, ActionCut_Click) )
                if ( !check(e.Shift, Keys.Insert, ActionPaste_Click) )
                  Previous.Set(Text, SelectionStart);
    }

    private void ActionSelectAll_Click(object sender, EventArgs e)
    {
      var textbox = GetTextBoxAndFocus(sender);
      if ( textbox == null || !textbox.Enabled ) return;
      textbox.SelectAll();
    }

    private void ActionCopy_Click(object sender, EventArgs e)
    {
      var textbox = GetTextBoxAndFocus(sender);
      if ( textbox == null || !textbox.Enabled ) return;
      if ( string.IsNullOrEmpty(textbox.SelectedText) ) return;
      Clipboard.SetText(textbox.SelectedText);
    }

    private void ActionCut_Click(object sender, EventArgs e)
    {
      var textbox = GetTextBoxAndFocus(sender);
      if ( textbox == null || !textbox.Enabled ) return;
      if ( textbox.ReadOnly ) return;
      if ( string.IsNullOrEmpty(textbox.SelectedText) ) return;
      Clipboard.SetText(textbox.SelectedText);
      int selectionStart = textbox.SelectionStart;
      textbox.Text = textbox.Text.Remove(selectionStart, textbox.SelectionLength);
      textbox.SelectionStart = selectionStart;
    }

    private void ActionPaste_Click(object sender, EventArgs e)
    {
      var textbox = GetTextBoxAndFocus(sender);
      if ( textbox == null || !textbox.Enabled ) return;
      if ( textbox.ReadOnly ) return;
      if ( string.IsNullOrEmpty(Clipboard.GetText()) ) return;
      textbox.SelectedText = Clipboard.GetText();
      textbox.ScrollToCaret();
    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      var textbox = GetTextBoxAndFocus(sender);
      if ( textbox == null || !textbox.Enabled ) return;
      if ( textbox.ReadOnly ) return;
      if ( textbox.UndoStack.Count == 0 ) return;
      try
      {
        textbox.SetTextMutex = true;
        textbox.Previous.Set(textbox.Text, textbox.SelectionStart);
        textbox.RedoStack.Push(new UndoRedoItem().Set(textbox.Text, textbox.SelectionStart));
        var item = textbox.UndoStack.Pop();
        textbox.Text = item.Text;
        textbox.SelectionStart = item.SelectionStart;
        textbox.ScrollToCaret();
      }
      finally
      {
        textbox.SetTextMutex = false;
      }
    }

    private void ActionRedo_Click(object sender, EventArgs e)
    {
      var textbox = GetTextBoxAndFocus(sender);
      if ( textbox == null || !textbox.Enabled ) return;
      if ( textbox.ReadOnly ) return;
      if ( textbox.RedoStack.Count == 0 ) return;
      try
      {
        textbox.SetTextMutex = true;
        textbox.UndoStack.Push(new UndoRedoItem().Set(textbox.Text, textbox.SelectionStart));
        var item = textbox.RedoStack.Pop();
        Text = item.Text;
        textbox.SelectionStart = item.SelectionStart;
        textbox.ScrollToCaret();
        textbox.Previous.Set(textbox.Text, textbox.SelectionStart);
      }
      finally
      {
        textbox.SetTextMutex = false;
      }
    }

  }

}
