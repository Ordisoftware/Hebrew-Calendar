/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2024 Olivier Rogier.
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
  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> TorahBox = new()
  {
    [TorahBook.Bereshit] =
    [
      "berechit-genese/berechit/",
      "berechit-genese/noah/",
      "berechit-genese/lekh-lekha/",
      "berechit-genese/vayera/",
      "berechit-genese/haye-sarah/",
      "berechit-genese/toledot/",
      "berechit-genese/vayetse/",
      "berechit-genese/vayichlah/",
      "berechit-genese/vayechev/",
      "berechit-genese/mikets/",
      "berechit-genese/vayigach/",
      "berechit-genese/vayehi/"
    ],
    [TorahBook.Shemot] =
    [
      "chemot-exode/chemot/",
      "chemot-exode/vaera/",
      "chemot-exode/bo/",
      "chemot-exode/bechalah/",
      "chemot-exode/yitro/",
      "chemot-exode/michpatim/",
      "chemot-exode/terouma/",
      "chemot-exode/tetsave/",
      "chemot-exode/ki-tissa/",
      "chemot-exode/vayakhel/",
      "chemot-exode/pekoude/"
    ],
    [TorahBook.Vayiqra] =
    [
      "vayikra-levitique/vayikra/",
      "vayikra-levitique/tsav/",
      "vayikra-levitique/chemini/",
      "vayikra-levitique/tazria/",
      "vayikra-levitique/metsora/",
      "vayikra-levitique/ahare-mot/",
      "vayikra-levitique/kedochim/",
      "vayikra-levitique/emor/",
      "vayikra-levitique/behar/",
      "vayikra-levitique/behoukotai/"
    ],
    [TorahBook.Bamidbar] =
    [
      "bamidbar-nombres/bamidbar/",
      "bamidbar-nombres/nasso/",
      "bamidbar-nombres/behaalotekha/",
      "bamidbar-nombres/chelah-lekha/",
      "bamidbar-nombres/korah/",
      "bamidbar-nombres/houkat/",
      "bamidbar-nombres/balak/",
      "bamidbar-nombres/pinhas/",
      "bamidbar-nombres/matot/",
      "bamidbar-nombres/masse/"
    ],
    [TorahBook.Devarim] =
    [
      "devarim-deuteronome/devarim/",
      "devarim-deuteronome/vaethanane/",
      "devarim-deuteronome/ekev/",
      "devarim-deuteronome/ree/",
      "devarim-deuteronome/choftim/",
      "devarim-deuteronome/ki-tetse/",
      "devarim-deuteronome/ki-tavo/",
      "devarim-deuteronome/nitsavim/",
      "devarim-deuteronome/vayelekh/",
      "devarim-deuteronome/haazinou/",
      "devarim-deuteronome/vezot-haberakha/"
    ]
  };

}
