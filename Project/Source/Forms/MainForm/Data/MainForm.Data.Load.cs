﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2022-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private void LoadData()
  {
    bool formEnabled = Enabled;
    ToolStrip.Enabled = false;
    Globals.IsLoadingData = true;
    try
    {
      PanelTitleInner.Visible = true;
      LabelSubTitleGPS.Text = SysTranslations.LoadingData.GetLang();
      LoadDataInit();
      if ( LunisolarDays.Count > 0 && !Settings.FirstLaunch && !Settings.FirstLaunchV7_0 )
      {
        LoadDataFill();
        if ( Settings.FirstLaunchV9_14 )
          LoadDataGenerate(true, true);
        else
        if ( Settings.FirstLaunchV9_17 || Settings.FirstLaunchV9_18 )
          LoadDataGenerate(true, false);
        Settings.FirstLaunchV9_14 = false;
        Settings.FirstLaunchV9_17 = false;
        Settings.FirstLaunchV9_18 = false;
      }
      else
        LoadDataGenerate(false, true);
    }
    catch ( Exception ex )
    {
      Globals.ChronoStartingApp.Stop();
      ex.Manage();
      DisplayManager.ShowAndTerminate(SysTranslations.ApplicationMustExitContactSupport.GetLang());
    }
    finally
    {
      Globals.IsLoadingData = false;
      LabelSubTitleGPS.Text = string.Empty;
      ToolStrip.Enabled = formEnabled;
      LoadDataEnd();
    }
  }

  private void LoadDataInit()
  {
    Globals.ChronoLoadData.Start();
    DBApp.Open();
    LunisolarDaysBindingSource.DataSource = DBApp.LunisolarDays;
    UserParashot = HebrewDatabase.TakeParashot();
    HebrewDatabase.ReleaseParashot();
    Globals.ChronoLoadData.Stop();
    Settings.BenchmarkLoadData = Globals.ChronoLoadData.ElapsedMilliseconds;
    SystemManager.TryCatch(Settings.Store);
  }

  private void LoadDataFill()
  {
    FillMonths();
    LoadDataFillReport();
    GoToDate(DateTime.Today);
  }

  private void LoadDataFillReport()
  {
    bool isTextReportLoaded = false;
    if ( File.Exists(Program.TextReportFilePath) )
      try
      {
        Globals.ChronoLoadData.Start();
        TextReport.Text = File.ReadAllText(Program.TextReportFilePath);
        Globals.ChronoLoadData.Stop();
        isTextReportLoaded = true;
      }
      catch ( Exception ex )
      {
        Globals.ChronoStartingApp.Stop();
        DisplayManager.ShowWarning(SysTranslations.LoadFileError.GetLang(Program.TextReportFilePath, ex.Message));
        Globals.ChronoStartingApp.Start();
      }
    if ( !isTextReportLoaded )
      TextReport.Text = DBApp.GenerateReport();
  }

  private void LoadDataGenerate(bool keepYears, bool runPreferences)
  {
    Globals.ChronoStartingApp.Stop();
    if ( runPreferences ) PreferencesForm.Run(PreferencesForm.TabIndexGeneration);
    string errors = CheckRegenerateCalendar(true, force: keepYears, keepYears: keepYears);
    Globals.ChronoStartingApp.Start();
    if ( errors is not null )
    {
      SystemManager.TryCatch(() => DBApp.EmptyLunisolarDays());
      throw new Exception(string.Format(SysTranslations.FatalGenerateError.GetLang(), errors));
    }
  }

  private void LoadDataEnd()
  {
    try
    {
      if ( Settings.RestoreLastViewAtStartup )
        SetView(Settings.CurrentView, true);
      else
        SetView(ViewMode.Month, true);
      UpdateButtons();
    }
    catch ( Exception ex )
    {
      Globals.ChronoStartingApp.Stop();
      ex.Manage();
      Globals.ChronoStartingApp.Start();
    }
    try
    {
      Globals.ChronoStartingApp.Stop();
      MonthlyCalendar.ShowEventTooltips = false;
      TimerReminder.Enabled = true;
      TimerReminder_Tick(null, null);
      Globals.ChronoStartingApp.Start();
    }
    catch ( Exception ex )
    {
      Globals.ChronoStartingApp.Stop();
      ex.Manage();
      Globals.ChronoStartingApp.Start();
    }
  }

}
