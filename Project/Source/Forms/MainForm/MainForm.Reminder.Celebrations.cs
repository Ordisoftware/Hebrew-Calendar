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

    private void CheckEvents()
    {
      try
      {
        var dateStart = DateTime.Today;
        var dateEnd = dateStart.AddDays(Program.Settings.ReminderInterval);
        var row = ( from day in LunisolarCalendar.LunisolarDays
                    where SQLiteUtility.GetDate(day.Date) >= dateStart
                       && SQLiteUtility.GetDate(day.Date) <= dateEnd
                       && check((TorahEventType)day.TorahEvents)
                       && !Reminded.Contains(day.Date)
                    select day ).FirstOrDefault() as Data.LunisolarCalendar.LunisolarDaysRow;
        if ( row == null ) return;
        Reminded.Add(row.Date);
        var rowPrevious = LunisolarCalendar.LunisolarDays.FindByDate(SQLiteUtility.GetDate(SQLiteUtility.GetDate(row.Date).AddDays(-1)));
        ReminderForm.Run(row, false, rowPrevious.Sunset, row.Sunset);
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

  }

}
