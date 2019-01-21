/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Data;
using System.Linq;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void CheckEvents()
    {
      try
      {
        var dateStart = DateTime.Now;
        var dateEnd = DateTime.Now.AddDays(Program.Settings.ReminderInterval);
        string strDateStart = SQLiteUtility.GetDate(dateStart);
        string strDateEnd = SQLiteUtility.GetDate(dateEnd);
        var row = ( from day in LunisolarCalendar.LunisolarDays
                    where SQLiteUtility.GetDate(day.Date) >= SQLiteUtility.GetDate(strDateStart)
                       && SQLiteUtility.GetDate(day.Date) <= SQLiteUtility.GetDate(strDateEnd)
                       && check((TorahEventType)day.TorahEvents)
                       && !Reminded.Contains(day.Date)
                    select day ).FirstOrDefault() as Data.LunisolarCalendar.LunisolarDaysRow;
        if ( row == null ) return;
        Reminded.Add(row.Date);
        ReminderForm.Run(row, false);
      }
      catch
      {
      }
      bool check(TorahEventType item)
      {
        foreach ( TorahEventType type in Enum.GetValues(typeof(TorahEventType)) )
          if ( type != TorahEventType.None )
            try
            {
              if ( item == type && (bool)Program.Settings["TorahEventRemind" + item.ToString()] )
                return true;
            }
            catch
            {
            }
        return false;
      }
    }

    private void CheckShabat()
    {
      try
      {
        var today = DateTime.Today;
        var now = DateTime.Now;
        var timeNow = new TimeSpan(now.Hour, now.Minute, 0);
        string strDate = SQLiteUtility.GetDate(today);
        var row = ( from day in LunisolarCalendar.LunisolarDays
                    where SQLiteUtility.GetDate(day.Date).DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay
                        && ( SQLiteUtility.GetDate(day.Date).AddDays(-1) == today
                        || SQLiteUtility.GetDate(day.Date) == today )
                        && !Reminded.Contains(day.Date)
                    select day ).FirstOrDefault() as Data.LunisolarCalendar.LunisolarDaysRow;
        if ( row == null ) return;
        string[] times = row.Sunset.Split(':');
        if ( SQLiteUtility.GetDate(row.Date) == today 
          && timeNow > new TimeSpan(Convert.ToInt32(times[0]), Convert.ToInt32(times[1]), 0) )
          return;
        Reminded.Add(row.Date);
        ReminderForm.Run(row, true);
      }
      catch
      {
      }
    }

  }

}
