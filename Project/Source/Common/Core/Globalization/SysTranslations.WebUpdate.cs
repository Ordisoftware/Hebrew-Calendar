/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2020-09 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Localization strings.
/// </summary>
static public partial class SysTranslations
{

  static public readonly TranslationsDictionary CheckUpdateReadError = new()
  {
    [Language.EN] = $"Error on reading data from server:{Globals.NL2}{{0}}",
    [Language.FR] = $"Erreur lors de la lecture des données depuis le serveur :{Globals.NL2}{{0}}",
  };

  static public readonly TranslationsDictionary CheckUpdateFileError = new()
  {
    [Language.EN] = $"Error in check update file: no version number found or bad format.{Globals.NL2}{{0}}",
    [Language.FR] = $"Erreur dans le fichier de mise à jour : pas de numéro de version trouvé ou format incorrect.{Globals.NL2}{{0}}"
  };

  static public readonly TranslationsDictionary WebCheckUpdate = new()
  {
    [Language.EN] = "Checking update server...",
    [Language.FR] = "Vérification du serveur de mise à jour..."
  };

  static public readonly TranslationsDictionary NoNewVersionAvailable = new()
  {
    [Language.EN] = "There is no new version available.",
    [Language.FR] = "Il n'y a pas de nouvelle version de disponible."
  };

  static public readonly TranslationsDictionary DownloadingNewVersion = new()
  {
    [Language.EN] = "Downloading new version...",
    [Language.FR] = "Téléchargement de la nouvelle version..."
  };

  static public readonly TranslationsDictionary AskToOpenGitHubPage = new()
  {
    [Language.EN] = "Do you want to open the project's GitHub repository?.",
    [Language.FR] = "Voulez-vous ouvrir le dépôt GitHub du projet ?"
  };

}
