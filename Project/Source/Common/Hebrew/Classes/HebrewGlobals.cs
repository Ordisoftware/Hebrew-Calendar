﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2022-04 </edited>
namespace Ordisoftware.Hebrew;

/// <summary>
/// Provides Hebrew global variables.
/// </summary>
static public partial class HebrewGlobals
{

  /// <summary>
  /// Indicates the bible references folder.
  /// </summary>
  static public string BibleReferencesFolderPath
    => Path.Combine(Globals.DocumentsFolderPath, "References");

  /// <summary>
  /// Indicates file path of celebration verses board.
  /// </summary>
  static public string CelebrationVersesFilePath
    => Path.Combine(BibleReferencesFolderPath, "Celebration-Verses.txt");

  /// <summary>
  /// Indicates the application guides folder.
  /// </summary>
  static public string GuidesFolderPath
    => Path.Combine(Globals.DocumentsFolderPath, "Guides");

  /// <summary>
  /// Indicates file path of the Hebrew transcription guide.
  /// </summary>
  static public string TranscriptionGuideFilePath
    => Path.Combine(GuidesFolderPath, "Guide-Transcription-{0}.htm");

  /// <summary>
  /// Indicates file path of the Hebrew grammar guide.
  /// </summary>
  static public string GrammarGuideFilePath
    => Path.Combine(GuidesFolderPath, "Guide-Grammar-{0}.htm");

  /// <summary>
  /// Indicates file path of the lettriq method notice.
  /// </summary>
  static public string LettriqMethodNoticeFilePath
    => Path.Combine(GuidesFolderPath, "Method-Lettriq-{0}.htm");

  /// <summary>
  /// Indicates the parashot factory folder.
  /// </summary>
  static public string ParashotFolderPath
    => Path.Combine(Globals.DocumentsFolderPath, "Parashot");

  /// <summary>
  /// Indicates file path of the parashot factory.
  /// </summary>
  static public string ParashotFactoryFilePath
    => Path.Combine(ParashotFolderPath, "ParashotFactory.txt");

  /// <summary>
  /// Indicates the parashot lettriqs folder.
  /// </summary>
  static public string ParashotTranslationsFilePath
    => Path.Combine(ParashotFolderPath, $"Parashot-Translations-{Languages.Current}.txt");

  /// <summary>
  /// Indicates file path of the parashot lettriqs.
  /// </summary>
  static public string ParashotLettriqsFilePath
    => Path.Combine(ParashotFolderPath, $"Parashot-Lettriqs-{Languages.Current}.txt");

  /// <summary>
  /// Indicates Calendar application code.
  /// </summary>
  static public readonly string AppCodeHebrewCalendar = "hebrew-calendar";

  /// <summary>
  /// Indicates Letters application code.
  /// </summary>
  static public readonly string AppCodeHebrewLetters = "hebrew-letters";

  /// <summary>
  /// Indicates Words application code.
  /// </summary>
  static public readonly string AppCodeHebrewWords = "hebrew-words";

  /// <summary>
  /// Indicates Calendar application name.
  /// </summary>
  static public readonly string AppNameHebrewCalendar = "Hebrew Calendar";

  /// <summary>
  /// Indicates Letters application name.
  /// </summary>
  static public readonly string AppNameHebrewLetters = "Hebrew Letters";

  /// <summary>
  /// Indicates Words application name.
  /// </summary>
  static public readonly string AppNameHebrewWords = "Hebrew Words";

  /// <summary>
  /// Indicates Calendar executable path.
  /// </summary>
  static public Func<string> GetHebrewCalendarExecutablePath { get; set; }

  /// <summary>
  /// Indicates Letters executable path.
  /// </summary>
  static public Func<string> GetHebrewLettersExecutablePath { get; set; }

  /// <summary>
  /// Indicates Words executable path.
  /// </summary>
  static public Func<string> GetHebrewWordsExecutablePath { get; set; }

  /// <summary>
  /// Indicates custom web search pattern.
  /// </summary>
  static public Func<string> GetCustomWebSearchPattern { get; set; }

}
