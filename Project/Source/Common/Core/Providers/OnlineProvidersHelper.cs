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
/// <edited> 2023-01 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides online providers list helper to create menu items.
/// </summary>
static public class OnlineProvidersHelper
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
  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "N/A")]
  static private void SetItems(
    ToolStripItemCollection items,
    OnlineProviders providers,
    EventHandler action,
    Action finished,
    Action reconstruct)
  {
    if ( providers is null || providers.Items.Count == 0 ) return;
    items.Clear();
    string itemsVarName = StackMethods.NameOfFromStack(3).Replace("Globals.", string.Empty);
    foreach ( var item in providers.Items )
      items.Add(item.CreateMenuItem(action));
    finished?.Invoke();
    if ( providers.Configurable )
    {
      items.Add(new ToolStripSeparator());
      items.Add(CreateConfigureMenuItem((sender, e) =>
      {
        if ( DataFileEditorForm.Run(itemsVarName, providers) )
          reconstruct();
      }));
    }
  }

  /// <summary>
  /// Creates sub-menu items for providers menu.
  /// </summary>
  static public void Initialize(
    this ContextMenuStrip menu,
    OnlineProviders providers,
    EventHandler action,
    Action finished = null)
  {
    SetItems(menu.Items, providers, action, finished, () => Initialize(menu, providers, action, finished));
  }

  /// <summary>
  /// Creates sub-menu items for providers menu.
  /// </summary>
  static public void Initialize(
    this ToolStripMenuItem item,
    OnlineProviders providers,
    EventHandler action,
    Action finished = null)
  {
    if ( providers is null ) return;
    SetItems(item.DropDownItems, providers, action, finished, () => Initialize(item, providers, action, finished));
    item.MouseUp += Menu_MouseUp;
  }

  /// <summary>
  /// Creates sub-menu items for web links menu.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "<En attente>")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "<En attente>")]
  static public void CreateWebLinks(this ToolStripDropDownButton root, Action reconstruct)
  {
    var providers = Globals.WebLinksProviders;
    if ( providers is null ) return;
    root.DropDownItems.Clear();
    foreach ( var items in providers )
      if ( items.Items.Count > 0 )
      {
        // Folder
        ToolStripDropDownItem menu;
        if ( items.Title.Count > 0 )
        {
          string title = items.Title.GetLang();
          if ( items.SeparatorBeforeFolder )
            root.DropDownItems.Add(new ToolStripSeparator());
          menu = new ToolStripMenuItem(title);
          root.DropDownItems.Add(menu);
          menu.ImageScaling = ToolStripItemImageScaling.None;
          menu.Image = OnlineProviderItem.FolderImage;
          menu.MouseUp += Menu_MouseUp;
        }
        else
        {
          root.DropDownItems.Add(new ToolStripSeparator());
          menu = root;
        }
        // Items
        foreach ( var item in items.Items )
          menu.DropDownItems.Add(item.CreateMenuItem((sender, e) =>
          {
            string url = (string)( (ToolStripItem)sender ).Tag;
            SystemManager.OpenWebLink(url);
          }));
      }
    if ( root.DropDownItems.Count > 0 && Globals.WebLinksProviders[0].Configurable )
    {
      root.DropDownItems.Add(new ToolStripSeparator());
      root.DropDownItems.Add(CreateConfigureMenuItem((sender, e) =>
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
    if ( sender is not ToolStripMenuItem item ) return;
    if ( item.Owner is ContextMenuStrip menuSingle )
      menuSingle.Close();
    if ( item.OwnerItem is ToolStripDropDownButton button )
      button.HideDropDown();
    else
    if ( item.OwnerItem is ToolStripMenuItem ownerMenuItem )
      if ( ownerMenuItem.Owner is ContextMenuStrip contextMenuInternal )
        contextMenuInternal.Hide();
      else
        ownerMenuItem.HideDropDown();
    int count = item.DropDownItems.ToEnumerable(item => item is not ToolStripSeparator).Count();
    string msg = SysTranslations.AskToOpenAllLinks.GetLang(item.Text, count);
    if ( DisplayManager.QueryYesNo(msg) )
      foreach ( var subitem in item.DropDownItems.ToEnumerable().Where(subitem => subitem.Tag is not null) )
      {
        subitem.PerformClick();
        Thread.Sleep(1500);
      }
  }

}
