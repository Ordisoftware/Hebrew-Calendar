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
/// <created> 2022-01 </created>
/// <edited> 2022-01 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ManageAcquaintanceEventsForm : Form
{

  //private const string TableName = "Date Bookmarks";

  static private readonly Properties.Settings Settings = Program.Settings;

  static public bool Run()
  {
    bool trayEnabled = MainForm.Instance.MenuTray.Enabled;
    MainForm.Instance.MenuTray.Enabled = false;
    try
    {
      using var form = new ManageAcquaintanceEventsForm();
      return form.ShowDialog() == DialogResult.OK;
    }
    finally
    {
      MainForm.Instance.MenuTray.Enabled = trayEnabled;
    }
  }

  private ManageAcquaintanceEventsForm()
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
    //ListBox.Items.Clear();
    //for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
    //  ListBox.Items.Add(new DateItem { Date = Program.DateBookmarks[index] });
    //ListBox.SelectedIndex = 0;
    //ActiveControl = ListBox;
  }

  private void ManageDateBookmarks_FormClosed(object sender, FormClosedEventArgs e)
  {
    if ( DialogResult != DialogResult.OK ) return;
    //for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
    //  Program.DateBookmarks[index] = ( (DateItem)ListBox.Items[index] ).Date;
    SystemManager.TryCatch(Settings.Save);
  }

}
