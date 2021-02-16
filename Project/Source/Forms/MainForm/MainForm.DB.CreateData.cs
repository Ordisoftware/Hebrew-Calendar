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
/// <created> 2016-04 </created>
/// <edited> 2021-02 </edited>
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    [Serializable]
    public class TooManyErrorsException : Exception
    {
      public TooManyErrorsException(string message) : base(message)
      {
      }
    }

    public const int MaxGenerateErrors = 20;

    private readonly List<string> GenerateErrors = new List<string>();

    private int ProgressCount;

    private bool AddGenerateErrorAndCheckIfTooMany(string method, string date, Exception ex)
    {
      var einfo = new ExceptionInfo(this, ex);
      GenerateErrors.Add($"{( GenerateErrors.Count + 1 ).ToString("00")}) " +
                         $"{method.PadRight(13)} {date} : " +
                         $"{einfo.SingleLineText}");
      return GenerateErrors.Count >= MaxGenerateErrors;
    }

    /// <summary>
    /// Create the calendar days items.
    /// </summary>
    /// <param name="yearFirst">The first year.</param>
    /// <param name="yearLast">The last year.</param>
    private string CreateData(int yearFirst, int yearLast)
    {
      IsGenerating = true;
      PanelViewText.Parent = null;
      PanelViewMonth.Parent = null;
      PanelViewGrid.Parent = null;
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      var Chrono = new Stopwatch();
      Chrono.Start();
      try
      {
        UpdateButtons();
        CalendarText.Clear();
        CalendarMonth.TheEvents.Clear();
        LunisolarDaysBindingSource.DataSource = null;
        EmptyDatabase();
        var d1 = new DateTime(yearFirst, 1, DateTime.DaysInMonth(yearFirst, 1));
        var d2 = new DateTime(yearLast, 12, DateTime.DaysInMonth(yearLast, 12));
        ProgressCount = (int)( d2 - d1 ).TotalDays;
        try
        {
          if ( IsGenerating )
            if ( PopulateDays(yearFirst, yearLast) )
              if ( IsGenerating )
                if ( AnalyseDays() )
                  if ( IsGenerating )
                    try
                    {
                      CalendarText.Text = GenerateReportText();
                    }
                    catch ( Exception ex )
                    {
                      // TODO add in errors list instead
                      ex.Manage();
                    }
        }
        finally
        {
          Chrono.Stop();
          Settings.BenchmarkGenerateYears = Chrono.ElapsedMilliseconds;
          Settings.LastGenerated = DateTime.Now;
          Settings.Save();
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
        ApplicationStatistics.UpdateDBFileSizeRequired = true;
        ApplicationStatistics.UpdateDBMemorySizeRequired = true;
        SetView(Settings.CurrentView, true);
        UpdateButtons();
        if ( Globals.IsReady && !ActionVacuumAtNextStartup.Checked )
          ActionVacuumAtNextStartup.PerformClick();
      }
      if ( GenerateErrors.Count != 0 )
      {
        string errors = GenerateErrors.AsMultiLine();
        GenerateErrors.Clear();
        errors = Settings.GetGPSText() + Globals.NL2 + errors;
        DebugManager.Trace(LogTraceEvent.Data, errors);
        using ( var form = new ShowTextForm(Text, errors, false, true, 600, 400, false, false) )
        {
          form.TextBox.Font = new System.Drawing.Font("Courier new", 8);
          form.ShowDialog();
        }
        if ( DisplayManager.QueryYesNo(SysTranslations.ContactSupport.GetLang()) )
          ExceptionForm.Run(new ExceptionInfo(this, new TooManyErrorsException(errors)));
        return errors;
      }
      return null;
    }

    /// <summary>
    /// Create the days.
    /// </summary>
    /// <param name="yearFirst">The first year.</param>
    /// <param name="yearLast">The last year.</param>
    private bool PopulateDays(int yearFirst, int yearLast)
    {
      LoadingForm.Instance.Initialize(AppTranslations.ProgressCreateDays.GetLang(),
                                      ProgressCount,
                                      Program.LoadingFormGenerate);
      var Chrono = new Stopwatch();
      Chrono.Start();
      try
      {
        for ( int year = yearFirst; year <= yearLast; year++ )
        {
          for ( int month = 1; month <= 12; month++ )
            for ( int day = 1; day <= DateTime.DaysInMonth(year, month); day++ )
              try
              {
                LoadingForm.Instance.DoProgress();
                var row = DataSet.LunisolarDays.NewLunisolarDaysRow();
                row.Date = SQLiteDate.ToString(year, month, day);
                row.TorahEvents = 0;
                row.LunarMonth = 0;
                if ( !InitializeDay(row) ) break;
                DataSet.LunisolarDays.AddLunisolarDaysRow(row);
              }
              catch ( Exception ex )
              {
                if ( AddGenerateErrorAndCheckIfTooMany(nameof(PopulateDays), $"{year}-{month.ToString("00")}-{day.ToString("00")}", ex) )
                  return false;
              }
        }
      }
      finally
      {
        Chrono.Stop();
        Settings.BenchmarkPopulateDays = Chrono.ElapsedMilliseconds;
      }
      return true;
    }

    /// <summary>
    /// Initialize a day.
    /// </summary>
    /// <param name="day">The day.</param>
    private bool InitializeDay(Data.DataSet.LunisolarDaysRow day)
    {
      try
      {
        var date = SQLiteDate.ToDateTime(day.Date);
        var data = CalendarDates.Instance[date];
        var ephemeris = data.Ephemerisis;
        day.LunarDay = data.MoonDay;
        day.IsNewMoon = day.LunarDay == 1 ? 1 : 0;
        day.MoonPhase = data.MoonPhase;
        day.IsFullMoon = Convert.ToInt32(day.MoonPhaseAsEnum == MoonPhase.Full);
        day.Sunrise = SQLiteDate.ToString(ephemeris.Sunrise);
        day.Sunset = SQLiteDate.ToString(ephemeris.Sunset);
        day.Moonrise = SQLiteDate.ToString(ephemeris.Moonrise);
        day.Moonset = SQLiteDate.ToString(ephemeris.Moonset);
        MoonRiseOccuring moonrisetype;
        if ( ephemeris.Moonrise == null )
          moonrisetype = MoonRiseOccuring.NextDay;
        else
        if ( ephemeris.Moonrise < ephemeris.Moonset )
          moonrisetype = MoonRiseOccuring.BeforeSet;
        else
          moonrisetype = MoonRiseOccuring.AfterSet;
        day.MoonriseOccuringAsEnum = moonrisetype;
        day.SeasonChangeAsEnum = data.RealSeasonChange;
        day.LunarMonth = 0;
        day.TorahEvents = 0;
      }
      catch ( Exception ex )
      {
        if ( AddGenerateErrorAndCheckIfTooMany(nameof(InitializeDay), day.Date, ex) )
          return false;
      }
      return true;
    }

    /// <summary>
    /// Create the calendar items.
    /// </summary>
    private bool AnalyseDays()
    {
      int month = 0;
      int delta = 0;
      LoadingForm.Instance.Initialize(AppTranslations.ProgressAnalyzeDays.GetLang(),
                                      ProgressCount,
                                      Program.LoadingFormGenerate);
      var Chrono = new Stopwatch();
      Chrono.Start();
      try
      {
        foreach ( Data.DataSet.LunisolarDaysRow day in DataSet.LunisolarDays.Rows )
          try
          {
            LoadingForm.Instance.DoProgress();
            if ( day.IsNewMoon == 1 )
              if ( !AnalyzeDay(day, ref month) ) break;
            day.LunarMonth = month;
            if ( day.IsNewMoon == 1 )
              delta = 0;
            if ( day.MoonriseOccuringAsEnum == MoonRiseOccuring.NextDay && Settings.TorahEventsCountAsMoon )
              delta = 1;
            day.LunarDay -= delta;
          }
          catch ( Exception ex )
          {
            if ( AddGenerateErrorAndCheckIfTooMany(nameof(AnalyseDays), day.Date, ex) )
              return false;
          }
      }
      finally
      {
        Chrono.Stop();
        Settings.BenchmarkAnalyseDays = Chrono.ElapsedMilliseconds;
      }
      return true;
    }

    /// <summary>
    /// Analyzes a day.
    /// </summary>
    /// <param name="day">The day.</param>
    /// <param name="monthMoon">[in,out] The current mooon month.</param>
    private bool AnalyzeDay(Data.DataSet.LunisolarDaysRow day, ref int monthMoon)
    {
      DateTime calculate(DateTime thedate, int toadd, TorahEvent type, bool forceSunOmer)
      {
        if ( Settings.TorahEventsCountAsMoon )
        {
          var rowStart = DataSet.LunisolarDays.FirstOrDefault(d => d.Date == SQLiteDate.ToString(thedate));
          int index = DataSet.LunisolarDays.Rows.IndexOf(rowStart);
          int count = 0;
          if ( forceSunOmer )
            count = toadd;
          else
            for ( int i = 0; i < toadd; i++, count++ )
              if ( DataSet.LunisolarDays[index + i].MoonriseOccuringAsEnum == MoonRiseOccuring.NextDay )
                count++;
          thedate = thedate.AddDays(count);
          var row = DataSet.LunisolarDays.FirstOrDefault(d => d.Date == SQLiteDate.ToString(thedate));
          if ( row != null )
            if ( row.MoonriseOccuringAsEnum == MoonRiseOccuring.NextDay )
              thedate = thedate.AddDays(1);
        }
        else
          thedate = thedate.AddDays(toadd);
        var rowEnd = DataSet.LunisolarDays.FirstOrDefault(d => d.Date == SQLiteDate.ToString(thedate));
        if ( rowEnd != null )
          rowEnd.TorahEvents |= (int)type;
        return thedate;
      }
      try
      {
        var dateDay = SQLiteDate.ToDateTime(day.Date);
        bool check(Data.DataSet.LunisolarDaysRow row)
        {
          var dateRow = SQLiteDate.ToDateTime(row.Date);
          return dateRow.Year == dateDay.Year 
                              && CalendarDates.Instance[dateRow].TorahSeasonChange == SeasonChange.SpringEquinox;
        }
        var equinoxe = DataSet.LunisolarDays.Where(d => check(d)).First();
        var dateEquinox = SQLiteDate.ToDateTime(equinoxe.Date);
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
        int delta = Settings.TorahEventsCountAsMoon ? 0 : 1;
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
          while ( dateDay.DayOfWeek != (DayOfWeek)Settings.ShabatDay )
            dateDay = dateDay.AddDays(1);
          SystemManager.TryCatch(() =>
          {
            calculate(dateDay, 1, TorahEvent.Chavouot1, true);
            calculate(dateDay, 1 + TorahCelebrations.ChavouotLenght - 1, TorahEvent.Chavouot2, false);
          });
        }
        else
        if ( monthMoon > 0 )
          monthMoon++;
        if ( monthMoon == TorahCelebrations.YomsMonth )
        {
          dateDay = calculate(dateDay, 0, TorahEvent.YomTerouah, false);
          calculate(dateDay, TorahCelebrations.YomHaKipourimDay - 1, TorahEvent.YomHaKipourim, false);
          dateDay = calculate(dateDay, TorahCelebrations.SoukotStartDay - 1, TorahEvent.SoukotD1, false);
          calculate(dateDay, TorahCelebrations.SoukotLenght - 1, TorahEvent.SoukotD8, false);
        }
      }
      catch ( Exception ex )
      {
        if ( AddGenerateErrorAndCheckIfTooMany(nameof(AnalyzeDay), day.Date, ex) )
          return false;
      }
      return true;
    }

  }

}
