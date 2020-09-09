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

    static public readonly TranslationsDictionary UpgradeResetRequired
      = new TranslationsDictionary
      {
        [Language.EN] = "An upgrade of the settings is required." + Globals.NL +
                        "They will be reseted to default values.",

        [Language.FR] = "Une mise à jour des paramètres est requise." + Globals.NL +
                        "Ils vont être réinialisés à leurs valeurs par défaut."
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

    static public readonly TranslationsDictionary AskToCheckPreferences
      = new TranslationsDictionary
      {
        [Language.EN] = "Check preferences.",
        [Language.FR] = "Vérifiez les préférences."
      };

  }

}
