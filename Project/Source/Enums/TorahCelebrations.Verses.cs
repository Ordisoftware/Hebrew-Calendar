/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Torah celebrations days, durations and verses.
  /// </summary>
  static partial class TorahCelebrations
  {

    // Shémot 5.1
    // Shémot 12.1 - 12.51
    // Vayiqra 23.5 - 23.8
    // Bamidbar 9.1 - 9.14
    // Bamidbar 28.16 - 28.25
    // Bamidbar 33.3 - 33.4
    // Dévarim 16.1 - 16.9

    static public NullSafeDictionary<TorahCelebration, List<Tuple<Books, string, string>>> Verses
      = new NullSafeDictionary<TorahCelebration, List<Tuple<Books, string, string>>>
      {
        [TorahCelebration.Pessah] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Shemot, "12.1", "12.20"),
          new Tuple<Books, string, string>(Books.Shemot, "13.4", ""),
          new Tuple<Books, string, string>(Books.Shemot, "23.15", "23.16"),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.5", "23.6"),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.10", "23.16"),
          new Tuple<Books, string, string>(Books.Bamidbar, "9.1", "9.12"),
          new Tuple<Books, string, string>(Books.Bamidbar, "28.16", "28.17"),
          new Tuple<Books, string, string>(Books.Bamidbar, "28.26", ""),
          new Tuple<Books, string, string>(Books.Devarim, "16.1", "16.8"),
          new Tuple<Books, string, string>(Books.Yehoshoua, "5.10", ""),
          new Tuple<Books, string, string>(Books.Melakim_II, "23.21", "23.23"),
          new Tuple<Books, string, string>(Books.Ezra, "6.19", "6.22"),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "8.12", "8.13"),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "30.1", "30.27"),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "35.1", "35.19")
        },

        [TorahCelebration.Chavouot] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Shemot, "23.16", "23.17"),
          new Tuple<Books, string, string>(Books.Shemot, "34.22", ""),
          new Tuple<Books, string, string>(Books.Shemot, "34.26", ""),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.9", "23.22"),
          new Tuple<Books, string, string>(Books.Bamidbar, "28.26", "38.31"),
          new Tuple<Books, string, string>(Books.Devarim, "16.1", "16.12"),
          new Tuple<Books, string, string>(Books.Melakim_II, "4.42", ""),
          new Tuple<Books, string, string>(Books.Yeshayahou, "9.2", ""),
          new Tuple<Books, string, string>(Books.Yirmeyahou, "5.24", ""),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "8.12", "8.13")
        },

        [TorahCelebration.YomTerouah] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Shemot, "12.2", ""),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.24", "23.25"),
          new Tuple<Books, string, string>(Books.Bamidbar, "29.1", "29.6"),
          new Tuple<Books, string, string>(Books.Nehemiah, "8.1", "8.10")
        },

        [TorahCelebration.YomHaKipourim] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Shemot, "30.1", "30.10"),
          new Tuple<Books, string, string>(Books.Vayiqra, "10.1", "10.3"),
          new Tuple<Books, string, string>(Books.Vayiqra, "16.1", "16.34"),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.26", "23.32"),
          new Tuple<Books, string, string>(Books.Vayiqra, "25.9", "25.10"),
          new Tuple<Books, string, string>(Books.Bamidbar, "29.7", "29.11"),
          new Tuple<Books, string, string>(Books.Yeshayahou, "58.1", "58.8"),
          new Tuple<Books, string, string>(Books.Yehezqel, "40.1 ?", ""),
          new Tuple<Books, string, string>(Books.Yehezqel, "45.18", "45.20 ?"),
          new Tuple<Books, string, string>(Books.Zekaria, "7.1", "7.5 ?")
        },

        [TorahCelebration.Soukot] = new List<Tuple<Books, string, string>>()
        {
          new Tuple<Books, string, string>(Books.Shemot, "23.16", "23.17"),
          new Tuple<Books, string, string>(Books.Shemot, "34.22", ""),
          new Tuple<Books, string, string>(Books.Vayiqra, "23.34", "23.43"),
          new Tuple<Books, string, string>(Books.Bamidbar, "29.12", "29.39"),
          new Tuple<Books, string, string>(Books.Devarim, "16.13", "16.16"),
          new Tuple<Books, string, string>(Books.Devarim, "31.10", "31.13"),
          new Tuple<Books, string, string>(Books.Shoftim, "9.27", ""),
          new Tuple<Books, string, string>(Books.Shoftim, "21.19", ""),
          new Tuple<Books, string, string>(Books.Melakim_I, "8", ""),
          new Tuple<Books, string, string>(Books.Melakim_I, "8.2", ""),
          new Tuple<Books, string, string>(Books.Melakim_I, "12.32", ""),
          new Tuple<Books, string, string>(Books.Melakim_I, "65", ""),
          new Tuple<Books, string, string>(Books.Yeshayahou, "12.3", ""),
          new Tuple<Books, string, string>(Books.Yehezqel, "45.25", ""),
          new Tuple<Books, string, string>(Books.Zekaria, "14.16", "14.19"),
          new Tuple<Books, string, string>(Books.Ezra, "3.1", "3.4"),
          new Tuple<Books, string, string>(Books.Nehemiah, "8.13", "8.18"),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "5.3", ""),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "7", ""),
          new Tuple<Books, string, string>(Books.Divrei_HaYamim_II, "7.8", "7.9"),
        }

      };

  }

}
