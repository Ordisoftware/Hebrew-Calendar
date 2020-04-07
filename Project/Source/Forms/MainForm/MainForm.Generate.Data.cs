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
/// <edited> 2019-11 </edited>
using System;
using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using Ordisoftware.Core;
using AASharp;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private readonly List<string> GenerateErrors = new List<string>();

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
      GenerateErrors.Clear();
      try
      {
        UpdateButtons();
        CalendarText.Clear();
        CalendarMonth.LoadPresetHolidays = false;
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
          var lat = XmlConvert.ToDouble(Program.Settings.GPSLatitude);
          if ( lat < 0 && !Program.Settings.TorahEventsCountAsMoon )
            foreach ( var row in DataSet.LunisolarDays )
            {
              if ( (SeasonChange)row.SeasonChange == SeasonChange.SpringEquinox )
                row.SeasonChange = (int)SeasonChange.AutumnEquinox;
              else
              if ( (SeasonChange)row.SeasonChange == SeasonChange.AutumnEquinox )
                row.SeasonChange = (int)SeasonChange.SpringEquinox;
              else
              if ( (SeasonChange)row.SeasonChange == SeasonChange.WinterSolstice )
                row.SeasonChange = (int)SeasonChange.SummerSolstice;
              else
              if ( (SeasonChange)row.SeasonChange == SeasonChange.SummerSolstice )
                row.SeasonChange = (int)SeasonChange.WinterSolstice;
            }
          if ( IsGenerating ) CalendarText.Text = GenerateReport();
          if ( IsGenerating ) FillMonths();
        }
        finally
        {
          TableAdapterManager.UpdateAll(DataSet);
          LunisolarDaysBindingSource.DataSource = DataSet.LunisolarDays;
        }
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowAndAbort("Generating", ex.Message);
      }
      finally
      {
        Cursor = Cursors.Default;
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
      for ( int progress = 0, year = yearFirst; year <= yearLast; year++ )
      {
        for ( int month = 1; month <= 12; month++ )
          for ( int day = 1; day <= DateTime.DaysInMonth(year, month); day++ )
            try
            {
              if ( !UpdateProgress(progress++, ProgressCount, Translations.ProgressCreateDays.GetLang()) ) return;
              var row = DataSet.LunisolarDays.NewLunisolarDaysRow();
              row.Date = SQLiteUtility.GetDate(year, month, day);
              row.TorahEvents = 0;
              row.LunarMonth = 0;
              InitializeDay(row);
              DataSet.LunisolarDays.AddLunisolarDaysRow(row);
            }
            catch ( Exception ex )
            {
              GenerateErrors.Add($"{year}-{month}-{day}: [{nameof(PopulateDays)}] { ex.Message}");
            }
        InitializeSeasons(year);
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
        var date = SQLiteUtility.GetDate(day.Date);
        var ephemeris = AstronomyUtility.GetSunMoonEphemeris(date);
        day.LunarDay = AstronomyUtility.LunisolerCalendar.GetDayOfMonth(date);
        day.IsNewMoon = day.LunarDay == 1 ? 1 : 0;
        day.MoonPhase = (int)AstronomyUtility.GetMoonPhase(date.Year, date.Month, date.Day);
        day.IsFullMoon = Convert.ToInt32((MoonPhaseType)day.MoonPhase == MoonPhaseType.Full);
        day.Sunrise = SQLiteUtility.FormatTime(ephemeris.Sunrise);
        day.Sunset = SQLiteUtility.FormatTime(ephemeris.Sunset);
        day.Moonrise = SQLiteUtility.FormatTime(ephemeris.Moonrise);
        day.Moonset = SQLiteUtility.FormatTime(ephemeris.Moonset);
        MoonRise moonrisetype;
        if ( ephemeris.Moonrise == null )
          moonrisetype = MoonRise.NextDay;
        else
        if ( ephemeris.Moonrise < ephemeris.Moonset )
          moonrisetype = MoonRise.BeforeSet;
        else
          moonrisetype = MoonRise.AfterSet;
        day.MoonriseType = (int)moonrisetype;
        day.SeasonChange = 0;
        day.LunarMonth = 0;
        day.TorahEvents = 0;
      }
      catch ( Exception ex )
      {
        GenerateErrors.Add($"{day.Date}: [{nameof(InitializeDay)}] { ex.Message}");
      }
    }

    /// <summary>
    /// Initialize the seasons.
    /// </summary>
    /// <param name="year">The year.</param>
    private void InitializeSeasons(int year)
    {
      try
      {
        var date = new AASDate();
        long jdYear = 0, jdMonth = 0, jdDay = 0, jdHour = 0, jdMinute = 0;
        double second = 0;
        void set(SeasonChange season, Func<long, bool, double> action)
        {
          date.Set(action(year, true), true);
          date.Get(ref jdYear, ref jdMonth, ref jdDay, ref jdHour, ref jdMinute, ref second);
          var dateJulian = new DateTime((int)jdYear, (int)jdMonth, (int)jdDay, 0, 0, 0);
          string strDate = SQLiteUtility.GetDate((int)jdYear, (int)jdMonth, (int)jdDay);
          var day = DataSet.LunisolarDays.FirstOrDefault(d => d.Date == strDate);
          if ( day == null ) return;
          day.SeasonChange = (int)season;
        }
        var lat = XmlConvert.ToDouble(Program.Settings.GPSLatitude);
        if ( lat >= 0 || !Program.Settings.TorahEventsCountAsMoon )
        {
          set(SeasonChange.SpringEquinox, AASEquinoxesAndSolstices.NorthwardEquinox);
          set(SeasonChange.SummerSolstice, AASEquinoxesAndSolstices.NorthernSolstice);
          set(SeasonChange.AutumnEquinox, AASEquinoxesAndSolstices.SouthwardEquinox);
          set(SeasonChange.WinterSolstice, AASEquinoxesAndSolstices.SouthernSolstice);
        }
        else
        {
          set(SeasonChange.SpringEquinox, AASEquinoxesAndSolstices.SouthwardEquinox);
          set(SeasonChange.SummerSolstice, AASEquinoxesAndSolstices.SouthernSolstice);
          set(SeasonChange.AutumnEquinox, AASEquinoxesAndSolstices.NorthwardEquinox);
          set(SeasonChange.WinterSolstice, AASEquinoxesAndSolstices.NorthernSolstice);
        }
      }
      catch ( Exception ex )
      {
        GenerateErrors.Add($"{year}: [{nameof(InitializeSeasons)}] { ex.Message}");
      }
    }

    /// <summary>
    /// Create the calendar items.
    /// </summary>
    private void AnalyseDays()
    {
      int progress = 0;
      int month = 0;
      int delta = 0;
      foreach ( Data.DataSet.LunisolarDaysRow day in DataSet.LunisolarDays.Rows )
        try
        {
          if ( !UpdateProgress(progress++, ProgressCount, Translations.ProgressAnalyzeDays.GetLang()) ) return;
          if ( day.IsNewMoon == 1 ) AnalyzeDay(day, ref month);
          day.LunarMonth = month;
          if ( day.IsNewMoon == 1 ) delta = 0;
          if ( (MoonRise)day.MoonriseType == MoonRise.NextDay
            && Program.Settings.TorahEventsCountAsMoon )
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
    /// <param name="delta">[in,out] The current delta to skip days w/o moonrise.</param>
    private void AnalyzeDay(Data.DataSet.LunisolarDaysRow day, ref int monthMoon)
    {
      DateTime calculate(DateTime thedate, int toadd, TorahEvent type, bool forceSunOmer)
      {
        if ( Program.Settings.TorahEventsCountAsMoon )
        {
          var rowStart = DataSet.LunisolarDays.FirstOrDefault(d => d.Date == SQLiteUtility.GetDate(thedate));
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
        var rowEnd = DataSet.LunisolarDays.FirstOrDefault(d => d.Date == SQLiteUtility.GetDate(thedate));
        if ( rowEnd != null ) rowEnd.TorahEvents |= (int)type;
        return thedate;
      }
      try
      {
        var dateDay = SQLiteUtility.GetDate(day.Date);
        var equinoxe = ( from d in DataSet.LunisolarDays
                         where dateDay.Year == SQLiteUtility.GetDate(day.Date).Year
                            && d.SeasonChange == (int)SeasonChange.SpringEquinox
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
        int delta = Program.Settings.TorahEventsCountAsMoon ? 0 : 1;
        bool isNewYear = ( dateDay.Month == monthExuinoxe && dateDay.Day >= dayEquinoxe )
                      || ( dateDay.Month == monthExuinoxe + 1 );
        if ( equinoxe != null && ( monthMoon == 0 || monthMoon >= 12 ) && isNewYear )
        {
          monthMoon = 1;
          calculate(date, 0, TorahEvent.NewYearD1, false);
          calculate(date, TorahCelebrations.NewLambDay - 1, TorahEvent.NewYearD10, false);
          date = calculate(date, TorahCelebrations.PessahStartDay - 1 + delta, TorahEvent.PessahD1, false);
          calculate(date, TorahCelebrations.PessahLenght - 1, TorahEvent.PessahD7, false);
          date = calculate(date, TorahCelebrations.ChavouotLenght - 1 - delta, TorahEvent.ChavouotDiet, true);
          while ( date.DayOfWeek != (DayOfWeek)Program.Settings.ShabatDay )
            date = date.AddDays(1);
          try
          {
            calculate(date, 1, TorahEvent.Chavouot1, true);
            calculate(date, 1 + TorahCelebrations.ChavouotLenght - 1, TorahEvent.Chavouot2, false);
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
          date = calculate(date, 0, TorahEvent.YomTerouah, false);
          calculate(date, TorahCelebrations.YomHaKipourimDay - 1, TorahEvent.YomHaKipourim, false);
          date = calculate(date, TorahCelebrations.SoukotStartDay - 1, TorahEvent.SoukotD1, false);
          calculate(date, TorahCelebrations.SoukotLenght - 1, TorahEvent.SoukotD8, false);
        }
      }
      catch ( Exception ex )
      {
        GenerateErrors.Add($"{day.Date}: [{nameof(AnalyzeDay)}] { ex.Message}");
      }
    }

  }

}
