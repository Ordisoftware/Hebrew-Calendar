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
/// <edited> 2019-10 </edited>
using System;
using System.Data;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void CheckShabat()
    {
      var dateNow = DateTime.Now;
      string strDateNow = SQLiteDate.ToString(dateNow);
      var row = ( from day in DataSet.LunisolarDays
                  where SQLiteDate.ToDateTime(day.Date).DayOfWeek == (DayOfWeek)Settings.ShabatDay
                     && SQLiteDate.ToDateTime(day.Date) >= SQLiteDate.ToDateTime(strDateNow)
                  select day ).FirstOrDefault() as Data.DataSet.LunisolarDaysRow;
      if ( row == null )
        return;
      var dateRow = SQLiteDate.ToDateTime(row.Date);
      var rowPrevious = DataSet.LunisolarDays.FindByDate(SQLiteDate.ToString(dateRow.AddDays(-1)));
      var times = new ReminderTimes();
      var delta3 = Settings.RemindShabatEveryMinutes;
      if ( Settings.RemindShabatOnlyLight )
        SetTimes(times, dateRow, row.Sunrise, row.Sunset, 0, 0, delta3);
      else
        SetTimes(times, dateRow, rowPrevious.Sunset, row.Sunset, -1, 0, delta3);
      var dateTrigger = times.dateStartCheck.Value.AddHours((double)-Settings.RemindShabatHoursBefore);
      if ( dateNow < dateTrigger || dateNow >= times.dateEnd.Value )
      {
        LastShabatReminded = null;
        if ( ShabatForm != null )
          ShabatForm.Close();
        return;
      }
      else
      if ( dateNow >= dateTrigger && dateNow < times.dateStartCheck )
      {
        if ( LastShabatReminded.HasValue )
          return;
        else
          LastShabatReminded = dateNow;
      }
      else
      if ( LastShabatReminded.HasValue )
      {
        if ( dateNow > times.dateStart && LastShabatReminded.Value < times.dateStart )
        {
          if ( ShabatForm != null )
            ShabatForm.Close();
          LastShabatReminded = dateNow;
        }
        else
        if ( dateNow < LastShabatReminded.Value.AddMinutes((double)Settings.RemindShabatEveryMinutes) )
          return;
        else
          LastShabatReminded = dateNow;
      }
      else
        LastShabatReminded = dateNow;
      ReminderForm.Run(row, TorahEvent.Shabat, times);
    }

  }

}
