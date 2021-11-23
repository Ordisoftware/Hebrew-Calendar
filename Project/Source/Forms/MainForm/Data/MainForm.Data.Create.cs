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
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  [Serializable]
  public class TooManyErrorsException : Exception
  {
    public TooManyErrorsException()
    {
    }
    public TooManyErrorsException(string message) : base(message)
    {
    }
    public TooManyErrorsException(string message, Exception innerException) : base(message, innerException)
    {
    }
    protected TooManyErrorsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }

  public const int MaxGenerateErrors = 20;

  private readonly List<string> GenerateErrors = new();

  private int ProgressCount;

  private bool AddGenerateErrorAndCheckIfTooMany(string method, string date, Exception ex)
  {
    var einfo = new ExceptionInfo(this, ex);
    GenerateErrors.Add($"{GenerateErrors.Count + 1:00}) " +
                       $"{method,-13} {date} : " +
                       $"{einfo.SingleLineText}");
    return GenerateErrors.Count >= MaxGenerateErrors;
  }

  /// <summary>
  /// Creates the calendar days items.
  /// </summary>
  /// <param name="yearFirst">The first year.</param>
  /// <param name="yearLast">The last year.</param>
  private string CreateData(int yearFirst, int yearLast)
  {
    Globals.IsGenerating = true;
    PanelViewText.Parent = null;
    PanelViewMonth.Parent = null;
    PanelViewGrid.Parent = null;
    var cursor = Cursor;
    Cursor = Cursors.WaitCursor;
    Globals.ChronoCreateData.Restart();
    LunisolarDaysBindingSource.DataSource = null;
    ApplicationDatabase.Instance.BeginTransaction();
    try
    {
      UpdateButtons();
      LabelSubTitleGPS.Text = SysTranslations.ProgressCreatingData.GetLang();
      CalendarText.Clear();
      CalendarMonth.TheEvents.Clear();
      ApplicationDatabase.Instance.DeleteAll();
      var d1 = new DateTime(yearFirst, 1, DateTime.DaysInMonth(yearFirst, 1));
      var d2 = new DateTime(yearLast, 12, DateTime.DaysInMonth(yearLast, 12));
      ProgressCount = (int)( d2 - d1 ).TotalDays;
      try
      {
        if ( Globals.IsGenerating )
          if ( PopulateDays(yearFirst, yearLast) )
            if ( Globals.IsGenerating )
              if ( AnalyseDays() )
                if ( Globals.IsGenerating )
                  try
                  {
                    CalendarText.Text = GenerateReportText(true);
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
            ApplicationDatabase.Instance.Commit();
            LunisolarDaysBindingSource.DataSource = ApplicationDatabase.Instance.LunisolarDays;
          }
      }
    }
    catch ( Exception ex )
    {
      ApplicationDatabase.Instance.Rollback();
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
  /// Creates the days.
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
        for ( int month = 1; month <= 12; month++ )
          for ( int day = 1; day <= DateTime.DaysInMonth(year, month); day++ )
            try
            {
              LoadingForm.Instance.DoProgress();
              var row = new LunisolarDay { Date = new DateTime(year, month, day) };
              if ( !InitializeDay(row) ) break;
              LunisolarDays.Add(row);
            }
            catch ( Exception ex )
            {
              if ( AddGenerateErrorAndCheckIfTooMany(nameof(PopulateDays), $"{year}-{month:00}-{day:00}", ex) )
                return false;
            }
    }
    finally
    {
      Chrono.Stop();
      Settings.BenchmarkPopulateDays = Chrono.ElapsedMilliseconds;
    }
    return true;
  }

  private TimeSpan? DelayMoonrise;
  private bool isMoonriseDelayed;

  /// <summary>
  /// Initializes a day.
  /// </summary>
  private bool InitializeDay(LunisolarDay day)
  {
    try
    {
      var data = CalendarDates.Instance[day.Date];
      var ephemeris = data.Ephemerisis;
      if ( isMoonriseDelayed )
      {
        ephemeris.Moonrise = DelayMoonrise;
        isMoonriseDelayed = false;
      }
      else
      if ( !CalendarDates.Instance[day.Date.AddDays(1)].Ephemerisis.Moonrise.HasValue )
        if ( ephemeris.Moonrise == new TimeSpan(0) )
        {
          DelayMoonrise = ephemeris.Moonrise;
          ephemeris.Moonrise = null;
          isMoonriseDelayed = true;
        }
      day.LunarDay = data.MoonDay;
      if ( isMoonriseDelayed ) day.LunarDay++;
      day.LunarMonth = 0;
      day.IsNewMoon = day.LunarDay == 1;
      day.MoonPhase = data.MoonPhase;
      day.IsFullMoon = day.MoonPhase == MoonPhase.Full;
      day.Sunrise = SQLiteDate.Add(ephemeris.Sunrise, day.Date);
      day.Sunset = SQLiteDate.Add(ephemeris.Sunset, day.Date);
      day.Moonrise = SQLiteDate.Add(ephemeris.Moonrise, day.Date);
      day.Moonset = SQLiteDate.Add(ephemeris.Moonset, day.Date);
      day.DateAsString = SQLiteDate.ToString(day.Date);
      day.SunriseAsString = SQLiteDate.ToString(ephemeris.Sunrise);
      day.SunsetAsString = SQLiteDate.ToString(ephemeris.Sunset);
      day.MoonriseAsString = SQLiteDate.ToString(ephemeris.Moonrise);
      day.MoonsetAsString = SQLiteDate.ToString(ephemeris.Moonset);
      MoonriseOccurring moonrisetype;
      if ( ephemeris.Moonrise == null )
        moonrisetype = MoonriseOccurring.NextDay;
      else
      if ( ephemeris.Moonrise < ephemeris.Moonset )
        moonrisetype = MoonriseOccurring.BeforeSet;
      else
        moonrisetype = MoonriseOccurring.AfterSet;
      day.MoonriseOccuring = moonrisetype;
      day.SeasonChange = data.RealSeasonChange;
      day.TorahEvent = TorahCelebrationDay.None;
      day.TorahEventText = string.Empty;
      day.ParashahID = string.Empty;
      day.LinkedParashahID = string.Empty;
    }
    catch ( Exception ex )
    {
      if ( AddGenerateErrorAndCheckIfTooMany(nameof(InitializeDay), day.DateAsString, ex) )
        return false;
    }
    return true;
  }

  /// <summary>
  /// Creates the calendar items.
  /// </summary>
  private bool AnalyseDays()
  {
    LoadingForm.Instance.Initialize(AppTranslations.ProgressAnalyzeDays.GetLang(),
                                    ProgressCount,
                                    Program.LoadingFormGenerate);
    int month = 0;
    int delta = 0;
    int indexParashah = -1;
    var shabatDay = (DayOfWeek)Settings.ShabatDay;
    bool shabatMutex = false;
    int simhatTorah = Settings.UseSimhatTorahOutside ? 23 : 22;
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
          if ( day.IsNewMoon && !AnalyzeDay(day, date, ref month) )
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
          if ( AddGenerateErrorAndCheckIfTooMany(nameof(AnalyseDays), day.DateAsString, ex) )
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
        remap(day);
        indexParashah = 0;
        dayRemap1 = day;
      }
      else
      if ( !shabatMutex && date.DayOfWeek == shabatDay && indexParashah >= 0 && indexParashah < parashot.Count )
      {
        day.ParashahID = parashot[indexParashah].ID;
        indexParashah++;
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
  private bool AnalyzeDay(LunisolarDay day, DateTime dayDate, ref int monthMoon)
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
        if ( row != null )
          if ( row.MoonriseOccuring == MoonriseOccurring.NextDay )
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
        return dateRow.Year == dayDate.Year
            && CalendarDates.Instance[dateRow].TorahSeasonChange == SeasonChange.SpringEquinox;
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
      if ( AddGenerateErrorAndCheckIfTooMany(nameof(AnalyzeDay), day.DateAsString, ex) )
        return false;
    }
    return true;
  }

}
