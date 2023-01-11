/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides SQLite date helper.
/// </summary>
[SuppressMessage("Performance ", "EPS05: Use in-modifier for a readonly struct", Justification = "Analysis error(https://docs.microsoft.com/dotnet/csharp/write-safe-efficient-code)")]
static public partial class SQLiteDate
{

  /// <summary>
  /// Static constructor.
  /// </summary>
  static SQLiteDate()
  {
    Initialize();
  }

  /// <summary>
  /// Initializes the string separators.
  /// </summary>
  static private void Initialize()
  {
    string sepDay = DaySeparatorText[_DaySeparator];
    string sepHour = HourSeparatorText[_HourSeparator];
    string sepDayHour = DayHourSeparatorText[_DayHourSeparator];
    DayFormatOnlyDayText = _DayOrder switch
    {
      SQLiteDateDayTextOrder.DayFirst => $"dd{sepDay}MM{sepDay}yyyy",
      SQLiteDateDayTextOrder.YearFirst => $"yyyy{sepDay}MM{sepDay}dd",
      _ => throw new AdvNotImplementedException(_DayOrder)
    };
    DayFormatOnlyTimeNoSecondsText = $"HH{sepHour}mm";
    DayFormatOnlyTimeText = $"{DayFormatOnlyTimeNoSecondsText}{sepHour}ss";
    DayHourFormatNoSecondsText = $"{DayFormatOnlyDayText}{sepDayHour}{DayFormatOnlyTimeNoSecondsText}";
    DayHourFormatText = $"{DayHourFormatNoSecondsText}{sepHour}ss";
    DateToDayFormatText = $"{{0:0000}}{sepDay}{{1:00}}{DaySeparatorText[_DaySeparator]}{{2:00}}";
    TimeToHourNoSecondsFormatText = $"{{0:00}}{sepHour}{{1:00}}";
    TimeToHourFormatText = $"{{0:00}}{sepHour}{{1:00}}{sepHour}{{2:00}}";
  }

  /// <summary>
  /// Gets a date from a string like "Year-Month-Day Hour-Min-Sec".
  /// </summary>
  /// <param name="date">The date.</param>
  /// <param name="withTime">True to add time, else only date.</param>
  /// <param name="ignoreSeconds">True to ignore seconds, else add them.</param>
  static public DateTime ToDateTime(string date, bool withTime = false, bool ignoreSeconds = false)
    => date.IsNullOrEmpty()
      ? DateTime.MinValue
       : withTime
         ? ignoreSeconds
           ? DateTime.ParseExact(date, DayHourFormatNoSecondsText, CultureInfo.InvariantCulture)
           : DateTime.ParseExact(date, DayHourFormatText, CultureInfo.InvariantCulture)
         : DateTime.ParseExact(date, DayFormatOnlyDayText, CultureInfo.InvariantCulture);

  /// <summary>
  /// Gets a date like "Year-Month-Day Hour:Min:Sec".
  /// </summary>
  /// <param name="date">The date.</param>
  /// <param name="withTime">True to add time, else only date.</param>
  /// <param name="ignoreSeconds">True to ignore seconds, else add them.</param>
  static public string ToString(DateTime date, bool withTime = false, bool ignoreSeconds = false)
    => withTime
       ? ignoreSeconds
         ? date.ToString(DayHourFormatNoSecondsText)
         : date.ToString(DayHourFormatText)
      : date.ToString(DayFormatOnlyDayText);

  /// <summary>
  /// Gets a date like "Year-Month-Day".
  /// </summary>
  /// <param name="year">The year.</param>
  /// <param name="month">The month.</param>
  /// <param name="day">The day.</param>
  static public string ToString(int year, int month, int day)
    => string.Format(DateToDayFormatText, year, month, day);

  /// <summary>
  /// Gets a time like "18:00".
  /// </summary>
  /// <param name="time">The time.</param>
  /// <param name="ignoreSeconds">True to ignore seconds, else add them.</param>
  static public string ToString(TimeSpan? time, bool ignoreSeconds = true)
    => time is not null
       ? ignoreSeconds
         ? string.Format(TimeToHourNoSecondsFormatText, time.Value.Hours, time.Value.Minutes)
         : string.Format(TimeToHourFormatText, time.Value.Hours, time.Value.Minutes, time.Value.Seconds)
       : string.Empty;

  /// <summary>
  /// Adds hours and minutes from a time span to a date else return null if time is null.
  /// </summary>
  static public DateTime? Add(TimeSpan? time, DateTime date)
    => time is not null
       ? date.AddHours(time.Value.Hours).AddMinutes(time.Value.Minutes)
       : null;

  /// <summary>
  /// Changes the year and month and day of a date with or without keeping the time.
  /// </summary>
  /// <param name="date">The DateTime instance.</param>
  /// <param name="year">The new year.</param>
  /// <param name="month">The new month.</param>
  /// <param name="day">The new day.</param>
  /// <param name="keepTime">True to keep time, else 00:00.</param>
  static public DateTime Change(this DateTime date, int year = -1, int month = -1, int day = -1, bool keepTime = false)
  {
    var result = new DateTime(year == -1 ? date.Year : year,
                              month == -1 ? date.Month : month,
                              day == -1 ? date.Day : day);
    return keepTime ? result + date.TimeOfDay : result;
  }

}
