/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2020-12 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system helper.
  /// </summary>
  static partial class StringHelper
  {

    /// <summary>
    /// Create a readable string from a size in bytes.
    /// </summary>
    static public string FormatBytesSize(this long bytes)
    {
      return bytes >= 0 ? StackMethods.FormatBytesSize((ulong)bytes) : SysTranslations.UndefinedSlot.GetLang();
    }

    /// <summary>
    /// Create a readable string from a milliseconds value.
    /// </summary>
    static public string FormatMilliseconds(this long ms, bool excludems = false)
    {
      TimeSpan time = TimeSpan.FromMilliseconds(ms);
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

}
