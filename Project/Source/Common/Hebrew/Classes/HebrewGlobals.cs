/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier.
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
/// <edited> 2021-09 </edited>
using System;
using System.IO;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide hebrew global variables.
  /// </summary>
  static partial class HebrewGlobals
  {

    /// <summary>
    /// Indicate the application guides folder.
    /// </summary>
    static public string GuidesFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "Guides");

    /// <summary>
    /// Indicate the bible references folder.
    /// </summary>
    static public string BibleReferencesFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "References");

    /// <summary>
    /// Indicate file path of the celebration verses.
    /// </summary>
    static public string CelebrationVersesFilePath
      => Path.Combine(BibleReferencesFolderPath, "Celebration-Verses.txt");

    /// <summary>
    /// Indicate file path of the hebrew grammar guide.
    /// </summary>
    static public string HebrewGrammarGuideFilePath
      => Path.Combine(GuidesFolderPath, "Guide-Grammar-{0}.htm");

    /// <summary>
    /// Indicate file path of the lettriq method notice.
    /// </summary>
    static public string LettriqMethodNoticeFilePath
      => Path.Combine(GuidesFolderPath, "Method-Lettriq-{0}.htm");

    static public string ParashotFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "Parashot");

    static public string ParashotFactoryFilePath
      => Path.Combine(ParashotFolderPath, "ParashotFactory.txt");

    static public string ParashotTranslationsFilePath
      => Path.Combine(ParashotFolderPath, $"Parashot-Translations-{Languages.Current}.txt");

    static public string ParashotLettriqsFilePath
      => Path.Combine(ParashotFolderPath, $"Parashot-Lettriqs-{Languages.Current}.txt");

  }

}
