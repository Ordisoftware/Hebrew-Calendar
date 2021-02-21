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
/// <created> 2020-12 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using System.Configuration;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm
  {

    private NullSafeOfStringDictionary<DataExportTarget> ExportTarget
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
      long starttime = Program.Settings.BenchmarkStartingApp;
      long loadtime = Program.Settings.BenchmarkLoadData;
      int shabat = EditShabatDay.SelectedIndex;
      int bookmarksCount = Settings.DateBookmarksCount;
      Settings.Reset();
      Settings.DateBookmarksCount = bookmarksCount;
      Settings.UpgradeResetRequiredV3_0 = false;
      Settings.UpgradeResetRequiredV3_6 = false;
      Settings.UpgradeResetRequiredV4_1 = false;
      Settings.UpgradeResetRequiredV5_10 = false;
      Settings.FirstLaunchV4 = false;
      Settings.Save();
      DoReset = true;
      Reseted = true;
      Settings.GPSCountry = country;
      Settings.GPSCity = city;
      Settings.GPSLatitude = lat;
      Settings.GPSLongitude = lng;
      Settings.TimeZone = timezone;
      Settings.ShabatDay = shabat;
      Settings.RestoreMainForm();
      Settings.LanguageSelected = Languages.Current;
      Settings.BenchmarkStartingApp = starttime;
      Settings.BenchmarkLoadData = loadtime;
      MainForm.Instance.ReminderBoxDesktopLocation();
      Close();
    }

    private void DoExportSettings()
    {
      SaveSettingsDialog.FileName = "Settings";
      for ( int index = 0; index < Program.GridExportTargets.Count; index++ )
        if ( Program.GridExportTargets.ElementAt(index).Key == Program.Settings.ExportDataPreferredTarget )
          SaveSettingsDialog.FilterIndex = index + 1;
      if ( SaveSettingsDialog.ShowDialog() != DialogResult.OK ) return;
      TabControl.SelectedIndex = 0;
      UpdateSettings();
      Settings.Store();
      var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
      config.SaveAs(SaveSettingsDialog.FileName);
    }

    private void DoImportSettings()
    {
      OpenSettingsDialog.FileName = string.Empty;
      if ( OpenSettingsDialog.ShowDialog() != DialogResult.OK ) return;
      MainForm.Instance.MenuShowHide_Click(null, null);
      LunarMonthsForm.Instance.Hide();
      StatisticsForm.Instance.Hide();
      long starttime = Program.Settings.BenchmarkStartingApp;
      long loadtime = Program.Settings.BenchmarkLoadData;
      try
      {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        string context = Properties.Settings.Default.Context["GroupName"].ToString();
        var xmldata = XDocument.Load(OpenSettingsDialog.FileName);
        var settings = xmldata.XPathSelectElements("//" + context);
        var section = config.GetSectionGroup("userSettings").Sections[context].SectionInformation;
        section.SetRawXml(settings.Single().ToString());
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("userSettings");
        Program.Settings.Reload();
        Program.Settings.BenchmarkStartingApp = starttime;
        Program.Settings.BenchmarkLoadData = loadtime;
        Program.Settings.Save();
        Program.Settings.Retrieve();
        DoReset = true;
        Reseted = true;
        Close();
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(ex.Message);
        Program.Settings.Reload();
      }
    }

  }

}
