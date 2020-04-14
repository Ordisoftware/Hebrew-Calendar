/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-04 </edited>
using System;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Indicate filename of the GPS database.
    /// </summary>
    static public readonly string GPSFilename
      = Globals.DocumentsFolderPath + "WorldCities.csv";

    /// <summary>
    /// Indicate filename of the moon months meanings.
    /// </summary>
    static public readonly string MoonMonthsMeaningsFilename
      = Globals.DocumentsFolderPath + "MoonMonthsMeanings%LANG%.txt";

    /// <summary>
    /// Indicate filename of the moon months lettriqs.
    /// </summary>
    static public readonly string MoonMonthsLettriqsFilename
      = Globals.DocumentsFolderPath + "MoonMonthsLettriqs%LANG%.txt";

  }

}
