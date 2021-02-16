/// <license>
/// This file is part of Ordisoftware Hebrew Words.
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
/// <edited> 2019-09 </edited>
using System;
using System.Linq;

namespace Ordisoftware.Hebrew
{

  public struct BookBound
  {
    public int Min;
    public int Max;
  }

  static public class BooksBounds
  {
    static public readonly BookBound Torah = new BookBound
    {
      Min = typeof(TorahBooks).Min() + 1,
      Max = typeof(TorahBooks).Max() + 1
    };
    static public readonly BookBound Neviim = new BookBound
    {
      Min = typeof(NeviimBooks).Min() + 1,
      Max = typeof(NeviimBooks).Max() + 1
    };
    static public readonly BookBound Ketouvim = new BookBound
    {
      Min = typeof(KetouvimBooks).Min() + 1,
      Max = typeof(KetouvimBooks).Max() + 1
    };
    static private int Min(this Type type)
    {
      return Enum.GetValues(type).Cast<int>().Min();
    }
    static private int Max(this Type type)
    {
      return Enum.GetValues(type).Cast<int>().Max();
    }
  }

}
