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

    private bool CheckShabat(bool showBox)
    {
      var dateNow = DateTime.Now;
      string strDateNow = SQLiteDate.ToString(dateNow);
      var row = ( from day in DataSet.LunisolarDays
                  where day.DateAsDateTime.DayOfWeek == (DayOfWeek)Settings.ShabatDay
                     && day.DateAsDateTime >= dateNow
                  select day ).FirstOrDefault() as LunisolarDaysRow;
      if ( row == null )
        return false;
      var dateRow = row.DateAsDateTime;
      var rowPrevious = DataSet.LunisolarDays.FindByDate(SQLiteDate.ToString(dateRow.AddDays(-1)));
      var times = new ReminderTimes();
      var delta3 = Settings.RemindShabatEveryMinutes;
      if ( Settings.RemindShabatOnlyLight )
        times.Set(dateRow, row.Sunrise, row.Sunset, 0, 0, delta3);
      else
        times.Set(dateRow, rowPrevious.Sunset, row.Sunset, -1, 0, delta3);
      bool result = dateNow >= times.DateStart.Value && dateNow <= times.DateEnd.Value;
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
      if ( showBox ) ReminderForm.Run(row, TorahEvent.Shabat, times);
      return result;
    }

  }

}
