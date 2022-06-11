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
/// <edited> 2022-06 </edited>
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

  static public readonly TranslationsDictionary PreviewModeNotice = new()
  {
    [Language.EN] = "If preview mode is enabled, features under development such as the following will be available but only for viewing." + Globals.NL2 +
                    "{0}" + Globals.NL2 +
                    "Data modification is discouraged and any saves may be lost in the final release if the database structure is changed or factory data is updated.",

    [Language.FR] = "Si le mode aperçu est activé, des fonctionnalités en cours de développement telles que les suivantes seront disponibles mais uniquement pour la visualisation." + Globals.NL2 +
                    "{0}" + Globals.NL2 +
                    "La modification des données est déconseillés et toute sauvegarde pourrait être perdue lors de la version finale en cas de changement de la structure de la base de données ou de la mise à jour des données d'usine. "
  };

  static public readonly TranslationsDictionary AskForPreviewMode = new()
  {
    [Language.EN] = PreviewModeNotice[Language.EN] + Globals.NL2 +
                    "Click Yes to continue with this mode." + Globals.NL2 +
                    "Click No to disable it.",

    [Language.FR] = PreviewModeNotice[Language.EN] + Globals.NL2 +
                    "Cliquez sur Oui pour continuer avec ce mode." + Globals.NL2 +
                    "Cliquez sur Non pour le désactiver."
  };

}
