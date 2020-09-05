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
/// <edited> 2020-08 </edited>
using System;
using System.IO;

namespace Ordisoftware.HebrewCommon
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
    /// Indicate the contact URL.
    /// </summary>
    static public string ContactURL { get; set; }
      = AssemblyTrademark + "/contact";

    /// <summary>
    /// Indicate the application home URL.
    /// </summary>
    static public string ApplicationHomeURL { get; set; }
      = AssemblyProduct;

    static public string ApplicationReleaseNotesURL { get; set; }
      = $"{ApplicationHomeURL}/#release{{0}}";

    /// <summary>
    /// Indicate the check update URL.
    /// </summary>
    static public string CheckUpdateURL { get; set; }
      = $"https://{AssemblyTrademark}/files/{ApplicationCode}.update";

    /// <summary>
    /// Indicate the new version setup file.
    /// </summary>
    static public string SetupFileURL { get; set; }
      = $"https://{AssemblyTrademark}/files/{SetupFilename}";

    /// <summary>
    /// Indicate the setup file name.
    /// </summary>
    static public string SetupFilename { get; set; }
      = $"{AssemblyCompany}{ApplicationCode}Setup-{{0}}.exe";

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
    /// Indicate the filename of the application's icon.
    /// </summary>
    static public string ApplicationIconFilename
      => Path.Combine(RootFolderPath, "Application.ico");

    /// <summary>
    /// Indicate the filename of the help.
    /// </summary>
    static public string HelpFilename
      => Path.Combine(HelpFolderPath, $"index-{Languages.CurrentCode}.htm");

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
    /// Indicate the Odbc DSN of the database.
    /// </summary>
    static public string OdbcDSN
      => ApplicationGitHubCode;

    /// <summary>
    /// Indicate the filename of the database.
    /// </summary>
    static public string RegisterOdbcFilename
      => Path.Combine(Directory.GetParent(RootFolderPath).FullName, "Register ODBC.reg");

    /// <summary>
    /// Indicate the extension of database files.
    /// </summary>
    static public string DatabaseFileExtension { get; set; }
      = ".sqlite";

    /// <summary>
    /// Indicate the filename of the database.
    /// </summary>
    static public string DatabaseFileName
      => Path.Combine(DatabaseFolderPath, OdbcDSN + DatabaseFileExtension);

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

  }

}
