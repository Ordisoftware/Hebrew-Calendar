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
/// <created> 2021-03 </created>
/// <edited> 2021-03 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  static partial class OnlineParashot
  {

    static public readonly NullSafeDictionary<TorahBooks, NullSafeList<string>> TorahOrg
      = new NullSafeDictionary<TorahBooks, NullSafeList<string>>
      {
        [TorahBooks.Bereshit] = new NullSafeList<string>
        {
          "bereishis",
          "noach",
          "lech-lecha",
          "vayera",
          "chayei-sarah",
          "toldos",
          "vayeitzei",
          "vayishlach",
          "vayeishev",
          "miketz",
          "vayigash",
          "vayechi"
        },
        [TorahBooks.Shemot] = new NullSafeList<string>
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
        [TorahBooks.Vayiqra] = new NullSafeList<string>
        {
          "vayikra",
          "tzav",
          "shemini",
          "tazria",
          "metzorah",
          "acharei-mos",
          "kedoshim",
          "emor",
          "behar",
          "bechukosai"
        },
        [TorahBooks.Bamidbar] = new NullSafeList<string>
        {
          "bamidbar",
          "naso",
          "behaaloscha",
          "shlach",
          "korach",
          "chukas",
          "balak",
          "pinchas",
          "matos",
          "masei"
        },
        [TorahBooks.Devarim] = new NullSafeList<string>
        {
          "devarim",
          "vaeschanan",
          "eikev",
          "reeh",
          "shoftim",
          "ki-seitzei",
          "ki-savo",
          "netzavim",
          "vayeilech",
          "haazinu",
          "vzos-habracha"
        }
      };

  }

}
