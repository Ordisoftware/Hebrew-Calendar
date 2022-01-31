/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2021-02 </edited>
namespace Ordisoftware.Core;

partial class TextBoxEx
{

  static public TextBoxEx GetTextBox(object sender)
  {
    return GetTextBoxAndFocus(sender, false);
  }

  static public TextBoxEx GetTextBoxAndFocus(object sender, bool doFocus = true)
  {
    TextBoxEx control = sender as TextBoxEx;
    if ( control == null )
      if ( sender is ContextMenuStrip menuContext )
        control = menuContext.SourceControl as TextBoxEx;
      else
      if ( sender is ToolStripMenuItem menuItem )
        control = ( menuItem.GetCurrentParent() as ContextMenuStrip )?.SourceControl as TextBoxEx;
    if ( control == null )
    {
      var form = FormsHelper.GetActiveForm();
      if ( form != null )
      {
        if ( form.ActiveControl is TextBoxEx )
          control = form.ActiveControl as TextBoxEx;
        else
        if ( form.ActiveControl is UserControl )
          control = ( form.ActiveControl as UserControl )?.ActiveControl as TextBoxEx;
      }
    }
    if ( doFocus && control?.Enabled == true && !control.Focused )
      control.Focus();
    return control;
  }

  static private void ActionSelectAll_Click(object sender, EventArgs e)
  {
    var textbox = GetTextBoxAndFocus(sender);
    if ( textbox?.Enabled != true ) return;
    textbox.SelectAll();
  }

  static private void ActionCopy_Click(object sender, EventArgs e)
  {
    var textbox = GetTextBoxAndFocus(sender);
    if ( textbox?.Enabled != true ) return;
    if ( textbox.SelectedText.IsNullOrEmpty() ) return;
    Clipboard.SetText(textbox.SelectedText);
  }

  static private void ActionCut_Click(object sender, EventArgs e)
  {
    var textbox = GetTextBoxAndFocus(sender);
    if ( textbox?.Enabled != true ) return;
    if ( textbox.ReadOnly ) return;
    if ( textbox.SelectedText.IsNullOrEmpty() ) return;
    try
    {
      textbox.Cut();
      /*Clipboard.SetText(textbox.SelectedText);
      int selectionStart = textbox.SelectionStart;
      textbox.Text = textbox.Text.Remove(selectionStart, textbox.SelectionLength);
      textbox.SelectionStart = selectionStart;
      if ( textbox.Multiline ) textbox.ScrollToCaret();*/
    }
    finally
    {
      textbox.SetTextMutex = false;
    }
  }

  static private void ActionDelete_Click(object sender, EventArgs e)
  {
    var textbox = GetTextBoxAndFocus(sender);
    if ( textbox?.Enabled != true ) return;
    if ( textbox.ReadOnly ) return;
    if ( textbox.SelectedText.IsNullOrEmpty() ) return;
    try
    {
      SendKeys.Send("{DELETE}");
      /*int selectionStart = textbox.SelectionStart;
      textbox.SelectedText = textbox.Text.Remove(selectionStart, textbox.SelectionLength);
      textbox.SelectionStart = selectionStart;
      if ( textbox.Multiline ) textbox.ScrollToCaret();*/
    }
    finally
    {
      textbox.SetTextMutex = false;
    }
  }

  static private void ActionPaste_Click(object sender, EventArgs e)
  {
    var textbox = GetTextBoxAndFocus(sender);
    if ( textbox?.Enabled != true ) return;
    if ( textbox.ReadOnly ) return;
    if ( Clipboard.GetText().IsNullOrEmpty() ) return;
    try
    {
      int pos = textbox.SelectionStart;
      string strTemp = null;
      if ( textbox.InsertingText != null )
      {
        strTemp = Clipboard.GetText();
        string str = strTemp;
        textbox.InsertingText(textbox, TextUpdating.Text, ref str);
        if ( !str.IsNullOrEmpty() )
          Clipboard.SetText(str);
        else
          Clipboard.Clear();
      }
      textbox.Paste();
      if ( textbox.CaretAfterPaste == CaretPositionAfterPaste.Beginning )
        textbox.SelectionStart = pos;
      if ( strTemp != null )
        Clipboard.SetText(strTemp);
      /*textbox.SetTextMutex = true;
      textbox.SelectedText = Clipboard.GetText();
      if ( textbox.Multiline ) textbox.ScrollToCaret();*/
    }
    finally
    {
      textbox.SetTextMutex = false;
    }
  }

  static private void ActionUndo_Click(object sender, EventArgs e)
  {
    //if ( !Enabled ) return;
    //if ( sender is ToolStripMenuItem && !Focused ) Focus();
    //if ( ReadOnly ) return;
    //if ( UndoStack.Count == 0 ) return;
    //try
    //{
    //  SetTextMutex = true;
    //  Previous.Set(Text, SelectionStart);
    //  RedoStack.Push(new UndoRedoItem().Set(Text, SelectionStart));
    //  var item = UndoStack.Pop();
    //  Text = item.Text;
    //  SelectionStart = item.SelectionStart;
    //}
    //finally
    //{
    //  SetTextMutex = false;
    //}

    var textbox = GetTextBoxAndFocus(sender);
    if ( textbox?.Enabled != true ) return;
    if ( textbox.ReadOnly ) return;
    //if ( textbox.UndoStack.Count == 0 ) return;
    try
    {
      if ( textbox.CanUndo ) textbox.Undo();
      /*textbox.SetTextMutex = true;
      textbox.Previous.Set(textbox.Text, textbox.SelectionStart, textbox.SelectionLength);
      textbox.RedoStack.Push(new UndoRedoItem().Set(textbox.Text, textbox.SelectionStart, textbox.SelectionLength));
      var item = textbox.UndoStack.Pop();
      textbox.Text = item.Text;
      textbox.SelectionStart = item.SelectionStart;
      if ( textbox.Multiline ) textbox.ScrollToCaret();*/
    }
    finally
    {
      textbox.SetTextMutex = false;
    }
  }

  static private void ActionRedo_Click(object sender, EventArgs e)
  {
    //if ( !Enabled ) return;
    //if ( sender is ToolStripMenuItem && !Focused ) Focus();
    //if ( ReadOnly ) return;
    //if ( RedoStack.Count == 0 ) return;
    //try
    //{
    //  SetTextMutex = true;
    //  UndoStack.Push(new UndoRedoItem().Set(Text, SelectionStart));
    //  var item = RedoStack.Pop();
    //  Text = item.Text;
    //  SelectionStart = item.SelectionStart;
    //  Previous.Set(Text, SelectionStart);
    //}
    //finally
    //{
    //  SetTextMutex = false;
    //}

    /*var textbox = GetTextBoxAndFocus(sender);
    if ( textbox == null || !textbox.Enabled ) return;
    if ( textbox.ReadOnly ) return;
    if ( textbox.RedoStack.Count == 0 ) return;
    try
    {
      textbox.SetTextMutex = true;
      textbox.UndoStack.Push(new UndoRedoItem().Set(textbox.Text, textbox.SelectionStart, textbox.SelectionLength));
      var item = textbox.RedoStack.Pop();
      textbox.Text = item.Text;
      textbox.SelectionStart = item.SelectionStart;
      if ( textbox.Multiline ) textbox.ScrollToCaret();
      textbox.Previous.Set(textbox.Text, textbox.SelectionStart, textbox.SelectionLength);
    }
    finally
    {
      textbox.SetTextMutex = false;
    }*/
  }

}
