/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public class DatesDiffItem
  {

    static private Dictionary<DateTime, Tuple<int, TimeSpan?>> Buffer
      = new Dictionary<DateTime, Tuple<int, TimeSpan?>>();

    static private Tuple<int, TimeSpan?> GetData(DateTime date)
    {
      Tuple<int, TimeSpan?> value = null;
      if ( !Buffer.ContainsKey(date) )
      {
        value = new Tuple<int, TimeSpan?>(AstronomyHelper.LunisolerCalendar.GetDayOfMonth(date),
                                          date.GetSunMoonEphemeris().Moonrise);
        Buffer.Add(date, value);
      }
      else
        value = Buffer[date];
      return value;
    }

    private DateTime Date1;
    private DateTime Date2;

    public int SolarDays { get; set; }
    public int SolarWeeks { get; set; }
    public int SolarMonths { get; set; }
    public int SolarYears { get; set; }
    public int MoonDays { get; set; }
    public int Lunations { get; set; }

    public DatesDiffItem(DateTime date1, DateTime date2)
    {
      SetDates(date1, date2);
    }

    public void SetDates(DateTime date1, DateTime date2)
    {
      if ( Date1 == date1 && Date2 == date2 ) return;
      if ( date1 > date2 )
      {
        var temp = date1;
        date1 = date2;
        date2 = date1;
      }
      Date1 = date1;
      Date2 = date2;
      Calculate();
    }

    private void Calculate()
    {
      try
      {
        var data = GetData(Date1);
        SolarDays = ( Date2 - Date1 ).Days + 1;
        SolarWeeks = (int)Math.Ceiling(SolarDays / 7d);
        SolarMonths = 1;
        SolarYears = 1;
        MoonDays = 0;
        Lunations = 1;
        if ( Date1.Day == 1 ) SolarMonths = 0;
        if ( Date1.Month == 1 && Date1.Day == 1 ) SolarYears = 0;
        if ( data.Item1 == 1 && data.Item2 != null ) Lunations = 0;
        for ( DateTime index = Date1; index <= Date2; index = index.AddDays(1) )
        {
          data = GetData(index);
          if ( index.Day == 1 ) SolarMonths++;
          if ( index.Month == 1 && index.Day == 1 ) SolarYears++;
          if ( data.Item2 == null ) continue;
          MoonDays++;
          if ( data.Item1 == 1 ) Lunations++;
        }
      }
      catch (Exception ex)
      {
        ex.Manage();
      }
    }

  }

}
