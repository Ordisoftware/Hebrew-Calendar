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
/// <edited> 2021-04 </edited>
using System;
using System.Data;
using System.Linq;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private bool CheckCelebrationDay(bool showbox)
    {
      bool check(TorahCelebrationDay item)
      {
        return TorahEventRemindDayList.ContainsKey(item) && TorahEventRemindDayList[item];
      }
      bool result = false;
      var dateNow = DateTime.Now;
      dateNow = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, dateNow.Hour, dateNow.Minute, 0);
      var dateToday = DateTime.Today;
      var row = ( from day in LunisolarDays
                  where day.HasTorahEvent && check(day.TorahEvent)
                     && day.Date >= dateToday.AddDays(-1)
                  select day ).FirstOrDefault();
      if ( row == null ) return result;
      var torahevent = row.TorahEvent;
      if ( row.Date.Day < dateNow.Day )
        if ( Settings.TorahEventsCountAsMoon && row.MoonriseOccuring == MoonriseOccuring.BeforeSet )
          return result;
      var times = row.GetTimesForCelebration(Settings.RemindCelebrationEveryMinutes);
      if ( times == null ) return result;
      result = dateNow >= times.DateStart && dateNow < times.DateEnd;
      var dateTrigger = times.DateStartCheck.AddHours((double)-Settings.RemindCelebrationHoursBefore);
      if ( dateNow < dateTrigger || dateNow >= times.DateEnd )
      {
        LastCelebrationReminded[torahevent] = null;
        if ( RemindCelebrationDayForms.ContainsKey(torahevent) )
          RemindCelebrationDayForms[torahevent].Close();
        return result;
      }
      else
      if ( dateNow >= dateTrigger && dateNow < times.DateStartCheck )
      {
        if ( LastCelebrationReminded[torahevent].HasValue )
          return result;
        else
          LastCelebrationReminded[torahevent] = dateNow;
      }
      else
      if ( LastCelebrationReminded[torahevent].HasValue )
      {
        if ( dateNow > times.DateStart && LastCelebrationReminded[torahevent].Value < times.DateStart )
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
      if ( showbox ) ReminderForm.Run(row, torahevent, times);
      return result;
    }

  }

}
