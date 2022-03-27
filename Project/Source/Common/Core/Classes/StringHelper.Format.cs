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
/// <created> 2020-04 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides system helper.
/// </summary>
[SuppressMessage("Design", "GCop160:This is not readable. Either refactor into a method, or use If / else statement.", Justification = "Opinion")]
static partial class StringHelper
{

  /// <summary>
  /// Creates a readable string from a size in bytes.
  /// </summary>
  static public string FormatBytesSize(this long bytes)
    => bytes >= 0
       ? ( (ulong)bytes ).FormatBytesSize()
       : SysTranslations.UndefinedSlot.GetLang();

  /// <summary>
  /// Creates a readable string from a milliseconds value.
  /// </summary>
  static public string FormatMilliseconds(this long ms, bool excludems = false)
  {
    var time = TimeSpan.FromMilliseconds(ms);
    var list = SysTranslations.MillisecondsFormat.GetLang();
    int index = time.Days == 0 && time.Hours == 0 && time.Minutes == 0 && time.Seconds == 0
      ? 0
      : time.Days == 0 && time.Hours == 0 && time.Minutes == 0
        ? 1
        : time.Days == 0 && time.Hours == 0
          ? 2
          : time.Days == 0
            ? 3
            : 4;
    string result = list[index];
    if ( index > 0 && !excludems ) result += " " + list[0];
    if ( index == 0 && excludems ) result = list[1];
    return string.Format(result, time.Days, time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
  }

}
