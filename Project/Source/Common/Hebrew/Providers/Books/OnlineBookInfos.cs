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
/// <created> 2019-09 </created>
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

static partial class OnlineBookInfos
{

  static public string GetUrl(string pattern, int book, int chapter, int verse)
  {
    string chapterString = chapter.ToString();
    if ( pattern.Contains("%BOOKMM%") && chapter >= 100 )
    {
      int dizaine = ( chapter - 100 ) / 10;
      char centaine = 'a';
      centaine += (char)dizaine;
      chapterString = centaine.ToString() + ( chapter - 100 - dizaine * 10 ).ToString();
      pattern = pattern.Replace("%CHAPTERNUM#2%", "%CHAPTERNUM%");
    }
    var dispatch = new Dictionary<string, string>()
    {
      { "%BOOKBIBLEHUB%", BibleHub[(TanakBook)book] },
      { "%BOOKCHABAD%", ( Chabad[(TanakBook)book] + chapter - 1 ).ToString() },
      { "%BOOKDJEP%", Djep[(TanakBook)book] },
      { "%BOOKLE%", LEvangile[(TanakBook)book] },
      { "%BOOKMM%", MechonMamre[(TanakBook)book] },
      { "%BOOKNUM#2%", book.ToString("00") },
      { "%BOOKNUM%", book.ToString() },
      { "%BOOKSB%", StudyBible[(TanakBook)book] },
      { "%BOOKSEFARIA%", Sefaria[(TanakBook)book] },
      { "%BOOKTORAHBOX%", TorahBox[(TanakBook)book] },
      { "%CHAPTERNUM#2%", chapter.ToString("00") },
      { "%CHAPTERNUM%", chapterString },
      { "%VERSENUM#2%", verse.ToString("00") },
      { "%VERSENUM%", verse.ToString() }
    };
    foreach ( var item in dispatch )
      if ( pattern.Contains(item.Key) )
        pattern = pattern.Replace(item.Key, item.Value);
    if ( pattern.Contains("%") )
    {
      var uri = new Uri(pattern);
      new UriBuilder(uri.Scheme, uri.Host).ToString();
    }
    return pattern;
  }

}
