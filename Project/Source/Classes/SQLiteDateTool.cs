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

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide SQLite date conversion methods.
  /// </summary>
  static public class SQLiteDateTool
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

  }

}
