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
/// <created> 2019-09 </created>
/// <edited> 2019-09 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.Hebrew
{

  static public partial class BooksNames
  {

    static public readonly Dictionary<Books, string> Djep = new Dictionary<Books, string>()
    {
      // Torah
      { Books.Bereshit, "1" },
      { Books.Shemot, "2" },
      { Books.Vayiqra, "3" },
      { Books.Bamidbar, "4" },
      { Books.Devarim, "5" },
      // Nevi'im
      { Books.Yehoshoua, "6" },
      { Books.Shoftim, "7" },
      { Books.Shemouel_I, "9" },
      { Books.Shemouel_II, "10" },
      { Books.Melakim_I, "11" },
      { Books.Melakim_II, "12" },
      { Books.Yeshayahou , "23" },
      { Books.Yirmeyahou , "24" },
      { Books.Yehezqel, "26" },
      { Books.Hoshea, "28" },
      { Books.Yoel, "29" },
      { Books.Amos, "30" },
      { Books.Obadyah, "31" },
      { Books.Yonah, "32" },
      { Books.Mikah, "33" },
      { Books.Nahoum, "34" },
      { Books.Habaqouq, "35" },
      { Books.Tsephaniah, "36" },
      { Books.Hagai, "37" },
      { Books.Zekaria, "38" },
      { Books.Malaki, "39" },
      // Ketouvim
      { Books.Tehilim, "19" },
      { Books.Mishlei, "20" },
      { Books.Iyov, "18" },
      { Books.Shir_HaShirim, "22" },
      { Books.Ruth, "8" },
      { Books.Eikah, "25" },
      { Books.Qohelet, "21" },
      { Books.Esther, "17" },
      { Books.Daniel, "27" },
      { Books.Ezra, "15" },
      { Books.Nehemiah, "16" },
      { Books.Divrei_HaYamim_I, "13" },
      { Books.Divrei_HaYamim_II, "14" }
    };

  }

}
