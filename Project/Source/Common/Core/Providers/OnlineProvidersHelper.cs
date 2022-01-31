/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2021-11 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides online providers list helper to create menu items.
/// </summary>
static class OnlineProvidersHelper
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
  /// Indicates image of the configure menu item.
  /// </summary>
  static public Image ImageConfigure { get; }

  /// <summary>
  /// Static constructor.
  /// </summary>
  static OnlineProvidersHelper()
  {
    using var stream = new MemoryStream(Convert.FromBase64String(ImageEditString));
    ImageConfigure = Image.FromStream(stream);
  }

  /// <summary>
  /// Creates configure menu item.
  /// </summary>
  static ToolStripMenuItem CreateConfigureMenuItem(EventHandler click)
  {
    return new ToolStripMenuItem(SysTranslations.ConfigureProviders.GetLang(), ImageConfigure, click)
    {
      ImageScaling = ToolStripItemImageScaling.None
    };
  }

  /// <summary>
  /// Creates a list of menu items.
  /// </summary>
  static private void SetItems(ToolStripItemCollection menuItems,
                               OnlineProviders providers,
                               EventHandler action,
                               Action reconstruct)
  {
    if ( providers == null || providers.Items.Count == 0 ) return;
    menuItems.Clear();
    string nameItems = StackMethods.NameOfFromStack(3).Replace("Globals.", string.Empty);
    foreach ( var item in providers.Items )
      menuItems.Add(item.CreateMenuItem(action));
    if ( providers.Configurable )
    {
      menuItems.Add(new ToolStripSeparator());
      menuItems.Add(CreateConfigureMenuItem((sender, e) =>
      {
        if ( DataFileEditorForm.Run(nameItems, providers) )
          reconstruct();
      }));
    }
  }

  /// <summary>
  /// Creates submenu items for providers menu.
  /// </summary>
  static public void InitializeFromProviders(this ContextMenuStrip contextMenu,
                                             OnlineProviders providers,
                                             EventHandler action)
  {
    SetItems(contextMenu.Items, providers, action, () => InitializeFromProviders(contextMenu, providers, action));
  }

  /// <summary>
  /// Creates submenu items for providers menu.
  /// </summary>
  static public void InitializeFromProviders(this ToolStripMenuItem menuItem,
                                             OnlineProviders providers,
                                             EventHandler action)
  {
    if ( providers == null ) return;
    SetItems(menuItem.DropDownItems, providers, action, () => InitializeFromProviders(menuItem, providers, action));
    menuItem.MouseUp += Menu_MouseUp;
  }

  /// <summary>
  /// Creates submenu items for web links menu.
  /// </summary>
  static public void InitializeFromWebLinks(this ToolStripDropDownButton menuRoot, Action reconstruct)
  {
    var providers = Globals.WebLinksProviders;
    if ( providers == null ) return;
    menuRoot.DropDownItems.Clear();
    foreach ( var items in providers )
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
          menu.MouseUp += Menu_MouseUp;
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
    if ( menuRoot.DropDownItems.Count > 0 && Globals.WebLinksProviders[0].Configurable )
    {
      menuRoot.DropDownItems.Add(new ToolStripSeparator());
      menuRoot.DropDownItems.Add(CreateConfigureMenuItem((sender, e) =>
      {
        if ( DataFileEditorForm.Run(nameof(Globals.WebLinksProviders), Globals.WebLinksProviders) )
          reconstruct();
      }));
    }
  }

  /// <summary>
  /// Handles the MouseUp event of the Menu control.
  /// </summary>
  /// <param name="sender">The source of the event.</param>
  /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
  static private void Menu_MouseUp(object sender, MouseEventArgs e)
  {
    if ( e.Button != MouseButtons.Right ) return;
    if ( sender is ToolStripMenuItem menuItem )
    {
      if ( menuItem.Owner is ContextMenuStrip contextMenuSingle )
        contextMenuSingle.Close();
      if ( menuItem.OwnerItem is ToolStripDropDownButton button )
        button.HideDropDown();
      else
      if ( menuItem.OwnerItem is ToolStripMenuItem ownerMenuItem )
        if ( ownerMenuItem.Owner is ContextMenuStrip contextMenuInternal )
          contextMenuInternal.Hide();
        else
          ownerMenuItem.HideDropDown();
      int count = menuItem.DropDownItems.ToEnumerable(item => item is not ToolStripSeparator).Count();
      string msg = SysTranslations.AskToOpenAllLinks.GetLang(menuItem.Text, count);
      if ( DisplayManager.QueryYesNo(msg) )
        foreach ( ToolStripItem item in menuItem.DropDownItems )
          if ( item.Tag != null )
          {
            item.PerformClick();
            Thread.Sleep(1500);
          }
    }
  }

}
