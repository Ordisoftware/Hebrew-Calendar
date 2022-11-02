﻿/// <license>
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

public partial class Parashah
{

  public string GetNameDisplayText() => HebrewDatabase.HebrewNamesInUnicode ? Unicode : Name;

  public string ToStringShort(bool withBookAndref, bool withLinked)
  {
    string result = GetNameDisplayText();
    if ( withLinked ) result += GetLinked() is not null ? " - " + GetLinked().GetNameDisplayText() : string.Empty;
    if ( withBookAndref )
      result += $" ({ToStringBookAndReferences()})";
    return result;
  }

  public string ToStringBookAndReferences()
  {
    return HebrewDatabase.HebrewNamesInUnicode
      ? $"{BookInfos.Unicode[(TanakBook)Book]} : {GetUnicodeVerses()}"
      : $"{Book} {GetLatinVerses()}";
  }

  private string GetUnicodeVerses()
  {
    string result = HebrewAlphabet.IntToUnicode(ChapterBegin);
    result += ".";
    result += HebrewAlphabet.IntToUnicode(VerseBegin);
    result += " - ";
    result += HebrewAlphabet.IntToUnicode(ChapterEnd);
    result += ".";
    result += HebrewAlphabet.IntToUnicode(VerseEnd);
    return result;
  }

  private string GetLatinVerses()
  {
    return ChapterAndVerseBegin + " - " + ( IsLinkedToNext ? GetLinked().ChapterAndVerseEnd : ChapterAndVerseEnd );
  }

  public override string ToString()
    => ToString(false);

  public string ToString(bool useHebrewFont)
    => $"Torah Sefer {Book} {ChapterAndVerseBegin} - {ChapterAndVerseEnd} " +
       $"Parashah n°{Number} " +
       $"{Name}{( IsLinkedToNext ? "*" : string.Empty )} " +
       $"{( useHebrewFont ? Hebrew : Unicode )} : " +
       $"{Translation.GetOrEmpty()} ; " +
       $"{Lettriq.GetOrEmpty()}" +
       ( Memo.IsNullOrEmpty() ? string.Empty : $" ; {Memo.GetOrEmpty()}" );

  public string ToStringReadable()
    => $"• Torah Sefer {Book} {ChapterAndVerseBegin} - {ChapterAndVerseEnd}" + Globals.NL +
       $"• Parashah n°{Number} : {Name} {Unicode}" + Globals.NL +
       $"• {HebrewTranslations.Translation.GetLang()} : {Translation.GetOrEmpty()}" + Globals.NL +
       $"• {HebrewTranslations.Lettriq.GetLang()} : {Lettriq.GetOrEmpty()}";

}
