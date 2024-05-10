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
  /// Sanitizes and trims empty lines and spaces.
  /// </summary>
  /// <param name="str">The string to act on.</param>
  static public string SanitizeAndTrimEmptyLinesAndSpaces(this string str)
    => str.SanitizeEmptyLinesAndSpaces().TrimEmptyLinesAndSpaces();

}
