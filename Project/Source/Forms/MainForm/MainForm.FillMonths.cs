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
/// <created> 2019-01 </created>
/// <edited> 2019-08 </edited>
using System;
using System.Linq;
using System.Drawing;
using Calendar.NET;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private Color[,,] DayColors;

    internal Color GetDayColor(int counter, int month, int year)
    {
      return DayColors[YearLast - year, month, counter];
    }

    static public Color MixColor(Color c1, Color c2)
    {

      int _r = Math.Min(( c1.R + c2.R ) / 2, 255);
      int _g = Math.Min(( c1.G + c2.G ) / 2, 255);
      int _b = Math.Min(( c1.B + c2.B ) / 2, 255);
      return Color.FromArgb(Convert.ToByte(_r), Convert.ToByte(_g), Convert.ToByte(_b));
    }

    internal void FillMonths()
    {
      string strToolTip = "Error on getting sun rise and set";
      bool IsCelebrationWeekStart = false;
      bool IsCelebrationWeekEnd = false;
      int progress = 0;
      if ( LunisolarCalendar.LunisolarDays.Count == 0 ) return;
      YearFirst = SQLiteUtility.GetDate(LunisolarCalendar.LunisolarDays.FirstOrDefault().Date).Year;
      YearLast = SQLiteUtility.GetDate(LunisolarCalendar.LunisolarDays.LastOrDefault().Date).Year;
      DayColors = new Color[YearLast - YearFirst + 1, 13, 35];
      foreach ( var row in LunisolarCalendar.LunisolarDays )
      {
        if ( !UpdateProgress(progress++, Count, Translations.ProgressFillMonths.GetLang()) ) return;
        var ev = (TorahEventType)row.TorahEvents;
        if ( ev == TorahEventType.PessahD1 || ev == TorahEventType.SoukotD1 || ev == TorahEventType.ChavouotDiet )
          IsCelebrationWeekStart = true;
        IsCelebrationWeekEnd = ev == TorahEventType.PessahD7 || ev == TorahEventType.SoukotD8 || ev == TorahEventType.Chavouot1;
        var result = IsCelebrationWeekStart || IsCelebrationWeekEnd;
        var date = SQLiteUtility.GetDate(row.Date);
        DayColors[YearLast - date.Year, date.Month, date.Day] = Color.Transparent;
        if ( IsCelebrationWeekStart || ev != TorahEventType.None )
          DayColors[YearLast - date.Year, date.Month, date.Day] = Program.Settings.ReminderCurrentDayColor;
        if ( SQLiteUtility.GetDate(row.Date).DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
          if ( IsCelebrationWeekStart )
            DayColors[YearLast - date.Year, date.Month, date.Day] = MixColor(Program.Settings.ReminderShabatDayColor, DayColors[YearLast - date.Year, date.Month, date.Day]); 
          else
            DayColors[YearLast - date.Year, date.Month, date.Day] = Program.Settings.ReminderShabatDayColor;
        if ( IsCelebrationWeekEnd )
          IsCelebrationWeekStart = false;
        int rank = 0;
        void add(Color color, string text)
        {
          var item = new CustomEvent();
          item.Date = SQLiteUtility.GetDate(row.Date);
          item.EventFont = new Font("Calibri", 9f);
          item.EventColor = Color.White;
          item.EventTextColor = color;
          item.EventText = text;
          item.Rank = rank++;
          item.TooltipEnabled = true;
          item.IgnoreTimeComponent = true;
          item.ToolTipText = strToolTip;
          if ( Program.Settings.ReminderUseColors )
            item.EventColor = GetDayColor(item.Date.Day, item.Date.Month, item.Date.Year);
          CalendarMonth.AddEvent(item);
        }
        strToolTip = Translations.Ephemeris.GetLang(EphemerisType.Rise) + row.Sunrise + Environment.NewLine 
                   + Translations.Ephemeris.GetLang(EphemerisType.Set) + row.Sunset;
        Color colorMoon = Color.Black;
        string strMonth = row.IsNewMoon == 1
                        ? " " + Translations.BabylonianHebrewMonthText[row.LunarMonth]
                        : "";
        colorMoon = row.IsNewMoon == 1
                  ? Program.Settings.TorahEventColor
                  : ( row.IsFullMoon == 1 ? Program.Settings.FullMoonColor : Program.Settings.MoonEventColor );
        if ( (MoonriseType)row.MoonriseType == MoonriseType.AfterSet )
        {
          if ( row.Moonset != "" ) add(Color.Black, Translations.Ephemeris.GetLang(EphemerisType.Set) + row.Moonset);
          if ( (MoonriseType)row.MoonriseType != MoonriseType.NextDay )
            add(colorMoon, Translations.Ephemeris.GetLang(EphemerisType.Rise) + row.Moonrise + " #" + row.LunarDay + strMonth);
        }
        else
        {
          if ( (MoonriseType)row.MoonriseType != MoonriseType.NextDay )
            add(colorMoon, Translations.Ephemeris.GetLang(EphemerisType.Rise) + row.Moonrise + " #" + row.LunarDay + strMonth);
          if ( row.Moonset != "" ) add(Color.Black, Translations.Ephemeris.GetLang(EphemerisType.Set) + row.Moonset);
        }
        if ( row.SeasonChange != 0 )
          add(Program.Settings.SeasonEventColor, Translations.SeasonEvent.GetLang((SeasonChangeType)row.SeasonChange));
        if ( row.TorahEvents != 0 )
          add(Program.Settings.TorahEventColor, Translations.TorahEvent.GetLang((TorahEventType)row.TorahEvents));
      }
    }

  }

}
