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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.IO;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide hebrew tools helper.
  /// </summary>
  static public partial class HebrewTools
  {

    /// <summary>
    /// Start Hebrew Letters process.
    /// </summary>
    /// <param name="hebrew">The hebrew font chars of the word.</param>
    /// <param name="path">Path of the application.</param>
    static public void OpenHebrewLetters(string hebrew, string path)
    {
      if ( !File.Exists(path) )
      {
        if ( DisplayManager.QueryYesNo(HebrewTranslations.AskToDownloadHebrewLetters.GetLang()) )
          SystemManager.RunShell(Globals.AuthorProjectsURL + "/hebrew-letters");
        return;
      }
      hebrew = HebrewAlphabet.SetFinal(hebrew, false);
      if ( hebrew.StartsWith("a ") || hebrew.StartsWith("b ") )
        hebrew = hebrew.Substring(2, hebrew.Length - 2);
      foreach ( string item in hebrew.Split(' ') )
        SystemManager.RunShell(path, item);
    }

  }

}
