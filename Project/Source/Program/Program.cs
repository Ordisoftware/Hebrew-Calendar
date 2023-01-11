/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Provides Program class.
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
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      //
      Globals.ChronoStartingApp.Start();
      Globals.SoftpediaURL = "https://www.softpedia.com/get/Others/Home-Education/Hebrew-Calendar-Olivier-Rogier.shtml";
      Globals.AlternativeToURL = "https://alternativeto.net/software/hebrew-calendar/about/";
      CommonMenusControl.PreviewFunctions = AppTranslations.PreviewFunctions;
      //
      var lang = Settings.LanguageSelected;
      SystemManager.CheckCommandLineArguments<ApplicationCommandLine>(args, ref lang);
      if ( !SystemManager.CheckApplicationOnlyOneInstance(IPCRequests) ) return;
      bool upgrade = Settings.UpgradeRequired;
      Globals.IsSettingsUpgraded = upgrade;
      Settings.CheckUpgradeRequired(ref upgrade);
      Settings.UpgradeRequired = upgrade;
      Globals.IsSettingsUpgraded = Globals.IsSettingsUpgraded && !Settings.FirstLaunch;
      CheckSettingsReset();
      if ( lang != Language.None ) Settings.LanguageSelected = lang;
      SystemManager.TryCatch(Settings.Save);
      Globals.Settings = Settings;
      //
      //Globals.SpellCheckEnabled = Settings.SpellCheckEnabled;
      //TextBoxEx.InstanceCreated += TextBox_UpdateSpellChecker;
      //TextBoxEx.UpdateSpellChecker += TextBox_UpdateSpellChecker;
      //TextBoxEx.Relocalized += TextBox_Relocalized;
      //TextBox_Relocalized();
      Globals.MainForm = MainForm.Instance;
      DebugManager.TraceEnabled = Settings.TraceEnabled;
      DebugManager.Enabled = Settings.DebuggerEnabled;
      //
      HebrewGlobals.GetHebrewCalendarExePath = () => Globals.ApplicationExeFullPath;
      HebrewGlobals.GetHebrewLettersExePath = () => Settings.HebrewLettersExe;
      HebrewGlobals.GetHebrewWordsExePath = () => Settings.HebrewWordsExe;
      HebrewGlobals.GetCustomWebSearchPattern = () => Settings.CustomWebSearch;
      //
      Globals.ChronoStartingApp.Stop();
      ProcessCommandLineOptions();
      Globals.ChronoStartingApp.Start();
      LoadingForm.Instance.Hidden = Settings.LoadingFormHidden;
      AboutBox.LicenseAsRTF = Properties.Resources.MPL_2_0;
      AboutBox.DescriptionText = AppTranslations.ApplicationDescription;
      AboutBox.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    Application.Run(MainForm.Instance);
    SystemManager.Exit();
  }

  /// <summary>
  /// Checks if settings must be reseted.
  /// </summary>
  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "N/A")]
  private static void CheckSettingsReset(bool force = false)
  {
    var resetForceVersions = new bool[]
    {
      Settings.UpgradeResetRequiredV3_0,
      Settings.UpgradeResetRequiredV3_6,
      Settings.UpgradeResetRequiredV4_1,
      Settings.UpgradeResetRequiredV5_10
    };
    try
    {
      // Check reset
      if ( force || resetForceVersions.Contains(true) )
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
      // Check language
      if ( Settings.LanguageSelected == Language.None )
        Settings.LanguageSelected = Languages.Current;
      // Updates
      if ( Settings.UpgradeResetRequiredV5_10 )
        Settings.CurrentView = ViewMode.Month;
      if ( Settings.FirstLaunchV10_1 && !Settings.FirstLaunch )
        if ( Settings.TorahEventsCountAsMoon )
          Settings.MonthViewLayoutEphemerisMoonEnabled = true;
        else
          Settings.MonthViewLayoutEphemerisSunEnabled = true;
      // Check OS
      if ( Settings.FirstLaunch && SystemStatistics.Instance.Platform.Contains("Windows 7") )
        Settings.NavigationWindowUseUnicodeIcons = false;
      // Check applications
      string pathLettersFolder = Path.Combine(Globals.CompanyProgramFilesFolderPath, "Hebrew Letters", "Bin");
      string pathWordsFolder = Path.Combine(Globals.CompanyProgramFilesFolderPath, "Hebrew Words", "Bin");
      string pathLettersOld = Path.Combine(pathLettersFolder, "Ordisoftware.HebrewLetters.exe");
      string pathWordsOld = Path.Combine(pathWordsFolder, "Ordisoftware.HebrewWords.exe");
      string pathLettersDefault = (string)Settings.Properties["HebrewLettersExe"].DefaultValue;
      string pathWordsDefault = (string)Settings.Properties["HebrewWordsExe"].DefaultValue;
      // Check applications : Letters
      if ( !File.Exists(Settings.HebrewLettersExe) )
        if ( File.Exists(pathLettersOld) )
          Settings.HebrewLettersExe = pathLettersOld;
        else
        if ( File.Exists(pathLettersDefault) )
          Settings.HebrewLettersExe = pathLettersDefault;
      // Check applications : Words
      if ( !File.Exists(Settings.HebrewWordsExe) )
        if ( File.Exists(pathWordsOld) )
          Settings.HebrewWordsExe = pathWordsOld;
        else
        if ( File.Exists(pathWordsDefault) )
          Settings.HebrewWordsExe = pathWordsDefault;
      // Save settings
      CheckPreviewNotice();
      SystemManager.TryCatch(Settings.Save);
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

  /// <summary>
  /// Checks if the app is in preview mode or not and display a notice if needed.
  /// </summary>
  static internal void CheckPreviewNotice()
  {
    if ( CommonMenusControl.PreviewFunctions is null ) return;
    if ( !SystemManager.CommandLineOptions.IsPreviewEnabled || Settings.PreviewModeNotified ) return;
    string msg = SysTranslations.AskForPreviewMode.GetLang(CommonMenusControl.PreviewFunctions[Languages.Current]);
    if ( !DisplayManager.QueryYesNo(msg) )
    {
      SystemManager.CommandLineOptions.WithPreview = false;
      SystemManager.CommandLineOptions.NoPreview = true;
    }
    Settings.PreviewModeNotified = true;
  }

  /// <summary>
  /// IPC requests.
  /// </summary>
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  [SuppressMessage("Vulnerability", "SEC0029:Insecure Deserialization", Justification = "N/A")]
  static void IPCRequests(IAsyncResult ar)
  {
    var server = ar.AsyncState as NamedPipeServerStream;
    try
    {
      server.EndWaitForConnection(ar);
      using var reader = new BinaryReader(server);
      string command = reader.ReadString();
      if ( command is null ) return;
      if ( !Globals.IsReady ) return;
      var lang = Settings.LanguageSelected;
      SystemManager.CheckCommandLineArguments<ApplicationCommandLine>(command.SplitKeepEmptyLines(" "), ref lang);
      var form = MainForm.Instance;
      var cmd = ApplicationCommandLine.Instance;
      if ( cmd is null ) return;
      Action action = null;
      if ( cmd.ShowMainForm ) action = () => form.MenuShowHide_Click(null, null);
      if ( cmd.HideMainForm ) action = form.ForceHideToTray;
      if ( cmd.Generate ) action = form.ActionGenerate.PerformClick;
      if ( cmd.ResetReminder ) action = form.ActionResetReminder.PerformClick;
      if ( cmd.OpenNavigation ) action = form.ActionNavigate.PerformClick;
      if ( cmd.OpenDiffDates ) action = form.ActionCalculateDateDiff.PerformClick;
      if ( cmd.OpenCelebrationVersesBoard ) action = form.ActionShowCelebrationVersesBoard.PerformClick;
      if ( cmd.OpenCelebrationsBoard ) action = form.ActionShowCelebrationsBoard.PerformClick;
      if ( cmd.OpenNewMoonsBoard ) action = form.ActionShowNewMoonsBoard.PerformClick;
      if ( cmd.OpenParashotBoard ) action = form.ActionShowParashotBoard.PerformClick;
      if ( cmd.OpenWeeklyParashahBox ) action = form.ActionWeeklyParashahDescription.PerformClick;
      // TODO when ready : update
      if ( cmd.OpenLunarMonthsBoard ) action = SystemManager.CommandLineOptions.IsPreviewEnabled
                                               ? form.ActionShowLunarMonths.PerformClick
                                               : null;
      if ( action is not null ) SystemManager.TryCatch(() => form.ToolStrip.SyncUI(action));
    }
    finally
    {
      server.Close();
      SystemManager.CreateIPCServer(IPCRequests);
    }
  }

  /// <summary>
  /// Processes command line options.
  /// </summary>
  static private void ProcessCommandLineOptions()
  {
    try
    {
      if ( SystemManager.CommandLineOptions is null ) return;
      if ( SystemManager.CommandLineOptions.ResetSettings )
      {
        SystemManager.CleanAllLocalAppSettingsFolders();
        CheckSettingsReset(true);
      }
      else
      if ( !Settings.FirstLaunch && SystemManager.CommandLineOptions?.HideMainForm == true )
        Globals.ForceStartupHide = true;
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

  /// <summary>
  /// Updates localization strings to the whole application.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "<En attente>")]
  static public void UpdateLocalization()
  {
    Globals.ChronoTranslate.Restart();
    Task task = null;
    try
    {
      static void update(Form form)
      {
        new Infralution.Localization.CultureManager().ManagedControl = form;
        var resources = new ComponentResourceManager(form.GetType());
        resources.ApplyResources(form.Controls);
      }
      string lang = "en-US";
      if ( Settings.LanguageSelected == Language.FR ) lang = "fr-FR";
      var culture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      task = new Task(HebrewGlobals.LoadProviders);
      task.Start();
      if ( Globals.IsReady )
      {
        MessageBoxEx.CloseAll();
        AboutBox.Instance.Hide();
        MainForm.Instance.ClearLists();
      }
      else
        update(MainForm.Instance);
      new Infralution.Localization.CultureManager().ManagedControl = StatisticsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = TranscriptionGuideForm;
      new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
      new Infralution.Localization.CultureManager().ManagedControl = NextCelebrationsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = CelebrationsBoardForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = CelebrationVersesBoardForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = NewMoonsBoardForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = ParashotForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = LunarMonthsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = DatesDiffCalculatorForm.Instance;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      var formsToSkip = new Form[] { DebugManager.TraceForm, AboutBox.Instance, GrammarGuideForm };
      foreach ( Form form in Application.OpenForms.GetAll().Except(formsToSkip) )
      {
        update(form);
        if ( form is ShowTextForm formShowText )
          formShowText.Relocalize();
      }
      // Various updates
      if ( Globals.IsReady )
      {
        LoadingForm.Instance.Relocalize();
        TextBoxEx.Relocalize();
        AboutBox.Instance.AboutBox_Shown(null, null);
        TranscriptionGuideForm.HTMLBrowserForm_Shown(null, null);
        GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
        LunarMonthsForm.Instance.Relocalize();
        NavigationForm.Instance.Relocalize();
        ParashotFactory.Instance.Reset();
        DatesDiffCalculatorForm.Instance.Relocalize();
        SystemManager.TryCatchManage(ShowExceptionMode.OnlyMessage,
                                     () => MainForm.Instance.LoadMenuBookmarks(MainForm.Instance));
      }
      MainForm.Instance.MonthlyCalendar._btnToday.ButtonText = AppTranslations.Today.GetLang();
      task?.Wait();
      MainForm.Instance.CreateSystemInformationMenu();
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      Globals.ChronoTranslate.Stop();
      Settings.BenchmarkTranslate = Globals.ChronoTranslate.ElapsedMilliseconds;
    }
  }

}
