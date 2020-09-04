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

  public class TranslationsDictionary : NullSafeOfStringDictionary<Language>
  {
  }

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public partial class Localizer
  {

    static public readonly NullSafeDictionary<bool, TranslationsDictionary> HideRestore
      = new NullSafeDictionary<bool, TranslationsDictionary>()
      {
        [true] = new TranslationsDictionary
        {
          [Language.EN] = "Hide",
          [Language.FR] = "Cacher"
        },
        [false] = new TranslationsDictionary
        {
          [Language.EN] = "Restore",
          [Language.FR] = "Restaurer"
        }
      };

    static public readonly TranslationsDictionary AboutBoxTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "About {0}",
        [Language.FR] = "À propos de {0}"
      };

    static public readonly TranslationsDictionary AboutBoxVersion
      = new TranslationsDictionary
      {
        [Language.EN] = "Version {0}",
        [Language.FR] = "Version {0}"
      };

    static public readonly TranslationsDictionary GrammarGuideTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Grammar guide",
        [Language.FR] = "Guide de grammaire"
      };

    static public readonly TranslationsDictionary PrivacyNoticeNoData
      = new TranslationsDictionary
      {
        [Language.EN] = "This software doesn't collect any personal information about you, your computer and your network, unless it is specified by its features.",
        [Language.FR] = "Ce logiciel ne collecte aucune information personnelle concernant vous-même, votre ordinateur et votre réseau, à moins que cela ne soit indiqué par ses fonctionnalités."
      };

    static public readonly TranslationsDictionary MethodNoticeTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Lettriq analysis method notice",
        [Language.FR] = "Notice de la méthode d'analyse lettrique"
      };

    static public readonly TranslationsDictionary NotYetAvailable
      = new TranslationsDictionary
      {
        [Language.EN] = "Not yet available.",
        [Language.FR] = "Pas encore disponible."
      };

    static public readonly TranslationsDictionary CheckUpdateFileError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error in check update file: no version number found or bad format.{Globals.NL2}{{0}}",
        [Language.FR] = $"Erreur dans le fichier de mise à jour : pas de numéro de version trouvé ou format incorrect.{Globals.NL2}{{0}}"
      };

    static public readonly TranslationsDictionary WebCheckUpdate
      = new TranslationsDictionary
      {
        [Language.EN] = "Checking update...",
        [Language.FR] = "Vérification de la la mise à jour..."
      };

    static public readonly TranslationsDictionary Initializing
      = new TranslationsDictionary
      {
        [Language.EN] = "Initializing...",
        [Language.FR] = "Initialisation..."
      };

    static public readonly TranslationsDictionary Processing
      = new TranslationsDictionary
      {
        [Language.EN] = "Processing...",
        [Language.FR] = "Traitement..."
      };

    static public readonly TranslationsDictionary ProgressCreatingData
      = new TranslationsDictionary
      {
        [Language.EN] = "Creating data...",
        [Language.FR] = "Création des données..."
      };

    static public readonly TranslationsDictionary AskToContinue
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to continue?",
        [Language.FR] = "Voulez-vous continuer ?"
      };

    static public readonly TranslationsDictionary AskToDownload
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to download it?",
        [Language.FR] = "Voulez-vous le télécharger ?"
      };

    static public readonly TranslationsDictionary AskToExitApplication
      = new TranslationsDictionary
      {
        [Language.EN] = "Exit application?",
        [Language.FR] = "Quitter l'application ?"
      };

    static public readonly TranslationsDictionary AskToShutdownComputer
      = new TranslationsDictionary
      {
        [Language.EN] = "Shutdown the computer?",
        [Language.FR] = "Arrêter l'ordinateur ?"
      };

    static public readonly TranslationsDictionary LockSessionError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Lock session error:{Globals.NL2}{{0}}",
        [Language.FR] = $"Erreur de vérouillage de la session :{Globals.NL2}{{0}}"
      };

    static public readonly TranslationsDictionary UpgradeResetRequired
      = new TranslationsDictionary
      {
        [Language.EN] = "An upgrade of the settings is required." + Globals.NL +
                        "They will be reseted to default values.",

        [Language.FR] = "Une mise à jour des paramètres est requise." + Globals.NL +
                        "Ils vont être réinialisés à leurs valeurs par défaut."
      };

    static public readonly TranslationsDictionary NoNewVersionAvailable
      = new TranslationsDictionary
      {
        [Language.EN] = "There is no new version available.",
        [Language.FR] = "Il n'y a pas de nouvelle version de disponible."
      };

    static public readonly TranslationsDictionary DownloadingNewVersion
      = new TranslationsDictionary
      {
        [Language.EN] = "Downloading new version...",
        [Language.FR] = "Téléchargement de la nouvelle version..."
      };

    static public readonly TranslationsDictionary ApplicationMustExit
      = new TranslationsDictionary
      {
        [Language.EN] = "The application must exit.",
        [Language.FR] = "L'application doit se fermer."
      };

    static public readonly TranslationsDictionary ContactSupport
      = new TranslationsDictionary
      {
        [Language.EN] = "Please contact support.",
        [Language.FR] = "Veuillez contacter le support."
      };

    static public readonly TranslationsDictionary DatabaseSetDSNError
      = new TranslationsDictionary
      {
        [Language.EN] = "Error creating or updating SQLite ODBC DSN.",
        [Language.FR] = "Erreur de création ou de mise à jour du DSN ODBC SQLite."
      };

    static public readonly TranslationsDictionary DatabaseIntegrityError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Database integrity error:{Globals.NL2}{{0}}",
        [Language.FR] = $"Erreur d'intégrité de la base de données :{Globals.NL2}{{0}}"
      };

    static public readonly TranslationsDictionary DatabaseVacuumError
      = new TranslationsDictionary
      {
        [Language.EN] = "Database vacuum failed.",
        [Language.FR] = "Echec du vacuum de la base de données."
      };

    static public readonly TranslationsDictionary AskToCheckParametersAfterDatabaseUpgraded
      = new TranslationsDictionary
      {
        [Language.EN] = "Database upgraded." + Globals.NL2 +
                        "Do you want check the parameters?",

        [Language.FR] = "La base de données a été mise à jour." + Globals.NL2 +
                        "Voulez-vous vérifier les paramètres ?"
      };

    static public readonly TranslationsDictionary AskToOptimizeDatabase
      = new TranslationsDictionary
      {
        [Language.EN] = "Optimization process will close and reopen the database." + Globals.NL2 +
                         AskToContinue[Language.EN],

        [Language.FR] = "Le processus d'optimisation va fermer et rouvrir la base de données." + Globals.NL2 +
                         AskToContinue[Language.FR]
      };

    static public readonly TranslationsDictionary AskToRestoreWindowPosition
      = new TranslationsDictionary
      {
        [Language.EN] = "This action will restore the window position." + Globals.NL2 +
                         AskToContinue[Language.EN],

        [Language.FR] = "Cette action va restaurer la position de la fenêtre." + Globals.NL2 +
                         AskToContinue[Language.FR]
      };

    static public readonly TranslationsDictionary ResetPreferences
      = new TranslationsDictionary
      {
        [Language.EN] = "Preferences will be reseted to their default values.",
        [Language.FR] = "Les préférences vont être réinitialisées à leurs valeurs par défaut."
      };


    static public readonly TranslationsDictionary AskToResetPreferences
      = new TranslationsDictionary
      {
        [Language.EN] = ResetPreferences[Language.EN] + Globals.NL2 + AskToContinue[Language.EN],
        [Language.FR] = ResetPreferences[Language.FR] + Globals.NL2 + AskToContinue[Language.FR]
      };

    static public readonly TranslationsDictionary AskToLoadInstalledData
      = new TranslationsDictionary
      {
        [Language.EN] = "This action will load the data installed with the application." + Globals.NL2 +
                        "All modifications will be lost." + Globals.NL2 +
                        AskToContinue[Language.EN],

        [Language.FR] = "Cette action va charger les données installées avec l'application." + Globals.NL2 +
                        "Toutes les modifications seront perdues." + Globals.NL2 +
                        AskToContinue[Language.FR]
      };

    static public readonly TranslationsDictionary NotImplemented
      = new TranslationsDictionary
      {
        [Language.EN] = "Not implemented: {0}",
        [Language.FR] = "Non implémenté : {0}",
      };

    static public readonly TranslationsDictionary CallMethodError
      = new TranslationsDictionary
      {
        [Language.EN] = "Error in {0}.",
        [Language.FR] = "Erreur dans {0}.",
      };

    static public readonly TranslationsDictionary RunSystemManagerError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error on launching :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
        [Language.FR] = $"Erreur de lancement :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      };

    static public readonly TranslationsDictionary FileNotFound
      = new TranslationsDictionary
      {
        [Language.EN] = $"File not found:{Globals.NL2}{{0}}",
        [Language.FR] = $"Fichier non trouvé :{Globals.NL2}{{0}}"
      };

    static public readonly TranslationsDictionary LoadFileError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error while loading file:{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
        [Language.FR] = $"Erreur de chargement du fichier :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      };

    static public readonly TranslationsDictionary WriteFileError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error while writing file:{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
        [Language.FR] = $"Erreur de sauvegarde du fichier :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      };

    static public readonly TranslationsDictionary CopyFileError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error while copying file:{Globals.NL2}{{0}} -> {{1}}{Globals.NL2}{{2}}",
        [Language.FR] = $"Erreur de copie du fichier :{Globals.NL2}{{0}} -> {{1}}{Globals.NL2}{{2}}",
      };

    static public readonly TranslationsDictionary ErrorInFile
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error in {{0}}{Globals.NL2}Line n° {{1}}{Globals.NL2}{{2}}",
        [Language.FR] = $"Erreur dans {{0}}{Globals.NL2}Ligne n° {{1}}{Globals.NL2}{{2}}"
      };

    static public readonly TranslationsDictionary CreateDBTableError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error on create table:{Globals.NL2}{{0}}",
        [Language.FR] = $"Error à la création de la table:{Globals.NL2}{{0}}",
      };

    static public readonly TranslationsDictionary CreateDBColumnError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error on create column:{Globals.NL2}{{0}}",
        [Language.FR] = $"Error à la création de la colonne:{Globals.NL2}{{0}}",
      };

    static public readonly TranslationsDictionary TermNotFound
      = new TranslationsDictionary
      {
        [Language.EN] = "Term \"{0}\" not found.",
        [Language.FR] = "Terme \"{0}\" non trouvé."
      };

    static public readonly TranslationsDictionary AskToOpenAllLinks
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to open all \"{0}\" links?",
        [Language.FR] = "Voulez-vous ouvrir tous les liens de \"{0}\" ?"
      };

    static public readonly TranslationsDictionary AskToCheckPreferences
      = new TranslationsDictionary
      {
        [Language.EN] = "Check preferences.",
        [Language.FR] = "Vérifiez les préférences."
      };

    static public readonly TranslationsDictionary AskToDownloadHebrewLetters
      = new TranslationsDictionary
      {
        [Language.EN] = $"Hebrew Letters not found." + Globals.NL +
                        AskToCheckPreferences[Language.EN] + Globals.NL2 +
                        AskToDownload[Language.EN],

        [Language.FR] = $"Hebrew Letters n'a pas été trouvé." + Globals.NL +
                        AskToCheckPreferences[Language.FR] + Globals.NL2 +
                        AskToDownload[Language.FR]
      };

    static public readonly TranslationsDictionary AskToDownloadHebrewWords
      = new TranslationsDictionary
      {
        [Language.EN] = "Hebrew Words not found." + Globals.NL +
                        AskToCheckPreferences[Language.EN] + Globals.NL2 +
                        AskToDownload[Language.EN],

        [Language.FR] = "Hebrew Words n'a pas été trouvé." + Globals.NL +
                        AskToCheckPreferences[Language.FR] + Globals.NL2 +
                        AskToDownload[Language.FR]
      };

    static public readonly TranslationsDictionary ConfigureProviders
      = new TranslationsDictionary
      {
        [Language.EN] = "Configure providers",
        [Language.FR] = "Configurer les fournisseurs"
      };

    static public readonly TranslationsDictionary AskToEmptyHistory
      = new TranslationsDictionary
      {
        [Language.EN] = "Empty history?",
        [Language.FR] = "Vider l'historique ?"
      };

    static public readonly TranslationsDictionary AskToEmptyBookmarks
      = new TranslationsDictionary
      {
        [Language.EN] = "Empty bookmarks?",
        [Language.FR] = "Vider les signets?"
      };

    static public readonly TranslationsDictionary AskToDeleteBookmark
      = new TranslationsDictionary
      {
        [Language.EN] = "Erase the bookmark?",
        [Language.FR] = "Effacer le signet ?"
      };

    static public readonly TranslationsDictionary AskToDeleteBookmarkAll
      = new TranslationsDictionary
      {
        [Language.EN] = "Erase all bookmarks?",
        [Language.FR] = "Effacer tous les signets ?"
      };

    static public readonly TranslationsDictionary AskToReplaceBookmark
      = new TranslationsDictionary
      {
        [Language.EN] = "Replace bookmark?",
        [Language.FR] = "Remplacer le signet ?"
      };

    static public readonly TranslationsDictionary AskToClearLogs
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to delete all log files?",
        [Language.FR] = "Voulez-vous effacer tous les fichiers de log ?"
      };

    static public readonly TranslationsDictionary GitHubIssueComment
      = new TranslationsDictionary
      {
        [Language.EN] = "> Describe here what you did, what you expected and what happened.",
        [Language.FR] = "> Décrivez ici ce que vous avez fait, ce que vous attendiez et ce qui c'est passé."
      };

    static public readonly TranslationsDictionary IndexOutOfRange
      = new TranslationsDictionary
      {
        [Language.EN] = "Index out of range in {0}: {1}" + Globals.NL2 +
                        "Must be between {2}} and {3}}.",

        [Language.FR] = "Index en dehors des limites dans {0}: {1}" + Globals.NL2 +
                        "Doit être entre {2} et {3}."
      };

    static public readonly TranslationsDictionary IndexCantBeNegative
      = new TranslationsDictionary
      {
        [Language.EN] = "Index can''t be negative in {0}: {1}",
        [Language.FR] = "Index ne peut pas être négatif dans {0}: {1}"
      };

    static public readonly TranslationsDictionary UnhandledException
      = new TranslationsDictionary
      {
        [Language.EN] = "Unhandled Exception has occured in {0}" + Globals.NL +
                        "<{1}>" + Globals.NL2 +
                        "{2}",

        [Language.FR] = "Exception non gérée dans {0}" + Globals.NL +
                        "<{1}>" + Globals.NL2 +
                        "{2}"
      };

    static public readonly TranslationsDictionary AskToContinueOrTerminate
      = new TranslationsDictionary
      {
        [Language.EN] = "You can choose Yes to continue or No to terminate.",
        [Language.FR] = "You can choose Yes to continue or No to terminate."
      };

    static public readonly TranslationsDictionary NullSlot
      = new TranslationsDictionary
      {
        [Language.EN] = "<null>",
        [Language.FR] = "<null>"
      };

    static public readonly TranslationsDictionary UndefinedSlot
      = new TranslationsDictionary
      {
        [Language.EN] = "<not defined>",
        [Language.FR] = "<non définit>"
      };

    static public readonly TranslationsDictionary EmptySLot
      = new TranslationsDictionary
      {
        [Language.EN] = "<empty>",
        [Language.FR] = "<empty>"
      };

    static public readonly TranslationsDictionary ErrorSlot
      = new TranslationsDictionary
      {
        [Language.EN] = "<error>",
        [Language.FR] = "<erreur>"
      };


    static public readonly TranslationsDictionary TraceLinesCount
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} lines",
        [Language.FR] = "{0} lignes"
      };

    static public readonly TranslationsDictionary NextException
      = new TranslationsDictionary
      {
        [Language.EN] = "Next",
        [Language.FR] = "Suivante"
      };

    static public NullSafeDictionary<Language, NullSafeStringList> MillisecondsFormat
      = new NullSafeDictionary<Language, NullSafeStringList>
      {
        [Language.EN] = new NullSafeStringList
          {
            "{4} ms",
            "{3} s",
            "{2} m {3} s",
            "{1} h {2} m {3} s",
            "{0} d {1} h {2} m {3} s",
          },
        [Language.FR] =
          new NullSafeStringList
          {
            "{4} ms",
            "{3} s",
            "{2} m {3} s",
            "{1} h {2} m {3} s",
            "{0} j {1} h {2} m {3} s",
          }
      };

  }

}