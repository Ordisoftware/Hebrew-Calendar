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
  /// Creates a string from an object.ToString() enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="separator">The separator.</param>
  static public string Join(this IEnumerable<object> list, string separator)
    => string.Join(separator, list.Select(o => o.ToString()));

  /// <summary>
  /// Creates a string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="separator">The separator.</param>
  static public string Join(this IEnumerable<string> list, string separator)
    => string.Join(separator, list);

}
