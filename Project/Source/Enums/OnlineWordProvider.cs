/// <license>
/// This file is part of Ordisoftware Hebrew Words.
/// Copyright 2012-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-03 </created>
/// <edited> 2020-03 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.HebrewWords
{

  public class OnlineWordProvider
  {
    public string Name { get; set; }
    public string URL { get; set; }
    public ToolStripMenuItem CreateMenuItem(EventHandler action, Image image = null)
    {
      var result = new ToolStripMenuItem(Name, image);
      result.Tag = URL;
      result.Click += action;
      return result;
    }
  }

  static public class OnlineWordProviders
  {

    static public List<OnlineWordProvider> Items
    {
      get;
      private set;
    }

    static OnlineWordProviders()
    {
      Items = new List<OnlineWordProvider>();
      OnlineWordProvider item;

      item = new OnlineWordProvider();
      item.Name = "Pealim Hebrew Verb Tables EN";
      item.URL = "https://www.pealim.com/search/?q=%WORD%";
      Items.Add(item);

      item = new OnlineWordProvider();
      item.Name = "Sefaria Klein Dictionary EN";
      item.URL = "https://www.sefaria.org/Klein_Dictionary%2C_%WORD%_%E1%B4%B5?lang=bi";
      Items.Add(item);

      item = new OnlineWordProvider();
      item.Name = "Dict.com FR";
      item.URL = "https://www.dict.com/hebreu-francais/%WORD%";
      Items.Add(item);

      Items.Add(new OnlineWordProvider() { Name = "-" });

      item = new OnlineWordProvider();
      item.Name = "Wiktionary EN";
      item.URL = "https://en.wiktionary.org/wiki/%WORD%";
      Items.Add(item);
      item = new OnlineWordProvider();
      item.Name = "Wiktionary FR";
      item.URL = "https://fr.wiktionary.org/w/index.php?search=%WORD%";
      Items.Add(item);

      Items.Add(new OnlineWordProvider() { Name = "-" });

      item = new OnlineWordProvider();
      item.Name = "Google Translate EN";
      item.URL = "https://translate.google.com/?op=translate&sl=iw&tl=en&text=%WORD%";
      Items.Add(item);
      item = new OnlineWordProvider();
      item.Name = "Google Translate FR";
      item.URL = "https://translate.google.com/?op=translate&sl=iw&tl=fr&text=%WORD%";
      Items.Add(item);

      Items.Add(new OnlineWordProvider() { Name = "-" });

      item = new OnlineWordProvider();
      item.Name = "Bing Translate EN";
      item.URL = "https://www.bing.com/translator/?from=he&to=en&text=%WORD%";
      Items.Add(item);
      item = new OnlineWordProvider();
      item.Name = "Bing Translate FR";
      item.URL = "https://www.bing.com/translator/?from=he&to=fr&text=%WORD%";
      Items.Add(item);

      Items.Add(new OnlineWordProvider() { Name = "-" });

      item = new OnlineWordProvider();
      item.Name = "Reverso Dictionary EN";
      item.URL = "https://dictionary.reverso.net/hebrew-english/%WORD%";
      Items.Add(item);
      item = new OnlineWordProvider();
      item.Name = "Reverso Dictionary FR";
      item.URL = "https://dictionnaire.reverso.net/hebreu-francais/%WORD%";
      Items.Add(item);

      Items.Add(new OnlineWordProvider() { Name = "-" });

      item = new OnlineWordProvider();
      item.Name = "Reverso Context EN";
      item.URL = "https://context.reverso.net/translation/hebrew-english/%WORD%";
      Items.Add(item);
      item = new OnlineWordProvider();
      item.Name = "Reverso Context FR";
      item.URL = "https://context.reverso.net/translation/hebrew-french/%WORD%";
      Items.Add(item);

      Items.Add(new OnlineWordProvider() { Name = "-" });

      item = new OnlineWordProvider();
      item.Name = "Glosbe Dictionary EN";
      item.URL = "https://en.glosbe.com/he/en/%WORD%";
      Items.Add(item);
      item = new OnlineWordProvider();
      item.Name = "Glosbe Dictionary FR";
      item.URL = "https://fr.glosbe.com/he/fr/%WORD%";
      Items.Add(item);

      Items.Add(new OnlineWordProvider() { Name = "-" });

      item = new OnlineWordProvider();
      item.Name = "Google Search";
      item.URL = "https://www.google.com/search?q=hebrew+strong+%WORD%";
      Items.Add(item);

      item = new OnlineWordProvider();
      item.Name = "Bing Search";
      item.URL = "http://www.bing.com/search?q=hebrew+strong+%WORD%";
      Items.Add(item);

    }

  }

}
