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
/// <edited> 2021-05 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides SQLite date helper.
/// </summary>
static class SQLiteDate
{

  /// <summary>
  /// Gets a date from a string like "Year-Month-Day Hour-Min-Sec".
  /// </summary>
  /// <param name="date">The date.</param>
  /// <param name="withTime">True to add time, else only date.</param>
  /// <param name="ignoreSeconds">True to ignore seconds, else add them.</param>
  static public DateTime ToDateTime(string date, bool withTime = false, bool ignoreSeconds = false)
  {
    if ( date.IsNullOrEmpty() ) return DateTime.MinValue;
    return withTime
           ? ignoreSeconds
             ? DateTime.ParseExact(date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
             : DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
           : DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
  }

  /// <summary>
  /// Gets a date like "Year-Month-Day Hour:Min:Sec".
  /// </summary>
  /// <param name="date">The date.</param>
  /// <param name="withTime">True to add time, else only date.</param>
  /// <param name="ignoreSeconds">True to ignore seconds, else add them.</param>
  static public string ToString(DateTime date, bool withTime = false, bool ignoreSeconds = false)
  {
    return withTime
           ? ignoreSeconds
             ? date.ToString("yyyy-MM-dd HH:mm")
             : date.ToString("yyyy-MM-dd HH:mm:ss")
           : date.ToString("yyyy-MM-dd");
  }

  /// <summary>
  /// Gets a date like "Year-Month-Day".
  /// </summary>
  /// <param name="year">The year.</param>
  /// <param name="month">The month.</param>
  /// <param name="day">The day.</param>
  static public string ToString(int year, int month, int day)
  {
    return $"{year:0000}-{month:00)}-{day:00}";
  }

  /// <summary>
  /// Gets a time like "18:00".
  /// </summary>
  /// <param name="time">The time.</param>
  /// <returns>An empty string if time is null</returns>
  static public string ToString(TimeSpan? time)
  {
    return time.HasValue ? $"{time.Value.Hours:00}:{time.Value.Minutes:00}" : string.Empty;
  }

  /// <summary>
  /// Gets a time like "18:00".
  /// </summary>
  /// <param name="date">The date time.</param>
  /// <returns>An empty string if time is null</returns>
  //static string ToStringFromTime(DateTime? date)
  //{
  //  return date.HasValue ? $"{date.Value.Hour:00}:{date.Value.Minute:00}" : string.Empty;
  //}

  /// <summary>
  /// Adds hours and minutes from a time span to a date else return null if time is null.
  /// </summary>
  static public DateTime? Add(TimeSpan? time, DateTime date)
  {
    return time.HasValue ? date.AddHours(time.Value.Hours).AddMinutes(time.Value.Minutes) : null;
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
    if ( year == -1 ) year = date.Year;
    if ( month == -1 ) month = date.Month;
    if ( day == -1 ) day = date.Day;
    return new DateTime(year, month, day);
  }

}
