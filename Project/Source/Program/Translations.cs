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
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static public string NewLine { get { return Environment.NewLine; } }

    static public readonly Dictionary<string, string> ApplicationDescription
      = new Dictionary<string, string>()
      {
        { "en", "Generate a hebrew lunisolar calendar with shabat and celebrations reminder" },
        { "fr", "Génère un calendrier luni-solaire hébraïque avec rappel du shabat et des célébrations" }
      };

    static public readonly Dictionary<string, string> AskToResetPreferences
      = new Dictionary<string, string>()
      {
        { "en", "Preferences will be reseted to their default values." + NewLine + NewLine +
                "GPS location and shabat day will be keeped." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Les préférences vont être réinitialisées à leurs valeurs par défaut." + NewLine + NewLine +
                "La position GPS et le jour du shabat seront conservés." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> AskToShutdownComputer
      = new Dictionary<string, string>()
      {
        { "en", "Shutdown the computer?" },
        { "fr", "Arrêter l'ordinateur ?" }
      };

    static public readonly Dictionary<string, string> LockSessionError
      = new Dictionary<string, string>()
      {
        { "en", "Lock session error: {0}" },
        { "fr", "Erreur de vérouillage de la session : {0}" }
      };

    static public readonly Dictionary<string, string> CantExitWhileGenerating
      = new Dictionary<string, string>()
      {
        { "en", "Can't exit application while generating data..." },
        { "fr", "Impossible de quitter l'application durant la génération des données..." }
      };

    static public readonly Dictionary<string, string> ProgressLoadingData
      = new Dictionary<string, string>()
      {
        { "en", "Loading data..." },
        { "fr", "Chargement des données..." }
      };

    static public readonly Dictionary<string, string> ProgressCreateDays
      = new Dictionary<string, string>()
      {
        { "en", "Populating days..." },
        { "fr", "Garnissage des jours..." }
      };

    static public readonly Dictionary<string, string> ProgressAnalyzeDays
      = new Dictionary<string, string>()
      {
        { "en", "Analyzing days..." },
        { "fr", "Analyse des jours..." }
      };

    static public readonly Dictionary<string, string> ProgressGenerateReport
      = new Dictionary<string, string>()
      {
        { "en", "Generating report..." },
        { "fr", "Génération du rapport..." }
      };

    static public readonly Dictionary<string, string> ProgressFillMonths
      = new Dictionary<string, string>()
      {
        { "en", "Filling months..." },
        { "fr", "Remplissage des mois..." }
      };

    static public readonly Dictionary<string, string> AskToUseMoonOmer
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to use the moon omer, else the sun?" },
        { "fr", "Voulez-vous utiliser le omer de la lune, sinon du soleil ?" }
      };

    static public readonly Dictionary<string, string> AskToSetupPersonalShabat
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to setup the personal shabat?" },
        { "fr", "Voulez-vous configurer le shabat personnel ?" }
      };

    static public readonly Dictionary<string, string> DateNotFound
      = new Dictionary<string, string>()
      {
        { "en", "Date not found in the database: {0}" },
        { "fr", "Date non trouvée dans la base de données : {0}" }
      };

    static public readonly Dictionary<string, string> SelectBirthday
      = new Dictionary<string, string>()
      {
        { "en", "Birth day" },
        { "fr", "Date de naissance" }
      };

    static public readonly Dictionary<string, string> FirstDay
      = new Dictionary<string, string>()
      {
        { "en", "First day" },
        { "fr", "Premier jour" }
      };

    static public readonly Dictionary<string, string> LastDay
      = new Dictionary<string, string>()
      {
        { "en", "Last day" },
        { "fr", "Dernier jour" }
      };

    static public readonly Dictionary<string, string> DiffDatesSolarCount
      = new Dictionary<string, string>()
      {
        { "en", "Solar days count: {0}" },
        { "fr", "Nombre de jours solaires : {0}" }
      };

    static public readonly Dictionary<string, string> DiffDatesMoonCount
      = new Dictionary<string, string>()
      {
        { "en", "Moon days count: {0}" },
        { "fr", "Nombre de jours lunaires : {0}" }
      };

    static public readonly Dictionary<string, string> DiffDatesMoonOutOfRange
      = new Dictionary<string, string>()
      {
        { "en", "Moon days count: out of range ({0} - {1})" },
        { "fr", "Nombre de jours lunaires : hors limites ({0} - {1})" }
      };

    static public Dictionary<string, List<SuspendDelayItem>> SuspendReminderDelays
      = new Dictionary<string, List<SuspendDelayItem>>
      {
        {
          "en",
          new List<SuspendDelayItem>
          {
            new SuspendDelayItem("None", 0),
            new SuspendDelayItem("5 minutes", 5),
            new SuspendDelayItem("10 minutes", 10),
            new SuspendDelayItem("15 minutes", 15),
            new SuspendDelayItem("30 minutes", 30),
            new SuspendDelayItem("1 hour", 60),
            new SuspendDelayItem("2 hours", 120),
            new SuspendDelayItem("3 hours", 180),
            new SuspendDelayItem("4 hours", 240),
            new SuspendDelayItem("6 hours", 360),
            new SuspendDelayItem("12 hours", 720),
            new SuspendDelayItem("1 day", 1440),
            new SuspendDelayItem("Custom", -1)
          }
        },
        {
          "fr",
          new List<SuspendDelayItem>
          {
            new SuspendDelayItem("Aucun", 0),
            new SuspendDelayItem("5 minutes", 5),
            new SuspendDelayItem("10 minutes", 10),
            new SuspendDelayItem("15 minutes", 15),
            new SuspendDelayItem("30 minutes", 30),
            new SuspendDelayItem("1 heure", 60),
            new SuspendDelayItem("2 heures", 120),
            new SuspendDelayItem("3 heures", 180),
            new SuspendDelayItem("4 heures", 240),
            new SuspendDelayItem("6 heures", 360),
            new SuspendDelayItem("12 heures", 720),
            new SuspendDelayItem("1 jour", 1440),
            new SuspendDelayItem("Personnalisé", -1)
          }
        }
      };

  }

}
