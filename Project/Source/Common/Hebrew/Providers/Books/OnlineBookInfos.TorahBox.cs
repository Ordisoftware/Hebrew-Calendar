/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2022-02 </created>
/// <edited> 2022-02 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineBookInfos
{

  static public readonly Dictionary<TanakBook, string> TorahBox = new()
  {
    // Torah
    { TanakBook.Bereshit, "torah/genese" },
    { TanakBook.Shemot, "torah/exode" },
    { TanakBook.Vayiqra, "torah/levitique" },
    { TanakBook.Bamidbar, "torah/nombres" },
    { TanakBook.Devarim, "torah/deuteronome" },
    // Nevi'im
    { TanakBook.Yehoshoua, "neviim/josue" },
    { TanakBook.Shoftim, "neviim/juges" },
    { TanakBook.Shemouel_I, "neviim/livre-de-samuel-i" },
    { TanakBook.Shemouel_II, "neviim/livre-de-samuel-ii" },
    { TanakBook.Melakim_I, "neviim/livre-des-rois-i" },
    { TanakBook.Melakim_II, "neviim/livre-des-rois-ii" },
    { TanakBook.Yeshayahou, "neviim/isaie" },
    { TanakBook.Yirmeyahou, "neviim/jeremie" },
    { TanakBook.Yehezqel, "neviim/ezechiel" },
    { TanakBook.Hoshea, "neviim/osee" },
    { TanakBook.Yoel, "neviim/yoel" },
    { TanakBook.Amos, "neviim/amos" },
    { TanakBook.Obadyah, "neviim/obadia" },
    { TanakBook.Yonah, "neviim/jonas" },
    { TanakBook.Mikah, "neviim/michee" },
    { TanakBook.Nahoum, "neviim/nahoum" },
    { TanakBook.Habaqouq, "neviim/habacuc" },
    { TanakBook.Tsephaniah, "neviim/cephania" },
    { TanakBook.Hagai, "neviim/haggai" },
    { TanakBook.Zekaria, "neviim/zacharie" },
    { TanakBook.Malaki, "neviim/malachie" },
    // Ketouvim
    { TanakBook.Tehilim, "ketouvim/psaumes" },
    { TanakBook.Mishlei, "ketouvim/proverbes" },
    { TanakBook.Iyov, "ketouvim/job" },
    { TanakBook.Shir_HaShirim, "ketouvim/cantique-des-cantiques" },
    { TanakBook.Ruth, "ketouvim/ruth" },
    { TanakBook.Eikah, "ketouvim/lamentations" },
    { TanakBook.Qohelet, "ketouvim/ecclésiaste" },
    { TanakBook.Esther, "ketouvim/esther" },
    { TanakBook.Daniel, "ketouvim/daniel" },
    { TanakBook.Ezra, "ketouvim/ezra" },
    { TanakBook.Nehemiah, "ketouvim/nehemia" },
    { TanakBook.Divrei_HaYamim_I, "ketouvim/chroniques-i" },
    { TanakBook.Divrei_HaYamim_II, "ketouvim/chroniques-ii" }
  };

}
