/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
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

  /// <summary>
  /// Creates a multi-spaced string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  static public string AsMultiSpace(this IEnumerable<object> list)
    => string.Join(" ", list);

  /// <summary>
  /// Creates a multi-spaced string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  static public string AsMultiSpace(this IEnumerable<string> list)
    => string.Join(" ", list);

  /// <summary>
  /// Creates a multi-comma string from an object.ToString() enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="withSpaceAfter">True to add a space after each comma, else without.</param>
  static public string AsMultiComma(this IEnumerable<object> list, bool withSpaceAfter = false)
    => string.Join(withSpaceAfter ? ", " : ",", list.Select(o => o.ToString()));

  /// <summary>
  /// Creates a multi-comma string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="withSpaceAfter">True to add a space after each comma, else without.</param>
  static public string AsMultiComma(this IEnumerable<string> list, bool withSpaceAfter = false)
    => string.Join(withSpaceAfter ? ", " : ",", list);

  /// <summary>
  /// Creates a multi-comma string from an object.ToString() enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="withSpaceAfter">True to add a space after each comma, else without.</param>
  static public string AsMultiSemicolon(this IEnumerable<object> list, bool withSpaceAfter = false)
    => string.Join(withSpaceAfter ? "; " : ";", list.Select(o => o.ToString()));

  /// <summary>
  /// Creates a multi-comma string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="withSpaceAfter">True to add a space after each comma, else without.</param>
  static public string AsMultiSemicolon(this IEnumerable<string> list, bool withSpaceAfter = false)
    => string.Join(withSpaceAfter ? "; " : ";", list);

  /// <summary>
  /// Creates a multi-newlines string from an object enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  static public string AsMultiLine(this IEnumerable<object> list)
    => string.Join(Globals.NL, list);

  /// <summary>
  /// Creates a multi-newlines string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  static public string AsMultiLine(this IEnumerable<string> list)
    => string.Join(Globals.NL, list);

  /// <summary>
  /// Creates a multi-double-newlines string from an object enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  static public string AsMultiDoubleLine(this IEnumerable<object> list)
    => string.Join(Globals.NL2, list);

  /// <summary>
  /// Creates a multi-double-newlines string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  static public string AsMultiDoubleLine(this IEnumerable<string> list)
    => string.Join(Globals.NL2, list);

}
