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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides string helper.
/// </summary>
static partial class StringHelper
{

  /// <summary>
  /// Indicates if a string is empty.
  /// </summary>
  /// <returns>
  /// true if empty, false if not.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  static public bool IsEmpty(this string str)
  {
    return str.Length == 0;
  }

  /// <summary>
  /// Indicates if a string is null or empty.
  /// </summary>
  /// <returns>
  /// true if a null or is empty, false if not.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  static public bool IsNullOrEmpty(this string str)
  {
    return string.IsNullOrEmpty(str);
  }

  /// <summary>
  /// Indicates if a string equals another string ignoring case and diacritics.
  /// </summary>
  /// <returns>
  /// True if it succeeds, false if it fails.
  /// </returns>
  /// <param name="str1">The string to act on.</param>
  /// <param name="str2">The other string.</param>
  static public bool RawEquals(this string str1, string str2)
  {
    return str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
  }

  /// <summary>
  /// Indicates if a string contains a substring ignoring case, diacritics and symbols.
  /// </summary>
  /// <returns>
  /// True if it succeeds, false if it fails.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="substr">The substr.</param>
  static public bool RawContains(this string str, string substr)
  {
    return RawComparer.IndexOf(str, substr, RawContainsFlags) >= 0;
  }

  [SuppressMessage("Design", "IDE0036:Use constant instead of field.", Justification = "Opinion")]
  [SuppressMessage("Design", "RCS1187:Use constant instead of field.", Justification = "Opinion")]
  static readonly private CompareOptions RawContainsFlags = CompareOptions.IgnoreCase
                                                          | CompareOptions.IgnoreNonSpace
                                                          | CompareOptions.IgnoreSymbols;

  static readonly private CompareInfo RawComparer = CultureInfo.InvariantCulture.CompareInfo;

  /// <summary>
  /// Sets all first letter to upper case.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string Titleize(this string str)
  {
    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
  }

  /// <summary>
  /// Trims any first and last char.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimFirstLast(this string str)
  {
    return new string(str.Skip(1).SkipLast(1).ToArray());
  }

  /// <summary>
  /// Splits a string by new line and remove empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="isUnix">True if is unix, false if not.</param>
  static public string[] SplitNoEmptyLines(this string str, bool isUnix = false)
  {
    return str.Split(isUnix ? "\n" : Globals.NL, StringSplitOptions.RemoveEmptyEntries);
  }

  /// <summary>
  /// Splits a string and remove empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="separator">The separator.</param>
  static public string[] SplitNoEmptyLines(this string str, string separator)
  {
    return str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
  }

  /// <summary>
  /// Splits a string by new line and keep empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  static public string[] SplitKeepEmptyLines(this string str)
  {
    return str.Split(Globals.NL, StringSplitOptions.None);
  }

  /// <summary>
  /// Splits a string and remove empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="separator">The separator.</param>
  static public string[] SplitKeepEmptyLines(this string str, string separator)
  {
    return str.Split(separator, StringSplitOptions.None);
  }

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
  {
    return str.Split(new string[] { separator }, stringSplitOptions);
  }

  /// <summary>
  /// Creates a string from a string enumeration.
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
  /// Creates a string from an object enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="separator">The separator.</param>
  static public string Join(this IEnumerable<object> list, string separator)
  {
    return string.Join(separator, list.Select(o => o.ToString()));
  }

  /// <summary>
  /// Creates a multi-spaced string from a string enumeration.
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
  /// Creates a multi-comma string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="withSpaceAfter">True to add a space after each comma, else without.</param>
  static public string AsMultiComma(this IEnumerable<string> list, bool withSpaceAfter)
  {
    string separator = withSpaceAfter ? ", " : ",";
    return string.Join(separator, list);
  }

  /// <summary>
  /// Creates a multi-comma string from an object enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="withSpaceAfter">True to add a space after each comma, else without.</param>
  static public string AsMultiComma(this IEnumerable<object> list, bool withSpaceAfter = false)
  {
    string separator = withSpaceAfter ? ", " : ",";
    return string.Join(separator, list.Select(o => o.ToString()));
  }

  /// <summary>
  /// Creates a multi-newlined string from a string enumeration.
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
  /// Creates a multi-newlined string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  static public string AsMultiDoubleLine(this IEnumerable<string> list)
  {
    return string.Join(Globals.NL2, list);
  }

  /// <summary>
  /// Left indent a text.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="margin">Margin.</param>
  static public string Indent(this string str, int margin)
  {
    return str.Indent(margin, margin);
  }

  /// <summary>
  /// Does a left indent a text.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="first">First line indentation.</param>
  /// <param name="corpus">Other lines indentation.</param>
  static public string Indent(this string str, int first, int corpus)
  {
    return new string(' ', first) + str.Replace(Globals.NL, Globals.NL + new string(' ', corpus));
  }

}
