﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2021-05 </edited>
using System;
using System.IO;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static partial class Globals
  {

    /// <summary>
    /// Indicate the support email.
    /// </summary>
    static public string SupportEMail { get; set; }

    /// <summary>
    /// Indicate the author home URL.
    /// </summary>
    static public string AuthorHomeURL { get; set; }
      = AssemblyTrademark;

    /// <summary>
    /// Indicate the author projects URL.
    /// </summary>
    static public string AuthorProjectsURL { get; set; }
      = AssemblyTrademark + "/projects/";

    /// <summary>
    /// Indicate the author contact URL.
    /// </summary>
    static public string AuthorContactURL { get; set; }
      = AssemblyTrademark + "/contact/";

    /// <summary>
    /// Indicate the application home URL.
    /// </summary>
    static public string ApplicationHomeURL { get; set; }
      = AssemblyProduct;

    static public string ApplicationReleaseNotesURL { get; set; }
      = $"{ApplicationHomeURL}/#release{{0}}";

    static public string ApplicationReleaseNews { get; set; }
      = $"{ApplicationHomeURL}/#whatsnew";

    /// <summary>
    /// Indicate the application website SSL certificate information.
    /// </summary>
    static public string ApplicationHomeSSLFilePath { get; set; }
      = Path.Combine(RootFolderPath, "Setup\\SSL", AssemblyTrademark + ".ssl");

    /// <summary>
    /// Indicate the check update URL.
    /// </summary>
    static public string CheckUpdateURL { get; set; }
      = $"https://{AssemblyTrademark}/files/{ApplicationCode}.sha-update";

    /// <summary>
    /// Indicate the setup file name.
    /// </summary>
    static public string SetupFileName { get; set; }
      = $"{AssemblyCompany}{ApplicationCode}Setup-{{0}}.exe";

    /// <summary>
    /// Indicate the new version setup file.
    /// </summary>
    static public string SetupFileURL { get; set; }
      = $"https://{AssemblyTrademark}/download/{SetupFileName}";

    /// <summary>
    /// Indicate the GitHub repository.
    /// </summary>
    static public string GitHubRepositoryURL { get; set; }
      = $"https://github.com/{AssemblyCompany}/{ApplicationGitHubCode}";

    /// <summary>
    /// Indicate the create GitHub issue url.
    /// </summary>
    static public string GitHubCreateIssueURL { get; set; }
      = GitHubRepositoryURL + "/issues/new?assignees=" + AssemblyCompany;

    /// <summary>
    /// Indicate the Softpedia url.
    /// </summary>
    static public string SoftpediaURL { get; set; }

    /// <summary>
    /// Indicate the AlternativeTo url.
    /// </summary>
    static public string AlternativeToURL { get; set; }
      = $"https://alternativeto.net/user/{AssemblyCompany.ToLower()}/";

    /// <summary>
    /// Indicate the file path of the application's icon.
    /// </summary>
    static public string ApplicationIconFilePath
      => Path.Combine(SystemFolderPath, "Application.ico");

    /// <summary>
    /// Indicate the file path of the application's readme markdown file.
    /// </summary>
    static public string ApplicationReadmeMDPath
      => Path.Combine(RootFolderPath, "README.md");

    /// <summary>
    /// Indicate the file path of the help.
    /// </summary>
    static public string HelpFilePath
      => Path.Combine(HelpFolderPath, $"index-{Languages.CurrentCode}.htm");

    /// <summary>
    /// Indicate the file path of the emptysound.
    /// </summary>
    static public string EmptySoundFilePath
      => Path.Combine(ProjectSoundsFolderPath, "Empty.wav");

    /// <summary>
    /// Indicate the file path of the screenshot sound.
    /// </summary>
    static public string ScreenshotSoundFilePath
      => Path.Combine(ProjectSoundsFolderPath, "Screenshot.wav");

    /// <summary>
    /// Indicate the file path of the clipboard sound.
    /// </summary>
    static public string ClipboardSoundFilePath
      => Path.Combine(ProjectSoundsFolderPath, "Clipboard.wav");

    /// <summary>
    /// Indicate the file path of the keyboard sound.
    /// </summary>
    static public string KeyboardSoundFilePath
      => Path.Combine(ProjectSoundsFolderPath, "Keyboard.wav");

    /// <summary>
    /// Indicate the file path of the printer sound.
    /// </summary>
    static public string PrinterSoundFilePath
      => Path.Combine(ProjectSoundsFolderPath, "Printer.wav");

    /// <summary>
    /// Indicate the SQLite system DLL file path.
    /// </summary>
    static public string SQLiteSystemDLLFilePath
      => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "system32", "sqlite3odbc.dll");

    /// <summary>
    /// Indicate the extension of database files.
    /// </summary>
    static public string DatabaseFileExtension { get; set; }
      = ".sqlite";

    /// <summary>
    /// Indicate the application ODBC DSN of the database.
    /// </summary>
    static public string ApplicationDatabaseOdbcDSN
      => ApplicationGitHubCode;

    /// <summary>
    /// Indicate the file name of the application database.
    /// </summary>
    static public string ApplicationDatabaseFileName
      => ApplicationDatabaseOdbcDSN + DatabaseFileExtension;

    /// <summary>
    /// Indicate the file path of the application database.
    /// </summary>
    static public string ApplicationDatabaseFilePath
      => Path.Combine(DatabaseFolderPath, ApplicationDatabaseFileName);

    /// <summary>
    /// Indicate the common ODBC DSN of the database.
    /// </summary>
    static public string CommonDatabaseOdbcDSN
      => HebrewCommonDirectoryName.Replace(" ", "-");

    /// <summary>
    /// Indicate the application database ODBC connection string.
    /// </summary>
    static public string ApplicationOdbcConnectionString
      => "Dsn=" + ApplicationDatabaseOdbcDSN;

    /// <summary>
    /// Indicate the file name of the common database.
    /// </summary>
    static public string CommonDatabaseFileName
      => CommonDatabaseOdbcDSN + DatabaseFileExtension;

    /// <summary>
    /// Indicate the file path of the common database.
    /// </summary>
    static public string CommonDatabaseFilePath
      => Path.Combine(UserDataCommonFolderPath, CommonDatabaseFileName);

    /// <summary>
    /// Indicate the application database SQLite connection string.
    /// </summary>
    static public string ApplicationSQLiteNetConnectionString
      => "Datasource=" + ApplicationDatabaseFilePath;

    /// <summary>
    /// Indicate the common database ODBC connection string.
    /// </summary>
    static public string CommonOdbcConnectionString
      => "Dsn=" + CommonDatabaseOdbcDSN;

    /// <summary>
    /// Indicate the common database SQLite connection string.
    /// </summary>
    static public string CommonSQLiteNetConnectionString
      => "Datasource=" + CommonDatabaseFilePath;

  }

}
