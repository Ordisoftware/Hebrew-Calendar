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
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void CheckCelebrationDay()
    {
      bool check(TorahEventType item)
      {
        return TorahEventRemindDayList.ContainsKey(item) && TorahEventRemindDayList[item];
      }
      try
      {
        var today = DateTime.Today;
        var dateNow = DateTime.Now;
        string strDate = SQLiteUtility.GetDate(today);
        var row = ( from day in LunisolarCalendar.LunisolarDays
                    where (TorahEventType)day.TorahEvents != TorahEventType.None
                       && check((TorahEventType)day.TorahEvents)
                       && SQLiteUtility.GetDate(day.Date) >= SQLiteUtility.GetDate(strDate).AddDays(-1)
                    select day ).FirstOrDefault() as Data.LunisolarCalendar.LunisolarDaysRow;
        if ( row == null ) return;
        var rowPrevious = LunisolarCalendar.LunisolarDays
                          .FindByDate(SQLiteUtility.GetDate(SQLiteUtility.GetDate(row.Date).AddDays(-1)));
        var rowNext = LunisolarCalendar.LunisolarDays
                      .FindByDate(SQLiteUtility.GetDate(SQLiteUtility.GetDate(row.Date).AddDays(+1)));
        if ( rowPrevious == null || rowNext == null ) return;
        string timeStart = "";
        string timeEnd = "";
        string[] timesStart = null;
        string[] timesEnd = null;
        DateTime? dateStartCheck = null;
        DateTime? dateStart = null;
        DateTime? dateEnd = null;
        Action<string, string, int, int> initTimes = (start, end, delta1, delta2) =>
        {
          timeStart = start;
          timeEnd = end;
          timesStart = timeStart.Split(':');
          timesEnd = timeEnd.Split(':');
          var date = SQLiteUtility.GetDate(row.Date);
          dateStart = date.AddDays(delta1).AddHours(Convert.ToInt32(timesStart[0]))
                      .AddMinutes(Convert.ToInt32(timesStart[1]));
          dateStartCheck = dateStart.Value.AddMinutes((double)-Program.Settings.RemindCelebrationEveryMinutes);
          dateEnd = date.AddDays(delta2).AddHours(Convert.ToInt32(timesEnd[0])).AddMinutes(Convert.ToInt32(timesEnd[1]));
        };
        if ( row.Moonset != "" && (MoonriseType)row.MoonriseType == MoonriseType.AfterSet )
          initTimes(row.Moonset, rowNext.Moonset, 0, 1);
        else
        if ( row.Moonset != "" && (MoonriseType)row.MoonriseType == MoonriseType.NextDay )
          initTimes(row.Moonset, rowNext.Moonset, 0, 1);
        else
        if ( row.Moonset != "" && (MoonriseType)row.MoonriseType == MoonriseType.BeforeSet )
          initTimes(rowPrevious.Moonset, row.Moonset, -1, 0);
        else
        if ( row.Moonset == "" )
          initTimes(rowPrevious.Moonset, rowNext.Moonset, -1, 1);
        else
          throw new Exception("Error on calculating celebration dates and times.");
        var dateTrigger = dateStartCheck.Value.AddHours((double)-Program.Settings.RemindCelebrationHoursBefore);
        if ( dateNow < dateTrigger || dateNow >= dateEnd.Value
                                                 .AddMinutes((double)-Program.Settings.RemindCelebrationEveryMinutes) )
        {
          LastCelebrationReminded[(TorahEventType)row.TorahEvents] = null;
          if ( RemindCelebrationDayForms.ContainsKey((TorahEventType)row.TorahEvents) )
            RemindCelebrationDayForms[(TorahEventType)row.TorahEvents].Close();
          return;
        }
        else
        if ( dateNow >= dateTrigger && dateNow < dateStartCheck )
        {
          if ( LastCelebrationReminded.ContainsKey((TorahEventType)row.TorahEvents)
            && LastCelebrationReminded[(TorahEventType)row.TorahEvents].HasValue )
            return;
          else
            LastCelebrationReminded[(TorahEventType)row.TorahEvents] = dateNow;
        }
        else
        if ( LastCelebrationReminded.ContainsKey((TorahEventType)row.TorahEvents)
            && LastCelebrationReminded[(TorahEventType)row.TorahEvents].HasValue )
        {
          if ( dateNow < LastCelebrationReminded[(TorahEventType)row.TorahEvents].Value
                         .AddMinutes((double)Program.Settings.RemindCelebrationEveryMinutes) )
            return;
          else
            LastCelebrationReminded[(TorahEventType)row.TorahEvents] = dateNow;
        }
        else
          LastCelebrationReminded[(TorahEventType)row.TorahEvents] = dateNow;
        ReminderForm.Run(row, false, (TorahEventType)row.TorahEvents, dateStart, dateEnd, timeStart, timeEnd);
      }
      catch ( Exception ex )
      {
        if ( TimerErrorShown ) return;
        TimerErrorShown = true;
        ex.Manage();
      }
    }

  }

}
