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
/// <edited> 2021-03 </edited>
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
      try
      {
        Globals.SoftpediaURL = "https://www.softpedia.com/get/Others/Home-Education/Hebrew-Calendar-Olivier-Rogier.shtml";
        Globals.AlternativeToURL = "https://alternativeto.net/software/hebrew-calendar/about/";
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Language lang = Settings.LanguageSelected;
        SystemManager.CheckCommandLineArguments<ApplicationCommandLine>(args, ref lang);
        SystemManager.IPCSendCommands = IPCSendCommands;
        if ( !SystemManager.CheckApplicationOnlyOneInstance(IPCRequests) ) return;
        bool upgrade = Settings.UpgradeRequired;
        Globals.IsSettingsUpgraded = upgrade;
        Settings.CheckUpgradeRequired(ref upgrade);
        Settings.UpgradeRequired = upgrade;
        Globals.IsSettingsUpgraded = Globals.IsSettingsUpgraded && !Settings.FirstLaunch;
        CheckSettingsReset();
        if ( lang != Language.None ) Settings.LanguageSelected = lang;
        Settings.Save();
        Globals.Settings = Settings;
        Globals.MainForm = MainForm.Instance;
        DebugManager.Enabled = Settings.DebuggerEnabled;
        DebugManager.TraceEnabled = Settings.TraceEnabled;
        UpdateLocalization();
        ProcessCommandLineOptions();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      Application.Run(MainForm.Instance);
    }

    /// <summary>
    /// IPC requests.
    /// </summary>
    static void IPCRequests(IAsyncResult ar)
    {
      var server = ar.AsyncState as NamedPipeServerStream;
      try
      {
        server.EndWaitForConnection(ar);
        var command = new BinaryFormatter().Deserialize(server) as string;
        if ( !Globals.IsReady ) return;
        if ( command == nameof(ApplicationCommandLine.Instance.ShowMainForm) )
          MainForm.Instance.SyncUI(() => MainForm.Instance.MenuShowHide_Click(null, null));
        if ( command == nameof(ApplicationCommandLine.Instance.HideMainForm) )
          MainForm.Instance.SyncUI(() =>
          {
            if ( MainForm.Instance.Visible )
            {
              if ( MainForm.Instance.WindowState == FormWindowState.Minimized )
                MainForm.Instance.MenuShowHide.PerformClick();
              MainForm.Instance.MenuShowHide.PerformClick();
            }
          });
        if ( command == nameof(ApplicationCommandLine.Instance.OpenNavigation) )
          MainForm.Instance.SyncUI(() => MainForm.Instance.ActionNavigate.PerformClick());
        if ( command == nameof(ApplicationCommandLine.Instance.OpenDiffDates) )
          MainForm.Instance.SyncUI(() => MainForm.Instance.ActionCalculateDateDiff.PerformClick());
        if ( command == nameof(ApplicationCommandLine.Instance.OpenCelebrationsBoard) )
          MainForm.Instance.SyncUI(() => MainForm.Instance.ActionViewCelebrationsBoard.PerformClick());
        if ( command == nameof(ApplicationCommandLine.Instance.OpenNewMoonsBoard) )
          MainForm.Instance.SyncUI(() => MainForm.Instance.ActionViewNewMoonsBoard.PerformClick());
        // TODO enable when ready and update keys and faq
        //if ( command == nameof(ApplicationCommandLine.Instance.OpenLunarMonthsBoard) )
        //MainForm.Instance.SyncUI(() => MainForm.Instance.ActionViewLunarMonths.PerformClick());
        if ( command == nameof(ApplicationCommandLine.Instance.OpenParashotBoard) )
          MainForm.Instance.SyncUI(() => MainForm.Instance.ActionViewParashot.PerformClick());
      }
      finally
      {
        server.Close();
        if ( Globals.IsReady )
          SystemManager.CreateIPCServer(IPCRequests);
      }
    }

    /// <summary>
    /// Send IPC commands.
    /// </summary>
    static private void IPCSendCommands()
    {
      if ( ApplicationCommandLine.Instance.HideMainForm )
        SystemManager.IPCSend(nameof(ApplicationCommandLine.Instance.HideMainForm));
      if ( ApplicationCommandLine.Instance.ShowMainForm )
        SystemManager.IPCSend(nameof(ApplicationCommandLine.Instance.ShowMainForm));
      if ( ApplicationCommandLine.Instance.OpenNavigation )
        SystemManager.IPCSend(nameof(ApplicationCommandLine.Instance.OpenNavigation));
      if ( ApplicationCommandLine.Instance.OpenDiffDates )
        SystemManager.IPCSend(nameof(ApplicationCommandLine.Instance.OpenDiffDates));
      if ( ApplicationCommandLine.Instance.OpenCelebrationsBoard )
        SystemManager.IPCSend(nameof(ApplicationCommandLine.Instance.OpenCelebrationsBoard));
      // TODO enable when ready and update keys and faq
      //if ( ApplicationCommandLine.Instance.OpenLunarMonthsBoard )
      //SystemManager.IPCSend(nameof(ApplicationCommandLine.Instance.OpenLunarMonthsBoard));
      if ( ApplicationCommandLine.Instance.OpenNewMoonsBoard )
        SystemManager.IPCSend(nameof(ApplicationCommandLine.Instance.OpenNewMoonsBoard));
      if ( ApplicationCommandLine.Instance.OpenParashotBoard )
        SystemManager.IPCSend(nameof(ApplicationCommandLine.Instance.OpenParashotBoard));
    }

    /// <summary>
    /// Check if settings must be reseted.
    /// </summary>
    private static void CheckSettingsReset(bool force = false)
    {
      try
      {
        if ( force
          || Settings.UpgradeResetRequiredV3_0
          || Settings.UpgradeResetRequiredV3_6
          || Settings.UpgradeResetRequiredV4_1
          || Settings.UpgradeResetRequiredV5_10 )
        {
          if ( !force && !Settings.FirstLaunch )
            DisplayManager.ShowInformation(SysTranslations.UpgradeResetRequired.GetLang());
          Settings.Reset();
          Settings.LanguageSelected = Languages.Current;
          Settings.SetUpgradeFlagsOff();
        }
        if ( Settings.FirstLaunchV4 )
        {
          Settings.SetFirstAndUpgradeFlagsOff();
          Settings.FirstLaunch = true;
        }
        if ( Settings.UpgradeResetRequiredV5_10 )
          Settings.CurrentView = ViewMode.Month;
        if ( Settings.LanguageSelected == Language.None )
          Settings.LanguageSelected = Languages.Current;
        Settings.Save();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Process command line options.
    /// </summary>
    static private void ProcessCommandLineOptions()
    {
      try
      {
        if ( SystemManager.CommandLineOptions == null ) return;
        if ( SystemManager.CommandLineOptions.ResetSettings )
        {
          SystemManager.CleanAllLocalAppSettingsFolders();
          CheckSettingsReset(true);
        }
        else
        if ( !Settings.FirstLaunch
          && SystemManager.CommandLineOptions != null
          && SystemManager.CommandLineOptions.HideMainForm )
          Globals.ForceStartupHide = true;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Update localization strings to the whole application.
    /// </summary>
    static public void UpdateLocalization()
    {
      try
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
        string tempTextReport = MainForm.Instance.CalendarText.Text;
        string tempLogTitle = DebugManager.TraceForm.Text;
        string tempLogContent = DebugManager.TraceForm.TextBox.Text;
        MainForm.Instance.EditEnumsAsTranslations.Visible = false;
        MainForm.Instance.EditEnumsAsTranslations.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        update(MainForm.Instance);
        new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = DebugManager.TraceForm;
        new Infralution.Localization.CultureManager().ManagedControl = StatisticsForm.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
        new Infralution.Localization.CultureManager().ManagedControl = NextCelebrationsForm.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = CelebrationsBoardForm.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = NewMoonsBoardForm.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = ParashotForm.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = LunarMonthsForm.Instance;
        new Infralution.Localization.CultureManager().ManagedControl = DatesDiffCalculatorForm.Instance;
        Infralution.Localization.CultureManager.ApplicationUICulture = culture;
        foreach ( Form form in Application.OpenForms )
        {
          if ( form != AboutBox.Instance && form != GrammarGuideForm )
            update(form);
          if ( form is ShowTextForm formShowText )
            formShowText.Relocalize();
        }
        // Various updates
        DebugManager.TraceForm.Text = tempLogTitle;
        DebugManager.TraceForm.AppendText(tempLogContent);
        LoadingForm.Instance.Relocalize();
        TextBoxEx.Relocalize();
        AboutBox.Instance.AboutBox_Shown(null, null);
        GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
        LunarMonthsForm.Instance.Relocalize();
        NavigationForm.Instance.Relocalize();
        DatesDiffCalculatorForm.Instance.Relocalize();
        ParashotTable.LoadDefaults();
        MainForm.Instance.CreateSystemInformationMenu();
        MainForm.Instance.CalendarText.Text = tempTextReport;
        MainForm.Instance.CalendarMonth._btnToday.ButtonText = AppTranslations.Today.GetLang();
        MainForm.Instance.DoTimerReminder();
        MainForm.Instance.EditEnumsAsTranslations.Left = MainForm.Instance.PanelViewGrid.Width - MainForm.Instance.EditEnumsAsTranslations.Width - 5;
        MainForm.Instance.EditEnumsAsTranslations.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        MainForm.Instance.EditEnumsAsTranslations.Visible = true;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}
