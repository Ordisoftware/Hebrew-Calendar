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

  static public partial class BooksNames
  {

    static public readonly Dictionary<Books, string> Hebrew = new Dictionary<Books, string>()
    {
      // Torah
      { Books.Bereshit, "ty>arb" },
      { Books.Shemot, "tvm>" },
      { Books.Vayiqra, "arqyv" },
      { Books.Bamidbar, "rbdmb" },
      { Books.Devarim, "myrbd" },
      // Nevi'im
      { Books.Yehoshoua, "i>vhy" },
      { Books.Shoftim, "mytpv>" },
      { Books.Shemouel_I, "a lavm>" },
      { Books.Shemouel_II, "b lavm>" },
      { Books.Melakim_I, "a myklm" },
      { Books.Melakim_II, "b myklm" },
      { Books.Yeshayahou , "hyi>y" },
      { Books.Yirmeyahou , "hymry" },
      { Books.Yehezqel, "laqzxy" },
      { Books.Hoshea, "i>vh" },
      { Books.Yoel, "lavy" },
      { Books.Amos, "cvmi" },
      { Books.Obadyah, "hydbvi" },
      { Books.Yonah, "hnvy" },
      { Books.Mikah, "hkym" },
      { Books.Nahoum, "mvxn" },
      { Books.Habaqouq, "qvqbx" },
      { Books.Tsephaniah, "hynpj" },
      { Books.Hagai, "ygx" },
      { Books.Zekaria, "hyrkz" },
      { Books.Malaki, "ykalm" },
      // Ketouvim
      { Books.Tehilim, "mylht" },
      { Books.Mishlei, "yl>m" },
      { Books.Iyov, "bvya" },
      { Books.Shir_HaShirim, "myry>h ry>" },
      { Books.Ruth, "tvr" },
      { Books.Eikah, "hkya" },
      { Books.Qohelet, "tlhq" },
      { Books.Esther, "rt>a" },
      { Books.Daniel, "lanyd" },
      { Books.Ezra, "arzi" },
      { Books.Nehemiah, "hymxn" },
      { Books.Divrei_HaYamim_I, "a mymyh yrbd" },
      { Books.Divrei_HaYamim_II, "b mymyh yrbd" }
    };

  }

}
