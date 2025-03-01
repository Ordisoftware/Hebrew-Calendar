/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
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

using MoreLinq;

/// <summary>
/// Provides string helper.
/// </summary>
static public partial class StringHelper
{

  /// <summary>
  /// Removes all starting and ending spaces.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimSpaces(this string str)
    => str.Trim(' ');

  /// <summary>
  /// Removes all starting and ending empty lines.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimEmptyLines(this string str)
    => str.Trim(EmptyLineCharArray);

  /// <summary>
  /// Removes all starting and ending empty lines and spaces.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimEmptyLinesAndSpaces(this string str)
    => str.Trim(EmptyLineAndSpaceCharArray);

  /// <summary>
  /// Trims any first and last char.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimFirstLast(this string str)
    => new([.. str.Skip(1).SkipLast(1)]);

}
