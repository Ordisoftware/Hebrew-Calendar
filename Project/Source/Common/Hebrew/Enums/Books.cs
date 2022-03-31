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
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew;

public enum TanakBook
{
  // Torah
  Bereshit = 1, Shemot, Vayiqra, Bamidbar, Devarim,
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

public enum TorahBook
{
  Bereshit = TanakBook.Bereshit,
  Shemot = TanakBook.Shemot,
  Vayiqra = TanakBook.Vayiqra,
  Bamidbar = TanakBook.Bamidbar,
  Devarim = TanakBook.Devarim
};

public enum NeviimBook
{
  Yehoshoua = TanakBook.Yehoshoua,
  Shoftim = TanakBook.Shoftim,
  Shemouel_I = TanakBook.Shemouel_I,
  Shemouel_II = TanakBook.Shemouel_II,
  Melakim_I = TanakBook.Melakim_I,
  Melakim_II = TanakBook.Melakim_II,
  Yeshayahou = TanakBook.Yeshayahou,
  Yirmeyahou = TanakBook.Yirmeyahou,
  Yehezqel = TanakBook.Yehezqel,
  Hoshea = TanakBook.Hoshea,
  Yoel = TanakBook.Yoel,
  Amos = TanakBook.Amos,
  Obadyah = TanakBook.Obadyah,
  Yonah = TanakBook.Yonah,
  Mikah = TanakBook.Mikah,
  Nahoum = TanakBook.Nahoum,
  Habaqouq = TanakBook.Habaqouq,
  Tsephaniah = TanakBook.Tsephaniah,
  Hagai = TanakBook.Hagai,
  Zekaria = TanakBook.Zekaria,
  Malaki = TanakBook.Malaki
};

public enum KetouvimBook
{
  Tehilim = TanakBook.Tehilim,
  Mishlei = TanakBook.Mishlei,
  Iyov = TanakBook.Iyov,
  Shir_HaShirim = TanakBook.Shir_HaShirim,
  Ruth = TanakBook.Ruth,
  Eikah = TanakBook.Eikah,
  Qohelet = TanakBook.Qohelet,
  Esther = TanakBook.Esther,
  Daniel = TanakBook.Daniel,
  Ezra = TanakBook.Ezra,
  Nehemiah = TanakBook.Nehemiah,
  Divrei_HaYamim_I = TanakBook.Divrei_HaYamim_I,
  Divrei_HaYamim_II = TanakBook.Divrei_HaYamim_II
};
