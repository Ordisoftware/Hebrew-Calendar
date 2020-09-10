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

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class AppTranslations
  {

    static public readonly TranslationsDictionary Today
      = new TranslationsDictionary
      {
        [Language.EN] = "Today",
        [Language.FR] = "Aujourd'hui"
      };

    static public readonly TranslationsDictionary NavigationDay
      = new TranslationsDictionary
      {
        [Language.EN] = "Day #",
        [Language.FR] = "Jour #"
      };

    static public readonly NullSafeDictionary<DayOfWeek, TranslationsDictionary> DayOfWeek
      = new NullSafeDictionary<DayOfWeek, TranslationsDictionary>()
      {
        [System.DayOfWeek.Monday] = new TranslationsDictionary
        {
          [Language.EN] = "Monday",
          [Language.FR] = "Lundi"
        },
        [System.DayOfWeek.Tuesday] = new TranslationsDictionary
        {
          [Language.EN] = "Tuesday",
          [Language.FR] = "Mardi"
        },
        [System.DayOfWeek.Wednesday] = new TranslationsDictionary
        {
          [Language.EN] = "Wednesday",
          [Language.FR] = "Mercredi"
        },
        [System.DayOfWeek.Thursday] = new TranslationsDictionary
        {
          [Language.EN] = "Thursday",
          [Language.FR] = "Jeudi"
        },
        [System.DayOfWeek.Friday] = new TranslationsDictionary
        {
          [Language.EN] = "Friday",
          [Language.FR] = "Vendredi"
        },
        [System.DayOfWeek.Saturday] = new TranslationsDictionary
        {
          [Language.EN] = "Saturday",
          [Language.FR] = "Samedi"
        },
        [System.DayOfWeek.Sunday] = new TranslationsDictionary
        {
          [Language.EN] = "Sunday",
          [Language.FR] = "Dimanche"
        }
      };

    static public readonly NullSafeDictionary<MoonPhase, TranslationsDictionary> MoonPhase
      = new NullSafeDictionary<MoonPhase, TranslationsDictionary>()
      {
        [Calendar.MoonPhase.New] = new TranslationsDictionary
        {
          [Language.EN] = "New moon",
          [Language.FR] = "Nouvelle lune"
        },
        [Calendar.MoonPhase.WaxingCrescent] = new TranslationsDictionary
        {
          [Language.EN] = "Waxing crescent",
          [Language.FR] = "Premier croissant"
        },
        [Calendar.MoonPhase.FirstQuarter] = new TranslationsDictionary
        {
          [Language.EN] = "First quarter",
          [Language.FR] = "Premier quartier"
        },
        [Calendar.MoonPhase.WaxingGibbous] = new TranslationsDictionary
        {
          [Language.EN] = "Waxing gibbous",
          [Language.FR] = "Gibbeuse croissante"
        },
        [Calendar.MoonPhase.Full] = new TranslationsDictionary
        {
          [Language.EN] = "Full moon",
          [Language.FR] = "Pleine lune"
        },
        [Calendar.MoonPhase.WaningGibbous] = new TranslationsDictionary
        {
          [Language.EN] = "Waning gibbous",
          [Language.FR] = "Gibbeuse décroissante"
        },
        [Calendar.MoonPhase.LastQuarter] = new TranslationsDictionary
        {
          [Language.EN] = "Last quarter",
          [Language.FR] = "Dernier quartier"
        },
        [Calendar.MoonPhase.WaningCrescent] = new TranslationsDictionary
        {
          [Language.EN] = "Waning crescent",
          [Language.FR] = "Dernier croissant"
        }
      };

    static public readonly NullSafeDictionary<Ephemeris, TranslationsDictionary> Ephemeris
      = new NullSafeDictionary<Ephemeris, TranslationsDictionary>()
      {
        [Calendar.Ephemeris.Rise] = new TranslationsDictionary
        {
          [Language.EN] = "R: ",
          [Language.FR] = "L: "
        },
        [Calendar.Ephemeris.Set] = new TranslationsDictionary
        {
          [Language.EN] = "S: ",
          [Language.FR] = "C: "
        },
        [Calendar.Ephemeris.SummerHour] = new TranslationsDictionary
        {
          [Language.EN] = "(S)",
          [Language.FR] = "(E)"
        },
        [Calendar.Ephemeris.WinterHour] = new TranslationsDictionary
        {
          [Language.EN] = "(W)",
          [Language.FR] = "(H)"
        }
      };

    static public readonly NullSafeDictionary<ReportFieldText, TranslationsDictionary> ReportFieldText
      = new NullSafeDictionary<ReportFieldText, TranslationsDictionary>()
      {
        [Calendar.ReportFieldText.Date] = new TranslationsDictionary
        {
          [Language.EN] = "Date",
          [Language.FR] = "Date"
        },
        [Calendar.ReportFieldText.Month] = new TranslationsDictionary
        {
          [Language.EN] = "Month",
          [Language.FR] = "Mois"
        },
        [Calendar.ReportFieldText.Sun] = new TranslationsDictionary
        {
          [Language.EN] = "Sun",
          [Language.FR] = "Soleil"
        },
        [Calendar.ReportFieldText.Moon] = new TranslationsDictionary
        {
          [Language.EN] = "Moon",
          [Language.FR] = "Lune"
        },
        [Calendar.ReportFieldText.Events] = new TranslationsDictionary
        {
          [Language.EN] = "Events",
          [Language.FR] = "Évènements"
        }
      };

    static public readonly NullSafeDictionary<SeasonChange, TranslationsDictionary> SeasonEvent
      = new NullSafeDictionary<SeasonChange, TranslationsDictionary>()
      {
        [SeasonChange.None] = new TranslationsDictionary
        {
          [Language.EN] = "",
          [Language.FR] = ""
        },
        [SeasonChange.SpringEquinox] = new TranslationsDictionary
        {
          [Language.EN] = "Spring equinox",
          [Language.FR] = "Equinoxe de printemps"
        },
        [SeasonChange.SummerSolstice] = new TranslationsDictionary
        {
          [Language.EN] = "Summer solstice",
          [Language.FR] = "Solstice d'été"
        },
        [SeasonChange.AutumnEquinox] = new TranslationsDictionary
        {
          [Language.EN] = "Autumn equinox",
          [Language.FR] = "Equinoxe d'automne"
        },
        [SeasonChange.WinterSolstice] = new TranslationsDictionary
        {
          [Language.EN] = "Winter solstice",
          [Language.FR] = "Solstice d'hiver"
        }
      };

    static public readonly NullSafeDictionary<TorahEvent, TranslationsDictionary> TorahEvent
      = new NullSafeDictionary<TorahEvent, TranslationsDictionary>()
      {
        [Calendar.TorahEvent.None] = new TranslationsDictionary
        {
          [Language.EN] = "",
          [Language.FR] = ""
        },
        [Calendar.TorahEvent.NewYearD1] = new TranslationsDictionary
        {
          [Language.EN] = "New year",
          [Language.FR] = "Début de l'année"
        },
        [Calendar.TorahEvent.NewYearD10] = new TranslationsDictionary
        {
          [Language.EN] = "Set aside lamb",
          [Language.FR] = "Réserver agneau"
        },
        [Calendar.TorahEvent.PessahD1] = new TranslationsDictionary
        {
          [Language.EN] = "Pessa'h start",
          [Language.FR] = "Début de Pessah"
        },
        [Calendar.TorahEvent.PessahD7] = new TranslationsDictionary
        {
          [Language.EN] = "Pessa'h end",
          [Language.FR] = "Fin de Pessah"
        },
        [Calendar.TorahEvent.ChavouotDiet] = new TranslationsDictionary
        {
          [Language.EN] = "Chavouot diet",
          [Language.FR] = "Régime de Chavouot"
        },
        [Calendar.TorahEvent.Chavouot1] = new TranslationsDictionary
        {
          [Language.EN] = "Chavouot lamb",
          [Language.FR] = "Agneau de Chavouot"
        },
        [Calendar.TorahEvent.Chavouot2] = new TranslationsDictionary
        {
          [Language.EN] = "Chavouot end",
          [Language.FR] = "Fin de Chavouot"
        },
        [Calendar.TorahEvent.YomTerouah] = new TranslationsDictionary
        {
          [Language.EN] = "Yom Terou'ah",
          [Language.FR] = "Yom Terou'ah"
        },
        [Calendar.TorahEvent.YomHaKipourim] = new TranslationsDictionary
        {
          [Language.EN] = "Yom HaKipourim",
          [Language.FR] = "Yom HaKipourim"
        },
        [Calendar.TorahEvent.SoukotD1] = new TranslationsDictionary
        {
          [Language.EN] = "Soukot start",
          [Language.FR] = "Début de Soukot"
        },
        [Calendar.TorahEvent.SoukotD8] = new TranslationsDictionary
        {
          [Language.EN] = "Soukot end",
          [Language.FR] = "Fin de Soukot"
        }
      };

  }

}
