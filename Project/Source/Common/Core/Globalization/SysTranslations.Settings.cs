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
/// <edited> 2020-12 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Localization strings.
/// </summary>
static partial class SysTranslations
{

  static public readonly TranslationsDictionary UpgradeResetRequired = new()
  {
    [Language.EN] = "An upgrade of the settings is required." + Globals.NL +
                    "They will be reseted to default values.",

    [Language.FR] = "Une mise à jour des paramètres est requise." + Globals.NL +
                    "Ils vont être réinitialisés à leurs valeurs par défaut."
  };

  static public readonly TranslationsDictionary ResetPreferences = new()
  {
    [Language.EN] = "Preferences will be reseted to their default values.",
    [Language.FR] = "Les préférences vont être réinitialisés à leurs valeurs par défaut."
  };

  static public readonly TranslationsDictionary ResetParameter = new()
  {
    [Language.EN] = "The parameter will be reset to its default value.",
    [Language.FR] = "Le paramètre va être réinitialisé à sa valeur par défaut."
  };

  static public readonly TranslationsDictionary AskToResetPreferences = new()
  {
    [Language.EN] = ResetPreferences[Language.EN] + Globals.NL2 + AskToContinue[Language.EN],
    [Language.FR] = ResetPreferences[Language.FR] + Globals.NL2 + AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary AskToResetParameter = new()
  {
    [Language.EN] = ResetParameter[Language.EN] + Globals.NL2 + AskToContinue[Language.EN],
    [Language.FR] = ResetParameter[Language.FR] + Globals.NL2 + AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary AskToCheckPreferences = new()
  {
    [Language.EN] = "Check preferences.",
    [Language.FR] = "Vérifiez les préférences."
  };

  static public readonly TranslationsDictionary AskToRestoreWindowPosition = new()
  {
    [Language.EN] = "This action will restore the window position." + Globals.NL2 +
                     AskToContinue[Language.EN],

    [Language.FR] = "Cette action va restaurer la position de la fenêtre." + Globals.NL2 +
                     AskToContinue[Language.FR]
  };

}
