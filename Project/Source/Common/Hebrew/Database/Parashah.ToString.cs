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
/// <edited> 2021-05 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  public partial class Parashah
  {

    public string ToStringLinked()
      => Name + ( Linked != null ? " - " + Linked.Name : "" );

    public override string ToString()
      => ToString(false);

    public string ToString(bool useHebrewFont = false)
      => $"Sefer {Book} {VerseBegin} - {VerseEnd} " +
         $"Parashah n°{Number} " +
         $"{Name}{( IsLinkedToNext ? "*" : string.Empty )} " +
         $"({( useHebrewFont ? Hebrew : Unicode )}) : " +
         $"{Translation.GetOrEmpty()} ; " +
         $"{Lettriq.GetOrEmpty()}" +
         ( Memo.IsNullOrEmpty() ? "" : $" ; {Memo.GetOrEmpty()}" );

    public string ToStringReadable()
      => $"Sefer {Book} {VerseBegin} - {VerseEnd}" + Globals.NL +
         $"Parashah n°{Number} " + Globals.NL +
         $"{Name} ({Unicode})" + Globals.NL +
         $"• {Translation.GetOrEmpty()}" + Globals.NL +
         $"• {Lettriq.GetOrEmpty()}";

  }

}
