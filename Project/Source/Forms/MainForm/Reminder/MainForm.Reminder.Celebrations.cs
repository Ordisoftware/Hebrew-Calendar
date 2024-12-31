/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private void CheckCelebrations()
  {
    bool check(TorahCelebrationDay item)
    {
      return TorahEventRemindList.ContainsKey(item) && TorahEventRemindList[item];
    }
    var dateNow = DateTime.Now;
    dateNow = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, dateNow.Hour, dateNow.Minute, 0);
    var dateToday = DateTime.Today;
    var dateLimit = dateNow.AddDays((int)Settings.ReminderCelebrationsInterval);
    var rows = from day in LunisolarDays
               where !RemindCelebrationDates.Contains(day.Date)
                  && check(day.TorahEvent)
                  && day.Date >= dateToday
                  && day.Date <= dateLimit
               select day;
    foreach ( var row in rows )
    {
      var times = row.GetTimesForCelebration(Settings.RemindCelebrationEveryMinutes);
      if ( times is null ) continue;
      RemindCelebrationDates.Add(row.Date);
      ReminderForm.Run(row, TorahCelebrationDay.None, times);
    }
  }

}
