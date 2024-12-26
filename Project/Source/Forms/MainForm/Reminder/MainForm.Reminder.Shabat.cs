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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private bool CheckShabat(bool showbox)
  {
    bool result = false;
    var dateNow = DateTime.Now;
    dateNow = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, dateNow.Hour, dateNow.Minute, 0);
    var dateToday = DateTime.Today;
    var dayShabat = (DayOfWeek)Settings.ShabatDay;
    var row = LunisolarDays.Find(day => day.Date.DayOfWeek == dayShabat && day.Date >= dateToday);
    if ( row is null ) return result;
    var times = row.GetTimesForShabat(Settings.RemindShabatEveryMinutes);
    if ( times is null ) return result;
    result = dateNow >= times.DateStart && dateNow < times.DateEnd;
    var dateTrigger = times.DateStartCheck.AddHours((double)-Settings.RemindShabatHoursBefore);
    if ( dateNow < dateTrigger || dateNow >= times.DateEnd )
    {
      LastShabatReminded = null;
      ShabatForm?.Close();
      return result;
    }
    else
    //#pragma warning disable S2589 // Boolean expressions should not be gratuitous - Analysis Error
    if ( dateNow >= dateTrigger && dateNow < times.DateStartCheck )
    {
      if ( LastShabatReminded is not null )
        return result;
      else
        LastShabatReminded = dateNow;
    }
    //#pragma warning restore S2589 // Boolean expressions should not be gratuitous
    else
      if ( LastShabatReminded is not null )
    {
      if ( dateNow > times.DateStart && LastShabatReminded < times.DateStart )
      {
        ShabatForm?.Close();
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
    if ( showbox ) ReminderForm.Run(row, TorahCelebrationDay.Shabat, times);
    return result;
  }

}
