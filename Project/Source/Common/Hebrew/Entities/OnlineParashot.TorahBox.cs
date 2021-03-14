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
          "https://www.torah-box.com/paracha/berechit-genese/berechit/",
          "https://www.torah-box.com/paracha/berechit-genese/noah/",
          "https://www.torah-box.com/paracha/berechit-genese/lekh-lekha/",
          "https://www.torah-box.com/paracha/berechit-genese/vayera/",
          "https://www.torah-box.com/paracha/berechit-genese/haye-sarah/",
          "https://www.torah-box.com/paracha/berechit-genese/toledot/",
          "https://www.torah-box.com/paracha/berechit-genese/vayetse/",
          "https://www.torah-box.com/paracha/berechit-genese/vayichlah/",
          "https://www.torah-box.com/paracha/berechit-genese/vayechev/",
          "https://www.torah-box.com/paracha/berechit-genese/mikets/",
          "https://www.torah-box.com/paracha/berechit-genese/vayigach/",
          "https://www.torah-box.com/paracha/berechit-genese/vayehi/"
        },
        [TorahBooks.Shemot] = new NullSafeList<string>
        {
          "https://www.torah-box.com/paracha/chemot-exode/chemot/",
          "https://www.torah-box.com/paracha/chemot-exode/vaera/",
          "https://www.torah-box.com/paracha/chemot-exode/bo/",
          "https://www.torah-box.com/paracha/chemot-exode/bechalah/",
          "https://www.torah-box.com/paracha/chemot-exode/yitro/",
          "https://www.torah-box.com/paracha/chemot-exode/michpatim/",
          "https://www.torah-box.com/paracha/chemot-exode/terouma/",
          "https://www.torah-box.com/paracha/chemot-exode/tetsave/",
          "https://www.torah-box.com/paracha/chemot-exode/ki-tissa/",
          "https://www.torah-box.com/paracha/chemot-exode/vayakhel/",
          "https://www.torah-box.com/paracha/chemot-exode/pekoude/"
        },
        [TorahBooks.Vayiqra] = new NullSafeList<string>
        {
          "https://www.torah-box.com/paracha/vayikra-levitique/vayikra/",
          "https://www.torah-box.com/paracha/vayikra-levitique/tsav/",
          "https://www.torah-box.com/paracha/vayikra-levitique/chemini/",
          "https://www.torah-box.com/paracha/vayikra-levitique/tazria/",
          "https://www.torah-box.com/paracha/vayikra-levitique/metsora/",
          "https://www.torah-box.com/paracha/vayikra-levitique/ahare-mot/",
          "https://www.torah-box.com/paracha/vayikra-levitique/kedochim/",
          "https://www.torah-box.com/paracha/vayikra-levitique/emor/",
          "https://www.torah-box.com/paracha/vayikra-levitique/behar/",
          "https://www.torah-box.com/paracha/vayikra-levitique/behoukotai/"
        },
        [TorahBooks.Bamidbar] = new NullSafeList<string>
        {
          "https://www.torah-box.com/paracha/bamidbar-nombres/bamidbar/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/nasso/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/behaalotekha/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/chelah-lekha/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/korah/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/houkat/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/balak/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/pinhas/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/matot/",
          "https://www.torah-box.com/paracha/bamidbar-nombres/masse/"
        },
        [TorahBooks.Devarim] = new NullSafeList<string>
        {
          "https://www.torah-box.com/paracha/devarim-deuteronome/devarim/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/vaethanane/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/ekev/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/ree/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/choftim/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/ki-tetse/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/ki-tavo/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/nitsavim/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/vayelekh/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/haazinou/",
          "https://www.torah-box.com/paracha/devarim-deuteronome/vezot-haberakha/"
        }
      };

  }

}
