/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
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

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public partial class Localizer
  {

    static public readonly Dictionary<Language, string> LanguageNames
      = new Dictionary<Language, string>
      {
        { Language.English, "en" },
        { Language.French, "fr" }
      };

    static public readonly Dictionary<string, string> AskToExitApplication
      = new Dictionary<string, string>()
      {
        { EN, "Exit application?" },
        { FR, "Quitter l'application ?" }
      };

    static public readonly Dictionary<string, string> AskToShutdownComputer
      = new Dictionary<string, string>()
      {
        { EN, "Shutdown the computer?" },
        { FR, "Arrêter l'ordinateur ?" }
      };

    static public readonly Dictionary<string, string> LockSessionError
      = new Dictionary<string, string>()
      {
        { EN, "Lock session error: {0}" },
        { FR, "Erreur de vérouillage de la session : {0}" }
      };

    static public readonly Dictionary<string, string> AskToContinue
      = new Dictionary<string, string>()
      {
        { EN, "Do you want to continue?" },
        { FR, "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> GrammarGuideTitle
      = new Dictionary<string, string>()
      {
        { EN, "Grammar guide" },
        { FR, "Guide de grammaire" }
      };

    static public readonly Dictionary<string, string> MethodNoticeTitle
      = new Dictionary<string, string>()
      {
        { EN, "Lettriq analysis method notice" },
        { FR, "Notice de la méthode d'analyse lettrique" }
      };

    static public readonly Dictionary<string, string> GitHubIssueComment
      = new Dictionary<string, string>()
      {
        { EN, "> Describe here what you did, what you expected and what happened." },
        { FR, "> Décrivez ici ce que vous avez fait, ce que vous attendiez et ce qui c'est passé." }
      };

    static public readonly Dictionary<string, string> AboutBoxTitle
      = new Dictionary<string, string>()
      {
        { EN, "About {0}" },
        { FR, "À propos de {0}" }
      };

    static public readonly Dictionary<string, string> AboutBoxVersion
      = new Dictionary<string, string>()
      {
        { EN, "Version {0}" },
        { FR, "Version {0}" }
      };

    static public readonly Dictionary<string, string> NotYetAvailable
      = new Dictionary<string, string>()
      {
        { EN, "Not yet available." },
        { FR, "Pas encore disponible." }
      };

    static public readonly Dictionary<string, string> UpgradeResetRequired
      = new Dictionary<string, string>()
      {
        { EN, "An upgrade of the settings is required and they will be reseted to default values." },
        { FR, "Une mise à jour des paramètres est requise et ils vont être réinialisés à leurs valeurs par défaut." }
      };

    static public readonly Dictionary<string, string> NoNewVersionAvailable
      = new Dictionary<string, string>()
      {
        { EN, "There is no new version available." },
        { FR, "Il n'y a pas de nouvelle version de disponible." }
      };

    static public readonly Dictionary<string, string> NewVersionAvailable
      = new Dictionary<string, string>()
      {
        { EN, "A newer version is available : {0}" },
        { FR, "Une nouvelle version est disponible : {0}" }
      };

    static public readonly Dictionary<string, string> DownloadingNewVersion
      = new Dictionary<string, string>()
      {
        { EN, "Downloading new version" },
        { FR, "Téléchargement de la nouvelle version" }
      };

    static public readonly Dictionary<string, string> AskToCheckParametersAfterDatabaseUpgraded
      = new Dictionary<string, string>()
      {
        { EN, "Database upgraded." + NL + NL +
              "Do you want check the parameters?" },
        { FR, "La base de données a été mise à jour." + NL + NL +
              "Voulez-vous vérifier les paramètres ?" }
      };

    static public readonly Dictionary<string, string> AskToOptimizeDatabase
      = new Dictionary<string, string>()
      {
        { EN, "Optimization process will close and reopen the database." + NL + NL +
              AskToContinue[EN] },
        { FR, "Le processus d'optimisation va fermer et rouvrir la base de données." + NL + NL +
              AskToContinue[FR] }
      };

    static public readonly Dictionary<string, string> AskToRestoreWindowPosition
      = new Dictionary<string, string>()
      {
        { EN, "This action will restore the window position." + NL + NL +
              AskToContinue[EN] },
        { FR, "Cette action va restaurer la position de la fenêtre."  + NL + NL +
              AskToContinue[FR] },
      };

    static public readonly Dictionary<string, string> AskToResetPreferences
      = new Dictionary<string, string>()
      {
        { EN, "Preferences will be reseted to their default values." + NL + NL +
              AskToContinue[EN] },
        { FR, "Les préférences vont être réinitialisées à leurs valeurs par défaut." + NL + NL +
              AskToContinue[FR] },
      };

    static public readonly Dictionary<string, string> AskToLoadInstalledData
      = new Dictionary<string, string>()
      {
        { EN, "This action will load the data installed with the application." + NL + NL +
              "All modifications will be lost." + NL + NL +
              AskToContinue[EN] },
        { FR, "Cette action va charger les données installées avec l'application."  + NL + NL +
              "Toutes les modifications seront perdues." + NL + NL +
              AskToContinue[FR] },
      };

    static public readonly Dictionary<string, string> ErrorInFile
      = new Dictionary<string, string>()
      {
        { EN, "Error in {0}" + NL + NL +
              "Line n° {1]" + NL + NL +
              "{2}" },
        { FR, "Erreur dans {0}" + NL + NL +
              "Ligne n° {1}" + NL + NL +
              "{2}" }
      };

    static public readonly Dictionary<string, string> FileNotFound
      = new Dictionary<string, string>()
      {
        { EN, "File not found: " + NL + NL + "{0}" },
        { FR, "Fichier non trouvé :" + NL + NL + "{0}" }
      };

    static public readonly Dictionary<string, string> TermNotFound
      = new Dictionary<string, string>()
      {
        { EN, "Term \"{0}\" not found." },
        { FR, "Terme \"{0}\" non trouvé." }
      };

    static public readonly Dictionary<string, string> AskToOpenAllLinks
      = new Dictionary<string, string>()
      {
        { EN, "Do you want to open all \"{0}\" links?" },
        { FR, "Voulez-vous ouvrir tous les liens de \"{0}\" ?" }
      };

    static public readonly Dictionary<string, string> AskToDownloadHebrewLetters
      = new Dictionary<string, string>()
      {
        { EN, "Hebrew Letters not found." + NL +
              "Check preferences." + NL + NL +
              "Do you want to download it?" },
        { FR, "Hebrew Letters n'a pas été trouvé." + NL +
              "Vérifiez les préférences." + NL + NL +
              "Voulez-vous le télécharger ?" }
      };

    static public readonly Dictionary<string, string> AskToDownloadHebrewWords
      = new Dictionary<string, string>()
      {
        { EN, "Hebrew Words not found." + NL +
              "Check preferences." + NL + NL +
              "Do you want to download it?" },
        { FR, "Hebrew Words n'a pas été trouvé." + NL +
              "Vérifiez les préférences." + NL + NL +
              "Voulez-vous le télécharger ?" }
      };

    static public readonly Dictionary<string, string> ConfigureProviders
      = new Dictionary<string, string>()
      {
        { EN, "Configure providers" },
        { FR, "Configurer les fournisseurs" }
      };

    static public readonly Dictionary<bool, Dictionary<string, string>> HideRestore
      = new Dictionary<bool, Dictionary<string, string>>()
      {
        {
          true, new Dictionary<string, string>
          {
            { EN, "Hide" },
            { FR, "Cacher" }
          }
        },
        {
          false, new Dictionary<string, string>
          {
            { EN, "Restore" },
            { FR, "Restaurer" }
          }
        }
      };

  }

}
