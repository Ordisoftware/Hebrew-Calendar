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
/// <created> 2021-09 </created>
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> TheYeshivaNet = new()
  {
    [TorahBook.Bereshit] =
    [
      "c7/torah/parsha/bereshit/bereshit",
      "c8/torah/parsha/bereshit/noach",
      "c9/torah/parsha/bereshit/lech-lecha",
      "c10/torah/parsha/bereshit/vayera",
      "c11/torah/parsha/bereshit/chayei-sarah",
      "c13/torah/parsha/bereshit/toldot",
      "c16/torah/parsha/bereshit/vayetzei",
      "c18/torah/parsha/bereshit/vayishlach",
      "c15/torah/parsha/bereshit/vayeshev",
      "c12/torah/parsha/bereshit/miketz",
      "c17/torah/parsha/bereshit/vayigash",
      "c14/torah/parsha/bereshit/vayechi",
    ],
    [TorahBook.Shemot] =
    [
      "c25/torah/parsha/shemot/shemot",
      "c28/torah/parsha/shemot/vaera",
      "c21/torah/parsha/shemot/bo",
      "c20/torah/parsha/shemot/beshalach",
      "c30/torah/parsha/shemot/yisro",
      "c23/torah/parsha/shemot/mishpatim",
      "c26/torah/parsha/shemot/terumah",
      "c27/torah/parsha/shemot/tetzaveh",
      "c22/torah/parsha/shemot/ki-tisa",
      "c29/torah/parsha/shemot/vayakhel",
      "c24/torah/parsha/shemot/pekudei",
    ],
    [TorahBook.Vayiqra] =
    [
      "c41/torah/parsha/vayikra/vayikra",
      "c40/torah/parsha/vayikra/tzav",
      "c38/torah/parsha/vayikra/shmini",
      "c39/torah/parsha/vayikra/tazria",
      "c37/torah/parsha/vayikra/metzora",
      "c32/torah/parsha/vayikra/acharei-mos",
      "c36/torah/parsha/vayikra/kedoshim",
      "c35/torah/parsha/vayikra/emor",
      "c34/torah/parsha/vayikra/behar",
      "c33/torah/parsha/vayikra/bechukotai",
    ],
    [TorahBook.Bamidbar] =
    [
      "c44/torah/parsha/bamidbar/bamidbar",
      "c50/torah/parsha/bamidbar/nasso",
      "c45/torah/parsha/bamidbar/behaalotcha",
      "c52/torah/parsha/bamidbar/shlach",
      "c47/torah/parsha/bamidbar/korach",
      "c46/torah/parsha/bamidbar/chukat",
      "c43/torah/parsha/bamidbar/balak",
      "c51/torah/parsha/bamidbar/pinchas",
      "c49/torah/parsha/bamidbar/matot",
      "c48/torah/parsha/bamidbar/maasei",
    ],
    [TorahBook.Devarim] =
    [
      "c55/torah/parsha/devarim/devarim",
      "c63/torah/parsha/devarim/vaetchanan",
      "c56/torah/parsha/devarim/eikev",
      "c61/torah/parsha/devarim/reeh",
      "c62/torah/parsha/devarim/shoftim",
      "c59/torah/parsha/devarim/ki-teitzei",
      "c58/torah/parsha/devarim/ki-tavo",
      "c60/torah/parsha/devarim/nitzavim",
      "c64/torah/parsha/devarim/vayeilech",
      "c57/torah/parsha/devarim/haazinu",
      "c65/torah/parsha/devarim/vezot-haberakhah",
    ]
  };

}
