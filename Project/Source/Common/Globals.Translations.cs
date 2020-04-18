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
/// <created> 2020-03 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static public partial class Globals
  {

    static public string NewLine { get { return Environment.NewLine; } }

    static public readonly Dictionary<string, string> GrammarGuideTitle
      = new Dictionary<string, string>()
      {
        { "en", "Grammar guide" },
        { "fr", "Guide de grammaire" }
      };

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

    static public readonly Dictionary<string, string> NotYetAvailable
      = new Dictionary<string, string>()
      {
        { "en", "Not yet available." },
        { "fr", "Pas encore disponible." }
      };

    static public readonly Dictionary<string, string> AskToExitApplication
      = new Dictionary<string, string>()
      {
        { "en", "Exit application?" },
        { "fr", "Quitter l'application ?" }
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

    static public readonly Dictionary<string, string> AskToDownloadNewVersion
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open the download page?" },
        { "fr", "Voulez-vous ouvrir la page de téléchargement ?" }
      };

    static public readonly Dictionary<string, string> AskToCheckParametersAfterDatabaseUpgraded
      = new Dictionary<string, string>()
      {
        { "en", "Database upgraded." + NewLine + NewLine +
                "Do you want to open the parameters page to check them?" },
        { "fr", "La base de données a été mise à jour." + NewLine + NewLine +
                "Voulez-vous ouvrir la page des paramètres pour les vérifier ?" }
      };

    static public readonly Dictionary<string, string> AskToRestoreWindowPosition
      = new Dictionary<string, string>()
      {
        { "en", "This action will restore windows position." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Cette action va restaurer la position de la fenêtre."  + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> AskToResetPreferences
      = new Dictionary<string, string>()
      {
        { "en", "Preferences will be reseted to their default values." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Les préférences vont être réinitialisées à leurs valeurs par défaut." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> ErrorInFile
      = new Dictionary<string, string>()
      {
        { "en", "Error in {0}" + Environment.NewLine + Environment.NewLine +
                "Line n° {1]" + Environment.NewLine + Environment.NewLine +
                "{2}" },
        { "fr", "Erreur dans {0}" + Environment.NewLine + Environment.NewLine +
                "Ligne n° {1}" + Environment.NewLine + Environment.NewLine +
                "{2}" }
      };

    static public readonly Dictionary<string, string> FileNotFound
      = new Dictionary<string, string>()
      {
        { "en", "File not found: " + NewLine + NewLine + "{0}" },
        { "fr", "Fichier non trouvé :" + NewLine + NewLine + "{0}" }
      };

    static public readonly Dictionary<string, string> TermNotFound
      = new Dictionary<string, string>()
      {
        { "en", "Term \"{0}\" not found." },
        { "fr", "Terme \"{0}\" non trouvé." }
      };

    static public readonly Dictionary<string, string> AskToOpenAllLinks
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open all \"{0}\" links?" },
        { "fr", "Voulez-vous ouvrir tous les liens de \"{0}\" ?" }
      };

    static public readonly Dictionary<string, string> AskToDownloadHebrewLetters
      = new Dictionary<string, string>()
      {
        { "en", "Hebrew Letters not found." + NewLine +
                "Check preferences." + NewLine + NewLine +
                "Do you want to download it?" },
        { "fr", "Hebrew Letters n'a pas été trouvé." + NewLine +
                "Vérifiez les préférences." + NewLine + NewLine +
                "Voulez-vous le télécharger ?" }
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

  }

}