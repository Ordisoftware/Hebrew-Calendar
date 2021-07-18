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
/// <edited> 2021-07 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static partial class AppTranslations
  {

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

    static public readonly NullSafeDictionary<DayOfWeek, TranslationsDictionary> DayOfWeek
      = new NullSafeDictionary<DayOfWeek, TranslationsDictionary>
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

    static public readonly NullSafeDictionary<MoonriseOccuring, TranslationsDictionary> MoonriseOccuring
      = new NullSafeDictionary<MoonriseOccuring, TranslationsDictionary>
      {
        [Calendar.MoonriseOccuring.AfterSet] = new TranslationsDictionary
        {
          [Language.EN] = "After the set",
          [Language.FR] = "Après le lever"
        },
        [Calendar.MoonriseOccuring.BeforeSet] = new TranslationsDictionary
        {
          [Language.EN] = "Before the set",
          [Language.FR] = "Avant le lever"
        },
        [Calendar.MoonriseOccuring.NextDay] = new TranslationsDictionary
        {
          [Language.EN] = "The next day",
          [Language.FR] = "Le jour d'après"
        },
      };

    static public readonly NullSafeDictionary<MoonPhase, TranslationsDictionary> MoonPhase
      = new NullSafeDictionary<MoonPhase, TranslationsDictionary>
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
      = new NullSafeDictionary<Ephemeris, TranslationsDictionary>
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
      = new NullSafeDictionary<ReportFieldText, TranslationsDictionary>
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

    static public readonly NullSafeDictionary<SeasonChange, TranslationsDictionary> SeasonChange
      = new NullSafeDictionary<SeasonChange, TranslationsDictionary>
      {
        [Calendar.SeasonChange.None] = new TranslationsDictionary
        {
          [Language.EN] = "",
          [Language.FR] = ""
        },
        [Calendar.SeasonChange.SpringEquinox] = new TranslationsDictionary
        {
          [Language.EN] = "Spring equinox",
          [Language.FR] = "Equinoxe de printemps"
        },
        [Calendar.SeasonChange.SummerSolstice] = new TranslationsDictionary
        {
          [Language.EN] = "Summer solstice",
          [Language.FR] = "Solstice d'été"
        },
        [Calendar.SeasonChange.AutumnEquinox] = new TranslationsDictionary
        {
          [Language.EN] = "Autumn equinox",
          [Language.FR] = "Equinoxe d'automne"
        },
        [Calendar.SeasonChange.WinterSolstice] = new TranslationsDictionary
        {
          [Language.EN] = "Winter solstice",
          [Language.FR] = "Solstice d'hiver"
        }
      };

    static public readonly TranslationsDictionary PessahDay
      = new TranslationsDictionary
      {
        [Language.EN] = "Pesa'h Day {0}",
        [Language.FR] = "Pessa'h Jour {0}"
      };

    static public readonly TranslationsDictionary SoukotDay
      = new TranslationsDictionary
      {
        [Language.EN] = "Sukot Day {0}",
        [Language.FR] = "Soukot Jour {0}"
      };

    static public readonly NullSafeDictionary<TorahEvent, TranslationsDictionary> TorahEvent
      = new NullSafeDictionary<TorahEvent, TranslationsDictionary>
      {
        [Calendar.TorahEvent.None] = new TranslationsDictionary
        {
          [Language.EN] = "",
          [Language.FR] = ""
        },
        [Calendar.TorahEvent.NewYearD1] = new TranslationsDictionary
        {
          [Language.EN] = "New Year",
          [Language.FR] = "Nouvelle Année"
        },
        [Calendar.TorahEvent.NewYearD10] = new TranslationsDictionary
        {
          [Language.EN] = "Set Aside Lamb",
          [Language.FR] = "Réserver Agneau"
        },
        [Calendar.TorahEvent.PessahD1] = new TranslationsDictionary
        {
          [Language.EN] = "Pesa'h Start",
          [Language.FR] = "Pessa'h Début"
        },
        [Calendar.TorahEvent.PessahD7] = new TranslationsDictionary
        {
          [Language.EN] = "Pesa'h End",
          [Language.FR] = "Pessa'h Fin"
        },
        [Calendar.TorahEvent.ChavouotDiet] = new TranslationsDictionary
        {
          [Language.EN] = "Shavu'ot Diet",
          [Language.FR] = "Shavou'ot Régime"
        },
        [Calendar.TorahEvent.Chavouot1] = new TranslationsDictionary
        {
          [Language.EN] = "Shavu'ot Lamb",
          [Language.FR] = "Shavou'ot Agneau"
        },
        [Calendar.TorahEvent.Chavouot2] = new TranslationsDictionary
        {
          [Language.EN] = "Shavu'ot End",
          [Language.FR] = "Shavou'ot Fin"
        },
        [Calendar.TorahEvent.YomTerouah] = new TranslationsDictionary
        {
          [Language.EN] = "Yom Teru'ah",
          [Language.FR] = "Yom Terou'ah"
        },
        [Calendar.TorahEvent.YomHaKipourim] = new TranslationsDictionary
        {
          [Language.EN] = "Yom HaKipurim",
          [Language.FR] = "Yom HaKipourim"
        },
        [Calendar.TorahEvent.SoukotD1] = new TranslationsDictionary
        {
          [Language.EN] = "Sukot Start",
          [Language.FR] = "Soukot Début"
        },
        [Calendar.TorahEvent.SoukotD8] = new TranslationsDictionary
        {
          [Language.EN] = "Sukot End",
          [Language.FR] = "Soukot Fin"
        }
        // TODO manage as user custom remind list
        /*[Calendar.TorahEvent.HanoukaD1] = new TranslationsDictionary
        {
          [Language.EN] = "'Hanouka start",
          [Language.FR] = "Début de 'Hanouka"
        },
        [Calendar.TorahEvent.HanoukaD8] = new TranslationsDictionary
        {
          [Language.EN] = "'Hanouka end",
          [Language.FR] = "'Fin de Hanouka"
        },
        [Calendar.TorahEvent.Pourim] = new TranslationsDictionary
        {
          [Language.EN] = "Pourim",
          [Language.FR] = "Pourim"
        },
        [Calendar.TorahEvent.AnniversarySun] = new TranslationsDictionary
        {
          [Language.EN] = "Solar anniversary",
          [Language.FR] = "Anniversaire solaire"
        },
        [Calendar.TorahEvent.AnniversaryMoon] = new TranslationsDictionary
        {
          [Language.EN] = "Lunar anniversary",
          [Language.FR] = "Anniversaire lunaire"
        }*/
      };

  }

}
