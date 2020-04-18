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
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide online providers list.
  /// </summary>
  public partial class OnlineProviders
  {

    /// <summary>
    /// Create submenu items for providers menu.
    /// </summary>
    static public void CreateProvidersMenuItems(OnlineProviders items, ContextMenuStrip menu, EventHandler action)
    {
      int index = 0;
      foreach ( var item in items.Items )
        menu.Items.Insert(index++, item.CreateMenuItem(action));
    }

    /// <summary>
    /// Create submenu items for providers menu.
    /// </summary>
    static public void CreateProvidersMenuItems(OnlineProviders items, ToolStripMenuItem menu, EventHandler action)
    {
      int index = 0;
      foreach ( var item in items.Items )
        menu.DropDownItems.Insert(index++, item.CreateMenuItem(action));
    }

    /// <summary>
    /// Create submenu items for web links menu.
    /// </summary>
    static public void CreateWebLinksMenuItems(ToolStripDropDownButton menuRoot, Image imageFolder)
    {
      Globals.LoadWebLinks();
      menuRoot.DropDownItems.Clear();
      foreach ( var items in Globals.OnlineLinksProviders )
        if ( items.Items.Count > 0 )
        {
          string title = items.Title.GetLang();
          ToolStripDropDownItem menu;
          if ( title != "" )
          {
            if ( items.SeparatorBeforeFolder )
              menuRoot.DropDownItems.Add(new ToolStripSeparator());
            menu = new ToolStripMenuItem(title);
            menuRoot.DropDownItems.Add(menu);
            menu.ImageScaling = ToolStripItemImageScaling.None;
            menu.Image = imageFolder;
            menu.MouseUp += (sender, e) =>
            {
              if ( e.Button != MouseButtons.Right ) return;
              ( (ToolStripDropDownButton)menu.OwnerItem ).HideDropDown();
              if ( !DisplayManager.QueryYesNo(Globals.AskToOpenAllLinks.GetLang(menu.Text)) ) return;
              foreach ( ToolStripItem item in ( (ToolStripMenuItem)sender ).DropDownItems )
                if ( item.Tag != null )
                {
                  SystemManager.OpenWebLink((string)item.Tag);
                  Thread.Sleep(1000);
                }
            };
          }
          else
            menu = menuRoot;
          foreach ( var item in items.Items )
            menu.DropDownItems.Add(item.CreateMenuItem((sender, e) =>
            {
              string url = (string)( (ToolStripItem)sender ).Tag;
              SystemManager.OpenWebLink(url);
            }));
        }
    }

  }

}