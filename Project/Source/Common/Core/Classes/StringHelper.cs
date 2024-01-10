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
/// <edited> 2022-04 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides string helper.
/// </summary>
static public partial class StringHelper
{

  /// <summary>
  /// Indicates if a string is empty.
  /// </summary>
  /// <returns>
  /// true if empty, false if not.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  static public bool IsEmpty(this string str)
    => str.Length == 0;

  /// <summary>
  /// Indicates if a string is null or empty.
  /// </summary>
  /// <returns>
  /// true if a null or is empty, false if not.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  static public bool IsNullOrEmpty(this string str)
    => string.IsNullOrEmpty(str);

  /// <summary>
  /// Indicates if a string starts with one of these comment symbol: # - ; /* //
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public bool IsCommented(this string str)
    => str.StartsWith("/*", StringComparison.Ordinal)
       || str.StartsWith("//", StringComparison.Ordinal)
       || str.StartsWith(";", StringComparison.Ordinal)
       || str.StartsWith("#", StringComparison.Ordinal)
       || str.StartsWith("--", StringComparison.Ordinal);

  /// <summary>
  /// Sets all first letter to upper case.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string Titleize(this string str)
    => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);

}
