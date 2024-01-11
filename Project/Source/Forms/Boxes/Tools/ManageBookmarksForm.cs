/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.Windows.Forms;
using Equin.ApplicationFramework;

sealed partial class ManageBookmarksForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  static private ApplicationDatabase DBApp => ApplicationDatabase.Instance;

  static public void Run()
  {
    MainForm.Instance.FreezeUI();
    try
    {
      using var form = new ManageBookmarksForm();
      form.ShowDialog();
    }
    finally
    {
      MainForm.Instance.RestoreUI();
    }
  }

  private bool Modified;

  private string OriginalMemoBeforeEdit;

  private ManageBookmarksForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    OpenBookmarksDialog.InitialDirectory = Settings.GetExportBookmarksDirectory();
    SaveBookmarksDialog.InitialDirectory = Settings.GetExportBookmarksDirectory();
    OpenBookmarksDialog.Filter = Program.BoardExportTargets.CreateFilters();
    SaveBookmarksDialog.Filter = Program.GridExportTargets.CreateFilters();
  }

  private void ManageDateBookmarks_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
    BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
    ActiveControl = EditBookmarks;
  }

  private void ManageBookmarksForm_Shown(object sender, EventArgs e)
  {
    UpdateControls();
  }

  private void ManageBookmarksForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if ( Globals.IsExiting ) return;
    if ( Globals.IsSessionEnding ) return;
    if ( !ActionClose.Enabled ) e.Cancel = true;
  }

  private void ManageBookmarksForm_SizeChanged(object sender, EventArgs e)
  {
    RefreshGridRow();
  }

  private void RefreshGridRow()
  {
    if ( EditBookmarks.SelectedRows.Count > 0 )
    {
      var row = EditBookmarks.SelectedRows[0];
      row.Selected = false;
      EditBookmarks.Refresh();
      row.Selected = true;
    }
  }

  private void UpdateControls(bool doGridRowRefresh = true, bool forceEditMode = false)
  {
    var color = SystemColors.ControlText.ToArgb();
    try
    {
      forceEditMode = forceEditMode || EditBookmarks.IsCurrentCellInEditMode;
      ActionDelete.Enabled = !forceEditMode && EditBookmarks.Rows.Count > 0;
      ActionClear.Enabled = ActionDelete.Enabled;
      ActionAdd.Enabled = ActionDelete.Enabled;
      ActionSave.Enabled = Modified;
      ActionUndo.Enabled = Modified;
      ActionClose.Enabled = !ActionSave.Enabled && !forceEditMode;
      ActionImport.Enabled = ActionClose.Enabled;
      ActionExport.Enabled = ActionClose.Enabled && EditBookmarks.Rows.Count > 0;
      Globals.AllowClose = ActionClose.Enabled;
      ActionResetColors.Enabled = EditBookmarks.Rows
                                               .AsIEnumerable()
                                               .Select(row => ( (ObjectView<DateBookmarkRow>)row.DataBoundItem ).Object)
                                               .Any(item => item.Color.ToArgb() != color);
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      EditBookmarks.Focus();
      if ( doGridRowRefresh )
        RefreshGridRow();
    }
  }

  private void ActionExport_Click(object sender, EventArgs e)
  {
    DoActionExport();
    UpdateControls();
  }

  private void ActionImport_Click(object sender, EventArgs e)
  {
    DoActionImport();
    UpdateControls();
  }

  private void ActionResetColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(AppTranslations.AskToResetColors.GetLang()) ) return;
    DBApp.BeginTransaction();
    var list = EditBookmarks.Rows
                            .AsIEnumerable()
                            .Select(row => ( (ObjectView<DateBookmarkRow>)row.DataBoundItem ).Object);
    foreach ( var item in list )
      item.Color = Settings.DateBookmarkDefaultTextColor;
    Modified = true;
    UpdateControls();
  }

  private void ActionSave_Click(object sender, EventArgs e)
  {
    DBApp.SaveBookmarks();
    Modified = false;
    UpdateControls(false);
    ApplicationStatistics.UpdateDBFileSizeRequired = true;
    ApplicationStatistics.UpdateDBMemorySizeRequired = true;
  }

  private void ActionUndo_Click(object sender, EventArgs e)
  {
    DBApp.LoadBookmarks();
    BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
    Modified = false;
    UpdateControls();
  }

  private void ActionAdd_Click(object sender, EventArgs e)
  {
    var date = DateTime.Today;
    if ( !SelectDayForm.Run(null, ref date) ) return;
    var row = DBApp.DateBookmarks.Find(item => item.Date == date);
    if ( row is not null )
    {
      BindingSource.Position = BindingSource.Find("ID", row.ID);
      return;
    }
    var list = (BindingListView<DateBookmarkRow>)BindingSource.DataSource;
    var bookmark = DateBookmarkRow.CreateFromUserInput(date, true, list);
    BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
    BindingSource.Position = BindingSource.Find("ID", bookmark.ID);
    Modified = true;
    UpdateControls();
  }

  private void ActionDelete_Click(object sender, EventArgs e)
  {
    if ( BindingSource.Count < 1 ) return;
    var bookmark = ( (ObjectView<DateBookmarkRow>)BindingSource.Current ).Object;
    DBApp.BeginTransaction();
    DBApp.Connection.Delete(bookmark);
    DBApp.DateBookmarks.Remove(bookmark);
    BindingSource.RemoveCurrent();
    int count = BindingSource.Count;
    if ( count > 1 )
    {
      int index = BindingSource.Position;
      if ( index >= count )
      {
        BindingSource.MoveFirst();
        BindingSource.MoveLast();
      }
      else
        BindingSource.Position = index;
    }
    Modified = true;
    UpdateControls();
  }

  private void ActionClear_Click(object sender, EventArgs e)
  {
    if ( e is not null && !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmarkAll.GetLang()) )
      return;
    DBApp.BeginTransaction();
    DBApp.Connection.DeleteAll<DateBookmarkRow>();
    int count = BindingSource.Count;
    for ( int index = 0; index < count; index++ )
    {
      BindingSource.RemoveAt(0);
      DBApp.DateBookmarks.RemoveAt(0);
    }
    Modified = true;
    UpdateControls();
  }

  private void EditBookmarks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
  {
    if ( EditBookmarks.IsCurrentCellInEditMode ) return;
    EditBookmarks.BeginEdit(false);
  }

  private void EditBookmarks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    DBApp.BeginTransaction();
    var cell = EditBookmarks[e.ColumnIndex, e.RowIndex];
    OriginalMemoBeforeEdit = (string)cell.Value;
    UpdateControls(false, true);
  }

  private void EditBookmarks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    var cell = EditBookmarks[e.ColumnIndex, e.RowIndex];
    var str = (string)cell.Value;
    if ( str.StartsWith(" ", StringComparison.Ordinal) || str.EndsWith(" ", StringComparison.Ordinal) )
      cell.Value = str.Trim();
    Modified = Modified || OriginalMemoBeforeEdit != str;
    UpdateControls(false);
  }

  private void EditBookmarks_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( e.FormattedValue == DBNull.Value )
      e.Cancel = true;
    else
      UpdateControls(false);
  }

  private void EditBookmarks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( Globals.IsReadOnly ) return;
    if ( e.ColumnIndex == -1 || e.RowIndex == -1 ) return;
    UpdateControls(false);
  }

  private void EditBookmarks_KeyDown(object sender, KeyEventArgs e)
  {
    if ( ( e.Control && e.KeyCode == Keys.Insert ) || ( e.Control && e.KeyCode == Keys.Add ) )
      ActionAdd.PerformClick();
    else
    if ( ( e.Control && e.KeyCode == Keys.Delete ) || ( e.Control && e.KeyCode == Keys.Subtract ) )
      ActionDelete.PerformClick();
    else
    if ( !EditBookmarks.IsCurrentCellInEditMode && ( e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter ) )
      EditBookmarks.BeginEdit(false);
    else
      return;
    e.Handled = true;
    e.SuppressKeyPress = true;
  }

  private void EditBookmarks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
  {
    if ( e.Value is null ) return;
    if ( e.ColumnIndex == ColumnDate.Index && Settings.BoookmarkDisplayLunarDate )
    {
      var row = EditBookmarks.Rows[e.RowIndex];
      var boundItem = ( (ObjectView<DateBookmarkRow>)row.DataBoundItem ).Object;
      e.Value = boundItem.ToStringForGrid();
    }
    if ( e.ColumnIndex == ColumnColor.Index )
    {
      var row = EditBookmarks.Rows[e.RowIndex];
      var boundItem = ( (ObjectView<DateBookmarkRow>)row.DataBoundItem ).Object;
      e.CellStyle.BackColor = boundItem.Color;
    }
  }

  private void EditBookmarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
  {
    if ( e.RowIndex < 0 || e.ColumnIndex != ColumnColor.Index ) return;
    ActionEditColor_Click(sender, e);
  }

  [SuppressMessage("Refactoring", "GCop622:Reverse your IF condition and return. Then move the nested statements to after the IF.", Justification = "Opinion")]
  private void ActionEditColor_Click(object sender, DataGridViewCellEventArgs e)
  {
    DBApp.BeginTransaction();
    var row = EditBookmarks.SelectedRows[0];
    var boundItem = ( (ObjectView<DateBookmarkRow>)row.DataBoundItem ).Object;
    ColorDialog.Color = boundItem.Color;
    var res = ColorDialog.ShowDialog();
    if ( res != DialogResult.OK || ColorDialog.Color == boundItem.Color ) return;
    row.Cells[ColumnColor.Index].Style.BackColor = ColorDialog.Color;
    boundItem.Color = ColorDialog.Color;
    Modified = true;
    UpdateControls();
  }

  private void EditBookmarks_DataError(object sender, DataGridViewDataErrorEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( e.Exception is ArgumentOutOfRangeException || e.Exception is IndexOutOfRangeException )
    {
      DisplayManager.ShowError($"DB Index error.{Globals.NL2}{SysTranslations.ApplicationMustExit.GetLang()}");
      e.Exception.Manage();
      DBApp.Connection.Rollback();
      Application.Exit();
    }
    else
      e.Exception.Manage();
  }

}
