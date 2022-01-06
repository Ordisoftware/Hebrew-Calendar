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
/// <created> 2016-04 </created>
/// <edited> 2021-10 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides global variables.
/// </summary>
static partial class Globals
{

  /// <summary>
  /// Indicates the application web links folder.
  /// </summary>
  static public string WebLinksFolderPath
    => Path.Combine(DocumentsFolderPath, "WebLinks");

  /// <summary>
  /// Indicates the web links providers.
  /// </summary>
  static public List<OnlineProviders> WebLinksProviders { get; private set; }

  /// <summary>
  /// Creates an OnlineProviders instance.
  /// </summary>
  static public OnlineProviders CreateOnlineProviders(DataFileFolder folder, string filePath)
  {
    try
    {
      return new OnlineProviders(filePath, true, IsDebugExecutable, folder);
    }
    catch ( FileNotFoundException )
    {
      DisplayManager.ShowError(SysTranslations.FileNotFound.GetLang(filePath));
      return null;
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(SysTranslations.LoadFileError.GetLang(filePath, ex.Message));
      return null;
    }
  }

  /// <summary>
  /// Loads web links providers files.
  /// </summary>
  static public void LoadWebLinksProviders()
  {
    if ( !Directory.Exists(WebLinksFolderPath) ) return;
    WebLinksProviders = new List<OnlineProviders>();
    SystemManager.TryCatchManage(ShowExceptionMode.OnlyMessage, () =>
    {
      foreach ( var file in Directory.GetFiles(WebLinksFolderPath, "WebLinks*.txt") )
      {
        var item = CreateOnlineProviders(DataFileFolder.ApplicationDocuments, file);
        if ( item != null ) WebLinksProviders.Add(item);
      }
    });
  }

}
