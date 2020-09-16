/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
/// <edited> 2020-09 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system helper.
  /// </summary>
  static partial class StringHelper
  {

    /// <summary>
    /// Indicate if a string is null or empty.
    /// </summary>
    /// <returns>
    /// true if a null or is empty, false if not.
    /// </returns>
    /// <param name="str">The str to act on.</param>
    static public bool IsNullOrEmpty(this string str)
    {
      return ReferenceEquals(str, null) || str.Length == 0;
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
      return str.Split(Globals.NL, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Split a string and remove empty lines.
    /// </summary>
    /// <returns>
    /// A string[].
    /// </returns>
    /// <param name="str">The str to act on.</param>
    static public string[] SplitNoEmptyLines(this string str, string separator)
    {
      return str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Split a string by new line and keep empty lines.
    /// </summary>
    /// <returns>
    /// A string[].
    /// </returns>
    /// <param name="str">The string to act on.</param>
    /// <param name="stringSplitOptions">Options for controlling the operation.</param>
    static public string[] SplitKeepEmptyLines(this string str)
    {
      return str.Split(Globals.NL, StringSplitOptions.None);
    }

    /// <summary>
    /// Split a string and remove empty lines.
    /// </summary>
    /// <returns>
    /// A string[].
    /// </returns>
    /// <param name="str">The str to act on.</param>
    static public string[] SplitKeepEmptyLines(this string str, string separator)
    {
      return str.Split(separator, StringSplitOptions.None);
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
    static public string[] Split(this string str, string separator, StringSplitOptions stringSplitOptions)
    {
      return str.Split(new string[] { separator }, stringSplitOptions);
    }

    /// <summary>
    /// Create a string from a string enumeration.
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
    /// Create a multi-spaced string from a string enumeration.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    /// <param name="list">The enumeration to act on.</param>
    static public string AsMultiSpace(this IEnumerable<string> list)
    {
      return string.Join(" ", list);
    }

    /// <summary>
    /// Create a multi-newlined string from a string enumeration.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    /// <param name="list">The enumeration to act on.</param>
    static public string AsMultiLine(this IEnumerable<string> list)
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
    /// <param name="margin">Margin.</param>
    static public string Indent(this string str, int margin)
    {
      return str.Indent(margin, margin);
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
    static public string Indent(this string str, int first, int corpus)
    {
      return new string(' ', first) + str.Replace(Globals.NL, Globals.NL + new string(' ', corpus));
    }

    /// <summary>
    /// Wrap a string.
    /// </summary>
    /// <param name="str">The text.</param>
    /// <param name="width">The width.</param>
    static public string Wrap(this string str, int width)
    {
      char spacechar = ' ';
      string newline = Environment.NewLine;
      if ( width <= 0 || str.Length <= width ) return str;
      string result = str;
      int index = 0, pos;
      while ( index < result.Length - width )
      {
        pos = result.LastIndexOf(newline, index + width, width);
        if ( pos != -1 )
          index = pos + newline.Length;
        else
        {
          pos = result.LastIndexOf(spacechar, index + width, width);
          if ( pos == -1 )
          {
            pos = result.IndexOf(spacechar, index + width);
            break;
          }
          result = result.Remove(pos, 1);
          result = result.Insert(pos, newline);
          index = pos + newline.Length;
        }
      }
      return result;
    }
  }

}
