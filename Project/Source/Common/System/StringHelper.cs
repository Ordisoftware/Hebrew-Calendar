/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide system helper.
  /// </summary>
  static partial class StringHelper
  {

    /// <summary>
    /// Indicate if a string is null, DBNull or empty.
    /// </summary>
    /// <returns>
    /// true if a null or is empty, false if not.
    /// </returns>
    /// <param name="str">The str to act on.</param>
    static public bool IsNullOrEmpty(this string str)
    {
      return str == null || str == string.Empty;
    }

    /// <summary>
    /// Split a string by new line and remove empty lines.
    /// </summary>
    /// <returns>
    /// A string[].
    /// </returns>
    /// <param name="str">The str to act on.</param>
    static public string[] SplitNoEmptyLines(this string str)
    {
      return str.Split(StringSplitOptions.RemoveEmptyEntries, Globals.NL);
    }

    /// <summary>
    /// Split a string by new line.
    /// </summary>
    /// <returns>
    /// A string[].
    /// </returns>
    /// <param name="str">The string to act on.</param>
    /// <param name="stringSplitOptions">Options for controlling the operation.</param>
    static public string[] SplitNoEmptyLines(this string str, StringSplitOptions stringSplitOptions = StringSplitOptions.None)
    {
      return str.Split(stringSplitOptions, Globals.NL);
    }

    /// <summary>
    /// Split a string.
    /// </summary>
    /// <returns>
    /// A string[].
    /// </returns>
    /// <param name="str">The str to act on.</param>
    /// <param name="stringSplitOptions">Options for controlling the operation.</param>
    /// <param name="separator">The separator.</param>
    static public string[] Split(this string str, StringSplitOptions stringSplitOptions, string separator)
    {
      return str.Split(new string[] { separator }, stringSplitOptions);
    }

    /// <summary>
    /// Create a multiline string from a string enumeration.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    /// <param name="list">The enumeration to act on.</param>
    /// <param name="separator">The separator.</param>
    static public string Join(this IEnumerable<string> list, string separator)
    {
      return string.Join(separator, list);
    }

    /// <summary>
    /// Create a multiline string from a string enumeration.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    /// <param name="list">The enumeration to act on.</param>
    // TODO rename to FromMultiline or From List
    static public string AsMultispace(this IEnumerable<string> list)
    {
      return string.Join(" ", list);
    }

    /// <summary>
    /// Create a multiline string from a string enumeration.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    /// <param name="list">The enumeration to act on.</param>
    // TODO rename to FromMultiline or From List
    static public string AsMultiline(this IEnumerable<string> list)
    {
      return string.Join(Globals.NL, list);
    }

    /// <summary>
    /// Left indent a text.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    /// <param name="str">The str to act on.</param>
    /// <param name="first">First line indentation.</param>
    /// <param name="corpus">Other lines indentation.</param>
    /// <param name="spacechar">Space charactor.</param>
    /// <param name="newline">New line string sequence.</param>
    static public string Indent(this string str, int first, int corpus)
    {
      return new string(' ', first) + str.Replace(Globals.NL, Globals.NL + new string(' ', corpus));
    }

  }

}
