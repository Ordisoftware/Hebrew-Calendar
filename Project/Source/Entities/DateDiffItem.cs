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
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public class DatesDiffItem
  {

    public int SolarDays { get; set; }
    public int SolarWeeks { get; set; }
    public int SolarMonths { get; set; }
    public int SolarYears { get; set; }
    public int MoonDays { get; set; }
    public int Lunations { get; set; }

    public Tuple<DateTime, DateTime> Dates
    {
      get { return _Dates; }
      set
      {
        if ( _Dates == value ) return;
        _Dates = value.Item1 < value.Item2 
               ? value 
               : new Tuple<DateTime, DateTime>(value.Item2, value.Item1);
        Calculate();
      }
    }
    private Tuple<DateTime, DateTime> _Dates;

    public DatesDiffItem(Tuple<DateTime, DateTime> dates)
    {
      Dates = dates;
    }

    private void Calculate()
    {
      try
      {
        var date1 = _Dates.Item1;
        var date2 = _Dates.Item2;
        var ephemeris = date1.GetSunMoonEphemeris();
        SolarDays = ( date2 - date1 ).Days + 1;
        SolarWeeks = (int)Math.Ceiling(SolarDays / 7d);
        SolarMonths = 1;
        SolarYears = 1;
        MoonDays = 0;
        Lunations = 1;
        if ( date1.Day == 1 )
          SolarMonths = 0;
        if ( date1.Month == 1 && date1.Day == 1 )
          SolarYears = 0;
        if ( ephemeris.Moonrise != null && AstronomyHelper.LunisolerCalendar.GetDayOfMonth(date1) == 1 )
          Lunations = 0;
        for ( DateTime index = date1; index <= date2; index = index.AddDays(1) )
        {
          if ( index.Day == 1 ) SolarMonths++;
          if ( index.Month == 1 && index.Day == 1 ) SolarYears++;
          ephemeris = index.GetSunMoonEphemeris();
          if ( ephemeris.Moonrise == null ) continue;
          MoonDays++;
          if ( AstronomyHelper.LunisolerCalendar.GetDayOfMonth(index) == 1 )
            Lunations++;
        }
      }
      catch (Exception ex)
      {
        ex.Manage();
      }
    }

  }

}
