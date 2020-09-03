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

    static public readonly TranslationsDictionary Today
      = new TranslationsDictionary
      {
        [Languages.EN] = "Today",
        [Languages.FR] = "Aujourd'hui"
      };

    static public readonly TranslationsDictionary NavigationDay
      = new TranslationsDictionary
      {
        [Languages.EN] = "Day #",
        [Languages.FR] = "Jour #"
      };

    static public readonly NullSafeDictionary<DayOfWeek, TranslationsDictionary> DayOfWeek
      = new NullSafeDictionary<DayOfWeek, TranslationsDictionary>()
      {
        [System.DayOfWeek.Monday] = new TranslationsDictionary
        {
          [Languages.EN] = "Monday",
          [Languages.FR] = "Lundi"
        },
        [System.DayOfWeek.Tuesday] = new TranslationsDictionary
        {
          [Languages.EN] = "Tuesday",
          [Languages.FR] = "Mardi"
        },
        [System.DayOfWeek.Wednesday] = new TranslationsDictionary
        {
          [Languages.EN] = "Wednesday",
          [Languages.FR] = "Mercredi"
        },
        [System.DayOfWeek.Thursday] = new TranslationsDictionary
        {
          [Languages.EN] = "Thursday",
          [Languages.FR] = "Jeudi"
        },
        [System.DayOfWeek.Friday] = new TranslationsDictionary
        {
          [Languages.EN] = "Friday",
          [Languages.FR] = "Vendredi"
        },
        [System.DayOfWeek.Saturday] = new TranslationsDictionary
        {
          [Languages.EN] = "Saturday",
          [Languages.FR] = "Samedi"
        },
        [System.DayOfWeek.Sunday] = new TranslationsDictionary
        {
          [Languages.EN] = "Sunday",
          [Languages.FR] = "Dimanche"
        }
      };

    static public readonly NullSafeDictionary<MoonPhase, TranslationsDictionary> MoonPhase
      = new NullSafeDictionary<MoonPhase, TranslationsDictionary>()
      {
        [HebrewCalendar.MoonPhase.New] = new TranslationsDictionary
        {
          [Languages.EN] = "New moon",
          [Languages.FR] = "Nouvelle lune"
        },
        [HebrewCalendar.MoonPhase.WaxingCrescent] = new TranslationsDictionary
        {
          [Languages.EN] = "Waxing crescent",
          [Languages.FR] = "Premier croissant"
        },
        [HebrewCalendar.MoonPhase.FirstQuarter] = new TranslationsDictionary
        {
          [Languages.EN] = "First quarter",
          [Languages.FR] = "Premier quartier"
        },
        [HebrewCalendar.MoonPhase.WaxingGibbous] = new TranslationsDictionary
        {
          [Languages.EN] = "Waxing gibbous",
          [Languages.FR] = "Gibbeuse croissante"
        },
        [HebrewCalendar.MoonPhase.Full] = new TranslationsDictionary
        {
          [Languages.EN] = "Full moon",
          [Languages.FR] = "Pleine lune"
        },
        [HebrewCalendar.MoonPhase.WaningGibbous] = new TranslationsDictionary
        {
          [Languages.EN] = "Waning gibbous",
          [Languages.FR] = "Gibbeuse décroissante"
        },
        [HebrewCalendar.MoonPhase.LastQuarter] = new TranslationsDictionary
        {
          [Languages.EN] = "Last quarter",
          [Languages.FR] = "Dernier quartier"
        },
        [HebrewCalendar.MoonPhase.WaningCrescent] = new TranslationsDictionary
        {
          [Languages.EN] = "Waning crescent",
          [Languages.FR] = "Dernier croissant"
        }
      };

    static public readonly NullSafeDictionary<Ephemeris, TranslationsDictionary> Ephemeris
      = new NullSafeDictionary<Ephemeris, TranslationsDictionary>()
      {
        [HebrewCalendar.Ephemeris.Rise] = new TranslationsDictionary
        {
          [Languages.EN] = "R: ",
          [Languages.FR] = "L: "
        },
        [HebrewCalendar.Ephemeris.Set] = new TranslationsDictionary
        {
          [Languages.EN] = "S: ",
          [Languages.FR] = "C: "
        },
        [HebrewCalendar.Ephemeris.SummerHour] = new TranslationsDictionary
        {
          [Languages.EN] = "(S)",
          [Languages.FR] = "(E)"
        },
        [HebrewCalendar.Ephemeris.WinterHour] = new TranslationsDictionary
        {
          [Languages.EN] = "(W)",
          [Languages.FR] = "(H)"
        }
      };

    static public readonly NullSafeDictionary<ReportFieldText, TranslationsDictionary> ReportFieldText
      = new NullSafeDictionary<ReportFieldText, TranslationsDictionary>()
      {
        [HebrewCalendar.ReportFieldText.Date] = new TranslationsDictionary
        {
          [Languages.EN] = "Date",
          [Languages.FR] = "Date"
        },
        [HebrewCalendar.ReportFieldText.Month] = new TranslationsDictionary
        {
          [Languages.EN] = "Month",
          [Languages.FR] = "Mois"
        },
        [HebrewCalendar.ReportFieldText.Sun] = new TranslationsDictionary
        {
          [Languages.EN] = "Sun",
          [Languages.FR] = "Soleil"
        },
        [HebrewCalendar.ReportFieldText.Moon] = new TranslationsDictionary
        {
          [Languages.EN] = "Moon",
          [Languages.FR] = "Lune"
        },
        [HebrewCalendar.ReportFieldText.Events] = new TranslationsDictionary
        {
          [Languages.EN] = "Events",
          [Languages.FR] = "Évènements"
        }
      };

    static public readonly NullSafeDictionary<SeasonChange, TranslationsDictionary> SeasonEvent
      = new NullSafeDictionary<SeasonChange, TranslationsDictionary>()
      {
        [SeasonChange.None] = new TranslationsDictionary
        {
          [Languages.EN] = "",
          [Languages.FR] = ""
        },
        [SeasonChange.SpringEquinox] = new TranslationsDictionary
        {
          [Languages.EN] = "Spring equinox",
          [Languages.FR] = "Equinoxe de printemps"
        },
        [SeasonChange.SummerSolstice] = new TranslationsDictionary
        {
          [Languages.EN] = "Summer solstice",
          [Languages.FR] = "Solstice d'été"
        },
        [SeasonChange.AutumnEquinox] = new TranslationsDictionary
        {
          [Languages.EN] = "Autumn equinox",
          [Languages.FR] = "Equinoxe d'automne"
        },
        [SeasonChange.WinterSolstice] = new TranslationsDictionary
        {
          [Languages.EN] = "Winter solstice",
          [Languages.FR] = "Solstice d'hiver"
        }
      };

    static public readonly NullSafeDictionary<TorahEvent, TranslationsDictionary> TorahEvent
      = new NullSafeDictionary<TorahEvent, TranslationsDictionary>()
      {
        [HebrewCalendar.TorahEvent.None] = new TranslationsDictionary
        {
          [Languages.EN] = "",
          [Languages.FR] = ""
        },
        [HebrewCalendar.TorahEvent.NewYearD1] = new TranslationsDictionary
        {
          [Languages.EN] = "New year",
          [Languages.FR] = "Début de l'année"
        },
        [HebrewCalendar.TorahEvent.NewYearD10] = new TranslationsDictionary
        {
          [Languages.EN] = "Set aside lamb",
          [Languages.FR] = "Réserver agneau"
        },
        [HebrewCalendar.TorahEvent.PessahD1] = new TranslationsDictionary
        {
          [Languages.EN] = "Pessa'h start",
          [Languages.FR] = "Début de Pessah"
        },
        [HebrewCalendar.TorahEvent.PessahD7] = new TranslationsDictionary
        {
          [Languages.EN] = "Pessa'h end",
          [Languages.FR] = "Fin de Pessah"
        },
        [HebrewCalendar.TorahEvent.ChavouotDiet] = new TranslationsDictionary
        {
          [Languages.EN] = "Chavouot diet",
          [Languages.FR] = "Régime de Chavouot"
        },
        [HebrewCalendar.TorahEvent.Chavouot1] = new TranslationsDictionary
        {
          [Languages.EN] = "Chavouot lamb",
          [Languages.FR] = "Agneau de Chavouot"
        },
        [HebrewCalendar.TorahEvent.Chavouot2] = new TranslationsDictionary
        {
          [Languages.EN] = "Chavouot end",
          [Languages.FR] = "Fin de Chavouot"
        },
        [HebrewCalendar.TorahEvent.YomTerouah] = new TranslationsDictionary
        {
          [Languages.EN] = "Yom Terou'ah",
          [Languages.FR] = "Yom Terou'ah"
        },
        [HebrewCalendar.TorahEvent.YomHaKipourim] = new TranslationsDictionary
        {
          [Languages.EN] = "Yom HaKipourim",
          [Languages.FR] = "Yom HaKipourim"
        },
        [HebrewCalendar.TorahEvent.SoukotD1] = new TranslationsDictionary
        {
          [Languages.EN] = "Soukot start",
          [Languages.FR] = "Début de Soukot"
        },
        [HebrewCalendar.TorahEvent.SoukotD8] = new TranslationsDictionary
        {
          [Languages.EN] = "Soukot end",
          [Languages.FR] = "Fin de Soukot"
        }
      };

  }

}
