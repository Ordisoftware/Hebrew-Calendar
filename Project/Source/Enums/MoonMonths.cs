/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2020-03 </edited>
using System;
using System.IO;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  static public class MoonMonths
  {

    static public readonly string[] Names =
    {
      "",
      "Nissan", "Iyar", "Sivan", "Tamouz", "Av", "Eloul",
      "Tishri", "Heshvan", "Kislev", "Tevet", "Chevat", "Adar",
      "Adar II"
    };

    static public readonly string[] Hebrew =
    {
      "",
      "ניסן", "איר", "סיון", "תמוז", "אב", "אלול",
      "תשרי", "חשון", "כסלו", "טבת", "שבט", "אדר א",
      "אדר ב"
    };

    static public readonly List<string> Meanings = new List<string>();

    static public readonly List<string> Lettriqs = new List<string>();

    static public void Load()
    {
      Meanings.Clear();
      Lettriqs.Clear();
      string lang = Program.Settings.Language.ToUpper();
      Action<string, List<string>> process = (filenamepart, list) =>
      {
        try
        {
          string filename = Program.AppDocumentsFolderPath + filenamepart + lang + ".txt";
          var lines = File.ReadAllLines(filename);
          list.Add("");
          foreach ( string line in lines )
          {
            var parts = line.Split('=');
            list.Add(parts[1].Trim());
          }
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
      };
      process("MoonMonthsMeanings", Meanings);
      process("MoonMonthsLettriqs", Lettriqs);
    }

    static MoonMonths()
    {
      Load();
    }

  }

}
