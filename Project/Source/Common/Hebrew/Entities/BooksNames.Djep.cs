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
namespace Ordisoftware.Hebrew;

using System.Collections.Generic;

static partial class BooksNames
{

  static public readonly Dictionary<TanakBook, string> Djep = new()
  {
    // Torah
    { TanakBook.Bereshit, "1" },
    { TanakBook.Shemot, "2" },
    { TanakBook.Vayiqra, "3" },
    { TanakBook.Bamidbar, "4" },
    { TanakBook.Devarim, "5" },
    // Nevi'im
    { TanakBook.Yehoshoua, "6" },
    { TanakBook.Shoftim, "7" },
    { TanakBook.Shemouel_I, "9" },
    { TanakBook.Shemouel_II, "10" },
    { TanakBook.Melakim_I, "11" },
    { TanakBook.Melakim_II, "12" },
    { TanakBook.Yeshayahou, "23" },
    { TanakBook.Yirmeyahou, "24" },
    { TanakBook.Yehezqel, "26" },
    { TanakBook.Hoshea, "28" },
    { TanakBook.Yoel, "29" },
    { TanakBook.Amos, "30" },
    { TanakBook.Obadyah, "31" },
    { TanakBook.Yonah, "32" },
    { TanakBook.Mikah, "33" },
    { TanakBook.Nahoum, "34" },
    { TanakBook.Habaqouq, "35" },
    { TanakBook.Tsephaniah, "36" },
    { TanakBook.Hagai, "37" },
    { TanakBook.Zekaria, "38" },
    { TanakBook.Malaki, "39" },
    // Ketouvim
    { TanakBook.Tehilim, "19" },
    { TanakBook.Mishlei, "20" },
    { TanakBook.Iyov, "18" },
    { TanakBook.Shir_HaShirim, "22" },
    { TanakBook.Ruth, "8" },
    { TanakBook.Eikah, "25" },
    { TanakBook.Qohelet, "21" },
    { TanakBook.Esther, "17" },
    { TanakBook.Daniel, "27" },
    { TanakBook.Ezra, "15" },
    { TanakBook.Nehemiah, "16" },
    { TanakBook.Divrei_HaYamim_I, "13" },
    { TanakBook.Divrei_HaYamim_II, "14" }
  };

}
