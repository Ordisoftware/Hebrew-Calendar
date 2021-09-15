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

  static partial class BooksNames
  {

    static public readonly Dictionary<Books, string> Unicode = new Dictionary<Books, string>()
    {
      // Torah
      { Books.Bereshit, "בראשית" },
      { Books.Shemot, "שמות" },
      { Books.Vayiqra, "ויקרא" },
      { Books.Bamidbar, "במדבר" },
      { Books.Devarim, "דברים" },
      // Nevi'im
      { Books.Yehoshoua, "יהושע" },
      { Books.Shoftim, "שופטים" },
      { Books.Shemouel_I, "שמואל" },
      { Books.Shemouel_II, "שמואל" },
      { Books.Melakim_I, "מלכים" },
      { Books.Melakim_II, "מלכים" },
      { Books.Yeshayahou , "ישעיהו" },
      { Books.Yirmeyahou , "ירמיהו" },
      { Books.Yehezqel, "יחזקאל" },
      { Books.Hoshea, "הושע" },
      { Books.Yoel, "יואל" },
      { Books.Amos, "עמוס" },
      { Books.Obadyah, "עובדיה" },
      { Books.Yonah, "יונה" },
      { Books.Mikah, "מיכה" },
      { Books.Nahoum, "נחום" },
      { Books.Habaqouq, "חבקוק" },
      { Books.Tsephaniah, "צפניה" },
      { Books.Hagai, "חגי" },
      { Books.Zekaria, "זכריה" },
      { Books.Malaki, "מלאכי" },
      // Ketouvim
      { Books.Tehilim, "תהילים" },
      { Books.Mishlei, "משלי" },
      { Books.Iyov, "איוב" },
      { Books.Shir_HaShirim, "שיר השירים" },
      { Books.Ruth, "רות" },
      { Books.Eikah, "איכה" },
      { Books.Qohelet, "קהלת" },
      { Books.Esther, "אסתר" },
      { Books.Daniel, "דניאל" },
      { Books.Ezra, "עזרא" },
      { Books.Nehemiah, "ונחמיה" },
      { Books.Divrei_HaYamim_I, "דברי הימים" },
      { Books.Divrei_HaYamim_II, "דברי הימים" }
    };

  }

}
