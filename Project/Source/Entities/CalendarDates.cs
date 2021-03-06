﻿/// <license>
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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections;
using System.Collections.Generic;
using AASharp;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide date item read only dictionary wher items are initialized each time a date is not present.
  /// </summary>
  partial class CalendarDates : IReadOnlyDictionary<DateTime, CalendarDateItem>
  {

    static public readonly CalendarDates Instance = new CalendarDates();

    static private readonly Dictionary<int, SortedDictionary<DateTime, SeasonChange>> TorahSeasons
      = new Dictionary<int, SortedDictionary<DateTime, SeasonChange>>();

    static private readonly SortedDictionary<DateTime, CalendarDateItem> Items
      = new SortedDictionary<DateTime, CalendarDateItem>();

    public int Count
      => Items.Keys.Count;

    public IEnumerable<DateTime> Keys
      => Items.Keys;

    public IEnumerable<CalendarDateItem> Values
      => Items.Values;

    public bool ContainsKey(DateTime key)
    {
      return Items.ContainsKey(key);
    }

    public IEnumerator<KeyValuePair<DateTime, CalendarDateItem>> GetEnumerator()
    {
      return Items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return Items.GetEnumerator();
    }

    public bool TryGetValue(DateTime key, out CalendarDateItem value)
    {
      return Items.TryGetValue(key, out value);
    }

    public void Clear()
    {
      TorahSeasons.Clear();
      Items.Clear();
    }

    public CalendarDateItem this[DateTime key]
    {
      get
      {
        if ( Items.ContainsKey(key) ) return Items[key];
        CalendarDateItem value = new CalendarDateItem
        {
          Date = key,
          MoonDay = AstronomyHelper.LunisolerCalendar.GetDayOfMonth(key),
          MoonPhase = key.GetMoonPhase(),
          Ephemerisis = key.GetSunMoonEphemeris()
        };
        if ( !TorahSeasons.ContainsKey(key.Year) )
          InitializeSeasons(key.Year);
        if ( TorahSeasons[key.Year].ContainsKey(key) )
          value.TorahSeasonChange = TorahSeasons[key.Year][key];
        value.RealSeasonChange = value.TorahSeasonChange;
        if ( value.TorahSeasonChange != SeasonChange.None
          && MainForm.Instance.CurrentGPSLatitude < 0
          && !Program.Settings.TorahEventsCountAsMoon )
          switch ( value.TorahSeasonChange )
          {
            case SeasonChange.SpringEquinox:
              value.RealSeasonChange = SeasonChange.AutumnEquinox;
              break;
            case SeasonChange.AutumnEquinox:
              value.RealSeasonChange = SeasonChange.SpringEquinox;
              break;
            case SeasonChange.WinterSolstice:
              value.RealSeasonChange = SeasonChange.SummerSolstice;
              break;
            case SeasonChange.SummerSolstice:
              value.RealSeasonChange = SeasonChange.WinterSolstice;
              break;
          }
        Items.Add(key, value);
        return value;
      }
    }

    private void InitializeSeasons(int year)
    {
      if ( !TorahSeasons.ContainsKey(year) )
        TorahSeasons.Add(year, new SortedDictionary<DateTime, SeasonChange>());
      var aasdate = new AASDate();
      long jdYear = 0, jdMonth = 0, jdDay = 0, jdHour = 0, jdMinute = 0;
      double second = 0;
      void set(SeasonChange season, Func<long, bool, double> action)
      {
        aasdate.Set(action(year, true), true);
        aasdate.Get(ref jdYear, ref jdMonth, ref jdDay, ref jdHour, ref jdMinute, ref second);
        var date = new DateTime((int)jdYear, (int)jdMonth, (int)jdDay, 0, 0, 0);
        TorahSeasons[year].Add(date.Date, season);
      }
      if ( MainForm.Instance.CurrentGPSLatitude >= 0 || !Program.Settings.TorahEventsCountAsMoon )
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
    }

    private CalendarDates()
    {
    }

  }

}
