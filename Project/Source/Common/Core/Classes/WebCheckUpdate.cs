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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides web check update.
/// </summary>
static class WebCheckUpdate
{

  static private bool Mutex;

  static public int DefaultCheckDaysInterval { get; set; } = Globals.DaysOfWeekCount;

  /// <summary>
  /// Deletes temp files.
  /// </summary>
  static public void CleanTemp()
  {
    SystemManager.TryCatch(() =>
    {
      foreach ( string s in Directory.GetFiles(Path.GetTempPath(), string.Format(Globals.SetupFileName, "*")) )
        SystemManager.TryCatch(() => File.Delete(s));
    });
  }

  /// <summary>
  /// Checks if an update is available online and offer to install, download or open product web page.
  /// App version is "MAJOR.MINOR".
  /// </summary>
  /// <returns>
  /// True if application must exist else false.
  /// </returns>
  /// <param name="lastdone">The last done date.</param>
  /// <param name="interval">Days interval to check.</param>
  /// <param name="auto">True if no user interaction else false.</param>
  /// <param name="checkAtStartup">True if it is a startup check.</param>
  /// <param name="useGitHub">True to use GitHub.</param>
  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  static public bool Run(ref DateTime lastdone, int interval, bool auto, bool checkAtStartup, bool useGitHub = false)
  {
    if ( interval == -1 ) interval = DefaultCheckDaysInterval;
    CleanTemp();
    if ( Mutex ) return false;
    if ( auto && !checkAtStartup ) return false;
    if ( auto && lastdone.AddDays(interval) >= DateTime.Now ) return false;
    var form = FormsHelper.GetActiveForm();
    bool formEnabled = form?.Enabled ?? false;
    bool formTopMost = form?.TopMost ?? false;
    bool formHidden = LoadingForm.Instance.Hidden;
    try
    {
      Mutex = true;
      if ( form is not null )
      {
        form.TopMost = true;
        form.TopMost = formTopMost;
        form.Enabled = false;
      }
      LoadingForm.Instance.Hidden = auto;
      LoadingForm.Instance.Initialize(SysTranslations.WebCheckUpdate.GetLang(), 3, 0, false);
      LoadingForm.Instance.Owner = Globals.MainForm;
      LoadingForm.Instance.DoProgress();
      using var client = new WebClientEx();
      var fileInfo = GetVersionAndChecksum(client, useGitHub);
      lastdone = DateTime.Now;
      if ( fileInfo.Item1.CompareTo(Assembly.GetExecutingAssembly().GetName().Version) > 0 )
        return GetUserChoice(client, fileInfo, useGitHub);
      else
      if ( !auto )
        DisplayManager.ShowInformation(SysTranslations.NoNewVersionAvailable.GetLang());
    }
    catch ( UnauthorizedAccessException ex )
    {
      CleanTemp();
      if ( !auto )
      {
        DisplayManager.ShowWarning(SysTranslations.CheckUpdate.GetLang(Globals.AssemblyTitle), ex.Message);
        if ( DisplayManager.QueryYesNo(SysTranslations.AskToOpenGitHubPage.GetLang()) )
          SystemManager.OpenGitHupRepo();
      }
    }
    catch ( IOException ex )
    {
      CleanTemp();
      if ( !auto )
      {
        DisplayManager.ShowWarning(SysTranslations.CheckUpdate.GetLang(Globals.AssemblyTitle), ex.Message);
        if ( DisplayManager.QueryYesNo(SysTranslations.AskToOpenGitHubPage.GetLang()) )
          SystemManager.OpenGitHupRepo();
      }
    }
    catch ( WebException ex )
    {
      // TODO create advanced box to retry-cancel
      CleanTemp();
      string msg = ex.Message;
      if ( ex.Status == WebExceptionStatus.Timeout )
      {
        if ( auto )
          if ( useGitHub )
            return false;
          else
            return Run(ref lastdone, interval, auto, checkAtStartup, true);
        else
        if ( useGitHub )
          msg += Globals.NL2 + SysTranslations.CheckInternetConnection.GetLang();
        else
          return Run(ref lastdone, interval, auto, checkAtStartup, true);
      }
      if ( !auto )
        DisplayManager.ShowWarning(SysTranslations.CheckUpdate.GetLang(Globals.AssemblyTitle), msg);
    }
    catch ( Exception ex )
    {
      CleanTemp();
      if ( !auto )
        DisplayManager.ShowWarning(SysTranslations.CheckUpdate.GetLang(Globals.AssemblyTitle), ex.Message);
    }
    finally
    {
      doFinally();
    }
    return false;
    //
    void doFinally()
    {
      Mutex = false;
      LoadingForm.Instance.Hidden = formHidden;
      LoadingForm.Instance.Hide();
      if ( form is not null )
      {
        form.TopMost = true;
        form.TopMost = formTopMost;
        form.Enabled = formEnabled;
      }
    }
  }

  /// <summary>
  /// Gets the version available online with the file checksum.
  /// </summary>
  [SuppressMessage("Usage", "MA0015:Specify the parameter name in ArgumentException", Justification = "N/A")]
  static private (Version, string) GetVersionAndChecksum(WebClientEx client, bool useGitHub)
  {
    SystemManager.CheckServerCertificate(useGitHub ? Globals.CheckUpdateGitHubURL : Globals.CheckUpdateURL, useGitHub, true);
    List<string> lines;
    try
    {
      string path = useGitHub ? Globals.CheckUpdateGitHubURL : Globals.CheckUpdateURL;
      lines = client.DownloadString(path).SplitNoEmptyLines(useGitHub).Take(2).ToList();
    }
    catch ( Exception ex )
    {
      throw new WebException(SysTranslations.CheckUpdateReadError.GetLang(ex.Message));
    }
    LoadingForm.Instance.DoProgress();
    var list = new NullSafeOfStringDictionary<string>();
    foreach ( string line in lines )
    {
      var parts = line.Split(':');
      if ( parts.Length != 2 ) continue;
      list.Add(parts[0].Trim(), parts[1].Trim());
    }
    string fileVersion = list["Version"];
    string fileChecksum = list["Checksum"];
    if ( fileVersion.IsNullOrEmpty() || fileChecksum.IsNullOrEmpty() )
      throw new WebException(SysTranslations.CheckUpdateFileError.GetLang(lines.AsMultiLine()));
    var partsVersion = fileVersion.Split('.');
    Version version;
    try
    {
      version = partsVersion.Length switch
      {
        2 => new Version(Convert.ToInt32(partsVersion[0]),
                                         Convert.ToInt32(partsVersion[1])),
        3 => new Version(Convert.ToInt32(partsVersion[0]),
                         Convert.ToInt32(partsVersion[1]),
                         Convert.ToInt32(partsVersion[2])),
        4 => new Version(Convert.ToInt32(partsVersion[0]),
                         Convert.ToInt32(partsVersion[1]),
                         Convert.ToInt32(partsVersion[2]),
                         Convert.ToInt32(partsVersion[3])),
        _ => throw new ArgumentException(SysTranslations.CheckUpdateFileError.GetLang(lines.AsMultiLine())),
      };
    }
    catch ( Exception ex )
    {
      throw new WebException(SysTranslations.CheckUpdateFileError.GetLang(lines.AsMultiLine()) + Globals.NL2 +
                             ex.Message);
    }
    LoadingForm.Instance.DoProgress();
    return (version, fileChecksum);
  }

  /// <summary>
  /// Asks to the user what to do.
  /// </summary>
  static private bool GetUserChoice(WebClientEx client, (Version version, string checksum) fileInfo, bool useGitHub)
  {
    LoadingForm.Instance.Hide();
    string path = useGitHub ? Globals.SetupFileGitHubURL : Globals.SetupFileURL;
    string fileURL = string.Format(path, fileInfo.version);
    var result = WebUpdateForm.Run(fileInfo.version);
    switch ( result )
    {
      case WebUpdateSelection.None:
        break;
      case WebUpdateSelection.Download:
        SystemManager.CheckServerCertificate(fileURL, useGitHub, false);
        SystemManager.OpenWebLink(fileURL);
        break;
      case WebUpdateSelection.Install:
        return ProcessAutoInstall(client, fileInfo, fileURL, useGitHub);
      default:
        throw new AdvNotImplementedException(result);
    }
    return false;
  }

  /// <summary>
  /// Processes the automatic download and installation.
  /// </summary>
  [SuppressMessage("Usage", "MA0099:Use Explicit enum value instead of 0", Justification = "N/A")]
  static private bool ProcessAutoInstall(WebClientEx client,
                                         (Version version, string checksum) fileInfo,
                                         string fileURL,
                                         bool useGitHub)
  {
    WebException ex = null;
    bool finished = false;
    bool hidden = LoadingForm.Instance.Hidden;
    try
    {
      LoadingForm.Instance.Hidden = false;
      LoadingForm.Instance.Initialize(SysTranslations.DownloadingNewVersion.GetLang(), 100, 0, false);
      SystemManager.CheckServerCertificate(fileURL, useGitHub, false);
      string filePathTemp = Path.GetTempPath() + string.Format(Globals.SetupFileName, fileInfo.version);
      client.DownloadProgressChanged += progress;
      client.DownloadFileCompleted += completed;
      client.DownloadFileAsync(new Uri(fileURL), filePathTemp);
      while ( !finished )
      {
        Thread.Sleep(100);
        Application.DoEvents();
      }
      if ( ex is not null ) throw ex;
      if ( !SystemManager.CheckIfFileIsExecutable(filePathTemp) )
        throw new IOException(SysTranslations.NotAnExecutableFile.GetLang(filePathTemp));
      if ( SystemManager.GetChecksumSha512(filePathTemp) != fileInfo.checksum )
        throw new IOException(SysTranslations.WrongFileChecksum.GetLang(filePathTemp));
      using var process = SystemManager.GetRunShell(filePathTemp, "/SP- /SILENT");
      if ( process is not null )
      {
        Globals.IsExiting = true;
        return true;
      }
      return false;
    }
    finally
    {
      LoadingForm.Instance.Hidden = hidden;
    }
    // Do progress
    void progress(object sender, DownloadProgressChangedEventArgs e)
    {
      LoadingForm.Instance.SetProgress(e.ProgressPercentage);
    }
    // Download completed
    void completed(object sender, AsyncCompletedEventArgs e)
    {
      finished = true;
      if ( e.Error is null ) return;
      HttpStatusCode code = 0;
      WebExceptionStatus status = 0;
      if ( e.Error is WebException we )
      {
        status = we.Status;
        if ( we.Response is HttpWebResponse response )
          code = response.StatusCode;
      }
      ex = new WebException(e.Error.Message + Globals.NL2 +
                            fileURL + Globals.NL2 +
                            status.ToStringFull() + Globals.NL +
                            code.ToStringFull());
    }
  }

}

/// <summary>
/// Provides web client with timeout.
/// </summary>
public class WebClientEx : WebClient
{

  static public int DefaultTimeOutSeconds { get; set; } = 5;

  public int TimeOutSeconds { get; set; }

  public WebClientEx(int timeOutSeconds = 0)
  {
    if ( timeOutSeconds <= 0 ) timeOutSeconds = DefaultTimeOutSeconds;
    TimeOutSeconds = timeOutSeconds;
  }

  protected override WebRequest GetWebRequest(Uri address)
  {
    var result = base.GetWebRequest(address);
    result.Timeout = TimeOutSeconds * 1000;
    return result;
  }

}
