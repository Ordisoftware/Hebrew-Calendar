/// <license>
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
namespace Ordisoftware.Core;

/// <summary>
/// Provides global variables.
/// </summary>
static partial class Globals
{

  /// <summary>
  /// Indicates the support email.
  /// </summary>
  static public string SupportEMail { get; set; }

  /// <summary>
  /// Indicates the author home URL.
  /// </summary>
  static public string AuthorHomeURL { get; set; }
    = AssemblyTrademark;

  /// <summary>
  /// Indicates the author projects URL.
  /// </summary>
  static public string AuthorProjectsURL { get; set; }
    = AssemblyTrademark + "/projects/";

  /// <summary>
  /// Indicates the author contact URL.
  /// </summary>
  static public string AuthorContactURL { get; set; }
    = AssemblyTrademark + "/contact/";

  /// <summary>
  /// Indicates the application home URL.
  /// </summary>
  static public string ApplicationHomeURL { get; set; }
    = AssemblyProduct;

  static public string ApplicationReleaseNotesURL { get; set; }
    = $"{ApplicationHomeURL}/#release{{0}}";

  static public string ApplicationReleaseNews { get; set; }
    = $"{ApplicationHomeURL}/#whatsnew";

  /// <summary>
  /// Indicates the application website SSL certificate information.
  /// </summary>
  static public string ApplicationHomeSSLFilePath { get; set; }
    = Path.Combine(RootFolderPath, "Setup\\SSL", AssemblyTrademark + ".ssl");

  /// <summary>
  /// Indicates the check update URL.
  /// </summary>
  static public string CheckUpdateURL { get; set; }
    = $"https://{AssemblyTrademark}/files/{ApplicationCode}.sha-update";

  /// <summary>
  /// Indicates the setup file name.
  /// </summary>
  static public string SetupFileName { get; set; }
    = $"{AssemblyCompany}{ApplicationCode}Setup-{{0}}.exe";

  /// <summary>
  /// Indicates the new version setup file.
  /// </summary>
  static public string SetupFileURL { get; set; }
    = $"https://{AssemblyTrademark}/download/{SetupFileName}";

  /// <summary>
  /// Indicates the GitHub repository.
  /// </summary>
  static public string GitHubRepositoryURL { get; set; }
    = $"https://github.com/{AssemblyCompany}/{ApplicationGitHubCode}";

  /// <summary>
  /// Indicates the create GitHub issue url.
  /// </summary>
  static public string GitHubCreateIssueURL { get; set; }
    = GitHubRepositoryURL + "/issues/new?assignees=" + AssemblyCompany;

  /// <summary>
  /// Indicates the Softpedia url.
  /// </summary>
  static public string SoftpediaURL { get; set; }

  /// <summary>
  /// Indicates the AlternativeTo url.
  /// </summary>
  static public string AlternativeToURL { get; set; }
    = $"https://alternativeto.net/user/{AssemblyCompany.ToLower()}/";

  /// <summary>
  /// Indicates the file path of the application's icon.
  /// </summary>
  static public string ApplicationIconFilePath
    => Path.Combine(SystemFolderPath, "Application.ico");

  /// <summary>
  /// Indicates the file path of the application's readme markdown file.
  /// </summary>
  static public string ApplicationReadmeMDPath
    => Path.Combine(RootFolderPath, "README.md");

  /// <summary>
  /// Indicates the file path of the help.
  /// </summary>
  static public string HelpFilePath
    => Path.Combine(HelpFolderPath, $"index-{Languages.CurrentCode}.htm");

  /// <summary>
  /// Indicates the file path of the empty sound.
  /// </summary>
  static public string EmptySoundFilePath
    => Path.Combine(ProjectSoundsFolderPath, "Empty.wav");

  /// <summary>
  /// Indicates the file path of the screenshot sound.
  /// </summary>
  static public string ScreenshotSoundFilePath
    => Path.Combine(ProjectSoundsFolderPath, "Screenshot.wav");

  /// <summary>
  /// Indicates the file path of the clipboard sound.
  /// </summary>
  static public string ClipboardSoundFilePath
    => Path.Combine(ProjectSoundsFolderPath, "Clipboard.wav");

  /// <summary>
  /// Indicates the file path of the keyboard sound.
  /// </summary>
  static public string KeyboardSoundFilePath
    => Path.Combine(ProjectSoundsFolderPath, "Keyboard.wav");

  /// <summary>
  /// Indicates the file path of the printer sound.
  /// </summary>
  static public string PrinterSoundFilePath
    => Path.Combine(ProjectSoundsFolderPath, "Printer.wav");

  /// <summary>
  /// Indicates the SQLite system DLL file path.
  /// </summary>
  static public string SQLiteSystemDLLFilePath
    => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "system32", "sqlite3odbc.dll");

  /// <summary>
  /// Indicates the extension of database files.
  /// </summary>
  static public string DatabaseFileExtension { get; set; }
    = ".sqlite";

  /// <summary>
  /// Indicates the application ODBC DSN of the database.
  /// </summary>
  static public string ApplicationDatabaseOdbcDSN
    => ApplicationGitHubCode;

  /// <summary>
  /// Indicates the file name of the application database.
  /// </summary>
  static public string ApplicationDatabaseFileName
    => ApplicationDatabaseOdbcDSN + DatabaseFileExtension;

  /// <summary>
  /// Indicates the file path of the application database.
  /// </summary>
  static public string ApplicationDatabaseFilePath
    => Path.Combine(DatabaseFolderPath, ApplicationDatabaseFileName);

  /// <summary>
  /// Indicates the common ODBC DSN of the database.
  /// </summary>
  static public string CommonDatabaseOdbcDSN
    => HebrewCommonDirectoryName.Replace(" ", "-");

  /// <summary>
  /// Indicates the application database ODBC connection string.
  /// </summary>
  static public string ApplicationOdbcConnectionString
    => "Dsn=" + ApplicationDatabaseOdbcDSN;

  /// <summary>
  /// Indicates the file name of the common database.
  /// </summary>
  static public string CommonDatabaseFileName
    => CommonDatabaseOdbcDSN + DatabaseFileExtension;

  /// <summary>
  /// Indicates the file path of the common database.
  /// </summary>
  static public string CommonDatabaseFilePath
    => Path.Combine(UserDataCommonFolderPath, CommonDatabaseFileName);

  /// <summary>
  /// Indicates the application database SQLite connection string.
  /// </summary>
  static public string ApplicationSQLiteNetConnectionString
    => "Datasource=" + ApplicationDatabaseFilePath;

  /// <summary>
  /// Indicates the common database ODBC connection string.
  /// </summary>
  static public string CommonOdbcConnectionString
    => "Dsn=" + CommonDatabaseOdbcDSN;

  /// <summary>
  /// Indicates the common database SQLite connection string.
  /// </summary>
  static public string CommonSQLiteNetConnectionString
    => "Datasource=" + CommonDatabaseFilePath;

}
