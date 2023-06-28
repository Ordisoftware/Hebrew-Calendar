/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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

[Serializable]
[SuppressMessage("Critical Code Smell", "S3871:Exception types should be \"public\"", Justification = "Analysis error")]
file class TooManyErrorsException : Exception
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

partial class ApplicationDatabase
{

  static public int MaxGenerateErrors { get; set; } = Globals.MaxErrorsAllowed;

  private const int ErrorFontSize = 8;

  public readonly List<string> LastGenerationErrors = new();

  public bool AddGenerateErrorAndCheckIfTooMany(string method, string date, Exception ex)
  {
    var einfo = new ExceptionInfo(this, ex);
    LastGenerationErrors.Add($"{LastGenerationErrors.Count + 1:00}) " +
                             $"{method,-13} {date} : " +
                             $"{einfo.SingleLineText}");
    return LastGenerationErrors.Count >= MaxGenerateErrors;
  }

  public string ShowLastGenerationErrors(string title)
  {
    string errors = LastGenerationErrors.AsMultiLine();
    LastGenerationErrors.Clear();
    errors = Settings.GetGPSText() + Globals.NL2 + errors;
    DebugManager.Trace(LogTraceEvent.Error, errors);
    using ( var form = new ShowTextForm(title, errors,
                                        false, true,
                                        MessageBoxEx.DefaultWidthLarge, MessageBoxEx.DefaultHeightLarge,
                                        false, false) )
    {
      form.TextBox.Font = new Font("Courier new", ErrorFontSize);
      form.ShowDialog();
    }
    if ( DisplayManager.QueryYesNo(SysTranslations.ContactSupport.GetLang()) )
      ExceptionForm.Run(new ExceptionInfo(this, new TooManyErrorsException(errors)));
    return errors;
  }

  /// <summary>
  /// Creates the days.
  /// </summary>
  /// <param name="yearFirst">The first year.</param>
  /// <param name="yearLast">The last year.</param>
  public bool PopulateDays(int yearFirst, int yearLast)
  {
    var d1 = new DateTime(yearFirst, 1, DateTime.DaysInMonth(yearFirst, 1));
    var d2 = new DateTime(yearLast, 12, DateTime.DaysInMonth(yearLast, 12));
    int progressCount = (int)( d2 - d1 ).TotalDays;
    LoadingForm.Instance.Initialize(AppTranslations.ProgressCreateDays.GetLang(),
                                    progressCount,
                                    Program.LoadingFormGenerate);
    var chrono = new Stopwatch();
    chrono.Start();
    try
    {
      LastGenerationErrors.Clear();
      for ( int year = yearFirst; year <= yearLast; year++ )
        for ( int month = 1; month <= 12; month++ )
          for ( int day = 1; day <= DateTime.DaysInMonth(year, month); day++ )
            try
            {
              LoadingForm.Instance.DoProgress();
              var row = new LunisolarDayRow { Date = new DateTime(year, month, day) };
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
      chrono.Stop();
      Settings.BenchmarkPopulateDays = chrono.ElapsedMilliseconds;
    }
    return Globals.IsGenerating && Settings.UseSodHaibour
      ? Instance.AnalyseDaysSod(progressCount)
      : Instance.AnalyseDaysOmer(progressCount);
  }

  private TimeSpan? DelayMoonrise;

  private bool IsMoonriseDelayed;

  /// <summary>
  /// Initializes a day.
  /// </summary>
  private bool InitializeDay(LunisolarDayRow day)
  {
    try
    {
      var data = CalendarDates.Instance[day.Date];
      var ephemeris = data.Ephemeris;
      if ( IsMoonriseDelayed )
      {
        ephemeris.Moonrise = DelayMoonrise;
        IsMoonriseDelayed = false;
      }
      else
      if ( CalendarDates.Instance[day.Date.AddDays(1)].Ephemeris.Moonrise is null )
        if ( ephemeris.Moonrise == new TimeSpan(0) )
        {
          DelayMoonrise = ephemeris.Moonrise;
          ephemeris.Moonrise = null;
          IsMoonriseDelayed = true;
        }
      day.LunarDay = data.MoonDay;
      if ( IsMoonriseDelayed ) day.LunarDay++;
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
      if ( ephemeris.Moonrise is null )
        moonrisetype = MoonriseOccurring.NextDay;
      else
      if ( ephemeris.Moonrise < ephemeris.Moonset )
        moonrisetype = MoonriseOccurring.BeforeSet;
      else
        moonrisetype = MoonriseOccurring.AfterSet;
      day.MoonriseOccurring = moonrisetype;
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

}
