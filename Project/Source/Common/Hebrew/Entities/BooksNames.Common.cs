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
/// <created> 2020-03 </created>
/// <edited> 2020-08 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  static public partial class BooksNames
  {

    static public readonly NullSafeDictionary<Language, NullSafeOfStringDictionary<Books>> Common
      = new NullSafeDictionary<Language, NullSafeOfStringDictionary<Books>>()
      {
        {
          Language.FR, new NullSafeOfStringDictionary<Books>
          {
            // Torah
            { Books.Bereshit, "Génèse"},
            { Books.Shemot, "Exode"},
            { Books.Vayiqra, "Lévitique"},
            { Books.Bamidbar, "Nombres"},
            { Books.Devarim, "Deutéronome"},
            // Nevi'im
            { Books.Yehoshoua, "Josué"},
            { Books.Shoftim, "Juges"},
            { Books.Shemouel_I, "Samuel 1"},
            { Books.Shemouel_II, "Samuel 1"},
            { Books.Melakim_I, "Rois 1"},
            { Books.Melakim_II, "Rois 1"},
            { Books.Yeshayahou , "Isaïe"},
            { Books.Yirmeyahou , "Jérémie"},
            { Books.Yehezqel, "Ézéchiel"},
            { Books.Hoshea, "Osée"},
            { Books.Yoel, "Joël"},
            { Books.Amos, "Amos"},
            { Books.Obadyah, "Abdias"},
            { Books.Yonah, "Jonas"},
            { Books.Mikah, "Michée"},
            { Books.Nahoum, "Nahum"},
            { Books.Habaqouq, "Habacuc"},
            { Books.Tsephaniah, "Sophonie"},
            { Books.Hagai, "Aggée"},
            { Books.Zekaria, "Zacharie"},
            { Books.Malaki, "Malachie"},
            // Ketouvim
            { Books.Tehilim, "Psaumes"},
            { Books.Mishlei, "Proverbes"},
            { Books.Iyov, "Job"},
            { Books.Shir_HaShirim, "Cantique des cantiques"},
            { Books.Ruth, "Ruth"},
            { Books.Eikah, "Lamentations"},
            { Books.Qohelet, "Ecclésiaste"},
            { Books.Esther, "Esther"},
            { Books.Daniel, "Daniel"},
            { Books.Ezra, "Esdras"},
            { Books.Nehemiah, "Néhémie"},
            { Books.Divrei_HaYamim_I, "Chroniques 1"},
            { Books.Divrei_HaYamim_II, "Chroniques 2"}
          }
        },
       {
         Language.EN, new NullSafeOfStringDictionary<Books>
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
           { Books.Shemouel_I, "Samuel 1" },
           { Books.Shemouel_II, "Samuel 2" },
           { Books.Melakim_I, "Kings 1" },
           { Books.Melakim_II, "Kings 2" },
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
           { Books.Shir_HaShirim, "Song of songs" },
           { Books.Ruth, "Ruth" },
           { Books.Eikah, "Lamentations" },
           { Books.Qohelet, "Ecclesiastes" },
           { Books.Esther, "Esther" },
           { Books.Daniel, "Daniel" },
           { Books.Ezra, "Ezra" },
           { Books.Nehemiah, "Nehemiah" },
           { Books.Divrei_HaYamim_I, "Chronicles 1" },
           { Books.Divrei_HaYamim_II, "Chronicles 2" }
         }
       }
    };

  }

}
