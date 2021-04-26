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
/// <edited> 2021-04 </edited>
using System;
using System.Data;
using System.Linq;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private bool CheckShabat(bool showbox)
    {
      bool result = false;
      var dateNow = DateTime.Now;
      dateNow = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, dateNow.Hour, dateNow.Minute, 0);
      var dateToday = DateTime.Today;
      var row = ( from day in DataSet.LunisolarDays
                  where day.DateAsDateTime.DayOfWeek == (DayOfWeek)Settings.ShabatDay
                     && day.DateAsDateTime >= dateToday
                  select day ).FirstOrDefault();
      if ( row == null ) return result;
      var times = row.GetTimesForShabat(Settings.RemindShabatEveryMinutes);
      if ( times == null ) return result;
      result = dateNow >= times.DateStart.Value && dateNow < times.DateEnd.Value;
      var dateTrigger = times.DateStartCheck.Value.AddHours((double)-Settings.RemindShabatHoursBefore);
      if ( dateNow < dateTrigger || dateNow >= times.DateEnd.Value )
      {
        LastShabatReminded = null;
        if ( ShabatForm != null )
          ShabatForm.Close();
        return result;
      }
      else
      if ( dateNow >= dateTrigger && dateNow < times.DateStartCheck )
      {
        if ( LastShabatReminded.HasValue )
          return result;
        else
          LastShabatReminded = dateNow;
      }
      else
      if ( LastShabatReminded.HasValue )
      {
        if ( dateNow > times.DateStart && LastShabatReminded.Value < times.DateStart )
        {
          if ( ShabatForm != null )
            ShabatForm.Close();
          LastShabatReminded = dateNow;
        }
        else
        if ( dateNow < LastShabatReminded.Value.AddMinutes((double)Settings.RemindShabatEveryMinutes) )
          return result;
        else
          LastShabatReminded = dateNow;
      }
      else
        LastShabatReminded = dateNow;
      if ( showbox ) ReminderForm.Run(row, TorahEvent.Shabat, times);
      return result;
    }

  }

}
