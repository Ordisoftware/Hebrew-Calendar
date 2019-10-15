/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-09 </edited>
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  static partial class Program
  {

    static public void CheckUpdate(bool auto)
    {
      if ( auto && !Settings.CheckUpdateAtStartup ) return;
      try
      {
        using ( WebClient client = new WebClient() )
        {
          string[] partsVersion = client.DownloadString(CheckUpdateURL).Split('.');
          var version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]));
          if ( version.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) <= 0 )
          {
            if ( !auto )
              DisplayManager.Show(Translations.NoNewVersionAvailable.GetLang());
          }
          else
          if ( DisplayManager.QueryYesNo(Translations.NewVersionAvailable.GetLang(version) + Environment.NewLine +
                                         Environment.NewLine +
                                         Translations.AskDownloadNewVersion.GetLang()) )
            SystemManager.OpenWebLink(DownloadApplicationURL);
        }
      }
      catch
      {
      }
    }

    static public void RunShell(string filename, string arguments = "")
    {
      using ( var process = new Process() )
        try
        {
          process.StartInfo.FileName = filename;
          process.StartInfo.Arguments = arguments;
          process.Start();
        }
        catch ( Exception ex )
        {
          DisplayManager.ShowError(ex.Message + Environment.NewLine + Environment.NewLine + 
                                   process.StartInfo.FileName);
        }
    }

    [DllImport("user32.dll")]
    static public extern bool HideCaret(IntPtr hWnd);

    static public void CenterToMainForm(this Form form)
    {
      form.Location = new Point(MainForm.Instance.Left + MainForm.Instance.Width / 2 - form.Width / 2,
                                MainForm.Instance.Top + MainForm.Instance.Height / 2 - form.Height / 2);
    }

  }

}
