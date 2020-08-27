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
using System.Collections.Generic;
using AASharp;

namespace Ordisoftware.HebrewCalendar
{

  static public class Dates
  {

    static private Dictionary<DateTime, DateItem> Items
      = new Dictionary<DateTime, DateItem>();

    static public int Count => Items.Keys.Count;

    static public void Clear() => Items.Clear();

    static public DateItem Get(DateTime date)
    {
      if ( Items.ContainsKey(date) ) return Items[date];
      DateItem value = new DateItem
      {
        DayOfMonth = AstronomyHelper.LunisolerCalendar.GetDayOfMonth(date),
        MoonRise = date.GetSunMoonEphemeris().Moonrise,
        MonthOfYear = AstronomyHelper.LunisolerCalendar.GetMonth(date)
      };
      var aasdate = new AASDate();
      long jdYear = 0, jdMonth = 0, jdDay = 0, jdHour = 0, jdMinute = 0;
      double second = 0;
      void set(SeasonChange season, Func<long, bool, double> action)
      {
        aasdate.Set(action(date.Year, true), true);
        aasdate.Get(ref jdYear, ref jdMonth, ref jdDay, ref jdHour, ref jdMinute, ref second);
        var dateJulian = new DateTime((int)jdYear, (int)jdMonth, (int)jdDay, 0, 0, 0);
        if ( date.Date == dateJulian.Date ) value.SeasonChange = season;
      }
      var lat = MainForm.Instance.CurrentGPSLatitude;
      if ( lat >= 0 || !Program.Settings.TorahEventsCountAsMoon )
      {
        set(SeasonChange.SpringEquinox, AASEquinoxesAndSolstices.NorthwardEquinox);
        set(SeasonChange.SummerSolstice, AASEquinoxesAndSolstices.NorthernSolstice);
        set(SeasonChange.AutumnEquinox, AASEquinoxesAndSolstices.SouthwardEquinox);
        set(SeasonChange.WinterSolstice, AASEquinoxesAndSolstices.SouthernSolstice);
      }
      else
      {
        set(SeasonChange.SpringEquinox, AASEquinoxesAndSolstices.SouthwardEquinox);
        set(SeasonChange.SummerSolstice, AASEquinoxesAndSolstices.SouthernSolstice);
        set(SeasonChange.AutumnEquinox, AASEquinoxesAndSolstices.NorthwardEquinox);
        set(SeasonChange.WinterSolstice, AASEquinoxesAndSolstices.NorthernSolstice);
      }
      if ( lat < 0 && !Program.Settings.TorahEventsCountAsMoon )
      {
        if ( value.SeasonChange == SeasonChange.SpringEquinox )
          value.SeasonChange = SeasonChange.AutumnEquinox;
        else
        if ( value.SeasonChange == SeasonChange.AutumnEquinox )
          value.SeasonChange = SeasonChange.SpringEquinox;
        else
        if ( value.SeasonChange == SeasonChange.WinterSolstice )
          value.SeasonChange = SeasonChange.SummerSolstice;
        else
        if ( value.SeasonChange == SeasonChange.SummerSolstice )
          value.SeasonChange = SeasonChange.WinterSolstice;
      }
      Items.Add(date, value);
      return value;
    }

  }

}
