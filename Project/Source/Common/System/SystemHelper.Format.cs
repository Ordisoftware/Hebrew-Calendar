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
/// <created> 2020-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Threading;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide system helper.
  /// </summary>
  static partial class SystemHelper
  {

    /// <summary>
    /// Create a readable string from a size in bytes.
    /// </summary>
    static public string FormatBytesSize(this long bytes)
    {
      return bytes >= 0 ? FormatBytesSize((ulong)bytes) : Localizer.EmptySlot.GetLang();
    }

    /// <summary>
    /// Create a readable string from a size in bytes.
    /// From: https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc
    /// </summary>
    static public string FormatBytesSize(this ulong bytes)
    {
      ulong unit = 1024;
      if ( bytes < unit ) return $"{bytes} B";
      var exp = (int)( Math.Log(bytes) / Math.Log(unit) );
      string result = $"{bytes / Math.Pow(unit, exp):F2} {( "KMGTPEZY" )[exp - 1]}iB";
      return result.Replace(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator + "00", "");
    }

    /// <summary>
    /// Create a readable string from a milliseconds value.
    /// </summary>
    static public string FormatMilliseconds(this long ms, bool excludems = false)
    {
      TimeSpan time = TimeSpan.FromMilliseconds(ms);
      string result = string.Format("{0} d {1} h {2} m {3} s" + ( excludems ? "" : " {4} ms" ),
                                    time.Days,
                                    time.Hours,
                                    time.Minutes,
                                    time.Seconds,
                                    time.Milliseconds);
      if ( !excludems ) result = result.Replace("0 d 0 h 0 m 0 s", "");
      return result.Replace("0 d 0 h 0 m", "")
                   .Replace("0 d 0 h", "")
                   .Replace("0 d ", "");
    }

  }

}
