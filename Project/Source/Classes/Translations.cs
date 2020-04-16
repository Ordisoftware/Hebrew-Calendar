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

    static public readonly Dictionary<string, string> AboutBoxTitle
      = new Dictionary<string, string>()
      {
        { "en", "About {0}" },
        { "fr", "À propos de {0}" }
      };

    static public readonly Dictionary<string, string> AboutBoxVersion
      = new Dictionary<string, string>()
      {
        { "en", "Version {0}" },
        { "fr", "Version {0}" }
      };

    static public readonly Dictionary<string, string> ApplicationDescription
      = new Dictionary<string, string>()
      {
        { "en", "Generate a hebrew lunisolar calendar with shabat and celebrations reminder" },
        { "fr", "Génère un calendrier luni-solaire hébraïque avec rappel du shabat et des célébrations" }
      };

    static public readonly Dictionary<string, string> ExitApplication
      = new Dictionary<string, string>()
      {
        { "en", "Exit application?" },
        { "fr", "Quitter l'application ?" }
      };

    static public readonly Dictionary<string, string> ShutdownComputer
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

    static public readonly Dictionary<string, string> CantExitApplicationWhileGenerating
      = new Dictionary<string, string>()
      {
        { "en", "Can't exit application while generating data..." },
        { "fr", "Impossible de quitter l'application durant la génération des données..." }
      };

    static public readonly Dictionary<string, string> NoNewVersionAvailable
      = new Dictionary<string, string>()
      {
        { "en", "There is no new version available." },
        { "fr", "Il n'y a pas de nouvelle version de disponible." }
      };

    static public readonly Dictionary<string, string> NewVersionAvailable
      = new Dictionary<string, string>()
      {
        { "en", "A newer version is available : {0}" },
        { "fr", "Une nouvelle version est disponible : {0}" }
      };

    static public readonly Dictionary<string, string> AskDownloadNewVersion
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open the download page?" },
        { "fr", "Voulez-vous ouvrir la page de téléchargement ?" }
      };

    static public readonly Dictionary<string, string> LoadingData
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

    static public readonly Dictionary<string, string> RestoreWinPos
      = new Dictionary<string, string>()
      {
        { "en", "This action will restore windows position." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Cette action va restaurer la position de la fenêtre."  + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> AskToOpenAllLinks
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open all \"{0]\" links?" },
        { "fr", "Voulez-vous ouvrir tous les liens de \"{0}\" ?" }
      };

    static public readonly Dictionary<string, string> ResetPreferences
      = new Dictionary<string, string>()
      {
        { "en", "Preferences will be reseted to their default values." + NewLine +
                "GPS location and shabat day will be keeped." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Les préférences vont être réinitialisées à leurs valeurs par défaut." + NewLine +
                "La position GPS et le jour du shabat seront conservés." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
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

    static public readonly Dictionary<bool, Dictionary<string, string>> HideRestore
      = new Dictionary<bool, Dictionary<string, string>>()
      {
        {
          true, new Dictionary<string, string>
          {
            { "en", "Hide" },
            { "fr", "Cacher" }
          }
        },
        {
          false, new Dictionary<string, string>
          {
            { "en", "Restore" },
            { "fr", "Restaurer" }
          }
        }
      };

    static public readonly Dictionary<string, string> HebrewLettersNotFound
      = new Dictionary<string, string>()
      {
        { "en", "Hebrew Letters not found." + NewLine +
                "Check preferences." + NewLine + NewLine +
                "Do you want to download it?" },
        { "fr", "Hebrew Letters n'a pas été trouvé." + NewLine +
                "Vérifiez les préférences." + NewLine + NewLine +
                "Voulez-vous le télécharger ?" }
      };

    static public readonly Dictionary<string, string> SelectBirthday
      = new Dictionary<string, string>()
      {
        { "en", "Birth day" },
        { "fr", "Date de naissance" }
      };

    static public readonly Dictionary<string, string> DateNotFound
      = new Dictionary<string, string>()
      {
        { "en", "Date not found in the database: {0}" },
        { "fr", "Date non trouvée dans la base de données : {0}" }
      };

    static public readonly Dictionary<string, string> DiffDatesFirst
      = new Dictionary<string, string>()
      {
        { "en", "First day" },
        { "fr", "Premier jour" }
      };

    static public readonly Dictionary<string, string> DiffDatesLast
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

  }

}
