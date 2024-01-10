/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2024 Olivier Rogier.
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
/// <edited> 2024-01 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides online provider item.
/// </summary>
public class OnlineProviderItem
{

  static public readonly Image FolderImage = CreateImage("folder_vertical_open.png");

  static public readonly Dictionary<string, Image> LanguageImages = new()
  {
    ["(NONE)"] = CreateImage("web_layout.png"),
    ["(FR)"] = CreateImage("flag_france.png"),
    ["(EN)"] = CreateImage("flag_great_britain.png"),
    ["(IW)"] = CreateImage("flag_israel.png"),
    ["(EN/IW)"] = CreateImage("flag_en_iw.png"),
    ["(FR/IW)"] = CreateImage("flag_fr_iw.png"),
    ["(FR/EN)"] = CreateImage("flag_fr_en.png")
  };

  static private Image CreateImage(string fileName)
  {
    try
    {
      return Image.FromFile(Path.Combine(Globals.HelpFolderPath, fileName));
    }
    catch ( Exception ex )
    {
      DebugManager.Trace(LogTraceEvent.Exception, new ExceptionInfo(null, ex).FullText);
      return null;
    }
  }

  public string Language { get; }

  public string Name { get; }

  public string URL { get; }

  public Image Image { get; }

  public ToolStripItem CreateMenuItem(EventHandler action)
  {
    if ( Name == "-" ) return new ToolStripSeparator();
    return new ToolStripMenuItem(Name, Image, action)
    {
      ImageScaling = ToolStripItemImageScaling.None,
      Tag = URL
    };
  }

  public OnlineProviderItem(string name, string url = "", Image image = null)
  {
    string lang = string.Empty;
    if ( name[0] == '(' )
    {
      int pos = name.IndexOf(')');
      if ( pos >= 3 )
      {
        lang = name.Substring(0, pos + 1);
        if ( LanguageImages.TryGetValue(lang, out image) )
          name = name.Substring(pos + 1);
      }
    }
    Language = lang;
    Name = name.Trim();
    URL = url.Trim();
    Image = image;
  }

}
