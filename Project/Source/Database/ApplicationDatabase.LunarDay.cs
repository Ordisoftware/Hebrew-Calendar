﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-05 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class ApplicationDatabase : SQLiteDatabase
  {

    private const int SearchDayInterval = 7;

    private const int GetTodayCacheInSeconds = 60;

    private DateTime DayChecked = DateTime.MinValue;

    private LunisolarDay LastCheck;

    public LunisolarDay GetToday()
    {
      var now = DateTime.Now;
      var diff = now - DayChecked;
      if ( LastCheck != null && diff.TotalSeconds < GetTodayCacheInSeconds && LunisolarDays.Contains(LastCheck) )
        return LastCheck;
      DayChecked = now;
      LastCheck = GetDay(now);
      return LastCheck;
    }

    public LunisolarDay GetDay(DateTime datetime)
    {
      return Program.Settings.TorahEventsCountAsMoon
             ? GetDayMoon(datetime)
             : GetDaySun(datetime);
    }

    private LunisolarDay GetDayMoon(DateTime datetime)
    {
      var rowCurrent = LunisolarDays.Find(d => d.Date == datetime.Date);
      int indexRowCurrent = LunisolarDays.IndexOf(rowCurrent);
      int indexStart = Math.Max(0, indexRowCurrent - SearchDayInterval);
      int indexEnd = Math.Min(indexRowCurrent + SearchDayInterval, LunisolarDays.Count - 1);
      bool isInBounds = false;
      LunisolarDay rowFirst = null;
      LunisolarDay rowLast = null;
      LunisolarDay rowPrevious = rowCurrent;
      for ( int index = indexStart; index <= indexEnd; index++ )
      {
        rowCurrent = LunisolarDays[index];
        if ( !isInBounds )
        {
          if ( rowCurrent.Moonset != null )
            if ( datetime < rowCurrent.Moonset)
            {
              rowFirst = rowPrevious;
              if ( rowCurrent.Moonset != null )
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
        if ( rowCurrent.Moonset != null )
        {
          rowLast = rowCurrent;
          break;
        }
      }
      if ( rowFirst != null && rowFirst.MoonriseOccuring == MoonriseOccuring.AfterSet )
        return rowFirst;
      else
      if ( rowLast != null && rowLast.MoonriseOccuring == MoonriseOccuring.BeforeSet )
        return rowLast;
      else
      if ( rowFirst != null && rowLast != null )
      {
        indexStart = LunisolarDays.IndexOf(rowFirst);
        indexEnd = LunisolarDays.IndexOf(rowLast);
        for ( int index = indexStart + 1; index <= indexEnd - 1; index++ )
        {
          rowCurrent = LunisolarDays[index];
          if ( rowCurrent.Moonrise != null )
            return rowCurrent;
        }
      }
      return null;
    }

    private LunisolarDay GetDaySun(DateTime datetime)
    {
      var rowCurrent = LunisolarDays.Find(d => d.Date == datetime.Date);
      int indexRowCurrent = LunisolarDays.IndexOf(rowCurrent);
      if ( datetime < rowCurrent.Sunset )
        return rowCurrent;
      else
      if ( indexRowCurrent < LunisolarDays.Count - 1 )
        return LunisolarDays[indexRowCurrent + 1];
      return null;
    }

  }

}
