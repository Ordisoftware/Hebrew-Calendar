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
/// <created> 2021-09 </created>
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew;

static partial class OnlineParashot
{

  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> MyJewishLearning = new()
  {
    [TorahBook.Bereshit] = new NullSafeList<string>
    {
      "parashat-bereshit",
      "parashat-noach",
      "parashat-lech-lecha",
      "parashat-vayera",
      "parashat-chayei-sara",
      "parashat-toldot",
      "parashat-vayetzei",
      "parashat-vayishlach",
      "parashat-vayeshev",
      "parashat-miketz",
      "parashat-vayigash",
      "parashat-vayechi",
    },
    [TorahBook.Shemot] = new NullSafeList<string>
    {
      "parashat-shemot",
      "parashat-vaera",
      "parashat-bo",
      "parashat-beshalach",
      "parashat-yitro",
      "parashat-mishpatim",
      "parashat-terumah",
      "parashat-tetzaveh",
      "parashat-ki-tisa",
      "parashat-vayakhel",
      "parashat-pekudei",
    },
    [TorahBook.Vayiqra] = new NullSafeList<string>
    {
      "parashat-vayikra",
      "parashat-tzav",
      "parashat-shmini",
      "parashat-tazria",
      "parashat-metzora",
      "parashat-achrei-mot",
      "parashat-kedoshim",
      "parashat-emor",
      "parashat-behar",
      "parashat-bechukotai",
    },
    [TorahBook.Bamidbar] = new NullSafeList<string>
    {
      "parashat-bamidbar",
      "parashat-nasso",
      "parashat-behaalotcha",
      "parashat-shlach",
      "parashat-korach",
      "parashat-chukat",
      "parashat-balak",
      "parashat-pinchas",
      "parashat-matot",
      "parashat-masei",
    },
    [TorahBook.Devarim] = new NullSafeList<string>
    {
      "parashat-devarim",
      "parashat-vaetchanan",
      "parashat-eikev",
      "parashat-reeh",
      "parashat-shoftim",
      "parashat-ki-teitzei",
      "parashat-ki-tavo",
      "parashat-nitzavim",
      "parashat-vayeilech",
      "parashat-haazinu",
      "parashat-vezot-haberakhah",
    }
  };

}
