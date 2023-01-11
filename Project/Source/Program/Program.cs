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
/// <edited> 2023-01 </edited>
namespace Ordisoftware.Hebrew.Calendar;

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
      //
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
      bool previewModeNotified = Settings.PreviewModeNotified;
      SystemCommandLine.CheckPreviewNotice(ref previewModeNotified);
      Settings.PreviewModeNotified = previewModeNotified;
      SystemManager.TryCatch(Settings.Save);
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

}
