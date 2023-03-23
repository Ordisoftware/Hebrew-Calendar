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
/// <edited> 2022-08 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class ManageBookmarksForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  private sealed class DateItem
  {
    public DateTime Date { get; set; }
    public override string ToString()
    {
      return Date == DateTime.MinValue ? SysTranslations.EmptySlot.GetLang() : Date.ToLongDateString();
    }
  }

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
    ListBox.Items.Clear();
    if ( Settings.DateBookmarksCount == 0 ) return;
    for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
      ListBox.Items.Add(new DateItem { Date = Program.DateBookmarks[index] });
    ListBox.SelectedIndex = 0;
    ActiveControl = ListBox;
    ActionClear.Enabled = ListBox.Items.Count > 0;
    ActionSort.Enabled = ListBox.Items.Count > 0;
    // TODO when ready : add && !Settings.AutoSortBookmarks;
    // TODO when ready : add ActionUp.Enabled = !Settings.AutoSortBookmarks;
    // TODO when ready : add ActionDown.Enabled = !Settings.AutoSortBookmarks;
  }

  private void ManageDateBookmarks_FormClosed(object sender, FormClosedEventArgs e)
  {
    if ( DialogResult != DialogResult.OK ) return;
    for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
      Program.DateBookmarks[index] = ( (DateItem)ListBox.Items[index] ).Date;
    SystemManager.TryCatch(Settings.Save);
  }

  private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
  {
    ActionUp.Enabled = /* !Settings.AutoSortBookmarks && */ ListBox.SelectedIndex != 0;
    ActionDown.Enabled = /* !Settings.AutoSortBookmarks && */ ListBox.SelectedIndex != ListBox.Items.Count - 1;
    ActionDelete.Enabled = ListBox.SelectedIndex >= 0
                        && ( (DateItem)ListBox.Items[ListBox.SelectedIndex] ).Date != DateTime.MinValue;
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
    for ( int index = 0; index < ListBox.Items.Count; index++ )
      ListBox.Items[index] = new DateItem { Date = DateTime.MinValue };
  }

  private void ActionDelete_Click(object sender, EventArgs e)
  {
    ListBox.Items[ListBox.SelectedIndex] = new DateItem { Date = DateTime.MinValue };
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
      var dateFirst = ( (DateItem)itemFirst ).Date;
      var dateLast = ( (DateItem)itemLast ).Date;
      if ( dateFirst == DateTime.MinValue ) dateFirst = DateTime.MaxValue;
      if ( dateLast == DateTime.MinValue ) dateLast = DateTime.MaxValue;
      return dateFirst.CompareTo(dateLast);
    });
    ListBox_SelectedIndexChanged(null, null);
    ListBox.Focus();
  }

}
