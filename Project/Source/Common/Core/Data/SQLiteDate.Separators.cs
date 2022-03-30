/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2022-03 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides SQLite date helper.
/// </summary>
static partial class SQLiteDate
{

  static public string DayHourFormatText { get; private set; }
  static public string DayHourFormatNoSecondsText { get; private set; }
  static public string DayFormatOnlyDayText { get; private set; }
  static public string DayFormatOnlyTimeText { get; private set; }
  static public string DayFormatOnlyTimeNoSecondsText { get; private set; }
  static public string DateToDayFormatText { get; private set; }
  static public string TimeToHourFormatText { get; private set; }
  static public string TimeToHourNoSecondsFormatText { get; private set; }

  static public readonly NullSafeOfStringDictionary<SQLiteDateDayTextSeparator> DaySeparatorText = new()
  {
    [SQLiteDateDayTextSeparator.Point] = ".",
    [SQLiteDateDayTextSeparator.Minus] = "-",
    [SQLiteDateDayTextSeparator.Slash] = "/"
  };

  static public readonly NullSafeOfStringDictionary<SQLiteDateHourTextSeparator> HourSeparatorText = new()
  {
    [SQLiteDateHourTextSeparator.Point] = ".",
    [SQLiteDateHourTextSeparator.Minus] = "-",
    [SQLiteDateHourTextSeparator.Colon] = ":"
  };

  static public readonly NullSafeOfStringDictionary<SQLiteDateDayHourTextSeparator> DayHourSeparatorText = new()
  {
    [SQLiteDateDayHourTextSeparator.Space] = " ",
    [SQLiteDateDayHourTextSeparator.At] = "@",
    [SQLiteDateDayHourTextSeparator.Sharp] = "#",
    [SQLiteDateDayHourTextSeparator.Vertical] = "|",
    [SQLiteDateDayHourTextSeparator.Plus] = "+"
  };

}
