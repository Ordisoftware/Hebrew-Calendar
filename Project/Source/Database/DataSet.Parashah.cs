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
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    partial class LunisolarDaysDataTable
    {

      public string WeeklyParashahText
      {
        get
        {
          var parashah = GetWeeklyParashah();
          return ( parashah != null ? parashah.ToStringLinked() : SysTranslations.UndefinedSlot.GetLang() ).ToUpper();
        }
      }

      public Parashah GetWeeklyParashah()
      {
        var today = Program.Settings.TorahEventsCountAsMoon ? GetDayMoon(DateTime.Now) : GetDaySun(DateTime.Now);
        if ( today == null ) return null;
        if ( today.LunarMonth == TorahCelebrations.PessahMonth )
          if ( today.TorahEventsAsEnum == TorahEvent.PessahD1 || today.TorahEventsAsEnum == TorahEvent.PessahD7 )
            return null;
          else
          if ( !today.GetWeekLongCelebrationIntermediateDay().IsNullOrEmpty() )
            return null;
        if ( Program.Settings.TorahEventsCountAsMoon ) today = GetDaySun(DateTime.Now);
        return ParashotTable.GetDefaultByID(today?.GetParashahReadingDay()?.ParashahID) ?? null;
      }

    }

    partial class LunisolarDaysRow
    {

      private const int SearchParashahInterval = 14;

      public string ParashahText
      {
        get
        {
          if ( ParashahID.IsNullOrEmpty() ) return string.Empty;
          string result = ParashotTable.GetDefaultByID(ParashahID).Name;
          if ( !LinkedParashahID.IsNullOrEmpty() )
            result += " - " + ParashotTable.GetDefaultByID(LinkedParashahID).Name;
          return result;
        }
      }

      public LunisolarDaysRow GetParashahReadingDay()
      {
        LunisolarDaysRow result = null;
        var shabatDay = Program.Settings.WeekParashahIsOnSaturday
                        ? DayOfWeek.Saturday
                        : (DayOfWeek)Program.Settings.ShabatDay;
        int indexStart = tableLunisolarDays.Rows.IndexOf(this);
        int indexEnd = Math.Min(indexStart + SearchParashahInterval, tableLunisolarDays.Rows.Count);
        for ( int index = indexStart; index < indexEnd; index++ )
        {
          var row = (LunisolarDaysRow)tableLunisolarDays.Rows[index];
          if ( row.DateAsDateTime.DayOfWeek == shabatDay )
          {
            result = row;
            break;
          }
        }
        return result;
      }

    }

  }

}
