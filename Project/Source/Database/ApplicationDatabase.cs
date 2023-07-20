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
/// <created> 2021-05 </created>
/// <edited> 2023-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using Equin.ApplicationFramework;

partial class ApplicationDatabase : SQLiteDatabase
{

  static public readonly string LunisolarDaysTableName = nameof(LunisolarDays);
  static public readonly string DateBookmarksTableName = nameof(DateBookmarks);

  static private readonly Properties.Settings Settings = Program.Settings;

  static public ApplicationDatabase Instance { get; private set; }

  static ApplicationDatabase()
  {
    Instance = new ApplicationDatabase();
  }

  public List<LunisolarDayRow> LunisolarDays { get; private set; }
  public List<DateBookmarkRow> DateBookmarks { get; private set; }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP006:Implement IDisposable", Justification = "N/A")]
  public BindingListView<DateBookmarkRow> DateBookmarksAsBindingListView { get; private set; }

  public List<DateBookmarkRow> DateBookmarksSorted
    => DateBookmarks.OrderBy(bookmark => bookmark.Date).ToList();

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP006:Implement IDisposable", Justification = "N/A")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP012:Property should not return created disposable", Justification = "N/A")]
  public BindingListView<DateBookmarkRow> DateBookmarksSortedAsBindingListView
    => new(DateBookmarksSorted);

  public List<DateBookmarkRow> DateBookmarksSortedOrNot
    => Settings.AutoSortBookmarks
       ? DateBookmarks.OrderBy(bookmark => bookmark.Date).ToList()
       : DateBookmarks;

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP006:Implement IDisposable", Justification = "N/A")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP012:Property should not return created disposable", Justification = "N/A")]
  public BindingListView<DateBookmarkRow> DateBookmarksSortedOrNotAsBindingListView
    => new(DateBookmarksSortedOrNot);

  private ApplicationDatabase() : base(Globals.ApplicationDatabaseFilePath)
  {
  }

  protected override void Vacuum(bool force = false)
  {
    if ( Settings.VacuumAtStartup )
    {
      var dateNew = Connection.Optimize(Settings.VacuumLastDone, Settings.VacuumAtStartupDaysInterval);
      if ( Settings.VacuumLastDone != dateNew )
      {
        HebrewDatabase.Instance.Connection.Optimize(dateNew, force: true);
        Settings.VacuumLastDone = dateNew;
      }
    }
  }

  protected override void DoClose()
  {
    if ( LunisolarDays is null ) return;
    if ( ClearListsOnCloseOrRelease )
    {
      LunisolarDays.Clear();
      DateBookmarks.Clear();
    }
    LunisolarDays = null;
  }

  protected override void CreateTables()
  {
    Connection.CreateTable<LunisolarDayRow>();
    Connection.CreateTable<DateBookmarkRow>();
  }

  protected override void DoLoadAll()
  {
    LunisolarDays = Connection.Table<LunisolarDayRow>().ToList();
    DateBookmarks = Connection.Table<DateBookmarkRow>().ToList();
  }

  protected override bool CreateDataIfNotExist(bool reset = false)
  {
    ImportOldFileBookmarksIfNeeded();
    return false;
  }

  protected override void CreateBindingLists()
  {
    DateBookmarksAsBindingListView?.Dispose();
    DateBookmarksAsBindingListView = new BindingListView<DateBookmarkRow>(DateBookmarks);
  }

  protected override void DoSaveAll()
  {
    string message = SysTranslations.NotImplemented.GetLang($"{nameof(ApplicationDatabase)}.{nameof(DoSaveAll)}");
    throw new NotSupportedException(message);
  }

  public void SaveDateBookmarks()
  {
    CheckAccess(DateBookmarks, DateBookmarksTableName);
    Connection.UpdateAll(DateBookmarks);
  }

  public void EmptyLunisolarDays()
  {
    CheckConnected();
    CheckAccess(LunisolarDays, nameof(LunisolarDays));
    Connection.DeleteAll<LunisolarDayRow>();
    LunisolarDays.Clear();
  }

  protected override void UpgradeSchema()
  {
    base.UpgradeSchema();
    if ( Connection.CheckTable(nameof(LunisolarDays)) )
    {
      if ( !Connection.CheckColumn(nameof(LunisolarDays), nameof(LunisolarDayRow.TorahEvent)) )
        Connection.DropTableIfExists(nameof(LunisolarDays));
    }
  }

  public LunisolarDayRow GetCurrentOrNextCelebration(DateTime date)
    => LunisolarDays.Find(day => day.Date >= date && TorahCelebrationSettings.MajorEvents.Contains(day.TorahEvent));

}
