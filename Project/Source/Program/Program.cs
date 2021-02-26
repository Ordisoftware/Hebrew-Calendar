/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-02 </edited>
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO.Pipes;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Process startup method.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Globals.SoftpediaURL = "https://www.softpedia.com/get/Others/Home-Education/Hebrew-Calendar-Olivier-Rogier.shtml";
      Globals.AlternativeToURL = "https://alternativeto.net/software/hebrew-calendar/about/";
      if ( !SystemManager.CheckApplicationOnlyOneInstance(IPCRequest) ) return;
      bool upgrade = Settings.UpgradeRequired;
      Globals.SettingsUpgraded = upgrade;
      Settings.CheckUpgradeRequired(ref upgrade);
      Settings.UpgradeRequired = upgrade;
      CheckSettingsReset();
      Globals.Settings = Settings;
      Globals.MainForm = MainForm.Instance;
      DebugManager.Enabled = Settings.DebuggerEnabled;
      DebugManager.TraceEnabled = Settings.TraceEnabled;
      Language lang = Settings.LanguageSelected;
      SystemManager.CheckCommandLineArguments<ApplicationCommandLine>(args, ref lang);
      Settings.LanguageSelected = lang;
      UpdateLocalization();
      ProcessCommandLineOptions();
      Application.Run(MainForm.Instance);
    }

    /// <summary>
    /// Bring to front the app in case of duplicate process start.
    /// </summary>
    /// <param name="ar"></param>
    static void IPCRequest(IAsyncResult ar)
    {
      var server = ar.AsyncState as NamedPipeServerStream;
      server.EndWaitForConnection(ar);
      var command = new BinaryFormatter().Deserialize(server) as string;
      if ( command == "BringToFront" )
        MainForm.Instance.SyncUI(() => MainForm.Instance.MenuShowHide_Click(null, null));
      server.Close();
      SystemManager.CreateIPCServer(IPCRequest);
    }

    /// <summary>
    /// Check if settings must be reseted.
    /// </summary>
    private static void CheckSettingsReset(bool force = false)
    {
      if ( force
        || Settings.UpgradeResetRequiredV3_0
        || Settings.UpgradeResetRequiredV3_6
        || Settings.UpgradeResetRequiredV4_1 )
      {
        if ( !force && !Settings.FirstLaunch )
          DisplayManager.ShowInformation(SysTranslations.UpgradeResetRequired.GetLang());
        Settings.Reset();
        Settings.LanguageSelected = Languages.Current;
        Settings.SetUpgradeFlagsOff();
      }
      if ( Settings.FirstLaunchV4 || Settings.FirstLaunchV7_0 )
        Settings.FirstLaunch = true;
      if ( Settings.UpgradeResetRequiredV5_10 )
        Settings.CurrentView = ViewMode.Month;
      if ( Settings.LanguageSelected == Language.None )
        Settings.LanguageSelected = Languages.Current;
      Settings.Save();
    }

    /// <summary>
    /// Process command line options.
    /// </summary>
    static private void ProcessCommandLineOptions()
    {
      if ( SystemManager.CommandLineOptions != null )
        if ( SystemManager.CommandLineOptions.ResetSettings )
        {
          SystemManager.CleanAllLocalAppSettingsFolders();
          CheckSettingsReset(true);
        }
        else
        if ( !Settings.FirstLaunch
          && SystemManager.CommandLineOptions != null
          && SystemManager.CommandLineOptions.HideGUI )
          Globals.ForceStartupHide = true;
    }

    /// <summary>
    /// Update localization strings to the whole application.
    /// </summary>
    static public void UpdateLocalization()
    {
      void update(Form form)
      {
        new Infralution.Localization.CultureManager().ManagedControl = form;
        ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
        resources.Apply(form.Controls);
      }
      string lang = "en-US";
      if ( Settings.LanguageSelected == Language.FR ) lang = "fr-FR";
      var culture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      MessageBoxEx.CloseAll();
      AboutBox.Instance.Hide();
      MainForm.Instance.ClearLists();
      string str = MainForm.Instance.CalendarText.Text;
      update(Globals.MainForm);
      string tempLogTitle = DebugManager.TraceForm.Text;
      string tempLogContent = DebugManager.TraceForm.TextBox.Text;
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = NextCelebrationsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = LunarMonthsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = ParashotForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = DatesDiffCalculatorForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = StatisticsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = DebugManager.TraceForm;
      new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      foreach ( Form form in Application.OpenForms )
      {
        if ( form != Globals.MainForm && form != AboutBox.Instance && form != GrammarGuideForm )
          update(form);
        if ( form is ShowTextForm formShowText )
          formShowText.RelocalizeText();
      }
      // Various updates
      DebugManager.TraceForm.Text = tempLogTitle;
      DebugManager.TraceForm.AppendText(tempLogContent);
      AboutBox.Instance.AboutBox_Shown(null, null);
      GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
      LoadingForm.Instance.Relocalize();
      UndoRedoTextBox.Relocalize();
      LunarMonthsForm.Instance.Relocalize();
      NavigationForm.Instance.Relocalize();
      DatesDiffCalculatorForm.Instance.Relocalize();
      ParashotTable.LoadDefaults();
      MainForm.Instance.CreateSystemInformationMenu();
      MainForm.Instance.CalendarText.Text = str;
      MainForm.Instance.CalendarMonth._btnToday.ButtonText = AppTranslations.Today.GetLang();
      MainForm.Instance.DoTimerReminder();
    }

  }

}
