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
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static public readonly NullSafeOfStringDictionary<Language> Today
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Today",
        [Languages.FR] = "Aujourd'hui"
      };

    static public readonly NullSafeOfStringDictionary<Language> NavigationDay
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Day #",
        [Languages.FR] = "Jour #"
      };

    static public readonly NullSafeDictionary<DayOfWeek, NullSafeOfStringDictionary<Language>> DayOfWeek
      = new NullSafeDictionary<DayOfWeek, NullSafeOfStringDictionary<Language>>()
      {
        [System.DayOfWeek.Monday] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Monday",
          [Languages.FR] = "Lundi"
        },
        [System.DayOfWeek.Tuesday] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Tuesday",
          [Languages.FR] = "Mardi"
        },
        [System.DayOfWeek.Wednesday] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Wednesday",
          [Languages.FR] = "Mercredi"
        },
        [System.DayOfWeek.Thursday] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Thursday",
          [Languages.FR] = "Jeudi"
        },
        [System.DayOfWeek.Friday] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Friday",
          [Languages.FR] = "Vendredi"
        },
        [System.DayOfWeek.Saturday] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Saturday",
          [Languages.FR] = "Samedi"
        },
        [System.DayOfWeek.Sunday] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Sunday",
          [Languages.FR] = "Dimanche"
        }
      };

    static public readonly NullSafeDictionary<MoonPhase, NullSafeOfStringDictionary<Language>> MoonPhase
      = new NullSafeDictionary<MoonPhase, NullSafeOfStringDictionary<Language>>()
      {
        [HebrewCalendar.MoonPhase.New] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "New moon",
          [Languages.FR] = "Nouvelle lune"
        },
        [HebrewCalendar.MoonPhase.WaxingCrescent] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Waxing crescent",
          [Languages.FR] = "Premier croissant"
        },
        [HebrewCalendar.MoonPhase.FirstQuarter] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "First quarter",
          [Languages.FR] = "Premier quartier"
        },
        [HebrewCalendar.MoonPhase.WaxingGibbous] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Waxing gibbous",
          [Languages.FR] = "Gibbeuse croissante"
        },
        [HebrewCalendar.MoonPhase.Full] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Full moon",
          [Languages.FR] = "Pleine lune"
        },
        [HebrewCalendar.MoonPhase.WaningGibbous] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Waning gibbous",
          [Languages.FR] = "Gibbeuse décroissante"
        },
        [HebrewCalendar.MoonPhase.LastQuarter] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Last quarter",
          [Languages.FR] = "Dernier quartier"
        },
        [HebrewCalendar.MoonPhase.WaningCrescent] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Waning crescent",
          [Languages.FR] = "Dernier croissant"
        }
      };

    static public readonly NullSafeDictionary<Ephemeris, NullSafeOfStringDictionary<Language>> Ephemeris
      = new NullSafeDictionary<Ephemeris, NullSafeOfStringDictionary<Language>>()
      {
        [HebrewCalendar.Ephemeris.Rise] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "R: ",
          [Languages.FR] = "L: "
        },
        [HebrewCalendar.Ephemeris.Set] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "S: ",
          [Languages.FR] = "C: "
        },
        [HebrewCalendar.Ephemeris.SummerHour] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "(S)",
          [Languages.FR] = "(E)"
        },
        [HebrewCalendar.Ephemeris.WinterHour] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "(W)",
          [Languages.FR] = "(H)"
        }
      };

    static public readonly NullSafeDictionary<ReportFieldText, NullSafeOfStringDictionary<Language>> ReportFieldText
      = new NullSafeDictionary<ReportFieldText, NullSafeOfStringDictionary<Language>>()
      {
        [HebrewCalendar.ReportFieldText.Date] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Date",
          [Languages.FR] = "Date"
        },
        [HebrewCalendar.ReportFieldText.Month] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Month",
          [Languages.FR] = "Mois"
        },
        [HebrewCalendar.ReportFieldText.Sun] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Sun",
          [Languages.FR] = "Soleil"
        },
        [HebrewCalendar.ReportFieldText.Moon] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Moon",
          [Languages.FR] = "Lune"
        },
        [HebrewCalendar.ReportFieldText.Events] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Events",
          [Languages.FR] = "Évènements"
        }
      };

    static public readonly NullSafeDictionary<SeasonChange, NullSafeOfStringDictionary<Language>> SeasonEvent
      = new NullSafeDictionary<SeasonChange, NullSafeOfStringDictionary<Language>>()
      {
        [SeasonChange.None] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "",
          [Languages.FR] = ""
        },
        [SeasonChange.SpringEquinox] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Spring equinox",
          [Languages.FR] = "Equinoxe de printemps"
        },
        [SeasonChange.SummerSolstice] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Summer solstice",
          [Languages.FR] = "Solstice d'été"
        },
        [SeasonChange.AutumnEquinox] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Autumn equinox",
          [Languages.FR] = "Equinoxe d'automne"
        },
        [SeasonChange.WinterSolstice] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Winter solstice",
          [Languages.FR] = "Solstice d'hiver"
        }
      };

    static public readonly NullSafeDictionary<TorahEvent, NullSafeOfStringDictionary<Language>> TorahEvent
      = new NullSafeDictionary<TorahEvent, NullSafeOfStringDictionary<Language>>()
      {
        [HebrewCalendar.TorahEvent.None] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "",
          [Languages.FR] = ""
        },
        [HebrewCalendar.TorahEvent.NewYearD1] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "New year",
          [Languages.FR] = "Début de l'année"
        },
        [HebrewCalendar.TorahEvent.NewYearD10] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Set aside lamb",
          [Languages.FR] = "Réserver agneau"
        },
        [HebrewCalendar.TorahEvent.PessahD1] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Pessa'h start",
          [Languages.FR] = "Début de Pessah"
        },
        [HebrewCalendar.TorahEvent.PessahD7] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Pessa'h end",
          [Languages.FR] = "Fin de Pessah"
        },
        [HebrewCalendar.TorahEvent.ChavouotDiet] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Chavouot diet",
          [Languages.FR] = "Régime de Chavouot"
        },
        [HebrewCalendar.TorahEvent.Chavouot1] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Chavouot lamb",
          [Languages.FR] = "Agneau de Chavouot"
        },
        [HebrewCalendar.TorahEvent.Chavouot2] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Chavouot end",
          [Languages.FR] = "Fin de Chavouot"
        },
        [HebrewCalendar.TorahEvent.YomTerouah] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Yom Terou'ah",
          [Languages.FR] = "Yom Terou'ah"
        },
        [HebrewCalendar.TorahEvent.YomHaKipourim] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Yom HaKipourim",
          [Languages.FR] = "Yom HaKipourim"
        },
        [HebrewCalendar.TorahEvent.SoukotD1] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Soukot start",
          [Languages.FR] = "Début de Soukot"
        },
        [HebrewCalendar.TorahEvent.SoukotD8] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Soukot end",
          [Languages.FR] = "Fin de Soukot"
        }
      };

  }

}
