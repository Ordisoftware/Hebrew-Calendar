﻿/// <license>
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
/// <created> 2019-01 </created>
/// <edited> 2021-05 </edited>
using System;
using System.IO;
using System.Threading.Tasks;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private void LoadData()
    {
      bool formEnabled = Enabled;
      ToolStrip.Enabled = false;
      try
      {
        var task = Task.Run(() =>
        {
          Globals.ChronoLoadData.Start();
          ApplicationDatabase.Instance.Open();
          LunisolarDaysBindingSource.DataSource = ApplicationDatabase.Instance.LunisolarDaysAsBindingList;
          UserParashot = HebrewDatabase.Instance.TakeParashot();
          HebrewDatabase.Instance.ReleaseParashot();
          Globals.ChronoLoadData.Stop();
          Settings.BenchmarkLoadData = Globals.ChronoLoadData.ElapsedMilliseconds;
                  SystemManager.TryCatch(Settings.Save);
        });
        Program.UpdateLocalization();
        task.Wait();
        if ( LunisolarDays.Count > 0
          && !Settings.FirstLaunch
          && !Settings.FirstLaunchV7_0 )
        {
          Globals.IsGenerating = true;
          try
          {
            FillMonths();
          }
          finally
          {
            Globals.IsGenerating = false;
          }
          SystemManager.TryCatch(() =>
          {
            bool isTextReportLoaded = false;
            if ( File.Exists(Program.TextReportFilePath) )
              try
              {
                Globals.ChronoLoadData.Start();
                CalendarText.Text = File.ReadAllText(Program.TextReportFilePath);
                Globals.ChronoLoadData.Stop();
                isTextReportLoaded = true;
              }
              catch ( Exception ex )
              {
                Globals.ChronoStartingApp.Stop();
                string msg = SysTranslations.LoadFileError.GetLang(Program.TextReportFilePath, ex.Message);
                DisplayManager.ShowWarning(msg);
                Globals.ChronoStartingApp.Start();
              }
            if ( !isTextReportLoaded )
              CalendarText.Text = GenerateReportText();
            GoToDate(DateTime.Today);
          });
        }
        else
        {
          Globals.ChronoStartingApp.Stop();
          PreferencesForm.Run();
          string errors = CheckRegenerateCalendar(true);
          Globals.ChronoStartingApp.Start();
          if ( errors != null )
          {
            SystemManager.TryCatch(() => ApplicationDatabase.Instance.DeleteAll());
            throw new Exception(string.Format(SysTranslations.FatalGenerateError.GetLang(), errors));
          }
        }
      }
      catch ( Exception ex )
      {
        Globals.ChronoStartingApp.Stop();
        ex.Manage();
        DisplayManager.ShowAndTerminate(SysTranslations.ApplicationMustExitContactSupport.GetLang());
        Globals.ChronoStartingApp.Start();
      }
      finally
      {
        ToolStrip.Enabled = formEnabled;
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
          CalendarMonth.ShowEventTooltips = Settings.MonthViewSunToolTips;
          TimerReminder.Enabled = true;
          Globals.ChronoStartingApp.Stop();
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

  }

}
