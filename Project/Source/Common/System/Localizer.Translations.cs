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

    static public readonly Dictionary<string, string> EmptySlot
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Not defined" },
        { Languages.FR, "Non définit" }
      };

    static public readonly Dictionary<string, string> Initializing
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Initializing" },
        { Languages.FR, "Initialisation" }
      };

    static public readonly Dictionary<string, string> Processing
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Processing" },
        { Languages.FR, "Traitement" }
      };

    static public readonly Dictionary<string, string> DatabaseIntegrityError
      = new Dictionary<string, string>()
      {
        { Languages.EN, $"Database integrity error:{Globals.NL}{Globals.NL}{0}" },
        { Languages.FR, $"Erreur d'intégrité de la base de données :{Globals.NL}{Globals.NL}{0}" }
      };

    static public readonly Dictionary<string, string> DatabaseVacuumError
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Database vacuum failed." },
        { Languages.FR, "Echec du vacuum de la base de données." }
      };

    static public readonly Dictionary<string, string> AskToExitApplication
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Exit application?" },
        { Languages.FR, "Quitter l'application ?" }
      };

    static public readonly Dictionary<string, string> AskToShutdownComputer
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Shutdown the computer?" },
        { Languages.FR, "Arrêter l'ordinateur ?" }
      };

    static public readonly Dictionary<string, string> LockSessionError
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Lock session error: {0}" },
        { Languages.FR, "Erreur de vérouillage de la session : {0}" }
      };

    static public readonly Dictionary<string, string> AskToContinue
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Do you want to continue?" },
        { Languages.FR, "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> GrammarGuideTitle
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Grammar guide" },
        { Languages.FR, "Guide de grammaire" }
      };

    static public readonly Dictionary<string, string> MethodNoticeTitle
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Lettriq analysis method notice" },
        { Languages.FR, "Notice de la méthode d'analyse lettrique" }
      };

    static public readonly Dictionary<string, string> GitHubIssueComment
      = new Dictionary<string, string>()
      {
        { Languages.EN, "> Describe here what you did, what you expected and what happened." },
        { Languages.FR, "> Décrivez ici ce que vous avez fait, ce que vous attendiez et ce qui c'est passé." }
      };

    static public readonly Dictionary<string, string> AboutBoxTitle
      = new Dictionary<string, string>()
      {
        { Languages.EN, "About {0}" },
        { Languages.FR, "À propos de {0}" }
      };

    static public readonly Dictionary<string, string> AboutBoxVersion
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Version {0}" },
        { Languages.FR, "Version {0}" }
      };

    static public readonly Dictionary<string, string> NotYetAvailable
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Not yet available." },
        { Languages.FR, "Pas encore disponible." }
      };

    static public readonly Dictionary<string, string> UpgradeResetRequired
      = new Dictionary<string, string>()
      {
        { Languages.EN, "An upgrade of the settings is required and they will be reseted to default values." },
        { Languages.FR, "Une mise à jour des paramètres est requise et ils vont être réinialisés à leurs valeurs par défaut." }
      };

    static public readonly Dictionary<string, string> WebCheckUpdate
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Check update" },
        { Languages.FR, "Vérifier la mise à jour" }
      };

    static public readonly Dictionary<string, string> NoNewVersionAvailable
      = new Dictionary<string, string>()
      {
        { Languages.EN, "There is no new version available." },
        { Languages.FR, "Il n'y a pas de nouvelle version de disponible." }
      };

    static public readonly Dictionary<string, string> NewVersionAvailable
      = new Dictionary<string, string>()
      {
        { Languages.EN, "A newer version is available : {0}" },
        { Languages.FR, "Une nouvelle version est disponible : {0}" }
      };

    static public readonly Dictionary<string, string> DownloadingNewVersion
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Downloading new version" },
        { Languages.FR, "Téléchargement de la nouvelle version" }
      };

    static public readonly Dictionary<string, string> AskToCheckParametersAfterDatabaseUpgraded
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Database upgraded." + Globals.NL + Globals.NL +
                        "Do you want check the parameters?" },
        { Languages.FR, "La base de données a été mise à jour." + Globals.NL + Globals.NL +
                        "Voulez-vous vérifier les paramètres ?" }
      };

    static public readonly Dictionary<string, string> AskToOptimizeDatabase
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Optimization process will close and reopen the database." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.EN] },
        { Languages.FR, "Le processus d'optimisation va fermer et rouvrir la base de données." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.FR] }
      };

    static public readonly Dictionary<string, string> AskToRestoreWindowPosition
      = new Dictionary<string, string>()
      {
        { Languages.EN, "This action will restore the window position." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.EN] },
        { Languages.FR, "Cette action va restaurer la position de la fenêtre."  + Globals.NL + Globals.NL +
                        AskToContinue[Languages.FR] },
      };

    static public readonly Dictionary<string, string> AskToResetPreferences
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Preferences will be reseted to their default values." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.EN] },
        { Languages.FR, "Les préférences vont être réinitialisées à leurs valeurs par défaut." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.FR] },
      };

    static public readonly Dictionary<string, string> AskToLoadInstalledData
      = new Dictionary<string, string>()
      {
        { Languages.EN, "This action will load the data installed with the application." + Globals.NL + Globals.NL +
                        "All modifications will be lost." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.EN] },
        { Languages.FR, "Cette action va charger les données installées avec l'application."  + Globals.NL + Globals.NL +
                        "Toutes les modifications seront perdues." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.FR] },
      };

    static public readonly Dictionary<string, string> ErrorInFile
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Error in {0}" + Globals.NL + Globals.NL +
                        "Line n° {1]" + Globals.NL + Globals.NL +
                        "{2}" },
        { Languages.FR, "Erreur dans {0}" + Globals.NL + Globals.NL +
                        "Ligne n° {1}" + Globals.NL + Globals.NL +
                        "{2}" }
      };

    static public readonly Dictionary<string, string> FileNotFound
      = new Dictionary<string, string>()
      {
        { Languages.EN, $"File not found:{Globals.NL}{Globals.NL}{0}" },
        { Languages.FR, $"Fichier non trouvé :{Globals.NL}{Globals.NL}{0}" }
      };

    static public readonly Dictionary<string, string> TermNotFound
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Term \"{0}\" not found." },
        { Languages.FR, "Terme \"{0}\" non trouvé." }
      };

    static public readonly Dictionary<string, string> AskToOpenAllLinks
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Do you want to open all \"{0}\" links?" },
        { Languages.FR, "Voulez-vous ouvrir tous les liens de \"{0}\" ?" }
      };

    static public readonly Dictionary<string, string> AskToDownloadHebrewLetters
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Hebrew Letters not found." + Globals.NL +
                        "Check preferences." + Globals.NL + Globals.NL +
                        "Do you want to download it?" },
        { Languages.FR, "Hebrew Letters n'a pas été trouvé." + Globals.NL +
                        "Vérifiez les préférences." + Globals.NL + Globals.NL +
                        "Voulez-vous le télécharger ?" }
      };

    static public readonly Dictionary<string, string> AskToDownloadHebrewWords
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Hebrew Words not found." + Globals.NL +
                        "Check preferences." + Globals.NL + Globals.NL +
                        "Do you want to download it?" },
        { Languages.FR, "Hebrew Words n'a pas été trouvé." + Globals.NL +
                        "Vérifiez les préférences." + Globals.NL + Globals.NL +
                        "Voulez-vous le télécharger ?" }
      };

    static public readonly Dictionary<string, string> ConfigureProviders
      = new Dictionary<string, string>()
      {
        { Languages.EN, "Configure providers" },
        { Languages.FR, "Configurer les fournisseurs" }
      };

    static public readonly Dictionary<string, string> AskToReplaceBookmark
      = new Dictionary<string, string>
      {
        { Languages.EN, "Replace bookmark?" },
        { Languages.FR, "Remplacer le signet ?" }
      };

    static public readonly Dictionary<string, string> AskToDeleteBookmark
      = new Dictionary<string, string>
      {
        { Languages.EN, "Delete bookmark?" },
        { Languages.FR, "Supprimer le signet ?" }
      };

    static public readonly Dictionary<bool, Dictionary<string, string>> HideRestore
      = new Dictionary<bool, Dictionary<string, string>>()
      {
        {
          true, new Dictionary<string, string>
          {
            { Languages.EN, "Hide" },
            { Languages.FR, "Cacher" }
          }
        },
        {
          false, new Dictionary<string, string>
          {
            { Languages.EN, "Restore" },
            { Languages.FR, "Restaurer" }
          }
        }
      };

  }

}
