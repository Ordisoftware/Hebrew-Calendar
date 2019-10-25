/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-01 </edited>
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void LoadData()
    {
      int progress = 0;
      void update(object tableSender, DataRowChangeEventArgs tableEvent)
      {
        if ( !IsGenerating ) UpdateProgress(progress++, ProgressCount, Translations.LoadingData.GetLang());
      };
      DataSet.LunisolarDays.RowChanged += update;
      Cursor = Cursors.WaitCursor;
      Enabled = false;
      try
      {
        CreateDatabaseIfNotExists();
        var connection = new OdbcConnection(Program.Settings.ConnectionString);
        connection.Open();
        var command = new OdbcCommand("SELECT count(*) FROM LunisolarDays", connection);
        ProgressCount = (int)command.ExecuteScalar();
        connection.Close();
        LunisolarDaysTableAdapter.Fill(DataSet.LunisolarDays);
        ReportTableAdapter.Fill(DataSet.Report);
        if ( DataSet.LunisolarDays.Count > 0 )
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
          try
          {
            var row = DataSet.Report.FirstOrDefault();
            CalendarText.Text = row == null ? "" : row.Content;
            GoToDate(DateTime.Now);
          }
          catch
          {
          }
        }
        else
        {
          PreferencesForm.Run();
          Enabled = true;
          do
          {
            DoGenerate(this, null);
          }
          while ( DataSet.LunisolarDays.Count == 0 );
        }
      }
      catch ( AbortException ex )
      {
        LoadData();
        return;
      }
      catch ( OdbcException ex )
      {
        DisplayManager.ShowError(ex.Message);
        Environment.Exit(-1);
      }
      catch ( Exception ex )
      {
        ex.Manage();
        LoadData();
        return;
      }
      finally
      {
        Enabled = true;
        Cursor = Cursors.Default;
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
          Timer_Tick(null, null);
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
      }
    }

  }

}
