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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public class DatesDiffItem
  {

    public int SolarDays { get; set; }
    public int SolarWeeks { get; set; }
    public int SolarMonths { get; set; } = 1;
    public int SolarYears { get; set; } = 1;
    public int MoonDays { get; set; } = 0;
    public int Lunations { get; set; } = 1;
    //public int MoonYears { get; set; } = 1;

    public DateTime? DateStart => _Dates?.Item1 ?? null;
    public DateTime? DateEnd => _Dates?.Item2 ?? null;

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

    public DatesDiffItem(DateTime date1, DateTime date2)
    {
      Dates = new Tuple<DateTime, DateTime>(date1, date2);
    }

    private void Calculate()
    {
      try
      {
        SolarDays = ( _Dates.Item2 - _Dates.Item1 ).Days + 1;
        SolarWeeks = (int)Math.Ceiling(SolarDays / 7d);
        if ( _Dates.Item1.Day == 1 ) SolarMonths = 0;
        if ( _Dates.Item1.Month == 1 && _Dates.Item1.Day == 1 ) SolarYears = 0;
        if ( AstronomyHelper.LunisolerCalendar.GetDayOfMonth(_Dates.Item1) == 1 )
        {
          MoonDays = 0;
          Lunations = 0;
        }
        for ( DateTime index = _Dates.Item1; index <= _Dates.Item2; index = index.AddDays(1) )
        {
          if ( index.Day == 1 ) SolarMonths++;
          if ( _Dates.Item1.Month == 1 && _Dates.Item1.Day != 1 ) SolarYears++;
          int day = AstronomyHelper.LunisolerCalendar.GetDayOfMonth(index);
          var ephemeris = index.GetSunMoonEphemeris();
          if ( ephemeris.Moonrise == null ) continue;
          MoonDays++;
          if ( day == 1 ) Lunations++;
        }
      }
      catch (Exception ex)
      {
        ex.Manage();
      }
    }

  }

}
