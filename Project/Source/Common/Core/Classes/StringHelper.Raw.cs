/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides string helper.
/// </summary>
static public partial class StringHelper
{

  private const CompareOptions RawContainsFlags = CompareOptions.IgnoreCase
                                                | CompareOptions.IgnoreNonSpace
                                                | CompareOptions.IgnoreSymbols;

  static readonly private CompareInfo RawComparer = CultureInfo.InvariantCulture.CompareInfo;

  /// <summary>
  /// Indicates if a string equals another string ignoring case and diacritics.
  /// </summary>
  /// <returns>
  /// True if it succeeds, false if it fails.
  /// </returns>
  /// <param name="str1">The string to act on.</param>
  /// <param name="str2">The other string.</param>
  static public bool RawEquals(this string str1, string str2)
    => str1.Equals(str2, StringComparison.OrdinalIgnoreCase);

  /// <summary>
  /// Indicates if a string contains a substring ignoring case, diacritics and symbols.
  /// </summary>
  /// <returns>
  /// True if it succeeds, false if it fails.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="subStr">The substring.</param>
  static public int RawIndexOf(this string str, string subStr)
    => RawComparer.IndexOf(str, subStr, RawContainsFlags);

  /// <summary>
  /// Indicates if a string contains a substring ignoring case, diacritics and symbols.
  /// </summary>
  /// <returns>
  /// True if it succeeds, false if it fails.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="subStr">The substring.</param>
  static public bool RawContains(this string str, string subStr)
    => str.RawIndexOf(subStr) >= 0;

  /// <summary>
  /// Indicates if a string starts with a substring ignoring case, diacritics and symbols.
  /// </summary>
  /// <returns>
  /// True if it succeeds, false if it fails.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="subStr">The substring.</param>
  static public bool RawStartsWith(this string str, string subStr)
    => str.RawIndexOf(subStr) == 0;

}
