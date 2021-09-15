/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-09 </created>
/// <edited> 2021-09 </edited>
using System;
using System.Collections.Generic;
using System.IO;
using EnumsNET;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Torah celebrations days, durations and verses.
  /// </summary>
  static public class TorahCelebrationVerses
  {

    static public void Save()
    {
      using ( var stream = File.CreateText(HebrewGlobals.CelebrationVersesFilePath) )
        foreach ( var kvp in Items )
          foreach ( var item in kvp.Value )
            stream.WriteLine($"{kvp.Key} : {item.Item1} - {item.Item2} - {item.Item3}");
    }

    static public void Load()
    {
      string filePath = HebrewGlobals.CelebrationVersesFilePath;
      if ( !File.Exists(filePath) ) throw new FileNotFoundException(SysTranslations.FileNotFound.GetLang(filePath));
      Items.Clear();
      var lines = File.ReadAllLines(filePath);
      foreach ( var line in lines )
      {
        var parts = line.Split(':');
        if ( parts.Length < 2 ) continue;
        var celebration = Enums.Parse<TorahCelebration>(parts[0].Trim());
        if ( Items[celebration] == null ) Items[celebration] = new List<Tuple<Books, string, string>>();
        var verses = parts[1].Split('-');
        if ( verses.Length < 2 ) continue;
        var book = Enums.Parse<Books>(verses[0].Trim());
        string verse1 = verses[1].Trim();
        string verse2 = verses.Length > 2 ? verses[2].Trim() : string.Empty;
        Items[celebration].Add(new Tuple<Books, string, string>(book, verse1, verse2));
      }
    }

    static public NullSafeDictionary<TorahCelebration, List<Tuple<Books, string, string>>> Items
      = new NullSafeDictionary<TorahCelebration, List<Tuple<Books, string, string>>>
      {
        [TorahCelebration.Pessah] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Shemot, "12.1", "12.51"),
          new Tuple<Books, string, string>(Books.Shemot, "13.1", "13.22"),
          new Tuple<Books, string, string>(Books.Shemot, "23.15", ""),
          new Tuple<Books, string, string>(Books.Shemot, "23.18", ""),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.5", "23.8"),
          new Tuple<Books, string, string>(Books.Bamidbar, "9.1", "9.14"),
          new Tuple<Books, string, string>(Books.Bamidbar, "28.16", "28.25"),
          new Tuple<Books, string, string>(Books.Bamidbar, "33.1", "33.5"),
          new Tuple<Books, string, string>(Books.Devarim, "16.1", "16.8"),
          new Tuple<Books, string, string>(Books.Yehoshoua, "5.10", "5.12"),
          new Tuple<Books, string, string>(Books.Melakim_II, "23.21", "23.23"),
          new Tuple<Books, string, string>(Books.Ezra, "6.19", "6.22"),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "30.1", "30.27"),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "35.1", "35.19")
        },

        [TorahCelebration.Chavouot] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Shemot, "23.16", ""),
          new Tuple<Books, string, string>(Books.Shemot, "23.19", ""),
          new Tuple<Books, string, string>(Books.Shemot, "34.22", ""),
          new Tuple<Books, string, string>(Books.Shemot, "34.26", ""),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.9", "23.22"),
          new Tuple<Books, string, string>(Books.Bamidbar, "28.26", "28.31"),
          new Tuple<Books, string, string>(Books.Devarim, "16.9", "16.12"),
        },

        [TorahCelebration.YomTerouah] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Vayiqra, "23.23", "23.25"),
          new Tuple<Books, string, string>(Books.Bamidbar, "10.1", "10.10"),
          new Tuple<Books, string, string>(Books.Bamidbar, "29.1", "29.6"),
          new Tuple<Books, string, string>(Books.Nehemiah, "8.1", "8.12"),
          new Tuple<Books, string, string>(Books.Tehilim, "66.1", "66.20"),
          new Tuple<Books, string, string>(Books.Tehilim, "81.1", "81.16"),
          new Tuple<Books, string, string>(Books.Tehilim, "100.1", "100.5")
        },

        [TorahCelebration.YomHaKipourim] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Vayiqra, "16.1", "16.34"),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.26", "23.32"),
          new Tuple<Books, string, string>(Books.Vayiqra, "25.9", ""),
          new Tuple<Books, string, string>(Books.Bamidbar, "29.7", "29.11"),
          new Tuple<Books, string, string>(Books.Tehilim, "3.1", "3.8"),
          new Tuple<Books, string, string>(Books.Tehilim, "27.1", "27.14"),
          new Tuple<Books, string, string>(Books.Tehilim, "123.1", "123.4"),
          new Tuple<Books, string, string>(Books.Tehilim, "124.1", "124.8"),
          new Tuple<Books, string, string>(Books.Tehilim, "125.1", "125.5"),
          new Tuple<Books, string, string>(Books.Tehilim, "126.1", "126.14"),
        },

        [TorahCelebration.Soukot] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Vayiqra, "23.33", "23.43"),
          new Tuple<Books, string, string>(Books.Bamidbar, "29.12", "29.39"),
          new Tuple<Books, string, string>(Books.Devarim, "16.13", "16.17"),
          new Tuple<Books, string, string>(Books.Devarim, "31.10", "31.13"),
          new Tuple<Books, string, string>(Books.Shoftim, "9.27", ""),
          new Tuple<Books, string, string>(Books.Melakim_I, "8.1", "8.66"),
          new Tuple<Books, string, string>(Books.Yehezqel, "45.25", ""),
          new Tuple<Books, string, string>(Books.Zekaria, "14.16", "14.19"),
          new Tuple<Books, string, string>(Books.Ezra, "3.1", "3.4"),
          new Tuple<Books, string, string>(Books.Nehemiah, "8.13", "8.18"),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "5.1", "5.14"),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "7.1", "7.22"),
        }

      };

  }

}
