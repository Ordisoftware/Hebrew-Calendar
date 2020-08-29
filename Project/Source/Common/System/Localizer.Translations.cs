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

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public partial class Localizer
  {

    static public readonly NullSafeStringDictionary EmptySlot
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Not defined" },
        { Languages.FR, "Non définit" }
      };

    static public readonly NullSafeStringDictionary Initializing
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Initializing" },
        { Languages.FR, "Initialisation" }
      };

    static public readonly NullSafeStringDictionary Processing
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Processing" },
        { Languages.FR, "Traitement" }
      };

    static public readonly NullSafeStringDictionary DatabaseIntegrityError
      = new NullSafeStringDictionary()
      {
        { Languages.EN, $"Database integrity error:{Globals.NL}{Globals.NL}{0}" },
        { Languages.FR, $"Erreur d'intégrité de la base de données :{Globals.NL}{Globals.NL}{0}" }
      };

    static public readonly NullSafeStringDictionary DatabaseVacuumError
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Database vacuum failed." },
        { Languages.FR, "Echec du vacuum de la base de données." }
      };

    static public readonly NullSafeStringDictionary AskToExitApplication
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Exit application?" },
        { Languages.FR, "Quitter l'application ?" }
      };

    static public readonly NullSafeStringDictionary AskToShutdownComputer
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Shutdown the computer?" },
        { Languages.FR, "Arrêter l'ordinateur ?" }
      };

    static public readonly NullSafeStringDictionary LockSessionError
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Lock session error: {0}" },
        { Languages.FR, "Erreur de vérouillage de la session : {0}" }
      };

    static public readonly NullSafeStringDictionary AskToContinue
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Do you want to continue?" },
        { Languages.FR, "Voulez-vous continuer ?" }
      };

    static public readonly NullSafeStringDictionary GrammarGuideTitle
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Grammar guide" },
        { Languages.FR, "Guide de grammaire" }
      };

    static public readonly NullSafeStringDictionary MethodNoticeTitle
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Lettriq analysis method notice" },
        { Languages.FR, "Notice de la méthode d'analyse lettrique" }
      };

    static public readonly NullSafeStringDictionary GitHubIssueComment
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "> Describe here what you did, what you expected and what happened." },
        { Languages.FR, "> Décrivez ici ce que vous avez fait, ce que vous attendiez et ce qui c'est passé." }
      };

    static public readonly NullSafeStringDictionary AboutBoxTitle
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "About {0}" },
        { Languages.FR, "À propos de {0}" }
      };

    static public readonly NullSafeStringDictionary AboutBoxVersion
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Version {0}" },
        { Languages.FR, "Version {0}" }
      };

    static public readonly NullSafeStringDictionary NotYetAvailable
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Not yet available." },
        { Languages.FR, "Pas encore disponible." }
      };

    static public readonly NullSafeStringDictionary UpgradeResetRequired
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "An upgrade of the settings is required and they will be reseted to default values." },
        { Languages.FR, "Une mise à jour des paramètres est requise et ils vont être réinialisés à leurs valeurs par défaut." }
      };

    static public readonly NullSafeStringDictionary WebCheckUpdate
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Check update" },
        { Languages.FR, "Vérifier la mise à jour" }
      };

    static public readonly NullSafeStringDictionary NoNewVersionAvailable
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "There is no new version available." },
        { Languages.FR, "Il n'y a pas de nouvelle version de disponible." }
      };

    static public readonly NullSafeStringDictionary NewVersionAvailable
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "A newer version is available : {0}" },
        { Languages.FR, "Une nouvelle version est disponible : {0}" }
      };

    static public readonly NullSafeStringDictionary DownloadingNewVersion
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Downloading new version" },
        { Languages.FR, "Téléchargement de la nouvelle version" }
      };

    static public readonly NullSafeStringDictionary AskToCheckParametersAfterDatabaseUpgraded
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Database upgraded." + Globals.NL + Globals.NL +
                        "Do you want check the parameters?" },
        { Languages.FR, "La base de données a été mise à jour." + Globals.NL + Globals.NL +
                        "Voulez-vous vérifier les paramètres ?" }
      };

    static public readonly NullSafeStringDictionary AskToOptimizeDatabase
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Optimization process will close and reopen the database." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.EN] },
        { Languages.FR, "Le processus d'optimisation va fermer et rouvrir la base de données." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.FR] }
      };

    static public readonly NullSafeStringDictionary AskToRestoreWindowPosition
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "This action will restore the window position." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.EN] },
        { Languages.FR, "Cette action va restaurer la position de la fenêtre."  + Globals.NL + Globals.NL +
                        AskToContinue[Languages.FR] },
      };

    static public readonly NullSafeStringDictionary AskToResetPreferences
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Preferences will be reseted to their default values." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.EN] },
        { Languages.FR, "Les préférences vont être réinitialisées à leurs valeurs par défaut." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.FR] },
      };

    static public readonly NullSafeStringDictionary AskToLoadInstalledData
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "This action will load the data installed with the application." + Globals.NL + Globals.NL +
                        "All modifications will be lost." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.EN] },
        { Languages.FR, "Cette action va charger les données installées avec l'application."  + Globals.NL + Globals.NL +
                        "Toutes les modifications seront perdues." + Globals.NL + Globals.NL +
                        AskToContinue[Languages.FR] },
      };

    static public readonly NullSafeStringDictionary ErrorInFile
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Error in {0}" + Globals.NL + Globals.NL +
                        "Line n° {1]" + Globals.NL + Globals.NL +
                        "{2}" },
        { Languages.FR, "Erreur dans {0}" + Globals.NL + Globals.NL +
                        "Ligne n° {1}" + Globals.NL + Globals.NL +
                        "{2}" }
      };

    static public readonly NullSafeStringDictionary FileNotFound
      = new NullSafeStringDictionary()
      {
        { Languages.EN, $"File not found:{Globals.NL}{Globals.NL}{0}" },
        { Languages.FR, $"Fichier non trouvé :{Globals.NL}{Globals.NL}{0}" }
      };

    static public readonly NullSafeStringDictionary TermNotFound
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Term \"{0}\" not found." },
        { Languages.FR, "Terme \"{0}\" non trouvé." }
      };

    static public readonly NullSafeStringDictionary AskToOpenAllLinks
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Do you want to open all \"{0}\" links?" },
        { Languages.FR, "Voulez-vous ouvrir tous les liens de \"{0}\" ?" }
      };

    static public readonly NullSafeStringDictionary AskToDownloadHebrewLetters
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Hebrew Letters not found." + Globals.NL +
                        "Check preferences." + Globals.NL + Globals.NL +
                        "Do you want to download it?" },
        { Languages.FR, "Hebrew Letters n'a pas été trouvé." + Globals.NL +
                        "Vérifiez les préférences." + Globals.NL + Globals.NL +
                        "Voulez-vous le télécharger ?" }
      };

    static public readonly NullSafeStringDictionary AskToDownloadHebrewWords
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Hebrew Words not found." + Globals.NL +
                        "Check preferences." + Globals.NL + Globals.NL +
                        "Do you want to download it?" },
        { Languages.FR, "Hebrew Words n'a pas été trouvé." + Globals.NL +
                        "Vérifiez les préférences." + Globals.NL + Globals.NL +
                        "Voulez-vous le télécharger ?" }
      };

    static public readonly NullSafeStringDictionary ConfigureProviders
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Configure providers" },
        { Languages.FR, "Configurer les fournisseurs" }
      };

    static public readonly NullSafeStringDictionary AskToReplaceBookmark
      = new NullSafeStringDictionary
      {
        { Languages.EN, "Replace bookmark?" },
        { Languages.FR, "Remplacer le signet ?" }
      };

    static public readonly NullSafeStringDictionary AskToDeleteBookmark
      = new NullSafeStringDictionary
      {
        { Languages.EN, "Delete bookmark?" },
        { Languages.FR, "Supprimer le signet ?" }
      };

    static public readonly NullSafeDictionary<bool, NullSafeStringDictionary> HideRestore
      = new NullSafeDictionary<bool, NullSafeStringDictionary>()
      {
        {
          true, new NullSafeStringDictionary
          {
            { Languages.EN, "Hide" },
            { Languages.FR, "Cacher" }
          }
        },
        {
          false, new NullSafeStringDictionary
          {
            { Languages.EN, "Restore" },
            { Languages.FR, "Restaurer" }
          }
        }
      };

  }

}
