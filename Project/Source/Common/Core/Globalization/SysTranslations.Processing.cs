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
/// <edited> 2021-02 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Localization strings.
/// </summary>
static partial class SysTranslations
{

  static public readonly TranslationsDictionary Initializing = new()
  {
    [Language.EN] = "Initializing...",
    [Language.FR] = "Initialisation..."
  };

  static public readonly TranslationsDictionary Processing = new()
  {
    [Language.EN] = "Processing...",
    [Language.FR] = "Traitement..."
  };

  static public readonly TranslationsDictionary Finalizing = new()
  {
    [Language.EN] = "Finalizing...",
    [Language.FR] = "Finalisation..."
  };

  static public readonly TranslationsDictionary LoadingData = new()
  {
    [Language.EN] = "Loading data...",
    [Language.FR] = "Chargement des données..."
  };

  static public readonly TranslationsDictionary CreatingData = new()
  {
    [Language.EN] = "Creating data...",
    [Language.FR] = "Création des données..."
  };

  static public readonly TranslationsDictionary SavingData = new()
  {
    [Language.EN] = "Saving data...",
    [Language.FR] = "Sauvegarde des données..."
  };

}
