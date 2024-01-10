/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-12 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase : SQLiteDatabase
{

  public void LoadCelebrations(DataTable table, int year1, int year2, bool useRealDay)
  {
    table.Rows.Clear();
    var query = from day in LunisolarDays
                where day.HasTorahEvent && day.Date.Year >= year1 && day.Date.Year <= year2
                select new
                {
                  date = day.GetEventStartDateTime(useRealDay, false),
                  torah = day.TorahEvent
                };
    foreach ( var item in query )
    {
      var row = table.Rows.Find(item.date.Year);
      if ( row is not null )
        row[(int)item.torah] = item.date;
      else
      {
        row = table.NewRow();
        row[0] = item.date.Year;
        row[(int)item.torah] = item.date;
        table.Rows.Add(row);
      }
    }
    table.AcceptChanges();
  }

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  public void LoadNewMoons(DataTable table, int year1, int year2, bool useRealDay)
  {
    table.Rows.Clear();
    var query = from day in LunisolarDays
                where day.LunarDay == 1
                   && day.Date.Year >= year1
                   && day.Date.Year <= year2 + 1
                select new
                {
                  date = day.GetEventStartDateTime(useRealDay, true),
                  month = day.LunarMonth
                };
    int year = year1 - 1;
    foreach ( var item in query )
    {
      if ( item.month == 1 )
      {
        year++;
        if ( year > year2 ) break;
      }
      if ( year < year1 ) continue;
      var row = table.Rows.Find(year);
      if ( row is not null )
        row[item.month] = item.date;
      else
      if ( item.month > 0 )
      {
        row = table.NewRow();
        row[0] = year;
        row[item.month] = item.date;
        table.Rows.Add(row);
      }
    }
    table.AcceptChanges();
  }
}
