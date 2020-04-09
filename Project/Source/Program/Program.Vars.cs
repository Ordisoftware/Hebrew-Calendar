/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2019-10 </edited>
using System;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Indicate the default Settings instance.
    /// </summary>
    static public readonly Properties.Settings Settings 
      = Properties.Settings.Default;

    /// <summary>
    /// Indicate the check update URL.
    /// </summary>
    static public string CheckUpdateURL
    {
      get
      {
        string title = AboutBox.Instance.AssemblyTitle;
        return "http://" + AboutBox.Instance.AssemblyTrademark + "/files/" + title.Replace(" ", "") + ".update";
      }
    }

    /// <summary>
    /// Indicate the download application URL.
    /// </summary>
    static public string DownloadApplicationURL
    {
      get
      {
        return AboutBox.Instance.AssemblyProduct;
      }
    }

    /// <summary>
    /// Indicate the GitHub repository.
    /// </summary>
    static public string GitHubRepositoryURL
    {
      get
      {
        string title = AboutBox.Instance.AssemblyTitle;
        return "https://github.com/" + AboutBox.Instance.CompanyName + "/" + title.Replace(" ", "-");
      }
    }

    /// <summary>
    /// Indicate root folder path of the application.
    /// </summary>
    static public readonly string AppRootFolderPath
      = Directory.GetParent
        (
          Path.GetDirectoryName(Application.ExecutablePath
                                .Replace("\\Bin\\Debug\\", "\\Bin\\")
                                .Replace("\\Bin\\Release\\", "\\Bin\\"))
        ).FullName
      + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate application documents folder.
    /// </summary>
    static public readonly string AppDocumentsFolderPath
      = AppRootFolderPath + "Documents" + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate user data folder in roaming.
    /// </summary>
    static public string UserDataFolderPath
    {
      get;
      private set;
    }

    /// <summary>
    /// Indicate user documents folder path.
    /// </summary>
    static public string UserDocumentsFolderPath
    {
      get;
      private set;
    }

    /// <summary>
    /// Indicate the extension of database file.
    /// </summary>
    static public readonly string DBFileExtension
      = ".sqlite";

    /// <summary>
    /// Indicate filename of the application's icon.
    /// </summary>
    static public readonly string IconFilename
      = AppRootFolderPath + "Application.ico";

    /// <summary>
    /// Indicate filename of the help.
    /// </summary>
    static public string HelpFilename
    {
      get
      {
        return AppRootFolderPath + "Help" + Path.DirectorySeparatorChar + "index-" + Localizer.Language + ".htm";
      }
    }

    /// <summary>
    /// Indicate filename of the GPS database.
    /// </summary>
    static public readonly string GPSFilename
      = AppDocumentsFolderPath + "WorldCities.csv";

  }

}
