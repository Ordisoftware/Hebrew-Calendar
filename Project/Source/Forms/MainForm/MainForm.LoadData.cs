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
/// <created> 2019-01 </created>
/// <edited> 2020-08 </edited>
using System;
using System.IO;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void LoadData()
    {
      void update(object tableSender, DataRowChangeEventArgs tableEvent)
      {
        if ( !IsGenerating ) LoadingForm.Instance.DoProgress();
      };
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      try
      {
        Enabled = false;
        CreateDatabaseIfNotExists();
        var connection = new OdbcConnection(Settings.ConnectionString);
        connection.Open();
        var command = new OdbcCommand("SELECT count(*) FROM LunisolarDays", connection);
        LoadingForm.Instance.Initialize(AppTranslations.ProgressLoadingData.GetLang(),
                                        (int)command.ExecuteScalar() * 2,
                                        Program.LoadingFormLoadDB);
        DataSet.LunisolarDays.RowChanged += update;
        connection.Close();
        var Chrono = new Stopwatch();
        Chrono.Start();
        LunisolarDaysTableAdapter.Fill(DataSet.LunisolarDays);
        Chrono.Stop();
        Settings.BenchmarkLoadData = Chrono.ElapsedMilliseconds;
        Settings.Save();
        if ( DataSet.LunisolarDays.Count > 0 && !Settings.FirstLaunch )
        {
          IsGenerating = true;
          try
          {
            FillMonths();
          }
          finally
          {
            IsGenerating = false;
          }
          SystemManager.TryCatch(() =>
          {
            bool isTextReportLoaded = false;
            if ( File.Exists(Program.TextReportFilePath) )
              try
              {
                CalendarText.Text = File.ReadAllText(Program.TextReportFilePath);
                isTextReportLoaded = true;
              }
              catch ( Exception ex )
              {
                ChronoStart.Stop();
                DisplayManager.ShowWarning(SysTranslations.LoadFileError.GetLang(Program.TextReportFilePath, ex.Message));
                ChronoStart.Start();
              }
            if ( !isTextReportLoaded )
              CalendarText.Text = GenerateReport();
            GoToDate(DateTime.Today);
          });
        }
        else
        {
          ChronoStart.Stop();
          PreferencesForm.Run();
          ChronoStart.Start();
          string errors = CheckRegenerateCalendar(true);
          if ( errors != null )
          {
            SystemManager.TryCatch(() => EmptyDatabase());
            throw new Exception(string.Format(AppTranslations.FatalGenerateError.GetLang(), errors));
          }
        }
      }
      catch ( Exception ex )
      {
        ChronoStart.Stop();
        ex.Manage();
        DisplayManager.ShowAndTerminate(SysTranslations.ApplicationMustExit[Language.FR] + Globals.NL2 +
                                        SysTranslations.ContactSupport[Language.FR]);
      }
      finally
      {
        Enabled = true;
        Cursor = cursor;
        DataSet.LunisolarDays.RowChanged -= update;
        try
        {
          SetView(Settings.CurrentView, true);
          UpdateButtons();
        }
        catch ( Exception ex )
        {
          ChronoStart.Stop();
          ex.Manage();
          ChronoStart.Start();
        }
        try
        {
          CalendarMonth.ShowEventTooltips = Settings.MonthViewSunToolTips;
          TimerReminder.Enabled = true;
          TimerReminder_Tick(null, null);
        }
        catch ( Exception ex )
        {
          ChronoStart.Stop();
          ex.Manage();
          ChronoStart.Start();
        }
      }
    }

  }

}
