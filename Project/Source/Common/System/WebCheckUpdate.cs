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
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide web check update.
  /// </summary>
  static class WebCheckUpdate
  {
    static public int DefaultCheckDaysInterval = 7;

    static private bool Mutex;

    /// <summary>
    /// Check if an update is available online and offer to install, download or open product web page.
    /// App version is "MAJOR.MINOR".
    /// </summary>
    /// <param name="checkAtStartup"></param>
    /// <param name="lastdone">The last done date.</param>
    /// <param name="auto">True if no user interaction else false</param>
    /// <returns>True if application must exist else false.</returns>
    static public bool Run(bool checkAtStartup, ref DateTime lastdone, bool auto)
    {
      if ( Mutex ) return false;
      if ( auto && !checkAtStartup ) return false;
      if ( auto && lastdone.AddDays(DefaultCheckDaysInterval) >= DateTime.Now ) return false;
      bool formEnabled = Globals.MainForm?.Enabled ?? false;
      try
      {
        Mutex = true;
        if ( Globals.MainForm != null ) Globals.MainForm.Enabled = false;
        LoadingForm.Instance.Initialize(Localizer.WebCheckUpdate.GetLang(), 3, 0, false);
        var files = Directory.GetFiles(Path.GetTempPath(), string.Format(Globals.SetupFilename, "*"));
        foreach ( string s in files ) SystemHelper.TryCatch(() => File.Delete(s));
        LoadingForm.Instance.DoProgress();
        using ( WebClient client = new WebClient() )
        {
          var version = GetVersion(client);
          lastdone = DateTime.Now;
          LoadingForm.Instance.DoProgress();
          if ( version.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) > 0 )
            return ProcessDownload(client, version);
          else
            if ( !auto )
            DisplayManager.ShowInformation(Localizer.NoNewVersionAvailable.GetLang());
        }
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowWarning(DisplayManager.Title + " Check Update", ex.Message);
      }
      finally
      {
        LoadingForm.Instance.Hide();
        if ( Globals.MainForm != null ) Globals.MainForm.Enabled = formEnabled;
        Mutex = false;
      }
      return false;
    }

    /// <summary>
    /// Get the version available online.
    /// </summary>
    static private Version GetVersion(WebClient client)
    {
      string content = client.DownloadString(Globals.CheckUpdateURL);
      string[] lines = content.Split(StringSplitOptions.RemoveEmptyEntries);
      LoadingForm.Instance.DoProgress();
      if ( lines.Length == 0 ) throw new WebException(Localizer.CheckUpdateFileError.GetLang());
      string[] partsVersion = lines[0].Split('.');
      Version version;
      try
      {
        switch ( partsVersion.Length )
        {
          case 2:
            version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]));
            break;
          case 3:
            version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]), Convert.ToInt32(partsVersion[2]));
            break;
          default:
            throw new ArgumentException(Localizer.CheckUpdateFileError.GetLang(content));
        }
      }
      catch ( Exception ex )
      {
        throw new WebException(Localizer.CheckUpdateFileError.GetLang(lines[0]) + Globals.NL2 + ex.Message);
      }
      return version;
    }

    /// <summary>
    /// Process the manual download.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    static private bool ProcessDownload(WebClient client, Version version)
    {
      string filename = string.Format(Globals.SetupFileURL, version.ToString());
      var result = WebUpdateForm.Run(version);
      switch ( result )
      {
        case WebUpdateSelection.None:
          break;
        case WebUpdateSelection.Download:
          Shell.OpenWebLink(filename);
          break;
        case WebUpdateSelection.Install:
          return ProcessAutoInstall(client, version, filename);
        default:
          throw new NotImplementedExceptionEx(result.ToStringFull());
      }
      return false;
    }

    /// <summary>
    /// Process the automatic download and installation.
    /// </summary>
    static private bool ProcessAutoInstall(WebClient client, Version version, string filename)
    {
      LoadingForm.Instance.Initialize(Localizer.DownloadingNewVersion.GetLang(), 100, 0, false);
      bool finished = false;
      Exception ex = null;
      string tempfile = Path.GetTempPath() + string.Format(Globals.SetupFilename, version.ToString());
      client.DownloadProgressChanged += downloadProgressChanged;
      client.DownloadFileCompleted += downloadFileCompleted;
      client.DownloadFileAsync(new Uri(filename), tempfile);
      while ( !finished )
      {
        Thread.Sleep(100);
        Application.DoEvents();
      }
      if ( ex != null ) throw ex;
      Shell.Run(tempfile, "/SP- /SILENT");
      Globals.IsExiting = true;
      Application.Exit();
      return true;
      void downloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
      {
        LoadingForm.Instance.SetProgress(e.ProgressPercentage);
      }
      void downloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
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
                              filename + Globals.NL2 +
                              status.ToStringFull() + Globals.NL +
                              code.ToStringFull());
      }
    }

  }

}
