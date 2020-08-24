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
        { Localizer.EN, "Today" },
        { Localizer.FR, "Aujourd'hui" }
      };

    static public readonly Dictionary<string, string> NavigationDay
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Day #" },
        { Localizer.FR, "Jour #" }
      };

    static public readonly Dictionary<DayOfWeek, Dictionary<string, string>> DayOfWeek
      = new Dictionary<DayOfWeek, Dictionary<string, string>>()
      {
        {
          System.DayOfWeek.Monday, new Dictionary<string, string>
          {
            { Localizer.EN, "Monday" },
            { Localizer.FR, "Lundi" }
          }
        },
        {
          System.DayOfWeek.Tuesday, new Dictionary<string, string>
          {
            { Localizer.EN, "Tuesday" },
            { Localizer.FR, "Mardi" }
          }
        },
        {
          System.DayOfWeek.Wednesday, new Dictionary<string, string>
          {
            { Localizer.EN, "Wednesday" },
            { Localizer.FR, "Mercredi" }
          }
        },
        {
          System.DayOfWeek.Thursday, new Dictionary<string, string>
          {
            { Localizer.EN, "Thursday" },
            { Localizer.FR, "Jeudi" }
          }
        },
        {
          System.DayOfWeek.Friday, new Dictionary<string, string>
          {
            { Localizer.EN, "Friday" },
            { Localizer.FR, "Vendredi" }
          }
        },
        {
          System.DayOfWeek.Saturday, new Dictionary<string, string>
          {
            { Localizer.EN, "Saturday" },
            { Localizer.FR, "Samedi" }
          }
        },
        {
          System.DayOfWeek.Sunday, new Dictionary<string, string>
          {
            { Localizer.EN, "Sunday" },
            { Localizer.FR, "Dimanche" }
          }
        }
      };

    static public readonly Dictionary<MoonPhase, Dictionary<string, string>> MoonPhase
      = new Dictionary<MoonPhase, Dictionary<string, string>>()
      {
        {
          HebrewCalendar.MoonPhase.New, new Dictionary<string, string>
          {
            { Localizer.EN, "New moon" },
            { Localizer.FR, "Nouvelle lune" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaxingCrescent, new Dictionary<string, string>
          {
            { Localizer.EN, "Waxing crescent" },
            { Localizer.FR, "Premier croissant" }
          }
        },
        {
          HebrewCalendar.MoonPhase.FirstQuarter, new Dictionary<string, string>
          {
            { Localizer.EN, "First quarter" },
            { Localizer.FR, "Premier quartier" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaxingGibbous, new Dictionary<string, string>
          {
            { Localizer.EN, "Waxing gibbous" },
            { Localizer.FR, "Gibbeuse croissante" }
          }
        },
        {
          HebrewCalendar.MoonPhase.Full, new Dictionary<string, string>
          {
            { Localizer.EN, "Full moon" },
            { Localizer.FR, "Pleine lune" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaningGibbous, new Dictionary<string, string>
          {
            { Localizer.EN, "Waning gibbous" },
            { Localizer.FR, "Gibbeuse décroissante" }
          }
        },
        {
          HebrewCalendar.MoonPhase.LastQuarter, new Dictionary<string, string>
          {
            { Localizer.EN, "Last quarter" },
            { Localizer.FR, "Dernier quartier" }
          }
        },
        {
          HebrewCalendar.MoonPhase.WaningCrescent, new Dictionary<string, string>
          {
            { Localizer.EN, "Waning crescent" },
            { Localizer.FR, "Dernier croissant" }
          }
        }
      };

    static public readonly Dictionary<Ephemeris, Dictionary<string, string>> Ephemeris
      = new Dictionary<Ephemeris, Dictionary<string, string>>()
      {
        {
          HebrewCalendar.Ephemeris.Rise, new Dictionary<string, string>
          {
            { Localizer.EN, "R: " },
            { Localizer.FR, "L: " }
          }
        },
        {
          HebrewCalendar.Ephemeris.Set, new Dictionary<string, string>
          {
            { Localizer.EN, "S: " },
            { Localizer.FR, "C: " }
          }
        },
        {
          HebrewCalendar.Ephemeris.SummerHour, new Dictionary<string, string>
          {
            { Localizer.EN, "(S)" },
            { Localizer.FR, "(E)" }
          }
        },
        {
          HebrewCalendar.Ephemeris.WinterHour, new Dictionary<string, string>
          {
            { Localizer.EN, "(W)" },
            { Localizer.FR, "(H)" }
          }
        }
      };

    static public readonly Dictionary<ReportFieldText, Dictionary<string, string>> CalendarField
      = new Dictionary<ReportFieldText, Dictionary<string, string>>()
      {
        {
          ReportFieldText.Date, new Dictionary<string, string>
          {
            { Localizer.EN, "Date" },
            { Localizer.FR, "Date" }
          }
        },
        {
          ReportFieldText.Month, new Dictionary<string, string>
          {
            { Localizer.EN, "Month" },
            { Localizer.FR, "Mois" }
          }
        },
        {
          ReportFieldText.Sun, new Dictionary<string, string>
          {
            { Localizer.EN, "Sun" },
            { Localizer.FR, "Soleil" }
          }
        },
        {
          ReportFieldText.Moon, new Dictionary<string, string>
          {
            { Localizer.EN, "Moon" },
            { Localizer.FR, "Lune" }
          }
        },
        {
          ReportFieldText.Events, new Dictionary<string, string>
          {
            { Localizer.EN, "Events" },
            { Localizer.FR, "Évènements" }
          }
        }
      };

    static public readonly Dictionary<SeasonChange, Dictionary<string, string>> SeasonEvent
      = new Dictionary<SeasonChange, Dictionary<string, string>>()
      {
        {
          SeasonChange.None, new Dictionary<string, string>
          {
            { Localizer.EN, "" },
            { Localizer.FR, "" }
          }
        },
        {
          SeasonChange.SpringEquinox, new Dictionary<string, string>
          {
            { Localizer.EN, "Spring equinox" },
            { Localizer.FR, "Equinoxe de printemps" }
          }
        },
        {
          SeasonChange.SummerSolstice, new Dictionary<string, string>
          {
            { Localizer.EN, "Summer solstice" },
            { Localizer.FR, "Solstice d'été" }
          }
        },
        {
          SeasonChange.AutumnEquinox, new Dictionary<string, string>
          {
            { Localizer.EN, "Autumn equinox" },
            { Localizer.FR, "Equinoxe d'automne" }
          }
        },
        {
          SeasonChange.WinterSolstice, new Dictionary<string, string>
          {
            { Localizer.EN, "Winter solstice" },
            { Localizer.FR, "Solstice d'hiver" }
          }
        }
      };

    static public readonly Dictionary<TorahEvent, Dictionary<string, string>> TorahEvent
      = new Dictionary<TorahEvent, Dictionary<string, string>>()
      {
        {
          HebrewCalendar.TorahEvent.None, new Dictionary<string, string>
          {
            { Localizer.EN, "" },
            { Localizer.FR, "" }
          }
        },
        {
          HebrewCalendar.TorahEvent.NewYearD1, new Dictionary<string, string>
          {
            { Localizer.EN, "New year" },
            { Localizer.FR, "Début de l'année" }
          }
        },
        {
          HebrewCalendar.TorahEvent.NewYearD10, new Dictionary<string, string>
          {
            { Localizer.EN, "Set aside lamb" },
            { Localizer.FR, "Réserver agneau" }
          }
        },
        {
          HebrewCalendar.TorahEvent.PessahD1, new Dictionary<string, string>
          {
            { Localizer.EN, "Pessa'h start" },
            { Localizer.FR, "Début de Pessah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.PessahD7, new Dictionary<string, string>
          {
            { Localizer.EN, "Pessa'h end" },
            { Localizer.FR, "Fin de Pessah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.ChavouotDiet, new Dictionary<string, string>
          {
            { Localizer.EN, "Chavouot diet" },
            { Localizer.FR, "Régime de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.Chavouot1, new Dictionary<string, string>
          {
            { Localizer.EN, "Chavouot lamb" },
            { Localizer.FR, "Agneau de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.Chavouot2, new Dictionary<string, string>
          {
            { Localizer.EN, "Chavouot end" },
            { Localizer.FR, "Fin de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.YomTerouah, new Dictionary<string, string>
          {
            { Localizer.EN, "Yom Terou'ah" },
            { Localizer.FR, "Yom Terou'ah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.YomHaKipourim, new Dictionary<string, string>
          {
            { Localizer.EN, "Yom HaKipourim" },
            { Localizer.FR, "Yom HaKipourim" }
          }
        },
        {
          HebrewCalendar.TorahEvent.SoukotD1, new Dictionary<string, string>
          {
            { Localizer.EN, "Soukot start" },
            { Localizer.FR, "Début de Soukot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.SoukotD8, new Dictionary<string, string>
          {
            { Localizer.EN, "Soukot end" },
            { Localizer.FR, "Fin de Soukot" }
          }
        }
      };

  }

}
