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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private readonly List<string> GenerateErrors = new List<string>();

    private int ProgressCount;

    /// <summary>
    /// Create the calendar days items.
    /// </summary>
    /// <param name="yearFirst">The first year.</param>
    /// <param name="yearLast">The last year.</param>
    private void GenerateData(int yearFirst, int yearLast)
    {
      IsGenerating = true;
      PanelViewText.Parent = null;
      PanelViewMonth.Parent = null;
      PanelViewGrid.Parent = null;
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      try
      {
        Program.Chrono.Restart();
        UpdateButtons();
        CalendarText.Clear();
        CalendarMonth.Events.Clear();
        LunisolarDaysBindingSource.DataSource = null;
        LunisolarDaysTableAdapter.DeleteAllQuery();
        ReportTableAdapter.DeleteAllQuery();
        TableAdapterManager.UpdateAll(DataSet);
        LunisolarDaysTableAdapter.Fill(DataSet.LunisolarDays);
        ReportTableAdapter.Fill(DataSet.Report);
         var d1 = new DateTime(yearFirst, 1, DateTime.DaysInMonth(yearFirst, 1));
        var d2 = new DateTime(yearLast, 12, DateTime.DaysInMonth(yearLast, 12));
        ProgressCount = (int)( d2 - d1 ).TotalDays;
        try
        {
          if ( IsGenerating ) PopulateDays(yearFirst, yearLast);
          if ( IsGenerating ) AnalyseDays();
          if ( IsGenerating )
            try
            {
              CalendarText.Text = GenerateReport();
            }
            catch (Exception ex)
            {
              ex.Manage();
            }
        }
        finally
        {
          Program.Chrono.Stop();
          Program.Settings.BenchmarkGenerateYears = Program.Chrono.ElapsedMilliseconds;
          Program.Settings.Save();
          if ( IsGenerating )
            try
            {
              FillMonths();
            }
            finally
            {
              TableAdapterManager.UpdateAll(DataSet);
              LunisolarDaysBindingSource.DataSource = DataSet.LunisolarDays;
            }
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      finally
      {
        Cursor = cursor;
        IsGenerating = false;
        SetView(Program.Settings.CurrentView, true);
        UpdateButtons();
      }
      if ( GenerateErrors.Count != 0 )
      {
        DisplayManager.ShowWarning(Text, string.Join(Environment.NewLine, GenerateErrors));
        GenerateErrors.Clear();
      }
    }

    /// <summary>
    /// Create the days.
    /// </summary>
    /// <param name="yearFirst">The first year.</param>
    /// <param name="yearLast">The last year.</param>
    private void PopulateDays(int yearFirst, int yearLast)
    {
      LoadingForm.Instance.Initialize(Translations.ProgressCreateDays.GetLang(),
                                      ProgressCount,
                                      Program.LoadingFormGenerate);
      for ( int year = yearFirst; year <= yearLast; year++ )
      {
        for ( int month = 1; month <= 12; month++ )
          for ( int day = 1; day <= DateTime.DaysInMonth(year, month); day++ )
            try
            {
              LoadingForm.Instance.DoProgress();
              var row = DataSet.LunisolarDays.NewLunisolarDaysRow();
              row.Date = SQLite.GetDate(year, month, day);
              row.TorahEvents = 0;
              row.LunarMonth = 0;
              InitializeDay(row);
              DataSet.LunisolarDays.AddLunisolarDaysRow(row);
            }
            catch ( Exception ex )
            {
              GenerateErrors.Add($"{year}-{month}-{day}: [{nameof(PopulateDays)}] { ex.Message}");
            }
      }
    }

    /// <summary>
    /// Initialize a day.
    /// </summary>
    /// <param name="day">The day.</param>
    private void InitializeDay(Data.DataSet.LunisolarDaysRow day)
    {
      try
      {
        var date = SQLite.GetDate(day.Date);
        var data = Dates.Get(date);
        var ephemeris = data.Ephemerisis;
        day.LunarDay = data.DayOfMonth;
        day.IsNewMoon = day.LunarDay == 1 ? 1 : 0;
        day.MoonPhase = data.MoonPhase;
        day.IsFullMoon = Convert.ToInt32((MoonPhase)day.MoonPhase == MoonPhase.Full);
        day.Sunrise = SQLite.FormatTime(ephemeris.Sunrise);
        day.Sunset = SQLite.FormatTime(ephemeris.Sunset);
        day.Moonrise = SQLite.FormatTime(ephemeris.Moonrise);
        day.Moonset = SQLite.FormatTime(ephemeris.Moonset);
        MoonRise moonrisetype;
        if ( ephemeris.Moonrise == null )
          moonrisetype = MoonRise.NextDay;
        else
        if ( ephemeris.Moonrise < ephemeris.Moonset )
          moonrisetype = MoonRise.BeforeSet;
        else
          moonrisetype = MoonRise.AfterSet;
        day.MoonriseType = (int)moonrisetype;
        day.SeasonChange = (int)data.RealSeasonChange;
        day.LunarMonth = 0;
        day.TorahEvents = 0;
      }
      catch ( Exception ex )
      {
        GenerateErrors.Add($"{day.Date}: [{nameof(InitializeDay)}] { ex.Message}");
      }
    }

    /// <summary>
    /// Create the calendar items.
    /// </summary>
    private void AnalyseDays()
    {
      int month = 0;
      int delta = 0;
      LoadingForm.Instance.Initialize(Translations.ProgressAnalyzeDays.GetLang(),
                                      ProgressCount,
                                      Program.LoadingFormGenerate);
      foreach ( Data.DataSet.LunisolarDaysRow day in DataSet.LunisolarDays.Rows )
        try
        {
          LoadingForm.Instance.DoProgress();
          if ( day.IsNewMoon == 1 )
            AnalyzeDay(day, ref month);
          day.LunarMonth = month;
          if ( day.IsNewMoon == 1 )
            delta = 0;
          if ( (MoonRise)day.MoonriseType == MoonRise.NextDay && Program.Settings.TorahEventsCountAsMoon )
            delta = 1;
          day.LunarDay -= delta;
        }
        catch ( Exception ex )
        {
          GenerateErrors.Add($"{day.Date}: [{nameof(AnalyseDays)}] { ex.Message}");
        }
    }

    /// <summary>
    /// Analyzes a day.
    /// </summary>
    /// <param name="day">The day.</param>
    /// <param name="monthMoon">[in,out] The current mooon month.</param>
    private void AnalyzeDay(Data.DataSet.LunisolarDaysRow day, ref int monthMoon)
    {
      DateTime calculate(DateTime thedate, int toadd, TorahEvent type, bool forceSunOmer)
      {
        if ( Program.Settings.TorahEventsCountAsMoon )
        {
          var rowStart = DataSet.LunisolarDays.FirstOrDefault(d => d.Date == SQLite.GetDate(thedate));
          int index = DataSet.LunisolarDays.Rows.IndexOf(rowStart);
          int count = 0;
          if ( forceSunOmer )
            count = toadd;
          else
            for ( int i = 0; i < toadd; i++, count++ )
              if ( (MoonRise)DataSet.LunisolarDays[index + i].MoonriseType == MoonRise.NextDay )
                count++;
          thedate = thedate.AddDays(count);
        }
        else
          thedate = thedate.AddDays(toadd);
        var rowEnd = DataSet.LunisolarDays.FirstOrDefault(d => d.Date == SQLite.GetDate(thedate));
        if ( rowEnd != null )
          rowEnd.TorahEvents |= (int)type;
        return thedate;
      }
      try
      {
        var dateDay = SQLite.GetDate(day.Date);
        bool check(Data.DataSet.LunisolarDaysRow row)
        {
          var dateRow = SQLite.GetDate(row.Date);
          return dateRow.Year == dateDay.Year && Dates.Get(dateRow).TorahSeasonChange == SeasonChange.SpringEquinox;
        }
        var equinoxe = DataSet.LunisolarDays.Where(d => check(d)).First();
        var dateEquinox = SQLite.GetDate(equinoxe.Date);
        int deltaNewLambDay = dateEquinox.Day - TorahCelebrations.NewLambDay;
        bool newEquinoxe = ( dateDay.Month == dateEquinox.Month && dateDay.Day >= deltaNewLambDay )
                        || ( dateDay.Month == dateEquinox.Month + 1 );
        int monthExuinoxe = dateEquinox.Month;
        int dayEquinoxe = dateEquinox.Day - TorahCelebrations.NewLambDay;
        if ( dayEquinoxe < 1 )
        {
          monthExuinoxe--;
          dayEquinoxe += 30;
        }
        int delta = Program.Settings.TorahEventsCountAsMoon ? 0 : 1;
        bool isNewYear = ( dateDay.Month == monthExuinoxe && dateDay.Day >= dayEquinoxe )
                      || ( dateDay.Month == monthExuinoxe + 1 );
        if ( equinoxe != null && ( monthMoon == 0 || monthMoon >= 12 ) && isNewYear )
        {
          monthMoon = 1;
          calculate(dateDay, 0, TorahEvent.NewYearD1, false);
          calculate(dateDay, TorahCelebrations.NewLambDay - 1, TorahEvent.NewYearD10, false);
          dateDay = calculate(dateDay, TorahCelebrations.PessahStartDay - 1 + delta, TorahEvent.PessahD1, false);
          calculate(dateDay, TorahCelebrations.PessahLenght - 1, TorahEvent.PessahD7, false);
          dateDay = calculate(dateDay, TorahCelebrations.ChavouotLenght - 1 - delta, TorahEvent.ChavouotDiet, true);
          while ( dateDay.DayOfWeek != (DayOfWeek)Program.Settings.ShabatDay )
            dateDay = dateDay.AddDays(1);
          try
          {
            calculate(dateDay, 1, TorahEvent.Chavouot1, true);
            calculate(dateDay, 1 + TorahCelebrations.ChavouotLenght - 1, TorahEvent.Chavouot2, false);
          }
          catch
          {
          }
        }
        else
        if ( monthMoon > 0 )
          monthMoon++;
        if ( monthMoon == 7 )
        {
          dateDay = calculate(dateDay, 0, TorahEvent.YomTerouah, false);
          calculate(dateDay, TorahCelebrations.YomHaKipourimDay - 1, TorahEvent.YomHaKipourim, false);
          dateDay = calculate(dateDay, TorahCelebrations.SoukotStartDay - 1, TorahEvent.SoukotD1, false);
          calculate(dateDay, TorahCelebrations.SoukotLenght - 1, TorahEvent.SoukotD8, false);
        }
      }
      catch ( Exception ex )
      {
        GenerateErrors.Add($"{day.Date}: [{nameof(AnalyzeDay)}] { ex.Message}");
      }
    }

  }

}
