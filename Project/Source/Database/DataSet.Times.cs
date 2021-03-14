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
/// <created> 2019-01 </created>
/// <edited> 2021-03 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    partial class LunisolarDaysRow
    {

      internal ReminderTimes GetTimesForShabat(decimal delta3)
      {
        var times = new ReminderTimes();
        var dateRow = DateAsDateTime;
        var rowPrevious = tableLunisolarDays.FindByDate(SQLiteDate.ToString(dateRow.AddDays(-1)));
        if ( rowPrevious == null )
          return null;
        if ( Program.Settings.RemindShabatOnlyLight )
          times.Set(dateRow, Sunrise, Sunset, 0, 0, delta3);
        else
          times.Set(dateRow, rowPrevious.Sunset, Sunset, -1, 0, delta3);
        return times;
      }

      internal ReminderTimes GetTimesForCelebration(decimal delta3)
      {
        var times = new ReminderTimes();
        var dateRow = DateAsDateTime;
        var rowPrevious = tableLunisolarDays.FindByDate(SQLiteDate.ToString(dateRow.AddDays(-1)));
        var rowNext = tableLunisolarDays.FindByDate(SQLiteDate.ToString(dateRow.AddDays(+1)));
        if ( rowPrevious == null || rowNext == null )
          return null;
        if ( Program.Settings.TorahEventsCountAsMoon )
        {
          if ( rowNext.Date == SQLiteDate.ToString(DateTime.Today) )
            times.Set(dateRow, Moonset, rowNext.Moonset, 0, 1, delta3);
          else
          if ( Moonset != string.Empty && (MoonRiseOccuring)MoonriseType == MoonRiseOccuring.AfterSet )
            times.Set(dateRow, Moonset, rowNext.Moonset, 0, 1, delta3);
          else
          if ( Moonset != string.Empty && (MoonRiseOccuring)MoonriseType == MoonRiseOccuring.NextDay )
            times.Set(dateRow, Moonset, rowNext.Moonset, 0, 1, delta3);
          else
          if ( Moonset != string.Empty && (MoonRiseOccuring)MoonriseType == MoonRiseOccuring.BeforeSet )
            times.Set(dateRow, rowPrevious.Moonset, Moonset, -1, 0, delta3);
          else
          if ( Moonset == string.Empty )
            times.Set(dateRow, rowPrevious.Moonset, rowNext.Moonset, -1, 1, delta3);
          else
            throw new Exception("Error on calculating celebration dates and times.");
        }
        else
          times.Set(dateRow, rowPrevious.Sunset, Sunset, -1, 0, delta3);
        return times;
      }
    }

  }

}
