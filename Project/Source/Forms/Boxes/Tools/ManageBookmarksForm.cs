/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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

using Equin.ApplicationFramework;

sealed partial class ManageBookmarksForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  public ApplicationDatabase DBApp => ApplicationDatabase.Instance;

  static public bool Run()
  {
    bool trayEnabled = MainForm.Instance.MenuTray.Enabled;
    MainForm.Instance.MenuTray.Enabled = false;
    try
    {
      using var form = new ManageBookmarksForm();
      return form.ShowDialog() == DialogResult.OK;
    }
    finally
    {
      MainForm.Instance.MenuTray.Enabled = trayEnabled;
    }
  }

  //private bool Ready;
  private bool Modified;

  private ManageBookmarksForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    SaveBookmarksDialog.InitialDirectory = Settings.GetExportDirectory();
    OpenBookmarksDialog.InitialDirectory = SaveBookmarksDialog.InitialDirectory;
    SaveBookmarksDialog.Filter = Program.BoardExportTargets.CreateFilters();
    OpenBookmarksDialog.Filter = SaveBookmarksDialog.Filter;
  }

  private void ManageDateBookmarks_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
    BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
    if ( EditBookmarks.Rows.Count > 0 ) EditBookmarks.Rows[0].Selected = true;
    ActiveControl = EditBookmarks;
    UpdateDataControls();
  }

  private void ManageBookmarksForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if ( Globals.IsExiting ) return;
    if ( Globals.IsSessionEnding ) return;
    if ( !ActionClose.Enabled ) e.Cancel = true;
  }

  private void ActionExport_Click(object sender, EventArgs e)
  {
    DoActionExport();
    UpdateDataControls();
  }

  private void ActionImport_Click(object sender, EventArgs e)
  {
    DoActionImport();
    Modified = true;
    UpdateDataControls();
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

  private void ActionAdd_Click(object sender, EventArgs e)
  {
    var date = DateTime.Today;
    if ( !SelectDayForm.Run(null, ref date) ) return;
    string memo = string.Empty;
    if ( DisplayManager.QueryValue(ColumnMemo.HeaderText, ref memo) == InputValueResult.Cancelled ) return;
    DBApp.BeginTransaction();
    var objectview = DBApp.DateBookmarksAsBindingListView.AddNew();
    objectview.Object.Date = date;
    objectview.Object.Memo = memo;
    DBApp.Connection.Insert(objectview.Object);
    DBApp.DateBookmarks.Add(objectview.Object);
    BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
    Modified = true;
    UpdateDataControls();
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
    UpdateDataControls();
  }

  private void ActionClear_Click(object sender, EventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmarkAll.GetLang()) ) return;
    DBApp.BeginTransaction();
    DBApp.Connection.DeleteAll<DateBookmarkRow>();
    int count = BindingSource.Count;
    for ( int index = 0; index < count; index++ )
    {
      BindingSource.RemoveAt(0);
      DBApp.DateBookmarks.RemoveAt(0);
    }
    Modified = true;
    UpdateDataControls();
  }

  private void EditBookmarks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
  {
    if ( EditBookmarks.IsCurrentCellInEditMode ) return;
    EditBookmarks.BeginEdit(false);
  }

  private string OriginalMemoBeforeEdit;

  private void EditBookmarks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    var cell = EditBookmarks[e.ColumnIndex, e.RowIndex];
    OriginalMemoBeforeEdit = (string)cell.Value;
    UpdateDataControls(true);
  }

  private void EditBookmarks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    var cell = EditBookmarks[e.ColumnIndex, e.RowIndex];
    var str = (string)cell.Value;
    if ( str.StartsWith(" ", StringComparison.Ordinal) || str.EndsWith(" ", StringComparison.Ordinal) )
      cell.Value = str.Trim();
    Modified = Modified || OriginalMemoBeforeEdit != str;
    UpdateDataControls();
  }

  private void EditBookmarks_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( e.FormattedValue == DBNull.Value )
      e.Cancel = true;
    else
      UpdateDataControls();
  }

  private void EditBookmarks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( Globals.IsReadOnly ) return;
    if ( e.ColumnIndex == -1 || e.RowIndex == -1 ) return;
    UpdateDataControls();
  }

  private void EditBookmarks_KeyDown(object sender, KeyEventArgs e)
  {
    if ( ( e.Control && e.KeyCode == Keys.Delete ) || ( e.Control && e.KeyCode == Keys.Subtract ) )
      ActionDelete.PerformClick();
    else
    if ( e.KeyCode == Keys.Enter && !EditBookmarks.IsCurrentCellInEditMode )
      EditBookmarks.BeginEdit(false);
    else
      return;
    e.Handled = true;
    e.SuppressKeyPress = true;
  }

  private void ActionSave_Click(object sender, EventArgs e)
  {
    DBApp.SaveBookmarks();
    Modified = false;
    UpdateDataControls();
    EditBookmarks.Focus();
    ApplicationStatistics.UpdateDBFileSizeRequired = true;
    ApplicationStatistics.UpdateDBMemorySizeRequired = true;
  }

  private void ActionUndo_Click(object sender, EventArgs e)
  {
    DBApp.LoadBookmarks();
    BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
    Modified = false;
    UpdateDataControls();
    EditBookmarks.Focus();
  }

  private void UpdateDataControls(bool forceEditMode = false)
  {
    try
    {
      forceEditMode = forceEditMode || EditBookmarks.IsCurrentCellInEditMode;
      ActionDelete.Enabled = !Globals.IsReadOnly && !forceEditMode && EditBookmarks.Rows.Count > 0;
      ActionClear.Enabled = ActionDelete.Enabled;
      ActionSave.Enabled = Modified && !forceEditMode;
      ActionUndo.Enabled = ActionSave.Enabled;
      ActionClose.Enabled = !ActionSave.Enabled;
      ActionImport.Enabled = ActionClose.Enabled;
      ActionExport.Enabled = ActionClose.Enabled;
      Globals.AllowClose = ActionClose.Enabled;
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

}
