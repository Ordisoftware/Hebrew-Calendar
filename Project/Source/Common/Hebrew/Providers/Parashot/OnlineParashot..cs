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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "N/A")]
  static public string GetUrl(string pattern, Parashah parashah)
  {
    var dispatch = new Dictionary<string, string>()
    {
      { "%AISH-EN%", AishEN[parashah.Book][parashah.Number - 1] },
      { "%AISH-FR%", AishFR[parashah.Book][parashah.Number - 1] },
      { "%AISH-IW%", AishIW[parashah.Book][parashah.Number - 1] },
      { "%CHABAD-EN%", ChabadEN[parashah.Book][parashah.Number - 1] },
      { "%CHABAD-FR%", ChabadFR[parashah.Book][parashah.Number - 1] },
      { "%MYJEWISHLEARNING%", MyJewishLearning[parashah.Book][parashah.Number - 1] },
      { "%THETORAHCOM%", TheTorahCom[parashah.Book][parashah.Number - 1] },
      { "%THEYESHIVA%", TheYeshivaNet[parashah.Book][parashah.Number - 1] },
      { "%TORAHBOX%", TorahBox[parashah.Book][parashah.Number - 1] },
      { "%TORAHJEWS%", TorahJews[parashah.Book][parashah.Number - 1] },
      { "%TORAHORG%", TorahOrg[parashah.Book][parashah.Number - 1] },
      { "%WIKIPEDIA-EN%", WikipediaEN[parashah.Book][parashah.Number - 1] },
      { "%WIKIPEDIA-FR%", WikipediaFR[parashah.Book][parashah.Number - 1] },
      { "%YESHIVACO%", YeshivaCo[parashah.Book][parashah.Number - 1] }
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

}
