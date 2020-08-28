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
        { Languages.EN, "Generate a hebrew lunisolar calendar with shabat and celebrations reminder" },
        { Languages.FR, "Génère un calendrier luni-solaire hébraïque avec rappel du shabat et des célébrations" }
      };

    static public readonly Dictionary<string, string> AskToResetPreferences
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Preferences will be reseted to their default values." + Globals.NL + Globals.NL +
                        "GPS location and shabat day will be keeped." + Globals.NL + Globals.NL +
                        Localizer.AskToContinue[Languages.EN] },
        { Languages.FR, "Les préférences vont être réinitialisées à leurs valeurs par défaut." + Globals.NL + Globals.NL +
                        "La position GPS et le jour du shabat seront conservés." + Globals.NL + Globals.NL +
                        Localizer.AskToContinue[Languages.FR] },
      };

    static public readonly Dictionary<string, string> CantExitWhileGenerating
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Can't exit application while generating data." },
        { Languages.FR, "Impossible de quitter l'application durant la génération des données." }
      };

    static public readonly Dictionary<string, string> ProgressLoadingData
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Loading data" },
        { Languages.FR, "Chargement des données" }
      };

    static public readonly Dictionary<string, string> ProgressCreateDays
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Populating days" },
        { Languages.FR, "Garnissage des jours" }
      };

    static public readonly Dictionary<string, string> ProgressAnalyzeDays
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Analyzing days" },
        { Languages.FR, "Analyse des jours" }
      };

    static public readonly Dictionary<string, string> ProgressGenerateReport
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Generating report" },
        { Languages.FR, "Génération du rapport" }
      };

    static public readonly Dictionary<string, string> ProgressFillMonths
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Filling months" },
        { Languages.FR, "Remplissage des mois" }
      };

    static public readonly Dictionary<string, string> AskToUseMoonOmer
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Do you want to use the moon omer, else the sun?" },
        { Languages.FR, "Voulez-vous utiliser le omer de la lune, sinon du soleil ?" }
      };

    static public readonly Dictionary<string, string> AskToSetupPersonalShabat
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Do you want to setup the personal shabat?" },
        { Languages.FR, "Voulez-vous configurer le shabat personnel ?" }
      };

    static public readonly Dictionary<string, string> DateNotFound
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Date not found in the database: {0}" },
        { Languages.FR, "Date non trouvée dans la base de données : {0}" }
      };

    static public readonly Dictionary<string, string> SelectBirthday
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Birth day" },
        { Languages.FR, "Jour de naissance" }
      };

    static public readonly Dictionary<string, string> FirstDay
      = new Dictionary<string, string>()
      {
        { Languages.EN, "First day" },
        { Languages.FR, "Premier jour" }
      };

    static public readonly Dictionary<string, string> LastDay
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Last day" },
        { Languages.FR, "Dernier jour" }
      };

    static public readonly Dictionary<string, string> PredefinedYearsInterval
      = new Dictionary<string, string>
      {
        { Languages.EN, "{0} years from now" },
        { Languages.FR, "{0} années à partir de maintenant" }
      };

  }

}
