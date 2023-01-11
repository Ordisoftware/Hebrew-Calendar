/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
    var dayPrevious = dateToday.AddDays(-1);
    var row = LunisolarDays.Find(day => day.HasTorahEvent && check(day.TorahEvent) && day.Date >= dayPrevious);
    if ( row is null ) return result;
    var torahevent = row.TorahEvent;
    if ( row.Date.Day < dateNow.Day )
      if ( Settings.TorahEventsCountAsMoon && row.MoonriseOccuring == MoonriseOccurring.BeforeSet )
        return result;
    var times = row.GetTimesForCelebration(Settings.RemindCelebrationEveryMinutes);
    if ( times is null ) return result;
    result = dateNow >= times.DateStart && dateNow < times.DateEnd;
    var dateTrigger = times.DateStartCheck.AddHours((double)-Settings.RemindCelebrationHoursBefore);
    if ( dateNow < dateTrigger || dateNow >= times.DateEnd )
    {
      LastCelebrationReminded[torahevent] = null;
      if ( RemindCelebrationDayForms.TryGetValue(torahevent, out var form) )
        form.Close();
      return result;
    }
    else
    if ( dateNow >= dateTrigger && dateNow < times.DateStartCheck )
    {
      if ( LastCelebrationReminded[torahevent] is not null )
        return result;
      else
        LastCelebrationReminded[torahevent] = dateNow;
    }
    else
    if ( LastCelebrationReminded[torahevent] is not null )
    {
      if ( dateNow > times.DateStart && LastCelebrationReminded[torahevent] < times.DateStart )
      {
        if ( RemindCelebrationDayForms.TryGetValue(torahevent, out var form) )
          form.Close();
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
