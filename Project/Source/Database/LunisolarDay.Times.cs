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
/// <created> 2019-01 </created>
/// <edited> 2021-05 </edited>
using System;


namespace Ordisoftware.Hebrew.Calendar
{

  partial class LunisolarDay
  {

    internal DateTime GetEventStartDateTime(bool useRealDay, bool isMoon)
    {
      var day = this;
      if ( !isMoon && !Program.Settings.TorahEventsCountAsMoon )
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
        if ( day.MoonriseOccuring == MoonriseOccuring.BeforeSet || day.Moonset == null )
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

    internal ReminderTimes GetTimesForShabat(decimal delta3)
    {
      var times = new ReminderTimes();
      var dateRow = Date;
      var rowPrevious = Table.Find(d => d.Date == dateRow.AddDays(-1));
      if ( rowPrevious == null )
        return null;
      if ( Program.Settings.RemindShabatOnlyLight )
        times.Set(dateRow, Sunrise.Value.TimeOfDay, Sunset.Value.TimeOfDay, 0, 0, delta3);
      else
        times.Set(dateRow, rowPrevious.Sunset.Value.TimeOfDay, Sunset.Value.TimeOfDay, -1, 0, delta3);
      return times;
    }

    internal ReminderTimes GetTimesForCelebration(decimal delta3)
    {
      var times = new ReminderTimes();
      var dateRow = Date;
      var rowPrevious = Table.Find(d => d.Date == dateRow.AddDays(-1));
      var rowNext = Table.Find(d => d.Date == dateRow.AddDays(+1));
      if ( rowPrevious == null || rowNext == null )
        return null;
      if ( Program.Settings.TorahEventsCountAsMoon )
      {
        if ( rowNext.Date == DateTime.Today )
          times.Set(dateRow, Moonset.Value.TimeOfDay, rowNext.Moonset.Value.TimeOfDay, 0, 1, delta3);
        else
        if ( Moonset != null && MoonriseOccuring == MoonriseOccuring.AfterSet )
          times.Set(dateRow, Moonset.Value.TimeOfDay, rowNext.Moonset.Value.TimeOfDay, 0, 1, delta3);
        else
        if ( Moonset != null && MoonriseOccuring == MoonriseOccuring.NextDay )
          times.Set(dateRow, Moonset.Value.TimeOfDay, rowNext.Moonset.Value.TimeOfDay, 0, 1, delta3);
        else
        if ( Moonset != null && MoonriseOccuring == MoonriseOccuring.BeforeSet )
          times.Set(dateRow, rowPrevious.Moonset.Value.TimeOfDay, Moonset.Value.TimeOfDay, -1, 0, delta3);
        else
        if ( Moonset == null )
          times.Set(dateRow, rowPrevious.Moonset.Value.TimeOfDay, rowNext.Moonset.Value.TimeOfDay, -1, 1, delta3);
        else
          throw new Exception("Error on calculating celebration dates and times.");
      }
      else
        times.Set(dateRow, rowPrevious.Sunset.Value.TimeOfDay, Sunset.Value.TimeOfDay, -1, 0, delta3);
      return times;
    }
  }

}
