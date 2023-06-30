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
/// <edited> 2023-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

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
      //Program.DateBookmarks.ApplyAutoSort();
    }
  }

  private bool Ready;
  private bool Modified;

  // TODO ne pas connecter le setting autosort pour gérer save / cancel
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
    if ( Settings.DateBookmarksCount == 0 ) return;
    //var items = Program.DateBookmarks.Items.Where(item => item is not null).Select(item => new DateBookmarkItem(item));
    ListBox.Items.Clear();
    //ListBox.Items.AddRange(items.ToArray());
    if ( ListBox.Items.Count != 0 ) ListBox.SelectedIndex = 0;
    ActiveControl = ListBox;
    Ready = true;
  }

  private void ManageBookmarksForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if ( !ActionSave.Enabled ) return;
    if ( Globals.IsExiting )
    {
      this.Popup();
      DisplayManager.QueryYesNo(SysTranslations.AskToSaveChanges.GetLang(Text), Save);
    }
    else
      DisplayManager.QueryYesNoCancel(SysTranslations.AskToSaveChanges.GetLang(Text), Save, null, () => e.Cancel = true);
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
  }

  private void Save()
  {
    /*var items = ListBox.Items.AsIEnumerable<DateBookmarkItem>().Select(item => new DateBookmarkItem(item));
    Program.DateBookmarks.Items.Clear();
    Program.DateBookmarks.Items.AddRange(items);
    Program.DateBookmarks.ApplyAutoSort();
    SystemManager.TryCatch(Settings.Save);*/
  }

  private void EditAutoSort_CheckedChanged(object sender, EventArgs e)
  {
    if ( !Ready ) return;
    if ( EditAutoSort.Checked ) ActionSort.PerformClick();
    ListBox_SelectedIndexChanged(null, null);
  }

  private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
  {
    ActionSort.Enabled = !EditAutoSort.Checked && ListBox.Items.Count > 0;
    ActionUp.Enabled = !EditAutoSort.Checked && ListBox.SelectedIndex != 0;
    ActionDown.Enabled = !EditAutoSort.Checked && ListBox.SelectedIndex != ListBox.Items.Count - 1;
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
    ListBox.Items[index] = new DateBookmarkRow(bookmark.Date, memo);
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

  private void ActionClear_Click(object sender, EventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmarkAll.GetLang()) ) return;
    ListBox.Items.Clear();
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

  private void ActionDelete_Click(object sender, EventArgs e)
  {
    ListBox.Items.RemoveAt(ListBox.SelectedIndex);
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

  private void ActionUp_Click(object sender, EventArgs e)
  {
    ListBox.MoveSelectedItem(-1);
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

  private void ActionDown_Click(object sender, EventArgs e)
  {
    ListBox.MoveSelectedItem(1);
    Modified = true;
    ListBox_SelectedIndexChanged(null, null);
  }

  // https://stackoverflow.com/questions/3012647/custom-listbox-sorting#3013558
  private void ActionSort_Click(object sender, EventArgs e)
  {
    /*var item = ListBox.SelectedItem;
    ListBox.Sort((itemFirst, itemLast) =>
    {
      var first = ( (DateBookmarkItem)itemFirst );
      var last = ( (DateBookmarkItem)itemLast );
      if ( first is null ) return 1;
      if ( last is null ) return -1;
      return first.Date.CompareTo(last.Date);
    });
    Modified = true;
    ListBox.SelectedItem = item;
    ListBox_SelectedIndexChanged(null, null);*/
  }

}
