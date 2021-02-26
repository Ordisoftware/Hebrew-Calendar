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
/// <created> 2016-04 </created>
/// <edited> 2021-02 </edited>
using System;
using System.Data.Odbc;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private OdbcConnection LockFileConnection;

    /// <summary>
    /// Check if tables exists or create them.
    /// </summary>
    public void CreateSchemaIfNotExists()
    {
      SystemManager.TryCatchManage(() =>
      {
        SQLiteOdbcHelper.CreateOrUpdateDSN();
        LockFileConnection = new OdbcConnection(Settings.ConnectionString);
        LockFileConnection.Open();
        if ( Settings.VacuumAtStartup )
          Settings.VacuumLastDone = LockFileConnection.Optimize(Settings.VacuumLastDone,
                                                                Settings.VacuumAtStartupDaysInterval);
        LockFileConnection.DropTableIfExists("Report");
        LockFileConnection.CheckTable(@"LunisolarDays",
                                      @"CREATE TABLE LunisolarDays 
                                        (
                                          Date TEXT DEFAULT '' NOT NULL,
                                          LunarMonth DEFAULT 0 INTEGER NOT NULL,
                                          LunarDay DEFAULT 0 INTEGER NOT NULL,
                                          Sunrise DEFAULT '' TEXT NOT NULL,
                                          Sunset DEFAULT '' TEXT NOT NULL,
                                          Moonrise DEFAULT '' TEXT NOT NULL,
                                          Moonset DEFAULT '' TEXT NOT NULL,
                                          MoonriseType DEFAULT 0 INTEGER NOT NULL,
                                          IsNewMoon DEFAULT 0 INTEGER NOT NULL,
                                          IsFullMoon DEFAULT 0 INTEGER NOT NULL,
                                          MoonPhase DEFAULT 0 INTEGER NOT NULL,
                                          SeasonChange DEFAULT 0 INTEGER NOT NULL,
                                          TorahEvents DEFAULT 0 INTEGER NOT NULL,
                                          ParashahID DEFAULT '' TEXT NOT NULL,
                                          LinkedParashahID DEFAULT '' TEXT NOT NULL,
                                          PRIMARY KEY(Date)
                                        )");
        bool b = Globals.DatabaseUpgraded;
        b = !LockFileConnection.CheckColumn("LunisolarDays", "ParashahID", "TEXT", "''", true) || b;
        b = !LockFileConnection.CheckColumn("LunisolarDays", "LinkedParashahID", "TEXT", "''", true) || b;
        Globals.DatabaseUpgraded = b;
      });
    }

    /// <summary>
    /// Empty all tables.
    /// </summary>
    private void EmptyDatabase()
    {
      if ( !DataSet.IsInitialized ) return;
      LunisolarDaysTableAdapter.DeleteAllQuery();
      TableAdapterManager.UpdateAll(DataSet);
      LunisolarDaysTableAdapter.Fill(DataSet.LunisolarDays);
    }

  }

}
