/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-10 </edited>
using System;
using System.Data;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void SetTimes(ReminderTimes times, 
                          DateTime date, 
                          string timeStart, 
                          string timeEnd, 
                          int delta1, 
                          int delta2, 
                          decimal delta3)
    {
      string[] timesStart = timeStart.Split(':');
      string[] timesEnd = timeEnd.Split(':');
      times.timeStart = timeStart;
      times.timeEnd = timeEnd;
      times.dateStart = date.AddDays(delta1).AddHours(Convert.ToInt32(timesStart[0]))
                            .AddMinutes(Convert.ToInt32(timesStart[1]));
      times.dateStartCheck = times.dateStart.Value.AddMinutes((double)-delta3);
      times.dateEnd = date.AddDays(delta2).AddHours(Convert.ToInt32(timesEnd[0]))
                          .AddMinutes(Convert.ToInt32(timesEnd[1]));
    }

    private ReminderTimes CreateCelebrationTimes(Data.DataSet.LunisolarDaysRow row, decimal delta3)
    {
      var times = new ReminderTimes();
      var dateRow = SQLiteUtility.GetDate(row.Date);
      var rowPrevious = DataSet.LunisolarDays.FindByDate(SQLiteUtility.GetDate(dateRow.AddDays(-1)));
      var rowNext = DataSet.LunisolarDays.FindByDate(SQLiteUtility.GetDate(dateRow.AddDays(+1)));
      if ( rowPrevious == null || rowNext == null ) return null;
      if ( Program.Settings.TorahEventsCountAsMoon )
      {
        if ( rowNext.Date == SQLiteUtility.GetDate(DateTime.Today) )
          SetTimes(times, dateRow, row.Moonset, rowNext.Moonset, 0, 1, delta3);
        else
        if ( row.Moonset != "" && (MoonriseType)row.MoonriseType == MoonriseType.AfterSet )
          SetTimes(times, dateRow, row.Moonset, rowNext.Moonset, 0, 1, delta3);
        else
        if ( row.Moonset != "" && (MoonriseType)row.MoonriseType == MoonriseType.NextDay )
          SetTimes(times, dateRow, row.Moonset, rowNext.Moonset, 0, 1, delta3);
        else
        if ( row.Moonset != "" && (MoonriseType)row.MoonriseType == MoonriseType.BeforeSet )
          SetTimes(times, dateRow, rowPrevious.Moonset, row.Moonset, -1, 0, delta3);
        else
        if ( row.Moonset == "" )
          SetTimes(times, dateRow, rowPrevious.Moonset, rowNext.Moonset, -1, 1, delta3);
        else
          throw new Exception("Error on calculating celebration dates and times.");
      }
      else
        SetTimes(times, dateRow, rowPrevious.Sunset, row.Sunset, -1, 0, delta3);
      return times;
    }

  }

  public class ReminderTimes
  {
    public string timeStart;
    public string timeEnd;
    public DateTime? dateStartCheck;
    public DateTime? dateStart;
    public DateTime? dateEnd;
  }

}
