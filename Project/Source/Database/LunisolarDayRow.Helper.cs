/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

public partial class LunisolarDayRow
{

  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  public (TorahCelebration Event, int Index, string Text) GetWeekLongCelebrationIntermediateDay(bool onlyPessah = false)
  {
    int offsetPessah = Settings.TorahEventsCountAsMoon ? 0 : -1;
    if ( MoonriseOccurring != MoonriseOccurring.NextDay || offsetPessah != 0 )
      if ( LunarMonth == TorahCelebrationSettings.PessahMonth )
      {
        int day = LunarDay >= TorahCelebrationSettings.PessahStartDay + offsetPessah
          ? LunarDay - TorahCelebrationSettings.PessahStartDay + 1 + offsetPessah
          : -1;
        if ( day > 0 && day <= TorahCelebrationSettings.PessahLength )
          return (TorahCelebration.Pessah, day, AppTranslations.GetPessahDayDisplayText(day));
      }
      else
      if ( !onlyPessah && LunarMonth == TorahCelebrationSettings.YomsMonth )
      {
        int day = LunarDay >= TorahCelebrationSettings.SoukotStartDay
          ? LunarDay - TorahCelebrationSettings.SoukotStartDay + 1
          : -1;
        if ( day > 0 && day <= TorahCelebrationSettings.SoukotLength )
          return (TorahCelebration.Soukot, day, AppTranslations.GetSoukotDayDisplayText(day));
      }
      else
      if ( !onlyPessah && LunarMonth == TorahCelebrationSettings.ChavouotMonth )
      {
        int indexCurrent = Table.IndexOf(this);
        int indexStart = Math.Max(0, indexCurrent - Globals.DaysOfWeekCount);
        int indexEnd = Math.Min(indexCurrent + Globals.DaysOfWeekCount, Table.Count - 1);
        LunisolarDayRow first = null;
        LunisolarDayRow last = null;
        for ( int index = indexStart; index <= indexEnd; index++ )
        {
          var row = Table[index];
          if ( row.TorahEvent == TorahCelebrationDay.ChavouotDiet )
          {
            first = row;
            if ( row.Date.DayOfWeek == (DayOfWeek)Settings.ShabatDay )
            {
              last = row;
              break;
            }
          }
          else
          if ( first is not null )
            if ( row.Date.DayOfWeek == (DayOfWeek)Settings.ShabatDay )
            {
              last = row;
              break;
            }
        }
        if ( first is not null && last is not null
          && first.Date <= last.Date
          && Date >= first.Date
          && Date <= last.Date )
        {
          string str = AppTranslations.GetCelebrationDayDisplayText(TorahCelebrationDay.ChavouotDiet);
          return (TorahCelebration.Chavouot, (int)( Date - first.Date ).TotalDays + 1, str);
        }
      }
    return (TorahCelebration.None, 0, string.Empty);
  }

}
