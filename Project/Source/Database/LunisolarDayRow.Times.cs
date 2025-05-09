﻿/// <license>
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
/// <created> 2019-01 </created>
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

public partial class LunisolarDayRow
{

  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  internal DateTime GetEventStartDateTime(bool useRealDay, bool isMoon)
  {
    var day = this;
    if ( !isMoon && !Settings.TorahEventsCountAsMoon )
    {
      if ( useRealDay )
      {
        int index = Table.IndexOf(day) - 1;
        if ( index < 0 )
          throw new SystemException($"Bad calendar in {nameof(GetEventStartDateTime)}({useRealDay},{isMoon})");
        day = Table[index];
        return day.Sunset.Value;
      }
      else
        return day.Sunrise.Value;
    }
    else
    if ( useRealDay )
    {
      if ( day.MoonriseOccurring == MoonriseOccurring.BeforeSet || day.Moonset is null )
      {
        int index = Table.IndexOf(day) - 1;
        if ( index < 0 )
          throw new SystemException($"Bad calendar in {nameof(GetEventStartDateTime)}({useRealDay},{isMoon})");
        day = Table[index];
      }
      return day.Moonset.Value;
    }
    else
      return day.Moonrise.Value;
  }

  internal ReminderTimes GetTimesForShabat(decimal offset3)
  {
    var times = new ReminderTimes();
    var dateRow = Date;
    var dayPrevious = dateRow.AddDays(-1);
    var rowPrevious = Table.Find(d => d.Date == dayPrevious);
    if ( rowPrevious is null )
      return null;
    if ( Settings.RemindShabatOnlyLight )
      times.Set(dateRow, Sunrise.Value.TimeOfDay, Sunset.Value.TimeOfDay, 0, 0, offset3);
    else
      times.Set(dateRow, rowPrevious.Sunset.Value.TimeOfDay, Sunset.Value.TimeOfDay, -1, 0, offset3);
    return times;
  }

  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "Analysis error")]
  internal ReminderTimes GetTimesForCelebration(decimal offset3)
  {
    var times = new ReminderTimes();
    var dateRow = Date;
    var dayPrevious = dateRow.AddDays(-1);
    var dayNext = dateRow.AddDays(+1);
    var rowPrevious = Table.Find(d => d.Date == dayPrevious);
    var rowNext = Table.Find(d => d.Date == dayNext);
    if ( rowPrevious is null || rowNext is null )
      return null;
    bool isShavouot = TorahEvent == TorahCelebrationDay.Chavouot1 || TorahEvent == TorahCelebrationDay.Chavouot2;
    if ( Settings.TorahEventsCountAsMoon && !isShavouot )
    {
      bool isPreviousNotNull = rowPrevious.Moonset.HasValue;
      bool isCurrentNotNull = Moonset.HasValue;
      bool isNextNotNull = rowNext.Moonset.HasValue;
      bool isNotNullCurrentAndPrevious = isCurrentNotNull && isPreviousNotNull;
      bool isNotNullCurrentAndNext = isCurrentNotNull && isNextNotNull;
      bool isNotNullPreviousAndNext = !isCurrentNotNull && isPreviousNotNull && isNextNotNull;
      if ( isNotNullCurrentAndNext && rowNext.Date == DateTime.Today )
        times.Set(dateRow, Moonset.Value.TimeOfDay, rowNext.Moonset.Value.TimeOfDay, 0, 1, offset3);
      else
      if ( isNotNullCurrentAndNext && MoonriseOccurring == MoonriseOccurring.AfterSet )
        times.Set(dateRow, Moonset.Value.TimeOfDay, rowNext.Moonset.Value.TimeOfDay, 0, 1, offset3);
      else
      if ( isNotNullCurrentAndNext && MoonriseOccurring == MoonriseOccurring.NextDay )
        times.Set(dateRow, Moonset.Value.TimeOfDay, rowNext.Moonset.Value.TimeOfDay, 0, 1, offset3);
      else
      if ( isNotNullCurrentAndPrevious && MoonriseOccurring == MoonriseOccurring.BeforeSet )
        times.Set(dateRow, rowPrevious.Moonset.Value.TimeOfDay, Moonset.Value.TimeOfDay, -1, 0, offset3);
      else
      if ( isNotNullPreviousAndNext )
        times.Set(dateRow, rowPrevious.Moonset.Value.TimeOfDay, rowNext.Moonset.Value.TimeOfDay, -1, 1, offset3);
      else
        throw new Exception(AppTranslations.CelebrationMoonDatesAndTimesError.GetLang() + Globals.NL2 +
                            $"    {nameof(isPreviousNotNull)}: {isPreviousNotNull}{Globals.NL}" +
                            $"    {nameof(isCurrentNotNull)}: {isCurrentNotNull}{Globals.NL}" +
                            $"    {nameof(isNextNotNull)}: {isNextNotNull}{Globals.NL}" +
                            $"    {nameof(isNotNullCurrentAndPrevious)}: {isNotNullCurrentAndPrevious}{Globals.NL}" +
                            $"    {nameof(isNotNullCurrentAndNext)}: {isNotNullCurrentAndNext}{Globals.NL}" +
                            $"    {nameof(isNotNullPreviousAndNext)}: {isNotNullPreviousAndNext}{Globals.NL2}" +
                            $"    Previous.{nameof(rowPrevious.Moonset)}: {rowPrevious.Moonset}{Globals.NL}" +
                            $"    Current.{nameof(Moonset)}: {Moonset}{Globals.NL}" +
                            $"    Next.{nameof(rowNext.Moonset)}: {rowNext.Moonset}");
    }
    else
    if ( rowPrevious.Sunset.HasValue && Sunset.HasValue )
      times.Set(dateRow, rowPrevious.Sunset.Value.TimeOfDay, Sunset.Value.TimeOfDay, -1, 0, offset3);
    else
      throw new Exception(AppTranslations.CelebrationSunDatesAndTimesError.GetLang() + Globals.NL2 +
                          $"    Previous.{nameof(rowPrevious.Sunset)}: {rowPrevious.Sunset}{Globals.NL}" +
                          $"    Current.{nameof(Sunset)}: {Sunset}");
    return times;
  }
}
