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
/// <edited> 2021-02 </edited>
using System;
using System.Linq;
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
      hebrew = HebrewAlphabet.UnFinalAll(hebrew);
      if ( hebrew.StartsWith("a ") || hebrew.StartsWith("b ") )
        hebrew = hebrew.Substring(2, hebrew.Length - 2);
      foreach ( string item in hebrew.Split(' ') )
        SystemManager.RunShell(path, item);
    }

    /// <summary>
    /// Start Hebrew Words process.
    /// </summary>
    /// <param name="reference">The verse reference.</param>
    /// <param name="path">Path of the application.</param>
    static public void OpenHebrewWords(string reference, string path)
    {
      if ( !File.Exists(path) )
      {
        if ( DisplayManager.QueryYesNo(HebrewTranslations.AskToDownloadHebrewWords.GetLang()) )
          SystemManager.RunShell(Globals.AuthorProjectsURL + "/hebrew-words");
        return;
      }
      SystemManager.RunShell(path, "-r " + reference);
    }

    /// <summary>
    /// Open default online verse search url.
    /// </summary>
    static public void OpenOnlineVerse(string url, string reference)
    {
      int[] list = reference.Split('.').Select(int.Parse).ToArray();
      OpenOnlineVerse(url, list[0], list[1], list[2]);
    }

    /// <summary>
    /// Open default online verse search url.
    /// </summary>
    static public void OpenOnlineVerse(string url, int book, int chapter, int verse)
    {
      int bookchabad = BooksNames.Chabad[(Books)( book - 1 )] + chapter - 1;
      if ( url.Contains("%BOOKSEFARIA%") )
        url = url.Replace("%BOOKSEFARIA%", BooksNames.StudyBible[(Books)( book - 1 )]
                                                     .Replace("1", "I")
                                                     .Replace("2", "II")
                                                     .Replace(" ", "_"))
                 .Replace("%CHAPTERNUM%", chapter.ToString())
                 .Replace("%VERSENUM%", verse.ToString());
      else
        url = url.Replace("%BOOKSB%", BooksNames.StudyBible[(Books)( book - 1 )])
                 .Replace("%BOOKBIBLEHUB%", BooksNames.BibleHub[(Books)( book - 1 )])
                 .Replace("%BOOKCHABAD%", bookchabad.ToString())
                 .Replace("%BOOKMM%", BooksNames.MechonMamre[(Books)( book - 1 )])
                 .Replace("%BOOKDJEP%", BooksNames.Djep[(Books)( book - 1 )])
                 .Replace("%BOOKLE%", BooksNames.LEvangile[(Books)( book - 1 )])
                 .Replace("%BOOKNUM%", book.ToString())
                 .Replace("%CHAPTERNUM%", chapter.ToString())
                 .Replace("%VERSENUM%", verse.ToString())
                 .Replace("%BOOKNUM#2%", book.ToString("00"))
                 .Replace("%CHAPTERNUM#2%", chapter.ToString("00"))
                 .Replace("%VERSENUM#2%", verse.ToString("00"));

      SystemManager.RunShell(url);
    }

  }

}
