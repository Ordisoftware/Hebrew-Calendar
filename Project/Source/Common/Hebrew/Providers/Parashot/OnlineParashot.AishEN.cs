/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2025 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> AishEN = new()
  {
    [TorahBook.Bereshit] =
    [
      "bereishit",
      "noach",
      "lech-lecha",
      "vayeira",
      "chayei-sarah",
      "toldot",
      "vayetzei",
      "vayishlach",
      "vayeshev",
      "mikeitz",
      "vayigash",
      "vayechi"
    ],
    [TorahBook.Shemot] =
    [
      "shmot",
      "vaeira",
      "bo",
      "beshalach",
      "yitro",
      "mishpatim",
      "trumah",
      "tetzaveh",
      "ki-tisa",
      "vayakhel",
      "pekudei"
    ],
    [TorahBook.Vayiqra] =
    [
      "vayikra",
      "tzav",
      "shmini",
      "tazria",
      "metzora",
      "acharei-mot",
      "kedoshim",
      "emor",
      "behar",
      "bechukotai"
    ],
    [TorahBook.Bamidbar] =
    [
      "bamidbar",
      "naso",
      "behalotcha",
      "shlach",
      "korach",
      "chukat",
      "balak",
      "pinchas",
      "matot",
      "masay"
    ],
    [TorahBook.Devarim] =
    [
      "devarim",
      "vetchanan",
      "ekev",
      "reeh",
      "shoftim",
      "ki-tetzei",
      "ki-tavo",
      "nitzavim",
      "vayelech",
      "haazinu",
      "vZot-haBracha"
    ]
  };

}
