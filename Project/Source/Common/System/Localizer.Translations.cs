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

    static public readonly NullSafeDictionary<bool, NullSafeOfStringDictionary<Language>> HideRestore
      = new NullSafeDictionary<bool, NullSafeOfStringDictionary<Language>>()
      {
        [true] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Hide",
          [Languages.FR] = "Cacher"
        },
        [false] = new NullSafeOfStringDictionary<Language>
        {
          [Languages.EN] = "Restore",
          [Languages.FR] = "Restaurer"
        }
      };

    static public readonly NullSafeOfStringDictionary<Language> AboutBoxTitle
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "About {0}",
        [Languages.FR] = "À propos de {0}"
      };

    static public readonly NullSafeOfStringDictionary<Language> AboutBoxVersion
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Version {0}",
        [Languages.FR] = "Version {0}"
      };

    static public readonly NullSafeOfStringDictionary<Language> GrammarGuideTitle
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Grammar guide",
        [Languages.FR] = "Guide de grammaire"
      };

    static public readonly NullSafeOfStringDictionary<Language> PrivacyNoticeNoData
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "This software doesn't collect any personal information about you, your computer and your network, unless it is specified by its features.",
        [Languages.FR] = "Ce logiciel ne collecte aucune information personnelle concernant vous-même, votre ordinateur et votre réseau, à moins que cela ne soit indiqué par ses fonctionnalités."
      };

    static public readonly NullSafeOfStringDictionary<Language> MethodNoticeTitle
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Lettriq analysis method notice",
        [Languages.FR] = "Notice de la méthode d'analyse lettrique"
      };

    static public readonly NullSafeOfStringDictionary<Language> NotYetAvailable
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Not yet available.",
        [Languages.FR] = "Pas encore disponible."
      };

    static public readonly NullSafeOfStringDictionary<Language> CheckUpdateFileError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Error in check update file: no version number found or bad format.{Globals.NL2}{{0}}",
        [Languages.FR] = $"Erreur dans le fichier de mise à jour : pas de numéro de version trouvé ou format incorrect.{Globals.NL2}{{0}}"
      };

    static public readonly NullSafeOfStringDictionary<Language> WebCheckUpdate
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Checking update...",
        [Languages.FR] = "Vérification de la la mise à jour..."
      };

    static public readonly NullSafeOfStringDictionary<Language> Initializing
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Initializing...",
        [Languages.FR] = "Initialisation..."
      };

    static public readonly NullSafeOfStringDictionary<Language> Processing
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Processing...",
        [Languages.FR] = "Traitement..."
      };

    static public readonly NullSafeOfStringDictionary<Language> ProgressCreatingData
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Creating data...",
        [Languages.FR] = "Création des données..."
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToContinue
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Do you want to continue?",
        [Languages.FR] = "Voulez-vous continuer ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToDownload
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Do you want to download it?",
        [Languages.FR] = "Voulez-vous le télécharger ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToExitApplication
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Exit application?",
        [Languages.FR] = "Quitter l'application ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToShutdownComputer
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Shutdown the computer?",
        [Languages.FR] = "Arrêter l'ordinateur ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> LockSessionError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Lock session error:{Globals.NL2}{{0}}",
        [Languages.FR] = $"Erreur de vérouillage de la session :{Globals.NL2}{{0}}"
      };

    static public readonly NullSafeOfStringDictionary<Language> UpgradeResetRequired
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "An upgrade of the settings is required." + Globals.NL +
                        "They will be reseted to default values.",

        [Languages.FR] = "Une mise à jour des paramètres est requise." + Globals.NL +
                        "Ils vont être réinialisés à leurs valeurs par défaut."
      };

    static public readonly NullSafeOfStringDictionary<Language> NoNewVersionAvailable
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "There is no new version available.",
        [Languages.FR] = "Il n'y a pas de nouvelle version de disponible."
      };

    static public readonly NullSafeOfStringDictionary<Language> DownloadingNewVersion
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Downloading new version...",
        [Languages.FR] = "Téléchargement de la nouvelle version..."
      };

    static public readonly NullSafeOfStringDictionary<Language> ApplicationMustExit
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "The application must exit.",
        [Languages.FR] = "L'application doit se fermer."
      };

    static public readonly NullSafeOfStringDictionary<Language> ContactSupport
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Please contact support.",
        [Languages.FR] = "Veuillez contacter le support."
      };

    static public readonly NullSafeOfStringDictionary<Language> DatabaseSetDSNError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Error creating or updating SQLite ODBC DSN.",
        [Languages.FR] = "Erreur de création ou de mise à jour du DSN ODBC SQLite."
      };

    static public readonly NullSafeOfStringDictionary<Language> DatabaseIntegrityError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Database integrity error:{Globals.NL2}{{0}}",
        [Languages.FR] = $"Erreur d'intégrité de la base de données :{Globals.NL2}{{0}}"
      };

    static public readonly NullSafeOfStringDictionary<Language> DatabaseVacuumError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Database vacuum failed.",
        [Languages.FR] = "Echec du vacuum de la base de données."
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToCheckParametersAfterDatabaseUpgraded
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Database upgraded." + Globals.NL2 +
                        "Do you want check the parameters?",

        [Languages.FR] = "La base de données a été mise à jour." + Globals.NL2 +
                        "Voulez-vous vérifier les paramètres ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToOptimizeDatabase
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Optimization process will close and reopen the database." + Globals.NL2 +
                         AskToContinue[Languages.EN],

        [Languages.FR] = "Le processus d'optimisation va fermer et rouvrir la base de données." + Globals.NL2 +
                         AskToContinue[Languages.FR]
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToRestoreWindowPosition
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "This action will restore the window position." + Globals.NL2 +
                         AskToContinue[Languages.EN],

        [Languages.FR] = "Cette action va restaurer la position de la fenêtre." + Globals.NL2 +
                         AskToContinue[Languages.FR]
      };

    static public readonly NullSafeOfStringDictionary<Language> ResetPreferences
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Preferences will be reseted to their default values.",
        [Languages.FR] = "Les préférences vont être réinitialisées à leurs valeurs par défaut."
      };


    static public readonly NullSafeOfStringDictionary<Language> AskToResetPreferences
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = ResetPreferences[Languages.EN] + Globals.NL2 + AskToContinue[Languages.EN],
        [Languages.FR] = ResetPreferences[Languages.FR] + Globals.NL2 + AskToContinue[Languages.FR]
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToLoadInstalledData
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "This action will load the data installed with the application." + Globals.NL2 +
                        "All modifications will be lost." + Globals.NL2 +
                        AskToContinue[Languages.EN],

        [Languages.FR] = "Cette action va charger les données installées avec l'application." + Globals.NL2 +
                        "Toutes les modifications seront perdues." + Globals.NL2 +
                        AskToContinue[Languages.FR]
      };

    static public readonly NullSafeOfStringDictionary<Language> NotImplemented
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Not implemented: {0}",
        [Languages.FR] = "Non implémenté : {0}",
      };

    static public readonly NullSafeOfStringDictionary<Language> CallMethodError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Error in {0}.",
        [Languages.FR] = "Erreur dans {0}.",
      };

    static public readonly NullSafeOfStringDictionary<Language> RunSystemManagerError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Error on launching :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
        [Languages.FR] = $"Erreur de lancement :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      };

    static public readonly NullSafeOfStringDictionary<Language> FileNotFound
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"File not found:{Globals.NL2}{{0}}",
        [Languages.FR] = $"Fichier non trouvé :{Globals.NL2}{{0}}"
      };

    static public readonly NullSafeOfStringDictionary<Language> LoadFileError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Error while loading file:{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
        [Languages.FR] = $"Erreur de chargement du fichier :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      };

    static public readonly NullSafeOfStringDictionary<Language> WriteFileError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Error while writing file:{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
        [Languages.FR] = $"Erreur de sauvegarde du fichier :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      };

    static public readonly NullSafeOfStringDictionary<Language> CopyFileError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Error while copying file:{Globals.NL2}{{0}} -> {{1}}{Globals.NL2}{{2}}",
        [Languages.FR] = $"Erreur de copie du fichier :{Globals.NL2}{{0}} -> {{1}}{Globals.NL2}{{2}}",
      };

    static public readonly NullSafeOfStringDictionary<Language> ErrorInFile
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Error in {{0}}{Globals.NL2}Line n° {{1}}{Globals.NL2}{{2}}",
        [Languages.FR] = $"Erreur dans {{0}}{Globals.NL2}Ligne n° {{1}}{Globals.NL2}{{2}}"
      };

    static public readonly NullSafeOfStringDictionary<Language> CreateDBTableError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Error on create table:{Globals.NL2}{{0}}",
        [Languages.FR] = $"Error à la création de la table:{Globals.NL2}{{0}}",
      };

    static public readonly NullSafeOfStringDictionary<Language> CreateDBColumnError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Error on create column:{Globals.NL2}{{0}}",
        [Languages.FR] = $"Error à la création de la colonne:{Globals.NL2}{{0}}",
      };

    static public readonly NullSafeOfStringDictionary<Language> TermNotFound
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Term \"{0}\" not found.",
        [Languages.FR] = "Terme \"{0}\" non trouvé."
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToOpenAllLinks
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Do you want to open all \"{0}\" links?",
        [Languages.FR] = "Voulez-vous ouvrir tous les liens de \"{0}\" ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToCheckPreferences
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Check preferences.",
        [Languages.FR] = "Vérifiez les préférences."
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToDownloadHebrewLetters
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = $"Hebrew Letters not found." + Globals.NL +
                        AskToCheckPreferences[Languages.EN] + Globals.NL2 +
                        AskToDownload[Languages.EN],

        [Languages.FR] = $"Hebrew Letters n'a pas été trouvé." + Globals.NL +
                        AskToCheckPreferences[Languages.FR] + Globals.NL2 +
                        AskToDownload[Languages.FR]
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToDownloadHebrewWords
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Hebrew Words not found." + Globals.NL +
                        AskToCheckPreferences[Languages.EN] + Globals.NL2 +
                        AskToDownload[Languages.EN],

        [Languages.FR] = "Hebrew Words n'a pas été trouvé." + Globals.NL +
                        AskToCheckPreferences[Languages.FR] + Globals.NL2 +
                        AskToDownload[Languages.FR]
      };

    static public readonly NullSafeOfStringDictionary<Language> ConfigureProviders
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Configure providers",
        [Languages.FR] = "Configurer les fournisseurs"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToEmptyHistory
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Empty history?",
        [Languages.FR] = "Vider l'historique ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToEmptyBookmarks
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Empty bookmarks?",
        [Languages.FR] = "Vider les signets?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToDeleteBookmark
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Erase the bookmark?",
        [Languages.FR] = "Effacer le signet ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToDeleteBookmarkAll
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Erase all bookmarks?",
        [Languages.FR] = "Effacer tous les signets ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToReplaceBookmark
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Replace bookmark?",
        [Languages.FR] = "Remplacer le signet ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToClearLogs
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Do you want to delete all log files?",
        [Languages.FR] = "Voulez-vous effacer tous les fichiers de log ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> GitHubIssueComment
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "> Describe here what you did, what you expected and what happened.",
        [Languages.FR] = "> Décrivez ici ce que vous avez fait, ce que vous attendiez et ce qui c'est passé."
      };

    static public readonly NullSafeOfStringDictionary<Language> IndexOutOfRange
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Index out of range in {0}: {1}" + Globals.NL2 +
                        "Must be between {2}} and {3}}.",

        [Languages.FR] = "Index en dehors des limites dans {0}: {1}" + Globals.NL2 +
                        "Doit être entre {2} et {3}."
      };

    static public readonly NullSafeOfStringDictionary<Language> IndexCantBeNegative
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Index can''t be negative in {0}: {1}",
        [Languages.FR] = "Index ne peut pas être négatif dans {0}: {1}"
      };

    static public readonly NullSafeOfStringDictionary<Language> UnhandledException
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Unhandled Exception has occured in {0}" + Globals.NL +
                        "<{1}>" + Globals.NL2 +
                        "{2}",

        [Languages.FR] = "Exception non gérée dans {0}" + Globals.NL +
                        "<{1}>" + Globals.NL2 +
                        "{2}"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToContinueOrTerminate
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "You can choose Yes to continue or No to terminate.",
        [Languages.FR] = "You can choose Yes to continue or No to terminate."
      };

    static public readonly NullSafeOfStringDictionary<Language> NullSlot
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "<null>",
        [Languages.FR] = "<null>"
      };

    static public readonly NullSafeOfStringDictionary<Language> UndefinedSlot
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "<not defined>",
        [Languages.FR] = "<non définit>"
      };

    static public readonly NullSafeOfStringDictionary<Language> EmptySLot
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "<empty>",
        [Languages.FR] = "<empty>"
      };

    static public readonly NullSafeOfStringDictionary<Language> ErrorSlot
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "<error>",
        [Languages.FR] = "<erreur>"
      };


    static public readonly NullSafeOfStringDictionary<Language> TraceLinesCount
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Lines",
        [Languages.FR] = "Lignes"
      };

    static public readonly NullSafeOfStringDictionary<Language> NextException
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Next",
        [Languages.FR] = "Suivante"
      };

    /// <summary>
    /// Indicate the templates to format milliseconds.
    /// </summary>
    static public NullSafeDictionary<Language, NullSafeStringList> MillisecondsFormatTemplates
      = new NullSafeDictionary<Language, NullSafeStringList>
      {
        {
          Languages.EN,
          new NullSafeStringList
          {
            "{4} ms",
            "{3} s",
            "{2} m {3} s",
            "{1} h {2} m {3} s",
            "{0} d {1} h {2} m {3} s",
          }
        },
        {
          Languages.FR,
          new NullSafeStringList
          {
            "{4} ms",
            "{3} s",
            "{2} m {3} s",
            "{1} h {2} m {3} s",
            "{0} j {1} h {2} m {3} s",
          }
        }
      };

  }

}
