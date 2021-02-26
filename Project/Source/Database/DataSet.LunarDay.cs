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
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    public LunisolarDaysRow GetLunarToday(bool force = false)
    {
      // TODO use a delta timespan to avoid calculation each time 
      return GetLunarDay(DateTime.Now);
    }

    public LunisolarDaysRow GetLunarDay(DateTime datetime)
    {
      var dateStr = SQLiteDate.ToString(datetime);
      if ( Program.Settings.TorahEventsCountAsMoon )
      {
        int delta = 2;
        var rowCurrent = LunisolarDays.FindByDate(dateStr);
        int indexRowCurrent = LunisolarDays.Rows.IndexOf(rowCurrent);
        int indexStart = Math.Max(0, indexRowCurrent - delta);
        int indexEnd = Math.Min(indexRowCurrent + delta, LunisolarDays.Count - 1);
        bool isInBounds = false;
        LunisolarDaysRow rowLast = null;
        LunisolarDaysRow rowFirst = null;
        for ( int index = indexEnd; index > indexStart; index-- )
        {
          rowCurrent = LunisolarDays[index];
          if ( !isInBounds && rowCurrent.MoonsetAsDateTime < datetime )
          {
            isInBounds = true;
            rowFirst = rowCurrent;
          }
          else
          if ( isInBounds && rowCurrent.MoonsetAsDateTime <= datetime )
            return !rowCurrent.Moonrise.IsNullOrEmpty() ? rowLast : rowFirst;
          rowLast = rowCurrent;
        }
      }
      else
      {
        int delta = 2;
        var rowCurrent = LunisolarDays.FindByDate(dateStr);
        int indexRowCurrent = LunisolarDays.Rows.IndexOf(rowCurrent);
        if ( datetime < rowCurrent.SunsetAsDateTime )
          return rowCurrent;
        else
        if ( indexRowCurrent < LunisolarDays.Rows.Count - 1 )
          return (LunisolarDaysRow)LunisolarDays.Rows[indexRowCurrent + 1];
      }
      return null;
    }

  }

}
