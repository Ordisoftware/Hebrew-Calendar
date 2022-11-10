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
/// <created> 2016-04 </created>
/// <edited> 2022-04 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides string helper.
/// </summary>
static public partial class StringHelper
{

  /// <summary>
  /// Splits a string by new line and remove empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="isUnix">True if on Unix, false if not.</param>
  static public string[] SplitNoEmptyLines(this string str, bool isUnix = false)
    => str.Split(isUnix ? "\n" : Globals.NL, StringSplitOptions.RemoveEmptyEntries);

  /// <summary>
  /// Splits a string and remove empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="separator">The separator.</param>
  static public string[] SplitNoEmptyLines(this string str, string separator)
    => str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

  /// <summary>
  /// Splits a string by new line and keep empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  static public string[] SplitKeepEmptyLines(this string str)
    => str.Split(Globals.NL, StringSplitOptions.None);

  /// <summary>
  /// Splits a string and remove empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="separator">The separator.</param>
  static public string[] SplitKeepEmptyLines(this string str, string separator)
    => str.Split(separator, StringSplitOptions.None);

  /// <summary>
  /// Splits a string.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="separator">The separator.</param>
  /// <param name="stringSplitOptions">Options for controlling the operation.</param>
  static public string[] Split(this string str, string separator, StringSplitOptions stringSplitOptions)
    => str.Split(new string[] { separator }, stringSplitOptions);

}
