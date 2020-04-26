/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-04 </edited>
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Indicate the default Settings instance.
    /// </summary>
    static public readonly Properties.Settings Settings
      = Properties.Settings.Default;

    /// <summary>
    /// Process startup method.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      if ( !SystemHelper.CheckApplicationOnlyOneInstance() ) return;
      bool upgrade = Settings.UpgradeRequired;
      SystemHelper.CheckSettingsUpgrade(Settings, ref upgrade);
      Settings.UpgradeRequired = upgrade;
      CheckSettingsReset();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Globals.Settings = Settings;
      Globals.MainForm = MainForm.Instance;
      Core.Diagnostics.Debugger.Active = Settings.DebuggerEnabled;
      string lang = Settings.Language;
      SystemHelper.CheckCommandLineArguments(args, ref lang);
      Settings.Language = lang;
      UpdateLocalization();
      Application.Run(MainForm.Instance);
    }

    /// <summary>
    /// Check if settings must be reseted to default values.
    /// </summary>
    private static void CheckSettingsReset()
    {
      if ( Settings.UpgradeResetRequiredV3_6 )
      {
        Settings.Reset();
        Settings.UpgradeResetRequiredV3_6 = false;
        Settings.Language = Localizer.Language;
        Settings.Save();
      }
      else
      if ( Settings.FirstLaunchV4 )
      {
        Settings.FirstLaunchV4 = false;
        Settings.FirstLaunch = true;
        Settings.Save();
      }
    }

    /// <summary>
    /// Update localization strings to the whole application.
    /// </summary>
    static internal void UpdateLocalization()
    {
      string lang = "en-US";
      if ( Settings.Language == "fr" ) lang = "fr-FR";
      var culture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      AboutBox.Instance.Hide();
      MainForm.Instance.ClearLists();
      string str = MainForm.Instance.CalendarText.Text;
      Action<Form> update = form =>
      {
        new Infralution.Localization.CultureManager().ManagedControl = form;
        ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
        SystemHelper.ApplyResources(resources, form.Controls);
      };
      foreach ( Form form in Application.OpenForms )
      {
        if ( form != AboutBox.Instance )
          update(form);
        if ( form is ShowTextForm )
          ( (ShowTextForm)form ).RelocalizeText();
      }
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      MainForm.Instance.CreateWebLinks();
      AboutBox.Instance.AboutBox_Shown(null, null);
      MainForm.Instance.CalendarText.Text = str;
      MainForm.Instance.TimerReminder_Tick(null, null);
      UndoRedoTextBox.Relocalize();
    }

  }

}
