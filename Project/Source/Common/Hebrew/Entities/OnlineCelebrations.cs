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
/// <created> 2021-09 </created>
/// <edited> 2021-09 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.Hebrew
{

  static class OnlineCelebration
  {

    static public readonly Dictionary<TorahCelebration, string> WikipediaEN = new()
    {
      { TorahCelebration.Pessah, "Passover" },
      { TorahCelebration.Chavouot, "Shavuot" },
      { TorahCelebration.YomTerouah, "Rosh_Hashanah" },
      { TorahCelebration.YomHaKipourim, "Yom_Kippur" },
      { TorahCelebration.Soukot, "Sukkot" }
    };

    static public readonly Dictionary<TorahCelebration, string> WikipediaFR = new()
    {
      { TorahCelebration.Pessah, "Pessa'h" },
      { TorahCelebration.Chavouot, "Chavouot" },
      { TorahCelebration.YomTerouah, "Roch_Hachana" },
      { TorahCelebration.YomHaKipourim, "Yom_Kippour" },
      { TorahCelebration.Soukot, "Souccot" }
    };

    static public readonly Dictionary<TorahCelebration, string> TorahOrg = new()
    {
      { TorahCelebration.Pessah, "passover" },
      { TorahCelebration.Chavouot, "shavuos" },
      { TorahCelebration.YomTerouah, "rosh-hashana" },
      { TorahCelebration.YomHaKipourim, "yom-kippur" },
      { TorahCelebration.Soukot, "sukkot" }
    };

    static public readonly Dictionary<TorahCelebration, string> TrueTorahJews = new()
    {
      { TorahCelebration.Pessah, "pesach" },
      { TorahCelebration.Chavouot, "Shavuos" },
      { TorahCelebration.YomTerouah, "rosh" },
      { TorahCelebration.YomHaKipourim, "yomkippur" },
      { TorahCelebration.Soukot, "succos" }
    };

    static public readonly Dictionary<TorahCelebration, string> MyJewishLearning = new()
    {
      { TorahCelebration.Pessah, "passover" },
      { TorahCelebration.Chavouot, "shavuot" },
      { TorahCelebration.YomTerouah, "rosh-hashanah" },
      { TorahCelebration.YomHaKipourim, "yom-kippur" },
      { TorahCelebration.Soukot, "sukkot" }
    };

    static public readonly Dictionary<TorahCelebration, string> TorahBox = new()
    {
      { TorahCelebration.Pessah, "pessah" },
      { TorahCelebration.Chavouot, "chavouot" },
      { TorahCelebration.YomTerouah, "roch-hachana" },
      { TorahCelebration.YomHaKipourim, "yom-kippour" },
      { TorahCelebration.Soukot, "souccot" }
    };

    static public readonly Dictionary<TorahCelebration, string> Loubavitch = new()
    {
      { TorahCelebration.Pessah, "pessa-h" },
      { TorahCelebration.Chavouot, "chavouot" },
      { TorahCelebration.YomTerouah, "roch-hachana" },
      { TorahCelebration.YomHaKipourim, "yom-kippour" },
      { TorahCelebration.Soukot, "souccot" }
    };

    static public readonly Dictionary<TorahCelebration, string> ChabadFR = new()
    {
      { TorahCelebration.Pessah, "495199/jewish/Pessah.htm" },
      { TorahCelebration.Chavouot, "619292/jewish/Chavouot.htm" },
      { TorahCelebration.YomTerouah, "565037/jewish/Roch-Hachana.htm" },
      { TorahCelebration.YomHaKipourim, "567990/jewish/Yom-Kippour.htm" },
      { TorahCelebration.Soukot, "3753669/jewish/Soukkot-et-Simhat-Torah.htm" }
    };

    static public readonly Dictionary<TorahCelebration, string> ChabadEN = new()
    {
      { TorahCelebration.Pessah, "holidays/passover/default_cdo/jewish/Passover.htm" },
      { TorahCelebration.Chavouot, "library/article_cdo/aid/111377/jewish/Shavuot.htm" },
      { TorahCelebration.YomTerouah, "library/article_cdo/aid/4644/jewish/Rosh-Hashanah.htm" },
      { TorahCelebration.YomHaKipourim, "library/article_cdo/aid/4687/jewish/Yom-Kippur.htm" },
      { TorahCelebration.Soukot, "library/article_cdo/aid/4126/jewish/Sukkot.htm" }
    };

    static public readonly Dictionary<TorahCelebration, string> YeshivaCo = new()
    {
      { TorahCelebration.Pessah, "103" },
      { TorahCelebration.Chavouot, "90" },
      { TorahCelebration.YomTerouah, "492" },
      { TorahCelebration.YomHaKipourim, "73" },
      { TorahCelebration.Soukot, "74" }
    };

    static public readonly Dictionary<TorahCelebration, string> TheYeshiva = new()
    {
      { TorahCelebration.Pessah, "c3/torah/holidays/pesach" },
      { TorahCelebration.Chavouot, "c76/torah/holidays/shavuot" },
      { TorahCelebration.YomTerouah, "c83/torah/holidays/rosh-hashanah" },
      { TorahCelebration.YomHaKipourim, "c84/torah/holidays/yom-kippur" },
      { TorahCelebration.Soukot, "c90/torah/holidays/sukkot" }
    };

    static public readonly Dictionary<TorahCelebration, string> AishFR = new()
    {
      { TorahCelebration.Pessah, "pessah" },
      { TorahCelebration.Chavouot, "shavuot" },
      { TorahCelebration.YomTerouah, "rosh_hashanah" },
      { TorahCelebration.YomHaKipourim, "yom_kippour" },
      { TorahCelebration.Soukot, "succot" }
    };

    static public readonly Dictionary<TorahCelebration, string> AishEN = new()
    {
      { TorahCelebration.Pessah, "pes" },
      { TorahCelebration.Chavouot, "sh" },
      { TorahCelebration.YomTerouah, "rh" },
      { TorahCelebration.YomHaKipourim, "yom-kippur" },
      { TorahCelebration.Soukot, "su" }
    };

    static public readonly Dictionary<TorahCelebration, string> AishIW = new()
    {
      { TorahCelebration.Pessah, "pes" },
      { TorahCelebration.Chavouot, "sh" },
      { TorahCelebration.YomTerouah, "hh/rh" },
      { TorahCelebration.YomHaKipourim, "hh/yk" },
      { TorahCelebration.Soukot, "su" }
    };

  }

}
