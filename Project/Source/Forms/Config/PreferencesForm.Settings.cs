/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-12 </created>
/// <edited> 2023-01 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class PreferencesForm
{

  private readonly NullSafeOfStringDictionary<DataExportTarget> ExportTarget
    = ExportHelper.CreateExportTargets(DataExportTarget.XML);

  private void DoResetSettings()
  {
    if ( !DisplayManager.QueryYesNo(AppTranslations.AskToResetPreferences.GetLang()) ) return;
    MainForm.Instance.MenuShowHide_Click(null, null);
    LunarMonthsForm.Instance.Hide();
    StatisticsForm.Instance.Hide();
    string country = Settings.GPSCountry;
    string city = Settings.GPSCity;
    string lat = Settings.GPSLatitude;
    string lng = Settings.GPSLongitude;
    string timezone = Settings.TimeZone;
    long starttime = Settings.BenchmarkStartingApp;
    long loadtime = Settings.BenchmarkLoadData;
    int Shabat = EditShabatDay.SelectedIndex;
    var lastupdate = Settings.CheckUpdateLastDone;
    var lastvacuum = Settings.VacuumLastDone;
    Settings.Reset();
    Settings.SetFirstAndUpgradeFlagsOff();
    Settings.CheckUpdateLastDone = lastupdate;
    Settings.VacuumLastDone = lastvacuum;
    Settings.GPSCountry = country;
    Settings.GPSCity = city;
    Settings.GPSLatitude = lat;
    Settings.GPSLongitude = lng;
    Settings.TimeZone = timezone;
    Settings.ShabatDay = Shabat;
    Settings.LanguageSelected = Languages.Current;
    Settings.BenchmarkStartingApp = starttime;
    Settings.BenchmarkLoadData = loadtime;
    Settings.RestoreMainForm();
    Settings.InitializeReminderBoxDesktopLocation();
    if ( Settings.TorahEventsCountAsMoon )
      Settings.MonthViewLayoutEphemerisMoonEnabled = true;
    else
      Settings.MonthViewLayoutEphemerisSunEnabled = true;
    Program.TranscriptionGuideForm.CenterToMainFormElseScreen();
    Program.GrammarGuideForm.CenterToMainFormElseScreen();
    SystemManager.TryCatch(Settings.Store);
    DoReset = true;
    Reseted = true;
    Close();
  }

  private void DoImportSettings()
  {
    if ( !Settings.Import(OpenSettingsDialog) ) return;
    LanguageChanged = true;
    DoReset = true;
    Reseted = true;
    Close();
  }

  private void DoExportSettings()
  {
    var city = Settings.GPSCity;
    var omer = SelectUseSodHaibour.Checked
      ? AppTranslations.MainFormSubTitleSod.GetLang()
      : AppTranslations.MainFormSubTitleOmer[SelectOmerMoon.Checked][Language.EN];
    var shabat = ( (DayOfWeekItem)EditShabatDay.SelectedItem ).Day;
    Settings.Export(SaveSettingsDialog, $"Settings {city} {omer} {shabat}", () =>
    {
      TabControlMain.SelectedIndex = 0;
      SaveSettings();
    });
  }

}
