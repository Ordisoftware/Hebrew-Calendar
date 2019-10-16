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
/// <created> 2016-04 </created>
/// <edited> 2019-10 </edited>
using System;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private int Count;

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
      Cursor = Cursors.WaitCursor;
      try
      {
        UpdateButtons();
        CalendarText.Clear();
        CalendarMonth.LoadPresetHolidays = false;
        LunisolarDaysBindingSource.DataSource = null;
        LunisolarDaysTableAdapter.DeleteAllQuery();
        ReportTableAdapter.DeleteAllQuery();
        TableAdapterManager.UpdateAll(LunisolarCalendar);
        LunisolarDaysTableAdapter.Fill(LunisolarCalendar.LunisolarDays);
        ReportTableAdapter.Fill(LunisolarCalendar.Report);
        var d1 = new DateTime(yearFirst, 1, DateTime.DaysInMonth(yearFirst, 1));
        var d2 = new DateTime(yearLast, 12, DateTime.DaysInMonth(yearLast, 12));
        Count = (int)( d2 - d1 ).TotalDays;
        try
        {
          if ( IsGenerating ) PopulateDays(yearFirst, yearLast);
          if ( IsGenerating ) AnalyseDays();
          if ( IsGenerating ) CalendarText.Text = GenerateReport();
          if ( IsGenerating ) FillMonths();
        }
        finally
        {
          TableAdapterManager.UpdateAll(LunisolarCalendar);
          LunisolarDaysBindingSource.DataSource = LunisolarCalendar.LunisolarDays;
        }
      }
      catch ( Exception except )
      {
        except.Manage();
      }
      finally
      {
        Cursor = Cursors.Default;
        IsGenerating = false;
        SetView(Program.Settings.CurrentView, true);
        UpdateButtons();
      }
    }

    /// <summary>
    /// Create the days.
    /// </summary>
    /// <param name="yearFirst">The first year.</param>
    /// <param name="yearLast">The last year.</param>
    private void PopulateDays(int yearFirst, int yearLast)
    {
      for ( int progress = 0, year = yearFirst; year <= yearLast; year++ )
      {
        for ( int month = 1; month <= 12; month++ )
          for ( int day = 1; day <= DateTime.DaysInMonth(year, month); day++ )
          {
            if ( !UpdateProgress(progress++, Count, Translations.ProgressCreateDays.GetLang()) ) return;
            var row = LunisolarCalendar.LunisolarDays.NewLunisolarDaysRow();
            row.Date = SQLiteUtility.GetDate(year, month, day);
            InitializeDay(row);
            LunisolarCalendar.LunisolarDays.AddLunisolarDaysRow(row);
          }
        InitializeSeasons(year);
      }
    }

    /// <summary>
    /// Initialize a day.
    /// </summary>
    /// <param name="day">The day.</param>
    private void InitializeDay(Data.LunisolarCalendar.LunisolarDaysRow day)
    {
      var date = SQLiteUtility.GetDate(day.Date);
      var ephemeris = AstronomyUtility.GetSunMoonEphemeris(date);
      day.LunarDay = AstronomyUtility.JapaneseCalendar.GetDayOfMonth(date);
      day.IsNewMoon = day.LunarDay == 1 ? 1 : 0;
      day.MoonPhase = (int)AstronomyUtility.GetMoonPhase(date.Year, date.Month, date.Day);
      day.IsFullMoon = Convert.ToInt32((MoonPhaseType)day.MoonPhase == MoonPhaseType.Full);
      day.Sunrise = SQLiteUtility.FormatTime(ephemeris.Sunrise);
      day.Sunset = SQLiteUtility.FormatTime(ephemeris.Sunset);
      day.Moonrise = SQLiteUtility.FormatTime(ephemeris.Moonrise);
      day.Moonset = SQLiteUtility.FormatTime(ephemeris.Moonset);
      MoonriseType moonrisetype;
      if ( ephemeris.Moonrise == null )
        moonrisetype = MoonriseType.NextDay;
      else
      if ( ephemeris.Moonrise < ephemeris.Moonset )
        moonrisetype = MoonriseType.BeforeSet;
      else
        moonrisetype = MoonriseType.AfterSet;
      day.MoonriseType = (int)moonrisetype;
      day.SeasonChange = 0;
      day.LunarMonth = 0;
      day.TorahEvents = 0;
    }

    /// <summary>
    /// Initialize the seasons.
    /// </summary>
    /// <param name="year">The year.</param>
    private void InitializeSeasons(int year)
    {
      var date = new AAPlus.Date();
      long jdYear, jdMonth, jdDay, jdHour, jdMinute;
      double second;
      void set(SeasonChangeType season, Func<long, double> action)
      {
        date.Set(action(year), true);
        date.Get(out jdYear, out jdMonth, out jdDay, out jdHour, out jdMinute, out second);
        var dateJulian = new DateTime((int)jdYear, (int)jdMonth, (int)jdDay, 0, 0, 0);
        string strDate = SQLiteUtility.GetDate((int)jdYear, (int)jdMonth, (int)jdDay);
        var day = LunisolarCalendar.LunisolarDays.FirstOrDefault(d => d.Date == strDate);
        if ( day != null ) day.SeasonChange = (int)season;
      }
      set(SeasonChangeType.SpringEquinox, AAPlus.EquinoxesAndSolstices.SpringEquinox);
      set(SeasonChangeType.SummerSolstice, AAPlus.EquinoxesAndSolstices.SummerSolstice);
      set(SeasonChangeType.AutumnEquinox, AAPlus.EquinoxesAndSolstices.AutumnEquinox);
      set(SeasonChangeType.WinterSolstice, AAPlus.EquinoxesAndSolstices.WinterSolstice);
    }

    /// <summary>
    /// Create the calendar items.
    /// </summary>
    private void AnalyseDays()
    {
      int progress = 0;
      int month = 0;
      int delta = 0;
      foreach ( Data.LunisolarCalendar.LunisolarDaysRow day in LunisolarCalendar.LunisolarDays.Rows )
      {
        if ( !UpdateProgress(progress++, Count, Translations.ProgressAnalyzeDays.GetLang()) ) return;
        if ( day.IsNewMoon == 1 ) AnalyzeDay(day, ref month, ref delta);
        day.LunarMonth = month;
        if ( day.LunarDay == 1 ) delta = 0;
        if ( (MoonriseType)day.MoonriseType == MoonriseType.NextDay
          && Program.Settings.TorahEventsCountAsMoon )
          delta = 1;
        day.LunarDay -= delta;
      }
    }

    /// <summary>
    /// Analyzes a day.
    /// </summary>
    /// <param name="day">The day.</param>
    /// <param name="monthMoon">[in,out] The current mooon month.</param>
    /// <param name="delta">[in,out] The current delta to skip days w/o moonrise.</param>
    private void AnalyzeDay(Data.LunisolarCalendar.LunisolarDaysRow day, ref int monthMoon, ref int delta)
    {
      DateTime calculate(DateTime thedate, int toadd, TorahEventType type)
      {
        if ( Program.Settings.TorahEventsCountAsMoon )
        {
          var rowStart = LunisolarCalendar.LunisolarDays.FirstOrDefault(d => d.Date == SQLiteUtility.GetDate(thedate));
          int index = LunisolarCalendar.LunisolarDays.Rows.IndexOf(rowStart);
          int count = 0;
          for ( int i = 0; i < toadd; i++, count++ )
            if ( (MoonriseType)LunisolarCalendar.LunisolarDays[index + i].MoonriseType == MoonriseType.NextDay )
              count++;
          thedate = thedate.AddDays(count);
        }
        else
          thedate = thedate.AddDays(toadd);
        var rowEnd = LunisolarCalendar.LunisolarDays.FirstOrDefault(d => d.Date == SQLiteUtility.GetDate(thedate));
        if ( rowEnd != null ) rowEnd.TorahEvents |= (int)type;
        return thedate;
      }
      var dateDay = SQLiteUtility.GetDate(day.Date);
      var equinoxe = ( from d in LunisolarCalendar.LunisolarDays
                       where dateDay.Year == SQLiteUtility.GetDate(day.Date).Year
                          && d.SeasonChange == (int)SeasonChangeType.SpringEquinox
                       select d ).First();
      var dateEquinox = SQLiteUtility.GetDate(equinoxe.Date);
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
      var date = dateDay;
      bool isNewYear = ( dateDay.Month == monthExuinoxe && dateDay.Day >= dayEquinoxe )
                    || ( dateDay.Month == monthExuinoxe + 1 );
      if ( equinoxe != null && ( monthMoon == 0 || monthMoon >= 12 ) && isNewYear )
      {
        monthMoon = 1;
        calculate(date, 0, TorahEventType.NewYearD1);
        calculate(date, TorahCelebrations.NewLambDay - 1, TorahEventType.NewYearD10);
        date = calculate(date, TorahCelebrations.PessahStartDay - 1, TorahEventType.PessahD1);
        calculate(date, TorahCelebrations.PessahLenght - 1, TorahEventType.PessahD7);
        date = calculate(date, TorahCelebrations.ChavouotLenght - 1, TorahEventType.ChavouotDiet);
        while ( date.DayOfWeek != (DayOfWeek)Program.Settings.ShabatDay )
          date = date.AddDays(1);
        calculate(date, 1, TorahEventType.Chavouot1);
        calculate(date, 1 + TorahCelebrations.ChavouotLenght - 1, TorahEventType.Chavouot2);
      }
      else
      if ( monthMoon > 0 )
        monthMoon++;
      if ( monthMoon == 7 )
      {
        date = calculate(date, 0, TorahEventType.YomTerouah);
        calculate(date, TorahCelebrations.YomHaKipourimDay - 1, TorahEventType.YomHaKipourim);
        date = calculate(date, TorahCelebrations.SoukotStartDay - 1, TorahEventType.SoukotD1);
        calculate(date, TorahCelebrations.SoukotLenght - 1, TorahEventType.SoukotD8);
      }
    }

  }

}
