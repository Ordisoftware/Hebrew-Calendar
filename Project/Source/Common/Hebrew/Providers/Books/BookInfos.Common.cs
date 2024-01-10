/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2024 Olivier Rogier.
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
namespace Ordisoftware.Hebrew;

static public partial class BookInfos
{

  static public readonly NullSafeDictionary<Language, NullSafeOfStringDictionary<TanakBook>> Common = new()
  {
    [Language.FR] = new NullSafeOfStringDictionary<TanakBook>
    {
      // Torah
      { TanakBook.Bereshit, "Genèse"},
      { TanakBook.Shemot, "Exode"},
      { TanakBook.Vayiqra, "Lévitique"},
      { TanakBook.Bamidbar, "Nombres"},
      { TanakBook.Devarim, "Deutéronome"},
      // Nevi'im
      { TanakBook.Yehoshoua, "Josué"},
      { TanakBook.Shoftim, "Juges"},
      { TanakBook.Shemouel_I, "Samuel 1"},
      { TanakBook.Shemouel_II, "Samuel 2"},
      { TanakBook.Melakim_I, "Rois 1"},
      { TanakBook.Melakim_II, "Rois 2"},
      { TanakBook.Yeshayahou, "Isaïe"},
      { TanakBook.Yirmeyahou, "Jérémie"},
      { TanakBook.Yehezqel, "Ézéchiel"},
      { TanakBook.Hoshea, "Osée"},
      { TanakBook.Yoel, "Joël"},
      { TanakBook.Amos, "Amos"},
      { TanakBook.Obadyah, "Abdias"},
      { TanakBook.Yonah, "Jonas"},
      { TanakBook.Mikah, "Michée"},
      { TanakBook.Nahoum, "Nahum"},
      { TanakBook.Habaqouq, "Habacuc"},
      { TanakBook.Tsephaniah, "Sophonie"},
      { TanakBook.Hagai, "Aggée"},
      { TanakBook.Zekaria, "Zacharie"},
      { TanakBook.Malaki, "Malachie"},
      // Ketouvim
      { TanakBook.Tehilim, "Psaumes"},
      { TanakBook.Mishlei, "Proverbes"},
      { TanakBook.Iyov, "Job"},
      { TanakBook.Shir_HaShirim, "Cantique des cantiques"},
      { TanakBook.Ruth, "Ruth"},
      { TanakBook.Eikah, "Lamentations"},
      { TanakBook.Qohelet, "Ecclésiaste"},
      { TanakBook.Esther, "Esther"},
      { TanakBook.Daniel, "Daniel"},
      { TanakBook.Ezra, "Esdras"},
      { TanakBook.Nehemiah, "Néhémie"},
      { TanakBook.Divrei_HaYamim_I, "Chroniques 1"},
      { TanakBook.Divrei_HaYamim_II, "Chroniques 2"}
    },
    [Language.EN] = new NullSafeOfStringDictionary<TanakBook>
    {
      // Torah
      { TanakBook.Bereshit, "Genesis" },
      { TanakBook.Shemot, "Exodus" },
      { TanakBook.Vayiqra, "Leviticus" },
      { TanakBook.Bamidbar, "Numbers" },
      { TanakBook.Devarim, "Deuteronomy" },
      // Nevi'im
      { TanakBook.Yehoshoua, "Joshua" },
      { TanakBook.Shoftim, "Judges" },
      { TanakBook.Shemouel_I, "Samuel 1" },
      { TanakBook.Shemouel_II, "Samuel 2" },
      { TanakBook.Melakim_I, "Kings 1" },
      { TanakBook.Melakim_II, "Kings 2" },
      { TanakBook.Yeshayahou, "Isaiah" },
      { TanakBook.Yirmeyahou, "Jeremiah" },
      { TanakBook.Yehezqel, "Ezekiel" },
      { TanakBook.Hoshea, "Hosea" },
      { TanakBook.Yoel, "Joel" },
      { TanakBook.Amos, "Amos" },
      { TanakBook.Obadyah, "Obadiah" },
      { TanakBook.Yonah, "Jonah" },
      { TanakBook.Mikah, "Micah" },
      { TanakBook.Nahoum, "Nahum" },
      { TanakBook.Habaqouq, "Habakkuk" },
      { TanakBook.Tsephaniah, "Zephaniah" },
      { TanakBook.Hagai, "Haggai" },
      { TanakBook.Zekaria, "Zechariah" },
      { TanakBook.Malaki, "Malachi" },
      // Ketouvim
      { TanakBook.Tehilim, "Psalms" },
      { TanakBook.Mishlei, "Proverbs" },
      { TanakBook.Iyov, "Job" },
      { TanakBook.Shir_HaShirim, "Song of songs" },
      { TanakBook.Ruth, "Ruth" },
      { TanakBook.Eikah, "Lamentations" },
      { TanakBook.Qohelet, "Ecclesiastes" },
      { TanakBook.Esther, "Esther" },
      { TanakBook.Daniel, "Daniel" },
      { TanakBook.Ezra, "Ezra" },
      { TanakBook.Nehemiah, "Nehemiah" },
      { TanakBook.Divrei_HaYamim_I, "Chronicles 1" },
      { TanakBook.Divrei_HaYamim_II, "Chronicles 2" }
    }
  };

}
