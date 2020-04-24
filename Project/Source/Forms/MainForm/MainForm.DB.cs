/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-04 </edited>
using System;
using System.Data.Odbc;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    /// <summary>
    /// Check if tables exists or create them.
    /// </summary>
    public void CreateDatabaseIfNotExists()
    {
      using ( var connection = new OdbcConnection(Program.Settings.ConnectionString) )
        try
        {
          connection.Open();
          if ( Program.Settings.VacuumAtStartup )
            Program.Settings.VacuumLastDone = connection.Optimize(Program.Settings.VacuumLastDone);
          connection.CheckTable("LunisolarDays",
                                @"CREATE TABLE LunisolarDays 
                                  (
                                    Date TEXT,
                                    LunarMonth INTEGER,
                                    LunarDay INTEGER,
                                    Sunrise TEXT,
                                    Sunset TEXT,
                                    Moonrise TEXT,
                                    Moonset TEXT,
                                    MoonriseType INTEGER,
                                    IsNewMoon INTEGER,
                                    IsFullMoon INTEGER,
                                    MoonPhase INTEGER,
                                    SeasonChange INTEGER,
                                    TorahEvents INTEGER,
                                    PRIMARY KEY('Date')
                                  )");
          connection.CheckTable("Report",
                                @"CREATE TABLE Report 
                                  ( 
                                     Content TEXT 
                                  );");
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
        finally
        {
          connection.Close();
        }
    }

  }

}
