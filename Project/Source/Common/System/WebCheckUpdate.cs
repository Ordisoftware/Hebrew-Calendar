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
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide web check update.
  /// </summary>
  static class WebCheckUpdate
  {

    /// <summary>
    /// Check if an update is available online and offer to install, download or open product web page.
    /// App version is "MAJOR.MINOR".
    /// </summary>
    /// <param name="checkAtStartup"></param>
    /// <param name="auto">True if no user interaction else false</param>
    /// <returns>True if application must exist else false.</returns>
    static public bool Run(bool checkAtStartup, bool auto)
    {
      if ( auto && !checkAtStartup ) return false;
      try
      {
        foreach ( string s in Directory.GetFiles(Path.GetTempPath(), Globals.SetupFilename.Replace("%VER%", "*")) )
          try { File.Delete(s); }
          catch { }
        using ( WebClient client = new WebClient() )
        {
          string[] content = client.DownloadString(Globals.CheckUpdateURL).Split(Environment.NewLine.ToCharArray(),
                                                   StringSplitOptions.RemoveEmptyEntries);
          string[] partsVersion = content[0].Split('.');
          string filename = Globals.SetupFileURL.Replace("%VER%", content[0]);
          var version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]));
          if ( version.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) <= 0 )
          {
            if ( !auto )
              DisplayManager.Show(Globals.NoNewVersionAvailable.GetLang());
          }
          else
          {
            var form = new WebUpdateForm(Globals.NewVersionAvailable.GetLang(version));
            if ( form.ShowDialog() != DialogResult.OK ) return false;
            if ( form.SelectDownload.Checked )
              Shell.OpenWebLink(filename);
            else
            if ( form.SelectOpenWebPage.Checked )
              Shell.OpenWebLink(Globals.ApplicationHomeURL);
            else
            if ( form.SelectInstall.Checked )
            {
              bool finished = false;
              string tempfile = Path.GetTempPath() + Globals.SetupFilename.Replace("%VER%", content[0]);
              var LoadingForm = new LoadingForm();
              LoadingForm.Show();
              client.DownloadProgressChanged += (sender, e) =>
              {
                LoadingForm.UpdateProgress(e.ProgressPercentage, 100, Globals.DownloadingNewVersion.GetLang());
              };
              client.DownloadFileCompleted += (sender, e) =>
              {
                LoadingForm.Hide();
                finished = true;
              };
              client.DownloadFileAsync(new Uri(filename), tempfile);
              while ( !finished )
              {
                Thread.Sleep(100);
                Application.DoEvents();
              }
              Shell.Run(tempfile, "/SP- /SILENT");
              Globals.IsExiting = true;
              Application.Exit();
              return true;
            }
          }
        }
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowAdvert(DisplayManager.Title + " Check Update", ex.Message);
      }
      return false;
    }

  }

}
