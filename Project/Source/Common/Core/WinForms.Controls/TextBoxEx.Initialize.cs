/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2021-04 </edited>
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  partial class TextBoxEx
  {

    static private IContainer _Container;
    static private ContextMenuStrip ContextMenuEdit;

    static public readonly ToolStripMenuItem ActionUndo = new();
    static public readonly ToolStripMenuItem ActionRedo = new();
    static public readonly ToolStripSeparator Separator1 = new();
    static public readonly ToolStripMenuItem ActionCopy = new();
    static public readonly ToolStripMenuItem ActionCut = new();
    static public readonly ToolStripMenuItem ActionPaste = new();
    static public readonly ToolStripSeparator Separator2 = new();
    static public readonly ToolStripMenuItem ActionSelectAll = new();
    static public readonly ToolStripMenuItem ActionDelete = new();

    static void InitializeContextMenu()
    {
      _Container = new Container();
      ContextMenuEdit = new ContextMenuStrip(_Container);
      ContextMenuEdit.Opened += ContextMenuEdit_Opened;
      ActionUndo.Click += ActionUndo_Click;
      ActionRedo.Click += ActionRedo_Click;
      ActionCopy.Click += ActionCopy_Click;
      ActionCut.Click += ActionCut_Click;
      ActionPaste.Click += ActionPaste_Click;
      ActionSelectAll.Click += ActionSelectAll_Click;
      ActionDelete.Click += ActionDelete_Click;
      ContextMenuEdit.Name = "ContextMenuEdit";
      Separator1.Name = "Separator1";
      Separator2.Name = "Separator2";
      ActionUndo.Name = "ActionUndo";
      ActionUndo.Text = "Undo";
      ActionRedo.Name = "ActionRedo";
      ActionRedo.Text = "Redo";
      ActionCut.Name = "ActionCut";
      ActionCut.Text = "Cut";
      ActionCopy.Name = "ActionCopy";
      ActionCopy.Text = "Copy";
      ActionPaste.Name = "ActionPaste";
      ActionPaste.Text = "Paste";
      ActionSelectAll.Name = "ActionSelectAll";
      ActionSelectAll.Text = "Select All";
      ActionDelete.Name = "ActionDelete";
      ActionDelete.Text = "Delete";
      Relocalize();
      ContextMenuEdit.Items.AddRange(new ToolStripItem[]
                                     {
                                       ActionUndo,
                                       ActionRedo,
                                       Separator1,
                                       ActionCut,
                                       ActionCopy,
                                       ActionPaste,
                                       Separator2,
                                       ActionSelectAll,
                                       ActionDelete
                                     });
    }

    static public void Relocalize()
    {
      if ( ContextMenuEdit == null ) return;
      var resources = new ComponentResourceManager(typeof(TextBoxEx));
      resources.ApplyResources(ContextMenuEdit, "ContextMenuEdit");
      resources.ApplyResources(ActionUndo, "ActionUndo");
      resources.ApplyResources(ActionRedo, "ActionRedo");
      resources.ApplyResources(ActionCut, "ActionCut");
      resources.ApplyResources(ActionCopy, "ActionCopy");
      resources.ApplyResources(ActionPaste, "ActionPaste");
      resources.ApplyResources(ActionSelectAll, "ActionSelectAll");
      resources.ApplyResources(ActionDelete, "ActionDelete");
    }

    static private void ContextMenuEdit_Opened(object sender, EventArgs e)
    {
      UpdateMenuItems(GetTextBoxAndFocus(sender));
    }

    static private void UpdateMenuItems(TextBoxEx textbox)
    {
      if ( textbox == null ) return;
      bool b1 = textbox.Enabled;
      bool b2 = textbox.Enabled && !textbox.ReadOnly;
      bool b3 = !textbox.SelectedText.IsNullOrEmpty();
      ActionUndo.Enabled = b2 && ( textbox.UndoStack.Count != 0 || textbox.CanUndo );
      ActionRedo.Enabled = b2 && ( textbox.RedoStack.Count != 0 );
      ActionCopy.Enabled = b1 && b3;
      ActionCut.Enabled = b2 && b3;
      ActionPaste.Enabled = b2 && !Clipboard.GetText().IsNullOrEmpty();
      ActionSelectAll.Enabled = b1 && !textbox.Text.IsNullOrEmpty()
                                   && textbox.SelectionLength != textbox.TextLength;
      ActionDelete.Enabled = ActionCut.Enabled;
    }

  }

}
