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
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  static partial class Program
  {

    static private Mutex Mutex;

    static private bool CheckApplicationOnlyOneInstance()
    {
      var assembly = typeof(Program).Assembly;
      var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
      string id = assembly.FullName + attribute.Value;
      bool created;
      Mutex = new Mutex(true, id, out created);
      return created;
    }

    static private void CheckSettingsUpgrade()
    {
      if ( Settings.UpgradeRequired )
      {
        Settings.Upgrade();
        Settings.UpgradeRequired = false;
        Settings.Save();
      }
    }

    static private void CheckCommandLineArguments(string[] args)
    {
      try
      {
        if ( args.Length == 2 && args[0] == "/lang" )
          if ( args[1] == "en" || args[1] == "fr" )
            Settings.Language = args[1];
        if ( Settings.Language == "" )
          Settings.Language = Localizer.Language;
        Settings.Save();
      }
      catch
      {
      }
    }

    static internal void ApplyCurrentLanguage()
    {
      string lang = "en-US";
      if ( Settings.Language == "fr" ) lang = "fr-FR";
      var culture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      string str = MainForm.Instance.CalendarText.Text;
      foreach ( var f in ReminderForm.Forms.ToList() ) f.Close();
      if ( ReminderForm.ShabatForm != null )
      {
        ReminderForm.ShabatForm.Close();
        ReminderForm.ShabatForm = null;
      }
      foreach ( Form form in Application.OpenForms )
        if ( form != AboutBox.Instance )
        {
          new Infralution.Localization.CultureManager().ManagedControl = form;
          ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
          ApplyResources(resources, form.Controls);
        }
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      AboutBox.Instance.AboutBox_Shown(null, null);
      MainForm.Instance.CalendarText.Text = str;
    }

    static private void ApplyResources(ComponentResourceManager resources, Control.ControlCollection controls)
    {
      foreach ( Control control in controls )
      {
        if ( control is Label ) resources.ApplyResources(control, control.Name);
        ApplyResources(resources, control.Controls);
      }
    }

    static private void SetFormsIcon()
    {
      MainForm.Instance.Icon = Icon.ExtractAssociatedIcon(IconFilename);
      NavigationForm.Instance.Icon = MainForm.Instance.Icon;
      CelebrationsForm.Instance.Icon = MainForm.Instance.Icon;
      AboutBox.Instance.Icon = MainForm.Instance.Icon;
    }

    static private void InitializeUserFolders()
    {
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
      Directory.CreateDirectory(UserDocumentsFolderPath);
    }

  }

}
