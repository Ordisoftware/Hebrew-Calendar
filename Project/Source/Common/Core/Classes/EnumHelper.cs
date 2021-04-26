/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-04 </created>
/// <edited> 2021-02 </edited>
using System;
using System.Linq;
using System.Globalization;

namespace Ordisoftware.Core
{

  static partial class EnumHelper
  {

    static public string ToStringFull<T>(this T value) where T : Enum
    {
      return value.GetType().Name + "." + value.ToString();
    }

    static public int Min<T>() where T : Enum
    {
      return Enum.GetValues(typeof(T)).Cast<int>().Min();
    }

    static public int Max<T>() where T : Enum
    {
      return Enum.GetValues(typeof(T)).Cast<int>().Max();
    }

    static public T SetFlag<T>(this T flags, T flag, bool value)
      where T : Enum, IComparable, IFormattable, IConvertible
    {
      int flagsInt = flags.ToInt32(NumberFormatInfo.CurrentInfo);
      int flagInt = flag.ToInt32(NumberFormatInfo.CurrentInfo);
      if ( value )
        flagsInt |= flagInt;
      else
        flagsInt &= ~flagInt;
      return (T)(object)flagsInt;
    }

    // From https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-public enum-value-in-c-sharp
    static public T Next<T>(this T value, params T[] skip) where T : Enum
    {
      var result = Enum.GetValues(value.GetType()).Cast<T>().Concat(new[] { default(T) })
                       .SkipWhile(e => !value.Equals(e))
                       .Skip(1)
                       .First();
      foreach ( T item in skip )
        if ( item.Equals(result) )
          result = result.Next(skip);
      return result;
    }

    // From https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-public enum-value-in-c-sharp
    static public T Previous<T>(this T value, params T[] skip) where T : Enum
    {
      var result = Enum.GetValues(value.GetType()).Cast<T>().Concat(new[] { default(T) })
                       .Reverse()
                       .SkipWhile(e => !value.Equals(e))
                       .Skip(1)
                       .First();
      foreach ( T item in skip )
        if ( item.Equals(result) )
          result = result.Previous(skip);
      return result;
    }

  }

}
