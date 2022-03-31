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
/// <created> 2012-10 </created>
/// <edited> 2019-01 </edited>
namespace Ordisoftware.Hebrew;

static partial class OnlineBooks
{

  static public readonly Dictionary<TanakBook, string> Unicode = new()
  {
    // Torah
    { TanakBook.Bereshit, "בראשית" },
    { TanakBook.Shemot, "שמות" },
    { TanakBook.Vayiqra, "ויקרא" },
    { TanakBook.Bamidbar, "במדבר" },
    { TanakBook.Devarim, "דברים" },
    // Nevi'im
    { TanakBook.Yehoshoua, "יהושע" },
    { TanakBook.Shoftim, "שופטים" },
    { TanakBook.Shemouel_I, "שמואל" },
    { TanakBook.Shemouel_II, "שמואל" },
    { TanakBook.Melakim_I, "מלכים" },
    { TanakBook.Melakim_II, "מלכים" },
    { TanakBook.Yeshayahou, "ישעיהו" },
    { TanakBook.Yirmeyahou, "ירמיהו" },
    { TanakBook.Yehezqel, "יחזקאל" },
    { TanakBook.Hoshea, "הושע" },
    { TanakBook.Yoel, "יואל" },
    { TanakBook.Amos, "עמוס" },
    { TanakBook.Obadyah, "עובדיה" },
    { TanakBook.Yonah, "יונה" },
    { TanakBook.Mikah, "מיכה" },
    { TanakBook.Nahoum, "נחום" },
    { TanakBook.Habaqouq, "חבקוק" },
    { TanakBook.Tsephaniah, "צפניה" },
    { TanakBook.Hagai, "חגי" },
    { TanakBook.Zekaria, "זכריה" },
    { TanakBook.Malaki, "מלאכי" },
    // Ketouvim
    { TanakBook.Tehilim, "תהילים" },
    { TanakBook.Mishlei, "משלי" },
    { TanakBook.Iyov, "איוב" },
    { TanakBook.Shir_HaShirim, "שיר השירים" },
    { TanakBook.Ruth, "רות" },
    { TanakBook.Eikah, "איכה" },
    { TanakBook.Qohelet, "קהלת" },
    { TanakBook.Esther, "אסתר" },
    { TanakBook.Daniel, "דניאל" },
    { TanakBook.Ezra, "עזרא" },
    { TanakBook.Nehemiah, "ונחמיה" },
    { TanakBook.Divrei_HaYamim_I, "דברי הימים" },
    { TanakBook.Divrei_HaYamim_II, "דברי הימים" }
  };

}
