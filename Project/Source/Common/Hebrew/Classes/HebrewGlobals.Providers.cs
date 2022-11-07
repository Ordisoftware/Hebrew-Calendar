/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

/// <summary>
/// Provides Hebrew global variables.
/// </summary>
static partial class HebrewGlobals
{

  /// <summary>
  /// Indicates the application web providers folder.
  /// </summary>
  static public string WebProvidersFolderPath
    => Path.Combine(Globals.DocumentsFolderPath, "WebProviders");

  /// <summary>
  /// Indicates the file path of the online bible text providers.
  /// </summary>
  static public string WebProvidersBibleFilePath
    => Path.Combine(WebProvidersFolderPath, "WebProviders-Bible.txt");

  /// <summary>
  /// Indicates the file path of the online text study celebration providers.
  /// </summary>
  static public string WebProvidersCelebrationTextsFilePath
    => Path.Combine(WebProvidersFolderPath, "WebProviders-Celebration-Texts.txt");

  /// <summary>
  /// Indicates the file path of the online video study celebration providers.
  /// </summary>
  static public string WebProvidersCelebrationVideosFilePath
    => Path.Combine(WebProvidersFolderPath, "WebProviders-Celebration-Videos.txt");

  /// <summary>
  /// Indicates the file path of the online search concordance providers.
  /// </summary>
  static public string WebProvidersConcordanceFilePath
    => Path.Combine(WebProvidersFolderPath, "WebProviders-Concordance.txt");

  /// <summary>
  /// Indicates the file path of the online study parashah providers.
  /// </summary>
  static public string WebProvidersParashahFilePath
    => Path.Combine(WebProvidersFolderPath, "WebProviders-Parashah.txt");

  /// <summary>
  /// Indicates the file path of the online search hebrew word providers.
  /// </summary>
  static public string WebProvidersWordFilePath
    => Path.Combine(WebProvidersFolderPath, "WebProviders-Word.txt");

  /// <summary>
  /// Indicates the online bible text providers.
  /// </summary>
  static public OnlineProviders WebProvidersBible { get; private set; }

  /// <summary>
  /// Indicates the online text study celebration providers.
  /// </summary>
  static public OnlineProviders WebProvidersCelebrationTexts { get; private set; }

  /// <summary>
  /// Indicates the online video study celebration providers.
  /// </summary>
  static public OnlineProviders WebProvidersCelebrationVideos { get; private set; }

  /// <summary>
  /// Indicates the online search concordance providers.
  /// </summary>
  static public OnlineProviders WebProvidersConcordance { get; private set; }

  /// <summary>
  /// Indicates the online study parashah providers.
  /// </summary>
  static public OnlineProviders WebProvidersParashah { get; private set; }

  /// <summary>
  /// Indicates the online search word providers.
  /// </summary>
  static public OnlineProviders WebProvidersWord { get; private set; }

  /// <summary>
  /// Loads the providers files.
  /// </summary>
  static internal void LoadProviders()
  {
    const DataFileFolder folder = DataFileFolder.ApplicationDocuments;
    WebProvidersWord = Globals.CreateOnlineProviders(folder, WebProvidersWordFilePath);
    WebProvidersConcordance = Globals.CreateOnlineProviders(folder, WebProvidersConcordanceFilePath);
    WebProvidersBible = Globals.CreateOnlineProviders(folder, WebProvidersBibleFilePath);
    WebProvidersParashah = Globals.CreateOnlineProviders(folder, WebProvidersParashahFilePath);
    WebProvidersCelebrationTexts = Globals.CreateOnlineProviders(folder, WebProvidersCelebrationTextsFilePath);
    WebProvidersCelebrationVideos = Globals.CreateOnlineProviders(folder, WebProvidersCelebrationVideosFilePath);
    Globals.LoadWebLinksProviders();
  }

}
