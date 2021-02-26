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

  static partial class BooksNames
  {

    static public readonly Dictionary<Books, string> MechonMamre = new Dictionary<Books, string>()
    {
      // Torah
      { Books.Bereshit, "01" },
      { Books.Shemot, "02" },
      { Books.Vayiqra, "03" },
      { Books.Bamidbar, "04" },
      { Books.Devarim, "05" },
      // Nevi'im
      { Books.Yehoshoua, "06" },
      { Books.Shoftim, "07" },
      { Books.Shemouel_I, "08a" },
      { Books.Shemouel_II, "08b" },
      { Books.Melakim_I, "09a" },
      { Books.Melakim_II, "09b" },
      { Books.Yeshayahou , "10" },
      { Books.Yirmeyahou , "11" },
      { Books.Yehezqel, "12" },
      { Books.Hoshea, "13" },
      { Books.Yoel, "14" },
      { Books.Amos, "15" },
      { Books.Obadyah, "16" },
      { Books.Yonah, "17" },
      { Books.Mikah, "18" },
      { Books.Nahoum, "19" },
      { Books.Habaqouq, "20" },
      { Books.Tsephaniah, "21" },
      { Books.Hagai, "22" },
      { Books.Zekaria, "23" },
      { Books.Malaki, "24" },
      // Ketouvim
      { Books.Tehilim, "26" },
      { Books.Mishlei, "28" },
      { Books.Iyov, "27" },
      { Books.Shir_HaShirim, "30" },
      { Books.Ruth, "29" },
      { Books.Eikah, "32" },
      { Books.Qohelet, "31" },
      { Books.Esther, "33" },
      { Books.Daniel, "34" },
      { Books.Ezra, "35a" },
      { Books.Nehemiah, "35b" },
      { Books.Divrei_HaYamim_I, "25a" },
      { Books.Divrei_HaYamim_II, "25b" }
    };

  }

}
