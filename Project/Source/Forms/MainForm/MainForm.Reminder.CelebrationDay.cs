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

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void CheckCelebrationDay()
    {
      bool check(TorahEvent item)
      {
        return TorahEventRemindDayList.ContainsKey(item) && TorahEventRemindDayList[item];
      }
      var dateNow = DateTime.Now;
      string strDateNow = SQLiteUtility.GetDate(dateNow);
      var row = ( from day in DataSet.LunisolarDays
                  where (TorahEvent)day.TorahEvents != TorahEvent.None
                     && check((TorahEvent)day.TorahEvents)
                     && SQLiteUtility.GetDate(day.Date) >= SQLiteUtility.GetDate(strDateNow).AddDays(-1)
                  select day ).FirstOrDefault() as Data.DataSet.LunisolarDaysRow;
      if ( row == null ) return;
      var times = CreateCelebrationTimes(row, Program.Settings.RemindCelebrationEveryMinutes);
      if ( times == null ) return;
      var dateTrigger = times.dateStartCheck.Value.AddHours((double)-Program.Settings.RemindCelebrationHoursBefore);
      if ( dateNow < dateTrigger || dateNow >= times.dateEnd.Value )
      {
        LastCelebrationReminded[(TorahEvent)row.TorahEvents] = null;
        if ( RemindCelebrationDayForms.ContainsKey((TorahEvent)row.TorahEvents) )
          RemindCelebrationDayForms[(TorahEvent)row.TorahEvents].Close();
        return;
      }
      else
      if ( dateNow >= dateTrigger && dateNow < times.dateStartCheck )
      {
        if ( LastCelebrationReminded.ContainsKey((TorahEvent)row.TorahEvents) && LastCelebrationReminded[(TorahEvent)row.TorahEvents].HasValue )
          return;
        else
          LastCelebrationReminded[(TorahEvent)row.TorahEvents] = dateNow;
      }
      else
      if ( LastCelebrationReminded.ContainsKey((TorahEvent)row.TorahEvents) && LastCelebrationReminded[(TorahEvent)row.TorahEvents].HasValue )
      {
        if ( dateNow > times.dateStart && LastCelebrationReminded[(TorahEvent)row.TorahEvents].Value < times.dateStart )
        {
          if ( RemindCelebrationDayForms[(TorahEvent)row.TorahEvents] != null )
            RemindCelebrationDayForms[(TorahEvent)row.TorahEvents].Close();
          LastCelebrationReminded[(TorahEvent)row.TorahEvents] = dateNow;
        }
        else
        if ( dateNow < LastCelebrationReminded[(TorahEvent)row.TorahEvents].Value.AddMinutes((double)Program.Settings.RemindCelebrationEveryMinutes) )
          return;
        else
          LastCelebrationReminded[(TorahEvent)row.TorahEvents] = dateNow;
      }
      else
        LastCelebrationReminded[(TorahEvent)row.TorahEvents] = dateNow;
      ReminderForm.Run(row, false, (TorahEvent)row.TorahEvents, times);
    }

  }

}
