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

  static public readonly Dictionary<TanakBook, string> Hebrew = new()
  {
    // Torah
    { TanakBook.Bereshit, "ty>arb" },
    { TanakBook.Shemot, "tvm>" },
    { TanakBook.Vayiqra, "arqyv" },
    { TanakBook.Bamidbar, "rbdmb" },
    { TanakBook.Devarim, "myrbd" },
    // Nevi'im
    { TanakBook.Yehoshoua, "i>vhy" },
    { TanakBook.Shoftim, "mytpv>" },
    { TanakBook.Shemouel_I, "a lavm>" },
    { TanakBook.Shemouel_II, "b lavm>" },
    { TanakBook.Melakim_I, "a myklm" },
    { TanakBook.Melakim_II, "b myklm" },
    { TanakBook.Yeshayahou, "hyi>y" },
    { TanakBook.Yirmeyahou, "hymry" },
    { TanakBook.Yehezqel, "laqzxy" },
    { TanakBook.Hoshea, "i>vh" },
    { TanakBook.Yoel, "lavy" },
    { TanakBook.Amos, "cvmi" },
    { TanakBook.Obadyah, "hydbvi" },
    { TanakBook.Yonah, "hnvy" },
    { TanakBook.Mikah, "hkym" },
    { TanakBook.Nahoum, "mvxn" },
    { TanakBook.Habaqouq, "qvqbx" },
    { TanakBook.Tsephaniah, "hynpj" },
    { TanakBook.Hagai, "ygx" },
    { TanakBook.Zekaria, "hyrkz" },
    { TanakBook.Malaki, "ykalm" },
    // Ketouvim
    { TanakBook.Tehilim, "mylht" },
    { TanakBook.Mishlei, "yl>m" },
    { TanakBook.Iyov, "bvya" },
    { TanakBook.Shir_HaShirim, "myry>h ry>" },
    { TanakBook.Ruth, "tvr" },
    { TanakBook.Eikah, "hkya" },
    { TanakBook.Qohelet, "tlhq" },
    { TanakBook.Esther, "rt>a" },
    { TanakBook.Daniel, "lanyd" },
    { TanakBook.Ezra, "arzi" },
    { TanakBook.Nehemiah, "hymxn" },
    { TanakBook.Divrei_HaYamim_I, "a mymyh yrbd" },
    { TanakBook.Divrei_HaYamim_II, "b mymyh yrbd" }
  };

}
