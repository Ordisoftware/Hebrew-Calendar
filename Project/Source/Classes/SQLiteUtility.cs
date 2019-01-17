/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Data.Odbc;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide SQLite utilities methods.
  /// </summary>
  static public class SQLiteUtility
  {

    /// <summary>
    /// Get a date like "2019.01.01".
    /// </summary>
    /// <param name="date">The date.</param>
    static public string GetDate(DateTime date)
    {
      return date.Year.ToString("0000") + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00");
    }

    /// <summary>
    /// Get a date like "2019.01.01".
    /// </summary>
    /// <param name="date">The date.</param>
    static public string GetDate(int year, int month, int day)
    {
      return year.ToString("0000") + "-" + month.ToString("00") + "-" + day.ToString("00");
    }

    /// <summary>
    /// Get a date from a string like "2019.01.01".
    /// </summary>
    /// <param name="date">The date.</param>
    static public DateTime GetDate(string date)
    {
      string[] items = date.Split('-');
      return new DateTime(Convert.ToInt32(items[0]), Convert.ToInt32(items[1]), Convert.ToInt32(items[2]));
    }

    /// <summary>
    /// Get a time like "18:00".
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>An empty string if time is null</returns>
    static public string FormatTime(TimeSpan? time)
    {
      return time.HasValue ? time.Value.Hours.ToString("00") + ":" + time.Value.Minutes.ToString("00") : "";
    }

    /// <summary>
    /// Check if tables exists or create them.
    /// </summary>
    static public void CheckDB()
    {
      var connection = new OdbcConnection(Program.Settings.ConnectionString);
      connection.Open();
      var cmdCheckTable = new OdbcCommand("SELECT count(*) FROM sqlite_master " +
                                          "WHERE type = 'table' AND name = 'LunisolarDays'", connection);
      int result = (int)cmdCheckTable.ExecuteScalar();
      if ( result == 0 )
      {
        var cmdCreateTable = new OdbcCommand(@"CREATE TABLE LunisolarDays (
                                                 Date text,
                                                 LunarMonth integer,
                                                 LunarDay integer,
                                                 Sunrise text,
                                                 Sunset text,
                                                 Moonrise text,
                                                 Moonset text,
                                                 MoonriseType integer,
                                                 IsNewMoon integer,
                                                 IsFullMoon integer,
                                                 MoonPhase integer,
                                                 SeasonChange integer,
                                                 TorahEvents integer,
                                                 PRIMARY KEY('Date')
                                               );", connection);
        cmdCreateTable.ExecuteNonQuery();
        cmdCheckTable = new OdbcCommand("SELECT count(*) FROM sqlite_master " +
                                            "WHERE type = 'table' AND name = 'Report'", connection);
        result = (int)cmdCheckTable.ExecuteScalar();
        if ( result == 0 )
        {
          cmdCreateTable = new OdbcCommand(@"CREATE TABLE Report (
                                               Content text
                                             );", connection);
          cmdCreateTable.ExecuteNonQuery();
        }
        connection.Close();
      }
    }

  }

}