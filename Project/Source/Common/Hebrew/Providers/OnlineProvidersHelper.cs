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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide online providers list helper to create menu items.
  /// </summary>
  static partial class OnlineProvidersHelper
  {

    /// <summary>
    /// Fatcow table_edit.ico for configure menu item.
    /// </summary>
    private const string ImageEditString
      = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8"
      + "YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAI5SURBVDhPnZNfSFNhGMbPldu6qKCboogguii6CLzoKgqK"
      + "wisvuq27iCKIYhHo1mZqKhmZmRsKShJRhhShO/tX28ByEQVBzm2Ym5IWUZRN+kd/fr3fd+aaiV30wMP7"
      + "nu8873O+9zvvZ6xuDH1Y7jFxuE1sLhO7ZqAYF+dKp/SqzlBQD/8DVacNHO6AtTK8Bx5Wwcg+PIGXkNyr"
      + "uSAfmoIHu7Rc1VkGsi0F990JEUxSb07SFMzRYOY1y/NGc4K6wXGtt80b2F1DeiH9CbKfIfcNWgNp8hIV"
      + "y/PzZoYX37UcY76FeYP8F5j6CjMiaAuO8UqiYin/AZciWWZEm/aEyDdFFxpcGBylLZDicihNZyRDh0RF"
      + "nYczXImM409M4fLUMnknz6POxzxz36Zk8Fa+8k6+Miu5L5Lmo0RFXzSjY0FY465j+vUbGlpbCNaEeXLU"
      + "/8eg8BPmfoF0Qnc0jXSj2RXLIcdD8sRaZrMD1DW3E43FOO1yqhYqSwZd4VG6Iyl6743RF8/QG8vQk8jR"
      + "k3zPiHOj/OKd0L+B1IAH58lTVDQmimdQaxnIBjQV+uLZYiZjoYqTu+HWFvCvwHdgvV5f5g1bBo7iDspx"
      + "LW796+Hj62RwdljFXavoOLhJryuUBmmpUZ7r3w7TLfDcK4eykquHNhffWCiN8pqzwYJ6UDuxSTsVcmmM"
      + "M3Fu1u8neEOKUxe5fmQrxrmn2L33S5dJ1WkDwTZh5d9sPlZN0+EqxturrdNeTFX3T5SLl4Bh/AZO3qcQ"
      + "BCcQLQAAAABJRU5ErkJggg==";

    /// <summary>
    /// Indicate image of the configure menu item.
    /// </summary>
    static private Image ImageConfigure;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static OnlineProvidersHelper()
    {
      using ( var stream = new MemoryStream(Convert.FromBase64String(ImageEditString)) )
        ImageConfigure = Image.FromStream(stream);
    }

    /// <summary>
    /// Create configure menu item.
    /// </summary>
    static ToolStripMenuItem CreateConfigureMenuItem(EventHandler click)
    {
      var item = new ToolStripMenuItem(HebrewTranslations.ConfigureProviders.GetLang(), ImageConfigure);
      item.ImageScaling = ToolStripItemImageScaling.None;
      item.Click += click;
      return item;
    }

    /// <summary>
    /// Crate a list of menu items.
    /// </summary>
    static private void SetItems(ToolStripItemCollection list,
                                 OnlineProviders items,
                                 EventHandler action,
                                 Action reconstruct)
    {
      list.Clear();
      string nameItems = NameOfFromStack(items, 3).Replace("Globals.", string.Empty);
      if ( items.Configurable )
      {
        list.Insert(0, CreateConfigureMenuItem((sender, e) =>
        {
          int countTotal = items.Items.Count;
          if ( !DataFileEditorForm.Run(nameItems, items) ) return;
          for ( int count = 0; count < countTotal; count++ )
            list.RemoveAt(0);
          list.RemoveAt(0);
          list.RemoveAt(0);
          reconstruct();
        }));
        list.Insert(0, new ToolStripSeparator());
      }
      for ( int index = items.Items.Count - 1; index >= 0; index-- )
        list.Insert(0, items.Items[index].CreateMenuItem(action));
    }

    /// <summary>
    /// Create submenu items for providers menu.
    /// </summary>
    static public void InitializeFromProviders(this ContextMenuStrip menuRoot,
                                               OnlineProviders items,
                                               EventHandler action)
    {
      SetItems(menuRoot.Items, items, action, () => InitializeFromProviders(menuRoot, items, action));
    }

    /// <summary>
    /// Create submenu items for providers menu.
    /// </summary>
    static public void InitializeFromProviders(this ToolStripMenuItem menu,
                                               OnlineProviders items,
                                               EventHandler action)
    {
      SetItems(menu.DropDownItems, items, action, () => InitializeFromProviders(menu, items, action));
    }

    /// <summary>
    /// Create submenu items for web links menu.
    /// </summary>
    static public void InitializeFromWebLinks(this ToolStripDropDownButton menuRoot, Action reconstruct)
    {
      menuRoot.DropDownItems.Clear();
      foreach ( var items in HebrewGlobals.WebLinksProviders )
        if ( items.Items.Count > 0 )
        {
          // Folder
          string title = items.Title.GetLang();
          ToolStripDropDownItem menu;
          if ( title != string.Empty )
          {
            if ( items.SeparatorBeforeFolder )
              menuRoot.DropDownItems.Add(new ToolStripSeparator());
            menu = new ToolStripMenuItem(title);
            menuRoot.DropDownItems.Add(menu);
            menu.ImageScaling = ToolStripItemImageScaling.None;
            menu.Image = OnlineProviderItem.FolderImage;
            menu.MouseUp += (sender, e) =>
            {
              if ( e.Button != MouseButtons.Right ) return;
              ( (ToolStripDropDownButton)menu.OwnerItem ).HideDropDown();
              if ( !DisplayManager.QueryYesNo(SysTranslations.AskToOpenAllLinks.GetLang(menu.Text)) ) return;
              foreach ( ToolStripItem item in ( (ToolStripMenuItem)sender ).DropDownItems )
                if ( item.Tag != null )
                {
                  SystemManager.OpenWebLink((string)item.Tag);
                  Thread.Sleep(1500);
                }
            };
          }
          else
            menu = menuRoot;
          // Items
          foreach ( var item in items.Items )
            menu.DropDownItems.Add(item.CreateMenuItem((sender, e) =>
            {
              string url = (string)( (ToolStripItem)sender ).Tag;
              SystemManager.OpenWebLink(url);
            }));
        }
      if ( menuRoot.DropDownItems.Count > 0 && HebrewGlobals.WebLinksProviders[0].Configurable )
      {
        menuRoot.DropDownItems.Add(new ToolStripSeparator());
        menuRoot.DropDownItems.Add(CreateConfigureMenuItem((sender, e) =>
        {
          if ( !DataFileEditorForm.Run(nameof(HebrewGlobals.WebLinksProviders), HebrewGlobals.WebLinksProviders) ) return;
          reconstruct();
        }));
      }
    }

    /// <summary>
    /// https://stackoverflow.com/questions/72121/finding-the-variable-name-passed-to-a-function/21219225#21219225
    /// </summary>
    static private Dictionary<string, string> AlreadyAcessedVarNames 
      = new Dictionary<string, string>();

    static private string NameOfFromStack(this object instance, int level = 1)
    {
      try
      {
        var frame = new StackTrace(true).GetFrame(level);
        string filePath = frame.GetFileName();
        int lineNumber = frame.GetFileLineNumber();
        string id = filePath + lineNumber;
        if ( AlreadyAcessedVarNames.ContainsKey(id) )
          return AlreadyAcessedVarNames[id];
        using ( var file = new StreamReader(filePath) )
        {
          for ( int i = 0; i < lineNumber - 1; i++ )
            file.ReadLine();
          string line = file.ReadLine();
          string name = line.Split('(', ')')[1].TrimEnd(' ', ',');
          AlreadyAcessedVarNames.Add(id, name);
          return name;
        }
      }
      catch
      {
        return SysTranslations.ErrorSlot.GetLang();
      }
    }

  }

}
