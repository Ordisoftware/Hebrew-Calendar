/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
/// <edited> 2020-07 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  public struct UndoRedoItem
  {
    public string Text { get; set; }
    public int SelectionStart { get; set; }
    //public int SelectionLength { get; set; }
    public UndoRedoItem Set(string text, int selectionStart/*, int selectionLength*/)
    {
      Text = text;
      SelectionStart = selectionStart;
      //SelectionLength = selectionLength;
      return this;
    }
  }

  public enum CaretPositionAfterPaste
  {
    Beginning,
    Ending
  }

  public enum TextUpdating
  {
    Text,
    Selected
  }

  

  public delegate void InsertingTextEventHandler(object sender, TextUpdating mode, ref string text);

  //public delegate void ShowingContextMenuEventHandler(object sender, TextUpdating mode, ref string text);

  public partial class UndoRedoTextBox : TextBox
  {

    private bool SetTextMutex;
    private UndoRedoItem Previous = new UndoRedoItem();
    private Stack<UndoRedoItem> UndoStack = new Stack<UndoRedoItem>();
    private Stack<UndoRedoItem> RedoStack = new Stack<UndoRedoItem>();

    public CaretPositionAfterPaste CaretAfterPaste { get; set; }
      = CaretPositionAfterPaste.Ending;

    public event InsertingTextEventHandler InsertingText;

    public event System.ComponentModel.CancelEventHandler ContextMenuEditOpening
    {
      add { ContextMenuEdit.Opening += value; }
      remove { ContextMenuEdit.Opening -= value; }
    }

    public event EventHandler ContextMenuEditOpened
    {
      add { ContextMenuEdit.Opened += value; }
      remove { ContextMenuEdit.Opened -= value; }
    }

    public event ToolStripDropDownClosedEventHandler ContextMenuEditClosed
    {
      add { ContextMenuEdit.Closed += value; }
      remove { ContextMenuEdit.Closed -= value; }
    }

    /*public override string Text
    {
      get => base.Text;
      set
      {
        InsertingText?.Invoke(this, TextUpdating.Text, ref value);
        if ( value == null ) value = "";
        if ( value == Text ) return;
        if ( value.Length > MaxLength ) return;
        try
        {
          bool first = Text.IsNullOrEmpty() && UndoStack.Count == 0;
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
    }*/

    /*public override string SelectedText
    {
      get => base.SelectedText;
      set
      {
        InsertingText?.Invoke(this, TextUpdating.Selected, ref value);
        if ( value == null ) value = "";
        if ( value == base.SelectedText ) return;
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
    }*/

    public UndoRedoTextBox()
    {
      InitializeComponent();
      if ( ContextMenuEdit == null )
        InitializeContextMenu();
      ContextMenuStrip = ContextMenuEdit;
      //TextChanged += TextChangedEvent;
      //KeyPress += KeyPressEvent;
      //KeyDown += KeyDownEvent;
    }

    private void AddUndo()
    {
      return;
      //
      if ( base.Text == null ) return;
      Previous.Set(base.Text, SelectionStart/*, SelectionLength*/);
      UndoStack.Push(Previous);
      if ( RedoStack.Count > 0 )
        RedoStack.Clear();
    }

    private void SetCaret(int pos, int length)
    {
      switch ( CaretAfterPaste )
      {
        case CaretPositionAfterPaste.Beginning:
          SelectionStart = pos;
          break;
        case CaretPositionAfterPaste.Ending:
          SelectionStart = pos + length;
          break;
        default:
          throw new NotImplementedExceptionEx(CaretAfterPaste);
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
        ActionCut_Click(sender, null);
      else
      if ( e.KeyChar == '\u0003' ) // Ctrl+C
        ActionCopy_Click(sender, null);
      else
      if ( e.KeyChar == '\u0016' ) // Ctrl+V
        ActionPaste_Click(sender, null);
      else
      if ( e.KeyChar == '\b' && SelectionStart > 0 ) // Back Space
      {
        var pos = SelectionStart;
        Text = Text.Remove(SelectionStart - 1, 1);
        SelectionStart = pos - 1;
        if ( Multiline ) ScrollToCaret();
      }
      else
        return;
      e.Handled = true;
    }

    private void KeyDownEvent(object sender, KeyEventArgs e)
    {
      bool check(bool condition, Keys key, Action<object, EventArgs> action)
      {
        if ( !condition || e.KeyCode != key ) return false;
        e.SuppressKeyPress = true;
        action?.Invoke(this, null);
        return true;
      }
      UpdateMenuItems(this);
      if ( !check(e.Control, Keys.A, ActionSelectAll_Click)
        && !check(e.Control, Keys.Z, ActionUndo_Click)
        && !check(e.Control, Keys.Y, ActionRedo_Click)
        && !check(e.Control, Keys.Insert, ActionCopy_Click)
        && !check(e.Shift, Keys.Delete, ActionCut_Click)
        && !check(e.Shift, Keys.Insert, ActionPaste_Click) )
        Previous.Set(Text, SelectionStart/*, SelectionLength*/);
    }

  }

}
