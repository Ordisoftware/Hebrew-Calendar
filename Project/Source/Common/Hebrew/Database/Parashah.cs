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
/// <edited> 2021-02 </edited>
using System;

namespace Ordisoftware.Hebrew
{

  public partial class Parashah
  {

    public string ID { get; }
    public TorahBooks Book { get; }
    public int Number { get; }
    public string VerseBegin { get; }
    public string VerseEnd { get; }
    public bool IsLinkedToNext { get; }
    public string Name { get; }
    public string Hebrew { get; }
    public string Unicode { get; }
    public string Translation { get; set; }
    public string Lettriq { get; set; }
    public string Memo { get; set; }
    public Parashah Linked { get; set; }

    /*public override string ToString()
      => ToString(false);

    public string ToString(bool useHebrewFont)
      => $"Sefer {Book}, " +
         $"Parashah n°{Number}, " +
         $"{VerseBegin} - {VerseEnd}, " +
         $"{Name}{( IsLinkedToNext ? "*" : string.Empty )} " +
         $"({( useHebrewFont ? Hebrew : Unicode )}) : " +
         $"{Translation} ; {Lettriq} : {Memo}";*/

    public string ToStringLinked()
      => Name + ( Linked != null  ? " - " + Linked.Name : "");

    public Parashah(TorahBooks book,
                    int number,
                    string name,
                    string unicode,
                    string verseBegin,
                    string verseEnd,
                    bool isLinkedToNext = false,
                    string translation = "",
                    string lettriq = "")
    {
      Book = book;
      Number = number;
      Name = name;
      Unicode = unicode;
      Hebrew = HebrewAlphabet.ToHebrewFont(unicode);
      VerseBegin = verseBegin;
      VerseEnd = verseEnd;
      IsLinkedToNext = isLinkedToNext;
      Translation = translation;
      Lettriq = lettriq;
      ID = $"{(int)book + 1}.{number}";
    }

  }

}
