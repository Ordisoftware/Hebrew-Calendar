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
/// <edited> 2019-01 </edited>
using System;
using System.IO;
using System.Drawing;
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
    /// Indicate filepath of application.
    /// </summary>
    static public readonly string RootPath
      = Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath.Replace("\\Bin\\Debug\\", "\\Bin\\").Replace("\\Bin\\Release\\", "\\Bin\\"))).FullName + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate filename of the application's icon.
    /// </summary>
    static public readonly string IconFilename = RootPath + "Application.ico";

    /// <summary>
    /// Indicate filename of the help file.
    /// </summary>
    static public readonly string HelpFilename
      = RootPath
      + "Help" + Path.DirectorySeparatorChar
      + "index.htm";

    /// <summary>
    /// Indicate the default Settings instance.
    /// </summary>
    static public readonly Properties.Settings Settings = Properties.Settings.Default;

    /// <summary>
    /// Indicate user data folder in roaming.
    /// </summary>
    static public string UserDataFolder { get; private set; }

    /// <summary>
    /// Main entry-point for this application.
    /// </summary>
    /// <param name="args">Array of command-line argument strings.</param>
    [STAThread]
    static void Main(string[] args)
    {
      //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
      //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
      try
      {
        var assembly = typeof(Program).Assembly;
        var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
        string id = "Hebrew Calendar " + attribute.Value;
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
        UserDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                       + Path.DirectorySeparatorChar + AboutBox.Instance.CompanyName
                       + Path.DirectorySeparatorChar + AboutBox.Instance.AssemblyTitle
                       + Path.DirectorySeparatorChar;
        Directory.CreateDirectory(UserDataFolder);
        Application.Run(MainForm.Instance);
      }
      catch ( Exception except )
      {
        except.Manage();
      }
    }

  }

}
