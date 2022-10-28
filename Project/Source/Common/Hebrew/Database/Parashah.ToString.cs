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
/// <edited> 2022-10 </edited>
namespace Ordisoftware.Hebrew;

//public enum ParashahToStringStyle
//{
//  OnlyParashah,
//  ParashahAndLinked,
//  WithBookAndRef,
//  WithBookAndFullRef,
//  OnlyBookAndRef,
//  OnlyBookAndFullRef
//}

public partial class Parashah
{

  public string ToStringShort(bool withBookAndref, bool withLinked)
  {
    string result = Name;
    if ( withLinked ) result += GetLinked() is not null ? " - " + GetLinked().Name : string.Empty;
    if ( withBookAndref ) result += $" ({Book} {VerseBegin})";
    return result;
  }

  public string ToStringOnlyBookAndFullRef()
  {
    return $"{Book} {VerseBegin} - {VerseEnd}";
  }

  //public string ToStringShort(ParashahToStringStyle style)
  //  => style switch
  //  {
  //    ParashahToStringStyle.OnlyParashah => Name,
  //    ParashahToStringStyle.ParashahAndLinked => $"{Name} - {GetLinked().Name}",
  //    ParashahToStringStyle.WithBookAndRef => $"{Name} ({Book} {VerseBegin})",
  //    ParashahToStringStyle.WithBookAndFullRef => $"{Name} ({Book} {VerseBegin} - {VerseEnd})",
  //    ParashahToStringStyle.OnlyBookAndRef => $"{Book} {VerseBegin}",
  //    ParashahToStringStyle.OnlyBookAndFullRef => $"{Book} {VerseBegin} - {VerseEnd}",
  //    _ => throw new AdvNotImplementedException(style)
  //  };

  public override string ToString()
    => ToString(false);

  public string ToString(bool useHebrewFont)
    => $"Torah Sefer {Book} {VerseBegin} - {VerseEnd} " +
       $"Parashah n°{Number} " +
       $"{Name}{( IsLinkedToNext ? "*" : string.Empty )} " +
       $"{( useHebrewFont ? Hebrew : Unicode )} : " +
       $"{Translation.GetOrEmpty()} ; " +
       $"{Lettriq.GetOrEmpty()}" +
       ( Memo.IsNullOrEmpty() ? string.Empty : $" ; {Memo.GetOrEmpty()}" );

  public string ToStringReadable()
    => $"• Torah Sefer {Book} {VerseBegin} - {VerseEnd}" + Globals.NL +
       $"• Parashah n°{Number} : {Name} {Unicode}" + Globals.NL +
       $"• {HebrewTranslations.Translation.GetLang()} : {Translation.GetOrEmpty()}" + Globals.NL +
       $"• {HebrewTranslations.Lettriq.GetLang()} : {Lettriq.GetOrEmpty()}";

}
