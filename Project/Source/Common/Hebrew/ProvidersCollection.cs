/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.IO;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide onlince providers collection.
  /// </summary>
  static public partial class ProvidersCollection
  {

    /// <summary>
    /// Indicate the application guides folder.
    /// </summary>
    static public string GuidesFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "Guides");

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
    /// Indicate filename of the hebrew grammar guide.
    /// </summary>
    static public string HebrewGrammarGuideFilename
      => Path.Combine(GuidesFolderPath, "grammar-{0}.htm");

    /// <summary>
    /// Indicate filename of the lettriq method notice.
    /// </summary>
    static public string LettriqMethodNoticeFilename
      => Path.Combine(GuidesFolderPath, "method-{0}.htm");

    /// <summary>
    /// Indicate the filename of the online search word providers.
    /// </summary>
    static public string OnlineWordProvidersFileName
      => Path.Combine(WebProvidersFolderPath, "OnlineWordProviders.txt");

    /// <summary>
    /// Indicate the filename of the online search word providers.
    /// </summary>
    static public string OnlineBibleProvidersFileName
      => Path.Combine(WebProvidersFolderPath, "OnlineBibleProviders.txt");

    /// <summary>
    /// Indicate the online search a word providers.
    /// </summary>
    static public OnlineProviders OnlineWordProviders { get; private set; }

    /// <summary>
    /// Indicate the online bible verse providers.
    /// </summary>
    static public OnlineProviders OnlineBibleProviders { get; private set; }

    /// <summary>
    /// Indicate the web links providers.
    /// </summary>
    static public List<OnlineProviders> WebLinksProviders { get; private set; }

    /// <summary>
    /// Create an online OnlineProviders instance.
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="filename"></param>
    /// <returns></returns>
    static private OnlineProviders CreateOnlineProviders(DataFileFolder folder, string filename)
    {
      try
      {
        return new OnlineProviders(filename, true, Globals.IsDevExecutable, folder);
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(Localizer.LoadFileError.GetLang(filename, ex.Message));
        return null;
      }
    }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static ProvidersCollection()
    {
      if ( Globals.IsDesignTime ) return;
      var folder = DataFileFolder.ApplicationDocuments;
      OnlineWordProviders = CreateOnlineProviders(folder, OnlineWordProvidersFileName);
      OnlineBibleProviders = CreateOnlineProviders(folder, OnlineBibleProvidersFileName);
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
