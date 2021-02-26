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
/// <edited> 2021-02 </edited>
using System;
using System.Data;
using System.Linq;
using Ordisoftware.Core;
using LunisolarDaysRow = Ordisoftware.Hebrew.Calendar.Data.DataSet.LunisolarDaysRow;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private bool CheckCelebrationDay()
    {
      bool check(TorahEvent item)
      {
        return TorahEventRemindDayList.ContainsKey(item) && TorahEventRemindDayList[item];
      }
      var dateNow = DateTime.Now;
      string strDateNow = SQLiteDate.ToString(dateNow);
      var row = ( from day in DataSet.LunisolarDays
                  where day.TorahEventsAsEnum != TorahEvent.None
                     && check(day.TorahEventsAsEnum)
                     && SQLiteDate.ToDateTime(day.Date) >= SQLiteDate.ToDateTime(strDateNow).AddDays(-1)
                  select day ).FirstOrDefault() as LunisolarDaysRow;
      if ( row == null ) return false;
      if ( SQLiteDate.ToDateTime(row.Date).Day < dateNow.Day )
        if ( Settings.TorahEventsCountAsMoon && row.MoonriseOccuringAsEnum == MoonRiseOccuring.BeforeSet )
          return false;
      var times = row.GetReminderTimes(Settings.RemindCelebrationEveryMinutes);
      if ( times == null ) return false;
      bool result = dateNow >= times.dateStartCheck.Value && dateNow <= times.dateEnd.Value;
      var dateTrigger = times.dateStartCheck.Value.AddHours((double)-Settings.RemindCelebrationHoursBefore);
      var torahevent = row.TorahEventsAsEnum;
      if ( dateNow < dateTrigger || dateNow >= times.dateEnd.Value )
      {
        LastCelebrationReminded[torahevent] = null;
        if ( RemindCelebrationDayForms.ContainsKey(torahevent) )
          RemindCelebrationDayForms[torahevent].Close();
        return result;
      }
      else
      if ( dateNow >= dateTrigger && dateNow < times.dateStartCheck )
      {
        if ( LastCelebrationReminded[torahevent].HasValue )
          return result;
        else
          LastCelebrationReminded[torahevent] = dateNow;
      }
      else
      if ( LastCelebrationReminded[torahevent].HasValue )
      {
        if ( dateNow > times.dateStart && LastCelebrationReminded[torahevent].Value < times.dateStart )
        {
          if ( RemindCelebrationDayForms.ContainsKey(torahevent) )
            RemindCelebrationDayForms[torahevent].Close();
          LastCelebrationReminded[torahevent] = dateNow;
        }
        else
        if ( dateNow < LastCelebrationReminded[torahevent].Value.AddMinutes((double)Settings.RemindCelebrationEveryMinutes) )
          return result;
        else
          LastCelebrationReminded[torahevent] = dateNow;
      }
      else
        LastCelebrationReminded[torahevent] = dateNow;
      ReminderForm.Run(row, torahevent, times);
      return result;
    }

  }

}
