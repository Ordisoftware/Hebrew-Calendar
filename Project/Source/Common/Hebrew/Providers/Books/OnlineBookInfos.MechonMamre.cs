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
/// <created> 2019-09 </created>
/// <edited> 2019-09 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineBookInfos
{

  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
  static public readonly Dictionary<TanakBook, string> MechonMamre = new()
  {
    // Torah
    { TanakBook.Bereshit, "01" },
    { TanakBook.Shemot, "02" },
    { TanakBook.Vayiqra, "03" },
    { TanakBook.Bamidbar, "04" },
    { TanakBook.Devarim, "05" },
    // Nevi'im
    { TanakBook.Yehoshoua, "06" },
    { TanakBook.Shoftim, "07" },
    { TanakBook.Shemouel_I, "08a" },
    { TanakBook.Shemouel_II, "08b" },
    { TanakBook.Melakim_I, "09a" },
    { TanakBook.Melakim_II, "09b" },
    { TanakBook.Yeshayahou, "10" },
    { TanakBook.Yirmeyahou, "11" },
    { TanakBook.Yehezqel, "12" },
    { TanakBook.Hoshea, "13" },
    { TanakBook.Yoel, "14" },
    { TanakBook.Amos, "15" },
    { TanakBook.Obadyah, "16" },
    { TanakBook.Yonah, "17" },
    { TanakBook.Mikah, "18" },
    { TanakBook.Nahoum, "19" },
    { TanakBook.Habaqouq, "20" },
    { TanakBook.Tsephaniah, "21" },
    { TanakBook.Hagai, "22" },
    { TanakBook.Zekaria, "23" },
    { TanakBook.Malaki, "24" },
    // Ketouvim
    { TanakBook.Tehilim, "26" },
    { TanakBook.Mishlei, "28" },
    { TanakBook.Iyov, "27" },
    { TanakBook.Shir_HaShirim, "30" },
    { TanakBook.Ruth, "29" },
    { TanakBook.Eikah, "32" },
    { TanakBook.Qohelet, "31" },
    { TanakBook.Esther, "33" },
    { TanakBook.Daniel, "34" },
    { TanakBook.Ezra, "35a" },
    { TanakBook.Nehemiah, "35b" },
    { TanakBook.Divrei_HaYamim_I, "25a" },
    { TanakBook.Divrei_HaYamim_II, "25b" }
  };

}
