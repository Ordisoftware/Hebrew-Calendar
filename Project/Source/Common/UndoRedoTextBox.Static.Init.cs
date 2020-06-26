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
using System.ComponentModel;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  public partial class UndoRedoTextBox : TextBox
  {

    static private ContextMenuStrip ContextMenuEdit;
    static private ToolStripMenuItem ActionUndo;
    static private ToolStripMenuItem ActionRedo;
    static private ToolStripSeparator Separator1;
    static private ToolStripMenuItem ActionCopy;
    static private ToolStripMenuItem ActionCut;
    static private ToolStripMenuItem ActionPaste;
    static private ToolStripSeparator Separator2;
    static private ToolStripMenuItem ActionSelectAll;
    static private ToolStripMenuItem ActionDelete;

    static void InitializeContextMenu(IContainer container)
    {
      ContextMenuEdit = new ContextMenuStrip(container);
      ActionUndo = new ToolStripMenuItem();
      ActionRedo = new ToolStripMenuItem();
      Separator1 = new ToolStripSeparator();
      ActionCut = new ToolStripMenuItem();
      ActionCopy = new ToolStripMenuItem();
      ActionPaste = new ToolStripMenuItem();
      Separator2 = new ToolStripSeparator();
      ActionSelectAll = new ToolStripMenuItem();
      ActionDelete = new ToolStripMenuItem();
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

    static internal void Relocalize()
    {
      if ( ContextMenuEdit == null ) return;
      var resources = new ComponentResourceManager(typeof(UndoRedoTextBox));
      resources.ApplyResources(ContextMenuEdit, "ContextMenuEdit");
      resources.ApplyResources(ActionUndo, "ActionUndo");
      resources.ApplyResources(ActionRedo, "ActionRedo");
      resources.ApplyResources(ActionCut, "ActionCut");
      resources.ApplyResources(ActionCopy, "ActionCopy");
      resources.ApplyResources(ActionPaste, "ActionPaste");
      resources.ApplyResources(ActionSelectAll, "ActionSelectAll");
      resources.ApplyResources(ActionDelete, "ActionDelete");
    }

  }

}
