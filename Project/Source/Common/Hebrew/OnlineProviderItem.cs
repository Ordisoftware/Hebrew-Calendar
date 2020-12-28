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
/// <created> 2020-03 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide online provider item.
  /// </summary>
  public class OnlineProviderItem
  {

    static public readonly Dictionary<string, Image> LanguageImages;

    static public readonly Image FolderImage;

    static OnlineProviderItem()
    {
      Image createImage(string filePath)
      {
        try
        {
          return Image.FromFile(System.IO.Path.Combine(ProvidersCollection.GuidesFolderPath, filePath));
        }
        catch ( Exception ex )
        {
          DisplayManager.ShowWarning(SysTranslations.LoadFileError.GetLang(filePath, ex.Message));
          return null;
        }
      }
      FolderImage = createImage("folder_vertical_open.png");
      LanguageImages = new Dictionary<string, Image>()
      {
        ["(NONE)"] = createImage("web_layout.png"),
        ["(FR)"] = createImage("flag_france.png"),
        ["(EN)"] = createImage("flag_great_britain.png"),
        ["(IW)"] = createImage("flag_israel.png"),
        ["(FR/IW)"] = createImage("flag_fr_iw.png"),
        ["(FR/EN)"] = createImage("flag_fr_en.png")
      };
    }

    public string Name { get; private set; }

    public string URL { get; private set; }

    public Image Image { get; private set; }

    public ToolStripItem CreateMenuItem(EventHandler action)
    {
      if ( Name == "-" ) return new ToolStripSeparator();
      var result = new ToolStripMenuItem(Name, Image);
      result.ImageScaling = ToolStripItemImageScaling.None;
      result.Tag = URL;
      result.Click += action;
      return result;
    }

    public OnlineProviderItem(string name, string url = "", Image image = null)
    {
      if ( name[0] == '(' )
      {
        int pos = name.IndexOf(')');
        if ( pos >= 3 )
        {
          string lang = name.Substring(0, pos + 1);
          if ( LanguageImages.ContainsKey(lang) )
          {
            name = name.Substring(pos + 1);
            image = LanguageImages[lang];
          }
        }
      }
      Name = name.Trim();
      URL = url.Trim();
      Image = image;
    }

  }

}
