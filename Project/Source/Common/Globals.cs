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
/// <created> 2016-04 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static public partial class Globals
  {

    /// <summary>
    /// Indicate the main form.
    /// </summary>
    static public Form MainForm { get; set; }

    /// <summary>
    /// Indicate the application settings.
    /// </summary>
    static public ApplicationSettingsBase Settings { get; set; }

    /// <summary>
    /// Indicate if the application is in loading data stage.
    /// </summary>
    static public bool IsLoadingData = false;

    /// <summary>
    /// Indicate if the application is ready to interact with the user or do its purpose.
    /// </summary>
    static public bool IsReady = false;

    /// <summary>
    /// Indicate if the windows session is ending.
    /// </summary>
    static public bool IsSessionEnding = false;

    /// <summary>
    /// Indicate if the application is exiting.
    /// </summary>
    static public bool IsExiting = false;

    /// <summary>
    /// Indicate if the application can be closed.
    /// </summary>
    static public bool AllowClose = true;

    /// <summary>
    /// Indicate the check update URL.
    /// </summary>
    static public string CheckUpdateURL
      = $"http://{AssemblyTrademark}/files/{AssemblyTitle.Replace(" ", "")}.update";

    /// <summary>
    /// Indicate the download application URL.
    /// </summary>
    static public string DownloadApplicationURL
      = AssemblyProduct;

    /// <summary>
    /// Indicate the application home URL.
    /// </summary>
    static public string ApplicationHomeURL
      = AssemblyProduct;

    /// <summary>
    /// Indicate the author home URL.
    /// </summary>
    static public string AuthorHomeURL
      = AssemblyTrademark;

    /// <summary>
    /// Indicate the contact URL.
    /// </summary>
    static public string ContactURL
      = AssemblyTrademark + "/contact";

    /// <summary>
    /// Indicate the GitHub repository.
    /// </summary>
    static public string GitHubRepositoryURL
      = $"https://github.com/{AssemblyCompany}/{AssemblyTitle.Replace(" ", "-")}";

    /// <summary>
    /// Indicate the GitHub issues page.
    /// </summary>
    static public string GitHubIssuesURL
      = GitHubRepositoryURL + "/issues";

    /// <summary>
    /// Indicate the extension of database files.
    /// </summary>
    static public readonly string DBFileExtension
      = ".sqlite";

    /// <summary>
    /// Indicate the root folder path of the application.
    /// </summary>
    static public readonly string RootFolderPath
      = Directory.GetParent
        (
          Path.GetDirectoryName(Application.ExecutablePath
                                .Replace("\\Bin\\Debug\\", "\\Bin\\")
                                .Replace("\\Bin\\Release\\", "\\Bin\\"))
        ).FullName
      + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate the filename of the application's icon.
    /// </summary>
    static public readonly string IconFilename
      = RootFolderPath + "Application.ico";

    /// <summary>
    /// Indicate the filename of the help.
    /// </summary>
    static public readonly string HelpFolderPath
      = RootFolderPath + "Help" + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate the application documents folder.
    /// </summary>
    static public readonly string DocumentsFolderPath
      = RootFolderPath + "Documents" + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate the application web links folder.
    /// </summary>
    static public readonly string WebLinksFolderPath
      = DocumentsFolderPath + "WebLinks" + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate the application web providers folder.
    /// </summary>
    static public readonly string WebProvidersFolderPath
      = DocumentsFolderPath + "WebProviders" + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate the application web links folder.
    /// </summary>
    static public readonly string GuidesFolderPath
      = DocumentsFolderPath + "Guides" + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate filename of the grammar guide.
    /// </summary>
    static public string GrammarGuideFilename
      = GuidesFolderPath + $"grammar-%LANG%.htm";

    /// <summary>
    /// Indicate filename of the method notice.
    /// </summary>
    static public string MethodNoticeFilename
      = GuidesFolderPath + $"method-%LANG%.htm";

    /// <summary>
    /// Indicate the filename of the help.
    /// </summary>
    static public string HelpFilename
    {
      get
      {
        return HelpFolderPath + $"index-{Localizer.Language}.htm";
      }
    }

    /// <summary>
    /// Indicate the user data folder in roaming.
    /// </summary>
    static public string UserDataFolderPath
    {
      get
      {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                    + Path.DirectorySeparatorChar
                    + AssemblyCompany
                    + Path.DirectorySeparatorChar
                    + AssemblyTitle
                    + Path.DirectorySeparatorChar;
        Directory.CreateDirectory(path);
        return path;
      }
    }

    /// <summary>
    /// Indicate the user documents folder path.
    /// </summary>
    static public string UserDocumentsFolderPath
    {
      get
      {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    + Path.DirectorySeparatorChar
                    + AssemblyCompany
                    + Path.DirectorySeparatorChar
                    + AssemblyTitle
                    + Path.DirectorySeparatorChar;
        Directory.CreateDirectory(path);
        return path;
      }
    }

    /// <summary>
    /// Indicate the filename of the online search word providers.
    /// </summary>
    static public readonly string OnlineWordProvidersFileName
      = WebProvidersFolderPath + "OnlineWordProviders.txt";

    /// <summary>
    /// Indicate the online search a word providers.
    /// </summary>
    static public OnlineProviders OnlineWordProviders { get; private set; }

    /// <summary>
    /// Indicate the filename of the online search word providers.
    /// </summary>
    static public readonly string OnlineBibleProvidersFileName
      = WebProvidersFolderPath + "OnlineBibleProviders.txt";

    /// <summary>
    /// Indicate the online bible verse providers.
    /// </summary>
    static public OnlineProviders OnlineBibleProviders { get; private set; }

    /// <summary>
    /// Indicate the online links providers.
    /// </summary>
    static public readonly List<OnlineProviders> OnlineLinksProviders
      = new List<OnlineProviders>();

    /// <summary>
    /// Static constructor.
    /// </summary>
    //static public void LoadProvidersAndLinks()
    static Globals()
    {
      OnlineWordProviders = new OnlineProviders(OnlineWordProvidersFileName);
      OnlineBibleProviders = new OnlineProviders(OnlineBibleProvidersFileName);
      OnlineLinksProviders.Clear();
      if ( Directory.Exists(WebLinksFolderPath) )
        foreach ( var file in Directory.GetFiles(WebLinksFolderPath, "WebLinks*.txt") )
          OnlineLinksProviders.Add(new OnlineProviders(file));
    }

    #region Assembly information

    /// <summary>
    /// Get the assembly title.
    /// </summary>
    static public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if ( attributes.Length > 0 )
        {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if ( titleAttribute.Title != "" )
            return titleAttribute.Title;
        }
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    /// <summary>
    /// Get the assembly version.
    /// </summary>
    static public string AssemblyVersion
    {
      get
      {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        return version.Major + "." + version.Minor;
      }
    }

    /// <summary>
    /// Get information describing the assembly.
    /// </summary>
    static public string AssemblyDescription
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        return attributes.Length == 0 ? "" : ( (AssemblyDescriptionAttribute)attributes[0] ).Description;
      }
    }

    /// <summary>
    /// Get the assembly product.
    /// </summary>
    static public string AssemblyProduct
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        return attributes.Length == 0 ? "" : ( (AssemblyProductAttribute)attributes[0] ).Product;
      }
    }

    /// <summary>
    /// Get the assembly copyright.
    /// </summary>
    static public string AssemblyCopyright
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        return attributes.Length == 0 ? "" : ( (AssemblyCopyrightAttribute)attributes[0] ).Copyright;
      }
    }

    /// <summary>
    /// Get the assembly company.
    /// </summary>
    static public string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        return attributes.Length == 0 ? "" : ( (AssemblyCompanyAttribute)attributes[0] ).Company;
      }
    }

    /// <summary>
    /// get the assembly trademark.
    /// </summary>
    static public string AssemblyTrademark
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false);
        return attributes.Length == 0 ? "" : ( (AssemblyTrademarkAttribute)attributes[0] ).Trademark;
      }

    }

    /// <summary>
    /// get the assembly GUID.
    /// </summary>
    static public string AssemblyGUID
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
        return attributes.Length == 0 ? "" : ( (GuidAttribute)attributes[0] ).Value;
      }
    }

    #endregion

  }

}
