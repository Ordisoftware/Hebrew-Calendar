/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
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
      string filenameIcon = ".." + Path.DirectorySeparatorChar + "Application.ico";
      try
      {
        if ( Settings.UpgradeRequired )
        {
          Settings.Upgrade();
          Settings.UpgradeRequired = false;
          Settings.Save();
        }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        MainForm.Instance.Icon = Icon.ExtractAssociatedIcon(filenameIcon);
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
