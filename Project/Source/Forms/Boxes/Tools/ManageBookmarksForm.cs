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
/// <edited> 2023-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class ManageBookmarksForm : Form
{

  private sealed record class ListItem(DateBookmarkItem BookmarkItem)
  {
    public override string ToString() => BookmarkItem.Date.ToLongDateString();
  }

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
      Program.DateBookmarks.ApplyAutoSort();
    }
  }

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
    this.CenterToFormElseMainFormElseScreen(DatesDiffCalculatorForm.Instance);
    if ( Settings.DateBookmarksCount == 0 ) return;
    var items = Program.DateBookmarks.Items.Where(item => item is not null).Select(item => new ListItem(item));
    ListBox.Items.Clear();
    ListBox.Items.AddRange(items.ToArray());
    ListBox.SelectedIndex = 0;
    ActiveControl = ListBox;
    ActionClear.Enabled = ListBox.Items.Count > 0;
    ActionSort.Enabled = ListBox.Items.Count > 0 && !Program.Settings.AutoSortBookmarks;
    ActionUp.Enabled = !Settings.AutoSortBookmarks;
    ActionDown.Enabled = !Settings.AutoSortBookmarks;
  }

  private void ManageDateBookmarks_FormClosed(object sender, FormClosedEventArgs e)
  {
    if ( DialogResult != DialogResult.OK ) return;
    var items = this.ListBox.Items.AsIEnumerable<ListItem>().Select(item => item.BookmarkItem);
    Program.DateBookmarks.Items.Clear();
    Program.DateBookmarks.Items.AddRange(items);
    Program.DateBookmarks.ApplyAutoSort();
    SystemManager.TryCatch(Settings.Save);
  }

  private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
  {
    ActionUp.Enabled = !Settings.AutoSortBookmarks && ListBox.SelectedIndex != 0;
    ActionDown.Enabled = !Settings.AutoSortBookmarks && ListBox.SelectedIndex != ListBox.Items.Count - 1;
    ActionDelete.Enabled = ListBox.SelectedIndex >= 0
                        && ( (ListItem)ListBox.Items[ListBox.SelectedIndex] ).BookmarkItem is not null;
  }

  private void ActionExport_Click(object sender, EventArgs e)
  {
    DoActionExport();
  }

  private void ActionImport_Click(object sender, EventArgs e)
  {
    DoActionImport();
  }

  private void ActionClear_Click(object sender, EventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmarkAll.GetLang()) ) return;
    ListBox.Items.Clear();
  }

  private void ActionDelete_Click(object sender, EventArgs e)
  {
    ListBox.Items.RemoveAt(ListBox.SelectedIndex);
    ListBox.Focus();
  }

  private void ActionUp_Click(object sender, EventArgs e)
  {
    ListBox.MoveSelectedItem(-1);
    ListBox.Focus();
  }

  private void ActionDown_Click(object sender, EventArgs e)
  {
    ListBox.MoveSelectedItem(1);
    ListBox.Focus();
  }

  // https://stackoverflow.com/questions/3012647/custom-listbox-sorting#3013558
  private void ActionSort_Click(object sender, EventArgs e)
  {
    ListBox.Sort((itemFirst, itemLast) =>
    {
      var first = ( (ListItem)itemFirst ).BookmarkItem;
      var last = ( (ListItem)itemLast ).BookmarkItem;
      if ( first is null ) return 1;
      if ( last is null ) return -1;
      return first.Date.CompareTo(last.Date);
    });
    ListBox_SelectedIndexChanged(null, null);
    ListBox.Focus();
  }

}
