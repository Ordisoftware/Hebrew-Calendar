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
/// <edited> 2021-03 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    partial class LunisolarDaysDataTable
    {

      private DateTime DayChecked = DateTime.MinValue;
      private LunisolarDaysRow LastCheck;

      public LunisolarDaysRow GetToday()
      {
        var now = DateTime.Now;
        var diff = now - DayChecked;
        if ( LastCheck != null && diff.Seconds < 60 && Rows.Contains(LastCheck) )
          return LastCheck;
        DayChecked = now;
        LastCheck = GetDay(now);
        return LastCheck;
      }

      public LunisolarDaysRow GetDay(DateTime datetime)
      {
        return Program.Settings.TorahEventsCountAsMoon
               ? GetDayMoon(datetime)
               : GetDaySun(datetime);
      }

      private LunisolarDaysRow GetDayMoon(DateTime datetime)
      {
        int delta = 7;
        var dateStr = SQLiteDate.ToString(datetime);
        var rowCurrent = FindByDate(dateStr);
        int indexRowCurrent = Rows.IndexOf(rowCurrent);
        int indexStart = Math.Max(0, indexRowCurrent - delta);
        int indexEnd = Math.Min(indexRowCurrent + delta, Count - 1);
        bool isInBounds = false;
        LunisolarDaysRow rowFirst = null;
        LunisolarDaysRow rowLast = null;
        LunisolarDaysRow rowPrevious = rowCurrent;
        for ( int index = indexStart; index <= indexEnd; index++ )
        {
          rowCurrent = this[index];
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
          indexStart = Rows.IndexOf(rowFirst);
          indexEnd = Rows.IndexOf(rowLast);
          for ( int index = indexStart + 1; index < indexEnd - 1; index++ )
          {
            rowCurrent = this[index];
            if ( !rowCurrent.Moonrise.IsNullOrEmpty() )
              return rowCurrent;
          }
        }
        return null;
      }

      private LunisolarDaysRow GetDaySun(DateTime datetime)
      {
        var dateStr = SQLiteDate.ToString(datetime);
        var rowCurrent = FindByDate(dateStr);
        int indexRowCurrent = Rows.IndexOf(rowCurrent);
        if ( datetime < rowCurrent.SunsetAsDateTime )
          return rowCurrent;
        else
        if ( indexRowCurrent < Rows.Count - 1 )
          return this[indexRowCurrent + 1];
        return null;
      }

    }

  }
  
}
