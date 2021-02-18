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

    static public readonly Dictionary<Books, string> BibleHub = new Dictionary<Books, string>()
    {
      // Torah
      { Books.Bereshit, "genesis" },
      { Books.Shemot, "exodus" },
      { Books.Vayiqra, "leviticus" },
      { Books.Bamidbar, "numbers" },
      { Books.Devarim, "deuteronomy" },
      // Nevi'im
      { Books.Yehoshoua, "joshua" },
      { Books.Shoftim, "judges" },
      { Books.Shemouel_I, "1_samuel" },
      { Books.Shemouel_II, "2_samuel" },
      { Books.Melakim_I, "1_kings" },
      { Books.Melakim_II, "2_kings" },
      { Books.Yeshayahou , "isaiah" },
      { Books.Yirmeyahou , "jeremiah" },
      { Books.Yehezqel, "ezekiel" },
      { Books.Hoshea, "hosea" },
      { Books.Yoel, "joel" },
      { Books.Amos, "amos" },
      { Books.Obadyah, "obadiah" },
      { Books.Yonah, "jonah" },
      { Books.Mikah, "micah" },
      { Books.Nahoum, "nahum" },
      { Books.Habaqouq, "habakkuk" },
      { Books.Tsephaniah, "zephaniah" },
      { Books.Hagai, "haggai" },
      { Books.Zekaria, "zechariah" },
      { Books.Malaki, "malachi" },
      // Ketouvim
      { Books.Tehilim, "psalms" },
      { Books.Mishlei, "proverbs" },
      { Books.Iyov, "job" },
      { Books.Shir_HaShirim, "songs" },
      { Books.Ruth, "ruth" },
      { Books.Eikah, "lamentations" },
      { Books.Qohelet, "ecclesiastes" },
      { Books.Esther, "esther" },
      { Books.Daniel, "daniel" },
      { Books.Ezra, "ezra" },
      { Books.Nehemiah, "nehemiah" },
      { Books.Divrei_HaYamim_I, "1_chronicles" },
      { Books.Divrei_HaYamim_II, "2_chronicles" }
    };

  }

}
