/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using CodeProjectCalendar.NET;

partial class MainForm
{

  [SuppressMessage("Performance", "U2U1211:Avoid memory leaks", Justification = "N/A")]
  static private readonly Dictionary<Color, Dictionary<Color, Color>> ColorMixesTwoKeys = new();

  [SuppressMessage("Performance", "U2U1211:Avoid memory leaks", Justification = "N/A")]
  static private readonly Dictionary<Color, Dictionary<Color, Dictionary<Color, Color>>> ColorMixesThreeKeys = new();

  private Brush[,,] DayBrushes;

  public Brush GetDayBrush(int counter, int month, int year)
  {
    int indexYear = YearLast - year;
    return indexYear < 0 || indexYear > DayBrushes.GetUpperBound(0)
           ? Brushes.Transparent
           : DayBrushes[indexYear, month, counter];
  }

  [SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
  [SuppressMessage("Performance", "U2U1209:Use dictionaries efficiently", Justification = "N/A")]
  static public Color MixColor(Color color1, Color color2)
  {
    bool hasFirstKey = ColorMixesTwoKeys.ContainsKey(color1);
    bool hasSecondKey = hasFirstKey && ColorMixesTwoKeys[color1].ContainsKey(color2);
    if ( hasSecondKey ) return ColorMixesTwoKeys[color1][color2];
    int r = Math.Min(( color1.R + color2.R ) / 2, 255);
    int g = Math.Min(( color1.G + color2.G ) / 2, 255);
    int b = Math.Min(( color1.B + color2.B ) / 2, 255);
    var color = Color.FromArgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
    if ( !hasFirstKey ) ColorMixesTwoKeys.Add(color1, new Dictionary<Color, Color>());
    ColorMixesTwoKeys[color1].Add(color2, color);
    return color;
  }

  [SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
  [SuppressMessage("Performance", "U2U1209:Use dictionaries efficiently", Justification = "N/A")]
  static public Color MixColor(Color color1, Color color2, Color color3)
  {
    bool hasFirstKey = ColorMixesThreeKeys.ContainsKey(color1);
    bool hasSecondKey = hasFirstKey && ColorMixesThreeKeys[color1].ContainsKey(color2);
    bool hasThirdKey = hasSecondKey && ColorMixesThreeKeys[color1][color2].ContainsKey(color3);
    if ( hasThirdKey ) return ColorMixesThreeKeys[color1][color2][color3];
    int r = Math.Min(( color1.R + color2.R + color3.R ) / 3, 255);
    int g = Math.Min(( color1.G + color2.G + color3.G ) / 3, 255);
    int b = Math.Min(( color1.B + color2.B + color3.B ) / 3, 255);
    var color = Color.FromArgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
    if ( !hasFirstKey ) ColorMixesThreeKeys.Add(color1, new Dictionary<Color, Dictionary<Color, Color>>());
    if ( !hasSecondKey ) ColorMixesThreeKeys[color1].Add(color2, new Dictionary<Color, Color>());
    ColorMixesThreeKeys[color1][color2].Add(color3, color);
    return color;
  }

  private void InitializeYearsInterval()
  {
    DateFirst = LunisolarDays.FirstOrDefault()?.Date ?? default;
    DateLast = LunisolarDays.LastOrDefault()?.Date ?? default;
    if ( DateFirst == DateTime.MinValue || DateLast == DateTime.MinValue || DateFirst >= DateLast )
    {
      YearFirst = DateTime.Now.Year - 1;
      YearLast = Settings.AutoGenerateYearsInternal - 1;
    }
    else
    {
      YearFirst = DateFirst.Year;
      YearLast = DateLast.Year;
    }
    YearsInterval = DateLast.Year - DateFirst.Year + 1;
    YearsIntervalArray = Enumerable.Range(DateFirst.Year, YearsInterval).ToArray();
  }

  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  public void FillMonths()
  {
    Globals.ChronoShowData.Restart();
    try
    {
      InitializeYearsInterval();
      bool dateSingleLine = Settings.CalendarHebrewDateSingleLine;
      bool omerSun = !Settings.TorahEventsCountAsMoon;
      bool omerSunAndNotDateSingleLine = omerSun && !dateSingleLine;
      bool useUnicode = Settings.HebrewNamesInUnicode;
      bool isCelebrationWeekStart = false;
      bool isCelebrationWeekEnd = false;
      if ( LunisolarDays.Count == 0 ) return;
      DayBrushes = new Brush[YearsInterval, 13, 35];
      var fontEvent = new Font("Calibri", Settings.MonthViewFontSize);
      var fontEventHebrew = new Font("Calibri", Settings.MonthViewFontSize + 2);
      string strRise = AppTranslations.EphemerisCodes.GetLang(Ephemeris.Rise);
      string strSet = AppTranslations.EphemerisCodes.GetLang(Ephemeris.Set);
      LoadingForm.Instance.Initialize(AppTranslations.ProgressFillMonths.GetLang(),
                                      LunisolarDays.Count,
                                      Program.LoadingFormLoadDB);
      foreach ( var row in LunisolarDays )
        try
        {
          LoadingForm.Instance.DoProgress();
          // Initialize
          var ev = row.TorahEvent;
          var season = row.SeasonChange;
          if ( ev == TorahCelebrationDay.PessahD1
            || ev == TorahCelebrationDay.SoukotD1
            || ev == TorahCelebrationDay.ChavouotDiet )
            isCelebrationWeekStart = true;
          isCelebrationWeekEnd = ev == TorahCelebrationDay.PessahD7
                              || ev == TorahCelebrationDay.SoukotD8
                              || ev == TorahCelebrationDay.Chavouot1;
          var date = row.Date;
          // Colors
          Color? color1 = null;
          Color? color2 = null;
          Color? color3 = null;
          if ( season != SeasonChange.None )
            color1 = Settings.EventColorSeason;
          if ( row.IsNewMoon && ev == TorahCelebrationDay.None )
            color2 = Settings.EventColorMonth;
          else
          if ( row.IsNewMoon && ev == TorahCelebrationDay.NewYearD1 )
            color2 = MixColor(Settings.EventColorMonth,
                              Settings.EventColorSeason,
                              Settings.EventColorNext);
          else
          if ( isCelebrationWeekStart || ev != TorahCelebrationDay.None )
            color2 = Settings.EventColorTorah;
          if ( row.Date.DayOfWeek == (DayOfWeek)Settings.ShabatDay )
            color3 = Settings.EventColorShabat;
          if ( color1 is not null && color2 is not null && color3 is not null )
            color1 = MixColor(color1.Value, color2.Value, color3.Value);
          else
          if ( color1 is not null && color2 is not null && color3 is null )
            color1 = MixColor(color1.Value, color2.Value);
          else
          if ( color1 is not null && color2 is null && color3 is not null )
            color1 = MixColor(color1.Value, color3.Value);
          else
          if ( color1 is null && color2 is not null && color3 is not null )
            color1 = MixColor(color2.Value, color3.Value);
          else
          if ( color2 is not null )
            color1 = color2;
          else
          if ( color3 is not null )
            color1 = color3;
          else
            color1 ??= Settings.MonthViewBackColor;
          DayBrushes[YearLast - date.Year, date.Month, date.Day] = SolidBrushesPool.Get(color1.Value);
          if ( isCelebrationWeekEnd )
            isCelebrationWeekStart = false;
          int rank = 0;
          // Moon/Sun ephemeris and date
          Color colorEphemeris = row.IsNewMoon
            ? Settings.CalendarColorTorahEvent
            : row.IsFullMoon
              ? Settings.CalendarColorFullMoon
              : Settings.CalendarColorMoon;
          string strDate = string.Empty;
          if ( dateSingleLine && ( omerSun || row.Moonrise is not null ) )
          {
            var color = row.IsNewMoon ? Settings.CalendarColorTorahEvent : Settings.MonthViewTextColor;
            add(color, row.DayAndMonthFormattedText, useUnicode);
          }
          else
            strDate = " " + row.DayAndMonthFormattedText;
          if ( omerSun )
          {
            add(colorEphemeris, $"{strRise}{row.SunriseAsString}{strDate}");
            add(Settings.MonthViewTextColor, strSet + row.SunsetAsString);
          }
          else
          {
            if ( row.MoonriseOccuring == MoonriseOccurring.AfterSet )
            {
              if ( row.Moonset is not null )
                add(Settings.MonthViewTextColor, strSet + row.MoonsetAsString);
              if ( row.MoonriseOccuring != MoonriseOccurring.NextDay )
                add(colorEphemeris, $"{strRise}{row.MoonriseAsString}{strDate}");
              else
              if ( omerSunAndNotDateSingleLine )
                add(colorEphemeris, row.DayAndMonthFormattedText);
            }
            else
            {
              if ( row.MoonriseOccuring != MoonriseOccurring.NextDay )
                add(colorEphemeris, $"{strRise}{row.MoonriseAsString}{strDate}");
              else
              if ( omerSunAndNotDateSingleLine )
                add(colorEphemeris, row.DayAndMonthFormattedText);
              if ( row.Moonset is not null )
                add(Settings.MonthViewTextColor, strSet + row.MoonsetAsString);
            }
          }
          // Torah
          add(Settings.CalendarColorTorahEvent, row.TorahEventText, useUnicode, useUnicode);
          // Season
          if ( row.SeasonChange != 0 )
            add(Settings.CalendarColorSeason, AppTranslations.SeasonChanges.GetLang(row.SeasonChange)/*, TODO useUnicode*/);
          // Parashah
          if ( Settings.CalendarShowParashah && !string.IsNullOrEmpty(row.ParashahID) )
          {
            var parashah = ParashotFactory.Instance.Get(row.ParashahID);
            if ( parashah is null )
              add(Settings.CalendarColorParashah, SysTranslations.UndefinedSlot.GetLang(), useUnicode, useUnicode);
            else
            {
              add(Settings.CalendarColorParashah, parashah.ToStringShort(false, row.HasLinkedParashah), useUnicode, useUnicode);
              if ( Settings.CalendarParashahWithBookAndFullRef )
                add(Settings.CalendarColorParashah, $"{parashah.ToStringBookAndReferences()}", useUnicode, useUnicode);
            }
          }
          // Add info
          void add(Color color, string text, bool isHebrew = false, bool isTorah = false)
          {
            if ( string.IsNullOrEmpty(text) ) return;
            var item = new CustomEvent
            {
              Date = date,
              EventFont = isHebrew ? fontEventHebrew : fontEvent,
              IsHebrew = isHebrew,
              IsParashah = isTorah
            };
            if ( Settings.UseColors )
            {
              item.EventTextColor = color;
            }
            else
            {
              item.EventColor = Color.Transparent;
              item.EventTextColor = MonthlyCalendar.ForeColor;
            }
            item.EventText = text;
            item.Rank = rank++;
            item.IgnoreTimeComponent = true;
            if ( Settings.UseColors )
              item.EventColor = ( (SolidBrush)GetDayBrush(item.Date.Day, item.Date.Month, item.Date.Year) ).Color;
            MonthlyCalendar.AddEvent(item);
          }
        }
        catch ( Exception ex )
        {
          if ( ApplicationDatabase.Instance.AddGenerateErrorAndCheckIfTooMany(nameof(FillMonths), row.DateAsString, ex) )
          {
            if ( !Globals.IsGenerating && ApplicationDatabase.Instance.LastGenerationErrors.Count != 0 )
              ApplicationDatabase.Instance.ShowLastGenerationErrors(Text);
            return;
          }
        }
    }
    finally
    {
      Globals.ChronoShowData.Stop();
      Settings.BenchmarkFillCalendar = Globals.ChronoShowData.ElapsedMilliseconds;
      SystemManager.TryCatch(Settings.Store);
    }
  }

}
