/// <license>
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
/// <edited> 2021-09 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static partial class AppTranslations
  {

    static public readonly TranslationsDictionary Sunrise
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} Sunrise",
        [Language.FR] = "{0} Lever du soleil"
      };

    static public readonly TranslationsDictionary Sunset
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} Sunset",
        [Language.FR] = "{0} Coucher du soleil"
      };

    static public readonly TranslationsDictionary Moonrise
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} Moonrise",
        [Language.FR] = "{0} Lever de la lune"
      };

    static public readonly TranslationsDictionary Moonset
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} Moonset",
        [Language.FR] = "{0} Coucher de la lune"
      };

    static public readonly TranslationsDictionary Today
      = new TranslationsDictionary
      {
        [Language.EN] = "Today",
        [Language.FR] = "Aujourd'hui"
      };

    static public readonly TranslationsDictionary Shabat
      = new TranslationsDictionary
      {
        [Language.EN] = "Shabat",
        [Language.FR] = "Shabat"
      };

    static public readonly TranslationsDictionary NavigationMonth
      = new TranslationsDictionary
      {
        [Language.EN] = "Month No. {0}",
        [Language.FR] = "Mois n°{0}"
      };

    static public readonly TranslationsDictionary NavigationDay
      = new TranslationsDictionary
      {
        [Language.EN] = "Day No. {0}",
        [Language.FR] = "Jour n°{0}"
      };

    static public readonly NullSafeDictionary<DayOfWeek, TranslationsDictionary> DaysOfWeek
      = new NullSafeDictionary<DayOfWeek, TranslationsDictionary>
      {
        [DayOfWeek.Monday] = new TranslationsDictionary
        {
          [Language.EN] = "Monday",
          [Language.FR] = "Lundi"
        },
        [DayOfWeek.Tuesday] = new TranslationsDictionary
        {
          [Language.EN] = "Tuesday",
          [Language.FR] = "Mardi"
        },
        [DayOfWeek.Wednesday] = new TranslationsDictionary
        {
          [Language.EN] = "Wednesday",
          [Language.FR] = "Mercredi"
        },
        [DayOfWeek.Thursday] = new TranslationsDictionary
        {
          [Language.EN] = "Thursday",
          [Language.FR] = "Jeudi"
        },
        [DayOfWeek.Friday] = new TranslationsDictionary
        {
          [Language.EN] = "Friday",
          [Language.FR] = "Vendredi"
        },
        [DayOfWeek.Saturday] = new TranslationsDictionary
        {
          [Language.EN] = "Saturday",
          [Language.FR] = "Samedi"
        },
        [DayOfWeek.Sunday] = new TranslationsDictionary
        {
          [Language.EN] = "Sunday",
          [Language.FR] = "Dimanche"
        }
      };

    static public readonly NullSafeDictionary<MoonriseOccuring, TranslationsDictionary> MoonriseOccurings
      = new NullSafeDictionary<MoonriseOccuring, TranslationsDictionary>
      {
        [MoonriseOccuring.AfterSet] = new TranslationsDictionary
        {
          [Language.EN] = "After the set",
          [Language.FR] = "Après le lever"
        },
        [MoonriseOccuring.BeforeSet] = new TranslationsDictionary
        {
          [Language.EN] = "Before the set",
          [Language.FR] = "Avant le lever"
        },
        [MoonriseOccuring.NextDay] = new TranslationsDictionary
        {
          [Language.EN] = "The next day",
          [Language.FR] = "Le jour d'après"
        },
      };

    static public readonly NullSafeDictionary<MoonPhase, TranslationsDictionary> MoonPhases
      = new NullSafeDictionary<MoonPhase, TranslationsDictionary>
      {
        [MoonPhase.New] = new TranslationsDictionary
        {
          [Language.EN] = "New moon",
          [Language.FR] = "Nouvelle lune"
        },
        [MoonPhase.WaxingCrescent] = new TranslationsDictionary
        {
          [Language.EN] = "Waxing crescent",
          [Language.FR] = "Premier croissant"
        },
        [MoonPhase.FirstQuarter] = new TranslationsDictionary
        {
          [Language.EN] = "First quarter",
          [Language.FR] = "Premier quartier"
        },
        [MoonPhase.WaxingGibbous] = new TranslationsDictionary
        {
          [Language.EN] = "Waxing gibbous",
          [Language.FR] = "Gibbeuse croissante"
        },
        [MoonPhase.Full] = new TranslationsDictionary
        {
          [Language.EN] = "Full moon",
          [Language.FR] = "Pleine lune"
        },
        [MoonPhase.WaningGibbous] = new TranslationsDictionary
        {
          [Language.EN] = "Waning gibbous",
          [Language.FR] = "Gibbeuse décroissante"
        },
        [MoonPhase.LastQuarter] = new TranslationsDictionary
        {
          [Language.EN] = "Last quarter",
          [Language.FR] = "Dernier quartier"
        },
        [MoonPhase.WaningCrescent] = new TranslationsDictionary
        {
          [Language.EN] = "Waning crescent",
          [Language.FR] = "Dernier croissant"
        }
      };

    static public readonly NullSafeDictionary<Ephemeris, TranslationsDictionary> EphemerisCodes
      = new NullSafeDictionary<Ephemeris, TranslationsDictionary>
      {
        [Ephemeris.Rise] = new TranslationsDictionary
        {
          [Language.EN] = "R: ",
          [Language.FR] = "L: "
        },
        [Ephemeris.Set] = new TranslationsDictionary
        {
          [Language.EN] = "S: ",
          [Language.FR] = "C: "
        },
        [Ephemeris.SummerHour] = new TranslationsDictionary
        {
          [Language.EN] = "(S)",
          [Language.FR] = "(E)"
        },
        [Ephemeris.WinterHour] = new TranslationsDictionary
        {
          [Language.EN] = "(W)",
          [Language.FR] = "(H)"
        }
      };

    static public readonly NullSafeDictionary<ReportFieldText, TranslationsDictionary> ReportFields
      = new NullSafeDictionary<ReportFieldText, TranslationsDictionary>
      {
        [ReportFieldText.Date] = new TranslationsDictionary
        {
          [Language.EN] = "Date",
          [Language.FR] = "Date"
        },
        [ReportFieldText.Month] = new TranslationsDictionary
        {
          [Language.EN] = "Month",
          [Language.FR] = "Mois"
        },
        [ReportFieldText.Sun] = new TranslationsDictionary
        {
          [Language.EN] = "Sun",
          [Language.FR] = "Soleil"
        },
        [ReportFieldText.Moon] = new TranslationsDictionary
        {
          [Language.EN] = "Moon",
          [Language.FR] = "Lune"
        },
        [ReportFieldText.Events] = new TranslationsDictionary
        {
          [Language.EN] = "Events",
          [Language.FR] = "Évènements"
        }
      };

    static public readonly NullSafeDictionary<SeasonChange, TranslationsDictionary> SeasonChanges
      = new NullSafeDictionary<SeasonChange, TranslationsDictionary>
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

    static public readonly NullSafeDictionary<TorahCelebration, TranslationsDictionary> TorahCelebrations
      = new NullSafeDictionary<TorahCelebration, TranslationsDictionary>
      {
        [TorahCelebration.Pessah] = new TranslationsDictionary
        {
          [Language.EN] = "Pesach",
          [Language.FR] = "Pessa'h"
        },
        [TorahCelebration.Chavouot] = new TranslationsDictionary
        {
          [Language.EN] = "Shavu'ot",
          [Language.FR] = "Shavou'ot"
        },
        [TorahCelebration.YomTerouah] = new TranslationsDictionary
        {
          [Language.EN] = "Yom Teru'ah",
          [Language.FR] = "Yom Terou'ah"
        },
        [TorahCelebration.YomHaKipourim] = new TranslationsDictionary
        {
          [Language.EN] = "Yom HaKipurim",
          [Language.FR] = "Yom HaKipourim"
        },
        [TorahCelebration.Soukot] = new TranslationsDictionary
        {
          [Language.EN] = "Sukot",
          [Language.FR] = "Soukot"
        }
      };

    static public readonly TranslationsDictionary PessahDay
      = new TranslationsDictionary
      {
        [Language.EN] = TorahCelebrations[TorahCelebration.Pessah][Language.EN] + " Day {0}",
        [Language.FR] = TorahCelebrations[TorahCelebration.Pessah][Language.FR] + " Jour {0}"
      };

    static public readonly TranslationsDictionary SoukotDay
      = new TranslationsDictionary
      {
        [Language.EN] = TorahCelebrations[TorahCelebration.Soukot][Language.EN] + " Day {0}",
        [Language.FR] = TorahCelebrations[TorahCelebration.Soukot][Language.FR] + " Jour {0}"
      };

    static public readonly TranslationsDictionary Start
      = new TranslationsDictionary
      {
        [Language.EN] = "Start",
        [Language.FR] = "Début"
      };

    static public readonly TranslationsDictionary End
      = new TranslationsDictionary
      {
        [Language.EN] = "End",
        [Language.FR] = "Fin"
      };

    static public readonly TranslationsDictionary Lamb
      = new TranslationsDictionary
      {
        [Language.EN] = "Lamb",
        [Language.FR] = "Agneau"
      };

    static public readonly NullSafeDictionary<TorahCelebrationDay, TranslationsDictionary> TorahCelebrationDays
      = new NullSafeDictionary<TorahCelebrationDay, TranslationsDictionary>
      {
        [TorahCelebrationDay.None] = new TranslationsDictionary
        {
          [Language.EN] = "",
          [Language.FR] = ""
        },
        [TorahCelebrationDay.NewYearD1] = new TranslationsDictionary
        {
          [Language.EN] = "New Year",
          [Language.FR] = "Nouvelle Année"
        },
        [TorahCelebrationDay.NewYearD10] = new TranslationsDictionary
        {
          [Language.EN] = "Set Aside " + Start[Language.EN],
          [Language.FR] = "Réserver " + Start[Language.FR]
        },
        [TorahCelebrationDay.PessahD1] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.Pessah][Language.EN] + " " + Start[Language.EN],
          [Language.FR] = TorahCelebrations[TorahCelebration.Pessah][Language.FR] + " " + Start[Language.FR]
        },
        [TorahCelebrationDay.PessahD7] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.Pessah][Language.EN] + " " + End[Language.EN],
          [Language.FR] = TorahCelebrations[TorahCelebration.Pessah][Language.FR] + " " + End[Language.FR]
        },
        [TorahCelebrationDay.ChavouotDiet] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.Chavouot][Language.EN] + " Diet",
          [Language.FR] = TorahCelebrations[TorahCelebration.Chavouot][Language.FR] + " Régime"
        },
        [TorahCelebrationDay.Chavouot1] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.Chavouot][Language.EN] + " " + Start[Language.EN],
          [Language.FR] = TorahCelebrations[TorahCelebration.Chavouot][Language.FR] + " " + Start[Language.FR]
        },
        [TorahCelebrationDay.Chavouot2] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.Chavouot][Language.EN] + " " + End[Language.EN],
          [Language.FR] = TorahCelebrations[TorahCelebration.Chavouot][Language.FR] + " " + End[Language.FR]
        },
        [TorahCelebrationDay.YomTerouah] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.YomTerouah][Language.EN],
          [Language.FR] = TorahCelebrations[TorahCelebration.YomTerouah][Language.FR]
        },
        [TorahCelebrationDay.YomHaKipourim] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.YomHaKipourim][Language.EN],
          [Language.FR] = TorahCelebrations[TorahCelebration.YomHaKipourim][Language.FR]
        },
        [TorahCelebrationDay.SoukotD1] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.Soukot][Language.EN] + " " + Start[Language.EN],
          [Language.FR] = TorahCelebrations[TorahCelebration.Soukot][Language.FR] + " " + Start[Language.FR]
        },
        [TorahCelebrationDay.SoukotD8] = new TranslationsDictionary
        {
          [Language.EN] = TorahCelebrations[TorahCelebration.Soukot][Language.EN] + " " + End[Language.EN],
          [Language.FR] = TorahCelebrations[TorahCelebration.Soukot][Language.FR] + " " + End[Language.FR]
        }
        // TODO manage as user custom remind list
        /*[TorahCelebrationDay.HanoukaD1] = new TranslationsDictionary
        {
          [Language.EN] = "'Hanouka start",
          [Language.FR] = "Début de 'Hanouka"
        },
        [TorahCelebrationDay.HanoukaD8] = new TranslationsDictionary
        {
          [Language.EN] = "'Hanouka end",
          [Language.FR] = "'Fin de Hanouka"
        },
        [TorahCelebrationDay.Pourim] = new TranslationsDictionary
        {
          [Language.EN] = "Pourim",
          [Language.FR] = "Pourim"
        },
        [TorahCelebrationDay.AnniversarySun] = new TranslationsDictionary
        {
          [Language.EN] = "Solar anniversary",
          [Language.FR] = "Anniversaire solaire"
        },
        [TorahCelebrationDay.AnniversaryMoon] = new TranslationsDictionary
        {
          [Language.EN] = "Lunar anniversary",
          [Language.FR] = "Anniversaire lunaire"
        }*/
      };

  }

}
