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
      bool check(TorahEventType item)
      {
        return TorahEventRemindDayList.ContainsKey(item) && TorahEventRemindDayList[item];
      }
      var dateNow = DateTime.Now;
      string strDateNow = SQLiteUtility.GetDate(dateNow);
      var row = ( from day in DataSet.LunisolarDays
                  where (TorahEventType)day.TorahEvents != TorahEventType.None
                     && check((TorahEventType)day.TorahEvents)
                     && SQLiteUtility.GetDate(day.Date) >= SQLiteUtility.GetDate(strDateNow).AddDays(-1)
                  select day ).FirstOrDefault() as Data.DataSet.LunisolarDaysRow;
      if ( row == null ) return;
      var times = CreateCelebrationTimes(row, Program.Settings.RemindCelebrationEveryMinutes);
      if ( times == null ) return;
      var dateTrigger = times.dateStartCheck.Value.AddHours((double)-Program.Settings.RemindCelebrationHoursBefore);
      if ( dateNow < dateTrigger || dateNow >= times.dateEnd.Value )
      {
        LastCelebrationReminded[(TorahEventType)row.TorahEvents] = null;
        if ( RemindCelebrationDayForms.ContainsKey((TorahEventType)row.TorahEvents) )
          RemindCelebrationDayForms[(TorahEventType)row.TorahEvents].Close();
        return;
      }
      else
      if ( dateNow >= dateTrigger && dateNow < times.dateStartCheck )
      {
        if ( LastCelebrationReminded.ContainsKey((TorahEventType)row.TorahEvents) && LastCelebrationReminded[(TorahEventType)row.TorahEvents].HasValue )
          return;
        else
          LastCelebrationReminded[(TorahEventType)row.TorahEvents] = dateNow;
      }
      else
      if ( LastCelebrationReminded.ContainsKey((TorahEventType)row.TorahEvents) && LastCelebrationReminded[(TorahEventType)row.TorahEvents].HasValue )
      {
        if ( dateNow > times.dateStart && LastCelebrationReminded[(TorahEventType)row.TorahEvents].Value < times.dateStart )
        {
          if ( RemindCelebrationDayForms[(TorahEventType)row.TorahEvents] != null )
            RemindCelebrationDayForms[(TorahEventType)row.TorahEvents].Close();
          LastCelebrationReminded[(TorahEventType)row.TorahEvents] = dateNow;
        }
        else
        if ( dateNow < LastCelebrationReminded[(TorahEventType)row.TorahEvents].Value.AddMinutes((double)Program.Settings.RemindCelebrationEveryMinutes) )
          return;
        else
          LastCelebrationReminded[(TorahEventType)row.TorahEvents] = dateNow;
      }
      else
        LastCelebrationReminded[(TorahEventType)row.TorahEvents] = dateNow;
      ReminderForm.Run(row, false, (TorahEventType)row.TorahEvents, times);
    }

  }

}
