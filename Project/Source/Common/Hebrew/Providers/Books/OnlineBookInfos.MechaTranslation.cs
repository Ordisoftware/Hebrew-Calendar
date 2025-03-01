/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words/Pi.
/// Copyright 2012-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2023-01 </created>
/// <edited> 2023-01 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineBookInfos
{

  static public readonly Dictionary<TanakBook, string> MechanicalTranslation = new()
  {
    // Torah
    { TanakBook.Bereshit, "G" },
    { TanakBook.Shemot, "E" },
    { TanakBook.Vayiqra, "L" },
    { TanakBook.Bamidbar, "N" },
    { TanakBook.Devarim, "D" },
    // Nevi'im
    { TanakBook.Yehoshoua, "" },
    { TanakBook.Shoftim, "" },
    { TanakBook.Shemouel_I, "" },
    { TanakBook.Shemouel_II, "" },
    { TanakBook.Melakim_I, "" },
    { TanakBook.Melakim_II, "" },
    { TanakBook.Yeshayahou, "" },
    { TanakBook.Yirmeyahou, "" },
    { TanakBook.Yehezqel, "" },
    { TanakBook.Hoshea, "" },
    { TanakBook.Yoel, "" },
    { TanakBook.Amos, "" },
    { TanakBook.Obadyah, "" },
    { TanakBook.Yonah, "" },
    { TanakBook.Mikah, "" },
    { TanakBook.Nahoum, "" },
    { TanakBook.Habaqouq, "" },
    { TanakBook.Tsephaniah, "" },
    { TanakBook.Hagai, "" },
    { TanakBook.Zekaria, "" },
    { TanakBook.Malaki, "" },
    // Ketouvim
    { TanakBook.Tehilim, "" },
    { TanakBook.Mishlei, "" },
    { TanakBook.Iyov, "" },
    { TanakBook.Shir_HaShirim, "" },
    { TanakBook.Ruth, "" },
    { TanakBook.Eikah, "" },
    { TanakBook.Qohelet, "" },
    { TanakBook.Esther, "" },
    { TanakBook.Daniel, "" },
    { TanakBook.Ezra, "" },
    { TanakBook.Nehemiah, "" },
    { TanakBook.Divrei_HaYamim_I, "" },
    { TanakBook.Divrei_HaYamim_II, "" }
  };

}
