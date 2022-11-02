/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using AASharp;

/// <summary>
/// Provides date item read only dictionary wher items are initialized each time a date is not present.
/// </summary>
class CalendarDates : IReadOnlyDictionary<DateTime, CalendarDateItem>
{

  static public readonly CalendarDates Instance = new();

  static private readonly Dictionary<int, SortedDictionary<DateTime, SeasonChange>> TorahSeasons = new();

  static private readonly SortedDictionary<DateTime, CalendarDateItem> Items = new();

  public int Count
    => Items.Keys.Count;

  public IEnumerable<DateTime> Keys
    => Items.Keys;

  public IEnumerable<CalendarDateItem> Values
    => Items.Values;

  public bool ContainsKey(DateTime key)
    => Items.ContainsKey(key);

  public IEnumerator<KeyValuePair<DateTime, CalendarDateItem>> GetEnumerator()
    => Items.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator()
    => Items.GetEnumerator();

  public bool TryGetValue(DateTime key, out CalendarDateItem value)
    => Items.TryGetValue(key, out value);

  public void Clear()
  {
    TorahSeasons.Clear();
    Items.Clear();
  }

  public CalendarDateItem this[DateTime key]
  {
    get
    {
      if ( Items.TryGetValue(key, out var value) ) return value;
      value = new CalendarDateItem
      {
        Date = key,
        MoonDay = AstronomyHelper.LunisolerCalendar.GetDayOfMonth(key),
        MoonPhase = key.GetMoonPhase(),
        Ephemeris = key.GetSunMoonEphemeris()
      };
      if ( !TorahSeasons.ContainsKey(key.Year) )
        InitializeSeasons(key.Year);
      if ( TorahSeasons[key.Year].TryGetValue(key, out var season) )
        value.TorahSeasonChange = season;
      value.RealSeasonChange = value.TorahSeasonChange;
      if ( value.TorahSeasonChange != SeasonChange.None
        && MainForm.Instance.CurrentGPSLatitude < 0
        && !Program.Settings.TorahEventsCountAsMoon )
        value.RealSeasonChange = value.TorahSeasonChange switch
        {
          SeasonChange.SpringEquinox => SeasonChange.AutumnEquinox,
          SeasonChange.AutumnEquinox => SeasonChange.SpringEquinox,
          SeasonChange.WinterSolstice => SeasonChange.SummerSolstice,
          SeasonChange.SummerSolstice => SeasonChange.WinterSolstice,
          _ => throw new AdvNotImplementedException(value.TorahSeasonChange),
        };
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
