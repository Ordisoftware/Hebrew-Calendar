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

using System.Drawing;
using CodeProjectCalendar.NET;
using Ordisoftware.Core;
using Ordisoftware.Hebrew.Calendar.Properties;

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
      if ( LunisolarDays.Count == 0 ) return;
      InitializeYearsInterval();
      var colorBack = Settings.MonthViewBackColor;
      var colorText = Settings.MonthViewTextColor;
      var colorSeason = Settings.CalendarColorSeason;
      var colorTorahEvent = Settings.CalendarColorTorahEvent;
      var colorParashah = Settings.CalendarColorParashah;
      var colorNotFullMoon = Settings.CalendarColorMoon;
      var colorFullMoon = Settings.CalendarColorFullMoon;
      var colorEventTorah = Settings.EventColorTorah;
      var colorEventSeason = Settings.EventColorSeason;
      var colorEventMonth = Settings.EventColorMonth;
      var colorEventNext = Settings.EventColorNext;
      var colorEventShabat = Settings.EventColorShabat;
      Color colorSun = Color.Transparent;
      Color colorMoon = Color.Transparent;
      bool useColors = Settings.UseColors;
      bool showSun = Settings.MonthViewLayoutEphemerisSunEnabled;
      bool showMoon = Settings.MonthViewLayoutEphemerisMoonEnabled;
      bool bothTimes = showSun && showMoon;
      bool noTimes = !showSun && !showMoon;
      bool addAlonePrefix = !bothTimes && Settings.MonthViewSunOrMoonOneLineStarSign;
      bool addPrefix = bothTimes || addAlonePrefix;
      bool dateOnSingleLine = noTimes || Settings.CalendarHebrewDateSingleLine;
      bool dateInItalic = Settings.CalendarHebrewDateSingleLineItalic;
      bool sepLunarDate = Settings.MonthViewSeparatorForLunarDate;
      bool sepEphemerisSun = Settings.MonthViewSeparatorForEphemerisSun;
      bool sepEphemerisMoon = Settings.MonthViewSeparatorForEphemerisMoon;
      bool sepSeasonChange = Settings.MonthViewSeparatorForSeasonChange;
      bool sepCelebration = Settings.MonthViewSeparatorForCelebration;
      bool sepParashahName = Settings.MonthViewSeparatorForParashahName;
      bool sepParashahRef = Settings.MonthViewSeparatorForParashahReference;
      bool aloneOneLine = Settings.MonthViewSunOrMoonOneLine;
      bool showLunarDate = Settings.MonthViewLayoutLunarDateEnabled;
      bool showSeason = Settings.MonthViewLayoutSeasonChangeEnabled;
      bool showCelebration = Settings.MonthViewLayoutCelebrationEnabled;
      bool showParashah = Settings.CalendarShowParashah;
      bool showParashahName = Settings.MonthViewLayoutParashahNameEnabled;
      bool showParashahRef = Settings.MonthViewLayoutParashahReferenceEnabled;
      bool isCelebrationWeekStart = false;
      bool isOmerSun = !Settings.TorahEventsCountAsMoon;
      bool useUnicode = Settings.HebrewNamesInUnicode;
      var shabatday = (DayOfWeek)Settings.ShabatDay;
      Parashah parashah = null;
      DayBrushes = new Brush[YearsInterval, 13, 35];
      var fontEventHebrew = new Font(Settings.MonthViewFontNameHebrew, Settings.MonthViewHebrewFontSize);
      var fontEventNoItalic = new Font(Settings.MonthViewFontNameLatin, Settings.MonthViewFontSize);
      var fontEventItalic = new Font(Settings.MonthViewFontNameLatin, Settings.MonthViewFontSize, FontStyle.Italic);
      var fontEvent = fontEventNoItalic;
      string prefixSun = Settings.EphemerisPrefixSun;
      string prefixMoon = Settings.EphemerisPrefixMoon;
      string strRise = AppTranslations.EphemerisCodes.GetLang(Ephemeris.Rise);
      string strSet = AppTranslations.EphemerisCodes.GetLang(Ephemeris.Set);
      var addSectionsMethods = new Dictionary<int, Action>();
      LoadingForm.Instance.Initialize(AppTranslations.ProgressFillMonths.GetLang(),
                                      LunisolarDays.Count,
                                      Program.LoadingFormLoadDB);
      foreach ( var row in LunisolarDays )
        try
        {
          LoadingForm.Instance.DoProgress();
          // Initialize
          Color? color1 = null;
          Color? color2 = null;
          Color? color3 = null;
          var date = row.Date;
          var season = row.SeasonChange;
          var eventTorah = row.TorahEvent;
          if ( TorahCelebrationSettings.CelebrationStartWeek.Contains(eventTorah) )
            isCelebrationWeekStart = true;
          // Color mix
          if ( season != SeasonChange.None )
            color1 = colorEventSeason;
          if ( row.IsNewMoon && eventTorah == TorahCelebrationDay.None )
            color2 = colorEventMonth;
          else
          if ( row.IsNewMoon && eventTorah == TorahCelebrationDay.NewYearD1 )
            color2 = MixColor(colorEventMonth, colorEventSeason, colorEventNext);
          else
          if ( isCelebrationWeekStart || eventTorah != TorahCelebrationDay.None )
            color2 = colorEventTorah;
          if ( row.Date.DayOfWeek == shabatday )
            color3 = colorEventShabat;
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
            color1 ??= colorBack;
          DayBrushes[YearLast - date.Year, date.Month, date.Day] = SolidBrushesPool.Get(color1.Value);
          Color colorEphemeris = row.IsNewMoon ? colorTorahEvent : row.IsFullMoon ? colorFullMoon : colorNotFullMoon;
          if ( TorahCelebrationSettings.CelebrationEndWeek.Contains(eventTorah) )
            isCelebrationWeekStart = false;
          // Initialize dispatch table
          int rank = 0;
          string strDate = string.Empty;
          bool hasPreviousSeperator = false;
          Action addsun = bothTimes ? addSunWithMoon : showSun ? addSunAlone : null;
          Action addmoon = bothTimes ? addMoonWithSun : showMoon ? addMoonAlone : null;
          addSectionsMethods.Clear();
          addSectionsMethods.Add(Settings.MonthViewLayoutLunarDatePosition, addLunarDateSingleLine);
          addSectionsMethods.Add(Settings.MonthViewLayoutEphemerisSunPosition, addsun);
          addSectionsMethods.Add(Settings.MonthViewLayoutEphemerisMoonPosition, addmoon);
          addSectionsMethods.Add(Settings.MonthViewLayoutSeasonChangePosition, addSeason);
          addSectionsMethods.Add(Settings.MonthViewLayoutCelebrationPosition, addCelebration);
          addSectionsMethods.Add(Settings.MonthViewLayoutParashahNamePosition, addParashahName);
          addSectionsMethods.Add(Settings.MonthViewLayoutParashahReferencePosition, addParashahRef);
          // Call dispatch table
          for ( int index = 0; index < addSectionsMethods.Count; index++ )
            addSectionsMethods[index]?.Invoke();
          //
          // Date on single line
          //
          void addLunarDateSingleLine()
          {
            if ( !showLunarDate ) return;
            if ( dateOnSingleLine )
            {
              if ( isOmerSun || row.Moonrise is not null )
              {
                var color = row.IsNewMoon ? colorTorahEvent : colorEphemeris;
                addLine(color, row.DayAndMonthFormattedText, CalendarSection.Date, useUnicode, dateInItalic);
                addSeparator(sepLunarDate);
              }
            }
            else
              strDate = " " + row.DayAndMonthFormattedText;
          }
          //
          // Sun alone
          //
          void addSunAlone()
          {
            if ( aloneOneLine )
              addSunWithMoon();
            else
            {
              addLine(colorEphemeris, $"{strRise}{row.SunriseAsString}{strDate}", CalendarSection.Ephemeris);
              addLine(colorText, strSet + row.SunsetAsString, CalendarSection.Ephemeris);
            }
            addSeparator(sepEphemerisSun);
          }
          //
          // Moon alone
          //
          void addMoonAlone()
          {
            if ( aloneOneLine )
              addMoonWithSun();
            else
            if ( row.MoonriseOccuring == MoonriseOccurring.AfterSet )
            {
              if ( row.Moonset is not null )
                addLine(colorText, strSet + row.MoonsetAsString, CalendarSection.Ephemeris);
              if ( row.MoonriseOccuring != MoonriseOccurring.NextDay )
                addLine(colorEphemeris, $"{strRise}{row.MoonriseAsString}{strDate}", CalendarSection.Ephemeris);
            }
            else
            {
              if ( row.MoonriseOccuring != MoonriseOccurring.NextDay )
                addLine(colorEphemeris, $"{strRise}{row.MoonriseAsString}{strDate}", CalendarSection.Ephemeris);
              if ( row.Moonset is not null )
                addLine(colorText, strSet + row.MoonsetAsString, CalendarSection.Ephemeris);
            }
            addSeparator(sepEphemerisMoon);
          }
          //
          // Sun with moon
          //
          void addSunWithMoon()
          {
            string str = $"{strRise}{row.SunriseAsString} - {strSet}{row.SunsetAsString}";
            if ( addPrefix )
              str = prefixSun + str;
            addLine(colorSun, str, CalendarSection.Ephemeris);
            addSeparator(sepEphemerisSun);
          }
          //
          // Moon with sun
          //
          void addMoonWithSun()
          {
            colorSun = isOmerSun ? colorEphemeris : colorText;
            colorMoon = isOmerSun ? colorText : colorEphemeris;
            string set = $"{strSet}{row.MoonsetAsString}";
            string rise = $"{strRise}{row.MoonriseAsString}";
            string all = string.Empty;
            if ( row.MoonriseOccuring == MoonriseOccurring.AfterSet )
              setMoonWithSun_RiseAfterSet();
            else
              setMoonWithSun_RiseBeforeSet();
            if ( addPrefix )
              all = prefixMoon + all;
            addLine(colorMoon, all, CalendarSection.Ephemeris);
            addSeparator(sepEphemerisMoon);
            //
            void setMoonWithSun_RiseAfterSet()
            {
              if ( row.Moonset is not null )
                all = $"{set}";
              if ( row.MoonriseOccuring != MoonriseOccurring.NextDay )
              {
                if ( all.Length != 0 ) all += " - ";
                all += $"{rise}{strDate}";
              }
            }
            //
            void setMoonWithSun_RiseBeforeSet()
            {
              if ( row.MoonriseOccuring != MoonriseOccurring.NextDay )
                all = $"{rise}";
              if ( row.Moonset is not null )
              {
                if ( all.Length != 0 ) all += " - ";
                all += $"{set}{strDate}";
              }
            }
          }
          //
          // Add season
          //
          void addSeason()
          {
            if ( !showSeason ) return;
            if ( row.SeasonChange != 0 )
            {
              string str = AppTranslations.GetSeasonChangeDisplayText(row.SeasonChange);
              addLine(colorSeason, str, CalendarSection.Ephemeris);
            }
            addSeparator(sepSeasonChange);
          }
          //
          // Add celebration
          //
          void addCelebration()
          {
            if ( !showCelebration ) return;
            if ( !row.TorahEventText.IsNullOrEmpty() )
              addLine(colorTorahEvent, row.TorahEventText, CalendarSection.Celebration, useUnicode);
            addSeparator(sepCelebration);
          }
          //
          // Add parashah name
          //
          void addParashahName()
          {
            if ( !showParashah || !showParashahName || string.IsNullOrEmpty(row.ParashahID) ) return;
            parashah = ParashotFactory.Instance.Get(row.ParashahID);
            if ( parashah is null )
              addLine(colorParashah, SysTranslations.UndefinedSlot.GetLang(), CalendarSection.Parashah, useUnicode);
            else
            {
              string str = parashah.ToStringShort(false, row.HasLinkedParashah);
              addLine(colorParashah, str, CalendarSection.Parashah, useUnicode);
            }
            addSeparator(sepParashahName);
          }
          //
          // Add parashah ref
          //
          void addParashahRef()
          {
            if ( !showParashah || !showParashahRef || string.IsNullOrEmpty(row.ParashahID) ) return;
            parashah = ParashotFactory.Instance.Get(row.ParashahID);
            if ( parashah is null )
              addLine(colorParashah, SysTranslations.UndefinedSlot.GetLang(), CalendarSection.Parashah, useUnicode);
            else
            {
              string str = $"{parashah.ToStringWithBookAndReferences()}";
              addLine(colorParashah, str, CalendarSection.Parashah, useUnicode);
            }
            addSeparator(sepParashahRef);
          }
          //
          // Add separator
          //
          void addSeparator(bool enabled)
          {
            if ( enabled ) addLine(colorText, string.Empty, CalendarSection.Separator);
          }
          //
          // Add info
          //
          void addLine(Color color, string text, CalendarSection section, bool isHebrew = false, bool isItalic = false)
          {
            if ( section == CalendarSection.Separator )
            {
              if ( hasPreviousSeperator ) return;
              hasPreviousSeperator = true;
            }
            else
            {
              hasPreviousSeperator = false;
            }
            var item = new CustomEvent
            {
              Date = date,
              EventFont = isHebrew ? fontEventHebrew : isItalic ? fontEventItalic : fontEvent,
              IsHebrew = isHebrew,
              Section = section
            };
            if ( useColors )
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
            if ( useColors )
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
      CalendarEventsGrouped = MonthlyCalendar.TheEvents
                                             .Cast<CustomEvent>()
                                             .GroupBy(e => e.Date)
                                             .ToDictionary(g => g.Key, g => g.ToArray());
    }
    finally
    {
      Globals.ChronoShowData.Stop();
      Settings.BenchmarkFillCalendar = Globals.ChronoShowData.ElapsedMilliseconds;
      SystemManager.TryCatch(Settings.Store);
    }

  }

}

