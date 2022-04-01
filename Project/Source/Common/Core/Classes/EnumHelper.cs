/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides enum helper.
/// </summary>
static class EnumHelper
{

  /// <summary>
  /// Converts to a full string representation like "type.value".
  /// </summary>
  static public string ToStringFull<T>(this T value) where T : Enum
    => $"{value.GetType().Name}.{value}";

  /// <summary>
  /// Determines the minimum of the parameters.
  /// </summary>
  static public int Min<T>() where T : Enum
    => Enum.GetValues(typeof(T)).Cast<int>().Min();

  /// <summary>
  /// Determines the maximum of the parameters.
  /// </summary>
  static public int Max<T>() where T : Enum
    => Enum.GetValues(typeof(T)).Cast<int>().Max();

  /// <summary>
  /// Sets the flag.
  /// </summary>
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

}
