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
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide the main program.
  /// </summary>
  static class Program
  {

    /// <summary>
    /// Indicate root folder path of the application.
    /// </summary>
    static public readonly string RootFolderPath
      = Directory.GetParent
        (
          Path.GetDirectoryName(Application.ExecutablePath
                                .Replace("\\Bin\\Debug\\", "\\Bin\\")
                                .Replace("\\Bin\\Release\\", "\\Bin\\"))
        ).FullName
      + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate filename of the application's icon.
    /// </summary>
    static public readonly string IconFilename
      = RootFolderPath + "Application.ico";

    /// <summary>
    /// Indicate name of the help file.
    /// </summary>
    static public readonly string HelpFilename
      = RootFolderPath + "Help" + Path.DirectorySeparatorChar + "index.htm";

    /// <summary>
    /// Indicate user data folder in roaming.
    /// </summary>
    static public string UserDataFolderPath { get; private set; }

    /// <summary>
    /// Indicate user documents folder path.
    /// </summary>
    static public string UserDocumentsFolderPath { get; private set; }

    /// <summary>
    /// Indicate the default Settings instance.
    /// </summary>
    static public readonly Properties.Settings Settings = Properties.Settings.Default;

    /// <summary>
    /// Main entry-point for this application.
    /// </summary>
    /// <param name="args">Array of command-line argument strings.</param>
    [STAThread]
    static void Main(string[] args)
    {
      if ( args.Length == 2 && args[0] == "/lang" )
        try
        {
          // args[1] is like "en-US"
          Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(args[1]);
          Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(args[1]);
        }
        catch
        {
        }
      var assembly = typeof(Program).Assembly;
      var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
      string id = assembly.FullName + attribute.Value;
      bool created;
      var mutex = new Mutex(true, id, out created);
      if ( !created ) return;
      if ( Settings.UpgradeRequired )
      {
        Settings.Upgrade();
        Settings.UpgradeRequired = false;
        Settings.Save();
      }
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      MainForm.Instance.Icon = Icon.ExtractAssociatedIcon(IconFilename);
      NavigationForm.Instance.Icon = MainForm.Instance.Icon;
      CelebrationsForm.Instance.Icon = MainForm.Instance.Icon;
      PreferencesForm.Instance.Icon = MainForm.Instance.Icon;
      AboutBox.Instance.Icon = MainForm.Instance.Icon;
      UserDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                         + Path.DirectorySeparatorChar
                         + AboutBox.Instance.AssemblyCompany
                         + Path.DirectorySeparatorChar
                         + AboutBox.Instance.AssemblyTitle
                         + Path.DirectorySeparatorChar;
      UserDocumentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                              + Path.DirectorySeparatorChar
                              + AboutBox.Instance.AssemblyCompany
                              + Path.DirectorySeparatorChar
                              + AboutBox.Instance.AssemblyTitle
                              + Path.DirectorySeparatorChar;
      Directory.CreateDirectory(UserDataFolderPath);
      Application.Run(MainForm.Instance);
    }

    static public void CheckUpdate(bool auto)
    {
      if ( auto && !Settings.CheckUpdateAtStartup ) return;
      try
      {
        string title = AboutBox.Instance.AssemblyTitle;
        string url = "http://www.ordisoftware.com/files/" + title.Replace(" ", "") + ".update";
        using ( WebClient client = new WebClient() )
        {
          string[] partsVersion = client.DownloadString(url).Split('.');
          var version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]));
          if ( version.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) <= 0 )
          {
            if ( !auto )
              DisplayManager.Show(Translations.CheckUpdateNoNewText.GetLang());
          }
          else
          if ( DisplayManager.QueryYesNo(Translations.CheckUpdateResultText.GetLang() + version + Environment.NewLine +
                                         Environment.NewLine +
                                         Translations.CheckUpdateAskDownloadText.GetLang()) )
            AboutBox.Instance.OpenApplicationHome();
        }
      }
      catch
      {
      }
    }

  }

}
