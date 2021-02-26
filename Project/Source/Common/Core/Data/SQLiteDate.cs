/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2021-01 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide SQLite date helper.
  /// </summary>
  static partial class SQLiteDate
  {

    static private void RunSecure()
    {
    }

    /// <summary>
    /// Get a date like "Year.Month.Day".
    /// </summary>
    /// <param name="date">The date.</param>
    static public string ToString(DateTime date)
    {
      if ( date == null ) return string.Empty;
      return $"{date.Year.ToString("0000")}-{date.Month.ToString("00")}-{date.Day.ToString("00")}";
    }

    /// <summary>
    /// Get a date like "Year.Month.Day".
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    static public string ToString(int year, int month, int day)
    {
      return $"{year.ToString("0000")}-{month.ToString("00")}-{day.ToString("00")}";
    }

    /// <summary>
    /// Get a date from a string like "Year.Month.Day".
    /// </summary>
    /// <param name="date">The date.</param>
    static public DateTime ToDateTime(string date)
    {
      if ( date.IsNullOrEmpty() ) return DateTime.MinValue;
      string[] items = date.Split('-');
      if ( items.Length != 3 ) throw new FormatException(date);
      if ( !int.TryParse(items[0], out int year) ) throw new FormatException(date);
      if ( !int.TryParse(items[1], out int month) ) throw new FormatException(date);
      if ( !int.TryParse(items[2], out int day) ) throw new FormatException(date);
      return new DateTime(year, month, day);
    }

    /// <summary>
    /// Get a time like "18:00".
    /// </summary>
    /// <param name="time">The time.</param>
    /// <returns>An empty string if time is null</returns>
    static public string ToString(TimeSpan? time)
    {
      return time.HasValue ? $"{time.Value.Hours.ToString("00")}:{time.Value.Minutes.ToString("00")}" : string.Empty;
    }

    /// <summary>
    /// CHange the year and month and day of a date.
    /// </summary>
    /// <param name="date">The DateTime instance.</param>
    /// <param name="year">The new year.</param>
    /// <param name="month">The new month.</param>
    /// <param name="day">The new day.</param>
    /// <returns>The new date without time</returns>
    static public DateTime Change(this DateTime date, int year = -1, int month = -1, int day = -1)
    {
      if ( date == null ) return date;
      if ( year == -1 ) year = date.Year;
      if ( month == -1 ) month = date.Month;
      if ( day == -1 ) day = date.Day;
      return new DateTime(year, month, day);
    }

  }

}
