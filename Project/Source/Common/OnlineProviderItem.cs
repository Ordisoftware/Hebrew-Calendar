/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
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
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide online provider item.
  /// </summary>
  public class OnlineProviderItem
  {

    static private readonly Dictionary<string, Image> LanguageImages;

    static OnlineProviderItem()
    {
      Func<string, Image> createImage = filename =>
      {
        try
        {
          return Image.FromFile(filename);
        }
        catch
        {
          DisplayManager.ShowError($"Error loading: {Environment.NewLine}{filename}");
          return null;
        }
      };
      LanguageImages = new Dictionary<string, Image>()
      {
        { "(NONE)", createImage(Globals.HelpFolderPath + "flag_none.png") },
        { "(FR)", createImage(Globals.HelpFolderPath + "flag_france.png") },
        { "(EN)", createImage(Globals.HelpFolderPath + "flag_great_britain.png") },
        { "(IW)", createImage(Globals.HelpFolderPath + "flag_israel.png") },
        { "(FR/IW)", createImage(Globals.HelpFolderPath + "flag_fr_iw.png") },
        { "(FR/EN)", createImage(Globals.HelpFolderPath + "flag_fr_en.png") }
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
      foreach ( var flag in LanguageImages )
        if ( name.StartsWith(flag.Key) )
        {
          name = name.Replace(flag.Key, "").Trim();
          image = flag.Value;
          break;
        }
      Name = name;
      URL = url;
      Image = image;
    }

  }

}
