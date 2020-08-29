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
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
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
        var connection = new OdbcConnection(Program.Settings.ConnectionString);
        connection.Open();
        var command = new OdbcCommand("SELECT count(*) FROM LunisolarDays", connection);
        LoadingForm.Instance.Initialize(Translations.ProgressLoadingData.GetLang(),
                                        (int)command.ExecuteScalar() * 2,
                                        Program.LoadingFormLoadDB);
        DataSet.LunisolarDays.RowChanged += update;
        connection.Close();
        var Chrono = new Stopwatch();
        Chrono.Start();
        LunisolarDaysTableAdapter.Fill(DataSet.LunisolarDays);
        ReportTableAdapter.Fill(DataSet.Report);
        Chrono.Stop();
        Program.Settings.BenchmarkLoadData = Chrono.ElapsedMilliseconds;
        Program.Settings.Save();
        if ( DataSet.LunisolarDays.Count > 0 && !Program.Settings.FirstLaunch )
        {
          IsGenerating = true;
          try { FillMonths(); }
          finally { IsGenerating = false; }
          try
          {
            var row = DataSet.Report.FirstOrDefault();
            CalendarText.Text = row == null ? "" : row.Content;
            GoToDate(DateTime.Today);
          }
          catch
          {
          }
        }
        else
        {
          PreferencesForm.Run();
          string errors = CheckRegenerateCalendar(true);
          if ( errors != null )
          {
            try { EmptyDatabase(); }
            catch { }
            throw new Exception(string.Format(Translations.FatalGenerateError.GetLang(), errors));
          }
        }
      }
      catch ( OdbcException ex )
      {
        ex.Manage();
        Environment.Exit(-1);
      }
      catch ( Exception ex )
      {
        ex.Manage();
        Environment.Exit(-1);
      }
      finally
      {
        Enabled = true;
        Cursor = cursor;
        DataSet.LunisolarDays.RowChanged -= update;
        try
        {
          SetView(Program.Settings.CurrentView, true);
          UpdateButtons();
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
        try
        {
          CalendarMonth.ShowEventTooltips = Program.Settings.MonthViewSunToolTips;
          TimerReminder.Enabled = true;
          TimerReminder_Tick(null, null);
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
      }
    }

  }

}
