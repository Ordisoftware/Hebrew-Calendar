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

    static public readonly Dictionary<string, string> ApplicationDescription
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Generate a hebrew lunisolar calendar with shabat and celebrations reminder" },
        { Localizer.FR, "Génère un calendrier luni-solaire hébraïque avec rappel du shabat et des célébrations" }
      };

    static public readonly Dictionary<string, string> AskToResetPreferences
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Preferences will be reseted to their default values." + Localizer.NL + Localizer.NL +
                        "GPS location and shabat day will be keeped." + Localizer.NL + Localizer.NL +
                        Localizer.AskToContinue[Localizer.EN] },
        { Localizer.FR, "Les préférences vont être réinitialisées à leurs valeurs par défaut." + Localizer.NL + Localizer.NL +
                        "La position GPS et le jour du shabat seront conservés." + Localizer.NL + Localizer.NL +
                        Localizer.AskToContinue[Localizer.FR] },
      };

    static public readonly Dictionary<string, string> CantExitWhileGenerating
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Can't exit application while generating data." },
        { Localizer.FR, "Impossible de quitter l'application durant la génération des données." }
      };

    static public readonly Dictionary<string, string> ProgressLoadingData
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Loading data" },
        { Localizer.FR, "Chargement des données" }
      };

    static public readonly Dictionary<string, string> ProgressCreateDays
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Populating days" },
        { Localizer.FR, "Garnissage des jours" }
      };

    static public readonly Dictionary<string, string> ProgressAnalyzeDays
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Analyzing days" },
        { Localizer.FR, "Analyse des jours" }
      };

    static public readonly Dictionary<string, string> ProgressGenerateReport
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Generating report" },
        { Localizer.FR, "Génération du rapport" }
      };

    static public readonly Dictionary<string, string> ProgressFillMonths
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Filling months" },
        { Localizer.FR, "Remplissage des mois" }
      };

    static public readonly Dictionary<string, string> AskToUseMoonOmer
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Do you want to use the moon omer, else the sun?" },
        { Localizer.FR, "Voulez-vous utiliser le omer de la lune, sinon du soleil ?" }
      };

    static public readonly Dictionary<string, string> AskToSetupPersonalShabat
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Do you want to setup the personal shabat?" },
        { Localizer.FR, "Voulez-vous configurer le shabat personnel ?" }
      };

    static public readonly Dictionary<string, string> DateNotFound
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Date not found in the database: {0}" },
        { Localizer.FR, "Date non trouvée dans la base de données : {0}" }
      };

    static public readonly Dictionary<string, string> SelectBirthday
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Birth day" },
        { Localizer.FR, "Jour de naissance" }
      };

    static public readonly Dictionary<string, string> FirstDay
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "First day" },
        { Localizer.FR, "Premier jour" }
      };

    static public readonly Dictionary<string, string> LastDay
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Last day" },
        { Localizer.FR, "Dernier jour" }
      };

    static public readonly Dictionary<string, string> DiffDatesSolarCount
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Solar days count: {0}" },
        { Localizer.FR, "Nombre de jours solaires : {0}" }
      };

    static public readonly Dictionary<string, string> DiffDatesMoonCount
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Moon days count: {0}" },
        { Localizer.FR, "Nombre de jours lunaires : {0}" }
      };

    static public readonly Dictionary<string, string> DiffDatesMoonOutOfRange
      = new Dictionary<string, string>()
      {
        { Localizer.EN, "Moon days count: out of range ({0} - {1})" },
        { Localizer.FR, "Nombre de jours lunaires : hors limites ({0} - {1})" }
      };

    static public readonly Dictionary<string, string> PredefinedYearsInterval
      = new Dictionary<string, string>
      {
        { Localizer.EN, "{0} years from now" },
        { Localizer.FR, "{0} années à partir de maintenant" }
      };

  }

}
