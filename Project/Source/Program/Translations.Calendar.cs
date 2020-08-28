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
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static public readonly Dictionary<string, string> Today
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Today" },
        { Languages.FR, "Aujourd'hui" }
      };

    static public readonly Dictionary<string, string> NavigationDay
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Day #" },
        { Languages.FR, "Jour #" }
      };

    static public readonly Dictionary<DayOfWeek, Dictionary<string, string>> DayOfWeek
      = new Dictionary<DayOfWeek, Dictionary<string, string>>()
      {
        {
          System.DayOfWeek.Monday, new Dictionary<string, string>
          {
            { Languages.EN, "Monday" },
            { Languages.FR, "Lundi" }
          }
        },
        {
          System.DayOfWeek.Tuesday, new Dictionary<string, string>
          {
            { Languages.EN, "Tuesday" },
            { Languages.FR, "Mardi" }
          }
        },
        {
          System.DayOfWeek.Wednesday, new Dictionary<string, string>
          {
            { Languages.EN, "Wednesday" },
            { Languages.FR, "Mercredi" }
          }
        },
        {
          System.DayOfWeek.Thursday, new Dictionary<string, string>
          {
            { Languages.EN, "Thursday" },
            { Languages.FR, "Jeudi" }
          }
        },
        {
          System.DayOfWeek.Friday, new Dictionary<string, string>
          {
            { Languages.EN, "Friday" },
            { Languages.FR, "Vendredi" }
          }
        },
        {
          System.DayOfWeek.Saturday, new Dictionary<string, string>
          {
            { Languages.EN, "Saturday" },
            { Languages.FR, "Samedi" }
          }
        },
        {
          System.DayOfWeek.Sunday, new Dictionary<string, string>
          {
            { Languages.EN, "Sunday" },
            { Languages.FR, "Dimanche" }
          }
        }
      };

    static public readonly Dictionary<MoonPhase, Dictionary<string, string>> MoonPhase
      = new Dictionary<MoonPhase, Dictionary<string, string>>()
      {
        {
          HebrewCalendar.MoonPhase.New, new Dictionary<string, string>
          {
            { Languages.EN, "New moon" },
            { Languages.FR, "Nouvelle lune" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaxingCrescent, new Dictionary<string, string>
          {
            { Languages.EN, "Waxing crescent" },
            { Languages.FR, "Premier croissant" }
          }
        },
        {
          HebrewCalendar.MoonPhase.FirstQuarter, new Dictionary<string, string>
          {
            { Languages.EN, "First quarter" },
            { Languages.FR, "Premier quartier" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaxingGibbous, new Dictionary<string, string>
          {
            { Languages.EN, "Waxing gibbous" },
            { Languages.FR, "Gibbeuse croissante" }
          }
        },
        {
          HebrewCalendar.MoonPhase.Full, new Dictionary<string, string>
          {
            { Languages.EN, "Full moon" },
            { Languages.FR, "Pleine lune" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaningGibbous, new Dictionary<string, string>
          {
            { Languages.EN, "Waning gibbous" },
            { Languages.FR, "Gibbeuse décroissante" }
          }
        },
        {
          HebrewCalendar.MoonPhase.LastQuarter, new Dictionary<string, string>
          {
            { Languages.EN, "Last quarter" },
            { Languages.FR, "Dernier quartier" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaningCrescent, new Dictionary<string, string>
          {
            { Languages.EN, "Waning crescent" },
            { Languages.FR, "Dernier croissant" }
          }
        }
      };

    static public readonly Dictionary<Ephemeris, Dictionary<string, string>> Ephemeris
      = new Dictionary<Ephemeris, Dictionary<string, string>>()
      {
        {
          HebrewCalendar.Ephemeris.Rise, new Dictionary<string, string>
          {
            { Languages.EN, "R: " },
            { Languages.FR, "L: " }
          }
        },
        {
          HebrewCalendar.Ephemeris.Set, new Dictionary<string, string>
          {
            { Languages.EN, "S: " },
            { Languages.FR, "C: " }
          }
        },
        {
          HebrewCalendar.Ephemeris.SummerHour, new Dictionary<string, string>
          {
            { Languages.EN, "(S)" },
            { Languages.FR, "(E)" }
          }
        },
        {
          HebrewCalendar.Ephemeris.WinterHour, new Dictionary<string, string>
          {
            { Languages.EN, "(W)" },
            { Languages.FR, "(H)" }
          }
        }
      };

    static public readonly Dictionary<ReportFieldText, Dictionary<string, string>> CalendarField
      = new Dictionary<ReportFieldText, Dictionary<string, string>>()
      {
        {
          ReportFieldText.Date, new Dictionary<string, string>
          {
            { Languages.EN, "Date" },
            { Languages.FR, "Date" }
          }
        },
        {
          ReportFieldText.Month, new Dictionary<string, string>
          {
            { Languages.EN, "Month" },
            { Languages.FR, "Mois" }
          }
        },
        {
          ReportFieldText.Sun, new Dictionary<string, string>
          {
            { Languages.EN, "Sun" },
            { Languages.FR, "Soleil" }
          }
        },
        {
          ReportFieldText.Moon, new Dictionary<string, string>
          {
            { Languages.EN, "Moon" },
            { Languages.FR, "Lune" }
          }
        },
        {
          ReportFieldText.Events, new Dictionary<string, string>
          {
            { Languages.EN, "Events" },
            { Languages.FR, "Évènements" }
          }
        }
      };

    static public readonly Dictionary<SeasonChange, Dictionary<string, string>> SeasonEvent
      = new Dictionary<SeasonChange, Dictionary<string, string>>()
      {
        {
          SeasonChange.None, new Dictionary<string, string>
          {
            { Languages.EN, "" },
            { Languages.FR, "" }
          }
        },
        {
          SeasonChange.SpringEquinox, new Dictionary<string, string>
          {
            { Languages.EN, "Spring equinox" },
            { Languages.FR, "Equinoxe de printemps" }
          }
        },
        {
          SeasonChange.SummerSolstice, new Dictionary<string, string>
          {
            { Languages.EN, "Summer solstice" },
            { Languages.FR, "Solstice d'été" }
          }
        },
        {
          SeasonChange.AutumnEquinox, new Dictionary<string, string>
          {
            { Languages.EN, "Autumn equinox" },
            { Languages.FR, "Equinoxe d'automne" }
          }
        },
        {
          SeasonChange.WinterSolstice, new Dictionary<string, string>
          {
            { Languages.EN, "Winter solstice" },
            { Languages.FR, "Solstice d'hiver" }
          }
        }
      };

    static public readonly Dictionary<TorahEvent, Dictionary<string, string>> TorahEvent
      = new Dictionary<TorahEvent, Dictionary<string, string>>()
      {
        {
          HebrewCalendar.TorahEvent.None, new Dictionary<string, string>
          {
            { Languages.EN, "" },
            { Languages.FR, "" }
          }
        },
        {
          HebrewCalendar.TorahEvent.NewYearD1, new Dictionary<string, string>
          {
            { Languages.EN, "New year" },
            { Languages.FR, "Début de l'année" }
          }
        },
        {
          HebrewCalendar.TorahEvent.NewYearD10, new Dictionary<string, string>
          {
            { Languages.EN, "Set aside lamb" },
            { Languages.FR, "Réserver agneau" }
          }
        },
        {
          HebrewCalendar.TorahEvent.PessahD1, new Dictionary<string, string>
          {
            { Languages.EN, "Pessa'h start" },
            { Languages.FR, "Début de Pessah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.PessahD7, new Dictionary<string, string>
          {
            { Languages.EN, "Pessa'h end" },
            { Languages.FR, "Fin de Pessah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.ChavouotDiet, new Dictionary<string, string>
          {
            { Languages.EN, "Chavouot diet" },
            { Languages.FR, "Régime de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.Chavouot1, new Dictionary<string, string>
          {
            { Languages.EN, "Chavouot lamb" },
            { Languages.FR, "Agneau de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.Chavouot2, new Dictionary<string, string>
          {
            { Languages.EN, "Chavouot end" },
            { Languages.FR, "Fin de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.YomTerouah, new Dictionary<string, string>
          {
            { Languages.EN, "Yom Terou'ah" },
            { Languages.FR, "Yom Terou'ah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.YomHaKipourim, new Dictionary<string, string>
          {
            { Languages.EN, "Yom HaKipourim" },
            { Languages.FR, "Yom HaKipourim" }
          }
        },
        {
          HebrewCalendar.TorahEvent.SoukotD1, new Dictionary<string, string>
          {
            { Languages.EN, "Soukot start" },
            { Languages.FR, "Début de Soukot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.SoukotD8, new Dictionary<string, string>
          {
            { Languages.EN, "Soukot end" },
            { Languages.FR, "Fin de Soukot" }
          }
        }
      };

  }

}
