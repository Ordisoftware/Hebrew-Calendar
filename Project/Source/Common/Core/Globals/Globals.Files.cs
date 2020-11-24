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
/// <edited> 2020-11 </edited>
using System;
using System.IO;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static public partial class Globals
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
      = AssemblyTrademark + "/projects";

    /// <summary>
    /// Indicate the author contact URL.
    /// </summary>
    static public string AuthorContactURL { get; set; }
      = AssemblyTrademark + "/contact";

    /// <summary>
    /// Indicate the application home URL.
    /// </summary>
    static public string ApplicationHomeURL { get; set; }
      = AssemblyProduct;

    static public string ApplicationReleaseNotesURL { get; set; }
      = $"{ApplicationHomeURL}/#release{{0}}";

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
    /// Indicate the file path of the application's icon.
    /// </summary>
    static public string ApplicationIconFilePath
      => Path.Combine(RootFolderPath, "Application.ico");

    /// <summary>
    /// Indicate the file path of the help.
    /// </summary>
    static public string HelpFilePath
      => Path.Combine(HelpFolderPath, $"index-{Languages.CurrentCode}.htm");

    /// <summary>
    /// Indicate the file path of the snapshot sound.
    /// </summary>
    static public string SnapshotSoundFilePath
      => Path.Combine(ProjectSoundsFolderPath, "Snapshot.wav");

    /// <summary>
    /// Indicate the file path of the clipboard sound.
    /// </summary>
    static public string ClipboardSoundFilePath
      => Path.Combine(ProjectSoundsFolderPath, "Clipboard.wav");

    /// <summary>
    /// Indicate the SQLite system DLL file path.
    /// </summary>
    static public string SQLiteSystemDLLFilePath
      => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "system32", "sqlite3odbc.dll");

    /// <summary>
    /// Indicate the Odbc DSN of the database.
    /// </summary>
    static public string DatabaseOdbcDSN
      => ApplicationGitHubCode;

    /// <summary>
    /// Indicate the extension of database files.
    /// </summary>
    static public string DatabaseFileExtension { get; set; }
      = ".sqlite";

    /// <summary>
    /// Indicate the file name of the database.
    /// </summary>
    static public string DatabaseFileName
      => DatabaseOdbcDSN + DatabaseFileExtension;

    /// <summary>
    /// Indicate the file path of the database.
    /// </summary>
    static public string DatabaseFilePath
      => Path.Combine(DatabaseFolderPath, DatabaseFileName);

  }

}
