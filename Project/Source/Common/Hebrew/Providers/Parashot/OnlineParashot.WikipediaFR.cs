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
/// <created> 2021-03 </created>
/// <edited> 2021-03 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> WikipediaFR = new()
  {
    [TorahBook.Bereshit] = new NullSafeList<string>
    {
      "Bereshit_(parasha)",
      "Noa%27h_(parasha)",
      "Lekh_Lekha",
      "Vayera",
      "Haye_Sarah",
      "Toledot",
      "Vayetze",
      "Vayishla%27h",
      "Vayeshev",
      "Miketz",
      "Vayigash",
      "Vaye%27hi"
    },
    [TorahBook.Shemot] = new NullSafeList<string>
    {
      "Shemot_(parasha)",
      "Va%27era",
      "Bo_(parasha)",
      "Beshalakh",
      "Yitro_(parasha)",
      "Mishpatim",
      "Teroumah_(parasha)",
      "Tetzave",
      "Ki_Tissa",
      "Vayaqhel",
      "Peqoudei"
    },
    [TorahBook.Vayiqra] = new NullSafeList<string>
    {
      "Vayikra_(parasha)",
      "Tzav",
      "Shemini",
      "Tazria",
      "Metzora",
      "A%27harei",
      "Kedoshim_(parasha)",
      "Emor",
      "Behar",
      "Be%27houkota%C3%AF"
    },
    [TorahBook.Bamidbar] = new NullSafeList<string>
    {
      "Bemidbar_(parasha)",
      "Nasso",
      "Beha%27alot%27kha",
      "Shlakh",
      "Kora%27h_(parasha)",
      "Houkat",
      "Balak_(parasha)",
      "Pin%27has_(parasha)",
      "Matot",
      "Massei"
    },
    [TorahBook.Devarim] = new NullSafeList<string>
    {
      "Devarim_(parasha)",
      "Va%27et%27hanan",
      "Eikev",
      "Re%27eh",
      "Shoftim_(parasha)",
      "Ki_Tetze",
      "Ki_Tavo",
      "Nitzavim",
      "Vayelekh",
      "Haazinou",
      "V%C3%A8zot_HaBerakha"
    }
  };

}
