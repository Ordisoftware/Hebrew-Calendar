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
  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> ChabadFR = new()
  {
    [TorahBook.Bereshit] =
    [
      "575415",
      "575416",
      "577471",
      "581616",
      "584879",
      "588389",
      "592391",
      "593809",
      "598617",
      "604519",
      "606768",
      "611211"
    ],
    [TorahBook.Shemot] =
    [
      "614187",
      "618039",
      "620439",
      "624781",
      "626868",
      "629554",
      "631033",
      "635749",
      "637649",
      "641565",
      "644049"
    ],
    [TorahBook.Vayiqra] =
    [
      "495215",
      "495216",
      "497853",
      "656540",
      "659687",
      "662593",
      "662952",
      "510505",
      "671972",
      "675955"
    ],
    [TorahBook.Bamidbar] =
    [
      "518868",
      "520395",
      "523040",
      "525141",
      "527918",
      "530633",
      "531350",
      "533179",
      "703550",
      "703564"
    ],
    [TorahBook.Devarim] =
    [
      "538450",
      "540748",
      "544258",
      "545938",
      "545946",
      "545954",
      "547831",
      "742940",
      "744078",
      "565029",
      "751771"
    ]
  };

}
