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
/// <edited> 2021-08 </edited>
using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide web check update.
  /// </summary>
  static class WebCheckUpdate
  {

    static public int DefaultCheckDaysInterval { get; set; } = 7;

    static private bool Mutex;

    /// <summary>
    /// Delete temp files.
    /// </summary>
    static public void CleanTemp()
    {
      SystemManager.TryCatch(() =>
      {
        var files = Directory.GetFiles(Path.GetTempPath(), string.Format(Globals.SetupFileName, "*"));
        foreach ( string s in files ) SystemManager.TryCatch(() => File.Delete(s));
      });
    }

    /// <summary>
    /// Check if an update is available online and offer to install, download or open product web page.
    /// App version is "MAJOR.MINOR".
    /// </summary>
    /// <param name="checkAtStartup"></param>
    /// <param name="lastdone">The last done date.</param>
    /// <param name="interval">Days interval to check.</param>
    /// <param name="auto">True if no user interaction else false</param>
    /// <returns>True if application must exist else false.</returns>
    static public bool Run(bool checkAtStartup, ref DateTime lastdone, int interval, bool auto)
    {
      if ( interval == -1 ) interval = DefaultCheckDaysInterval;
      CleanTemp();
      if ( Mutex ) return false;
      if ( auto && !checkAtStartup ) return false;
      if ( auto && lastdone.AddDays(interval) >= DateTime.Now ) return false;
      var form = FormsHelper.GetActiveForm();
      bool formEnabled = form?.Enabled ?? false;
      bool formTopMost = form?.TopMost ?? false;
      try
      {
        Mutex = true;
        if ( form != null )
        {
          form.TopMost = true;
          form.TopMost = formTopMost;
          form.Enabled = false;
        }
        LoadingForm.Instance.Initialize(SysTranslations.WebCheckUpdate.GetLang(), 3, 0, false);
        LoadingForm.Instance.Owner = Globals.MainForm;
        LoadingForm.Instance.DoProgress();
        using var client = new WebClientEx();
        var fileInfo = GetVersionAndChecksum(client);
        lastdone = DateTime.Now;
        if ( fileInfo.Item1.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) > 0 )
          return GetUserChoice(client, fileInfo);
        else
        if ( !auto )
          DisplayManager.ShowInformation(SysTranslations.NoNewVersionAvailable.GetLang());
      }
      catch ( UnauthorizedAccessException ex )
      {
        CleanTemp();
        DisplayManager.ShowWarning(SysTranslations.CheckUpdate.GetLang(Globals.AssemblyTitle), ex.Message);
        if ( DisplayManager.QueryYesNo(SysTranslations.AskToOpenGitHubPage.GetLang()) )
          SystemManager.OpenGitHupRepo();
      }
      catch ( IOException ex )
      {
        CleanTemp();
        DisplayManager.ShowWarning(SysTranslations.CheckUpdate.GetLang(Globals.AssemblyTitle), ex.Message);
        if ( DisplayManager.QueryYesNo(SysTranslations.AskToOpenGitHubPage.GetLang()) )
          SystemManager.OpenGitHupRepo();
      }
      catch ( WebException ex )
      {
        CleanTemp();
        string msg = ex.Message;
        if ( ex.Status == WebExceptionStatus.Timeout )
          msg += Globals.NL2 + SysTranslations.CheckInternetConnection.GetLang();
        DisplayManager.ShowWarning(SysTranslations.CheckUpdate.GetLang(Globals.AssemblyTitle), msg);
      }
      catch ( Exception ex )
      {
        CleanTemp();
        DisplayManager.ShowWarning(SysTranslations.CheckUpdate.GetLang(Globals.AssemblyTitle), ex.Message);
      }
      finally
      {
        Mutex = false;
        LoadingForm.Instance.Hide();
        if ( form != null )
        {
          form.TopMost = true;
          form.TopMost = formTopMost;
          form.Enabled = formEnabled;
        }
      }
      return false;
    }

    /// <summary>
    /// Get the version available online with the file checksum.
    /// </summary>
    static private (Version, string) GetVersionAndChecksum(WebClient client)
    {
      SystemManager.CheckServerCertificate(Globals.CheckUpdateURL);
      List<string> lines;
      try
      {
        lines = client.DownloadString(Globals.CheckUpdateURL).SplitNoEmptyLines().Take(2).ToList();
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
      string[] partsVersion = fileVersion.Split('.');
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
    /// Ask to the user what to do.
    /// </summary>
    static private bool GetUserChoice(WebClient client, (Version version, string checksum) fileInfo)
    {
      LoadingForm.Instance.Hide();
      string fileURL = string.Format(Globals.SetupFileURL, fileInfo.version.ToString());
      var result = WebUpdateForm.Run(fileInfo.version);
      switch ( result )
      {
        case WebUpdateSelection.None:
          break;
        case WebUpdateSelection.Download:
          SystemManager.CheckServerCertificate(fileURL);
          SystemManager.OpenWebLink(fileURL);
          break;
        case WebUpdateSelection.Install:
          return ProcessAutoInstall(client, fileInfo, fileURL);
        default:
          throw new AdvancedNotImplementedException(result);
      }
      return false;
    }

    /// <summary>
    /// Process the automatic download and installation.
    /// </summary>
    static private bool ProcessAutoInstall(WebClient client,
                                           (Version version, string checksum) fileInfo,
                                           string fileURL)
    {
      Exception ex = null;
      bool finished = false;
      bool hidden = LoadingForm.Instance.Hidden;
      try
      {
        LoadingForm.Instance.Hidden = false;
        LoadingForm.Instance.Initialize(SysTranslations.DownloadingNewVersion.GetLang(), 100, 0, false);
        SystemManager.CheckServerCertificate(fileURL);
        string filePathTemp = Path.GetTempPath() + string.Format(Globals.SetupFileName, fileInfo.version.ToString());
        client.DownloadProgressChanged += progress;
        client.DownloadFileCompleted += completed;
        client.DownloadFileAsync(new Uri(fileURL), filePathTemp);
        while ( !finished )
        {
          Thread.Sleep(100);
          Application.DoEvents();
        }
        if ( ex != null ) throw ex;
        if ( !SystemManager.CheckIfFileIsExecutable(filePathTemp) )
          throw new IOException(SysTranslations.NotAnExecutableFile.GetLang(filePathTemp));
        if ( SystemManager.GetChecksum512(filePathTemp) != fileInfo.checksum )
          throw new IOException(SysTranslations.WrongFileChecksum.GetLang(filePathTemp));
        if ( SystemManager.RunShell(filePathTemp, "/SP- /SILENT") != null )
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
        if ( e.Error == null ) return;
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
  /// Provide web client with timeout.
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
      var request = base.GetWebRequest(address);
      request.Timeout = TimeOutSeconds * 1000;
      return request;
    }

  }

}
