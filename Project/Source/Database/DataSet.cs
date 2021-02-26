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
/// <edited> 2021-02 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    partial class LunisolarDaysRow
    {

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
        return string.Empty;
      }

      public DateTime GetEventStartDateTime(bool useRealDay, bool isMoon)
      {
        var day = this;
        if ( !isMoon && !Program.Settings.TorahEventsCountAsMoon )
        {
          if ( useRealDay )
          {
            int index = day.Table.Rows.IndexOf(day) - 1;
            if ( index < 0 )
              throw new SystemException($"Bad calendar in {nameof(GetEventStartDateTime)}({useRealDay},{isMoon})");
            day = (LunisolarDaysRow)day.Table.Rows[index];
            return SQLiteDate.ToDateTime(day.Date)
                             .AddHours(int.Parse(day.Sunset.Substring(0, 2)))
                             .AddMinutes(int.Parse(day.Sunset.Substring(3, 2)));
          }
          else
            return SQLiteDate.ToDateTime(day.Date)
                             .AddHours(int.Parse(day.Sunrise.Substring(0, 2)))
                             .AddMinutes(int.Parse(day.Sunrise.Substring(3, 2)));
        }
        else
        if ( useRealDay )
        {
          if ( day.MoonriseOccuringAsEnum == MoonRiseOccuring.BeforeSet || day.Moonset == string.Empty )
          {
            int index = day.Table.Rows.IndexOf(day) - 1;
            if ( index < 0 )
              throw new SystemException($"Bad calendar in {nameof(GetEventStartDateTime)}({useRealDay},{isMoon})");
            day = (LunisolarDaysRow)day.Table.Rows[index];
          }
          return SQLiteDate.ToDateTime(day.Date)
                           .AddHours(int.Parse(day.Moonset.Substring(0, 2)))
                           .AddMinutes(int.Parse(day.Moonset.Substring(3, 2)));
        }
        else
          return SQLiteDate.ToDateTime(day.Date)
                           .AddHours(int.Parse(day.Moonrise.Substring(0, 2)))
                           .AddMinutes(int.Parse(day.Moonrise.Substring(3, 2)));
      }

    }


  }

}
