/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide SQLite helper.
  /// </summary>
  static public class SQLite
  {

    static public int DefaultOptimizeDaysInterval = 7;

    /// <summary>
    /// Optimize the database.
    /// </summary>
    /// <param name="connection">The connection.</param>
    /// <param name="lastdone">The last done date.</param>
    /// <param name="force"></param>
    /// <returns>The new date if done else the same.</returns>
    static public DateTime Optimize(this OdbcConnection connection, 
                                    DateTime lastdone, 
                                    bool force = false)
    {
      try
      {
        if ( force || lastdone.AddDays(DefaultOptimizeDaysInterval) < DateTime.Now )
        {
          connection.CheckIntegrity();
          connection.Vacuum();
          lastdone = DateTime.Now;
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      return lastdone;
    }

    /// <summary>
    ///  Vacuum the database.
    /// </summary>
    /// <param name="connection">The connection.</param>
    static public void CheckIntegrity(this OdbcConnection connection)
    {
      using ( var sql = connection.CreateCommand() )
        try
        {
          sql.CommandText = "SELECT integrity_check FROM pragma_integrity_check()";
          var errors = new List<string>();
          using ( var reader = sql.ExecuteReader() )
            while ( reader.Read() )
            {
              string str = reader.GetString(0);
              if ( str != "ok" ) errors.Add(str);
            }
          if ( errors.Count > 0 )
          {
            string msg = Localizer.DatabaseIntegrityError.GetLang(string.Join(Environment.NewLine, errors));
            DisplayManager.ShowError(msg);
          }
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
    }

    /// <summary>
    ///  Vacuum the database.
    /// </summary>
    /// <param name="connection">The connection.</param>
    static public void Vacuum(this OdbcConnection connection)
    {
      using ( var sql = connection.CreateCommand() )
        try
        {
          sql.CommandText = "VACUUM;";
          if ( sql.ExecuteNonQuery() != 0 )
            DisplayManager.ShowError(Localizer.DatabaseVacuumError.GetLang());
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
    }

    static public bool CheckTable(this OdbcConnection connection, string table, string sql)
    {
      var command = new OdbcCommand("SELECT count(*) FROM sqlite_master " +
                                    "WHERE type = 'table' AND name = '" + table + "'", connection);
      if ( (int)command.ExecuteScalar() != 0 ) return false;
      if ( sql != "" ) new OdbcCommand(sql, connection).ExecuteNonQuery();
      return true;
    }

    static public bool CheckColumn(this OdbcConnection connection, string table, string column, string type, string valueDefault, bool valueNotNull)
    {
      if ( !string.IsNullOrEmpty(valueDefault) ) valueDefault = " DEFAULT " + valueDefault;
      if ( valueNotNull ) valueDefault += " NOT NULL";
      string sql = $"ALTER TABLE %TABLE% ADD COLUMN %COLUMN% " + type + valueDefault;
      return connection.CheckColumn(table, column, sql);
    }

    static public bool CheckColumn(this OdbcConnection connection, string table, string column, string sql)
    {
      var command = new OdbcCommand("PRAGMA table_info(" + table + ")", connection);
      var reader = command.ExecuteReader();
      int nameIndex = reader.GetOrdinal("Name");
      bool found = false;
      while ( reader.Read() )
        if ( reader.GetString(nameIndex).Equals(column) )
        {
          found = true;
          break;
        }
      if ( found ) return false;
      if ( sql != "" )
      {
        sql = sql.Replace("%TABLE%", table).Replace("%COLUMN%", column);
        new OdbcCommand(sql, connection).ExecuteNonQuery();
      }
      return true;
    }

    /// <summary>
    /// Get a date like "Year.Month.Day".
    /// </summary>
    /// <param name="date">The date.</param>
    static public string GetDate(DateTime date)
    {
      if ( date == null ) return "";
      return $"{date.Year.ToString("0000")}-{date.Month.ToString("00")}-{date.Day.ToString("00")}";
    }

    /// <summary>
    /// Get a date like "Year.Month.Day".
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    static public string GetDate(int year, int month, int day)
    {
      return $"{year.ToString("0000")}-{month.ToString("00")}-{day.ToString("00")}";
    }

    /// <summary>
    /// Get a date from a string like "Year.Month.Day".
    /// </summary>
    /// <param name="date">The date.</param>
    static public DateTime GetDate(string date)
    {
      if ( string.IsNullOrEmpty(date) ) return DateTime.Now;
      string[] items = date.Split('-');
      return new DateTime(Convert.ToInt32(items[0]), Convert.ToInt32(items[1]), Convert.ToInt32(items[2]));
    }

    /// <summary>
    /// Get a time like "18:00".
    /// </summary>
    /// <param name="time">The time.</param>
    /// <returns>An empty string if time is null</returns>
    static public string FormatTime(TimeSpan? time)
    {
      return time.HasValue ? $"{time.Value.Hours.ToString("00")}:{time.Value.Minutes.ToString("00")}" : "";
    }

  }

}
