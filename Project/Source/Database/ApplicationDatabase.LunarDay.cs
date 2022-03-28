/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase : SQLiteDatabase
{

  private readonly int GetTodayCacheInSeconds = Globals.SecondsInOneMinute;

  private DateTime DayChecked = DateTime.MinValue;

  private LunisolarDay LastCheck;

  public LunisolarDay GetToday()
  {
    var now = DateTime.Now;
    var diff = now - DayChecked;
    if ( LastCheck is not null && diff.TotalSeconds < GetTodayCacheInSeconds && LunisolarDays.Contains(LastCheck) )
      return LastCheck;
    DayChecked = now;
    LastCheck = GetDay(now);
    return LastCheck;
  }

  public LunisolarDay GetDay(DateTime datetime)
  {
    return Settings.TorahEventsCountAsMoon && !Settings.UseSodHaibour
      ? GetDayMoon(datetime)
      : GetDaySun(datetime);
  }

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  private LunisolarDay GetDayMoon(DateTime datetime)
  {
    var rowCurrent = LunisolarDays.Find(d => d.Date == datetime.Date);
    int indexRowCurrent = LunisolarDays.IndexOf(rowCurrent);
    int indexStart = Math.Max(0, indexRowCurrent - Globals.DaysOfWeekCount);
    int indexEnd = Math.Min(indexRowCurrent + Globals.DaysOfWeekCount, LunisolarDays.Count - 1);
    bool isInBounds = false;
    LunisolarDay rowFirst = null;
    LunisolarDay rowLast = null;
    var rowPrevious = rowCurrent;
    for ( int index = indexStart; index <= indexEnd; index++ )
    {
      rowCurrent = LunisolarDays[index];
      if ( !isInBounds )
      {
        if ( rowCurrent.Moonset is not null )
          if ( datetime < rowCurrent.Moonset )
          {
            rowFirst = rowPrevious;
            if ( rowCurrent.Moonset is not null )
            {
              rowLast = rowCurrent;
              break;
            }
            isInBounds = true;
          }
          else
          {
            rowPrevious = rowCurrent;
          }
      }
      else
      if ( rowCurrent.Moonset is not null )
      {
        rowLast = rowCurrent;
        break;
      }
    }
    if ( rowFirst?.MoonriseOccuring == MoonriseOccurring.AfterSet )
      return rowFirst;
    else
    if ( rowLast?.MoonriseOccuring == MoonriseOccurring.BeforeSet )
      return rowLast;
    else
    if ( rowFirst is not null && rowLast is not null )
    {
      indexStart = LunisolarDays.IndexOf(rowFirst);
      indexEnd = LunisolarDays.IndexOf(rowLast);
      for ( int index = indexStart + 1; index <= indexEnd - 1; index++ )
      {
        rowCurrent = LunisolarDays[index];
        if ( rowCurrent.Moonrise is not null )
          return rowCurrent;
      }
    }
    return null;
  }

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  private LunisolarDay GetDaySun(DateTime datetime)
  {
    var rowCurrent = LunisolarDays.Find(d => d.Date == datetime.Date);
    if ( datetime < rowCurrent.Sunset )
      return rowCurrent;
    else
    {
      int indexRowCurrent = LunisolarDays.IndexOf(rowCurrent);
      if ( indexRowCurrent < LunisolarDays.Count - 1 )
        return LunisolarDays[indexRowCurrent + 1];
    }
    return null;
  }

}
