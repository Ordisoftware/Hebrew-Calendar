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
/// <created> 2021-09 </created>
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

[SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
static public class OnlineCelebration
{

  [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "N/A")]
  static public string GetUrl(string pattern, TorahCelebration celebration)
  {
    var dispatch = new Dictionary<string, string>()
    {
      { "%AISH-EN%", AishEN[celebration]},
      { "%AISH-FR%", AishFR[celebration]},
      { "%AISH-IW%", AishIW[celebration]},
      { "%CHABAD-EN%", ChabadEN[celebration]},
      { "%CHABAD-FR%", ChabadFR[celebration]},
      { "%CHIOURIM%", Chiourim[celebration]},
      { "%LOUBAVITCH%", Loubavitch[celebration]},
      { "%MYJEWISHLEARNING%", MyJewishLearning[celebration]},
      { "%RAVABDELHAK%", RavAbdelhak[celebration]},
      { "%REFORMJUDAISM%", ReformJudaism[celebration]},
      { "%THETORAHCOM%", TheTorahCom[celebration]},
      { "%THEYESHIVA%", TheYeshiva[celebration]},
      { "%TORAHBOX%", TorahBox[celebration]},
      { "%TORAHJEWS%", TrueTorahJews[celebration]},
      { "%TORAHORG%", TorahOrg[celebration]},
      { "%WIKIPEDIA-EN%", WikipediaEN[celebration]},
      { "%WIKIPEDIA-FR%", WikipediaFR[celebration]},
      { "%YESHIVACO%", YeshivaCo[celebration]}
    };
    foreach ( var item in dispatch )
      if ( pattern.Contains(item.Key) )
      {
        if ( item.Value.Length != 0 )
          return pattern.Replace(item.Key, item.Value);
        var uri = new Uri(pattern);
        return new UriBuilder(uri.Scheme, uri.Host).ToString();
      }
    return pattern;
  }

  static public readonly Dictionary<TorahCelebration, string> AishEN = new()
  {
    { TorahCelebration.Shabat, "shabbat" },
    { TorahCelebration.Pessah, "passover" },
    { TorahCelebration.Chavouot, "shavuot" },
    { TorahCelebration.YomTerouah, "rosh-hashanah" },
    { TorahCelebration.YomHaKipourim, "yom-kippur" },
    { TorahCelebration.Soukot, "sukkot" }
  };

  static public readonly Dictionary<TorahCelebration, string> AishFR = new()
  {
    { TorahCelebration.Shabat, "shabbat" },
    { TorahCelebration.Pessah, "h/pessah" },
    { TorahCelebration.Chavouot, "h/chavuout" },
    { TorahCelebration.YomTerouah, "h/rosh-hashanah" },
    { TorahCelebration.YomHaKipourim, "h/yom-kippour" },
    { TorahCelebration.Soukot, "h/succot" }
  };

  static public readonly Dictionary<TorahCelebration, string> AishIW = new()
  {
    { TorahCelebration.Shabat, "" },
    { TorahCelebration.Pessah, "h/pes" },
    { TorahCelebration.Chavouot, "h/sh" },
    { TorahCelebration.YomTerouah, "h/hh/rh" },
    { TorahCelebration.YomHaKipourim, "h/hh/yk" },
    { TorahCelebration.Soukot, "h/su" }
  };

  static public readonly Dictionary<TorahCelebration, string> ChabadEN = new()
  {
    { TorahCelebration.Shabat, "library/article_cdo/aid/253215/jewish/Shabbat.htm" },
    { TorahCelebration.Pessah, "holidays/passover/default_cdo/jewish/Passover.htm" },
    { TorahCelebration.Chavouot, "library/article_cdo/aid/111377/jewish/Shavuot.htm" },
    { TorahCelebration.YomTerouah, "library/article_cdo/aid/4644/jewish/Rosh-Hashanah.htm" },
    { TorahCelebration.YomHaKipourim, "library/article_cdo/aid/4687/jewish/Yom-Kippur.htm" },
    { TorahCelebration.Soukot, "library/article_cdo/aid/4126/jewish/Sukkot.htm" }
  };

  static public readonly Dictionary<TorahCelebration, string> ChabadFR = new()
  {
    { TorahCelebration.Shabat, "487482/jewish/Le-Chabbat.htm" },
    { TorahCelebration.Pessah, "495199/jewish/Pessah.htm" },
    { TorahCelebration.Chavouot, "619292/jewish/Chavouot.htm" },
    { TorahCelebration.YomTerouah, "565037/jewish/Roch-Hachana.htm" },
    { TorahCelebration.YomHaKipourim, "567990/jewish/Yom-Kippour.htm" },
    { TorahCelebration.Soukot, "3753669/jewish/Soukkot-et-Simhat-Torah.htm" }
  };

  static public readonly Dictionary<TorahCelebration, string> Chiourim = new()
  {
    { TorahCelebration.Shabat, "" },
    { TorahCelebration.Pessah, "pessah" },
    { TorahCelebration.Chavouot, "chavouot" },
    { TorahCelebration.YomTerouah, "eloul" },
    { TorahCelebration.YomHaKipourim, "eloul" },
    { TorahCelebration.Soukot, "tichri" }
  };

  static public readonly Dictionary<TorahCelebration, string> Loubavitch = new()
  {
    { TorahCelebration.Shabat, "chabbat" },
    { TorahCelebration.Pessah, "fetes-juives/pessa-h" },
    { TorahCelebration.Chavouot, "fetes-juives/chavouot" },
    { TorahCelebration.YomTerouah, "fetes-juives/roch-hachana" },
    { TorahCelebration.YomHaKipourim, "fetes-juives/yom-kippour" },
    { TorahCelebration.Soukot, "fetes-juives/souccot" }
  };

  static public readonly Dictionary<TorahCelebration, string> MyJewishLearning = new()
  {
    { TorahCelebration.Shabat, "shabbat" },
    { TorahCelebration.Pessah, "passover" },
    { TorahCelebration.Chavouot, "shavuot" },
    { TorahCelebration.YomTerouah, "rosh-hashanah" },
    { TorahCelebration.YomHaKipourim, "yom-kippur" },
    { TorahCelebration.Soukot, "sukkot" }
  };

  static public readonly Dictionary<TorahCelebration, string> RavAbdelhak = new()
  {
    { TorahCelebration.Shabat, "daf-hayomi/daf-hayomi-chabbat/" },
    { TorahCelebration.Pessah, "fetes-juives/pessah" },
    { TorahCelebration.Chavouot, "fetes-juives/chavouoth" },
    { TorahCelebration.YomTerouah, "fetes-juives/roch-hachana" },
    { TorahCelebration.YomHaKipourim, "fetes-juives/kippour" },
    { TorahCelebration.Soukot, "fetes-juives/souccoth" }
  };

  static public readonly Dictionary<TorahCelebration, string> ReformJudaism = new()
  {
    { TorahCelebration.Shabat, "shabbat" },
    { TorahCelebration.Pessah, "passover" },
    { TorahCelebration.Chavouot, "shavuot" },
    { TorahCelebration.YomTerouah, "rosh-hashanah" },
    { TorahCelebration.YomHaKipourim, "yom-kippur" },
    { TorahCelebration.Soukot, "sukkot" }
  };

  static public readonly Dictionary<TorahCelebration, string> TheTorahCom = new()
  {
    { TorahCelebration.Shabat, "shabbat" },
    { TorahCelebration.Pessah, "passover" },
    { TorahCelebration.Chavouot, "shavuot" },
    { TorahCelebration.YomTerouah, "rosh-hashanah" },
    { TorahCelebration.YomHaKipourim, "yom-kippur" },
    { TorahCelebration.Soukot, "sukkot" }
  };

  static public readonly Dictionary<TorahCelebration, string> TheYeshiva = new()
  {
    { TorahCelebration.Shabat, "c776/series/the-laws-of-shabbos" },
    { TorahCelebration.Pessah, "c3/torah/holidays/pesach" },
    { TorahCelebration.Chavouot, "c76/torah/holidays/shavuot" },
    { TorahCelebration.YomTerouah, "c83/torah/holidays/rosh-hashanah" },
    { TorahCelebration.YomHaKipourim, "c84/torah/holidays/yom-kippur" },
    { TorahCelebration.Soukot, "c90/torah/holidays/sukkot" }
  };

  static public readonly Dictionary<TorahCelebration, string> TorahBox = new()
  {
    { TorahCelebration.Shabat, "mitsvot/chabbath" },
    { TorahCelebration.Pessah, "fetes/pessah" },
    { TorahCelebration.Chavouot, "fetes/chavouot" },
    { TorahCelebration.YomTerouah, "fetes/roch-hachana" },
    { TorahCelebration.YomHaKipourim, "fetes/yom-kippour" },
    { TorahCelebration.Soukot, "fetes/souccot" }
  };

  static public readonly Dictionary<TorahCelebration, string> TorahOrg = new()
  {
    { TorahCelebration.Shabat, "series/shabbos" },
    { TorahCelebration.Pessah, "passover" },
    { TorahCelebration.Chavouot, "shavuos" },
    { TorahCelebration.YomTerouah, "rosh-hashana" },
    { TorahCelebration.YomHaKipourim, "yom-kippur" },
    { TorahCelebration.Soukot, "sukkot" }
  };

  static public readonly Dictionary<TorahCelebration, string> TrueTorahJews = new()
  {
    { TorahCelebration.Shabat, "" },
    { TorahCelebration.Pessah, "pesach" },
    { TorahCelebration.Chavouot, "Shavuos" },
    { TorahCelebration.YomTerouah, "rosh" },
    { TorahCelebration.YomHaKipourim, "yomkippur" },
    { TorahCelebration.Soukot, "succos" }
  };

  static public readonly Dictionary<TorahCelebration, string> WikipediaEN = new()
  {
    { TorahCelebration.Shabat, "Shabbat" },
    { TorahCelebration.Pessah, "Passover" },
    { TorahCelebration.Chavouot, "Shavuot" },
    { TorahCelebration.YomTerouah, "Rosh_Hashanah" },
    { TorahCelebration.YomHaKipourim, "Yom_Kippur" },
    { TorahCelebration.Soukot, "Sukkot" }
  };

  static public readonly Dictionary<TorahCelebration, string> WikipediaFR = new()
  {
    { TorahCelebration.Shabat, "Shabbat" },
    { TorahCelebration.Pessah, "Pessa'h" },
    { TorahCelebration.Chavouot, "Chavouot" },
    { TorahCelebration.YomTerouah, "Roch_Hachana" },
    { TorahCelebration.YomHaKipourim, "Yom_Kippour" },
    { TorahCelebration.Soukot, "Souccot" }
  };

  static public readonly Dictionary<TorahCelebration, string> YeshivaCo = new()
  {
    { TorahCelebration.Shabat, "274" },
    { TorahCelebration.Pessah, "103" },
    { TorahCelebration.Chavouot, "90" },
    { TorahCelebration.YomTerouah, "492" },
    { TorahCelebration.YomHaKipourim, "73" },
    { TorahCelebration.Soukot, "74" }
  };
}
