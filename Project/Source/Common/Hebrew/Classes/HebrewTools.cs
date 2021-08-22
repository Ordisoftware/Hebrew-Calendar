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
/// <edited> 2021-08 </edited>
using System;
using System.Linq;
using System.IO;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide hebrew tools.
  /// </summary>
  static partial class HebrewTools
  {

    /// <summary>
    /// Start Hebrew Letters.
    /// </summary>
    /// <param name="word">The unicode or hebrew font chars of the word.</param>
    /// <param name="path">Path of the application.</param>
    static public void OpenHebrewLetters(string word, string path)
    {
      if ( !File.Exists(path) )
      {
        if ( DisplayManager.QueryYesNo(HebrewTranslations.AskToDownloadHebrewLetters.GetLang()) )
          SystemManager.RunShell(Globals.AuthorProjectsURL + "/hebrew-letters");
        return;
      }
      word = Localizer.RemoveDiacritics(word);
      bool isUnicode = HebrewAlphabet.ContainsUnicode(word);
      if ( isUnicode && ( word.EndsWith(" א") || word.EndsWith(" ב") ) )
        word = word.Remove(word.Length - 2);
      else
      if ( word.StartsWith("a ") || word.StartsWith("b ") )
        word = word.Remove(0, 2);
      var items = word.Split(' ');
      if ( isUnicode ) items = items.Reverse().ToArray();
      foreach ( string item in items )
      {
        SystemManager.RunShell(path, item);
        System.Threading.Thread.Sleep(250);
      }
    }

    /// <summary>
    /// Start Hebrew Words.
    /// </summary>
    static public void OpenHebrewWordsGoToVerse(string reference, string path)
    {
      if ( !File.Exists(path) )
      {
        if ( DisplayManager.QueryYesNo(HebrewTranslations.AskToDownloadHebrewWords.GetLang()) )
          SystemManager.RunShell(Globals.AuthorProjectsURL + "/hebrew-words");
        return;
      }
      SystemManager.RunShell(path, "--verse " + reference);
    }

    /// <summary>
    /// Start Hebrew Words.
    /// </summary>
    static public void OpenHebrewWordsSearchWord(string word, string path)
    {
      if ( !File.Exists(path) )
      {
        if ( DisplayManager.QueryYesNo(HebrewTranslations.AskToDownloadHebrewWords.GetLang()) )
          SystemManager.RunShell(Globals.AuthorProjectsURL + "/hebrew-words");
        return;
      }
      SystemManager.RunShell(path, "--word " + word);
    }

    /// <summary>
    /// Start Hebrew Words.
    /// </summary>
    static public void OpenHebrewWordsSearchTranslated(string word, string path)
    {
      if ( !File.Exists(path) )
      {
        if ( DisplayManager.QueryYesNo(HebrewTranslations.AskToDownloadHebrewWords.GetLang()) )
          SystemManager.RunShell(Globals.AuthorProjectsURL + "/hebrew-words");
        return;
      }
      SystemManager.RunShell(path, "--translated " + word);
    }

    /// <summary>
    /// Open online word provider.
    /// </summary>
    /// <param name="link"></param>
    /// <param name="hebrew"></param>
    static public void OpenWordProvider(string link, string hebrew)
    {
      if ( hebrew.Length > 1 ) hebrew = HebrewAlphabet.SetFinal(hebrew, true);
      string unicode = HebrewAlphabet.ToUnicode(hebrew);
      link = link.Replace("%WORD%", unicode)
                 .Replace("%FIRSTLETTER%", unicode[0].ToString());
      SystemManager.RunShell(link);
    }

    /// <summary>
    /// Open online bible provider.
    /// </summary>
    static public void OpenBibleProvider(string url, string reference)
    {
      int[] list = reference.Split('.').Select(int.Parse).ToArray();
      OpenBibleProvider(url, list[0], list[1], list[2]);
    }

    /// <summary>
    /// Open online bible provider.
    /// </summary>
    static public void OpenBibleProvider(string url, int book, int chapter, int verse)
    {
      int bookchabad = BooksNames.Chabad[(Books)book] + chapter - 1;
      if ( url.Contains("%BOOKSEFARIA%") )
        url = url.Replace("%BOOKSEFARIA%", BooksNames.StudyBible[(Books)book]
                                                     .Replace("1", "I")
                                                     .Replace("2", "II")
                                                     .Replace(" ", "_"))
                 .Replace("%CHAPTERNUM%", chapter.ToString())
                 .Replace("%VERSENUM%", verse.ToString());
      else
        url = url.Replace("%BOOKSB%", BooksNames.StudyBible[(Books)book])
                 .Replace("%BOOKBIBLEHUB%", BooksNames.BibleHub[(Books)book])
                 .Replace("%BOOKCHABAD%", bookchabad.ToString())
                 .Replace("%BOOKMM%", BooksNames.MechonMamre[(Books)book])
                 .Replace("%BOOKDJEP%", BooksNames.Djep[(Books)book])
                 .Replace("%BOOKLE%", BooksNames.LEvangile[(Books)book])
                 .Replace("%BOOKNUM%", book.ToString())
                 .Replace("%CHAPTERNUM%", chapter.ToString())
                 .Replace("%VERSENUM%", verse.ToString())
                 .Replace("%BOOKNUM#2%", book.ToString("00"))
                 .Replace("%CHAPTERNUM#2%", chapter.ToString("00"))
                 .Replace("%VERSENUM#2%", verse.ToString("00"));

      SystemManager.RunShell(url);
    }

    /// <summary>
    /// Open online parashah provider.
    /// </summary>
    static public void OpenParashahProvider(string url, Parashah parashah, bool openLinked = false)
    {
      if ( parashah == null )
      {
        DisplayManager.Show(HebrewTranslations.ParashahNotFound.GetLang());
        return;
      }
      open(parashah);
      if ( openLinked && url.Contains("%") )
      {
        var linked = parashah.GetLinked();
        if ( linked != null ) open(linked);
      }
      //
      void open(Parashah item)
      {
        string link = url.Replace("%TORAHBOX%", OnlineParashot.TorahBox[item.Book][item.Number - 1])
                         .Replace("%TORAHORG%", OnlineParashot.TorahOrg[item.Book][item.Number - 1])
                         .Replace("%TORAHJEWS%", OnlineParashot.TorahJews[item.Book][item.Number - 1])
                         .Replace("%CHABAD-EN%", OnlineParashot.ChabadEN[item.Book][item.Number - 1])
                         .Replace("%CHABAD-FR%", OnlineParashot.ChabadFR[item.Book][item.Number - 1])
                         .Replace("%WIKIPEDIA-EN%", OnlineParashot.WikipediaEN[item.Book][item.Number - 1])
                         .Replace("%WIKIPEDIA-FR%", OnlineParashot.WikipediaFR[item.Book][item.Number - 1])
                         .Replace("%AISH-EN%", OnlineParashot.AishEN[item.Book][item.Number - 1])
                         .Replace("%AISH-FR%", OnlineParashot.AishFR[item.Book][item.Number - 1])
                         .Replace("%AISH-IW%", OnlineParashot.AishIW[item.Book][item.Number - 1]);
        SystemManager.OpenWebLink(link);
      }
    }

  }

}
