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
/// <created> 2016-04 </created>
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase
{

  /// <summary>
  /// Creates the calendar items using moon or sun omer.
  /// </summary>
  public bool AnalyseDaysOmer(int progressCount)
  {
    LoadingForm.Instance.Initialize(AppTranslations.ProgressAnalyzeDays.GetLang(),
                                    progressCount,
                                    Program.LoadingFormGenerate);
    int month = 0;
    int delta = 0;
    int indexParashah = -1;
    var shabatDay = (DayOfWeek)Settings.ShabatDay;
    bool shabatMutex = false;
    int simhatTorah = Settings.UseSimhatTorahOutside ? 23 : 22;
    int simhatTorahRoot = simhatTorah;
    LunisolarDay dayRemap1 = null;
    LunisolarDay dayRemap2 = null;
    DateTime date;
    var Chrono = new Stopwatch();
    Chrono.Start();
    var parashot = ParashotFactory.Instance?.All?.ToList() ?? new List<Parashah>();
    try
    {
      foreach ( var day in LunisolarDays )
        try
        {
          LoadingForm.Instance.DoProgress();
          date = day.Date;
          if ( day.IsNewMoon && !AnalyzeDayOmer(day, date, ref month) )
            break;
          day.LunarMonth = month;
          if ( day.IsNewMoon )
            delta = 0;
          if ( day.MoonriseOccuring == MoonriseOccurring.NextDay && Settings.TorahEventsCountAsMoon )
            delta = 1;
          day.LunarDay -= delta;
          checkParashah(day);
          if ( day.TorahEvent != TorahCelebrationDay.None )
            day.TorahEventText = AppTranslations.TorahCelebrationDays[day.TorahEvent].GetLang();
          else
            day.TorahEventText = day.GetWeekLongCelebrationIntermediateDay().Text;
        }
        catch ( Exception ex )
        {
          if ( AddGenerateErrorAndCheckIfTooMany(nameof(AnalyseDaysOmer), day.DateAsString, ex) )
            return false;
        }
    }
    finally
    {
      Chrono.Stop();
      Settings.BenchmarkAnalyseDays = Chrono.ElapsedMilliseconds;
    }
    return true;
    //
    void checkParashah(LunisolarDay day)
    {
      if ( day.TorahEvent == TorahCelebrationDay.PessahD1 )
        shabatMutex = true;
      if ( day.LunarMonth == 7 && day.LunarDay == simhatTorah )
      {
        if ( day.Date.DayOfWeek == shabatDay )
          simhatTorah++;
        else
        {
          remap(day);
          indexParashah = 0;
          dayRemap1 = day;
        }
      }
      else
      if ( !shabatMutex && date.DayOfWeek == shabatDay && indexParashah >= 0 && indexParashah < parashot.Count )
      {
        day.ParashahID = parashot[indexParashah].ID;
        indexParashah++;
        if ( simhatTorahRoot != simhatTorah )
          simhatTorah = simhatTorahRoot;
      }
      if ( day.TorahEvent == TorahCelebrationDay.PessahD7 )
        shabatMutex = false;
    }
    //
    void remap(LunisolarDay day)
    {
      if ( indexParashah > 0 && indexParashah < parashot.Count )
      {
        dayRemap2 = day;
        var query = from row in LunisolarDays
                    where row.Date >= dayRemap1.Date
                       && row.Date <= dayRemap2.Date
                       && !row.ParashahID.IsNullOrEmpty()
                    select row;
        indexParashah = 0;
        foreach ( var row in query )
          if ( indexParashah >= parashot.Count )
            row.ParashahID = string.Empty;
          else
          {
            var parashah = parashot[indexParashah];
            row.ParashahID = parashah.ID;
            if ( parashah.IsLinkedToNext )
            {
              indexParashah++;
              row.LinkedParashahID = parashot[indexParashah].ID;
            }
            indexParashah++;
          }
      }
    }
  }

  /// <summary>
  /// Analyzes a day.
  /// </summary>
  private bool AnalyzeDayOmer(LunisolarDay day, DateTime dayDate, ref int monthMoon)
  {
    DateTime calculate(DateTime thedate, int toadd, TorahCelebrationDay type, bool forceSunOmer)
    {
      if ( Settings.TorahEventsCountAsMoon )
      {
        var rowStart = LunisolarDays.Find(d => d.Date == thedate);
        int index = LunisolarDays.IndexOf(rowStart);
        int count = 0;
        if ( forceSunOmer )
          count = toadd;
        else
          for ( int i = 0; i < toadd; i++, count++ )
            if ( LunisolarDays[index + i].MoonriseOccuring == MoonriseOccurring.NextDay )
              count++;
        thedate = thedate.AddDays(count);
        var row = LunisolarDays.Find(d => d.Date == thedate);
        if ( row?.MoonriseOccuring == MoonriseOccurring.NextDay )
          thedate = thedate.AddDays(1);
      }
      else
        thedate = thedate.AddDays(toadd);
      var rowEnd = LunisolarDays.Find(d => d.Date == thedate);
      if ( rowEnd != null )
        rowEnd.TorahEvent = type;
      return thedate;
    }
    try
    {
      bool check(LunisolarDay row)
      {
        var dateRow = row.Date;
        return dateRow.Year == dayDate.Year && CalendarDates.Instance[dateRow].TorahSeasonChange == SeasonChange.SpringEquinox;
      }
      var equinoxe = LunisolarDays.First(d => check(d));
      var dateEquinox = equinoxe.Date;
      int monthExuinoxe = dateEquinox.Month;
      int dayEquinoxe = dateEquinox.Day - TorahCelebrationSettings.NewLambDay;
      if ( dayEquinoxe < 1 )
      {
        monthExuinoxe--;
        dayEquinoxe += 30;
      }
      int delta = Settings.TorahEventsCountAsMoon ? 0 : 1;
      bool isNewYear = ( dayDate.Month == monthExuinoxe && dayDate.Day >= dayEquinoxe )
                    || ( dayDate.Month == monthExuinoxe + 1 );
      if ( isNewYear && ( monthMoon == 0 || monthMoon >= 12 ) )
      {
        monthMoon = 1;
        calculate(dayDate, 0, TorahCelebrationDay.NewYearD1, false);
        calculate(dayDate, TorahCelebrationSettings.NewLambDay - 1, TorahCelebrationDay.NewYearD10, false);
        dayDate = calculate(dayDate, TorahCelebrationSettings.PessahStartDay - 1 + delta, TorahCelebrationDay.PessahD1, false);
        calculate(dayDate, TorahCelebrationSettings.PessahLenght - 1, TorahCelebrationDay.PessahD7, false);
        dayDate = calculate(dayDate, TorahCelebrationSettings.ChavouotLenght - 1 - delta, TorahCelebrationDay.ChavouotDiet, true);
        var shabatDay = (DayOfWeek)Settings.ShabatDay;
        while ( dayDate.DayOfWeek != shabatDay )
          dayDate = dayDate.AddDays(1);
        SystemManager.TryCatch(() =>
        {
          calculate(dayDate, 1, TorahCelebrationDay.Chavouot1, true);
          calculate(dayDate, 1 + TorahCelebrationSettings.ChavouotLenght - 1, TorahCelebrationDay.Chavouot2, false);
        });
      }
      else
      if ( monthMoon > 0 )
        monthMoon++;
      if ( monthMoon == TorahCelebrationSettings.YomsMonth )
      {
        dayDate = calculate(dayDate, 0, TorahCelebrationDay.YomTerouah, false);
        calculate(dayDate, TorahCelebrationSettings.YomHaKipourimDay - 1, TorahCelebrationDay.YomHaKipourim, false);
        dayDate = calculate(dayDate, TorahCelebrationSettings.SoukotStartDay - 1, TorahCelebrationDay.SoukotD1, false);
        calculate(dayDate, TorahCelebrationSettings.SoukotLenght - 1, TorahCelebrationDay.SoukotD8, false);
      }
    }
    catch ( Exception ex )
    {
      if ( AddGenerateErrorAndCheckIfTooMany(nameof(AnalyzeDayOmer), day.DateAsString, ex) )
        return false;
    }
    return true;
  }

}