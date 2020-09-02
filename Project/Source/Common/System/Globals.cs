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
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static public partial class Globals
  {

    /// <summary>
    /// Indicate new line.
    /// </summary>
    static public readonly string NL = Environment.NewLine;
    static public readonly string NL2 = NL + NL;
    static public readonly string NL3 = NL2 + NL;
    static public readonly string NL4 = NL3 + NL;

    /// <summary>
    /// Indicate the process start date and time.
    /// </summary>
    static public readonly DateTime StartDateTime = DateTime.Now;

    /// <summary>
    /// Indicate the application settings.
    /// </summary>
    static public ApplicationSettingsBase Settings { get; internal set; }

    /// <summary>
    /// Indicate if the application is in loading data stage.
    /// </summary>
    static public bool IsLoadingData { get; set; } = false;

    /// <summary>
    /// Indicate if the application is ready to interact with the user or do its purpose.
    /// </summary>
    static public bool IsReady { get; set; } = false;

    /// <summary>
    /// Indicate if the windows session is ending.
    /// </summary>
    static public bool IsSessionEnding { get; set; } = false;

    /// <summary>
    /// Indicate if the application is exiting.
    /// </summary>
    static public bool IsExiting { get; set; } = false;

    /// <summary>
    /// Indicate if the application can be closed.
    /// </summary>
    static public bool AllowClose { get; set; } = true;

    /// <summary>
    /// Indicate the application process name.
    /// </summary>
    static public readonly string ProcessName
      = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

    /// <summary>
    /// Indicate the real application process name.
    /// </summary>
    static public ProcessPriorityClass RealProcessPriority
    {
      get
      {
        var list = Process.GetProcessesByName(ProcessName);
        return list.Length == 1 ? list[0].PriorityClass : 0;
      }
    }

    /// <summary>
    /// Indicate the main form.
    /// </summary>
    static public Form MainForm
    {
      get => _MainForm ?? ( Application.OpenForms.Count > 0 ? Application.OpenForms[0] : Form.ActiveForm );
      set => _MainForm = value;
    }
    static private Form _MainForm;

    /// <summary>
    /// Indicate the application code (title without space
    /// </summary>
    static public readonly string ApplicationCode
      = AssemblyTitle.Replace(" ", "");

    /// <summary>
    /// Indicate the application code (title without space
    /// </summary>
    static public readonly string HebrewCommonDirectoryName
      = "Hebrew Common";

    /// <summary>
    /// Indicate the application home URL.
    /// </summary>
    static public string ApplicationHomeURL { get; set; }
      = AssemblyProduct;

    static public string ApplicationReleaseNotesURL { get; set; }
      = $"{ApplicationHomeURL}/#release{{0}}";

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
    /// Indicate the check update URL.
    /// </summary>
    static public string CheckUpdateURL { get; set; }
      = $"https://{AssemblyTrademark}/files/{ApplicationCode}.update";

    /// <summary>
    /// Indicate the setup file name.
    /// </summary>
    static public string SetupFilename { get; set; }
      = $"{AssemblyCompany}{ApplicationCode}Setup-{{0}}.exe";

    /// <summary>
    /// Indicate the new version setup file.
    /// </summary>
    static public string SetupFileURL { get; set; }
      = $"https://{AssemblyTrademark}/files/{SetupFilename}";

    /// <summary>
    /// Indicate the GitHub repository.
    /// </summary>
    static public string GitHubRepositoryURL { get; set; }
      = $"https://github.com/{AssemblyCompany}/{AssemblyTitle.Replace(" ", "-")}";

    /// <summary>
    /// Indicate the create GitHub issue url.
    /// </summary>
    static public string GitHubCreateIssueURL { get; set; }
      = GitHubRepositoryURL + "/issues/new?assignees=" + AssemblyCompany;

    /// <summary>
    /// Indicate the extension of database files.
    /// </summary>
    static public string DatabaseFileExtension { get; set; }
      = ".sqlite";

    /// <summary>
    /// Indicate generated executable bin directory.
    /// </summary>
    static public string BinDirectory { get; set; } 
      = "Bin";

    /// <summary>
    /// Indicate generated executable debug directory.
    /// </summary>
    static public string DebugDirectory { get; set; }
      = Path.Combine(BinDirectory, "Debug");

    /// <summary>
    /// Indicate generated executable release directory.
    /// </summary>
    static public string ReleaseDirectory { get; set; }
      = Path.Combine(BinDirectory, "Release");

    /// <summary>
    /// Indicate if the executable has been generated in debug mode.
    /// </summary>
    static public bool IsDebugExecutable
    {
      get
      {
        bool isDebug = false;
        CheckDebugExecutable(ref isDebug);
        return isDebug;
      }
    }

    [Conditional("DEBUG")]
    static private void CheckDebugExecutable(ref bool isDebug)
      => isDebug = true;

    /// <summary>
    /// Indicate if the running app is from dev folder else user installed.
    /// </summary>
    static public bool IsDev
      => Application.ExecutablePath.Contains(DebugDirectory) || Application.ExecutablePath.Contains(ReleaseDirectory);

    /// <summary>
    /// Indicate if the code is executed from the IDE else from a running app.
    /// </summary>
    public static bool IsDesignTime
      => System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;

    /// <summary>
    /// Indicate the root folder path of the application.
    /// </summary>
    static public string RootFolderPath
      => Directory.GetParent
         (
           Path.GetDirectoryName(Application.ExecutablePath
                                 .Replace(DebugDirectory, BinDirectory)
                                 .Replace(ReleaseDirectory, BinDirectory))
         ).FullName;

    /// <summary>
    /// Indicate the filename of the application's icon.
    /// </summary>
    static public string ApplicationIconFilename
      => Path.Combine(RootFolderPath, "Application.ico");

    /// <summary>
    /// Indicate the filename of the help.
    /// </summary>
    static public string HelpFolderPath
      => Path.Combine(RootFolderPath, "Help");

    /// <summary>
    /// Indicate the application documents folder.
    /// </summary>
    static public string DocumentsFolderPath
      => Path.Combine(RootFolderPath, "Documents");

    /// <summary>
    /// Indicate the application web links folder.
    /// </summary>
    static public string WebLinksFolderPath
      => Path.Combine(DocumentsFolderPath, "WebLinks");

    /// <summary>
    /// Indicate the application web providers folder.
    /// </summary>
    static public string WebProvidersFolderPath
      => Path.Combine(DocumentsFolderPath, "WebProviders");

    /// <summary>
    /// Indicate the application web links folder.
    /// </summary>
    static public string GuidesFolderPath
      => Path.Combine(DocumentsFolderPath, "Guides");

    /// <summary>
    /// Indicate filename of the grammar guide.
    /// </summary>
    static public string GrammarGuideFilename
      => Path.Combine(GuidesFolderPath, "grammar-{0}.htm");

    /// <summary>
    /// Indicate filename of the method notice.
    /// </summary>
    static public string MethodNoticeFilename
      => Path.Combine(GuidesFolderPath, "method-{0}.htm");

    /// <summary>
    /// Indicate the filename of the help.
    /// </summary>
    static public string HelpFilename
      => Path.Combine(HelpFolderPath, $"index-{Languages.Current}.htm");

    /// <summary>
    /// Indicate the trace file mode.
    /// </summary>
    static public TraceRollOverMode TraceFileMode { get; set; }
     = TraceRollOverMode.Daily;

    /// <summary>
    /// Indicate the trace file keep count.
    /// </summary>
    static public int TraceFileKeepCount { get; set; }
     = 7;

    /// <summary>
    /// Indicate the trace file code.
    /// </summary>
    static public string TraceFileCode { get; set; }
      = "Trace";

    /// <summary>
    /// Indicate the trace file extension.
    /// </summary>
    static public string TraceFileExtension { get; set; }
      = ".log";

    /// <summary>
    /// Indicate the trace filename.
    /// </summary>
    static public string TraceDirectoryName { get; set; }
      = "Logs";

    /// <summary>
    /// Indicate the trace filename.
    /// </summary>
    static public string TraceFolderPath
      => Path.Combine(UserDataFolderPath, TraceDirectoryName);

    /// <summary>
    /// Indicate the application database folder.
    /// </summary>
    static public string DatabaseFolderPath
      => UserDataFolderPath;

    /// <summary>
    /// Indicate the Odbc DSN of the database.
    /// </summary>
    static public string OdbcDSN
      => AssemblyTitle.Replace(" ", "-");

    /// <summary>
    /// Indicate the filename of the database.
    /// </summary>
    static public string DatabaseFileName
      => Path.Combine(DatabaseFolderPath, OdbcDSN + DatabaseFileExtension);

    /// <summary>
    /// Indicate the filename of the database.
    /// </summary>
    static public string RegisterOdbcFilename
      => Path.Combine(Directory.GetParent(RootFolderPath).FullName, "Register ODBC.reg");

    /// <summary>
    /// Indicate a path for in a special folder.
    /// </summary>
    static private string CreateSpecialFolderPath(Environment.SpecialFolder folder, string directory)
      => Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(folder),
                                                AssemblyCompany,
                                                directory)).FullName;

    /// <summary>
    /// Indicate the user documents folder path.
    /// </summary>
    static public string UserDocumentsFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.MyDocuments, AssemblyTitle);

    /// <summary>
    /// Indicate the user data folder in roaming.
    /// </summary>
    static public string UserDataFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.ApplicationData, AssemblyTitle);

    /// <summary>
    /// Indicate the hebrew common data folder in roaming.
    /// </summary>
    static public string UserDataCommonFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.ApplicationData, HebrewCommonDirectoryName);

    /// <summary>
    /// Indicate the hebrew common data folder in program data.
    /// </summary>
    static public string ProgramDataFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.CommonApplicationData, HebrewCommonDirectoryName);

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
    static public List<OnlineProviders> WebLinksProviders
    {
      get
      {
        if ( _WebLinksProviders == null ) _WebLinksProviders = new List<OnlineProviders>();
        if ( _WebLinksProviders.Count == 0 )
          if ( Directory.Exists(WebLinksFolderPath) )
            try
            {
              foreach ( var file in Directory.GetFiles(WebLinksFolderPath, "WebLinks*.txt") )
                _WebLinksProviders.Add(new OnlineProviders(file, true, IsDev, DataFileFolder.ApplicationDocuments));
            }
            catch ( Exception ex )
            {
              string msg = Localizer.LoadFileError.GetLang(Path.Combine(WebLinksFolderPath, "WebLinks*.txt"), ex.Message);
              DisplayManager.ShowError(msg);
            }
        return _WebLinksProviders;
      }
    }

    static private List<OnlineProviders> _WebLinksProviders;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Globals()
    {
      if ( IsDesignTime ) return;
      var folder = DataFileFolder.ApplicationDocuments;
      try
      {
        OnlineWordProviders = new OnlineProviders(OnlineWordProvidersFileName, true, IsDev, folder);
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      try
      {
        OnlineBibleProviders = new OnlineProviders(OnlineBibleProvidersFileName, true, IsDev, folder);
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }
  }

}
