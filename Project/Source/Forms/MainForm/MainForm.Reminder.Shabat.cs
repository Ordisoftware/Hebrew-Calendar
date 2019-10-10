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
/// <edited> 2019-08 </edited>
using System;
using System.Data;
using System.Linq;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void CheckShabat()
    {
      try
      {
        var today = DateTime.Today;
        var dateNow = DateTime.Now;
        string strDate = SQLiteUtility.GetDate(today);
        var row = ( from day in LunisolarCalendar.LunisolarDays
                    where SQLiteUtility.GetDate(day.Date).DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay
                       && SQLiteUtility.GetDate(day.Date) >= SQLiteUtility.GetDate(strDate)
                    select day ).FirstOrDefault() as Data.LunisolarCalendar.LunisolarDaysRow;
        if ( row == null ) return;
        var rowPrevious = LunisolarCalendar.LunisolarDays.FindByDate(SQLiteUtility.GetDate(SQLiteUtility.GetDate(row.Date).AddDays(-1)));
        string timeStart = "";
        string timeEnd = "";
        string[] timesStart = null;
        string[] timesEnd = null;
        DateTime? dateStart = null;
        DateTime? dateEnd = null;
        Action<string, string, int> initTimes = (start, end, delta) =>
        {
          timeStart = start;
          timeEnd = end;
          timesStart = timeStart.Split(':');
          timesEnd = timeEnd.Split(':');
          var date = SQLiteUtility.GetDate(row.Date);
          dateStart = date.AddDays(delta).AddHours(Convert.ToInt32(timesStart[0]))
                      .AddMinutes(Convert.ToInt32(timesStart[1]))
                      .AddMinutes(-Program.Settings.RemindShabatEveryMinutes);
          dateEnd = date.AddHours(Convert.ToInt32(timesEnd[0])).AddMinutes(Convert.ToInt32(timesEnd[1]));
        };
        if ( Program.Settings.RemindShabatOnlyLight )
          initTimes(row.Sunrise, row.Sunset, 0);
        else
          initTimes(rowPrevious.Sunset, row.Sunset, -1);
        var dateTrigger = dateStart.Value.AddHours(-Program.Settings.RemindShabatHoursBefore);
        if ( dateNow < dateTrigger || dateNow >= dateEnd.Value.AddMinutes(-Program.Settings.RemindShabatEveryMinutes) )
        {
          ReminderForm.LastShabatReminded = null;
          if ( ReminderForm.ShabatForm != null )
          {
            ReminderForm.ShabatForm.Close();
            ReminderForm.ShabatForm = null;
          }
          return;
        }
        else
        if ( dateNow >= dateTrigger && dateNow < dateStart )
        {
          if ( ReminderForm.LastShabatReminded.HasValue )
            return;
          else
            ReminderForm.LastShabatReminded = dateNow;
        }
        else
        if ( ReminderForm.LastShabatReminded.HasValue )
        {
          if ( dateNow < ReminderForm.LastShabatReminded.Value.AddMinutes(Program.Settings.RemindShabatEveryMinutes) )
            return;
          else
            ReminderForm.LastShabatReminded = dateNow;
        }
        else
          ReminderForm.LastShabatReminded = dateNow;
        ReminderForm.Run(row, true, timeStart, timeEnd);
      }
      catch
      {
      }
    }

  }

}
