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
/// <created> 2019-01 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.Drawing;
using Calendar.NET;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private Color[,,] DayColors;

    internal Color GetDayColor(int counter, int month, int year)
    {
      int indexYear = YearLast - year;
      if (indexYear < 0 || indexYear > DayColors.GetUpperBound(0))
        return Color.Transparent;
      return DayColors[indexYear, month, counter];
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

    internal void FillMonths()
    {
      Program.Chrono.Restart();
      try
      {
        string strToolTip = "Error on getting sun rise and set";
        bool IsCelebrationWeekStart = false;
        bool IsCelebrationWeekEnd = false;
        if ( DataSet.LunisolarDays.Count == 0 ) return;
        DateFirst = SQLite.GetDate(DataSet.LunisolarDays.FirstOrDefault().Date);
        YearFirst = DateFirst.Year;
        DateLast = SQLite.GetDate(DataSet.LunisolarDays.LastOrDefault().Date);
        YearLast = DateLast.Year;
        DayColors = new Color[YearLast - YearFirst + 1, 13, 35];
        LoadingForm.Instance.Initialize(Translations.ProgressFillMonths.GetLang(),
                                        DataSet.LunisolarDays.Count(),
                                        Program.LoadingFormMinimumLoad);
        foreach ( var row in DataSet.LunisolarDays )
          try
          {
            LoadingForm.Instance.DoProgress();
            var ev = (TorahEvent)row.TorahEvents;
            var season = (SeasonChange)row.SeasonChange;
            if ( ev == TorahEvent.PessahD1
              || ev == TorahEvent.SoukotD1
              || ev == TorahEvent.ChavouotDiet )
              IsCelebrationWeekStart = true;
            IsCelebrationWeekEnd = ev == TorahEvent.PessahD7
                                || ev == TorahEvent.SoukotD8
                                || ev == TorahEvent.Chavouot1;
            var result = IsCelebrationWeekStart || IsCelebrationWeekEnd;
            var date = SQLite.GetDate(row.Date);
            Color? color1 = null;
            Color? color2 = null;
            Color? color3 = null;
            if ( season != SeasonChange.None )
              color1 = Program.Settings.EventColorSeason;
            if ( row.IsNewMoon == 1 && ev == TorahEvent.None )
              color2 = Program.Settings.EventColorMonth;
            else
            if ( row.IsNewMoon == 1 && ev == TorahEvent.NewYearD1 )
              color2 = MixColor(Program.Settings.EventColorMonth,
                                Program.Settings.EventColorSeason,
                                Program.Settings.EventColorNext);
            else
            if ( IsCelebrationWeekStart || ev != TorahEvent.None )
              color2 = Program.Settings.EventColorTorah;
            if ( SQLite.GetDate(row.Date).DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
              color3 = Program.Settings.EventColorShabat;
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
              color1 = Program.Settings.MonthViewBackColor;
            DayColors[YearLast - date.Year, date.Month, date.Day] = color1.Value;
            if ( IsCelebrationWeekEnd )
              IsCelebrationWeekStart = false;
            int rank = 0;
            void add(Color color, string text)
            {
              var item = new CustomEvent();
              item.Date = SQLite.GetDate(row.Date);
              item.EventFont = new Font("Calibri", Program.Settings.MonthViewFontSize);
              if ( Program.Settings.UseColors )
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
              item.TooltipEnabled = true;
              item.IgnoreTimeComponent = true;
              item.ToolTipText = strToolTip;
              if ( Program.Settings.UseColors )
                item.EventColor = GetDayColor(item.Date.Day, item.Date.Month, item.Date.Year);
              CalendarMonth.AddEvent(item);
            }
            strToolTip = Translations.Ephemeris.GetLang(Ephemeris.Rise) + row.Sunrise + Environment.NewLine
                       + Translations.Ephemeris.GetLang(Ephemeris.Set) + row.Sunset;
            Color colorMoon = Color.Black;
            string strMonthDay = Program.Settings.MoonDayTextFormat.ToUpper()
                                 .Replace("%MONTHNAME%", Program.MoonMonthsNames[row.LunarMonth])
                                 .Replace("%MONTHNUM%", row.LunarMonth.ToString())
                                 .Replace("%DAYNUM%", row.LunarDay.ToString());
            colorMoon = row.IsNewMoon == 1
                      ? Program.Settings.CalendarColorTorahEvent
                      : ( row.IsFullMoon == 1
                        ? Program.Settings.CalendarColorFullMoon
                        : Program.Settings.CalendarColorMoon );
            if ( (MoonRise)row.MoonriseType == MoonRise.AfterSet )
            {
              if ( row.Moonset != "" )
                add(Program.Settings.MonthViewTextColor, Translations.Ephemeris.GetLang(Ephemeris.Set) + row.Moonset);
              if ( (MoonRise)row.MoonriseType != MoonRise.NextDay )
                add(colorMoon, Translations.Ephemeris.GetLang(Ephemeris.Rise) + row.Moonrise + " " + strMonthDay);
            }
            else
            {
              if ( (MoonRise)row.MoonriseType != MoonRise.NextDay )
                add(colorMoon, Translations.Ephemeris.GetLang(Ephemeris.Rise) + row.Moonrise + " " + strMonthDay);
              if ( row.Moonset != "" )
                add(Program.Settings.MonthViewTextColor, Translations.Ephemeris.GetLang(Ephemeris.Set) + row.Moonset);
            }
            if ( row.SeasonChange != 0 )
              add(Program.Settings.CalendarColorSeason, Translations.SeasonEvent.GetLang((SeasonChange)row.SeasonChange));
            if ( row.TorahEvents != 0 )
              add(Program.Settings.CalendarColorTorahEvent, Translations.TorahEvent.GetLang((TorahEvent)row.TorahEvents));
          }
          catch ( Exception ex )
          {
            GenerateErrors.Add($"{row.Date}: [{nameof(FillMonths)}] { ex.Message}");
          }
      }
      finally
      {
        Program.Chrono.Stop();
        Program.Settings.BenchmarkFillCalendar = Program.Chrono.ElapsedMilliseconds;
        Program.Settings.Save();
      }
    }

  }

}
