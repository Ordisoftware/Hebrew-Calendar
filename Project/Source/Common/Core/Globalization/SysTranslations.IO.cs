/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2021-09 </edited>
using System;

#pragma warning disable RCS1214 // Unnecessary interpolated string.
namespace Ordisoftware.Core
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static partial class SysTranslations
  {

    static public readonly TranslationsDictionary RunSystemManagerError = new()
    {
      [Language.EN] = $"Error on launching :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      [Language.FR] = $"Erreur de lancement :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
    };

    static public readonly TranslationsDictionary FileNotFound = new()
    {
      [Language.EN] = $"File not found:{Globals.NL2}{{0}}",
      [Language.FR] = $"Fichier non trouvé :{Globals.NL2}{{0}}"
    };

    static public readonly TranslationsDictionary FileAccessError = new()
    {
      [Language.EN] = $"Error with file:{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      [Language.FR] = $"Erreur avec le fichier :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
    };

    static public readonly TranslationsDictionary NotAnExecutableFile = new()
    {
      [Language.EN] = $"Not an executable file:{Globals.NL2}{{0}}",
      [Language.FR] = $"Le fichier n'est pas un exécutable :{Globals.NL2}{{0}}",
    };

    static public readonly TranslationsDictionary LoadFileSuccess = new()
    {
      [Language.EN] = $"File loaded:{Globals.NL2}{{0}}",
      [Language.FR] = $"Fichier chargé :{Globals.NL2}{{0}}",
    };

    static public readonly TranslationsDictionary LoadFileError = new()
    {
      [Language.EN] = $"Error while loading file:{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      [Language.FR] = $"Erreur de chargement du fichier :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
    };

    static public readonly TranslationsDictionary WriteFileSuccess = new()
    {
      [Language.EN] = $"File saved:{Globals.NL2}{{0}}",
      [Language.FR] = $"Fichier sauvegardé :{Globals.NL2}{{0}}",
    };

    static public readonly TranslationsDictionary WriteFileError = new()
    {
      [Language.EN] = $"Error while writing file:{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      [Language.FR] = $"Erreur de sauvegarde du fichier :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
    };

    static public readonly TranslationsDictionary CopyFileError = new()
    {
      [Language.EN] = $"Error while copying file:{Globals.NL2}{{0}} -> {{1}}{Globals.NL2}{{2}}",
      [Language.FR] = $"Erreur de copie du fichier :{Globals.NL2}{{0}} -> {{1}}{Globals.NL2}{{2}}",
    };

    static public readonly TranslationsDictionary ErrorInFile = new()
    {
      [Language.EN] = $"Error in {{0}}{Globals.NL2}Line n° {{1}}{Globals.NL2}{{2}}",
      [Language.FR] = $"Erreur dans {{0}}{Globals.NL2}Ligne n° {{1}}{Globals.NL2}{{2}}"
    };

    static public readonly TranslationsDictionary WrongSSLCertificate = new()
    {
      [Language.EN] = $"Wrong SSL certificate for {{0}}:{Globals.NL2}" +
                      $"Required:{Globals.NL2}{{1}}{Globals.NL2}" +
                      $"Found:{Globals.NL2}{{2}}{Globals.NL2}" +
                      $"Either there is a problem or it has been updated.",

      [Language.FR] = $"Mauvais certificat SSL pour  {{0}} :{Globals.NL2}" +
                      $"Requis :{Globals.NL2}{{1}}{Globals.NL2}" +
                      $"Trouvé :{Globals.NL2}{{2}}{Globals.NL2}" +
                      $"Soit il y a un problème soit il a été mis à jour."
    };

    static public readonly TranslationsDictionary ExpiredSSLCertificate = new()
    {
      [Language.EN] = $"Expired SSL certificate for {{0}}:{Globals.NL2}" +
                      $"Effective = {{1}}{Globals.NL2}" +
                      $"Expiration = {{2}}",
      [Language.FR] = $"Certificat SSL expiré pour {{0}} :{Globals.NL2}" +
                      $"Effective = {{1}}{Globals.NL2}" +
                      $"Expiration = {{2}}"
    };

    static public readonly TranslationsDictionary WrongFileChecksum = new()
    {
      [Language.EN] = $"Wrong checksum for file:{Globals.NL2}{{0}}",
      [Language.FR] = $"Mauvaise somme de contrôle pour le fichier :{Globals.NL2}{{0}}"
    };

    static public readonly TranslationsDictionary AskToPrintLotsOfPages = new()
    {
      [Language.EN] = "There is {0} page(s)." + Globals.NL2 +
                      AskToContinue[Language.EN],

      [Language.FR] = "Il y a {0} page(s)." + Globals.NL2 +
                      AskToContinue[Language.FR]
    };

    static public readonly TranslationsDictionary AskToSaveLotsOfImages = new()
    {
      [Language.EN] = "There is {0} image(s)." + Globals.NL2 +
                      AskToContinue[Language.EN],

      [Language.FR] = "Il y a {0} image(s)." + Globals.NL2 +
                      AskToContinue[Language.FR]
    };

    static public readonly TranslationsDictionary FileExtensionFilter = new()
    {
      [Language.EN] = "{0} files",
      [Language.FR] = "Fichiers {0}"
    };

    static public readonly TranslationsDictionary AskToSaveChanges = new()
    {
      [Language.EN] = "Save {0} changes?",
      [Language.FR] = "Sauver les modifications de {0} ?"
    };

  }

}
#pragma warning restore RCS1214 // Unnecessary interpolated string.
