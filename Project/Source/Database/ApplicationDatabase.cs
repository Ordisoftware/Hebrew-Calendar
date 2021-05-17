/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-05 </edited>
using System;
using System.ComponentModel;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class ApplicationDatabase : SQLiteDatabase
  {

    static new public ApplicationDatabase Instance { get; protected set; }

    static ApplicationDatabase()
    {
      Instance = new ApplicationDatabase();
      SQLiteDatabase.Instance = Instance;
    }

    public List<LunisolarDay> LunisolarDays { get; private set; }
    public BindingList<LunisolarDay> LunisolarDaysAsBindingList { get; private set; }

    private ApplicationDatabase() : base(Globals.ApplicationDatabaseFilePath)
    {
    }

    public override void Open()
    {
      base.Open();
      if ( Program.Settings.VacuumAtStartup )
        Program.Settings.VacuumLastDone = Connection.Optimize(Program.Settings.VacuumLastDone,
                                                              Program.Settings.VacuumAtStartupDaysInterval);
    }

    protected override void DoClose()
    {
      if ( LunisolarDays == null ) return;
      if ( ClearListsOnCloseAndRelease ) LunisolarDays.Clear();
      LunisolarDays = null;
    }

    protected override void CreateTables()
    {
      Connection.CreateTable<LunisolarDay>();
    }

    public override void LoadAll()
    {
      base.LoadAll();
      LunisolarDays = Connection.Table<LunisolarDay>().ToList();
      LunisolarDaysAsBindingList = new BindingList<LunisolarDay>(LunisolarDays);
    }

    protected override void DoSaveAll()
    {
      throw new NotImplementedException();
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

  }

}
