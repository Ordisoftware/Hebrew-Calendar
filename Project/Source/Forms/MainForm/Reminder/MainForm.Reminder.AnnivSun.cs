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

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private void CheckAnniversarySun()
    {
      // TODO use anniversary form like shabat ?
      if ( RemindCelebrationDayForms.ContainsKey(TorahEvent.AnniversarySun) )
        if ( RemindCelebrationDayForms[TorahEvent.AnniversarySun] is not null )
          return;

      var dateBirth = BirthDate.Change(year: DateTime.Today.Year);
      var dateNow = DateTime.Now;
      string strDateNow = SQLiteDate.ToString(dateNow);
      var dateLimit = dateNow.AddDays((int)Settings.ReminderCelebrationsInterval);
      var row = ( from day in LunisolarDays
                   where !RemindCelebrationDates.Contains(day.Date)
                      && day.Date  >= dateNow
                      && day.Date == dateBirth
                      && day.Date <= dateLimit
                  select day ).FirstOrDefault();
      if ( row is null ) return;
      var times = CreateCelebrationTimes(row, Settings.RemindCelebrationEveryMinutes);
      if ( times is null ) return;
      RemindCelebrationDates.Add(row.Date); // TODO use anniversary date like shabat ?
      ReminderForm.Run(row, TorahEvent.AnniversarySun, times);
    }

  }

}
*/