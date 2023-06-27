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
/// <created> 2022-05 </created>
/// <edited> 2022-05 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> TheTorahCom = new()
  {
    [TorahBook.Bereshit] = new NullSafeList<string>
    {
      "bereshit",
      "noach",
      "lech-lecha",
      "vayera",
      "chayei-sara",
      "toldot",
      "vayetzei",
      "vayishlach",
      "vayeshev",
      "miketz",
      "vayigash",
      "vayechi"
    },
    [TorahBook.Shemot] = new NullSafeList<string>
    {
      "shemot",
      "vaera",
      "bo",
      "beshalach",
      "yitro",
      "mishpatim",
      "terumah",
      "tetzaveh",
      "ki-tisa",
      "vayakhel",
      "pekudei"
    },
    [TorahBook.Vayiqra] = new NullSafeList<string>
    {
      "vayikra",
      "tzav",
      "shmini",
      "tazria",
      "metzora",
      "achrei-mot",
      "kedoshim",
      "emor",
      "behar",
      "bechukotai"
    },
    [TorahBook.Bamidbar] = new NullSafeList<string>
    {
      "bamidbar",
      "nasso",
      "behaalotcha",
      "shlach",
      "korach",
      "chukat",
      "balak",
      "pinchas",
      "matot",
      "masei"
    },
    [TorahBook.Devarim] = new NullSafeList<string>
    {
      "devarim",
      "vaetchanan",
      "eikev",
      "reeh",
      "shoftim",
      "ki-teitzei",
      "ki-tavo",
      "nitzavim",
      "vayeilech",
      "haazinu",
      "vezot-haberachah"
    }
  };

}
