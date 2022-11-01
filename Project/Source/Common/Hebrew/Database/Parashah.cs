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
/// <created> 2021-02 </created>
/// <edited> 2021-11 </edited>
namespace Ordisoftware.Hebrew;

using SQLite;

[Serializable]
[Table("Parashot")]
public partial class Parashah : INotifyPropertyChanged
{

  public event PropertyChangedEventHandler PropertyChanged;

  public Parashah()
  {
  }

  public Parashah(TorahBook book,
                  int number,
                  string name,
                  string unicode,
                  string verseBegin,
                  string verseEnd,
                  bool isLinkedToNext = false,
                  string translation = "",
                  string lettriq = "")
  {
    try
    {
      Book = book;
      Number = number;
      Name = name;
      Unicode = unicode;
      Hebrew = HebrewAlphabet.ToHebrewFont(unicode);
      ChapterAndVerseBegin = verseBegin;
      ChapterAndVerseEnd = verseEnd;
      var partsBegin = ChapterAndVerseBegin.Split('.');
      ChapterBegin = Convert.ToInt32(partsBegin[0]);
      VerseBegin = Convert.ToInt32(partsBegin[1]);
      var partsEnd = ChapterAndVerseEnd.Split('.');
      ChapterEnd = Convert.ToInt32(partsEnd[0]);
      VerseEnd = Convert.ToInt32(partsEnd[1]);
      IsLinkedToNext = isLinkedToNext;
      Translation = translation;
      Lettriq = lettriq;
      Memo = string.Empty;
      ID = $"{(int)book}.{number}";
    }
    catch ( Exception ex )
    {
      throw new Exception("Error on creating parashah instance: " + ex.Message, ex);
    }
  }

  public object Clone()
  {
    return new Parashah(Book, Number, Name, Unicode, ChapterAndVerseBegin, ChapterAndVerseEnd, IsLinkedToNext, Translation, Lettriq);
  }

}
