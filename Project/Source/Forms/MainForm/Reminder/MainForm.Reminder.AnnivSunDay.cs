/*/// <license>
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
/// <created> 2020-09 </created>
/// <edited> 2020-09 </edited>
using System;
using System.Data;
using System.Linq;
using Ordisoftware.Core;
using LunisolarDay = Ordisoftware.Hebrew.Calendar.Data.DataSet.LunisolarDay;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    DateTime BirthDate = new DateTime(2000, 9, 25);
    int MoonMonthBirth = 1;
    int MoonDayBirth = 1;

    private void CheckAnniversarySunDay()
    {
      var dateBirth = BirthDate.Change(year: DateTime.Today.Year);
      var dateNow = DateTime.Now;
      string strDateNow = SQLiteDate.ToString(dateNow);
      var row = ( from day in LunisolarDays
                  where day.Date == dateBirth
                  select day ).FirstOrDefault() as LunisolarDay;
      if ( row is null )
        return;
      var dateRow = row.Date;
      var rowPrevious = LunisolarDays.FindByDate(SQLiteDate.ToString(dateRow.AddDays(-1)));
      var times = new ReminderTimes();
      var delta3 = Settings.RemindShabatEveryMinutes;
      times.SetTimes(dateRow, rowPrevious.Sunset, row.Sunset, -1, 0, delta3);
      var dateTrigger = times.dateStartCheck.Value.AddHours((double)-Settings.RemindShabatHoursBefore);

      // TODO use anniversarysunform & date like shabat
      var torahevent = TorahEvent.AnniversarySun;
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
*/