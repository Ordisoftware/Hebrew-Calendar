/// <license>
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
/// <created> 2016-04 </created>
/// <edited> 2022-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  /// <summary>
  /// Creates the calendar days items.
  /// </summary>
  /// <param name="yearFirst">The first year.</param>
  /// <param name="yearLast">The last year.</param>
  private string CreateData(int yearFirst, int yearLast)
  {
    Globals.IsGenerating = true;
    PanelViewTextReport.Parent = null;
    PanelViewMonthlyCalendar.Parent = null;
    PanelViewGrid.Parent = null;
    var cursor = Cursor;
    Cursor = Cursors.WaitCursor;
    Globals.ChronoCreateData.Restart();
    LunisolarDaysBindingSource.DataSource = null;
    DBApp.BeginTransaction();
    try
    {
      UpdateButtons();
      LabelSubTitleGPS.Text = SysTranslations.CreatingData.GetLang();
      TextReport.Clear();
      MonthlyCalendar.TheEvents.Clear();
      DBApp.EmptyLunisolarDays();
      try
      {
        bool success = false;
        if ( Globals.IsGenerating )
          success = DBApp.PopulateDays(yearFirst, yearLast);
        if ( Globals.IsGenerating && success )
          try
          {
            TextReport.Text = DBApp.GenerateReport(true);
          }
          catch ( Exception ex )
          {
            ex.Manage();
          }
      }
      finally
      {
        Globals.ChronoCreateData.Stop();
        Settings.BenchmarkGenerateYears = Globals.ChronoCreateData.ElapsedMilliseconds;
        Settings.LastGenerated = DateTime.Now;
        SystemManager.TryCatch(Settings.Store);
        if ( !Globals.IsGenerating )
          LabelSubTitleGPS.Text = string.Empty;
        else
          try
          {
            FillMonths();
            LabelSubTitleGPS.Text = string.Empty;
          }
          finally
          {
            DBApp.Commit();
            LunisolarDaysBindingSource.DataSource = DBApp.LunisolarDays;
          }
      }
    }
    catch ( Exception ex )
    {
      DBApp.Rollback();
      ex.Manage();
    }
    finally
    {
      Cursor = cursor;
      Globals.IsGenerating = false;
      ApplicationStatistics.UpdateDBFileSizeRequired = true;
      ApplicationStatistics.UpdateDBMemorySizeRequired = true;
      SetView(Settings.CurrentView, true);
      UpdateButtons();
    }
    if ( DBApp.LastGenerationErrors.Count != 0 )
      return DBApp.ShowLastGenerationErrors(Text);
    return null;
  }

}
