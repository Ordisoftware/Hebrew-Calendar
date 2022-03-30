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

  static public SQLiteDateDayTextOrder DayOrder
  {
    get => _DayOrder;
    set
    {
      if ( _DayOrder == value ) return;
      _DayOrder = value;
      Initialize();
    }
  }
  static private SQLiteDateDayTextOrder _DayOrder = SQLiteDateDayTextOrder.YearFirst;

  static public SQLiteDateDayTextSeparator DaySeparator
  {
    get => _DaySeparator;
    set
    {
      if ( _DaySeparator == value ) return;
      _DaySeparator = value;
      Initialize();
    }
  }
  static private SQLiteDateDayTextSeparator _DaySeparator = SQLiteDateDayTextSeparator.Minus;

  static public SQLiteDateHourTextSeparator HourSeparator
  {
    get => _HourSeparator;
    set
    {
      if ( _HourSeparator == value ) return;
      _HourSeparator = value;
      Initialize();
    }
  }
  static private SQLiteDateHourTextSeparator _HourSeparator = SQLiteDateHourTextSeparator.Colon;

  static public SQLiteDateDayHourTextSeparator DayHourSeparator
  {
    get => _DayHourSeparator;
    set
    {
      if ( _DayHourSeparator == value ) return;
      _DayHourSeparator = value;
      Initialize();
    }
  }
  static private SQLiteDateDayHourTextSeparator _DayHourSeparator = SQLiteDateDayHourTextSeparator.Space;

}
