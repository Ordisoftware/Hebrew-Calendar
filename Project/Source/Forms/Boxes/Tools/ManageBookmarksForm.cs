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

  private bool Ready;
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
    BindingSource.DataSource = ApplicationDatabase.Instance.DateBookmarksAsBindingListView;
    if ( ListBox.Items.Count != 0 ) ListBox.SelectedIndex = 0;
    ActiveControl = ListBox;
    Ready = true;
  }

  private void ManageBookmarksForm_Shown(object sender, EventArgs e)
  {
    ApplicationDatabase.Instance.BeginTransaction();
  }

  private void ManageBookmarksForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if ( !ActionSave.Enabled ) return;
    string message = SysTranslations.AskToSaveChanges.GetLang(Text);
    if ( Globals.IsExiting )
    {
      this.Popup();
      DisplayManager.QueryYesNo(message, Save);
    }
    else
    {
      DisplayManager.QueryYesNoCancel(message, Save, null, () => e.Cancel = true);
    }
  }

  private void ActionSave_Click(object sender, EventArgs e)
  {
    Save();
    ActionSave.Enabled = false;
    Close();
  }

  private void ActionCancel_Click(object sender, EventArgs e)
  {
    ActionSave.Enabled = false;
    ApplicationDatabase.Instance.Rollback();
    ApplicationDatabase.Instance.LoadBookmarksAndCreateBindingList();
  }

  private void Save()
  {
    ApplicationDatabase.Instance.Commit();
  }

  private void ActionDelete_Click(object sender, EventArgs e)
  {
    var item = (ObjectView<DateBookmarkRow>)ListBox.SelectedItem;
    ApplicationDatabase.Instance.Connection.Delete(item.Object);
    BindingSource.Remove(item.Object);
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

  private void ActionClear_Click(object sender, EventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmarkAll.GetLang()) ) return;
    ApplicationDatabase.Instance.Connection.DeleteAll<DateBookmarkRow>();
    int count = BindingSource.Count;
    for ( int index = 0; index < count; index++ )
      BindingSource.RemoveAt(0);
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

  private void EditAutoSort_CheckedChanged(object sender, EventArgs e)
  {
    if ( !Ready ) return;
    ListBox_SelectedIndexChanged(null, null);
  }

  private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
  {
    ActionDelete.Enabled = ListBox.SelectedIndex >= 0;
    ActionClear.Enabled = ListBox.Items.Count > 0;
    ActionSave.Enabled = Modified;
    ListBox.Focus();
  }

  private void ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    var bookmark = ( (DateBookmarkRow)ListBox.SelectedItem );
    string memo = bookmark.Memo;
    if ( DisplayManager.QueryValue(SysTranslations.Memo.GetLang(),
                                   bookmark.Date.ToLongDateString(),
                                   ref memo) != InputValueResult.Modified ) return;
    int index = ListBox.SelectedIndex;
    ( (DateBookmarkRow)ListBox.Items[index] ).Memo = memo;
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

  private void ActionExport_Click(object sender, EventArgs e)
  {
    DoActionExport();
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

  private void ActionImport_Click(object sender, EventArgs e)
  {
    DoActionImport();
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

}
