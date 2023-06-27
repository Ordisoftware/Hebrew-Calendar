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
/// <created> 2021-06 </created>
/// <edited> 2021-06 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> TorahJews = new()
  {
    [TorahBook.Bereshit] = new NullSafeList<string>
    {
      "bereishis",
      "noach",
      "lech-lecha",
      "vayera",
      "chayei-sara",
      "toldos",
      "vayetzei",
      "vayishlach",
      "vayeshev",
      "miketz",
      "vayigash",
      "vayechi"
    },
    [TorahBook.Shemot] = new NullSafeList<string>
    {
      "shemos",
      "vaera",
      "bo",
      "beshalach",
      "yisro",
      "mishpatim",
      "terumah",
      "tetzaveh",
      "ki-sisa",
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
      "achrei",
      "kedoshim",
      "emor",
      "behar",
      "bechukosai"
    },
    [TorahBook.Bamidbar] = new NullSafeList<string>
    {
      "bamidbar",
      "nasso",
      "behaaloscha",
      "shlach",
      "korach",
      "chukas",
      "balak",
      "pinchas",
      "matos",
      "masei"
    },
    [TorahBook.Devarim] = new NullSafeList<string>
    {
      "devarim",
      "vaeschanan",
      "eikev",
      "reeh",
      "shoftim",
      "ki-seitzei",
      "ki-savo",
      "nitzavim",
      "vayeilech",
      "haazinu",
      "vezos-haberachah"
    }
  };

}
