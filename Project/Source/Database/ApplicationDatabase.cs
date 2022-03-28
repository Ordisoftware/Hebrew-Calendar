/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase : SQLiteDatabase
{

  static private readonly Properties.Settings Settings = Program.Settings;

  static public ApplicationDatabase Instance { get; protected set; }

  static ApplicationDatabase()
  {
    Instance = new ApplicationDatabase();
  }

  public List<LunisolarDay> LunisolarDays { get; private set; }

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
    if ( ClearListsOnCloseOrRelease ) LunisolarDays.Clear();
    LunisolarDays = null;
  }

  protected override void CreateTables()
  {
    Connection.CreateTable<LunisolarDay>();
  }

  protected override void DoLoadAll()
  {
    LunisolarDays = Connection.Table<LunisolarDay>().ToList();
  }

  protected override bool CreateDataIfNotExist(bool reset = false)
    => false;

  protected override void CreateBindingLists()
  {
    // NOP
  }

  protected override void DoSaveAll()
  {
    string message = SysTranslations.NotImplemented.GetLang($"{nameof(ApplicationDatabase)}.{nameof(DoSaveAll)}");
    throw new NotSupportedException(message);
  }

  public void DeleteAll()
  {
    CheckConnected();
    CheckAccess(LunisolarDays, nameof(LunisolarDays));
    Connection.DeleteAll<LunisolarDay>();
    LunisolarDays.Clear();
  }

  protected override void UpgradeSchema()
  {
    base.UpgradeSchema();
    if ( Connection.CheckTable(nameof(LunisolarDays)) )
    {
      if ( !Connection.CheckColumn(nameof(LunisolarDays), nameof(LunisolarDay.TorahEvent)) )
        Connection.DropTableIfExists(nameof(LunisolarDays));
    }
  }

  public LunisolarDay GetCurrentOrNextCelebration(DateTime date)
    => LunisolarDays.Find(day => day.Date >= date && TorahCelebrationSettings.MajorEvents.Contains(day.TorahEvent));

}
