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
/// <created> 2020-12 </created>
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class LunisolarDay
{

  public (TorahCelebration Event, int Index, string Text) GetWeekLongCelebrationIntermediateDay(bool onlyPessah = false)
  {
    int deltaPessah = Program.Settings.TorahEventsCountAsMoon ? 0 : -1;
    if ( MoonriseOccuring != MoonriseOccurring.NextDay || deltaPessah != 0 )
      if ( LunarMonth == TorahCelebrationSettings.PessahMonth )
      {
        int day = LunarDay >= TorahCelebrationSettings.PessahStartDay + deltaPessah
                  ? LunarDay - TorahCelebrationSettings.PessahStartDay + 1 + deltaPessah
                  : -1;
        if ( day > 0 && day <= TorahCelebrationSettings.PessahLenght )
          return (TorahCelebration.Pessah, day, AppTranslations.PessahDay.GetLang(day));
      }
      else
      if ( !onlyPessah && LunarMonth == TorahCelebrationSettings.YomsMonth )
      {
        int day = LunarDay >= TorahCelebrationSettings.SoukotStartDay
                  ? LunarDay - TorahCelebrationSettings.SoukotStartDay + 1
                  : -1;
        if ( day > 0 && day <= TorahCelebrationSettings.SoukotLenght )
          return (TorahCelebration.Soukot, day, AppTranslations.SoukotDay.GetLang(day));
      }
      else
      if ( !onlyPessah && LunarMonth == 3 )
      {
        int indexCurrent = Table.IndexOf(this);
        int indexStart = Math.Max(0, indexCurrent - 7);
        int indexEnd = Math.Min(indexCurrent + 7, Table.Count - 1);
        LunisolarDay first = null;
        LunisolarDay last = null;
        for ( int index = indexStart; index <= indexEnd; index++ )
        {
          var row = Table[index];
          if ( row.TorahEvent == TorahCelebrationDay.ChavouotDiet )
          {
            first = row;
            if ( row.Date.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
            {
              last = row;
              break;
            }
          }
          else
          if ( first is not null )
            if ( row.Date.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
            {
              last = row;
              break;
            }
        }
        if ( first is not null && last is not null
          && first.Date <= last.Date
          && Date >= first.Date
          && Date <= last.Date )
          return (TorahCelebration.Chavouot,
                  (int)( Date - first.Date ).TotalDays + 1,
                  AppTranslations.TorahCelebrationDays[TorahCelebrationDay.ChavouotDiet].GetLang());
      }
    return (TorahCelebration.None, 0, string.Empty);
  }

}
