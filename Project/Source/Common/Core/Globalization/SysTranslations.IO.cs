/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
using System;

namespace Ordisoftware.Core
{


  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public partial class SysTranslations
  {

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

    static public readonly TranslationsDictionary FileAccessError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Error with file:{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
        [Language.FR] = $"Erreur avec le fichier :{Globals.NL2}{{0}}{Globals.NL2}{{1}}",
      };

    static public readonly TranslationsDictionary NotAnExecutableFile
      = new TranslationsDictionary
      {
        [Language.EN] = $"Not an executable file:{Globals.NL2}{{0}}",
        [Language.FR] = $"Le fichier n'est pas un exécutable :{Globals.NL2}{{0}}",
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

    static public readonly TranslationsDictionary WrongFileChecksum
      = new TranslationsDictionary
      {
        [Language.EN] = $"Wrong checksum for file:{Globals.NL2}{{0}}",
        [Language.FR] = $"Mauvaise somme de contrôle pour le fichier :{Globals.NL2}{{0}}"
      };    

  }

}
