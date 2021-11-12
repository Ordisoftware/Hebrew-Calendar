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
/// <created> 2012-10 </created>
/// <edited> 2021-04 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  public struct BookBound
  {
    public int Min { get; private set; }
    public int Max { get; private set; }
    public BookBound(int min, int max)
    {
      Min = min;
      Max = max;
    }
  }

  static partial class BooksBounds
  {
    static public readonly BookBound Torah = Create<TorahBook>();
    static public readonly BookBound Neviim = Create<NeviimBook>();
    static public readonly BookBound Ketouvim = Create<KetouvimBook>();
    static private BookBound Create<T>() where T : struct, Enum
      => new(EnumHelper.Min<T>() + 1, EnumHelper.Max<T>() + 1);
  }

}
