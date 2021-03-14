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
/// <created> 2020-12 </created>
/// <edited> 2021-03 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    partial class LunisolarDaysRow
    {

      public string DayAndMonthText
        => LunarDay + " " + HebrewMonths.Transliterations[LunarMonth];

      public string DayAndMonthWithYearText
        => DayAndMonthText + " " + int.Parse(Date.Substring(0,4));

      public string DayAndMonthFormattedText
        => Program.Settings.MoonDayTextFormat.ToUpper()
                  .Replace("%MONTHNAME%", HebrewMonths.Transliterations[LunarMonth])
                  .Replace("%MONTHNUM%", LunarMonth.ToString())
                  .Replace("%DAYNUM%", LunarDay.ToString());

      public string GetWeekLongCelebrationIntermediateDay()
      {
        int deltaPessah = Program.Settings.TorahEventsCountAsMoon ? 0 : -1;
        if ( MoonriseOccuringAsEnum != MoonRiseOccuring.NextDay || deltaPessah != 0 )
          if ( LunarMonth == TorahCelebrations.PessahMonth )
          {
            int day = LunarDay >= TorahCelebrations.PessahStartDay + deltaPessah
                      ? LunarDay - TorahCelebrations.PessahStartDay + 1 + deltaPessah
                      : -1;
            if ( day > 0 && day < TorahCelebrations.PessahLenght )
              return AppTranslations.PessahDay.GetLang(day);
          }
          else
          if ( LunarMonth == TorahCelebrations.YomsMonth )
          {
            int day = LunarDay >= TorahCelebrations.SoukotStartDay
                      ? LunarDay - TorahCelebrations.SoukotStartDay + 1
                      : -1;
            if ( day > 0 && day < TorahCelebrations.SoukotLenght )
              return AppTranslations.SoukotDay.GetLang(day);
          }
          else
          if ( LunarMonth == 3 )
          {
            int indexCurrent = tableLunisolarDays.Rows.IndexOf(this);
            int indexStart = Math.Max(0, indexCurrent - 7);
            int indexEnd = Math.Min(indexCurrent + 7, tableLunisolarDays.Rows.Count - 1);
            LunisolarDaysRow first = null;
            LunisolarDaysRow last = null;
            for ( int index = indexStart; index <= indexEnd; index++ )
            {
              var row = tableLunisolarDays[index];
              if ( row.TorahEventsAsEnum == TorahEvent.ChavouotDiet )
              {
                first = row;
                if ( row.DateAsDateTime.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
                {
                  last = row;
                  break;
                }
              }
              else
              if ( first != null )
                if ( row.DateAsDateTime.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
                {
                  last = row;
                  break;
                }
            }
            if ( first != null && last != null
              && first.DateAsDateTime <= last.DateAsDateTime
              && this.DateAsDateTime >= first.DateAsDateTime
              && this.DateAsDateTime <= last.DateAsDateTime )
              return AppTranslations.TorahEvent[TorahEvent.ChavouotDiet].GetLang();
          }

        return string.Empty;
      }

    }

  }

}
