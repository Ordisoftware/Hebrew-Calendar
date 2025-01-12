/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words/Pi.
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
/// <edited> 2021-03 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> WikipediaEN = new()
  {
    [TorahBook.Bereshit] =
    [
      "Bereshit_(parsha)",
      "Noach_(parsha)",
      "Lech-Lecha",
      "Vayeira_(parsha)",
      "Chayei_Sarah_(parsha)",
      "Toledot_(parsha)",
      "Vayetze_(parsha)",
      "Vayishlach_(parsha)",
      "Vayeshev_(parsha)",
      "Miketz_(parsha)",
      "Vayigash_(parsha)",
      "Vayechi_(parsha)"
    ],
    [TorahBook.Shemot] =
    [
      "Shemot_(parsha)",
      "Va%27eira_(parsha)",
      "Bo_(parsha)",
      "Beshalach_(parsha)",
      "Yitro_(parsha)",
      "Mishpatim_(parsha)",
      "Terumah_(parsha)",
      "Tetzaveh_(parsha)",
      "Ki_Tisa_(parsha)",
      "Vayakhel_(parsha)",
      "Pekudei_(parsha)"
    ],
    [TorahBook.Vayiqra] =
    [
      "Vayikra_(parsha)",
      "Tzav_(parsha)",
      "Shemini_(parsha)",
      "Tazria_(parsha)",
      "Metzora_(parsha)",
      "Acharei_Mot_(parsha)",
      "Kedoshim_(parsha)",
      "Emor_(parsha)",
      "Behar_(parsha)",
      "Bechukotai_(parsha)"
    ],
    [TorahBook.Bamidbar] =
    [
      "Bemidbar_(parsha)",
      "Naso_(parsha)",
      "Behaalotecha_(parsha)",
      "Shlach_(parsha)",
      "Korach_(parsha)",
      "Chukat_(parsha)",
      "Balak_(parsha)",
      "Pinchas_(parsha)",
      "Matot_(parsha)",
      "Masei_(parsha)"
    ],
    [TorahBook.Devarim] =
    [
      "Devarim_(parsha)",
      "Va%27etchanan_(parsha)",
      "Eikev_(parsha)",
      "Re%27eh_(parsha)",
      "Shoftim_(parsha)",
      "Ki_Teitzei_(parsha)",
      "Ki_Tavo_(parsha)",
      "Nitzavim_(parsha)",
      "Vayelech_(parsha)",
      "Haazinu",
      "V%27Zot_HaBerachah",
    ]
  };

}
