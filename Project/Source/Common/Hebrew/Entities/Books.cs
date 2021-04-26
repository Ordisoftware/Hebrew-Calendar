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
/// <edited> 2019-09 </edited>
using System;

namespace Ordisoftware.Hebrew
{

  public enum Books
  {
    // Torah
    Bereshit, Shemot, Vayiqra, Bamidbar, Devarim,
    // Nevi'im
    Yehoshoua, Shoftim, Shemouel_I, Shemouel_II, Melakim_I, Melakim_II,
    Yeshayahou, Yirmeyahou, Yehezqel,
    Hoshea, Yoel, Amos, Obadyah, Yonah, Mikah,
    Nahoum, Habaqouq, Tsephaniah, Hagai, Zekaria, Malaki,
    // Ketouvim
    Tehilim, Mishlei, Iyov,
    Shir_HaShirim, Ruth, Eikah, Qohelet, Esther, Daniel, Ezra, Nehemiah,
    Divrei_HaYamim_I, Divrei_HaYamim_II
  };

  public enum TorahBooks
  {
    Bereshit = Books.Bereshit,
    Shemot = Books.Shemot,
    Vayiqra = Books.Vayiqra,
    Bamidbar = Books.Bamidbar,
    Devarim = Books.Devarim
  };

  public enum NeviimBooks
  {
    Yehoshoua = Books.Yehoshoua,
    Shoftim = Books.Shoftim,
    Shemouel_I = Books.Shemouel_I,
    Shemouel_II = Books.Shemouel_II,
    Melakim_I = Books.Melakim_I,
    Melakim_II = Books.Melakim_II,
    Yeshayahou = Books.Yeshayahou,
    Yirmeyahou = Books.Yirmeyahou,
    Yehezqel = Books.Yehezqel,
    Hoshea = Books.Hoshea,
    Yoel = Books.Yoel,
    Amos = Books.Amos,
    Obadyah = Books.Obadyah,
    Yonah = Books.Yonah,
    Mikah = Books.Mikah,
    Nahoum = Books.Nahoum,
    Habaqouq = Books.Habaqouq,
    Tsephaniah = Books.Tsephaniah,
    Hagai = Books.Hagai,
    Zekaria = Books.Zekaria,
    Malaki = Books.Malaki
  };

  public enum KetouvimBooks
  {
    Tehilim = Books.Tehilim,
    Mishlei = Books.Mishlei,
    Iyov = Books.Iyov,
    Shir_HaShirim = Books.Shir_HaShirim,
    Ruth = Books.Ruth,
    Eikah = Books.Eikah,
    Qohelet = Books.Qohelet,
    Esther = Books.Esther,
    Daniel = Books.Daniel,
    Ezra = Books.Ezra,
    Nehemiah = Books.Nehemiah,
    Divrei_HaYamim_I = Books.Divrei_HaYamim_I,
    Divrei_HaYamim_II = Books.Divrei_HaYamim_II
  };

}
