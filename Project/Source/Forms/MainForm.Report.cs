/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private enum CalendarFieldType { Date, Month, Sun, Moon, Events }

    private Dictionary<CalendarFieldType, int> CalendarFieldSize
      = new Dictionary<CalendarFieldType, int>()
      {
        { CalendarFieldType.Date, 16 },
        { CalendarFieldType.Month, 11 },
        { CalendarFieldType.Sun, 23 },
        { CalendarFieldType.Moon, 21 },
        { CalendarFieldType.Events, 40 },
      };

    string HeaderSep;
    string HeaderTxt;
    string ColumnSepLeft = "| ";
    string ColumnSepInner = " | ";
    string ColumnSepRight = " |";
    string ShabatText = "[S]";
    string MoonriseText = "R: ";
    string MoonsetText = "S: ";
    string MoonNoText = "        ";
    string HourSummerText = "(S)";
    string HourWinterText = "(W)";
    int ColumnEventLenght = 38;
    public string MoonNewText = "●";
    public string MoonFullText = "○";

    bool TrimBeforeNewLunarYear = true;
    bool ShowWinterSummerHour = true;
    bool ShowShabat = true;

    private string FormatTime(TimeSpan? time)
    {
      return time.Value.Hours.ToString("00") + ":" + time.Value.Minutes.ToString("00");
    }

    private void GenerateTextReport()
    {
      IsGenerating = true;
      UseWaitCursor = true;
      calendarText.Clear();
      UpdateButtons();
      try
      {
        calendarText.Clear();
        DoGenerateTextReport();
      }
      catch ( Exception except )
      {
        except.Manage();
      }
      finally
      {
        UseWaitCursor = false;
        IsGenerating = false;
        UpdateButtons();
      }
    }

    private void DoGenerateTextReport()
    {
      DoGenerateTextReport(lunisolarCalendar.YearMin, lunisolarCalendar.YearMax);
    }

    private void DoGenerateTextReport(int yearFirst, int yearLast)
    {
      HeaderSep = "|";
      HeaderTxt = "|";
      foreach ( CalendarFieldType v in Enum.GetValues(typeof(CalendarFieldType)) )
      {
        HeaderSep += new string('-', CalendarFieldSize[v]) + '|';
        HeaderTxt += " " + v.ToString() + new string(' ', CalendarFieldSize[v] - v.ToString().Length - 2) + " |";
      }
      HeaderSep = HeaderSep.Remove(HeaderSep.Length - 1) + '|';
      var content = new StringBuilder();
      content.Append(HeaderSep + Environment.NewLine);
      content.Append(HeaderTxt + Environment.NewLine);
      if ( !TrimBeforeNewLunarYear ) content.Append(HeaderSep + Environment.NewLine);
      int progress = 0;
      int count = lunisolarCalendar.LunisolarDays.Count;
      if ( count == 0 ) return;
      var lastyear = SQLiteDateTool.GetDate(lunisolarCalendar.LunisolarDays.OrderByDescending(p=> p.Date).First().Date).Year;
      foreach ( Data.LunisolarCalendar.LunisolarDaysRow day in lunisolarCalendar.LunisolarDays.Rows )
      {
        var dayDate = SQLiteDateTool.GetDate(day.Date);
        if ( !UpdateProgress(progress++, count, ProgressGenerateResultText) ) return;
        if ( TrimBeforeNewLunarYear && day.LunarMonth == 0 ) continue;
        if ( TrimBeforeNewLunarYear && dayDate.Year == lastyear && day.LunarMonth == 1 ) break;

        if ( day.IsNewMoon == 1 ) content.Append(HeaderSep + Environment.NewLine);
        string strMonth = day.IsNewMoon == 1 && day.LunarMonth != 0 ? day.LunarMonth.ToString("00") : "  ";
        string strDay = ((MoonriseType)day.MoonriseType == MoonriseType.NextDay 
                      ? "  " 
                      : string.Format("{0:00}", day.LunarDay)) + " " + (day.IsNewMoon == 1 ? MoonNewText 
                                                                                           : day.IsFullMoon == 1 ? MoonFullText 
                                                                                                                 : " ");
        string strSun = day.Sunrise + " - " + day.Sunset;
        strSun = ShowWinterSummerHour
               ? (TimeZoneInfo.Local.IsDaylightSavingTime(dayDate.AddDays(1)) ? HourSummerText : HourWinterText) + " " + strSun
               : strSun + new string(' ', HourWinterText.Length + 1);
        strSun += " " + (ShowShabat && dayDate.DayOfWeek == Program.Settings.ShabatDay ? ShabatText : "   ");
        string strMoonrise = day.Moonrise == "" ? MoonNoText : MoonriseText + day.Moonrise;
        string strMoonset = day.Moonset == "" ? MoonNoText : MoonsetText + day.Moonset;
        string strMoon = (MoonriseType)day.MoonriseType == MoonriseType.BeforeSet ? strMoonrise + ColumnSepInner + strMoonset : strMoonset + ColumnSepInner + strMoonrise;
        string textDate = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[(int)dayDate.DayOfWeek];
        textDate = textDate.Replace(".", "") + " ";
        textDate += dayDate.Day.ToString("00") + ".";
        textDate += dayDate.Month.ToString("00") + ".";
        textDate += dayDate.Year;
        string strDesc = "";
        void AddResult(string str) { strDesc = ( strDesc == "" ? "" : strDesc + " - " ) + str; }
        AddResult(TorahCelebrations.SeasonEventToString((SeasonEventType)day.SeasonChange));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.NewYearD1) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.NewYearD1));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.NewYearD10) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.NewYearD10));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.PessahD1) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.PessahD1));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.PessahD8) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.PessahD8));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.ChavouotDiet) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.ChavouotDiet));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.Chavouot1) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.Chavouot1));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.Chavouot2) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.Chavouot2));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.YomTerouah) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.YomTerouah));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.YomHaKipourim) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.YomHaKipourim));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.SoukotD1) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.SoukotD1));
        if ( ((TorahEventType)day.TorahEvents).HasFlag(TorahEventType.SoukotD8) )
          AddResult(TorahCelebrations.TorahEventToString(TorahEventType.SoukotD8)); 
        strDesc += new string(' ', ColumnEventLenght - strDesc.Length) + ColumnSepRight;
        content.Append(ColumnSepLeft);
        content.Append(textDate);
        content.Append(ColumnSepInner);
        content.Append(strMonth);
        content.Append(ColumnSepInner);
        content.Append(strDay);
        content.Append(ColumnSepInner);
        content.Append(strSun);
        content.Append(ColumnSepInner);
        content.Append(strMoon);
        content.Append(ColumnSepInner);
        content.Append(strDesc);
        content.Append(Environment.NewLine);
      }
      content.Append(HeaderSep + Environment.NewLine);
      calendarText.Text = content.ToString();
    }

  }

}
