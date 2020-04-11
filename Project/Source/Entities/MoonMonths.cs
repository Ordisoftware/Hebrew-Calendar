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
using System.IO;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Moon months names in hebrew unicode and latin phonetic.
  /// </summary>
  static public class MoonMonths
  {

    /// <summary>
    /// Phonetic names.
    /// </summary>
    static public readonly string[] Names =
    {
      "",
      "Nissan", "Iyar", "Sivan", "Tamouz", "Av", "Eloul",
      "Tishri", "Heshvan", "Kislev", "Tevet", "Chevat", "Adar",
      "Adar II"
    };

    /// <summary>
    /// Unicode names.
    /// </summary>
    static public readonly string[] Unicode =
    {
      "",
      "ניסן", "איר", "סיון", "תמוז", "אב", "אלול",
      "תשרי", "חשון", "כסלו", "טבת", "שבט", "אדר א",
      "אדר ב"
    };

    /// <summary>
    /// Meanings list.
    /// </summary>
    static public readonly List<string> Meanings = new List<string>();

    /// <summary>
    /// Lettriq list
    /// </summary>
    static public readonly List<string> Lettriqs = new List<string>();

    /// <summary>
    /// Load lists from definitions files.
    /// </summary>
    static public void Load()
    {
      Meanings.Clear();
      Lettriqs.Clear();
      for ( int index = 1; index <= Names.Length; index++ )
      {
        Meanings.Add("");
        Lettriqs.Add("");
      }
      Action<string, List<string>> process = (filename, list) =>
      {
        try
        {
          var lines = File.ReadAllLines(filename.Replace("%LANG%", Program.Settings.Language.ToUpper()));
          int index = 1;
          foreach ( string line in lines )
          {
            if ( line.Trim() == "" )
              continue;
            if ( line.StartsWith(";") )
              continue;
            var parts = line.Split('=');
            list[index] = parts[1].Trim();
            if ( ++index >= Names.Length )
              break;
          }
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
      };
      process(Program.MoonMonthsMeaningsFilename, Meanings);
      process(Program.MoonMonthsLettriqsFilename, Lettriqs);
    }

  }

}
