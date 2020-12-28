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
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using System.Globalization;

namespace Ordisoftware.Core
{

  // From https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-enum-value-in-c-sharp
  static public class EnumHelper
  {
    static public T Next<T>(this T value) where T : Enum
    {
      return Enum.GetValues(value.GetType()).Cast<T>().Concat(new[] { default(T) })
                 .SkipWhile(e => !value.Equals(e))
                 .Skip(1)
                 .First();
    }

    static public T Previous<T>(this T value) where T : Enum
    {
      return Enum.GetValues(value.GetType()).Cast<T>().Concat(new[] { default(T) })
                 .Reverse()
                 .SkipWhile(e => !value.Equals(e))
                 .Skip(1)
                 .First();
    }

    static public string ToStringFull<T>(this T value) where T : Enum
    {
      return value.GetType().Name + "." + value.ToString();
    }

    static public T SetFlag<T>(this T flags, T flag, bool value) 
      where T : struct, IComparable, IFormattable, IConvertible
    {
      int flagsInt = flags.ToInt32(NumberFormatInfo.CurrentInfo);
      int flagInt = flag.ToInt32(NumberFormatInfo.CurrentInfo);
      if ( value )
        flagsInt |= flagInt;
      else
        flagsInt &= ~flagInt;
      return (T)(object)flagsInt;
    }
  }

}
