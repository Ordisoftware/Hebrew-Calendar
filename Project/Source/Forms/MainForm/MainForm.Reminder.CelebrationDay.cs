/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-09 </edited>
using System;
using System.Data;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
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
      string strDateNow = SQLiteDate.ToString(dateNow);
      var row = ( from day in DataSet.LunisolarDays
                  where (TorahEvent)day.TorahEvents != TorahEvent.None
                     && check((TorahEvent)day.TorahEvents)
                     && SQLiteDate.ToDateTime(day.Date) >= SQLiteDate.ToDateTime(strDateNow).AddDays(-1)
                  select day ).FirstOrDefault() as Data.DataSet.LunisolarDaysRow;
      if ( row == null ) return;
      if ( SQLiteDate.ToDateTime(row.Date).Day < dateNow.Day )
        if ( Settings.TorahEventsCountAsMoon && row.MoonriseType == (int)MoonRise.BeforeSet )
          return;
        //else
          //return;
      var times = CreateCelebrationTimes(row, Settings.RemindCelebrationEveryMinutes);
      if ( times == null ) return;
      var dateTrigger = times.dateStartCheck.Value.AddHours((double)-Settings.RemindCelebrationHoursBefore);
      var torahevent = (TorahEvent)row.TorahEvents;
      if ( dateNow < dateTrigger || dateNow >= times.dateEnd.Value )
      {
        LastCelebrationReminded[torahevent] = null;
        if ( RemindCelebrationDayForms.ContainsKey(torahevent) )
          RemindCelebrationDayForms[torahevent].Close();
        return;
      }
      else
      if ( dateNow >= dateTrigger && dateNow < times.dateStartCheck )
      {
        if ( LastCelebrationReminded[torahevent].HasValue )
          return;
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
          return;
        else
          LastCelebrationReminded[torahevent] = dateNow;
      }
      else
        LastCelebrationReminded[torahevent] = dateNow;
      ReminderForm.Run(row, torahevent, times);
    }

  }

}
