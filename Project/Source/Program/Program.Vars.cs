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
/// <edited> 2020-08 </edited>
using System;
using System.IO;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Indicate phonetic moon months names.
    /// </summary>
    static public readonly string[] MoonMonthsNames =
    {
      "",
      "Nissan", "Iyar", "Sivan", "Tamouz", "Av", "Eloul",
      "Tishri", "Heshvan", "Kislev", "Tevet", "Chevat", "Adar",
      "Adar II"
    };

    /// <summary>
    /// Indicate unicode moon months names.
    /// </summary>
    static public readonly string[] MoonMonthsUnicode =
    {
      "",
      "ניסן", "איר", "סיון", "תמוז", "אב", "אלול",
      "תשרי", "חשון", "כסלו", "טבת", "שבט", "אדר א",
      "אדר ב"
    };

    /// <summary>
    /// Indicate filename of the GPS database.
    /// </summary>
    static public readonly string GPSFilename
      = Globals.DocumentsFolderPath + "WorldCities.csv";

    /// <summary>
    /// Indicate the moon months documents folder.
    /// </summary>
    static public readonly string MoonMonthsFolderPath
      = Globals.DocumentsFolderPath + "MoonMonths" + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate filename of the moon months meanings.
    /// </summary>
    static public readonly string MoonMonthsMeaningsFilename
      = MoonMonthsFolderPath + "MoonMonthsMeanings%LANG%.txt";

    /// <summary>
    /// Indicate filename of the moon months lettriqs.
    /// </summary>
    static public readonly string MoonMonthsLettriqsFilename
      = MoonMonthsFolderPath + "MoonMonthsLettriqs%LANG%.txt";

    /// <summary>
    /// Indicate the moon months meanings.
    /// </summary>
    static public MoonMonthsFile MoonMonthsMeanings { get; private set; }

    /// <summary>
    /// Indicate the moon months lettriqs.
    /// </summary>
    static public MoonMonthsFile MoonMonthsLettriqs { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Program()
    {
      MoonMonthsMeanings = new MoonMonthsFile(MoonMonthsMeaningsFilename, true, Globals.IsDev, DataFileFolder.ApplicationDocuments);
      MoonMonthsLettriqs = new MoonMonthsFile(MoonMonthsLettriqsFilename, true, Globals.IsDev, DataFileFolder.ApplicationDocuments);
    }

  }

}
