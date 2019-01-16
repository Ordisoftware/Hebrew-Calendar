/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide torah celebrations events parameters.
  /// </summary>
  static public class TorahCelebrations
  {

    /// <summary>
    /// The spring lamb day.
    /// </summary>
    static public readonly int NewLambDay = 10;

    /// <summary>
    /// The pessah start day.
    /// </summary>
    static public readonly int PessahStartDay = 14;

    /// <summary>
    /// The pessah lenght.
    /// </summary>
    static public readonly int PessahLenght = 7 + 1;

    /// <summary>
    /// The chavouot lenght.
    /// </summary>
    static public readonly int ChavouotLenght = 50;

    /// <summary>
    /// The hakipourim day.
    /// </summary>
    static public readonly int YomHaKipourimDay = 10;

    /// <summary>
    /// The soukot start day.
    /// </summary>
    static public readonly int SoukotStartDay = 15;

    /// <summary>
    /// The soukot lenght.
    /// </summary>
    static public readonly int SoukotLenght = 7 + 1;

    /// <summary>
    /// List of names of the season change events.
    /// </summary>
    static public readonly Dictionary<SeasonChangeType, Dictionary<string, string>> SeasonEventNames
      = new Dictionary<SeasonChangeType, Dictionary<string, string>>()
      {
        {
          SeasonChangeType.None, new Dictionary<string, string>
          {
            { "en", "" },
            { "fr", "" }
          }
        },
        {
          SeasonChangeType.AutumnEquinox, new Dictionary<string, string>
          {
            { "en", "Autumn equinox" },
            { "fr", "Equinoxe d'automne" }
          }
        },
        {
          SeasonChangeType.SpringEquinox, new Dictionary<string, string>
          {
            { "en", "Spring equinox" },
            { "fr", "Equinoxe de printemps" }
          }
        },
        {
          SeasonChangeType.SummerSolstice, new Dictionary<string, string>
          {
            { "en", "Summer solstice" },
            { "fr", "Solstice d'été" }
          }
        },
        {
          SeasonChangeType.WinterSolstice, new Dictionary<string, string>
          {
            { "en", "Winter solstice" },
            { "fr", "Solstice d'hiver" }
          }
        }
      };

    /// <summary>
    /// List of names of the torah events.
    /// </summary>
    static public readonly Dictionary<TorahEventType, Dictionary<string, string>> TorahEventNames
      = new Dictionary<TorahEventType, Dictionary<string, string>>()
      {
        {
          TorahEventType.None, new Dictionary<string, string>
          {
            { "en", "" },
            { "fr", "" }
          }
        },
        {
          TorahEventType.NewYearD1, new Dictionary<string, string>
          {
            { "en", "New year" },
            { "fr", "Début de l'année" }
          }
        },
        {
          TorahEventType.NewYearD10, new Dictionary<string, string>
          {
            { "en", "Set aside lamb" },
            { "fr", "Réserver agneau" }
          }
        },
        {
          TorahEventType.PessahD1, new Dictionary<string, string>
          {
            { "en", "Pessa'h start" },
            { "fr", "Début de Pessah" }
          }
        },
        {
          TorahEventType.PessahD8, new Dictionary<string, string>
          {
            { "en", "Pessa'h end" },
            { "fr", "Fin de Pessah" }
          }
        },
        {
          TorahEventType.ChavouotDiet, new Dictionary<string, string>
          {
            { "en", "Chavouot diet" },
            { "fr", "Régime de Chavouot" }
          }
        },
        {
          TorahEventType.Chavouot1, new Dictionary<string, string>
          {
            { "en", "Chavouot lamb" },
            { "fr", "Agneau de Chavouot" }
          }
        },
        {
          TorahEventType.Chavouot2, new Dictionary<string, string>
          {
            { "en", "Chavouot end" },
            { "fr", "Fin de Chavouot" }
          }
        },
        {
          TorahEventType.YomTerouah, new Dictionary<string, string>
          {
            { "en", "Yom Terou'ah" },
            { "fr", "Yom Terou'ah" }
          }
        },
        {
          TorahEventType.YomHaKipourim, new Dictionary<string, string>
          {
            { "en", "Yom HaKipourim" },
            { "fr", "Yom HaKipourim" }
          }
        },
        {
          TorahEventType.SoukotD1, new Dictionary<string, string>
          {
            { "en", "Soukot start" },
            { "fr", "Début de Soukot" }
          }
        },
        {
          TorahEventType.SoukotD8, new Dictionary<string, string>
          {
            { "en", "Soukot end" },
            { "fr", "Fin de Soukot" }
          }
        }
      };

  }

}
