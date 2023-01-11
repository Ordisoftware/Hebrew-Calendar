/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2023 Olivier Rogier.
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
namespace Ordisoftware.Hebrew;

static public partial class OnlineBookInfos
{

  static public readonly Dictionary<TanakBook, string> Sefaria = new()
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
    { TanakBook.Shemouel_I, "I_Samuel" },
    { TanakBook.Shemouel_II, "II_Samuel" },
    { TanakBook.Melakim_I, "I_Kings" },
    { TanakBook.Melakim_II, "II_Kings" },
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
    { TanakBook.Shir_HaShirim, "Song of Songs" },
    { TanakBook.Ruth, "Ruth" },
    { TanakBook.Eikah, "Lamentations" },
    { TanakBook.Qohelet, "Ecclesiastes" },
    { TanakBook.Esther, "Esther" },
    { TanakBook.Daniel, "Daniel" },
    { TanakBook.Ezra, "Ezra" },
    { TanakBook.Nehemiah, "Nehemiah" },
    { TanakBook.Divrei_HaYamim_I, "I_Chronicles" },
    { TanakBook.Divrei_HaYamim_II, "II_Chronicles" }
  };

}
