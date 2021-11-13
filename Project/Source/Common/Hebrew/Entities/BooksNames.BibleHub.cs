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

    static public readonly Dictionary<TanakBook, string> BibleHub = new()
    {
      // Torah
      { TanakBook.Bereshit, "genesis" },
      { TanakBook.Shemot, "exodus" },
      { TanakBook.Vayiqra, "leviticus" },
      { TanakBook.Bamidbar, "numbers" },
      { TanakBook.Devarim, "deuteronomy" },
      // Nevi'im
      { TanakBook.Yehoshoua, "joshua" },
      { TanakBook.Shoftim, "judges" },
      { TanakBook.Shemouel_I, "1_samuel" },
      { TanakBook.Shemouel_II, "2_samuel" },
      { TanakBook.Melakim_I, "1_kings" },
      { TanakBook.Melakim_II, "2_kings" },
      { TanakBook.Yeshayahou, "isaiah" },
      { TanakBook.Yirmeyahou, "jeremiah" },
      { TanakBook.Yehezqel, "ezekiel" },
      { TanakBook.Hoshea, "hosea" },
      { TanakBook.Yoel, "joel" },
      { TanakBook.Amos, "amos" },
      { TanakBook.Obadyah, "obadiah" },
      { TanakBook.Yonah, "jonah" },
      { TanakBook.Mikah, "micah" },
      { TanakBook.Nahoum, "nahum" },
      { TanakBook.Habaqouq, "habakkuk" },
      { TanakBook.Tsephaniah, "zephaniah" },
      { TanakBook.Hagai, "haggai" },
      { TanakBook.Zekaria, "zechariah" },
      { TanakBook.Malaki, "malachi" },
      // Ketouvim
      { TanakBook.Tehilim, "psalms" },
      { TanakBook.Mishlei, "proverbs" },
      { TanakBook.Iyov, "job" },
      { TanakBook.Shir_HaShirim, "songs" },
      { TanakBook.Ruth, "ruth" },
      { TanakBook.Eikah, "lamentations" },
      { TanakBook.Qohelet, "ecclesiastes" },
      { TanakBook.Esther, "esther" },
      { TanakBook.Daniel, "daniel" },
      { TanakBook.Ezra, "ezra" },
      { TanakBook.Nehemiah, "nehemiah" },
      { TanakBook.Divrei_HaYamim_I, "1_chronicles" },
      { TanakBook.Divrei_HaYamim_II, "2_chronicles" }
    };

  }

}
