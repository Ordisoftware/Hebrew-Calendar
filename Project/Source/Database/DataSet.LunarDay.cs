/// <license>
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
/// <edited> 2021-02 </edited>
using System;
using System.Linq;
using MoreLinq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    private DateTime LunarDayChecked = DateTime.MinValue;
    private LunisolarDaysRow LastCheck;

    public LunisolarDaysRow GetLunarToday()
    {
      var now = DateTime.Now;
      var diff = now - LunarDayChecked;
      if ( LastCheck != null && diff.Seconds < 60 && LunisolarDays.Rows.Contains(LastCheck) )
        return LastCheck;
      LunarDayChecked = now;
      LastCheck = GetLunarDay(now);
      return LastCheck;
    }

    public LunisolarDaysRow GetLunarDay(DateTime datetime)
    {
      return Program.Settings.TorahEventsCountAsMoon
             ? GetLunarDayMoon(datetime)
             : GetLunarDaySun(datetime);
    }

    private LunisolarDaysRow GetLunarDayMoon(DateTime datetime)
    {
      int delta = 2;
      var dateStr = SQLiteDate.ToString(datetime);
      var rowCurrent = LunisolarDays.FindByDate(dateStr);
      int indexRowCurrent = LunisolarDays.Rows.IndexOf(rowCurrent);
      int indexStart = Math.Max(0, indexRowCurrent - delta);
      int indexEnd = Math.Min(indexRowCurrent + delta, LunisolarDays.Count - 1);
      bool isInBounds = false;
      LunisolarDaysRow rowFirst = null;
      LunisolarDaysRow rowLast = null;
      LunisolarDaysRow rowPrevious = rowCurrent;
      for ( int index = indexStart; index <= indexEnd; index++ )
      {
        rowCurrent = LunisolarDays[index];
        if ( !isInBounds )
        {
          if ( rowCurrent.MoonsetAsDateTime != null )
            if ( datetime < rowCurrent.MoonsetAsDateTime )
            {
              rowFirst = rowPrevious;
              if ( rowCurrent.MoonsetAsDateTime != null )
              {
                rowLast = rowCurrent;
                break;
              }
              isInBounds = true;
            }
            else
            {
              rowPrevious = rowCurrent;
              continue;
            }
        }
        else
        if ( rowCurrent.MoonsetAsDateTime != null )
        {
          rowLast = rowCurrent;
          break;
        }
      }
      if ( rowFirst != null && rowFirst.MoonriseOccuringAsEnum == MoonRiseOccuring.AfterSet )
        return rowFirst;
      else
      if ( rowLast != null && rowLast.MoonriseOccuringAsEnum == MoonRiseOccuring.BeforeSet )
        return rowLast;
      else
      if ( rowFirst != null && rowLast != null )
      {
        indexStart = LunisolarDays.Rows.IndexOf(rowFirst);
        indexEnd = LunisolarDays.Rows.IndexOf(rowLast);
        for ( int index = indexStart + 1; index < indexEnd - 1; index++ )
        {
          rowCurrent = LunisolarDays[index];
          if ( !rowCurrent.Moonrise.IsNullOrEmpty() )
            return rowCurrent;
        }
      }
      return null;
    }

    private LunisolarDaysRow GetLunarDaySun(DateTime datetime)
    {
      var dateStr = SQLiteDate.ToString(datetime);
      var rowCurrent = LunisolarDays.FindByDate(dateStr);
      int indexRowCurrent = LunisolarDays.Rows.IndexOf(rowCurrent);
      if ( datetime < rowCurrent.SunsetAsDateTime )
        return rowCurrent;
      else
      if ( indexRowCurrent < LunisolarDays.Rows.Count - 1 )
        return (LunisolarDaysRow)LunisolarDays.Rows[indexRowCurrent + 1];
      return null;
    }

  }

}
