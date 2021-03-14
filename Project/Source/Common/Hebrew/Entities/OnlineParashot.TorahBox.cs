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

    static public readonly NullSafeDictionary<TorahBooks, NullSafeList<string>> TorahBox
      = new NullSafeDictionary<TorahBooks, NullSafeList<string>>
      {
        [TorahBooks.Bereshit] = new NullSafeList<string>
        {
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
        },
        [TorahBooks.Shemot] = new NullSafeList<string>
        {
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
        },
        [TorahBooks.Vayiqra] = new NullSafeList<string>
        {
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
        },
        [TorahBooks.Bamidbar] = new NullSafeList<string>
        {
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
        },
        [TorahBooks.Devarim] = new NullSafeList<string>
        {
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
        }
      };

  }

}
