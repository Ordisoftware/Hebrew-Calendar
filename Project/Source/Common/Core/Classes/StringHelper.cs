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
static partial class StringHelper
{

  /// <summary>
  /// RegEx to replace multiple spaces by one.
  /// </summary>
  static private readonly Regex RegExReplaceMultipleSpaces
    = new("[ ]+", RegexOptions.None, TimeSpan.FromSeconds(1));

  /// <summary>
  /// Array to trim empty lines.
  /// </summary>
  static private readonly char[] EmptyLineCharArray
    = Globals.NL.ToCharArray();

  /// <summary>
  /// Array to trim empty lines and spaces.
  /// </summary>
  static private readonly char[] EmptyLineAndSpaceCharArray
    = ( Globals.NL + ' ' ).ToCharArray();

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
  /// <param name="substr">The substr.</param>
  static public bool RawContains(this string str, string substr)
    => RawComparer.IndexOf(str, substr, RawContainsFlags) >= 0;

  static readonly private CompareInfo RawComparer = CultureInfo.InvariantCulture.CompareInfo;

  [SuppressMessage("Design", "IDE0036:Use constant instead of field.", Justification = "Opinion")]
  [SuppressMessage("Design", "RCS1187:Use constant instead of field.", Justification = "Opinion")]
  static readonly private CompareOptions RawContainsFlags = CompareOptions.IgnoreCase
                                                          | CompareOptions.IgnoreNonSpace
                                                          | CompareOptions.IgnoreSymbols;

  /// <summary>
  /// Sets all first letter to upper case.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string Titleize(this string str)
    => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);

  /// <summary>
  /// Replaces all double and more contiguous empty lines by one.
  /// Also replace \n alone by Windows NewLine.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string SanitizeEmptyLines(this string str)
  {
    if ( str.IsNullOrEmpty() ) return str;
    if ( str.IndexOf('\n') >= 0 && !str.Contains(Globals.NL) )
      str = str.Replace("\n", Globals.NL);
    var lines = str.SplitKeepEmptyLines();
    var result = new List<string>();
    bool isPreviousEmpty = false;
    for ( int index = 0; index < lines.Length; index++ )
    {
      ref string line = ref lines[index];
      bool isEmpty = line.IsNullOrEmpty();
      if ( isEmpty )
      {
        if ( !isPreviousEmpty )
        {
          result.Add(line);
          isPreviousEmpty = true;
        }
      }
      else
      {
        result.Add(line);
        isPreviousEmpty = false;
      }
    }
    return result.AsMultiLine();
  }

  /// <summary>
  /// Replaces all double and more contiguous spaces by one.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string SanitizeSpaces(this string str)
    => RegExReplaceMultipleSpaces.Replace(str, " ");

  /// <summary>
  /// Replaces all double and more contiguous empty lines as well as spaces by one.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string SanitizeEmptyLinesAndSpaces(this string str)
    => str.SanitizeSpaces().SanitizeEmptyLines();

  /// <summary>
  /// Removes all starting and ending empty lines.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimEmptyLines(this string str)
    => str.Trim(EmptyLineCharArray);

  /// <summary>
  /// Removes all starting and ending spaces.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimSpaces(this string str)
    => str.Trim(' ');

  /// <summary>
  /// Removes all starting and ending empty lines and spaces.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimEmptyLinesAndSpaces(this string str)
    => str.Trim(EmptyLineAndSpaceCharArray);

  /// <summary>
  /// Sanitizes and trims empty lines and spaces a string.
  /// </summary>
  /// <param name="str"></param>
  static public string SanitizeAndTrimEmptyLinesAndSpaces(this string str)
    => str.SanitizeEmptyLinesAndSpaces().TrimEmptyLinesAndSpaces();

  /// <summary>
  /// Trims any first and last char.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string TrimFirstLast(this string str)
    => new(str.Skip(1).SkipLast(1).ToArray());

  /// <summary>
  /// Splits a string by new line and remove empty lines.
  /// </summary>
  /// <returns>
  /// A string[].
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="isUnix">True if is unix, false if not.</param>
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

  /// <summary>
  /// Creates a string from an object enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="separator">The separator.</param>
  static public string Join(this IEnumerable<object> list, string separator)
    => string.Join(separator, list.Select(o => o.ToString()));

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
  /// Creates a multi-comma string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="withSpaceAfter">True to add a space after each comma, else without.</param>
  static public string AsMultiComma(this IEnumerable<string> list, bool withSpaceAfter)
    => string.Join(withSpaceAfter ? ", " : ",", list);

  /// <summary>
  /// Creates a multi-comma string from an object enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  /// <param name="withSpaceAfter">True to add a space after each comma, else without.</param>
  static public string AsMultiComma(this IEnumerable<object> list, bool withSpaceAfter = false)
    => string.Join(withSpaceAfter ? ", " : ",", list.Select(o => o.ToString()));

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
  /// Creates a multi-newlines string from a string enumeration.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="list">The enumeration to act on.</param>
  static public string AsMultiDoubleLine(this IEnumerable<string> list)
    => string.Join(Globals.NL2, list);

  /// <summary>
  /// Left indent a text.
  /// </summary>
  /// <returns>
  /// A string.
  /// </returns>
  /// <param name="str">The string to act on.</param>
  /// <param name="margin">Margin.</param>
  static public string Indent(this string str, int margin)
    => str.Indent(margin, margin);

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
    => new string(' ', first) + str.Replace(Globals.NL, Globals.NL + new string(' ', corpus));

}
