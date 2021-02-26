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

    private void CheckCelebrations()
    {
      bool check(TorahEvent item)
      {
        return TorahEventRemindList.ContainsKey(item) && TorahEventRemindList[item];
      }
      var dateNow = DateTime.Now;
      string strDateNow = SQLiteDate.ToString(dateNow);
      var dateLimit = dateNow.AddDays((int)Settings.ReminderCelebrationsInterval);
      var rows = from day in DataSet.LunisolarDays
                 where !RemindCelebrationDates.Contains(day.Date)
                    && check(day.TorahEventsAsEnum)
                    && SQLiteDate.ToDateTime(day.Date) >= dateNow
                    && SQLiteDate.ToDateTime(day.Date) <= dateLimit
                 select day;
      foreach ( LunisolarDaysRow row in rows )
      {
        var times = row.GetCelebrationTimes(Settings.RemindCelebrationEveryMinutes);
        if ( times == null ) continue;
        RemindCelebrationDates.Add(row.Date);
        ReminderForm.Run(row, TorahEvent.None, times);
      }
    }

  }

}
