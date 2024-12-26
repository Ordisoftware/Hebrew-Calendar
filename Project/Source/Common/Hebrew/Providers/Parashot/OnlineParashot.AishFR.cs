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
/// <edited> 2021-03 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> AishFR = new()
  {
    [TorahBook.Bereshit] =
    [
      "128670448",
      "128670513",
      "128670563",
      "128670638",
      "128670688",
      "133862983",
      "133862988",
      "133862993",
      "133863003",
      "133863073",
      "133863083",
      "133863113"
    ],
    [TorahBook.Shemot] =
    [
      "135569193",
      "136498813",
      "137081823",
      "137081838",
      "137165318",
      "137165333",
      "137165403",
      "139626273",
      "137165523",
      "137165603",
      "137165673"
    ],
    [TorahBook.Vayiqra] =
    [
      "139626293",
      "139626323",
      "139626353",
      "139626373",
      "139626383",
      "139626393",
      "139626413",
      "139626423",
      "139626463",
      "139626523"
    ],
    [TorahBook.Bamidbar] =
    [
      "124262214",
      "124262149",
      "124262074",
      "124261614",
      "124262269",
      "124696969",
      "124957759",
      "125473398",
      "125806033",
      "125806228"
    ],
    [TorahBook.Devarim] =
    [
      "126480063",
      "127515668",
      "127991783",
      "128374108",
      "128669483",
      "128670033",
      "128670118",
      "128670193",
      "128670283",
      "130550483",
      "128670388"
    ]
  };

}
