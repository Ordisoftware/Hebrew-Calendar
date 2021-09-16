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
/// <created> 2019-01 </created>
/// <edited> 2021-06 </edited>
using System;
using System.Linq;
using System.Drawing;
using CodeProjectCalendar.NET;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private Color[,,] DayColors;

    public Color GetDayColor(int counter, int month, int year)
    {
      int indexYear = YearLast - year;
      return indexYear < 0 || indexYear > DayColors.GetUpperBound(0)
             ? Color.Transparent
             : DayColors[indexYear, month, counter];
    }

    static public Color MixColor(Color c1, Color c2)
    {

      int _r = Math.Min(( c1.R + c2.R ) / 2, 255);
      int _g = Math.Min(( c1.G + c2.G ) / 2, 255);
      int _b = Math.Min(( c1.B + c2.B ) / 2, 255);
      return Color.FromArgb(Convert.ToByte(_r), Convert.ToByte(_g), Convert.ToByte(_b));
    }

    static public Color MixColor(Color c1, Color c2, Color c3)
    {

      int _r = Math.Min(( c1.R + c2.R + c3.R ) / 3, 255);
      int _g = Math.Min(( c1.G + c2.G + c3.G ) / 3, 255);
      int _b = Math.Min(( c1.B + c2.B + c3.B ) / 3, 255);
      return Color.FromArgb(Convert.ToByte(_r), Convert.ToByte(_g), Convert.ToByte(_b));
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

    public void FillMonths()
    {
      Globals.ChronoShowData.Restart();
      try
      {
        InitializeYearsInterval();
        //string strToolTip = "Error on getting sun rise and set";
        bool IsCelebrationWeekStart = false;
        bool IsCelebrationWeekEnd = false;
        if ( LunisolarDays.Count == 0 ) return;
        DayColors = new Color[YearsInterval, 13, 35];
        LoadingForm.Instance.Initialize(AppTranslations.ProgressFillMonths.GetLang(),
                                        LunisolarDays.Count,
                                        Program.LoadingFormLoadDB);
        foreach ( var row in LunisolarDays )
          try
          {
            LoadingForm.Instance.DoProgress();
            var ev = row.TorahEvent;
            var season = row.SeasonChange;
            if ( ev == TorahCelebrationDay.PessahD1
              || ev == TorahCelebrationDay.SoukotD1
              || ev == TorahCelebrationDay.ChavouotDiet )
              IsCelebrationWeekStart = true;
            IsCelebrationWeekEnd = ev == TorahCelebrationDay.PessahD7
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
            if ( IsCelebrationWeekStart || ev != TorahCelebrationDay.None )
              color2 = Settings.EventColorTorah;
            if ( row.Date.DayOfWeek == (DayOfWeek)Settings.ShabatDay )
              color3 = Settings.EventColorShabat;
            if ( color1 != null && color2 != null && color3 != null )
              color1 = MixColor(color1.Value, color2.Value, color3.Value);
            else
            if ( color1 != null && color2 != null && color3 == null )
              color1 = MixColor(color1.Value, color2.Value);
            else
            if ( color1 != null && color2 == null && color3 != null )
              color1 = MixColor(color1.Value, color3.Value);
            else
            if ( color1 == null && color2 != null && color3 != null )
              color1 = MixColor(color2.Value, color3.Value);
            else
            if ( color2 != null )
              color1 = color2;
            else
            if ( color3 != null )
              color1 = color3;
            else
            if ( color1 == null )
              color1 = Settings.MonthViewBackColor;
            DayColors[YearLast - date.Year, date.Month, date.Day] = color1.Value;
            if ( IsCelebrationWeekEnd )
              IsCelebrationWeekStart = false;
            int rank = 0;
            // Moon phase
            Color colorMoon = Color.Black;
            string strMonthDay = row.DayAndMonthFormattedText;
            colorMoon = row.IsNewMoon
                      ? Settings.CalendarColorTorahEvent
                      : ( row.IsFullMoon
                        ? Settings.CalendarColorFullMoon
                        : Settings.CalendarColorMoon );
            if ( !Settings.TorahEventsCountAsMoon )
            {
              add(colorMoon, AppTranslations.EphemerisCodes.GetLang(Ephemeris.Rise) + row.SunriseAsString + " " + strMonthDay);
              add(Settings.MonthViewTextColor, AppTranslations.EphemerisCodes.GetLang(Ephemeris.Set) + row.SunsetAsString);
            }
            else
            {
              if ( row.MoonriseOccuring == MoonriseOccuring.AfterSet )
              {
                if ( row.Moonset != null )
                  add(Settings.MonthViewTextColor, AppTranslations.EphemerisCodes.GetLang(Ephemeris.Set) + row.MoonsetAsString);
                if ( row.MoonriseOccuring != MoonriseOccuring.NextDay )
                  add(colorMoon, AppTranslations.EphemerisCodes.GetLang(Ephemeris.Rise) + row.MoonriseAsString + " " + strMonthDay);
                else
                if ( !Settings.TorahEventsCountAsMoon )
                  add(colorMoon, strMonthDay);
              }
              else
              {
                if ( row.MoonriseOccuring != MoonriseOccuring.NextDay )
                  add(colorMoon, AppTranslations.EphemerisCodes.GetLang(Ephemeris.Rise) + row.MoonriseAsString + " " + strMonthDay);
                else
                if ( !Settings.TorahEventsCountAsMoon )
                  add(colorMoon, strMonthDay);
                if ( row.Moonset != null )
                  add(Settings.MonthViewTextColor, AppTranslations.EphemerisCodes.GetLang(Ephemeris.Set) + row.MoonsetAsString);
              }
            }
            //Torah
            add(Settings.CalendarColorTorahEvent, row.TorahEventText);
            // Parashah
            if ( Settings.CalendarShowParashah )
              if ( !string.IsNullOrEmpty(row.ParashahID) )
                add(Settings.CalendarColorParashah, row.GetParashahText(false));
            // Season
            if ( row.SeasonChange != 0 )
              add(Settings.CalendarColorSeason, AppTranslations.SeasonChanges.GetLang(row.SeasonChange));
            //
            void add(Color color, string text)
            {
              if ( string.IsNullOrEmpty(text) ) return;
              var item = new CustomEvent();
              item.Date = date;
              item.EventFont = new Font("Calibri", Settings.MonthViewFontSize);
              if ( Settings.UseColors )
              {
                item.EventColor = Color.OrangeRed;
                item.EventTextColor = color;
              }
              else
              {
                item.EventColor = Color.Transparent;
                item.EventTextColor = CalendarMonth.ForeColor;
              }
              item.EventText = text;
              item.Rank = rank++;
              //item.TooltipEnabled = true;
              item.IgnoreTimeComponent = true;
              //item.ToolTipText = strToolTip;
              if ( Settings.UseColors )
                item.EventColor = GetDayColor(item.Date.Day, item.Date.Month, item.Date.Year);
              CalendarMonth.AddEvent(item);
            }
          }
          catch ( Exception ex )
          {
            if ( AddGenerateErrorAndCheckIfTooMany(nameof(FillMonths), row.DateAsString, ex) )
              return;
          }
      }
      finally
      {
        Globals.ChronoShowData.Stop();
        Settings.BenchmarkFillCalendar = Globals.ChronoShowData.ElapsedMilliseconds;
        SystemManager.TryCatch(Settings.Save);
      }
    }

  }

}
