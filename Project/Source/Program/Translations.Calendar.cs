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

    static public readonly NullSafeStringDictionary Today
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Today" },
        { Languages.FR, "Aujourd'hui" }
      };

    static public readonly NullSafeStringDictionary NavigationDay
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Day #" },
        { Languages.FR, "Jour #" }
      };

    static public readonly NullSafeDictionary<DayOfWeek, NullSafeStringDictionary> DayOfWeek
      = new NullSafeDictionary<DayOfWeek, NullSafeStringDictionary>()
      {
        {
          System.DayOfWeek.Monday, new NullSafeStringDictionary
          {
            { Languages.EN, "Monday" },
            { Languages.FR, "Lundi" }
          }
        },
        {
          System.DayOfWeek.Tuesday, new NullSafeStringDictionary
          {
            { Languages.EN, "Tuesday" },
            { Languages.FR, "Mardi" }
          }
        },
        {
          System.DayOfWeek.Wednesday, new NullSafeStringDictionary
          {
            { Languages.EN, "Wednesday" },
            { Languages.FR, "Mercredi" }
          }
        },
        {
          System.DayOfWeek.Thursday, new NullSafeStringDictionary
          {
            { Languages.EN, "Thursday" },
            { Languages.FR, "Jeudi" }
          }
        },
        {
          System.DayOfWeek.Friday, new NullSafeStringDictionary
          {
            { Languages.EN, "Friday" },
            { Languages.FR, "Vendredi" }
          }
        },
        {
          System.DayOfWeek.Saturday, new NullSafeStringDictionary
          {
            { Languages.EN, "Saturday" },
            { Languages.FR, "Samedi" }
          }
        },
        {
          System.DayOfWeek.Sunday, new NullSafeStringDictionary
          {
            { Languages.EN, "Sunday" },
            { Languages.FR, "Dimanche" }
          }
        }
      };

    static public readonly NullSafeDictionary<MoonPhase, NullSafeStringDictionary> MoonPhase
      = new NullSafeDictionary<MoonPhase, NullSafeStringDictionary>()
      {
        {
          HebrewCalendar.MoonPhase.New, new NullSafeStringDictionary
          {
            { Languages.EN, "New moon" },
            { Languages.FR, "Nouvelle lune" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaxingCrescent, new NullSafeStringDictionary
          {
            { Languages.EN, "Waxing crescent" },
            { Languages.FR, "Premier croissant" }
          }
        },
        {
          HebrewCalendar.MoonPhase.FirstQuarter, new NullSafeStringDictionary
          {
            { Languages.EN, "First quarter" },
            { Languages.FR, "Premier quartier" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaxingGibbous, new NullSafeStringDictionary
          {
            { Languages.EN, "Waxing gibbous" },
            { Languages.FR, "Gibbeuse croissante" }
          }
        },
        {
          HebrewCalendar.MoonPhase.Full, new NullSafeStringDictionary
          {
            { Languages.EN, "Full moon" },
            { Languages.FR, "Pleine lune" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaningGibbous, new NullSafeStringDictionary
          {
            { Languages.EN, "Waning gibbous" },
            { Languages.FR, "Gibbeuse décroissante" }
          }
        },
        {
          HebrewCalendar.MoonPhase.LastQuarter, new NullSafeStringDictionary
          {
            { Languages.EN, "Last quarter" },
            { Languages.FR, "Dernier quartier" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaningCrescent, new NullSafeStringDictionary
          {
            { Languages.EN, "Waning crescent" },
            { Languages.FR, "Dernier croissant" }
          }
        }
      };

    static public readonly NullSafeDictionary<Ephemeris, NullSafeStringDictionary> Ephemeris
      = new NullSafeDictionary<Ephemeris, NullSafeStringDictionary>()
      {
        {
          HebrewCalendar.Ephemeris.Rise, new NullSafeStringDictionary
          {
            { Languages.EN, "R: " },
            { Languages.FR, "L: " }
          }
        },
        {
          HebrewCalendar.Ephemeris.Set, new NullSafeStringDictionary
          {
            { Languages.EN, "S: " },
            { Languages.FR, "C: " }
          }
        },
        {
          HebrewCalendar.Ephemeris.SummerHour, new NullSafeStringDictionary
          {
            { Languages.EN, "(S)" },
            { Languages.FR, "(E)" }
          }
        },
        {
          HebrewCalendar.Ephemeris.WinterHour, new NullSafeStringDictionary
          {
            { Languages.EN, "(W)" },
            { Languages.FR, "(H)" }
          }
        }
      };

    static public readonly NullSafeDictionary<ReportFieldText, NullSafeStringDictionary> CalendarField
      = new NullSafeDictionary<ReportFieldText, NullSafeStringDictionary>()
      {
        {
          ReportFieldText.Date, new NullSafeStringDictionary
          {
            { Languages.EN, "Date" },
            { Languages.FR, "Date" }
          }
        },
        {
          ReportFieldText.Month, new NullSafeStringDictionary
          {
            { Languages.EN, "Month" },
            { Languages.FR, "Mois" }
          }
        },
        {
          ReportFieldText.Sun, new NullSafeStringDictionary
          {
            { Languages.EN, "Sun" },
            { Languages.FR, "Soleil" }
          }
        },
        {
          ReportFieldText.Moon, new NullSafeStringDictionary
          {
            { Languages.EN, "Moon" },
            { Languages.FR, "Lune" }
          }
        },
        {
          ReportFieldText.Events, new NullSafeStringDictionary
          {
            { Languages.EN, "Events" },
            { Languages.FR, "Évènements" }
          }
        }
      };

    static public readonly NullSafeDictionary<SeasonChange, NullSafeStringDictionary> SeasonEvent
      = new NullSafeDictionary<SeasonChange, NullSafeStringDictionary>()
      {
        {
          SeasonChange.None, new NullSafeStringDictionary
          {
            { Languages.EN, "" },
            { Languages.FR, "" }
          }
        },
        {
          SeasonChange.SpringEquinox, new NullSafeStringDictionary
          {
            { Languages.EN, "Spring equinox" },
            { Languages.FR, "Equinoxe de printemps" }
          }
        },
        {
          SeasonChange.SummerSolstice, new NullSafeStringDictionary
          {
            { Languages.EN, "Summer solstice" },
            { Languages.FR, "Solstice d'été" }
          }
        },
        {
          SeasonChange.AutumnEquinox, new NullSafeStringDictionary
          {
            { Languages.EN, "Autumn equinox" },
            { Languages.FR, "Equinoxe d'automne" }
          }
        },
        {
          SeasonChange.WinterSolstice, new NullSafeStringDictionary
          {
            { Languages.EN, "Winter solstice" },
            { Languages.FR, "Solstice d'hiver" }
          }
        }
      };

    static public readonly NullSafeDictionary<TorahEvent, NullSafeStringDictionary> TorahEvent
      = new NullSafeDictionary<TorahEvent, NullSafeStringDictionary>()
      {
        {
          HebrewCalendar.TorahEvent.None, new NullSafeStringDictionary
          {
            { Languages.EN, "" },
            { Languages.FR, "" }
          }
        },
        {
          HebrewCalendar.TorahEvent.NewYearD1, new NullSafeStringDictionary
          {
            { Languages.EN, "New year" },
            { Languages.FR, "Début de l'année" }
          }
        },
        {
          HebrewCalendar.TorahEvent.NewYearD10, new NullSafeStringDictionary
          {
            { Languages.EN, "Set aside lamb" },
            { Languages.FR, "Réserver agneau" }
          }
        },
        {
          HebrewCalendar.TorahEvent.PessahD1, new NullSafeStringDictionary
          {
            { Languages.EN, "Pessa'h start" },
            { Languages.FR, "Début de Pessah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.PessahD7, new NullSafeStringDictionary
          {
            { Languages.EN, "Pessa'h end" },
            { Languages.FR, "Fin de Pessah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.ChavouotDiet, new NullSafeStringDictionary
          {
            { Languages.EN, "Chavouot diet" },
            { Languages.FR, "Régime de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.Chavouot1, new NullSafeStringDictionary
          {
            { Languages.EN, "Chavouot lamb" },
            { Languages.FR, "Agneau de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.Chavouot2, new NullSafeStringDictionary
          {
            { Languages.EN, "Chavouot end" },
            { Languages.FR, "Fin de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.YomTerouah, new NullSafeStringDictionary
          {
            { Languages.EN, "Yom Terou'ah" },
            { Languages.FR, "Yom Terou'ah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.YomHaKipourim, new NullSafeStringDictionary
          {
            { Languages.EN, "Yom HaKipourim" },
            { Languages.FR, "Yom HaKipourim" }
          }
        },
        {
          HebrewCalendar.TorahEvent.SoukotD1, new NullSafeStringDictionary
          {
            { Languages.EN, "Soukot start" },
            { Languages.FR, "Début de Soukot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.SoukotD8, new NullSafeStringDictionary
          {
            { Languages.EN, "Soukot end" },
            { Languages.FR, "Fin de Soukot" }
          }
        }
      };

  }

}
