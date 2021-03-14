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
/// <edited> 2021-03 </edited>
using System;
using System.IO;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide hebrew global variables.
  /// </summary>
  static partial class HebrewGlobals
  {

    /// <summary>
    /// Indicate the application web links folder.
    /// </summary>
    static public string WebLinksFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "WebLinks");

    /// <summary>
    /// Indicate the application web providers folder.
    /// </summary>
    static public string WebProvidersFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "WebProviders");

    /// <summary>
    /// Indicate the file path of the online search word providers.
    /// </summary>
    static public string WebProvidersWordFilePath
      => Path.Combine(WebProvidersFolderPath, "WebProviders-Word.txt");

    /// <summary>
    /// Indicate the file path of the online bible verse providers.
    /// </summary>
    static public string WebProvidersBibleFilePath
      => Path.Combine(WebProvidersFolderPath, "WebProviders-Bible.txt");

    /// <summary>
    /// Indicate the file path of the online study parashah providers.
    /// </summary>
    static public string WebProvidersParashahFilePath
      => Path.Combine(WebProvidersFolderPath, "WebProviders-Parashah.txt");

    /// <summary>
    /// Indicate the online search a word providers.
    /// </summary>
    static public OnlineProviders WebProvidersWord { get; private set; }

    /// <summary>
    /// Indicate the online bible verse providers.
    /// </summary>
    static public OnlineProviders WebProvidersBible { get; private set; }

    /// <summary>
    /// Indicate the online study parashah providers.
    /// </summary>
    static public OnlineProviders WebProvidersParashah { get; private set; }

    /// <summary>
    /// Indicate the web links providers.
    /// </summary>
    static public List<OnlineProviders> WebLinksProviders { get; private set; }

    /// <summary>
    /// Create an online OnlineProviders instance.
    /// </summary>
    static private OnlineProviders CreateOnlineProviders(DataFileFolder folder, string filePath)
    {
      try
      {
        return new OnlineProviders(filePath, true, Globals.IsDevExecutable, folder);
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(SysTranslations.LoadFileError.GetLang(filePath, ex.Message));
        return null;
      }
    }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static HebrewGlobals()
    {
      if ( Globals.IsVisualStudioDesigner ) return;
      var folder = DataFileFolder.ApplicationDocuments;
      WebProvidersWord = CreateOnlineProviders(folder, WebProvidersWordFilePath);
      WebProvidersBible = CreateOnlineProviders(folder, WebProvidersBibleFilePath);
      WebProvidersParashah = CreateOnlineProviders(folder, WebProvidersParashahFilePath);
      WebLinksProviders = new List<OnlineProviders>();
      if ( Directory.Exists(WebLinksFolderPath) )
        SystemManager.TryCatch(() =>
        {
          foreach ( var file in Directory.GetFiles(WebLinksFolderPath, "WebLinks*.txt") )
          {
            var item = CreateOnlineProviders(DataFileFolder.ApplicationDocuments, file);
            if ( item != null ) WebLinksProviders.Add(item);
          }
        });
    }

  }

}
