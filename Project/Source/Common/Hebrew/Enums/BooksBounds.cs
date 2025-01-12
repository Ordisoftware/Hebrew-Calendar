﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words/Pi.
/// Copyright 2012-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2012-10 </created>
/// <edited> 2022-05 </edited>
namespace Ordisoftware.Hebrew;

[SuppressMessage("Performance", "U2U1004:Public value types should implement equality", Justification = "N/A")]
[StructLayout(LayoutKind.Auto)]
public readonly record struct BookBound(int Min, int Max)
{
  public bool IsIn(int index) => index >= Min && index <= Max;
}

[SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
static public class BooksBounds
{
  static public readonly BookBound Torah = Create<TorahBook>();
  static public readonly BookBound Neviim = Create<NeviimBook>();
  static public readonly BookBound Ketouvim = Create<KetouvimBook>();
  static private BookBound Create<T>() where T : struct, Enum => new(EnumHelper.Min<T>(), EnumHelper.Max<T>());
}
