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
/// <created> 2012-10 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.Hebrew
{

  static public partial class BooksNames
  {

    static public readonly Dictionary<Books, string> StudyBible = new Dictionary<Books, string>()
    {
      // Torah
      { Books.Bereshit, "Genesis" },
      { Books.Shemot, "Exodus" },
      { Books.Vayiqra, "Leviticus" },
      { Books.Bamidbar, "Numbers" },
      { Books.Devarim, "Deuteronomy" },
      // Nevi'im
      { Books.Yehoshoua, "Joshua" },
      { Books.Shoftim, "Judges" },
      { Books.Shemouel_I, "1 Samuel" },
      { Books.Shemouel_II, "2 Samuel" },
      { Books.Melakim_I, "1 Kings" },
      { Books.Melakim_II, "2 Kings" },
      { Books.Yeshayahou , "Isaiah" },
      { Books.Yirmeyahou , "Jeremiah" },
      { Books.Yehezqel, "Ezekiel" },
      { Books.Hoshea, "Hosea" },
      { Books.Yoel, "Joel" },
      { Books.Amos, "Amos" },
      { Books.Obadyah, "Obadiah" },
      { Books.Yonah, "Jonah" },
      { Books.Mikah, "Micah" },
      { Books.Nahoum, "Nahum" },
      { Books.Habaqouq, "Habakkuk" },
      { Books.Tsephaniah, "Zephaniah" },
      { Books.Hagai, "Haggai" },
      { Books.Zekaria, "Zechariah" },
      { Books.Malaki, "Malachi" },
      // Ketouvim
      { Books.Tehilim, "Psalms" },
      { Books.Mishlei, "Proverbs" },
      { Books.Iyov, "Job" },
      { Books.Shir_HaShirim, "Song of Songs" },
      { Books.Ruth, "Ruth" },
      { Books.Eikah, "Lamentations" },
      { Books.Qohelet, "Ecclesiastes" },
      { Books.Esther, "Esther" },
      { Books.Daniel, "Daniel" },
      { Books.Ezra, "Ezra" },
      { Books.Nehemiah, "Nehemiah" },
      { Books.Divrei_HaYamim_I, "1 Chronicles" },
      { Books.Divrei_HaYamim_II, "2 Chronicles" }
    };

  }

}
