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
/// <created> 2016-04 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    const string SeparatorV = "|";
    const string SeparatorH = "-";
    const string ColumnSepLeft = SeparatorV + " ";
    const string ColumnSepInner = " " + SeparatorV + " ";
    const string ColumnSepRight = " " + SeparatorV;
    const string MoonNoText = "        ";
    const string ShabatText = "[S]";
    const string MoonFullText = "○";
    internal readonly string MoonNewText = "●";

    private bool ShowWinterSummerHour = true;
    private bool ShowShabat = true;

    private Dictionary<ReportFieldType, int> CalendarFieldSize
      = new Dictionary<ReportFieldType, int>()
      {
        { ReportFieldType.Date, 16 },
        { ReportFieldType.Month, 11 },
        { ReportFieldType.Sun, 23 },
        { ReportFieldType.Moon, 21 },
        { ReportFieldType.Events, 42 },
      };

    private string GenerateReport()
    {
      var headerSep = SeparatorV;
      var headerTxt = SeparatorV;
      foreach ( ReportFieldType v in Enum.GetValues(typeof(ReportFieldType)) )
      {
        string str = Localizer.CalendarFieldText.GetLang(v);
        headerSep += new string(SeparatorH[0], CalendarFieldSize[v]) + SeparatorV.ToString();
        headerTxt += " " + str + new string(' ', CalendarFieldSize[v] - str.Length - 2) + " " + SeparatorV.ToString();
      }
      headerSep = headerSep.Remove(headerSep.Length - 1) + SeparatorV;
      var content = new StringBuilder();
      content.Append(headerSep + Environment.NewLine);
      content.Append(headerTxt + Environment.NewLine);
      int progress = 0;
      int count = LunisolarCalendar.LunisolarDays.Count;
      if ( count <= 0 ) return "";
      var lastyear = SQLiteUtility.GetDate(LunisolarCalendar.LunisolarDays.OrderByDescending(p=> p.Date).First().Date).Year;
      foreach ( Data.LunisolarCalendar.LunisolarDaysRow day in LunisolarCalendar.LunisolarDays.Rows )
      {
        var dayDate = SQLiteUtility.GetDate(day.Date);
        if ( !UpdateProgress(progress++, count, Localizer.ProgressGenerateReportText.GetLang()) ) return "";
        if ( day.LunarMonth == 0 ) continue;
        if ( dayDate.Year == lastyear && day.LunarMonth == 1 ) break;
        if ( day.IsNewMoon == 1 ) content.Append(headerSep + Environment.NewLine);
        string strMonth = day.IsNewMoon == 1 && day.LunarMonth != 0 ? day.LunarMonth.ToString("00") : "  ";
        string strDay = ((MoonriseType)day.MoonriseType == MoonriseType.NextDay 
                      ? "  " 
                      : string.Format("{0:00}", day.LunarDay)) + " " + (day.IsNewMoon == 1 ? MoonNewText 
                                                                                           : day.IsFullMoon == 1 ? MoonFullText 
                                                                                                                 : " ");
        string strSun = day.Sunrise + " - " + day.Sunset;
        strSun = ShowWinterSummerHour
               ? (TimeZoneInfo.Local.IsDaylightSavingTime(dayDate.AddDays(1)) ? Localizer.EphemerisText.GetLang(EphemerisType.SummerHour) 
                                                                              : Localizer.EphemerisText.GetLang(EphemerisType.WinterHour) ) + " " + strSun
               : strSun + new string(' ', 3 + 1);
        strSun += " " + (ShowShabat && dayDate.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay ? ShabatText : "   ");
        string strMoonrise = day.Moonrise == "" ? MoonNoText : Localizer.EphemerisText.GetLang(EphemerisType.Rise) + day.Moonrise;
        string strMoonset = day.Moonset == "" ? MoonNoText : Localizer.EphemerisText.GetLang(EphemerisType.Set) + day.Moonset;
        string strMoon = (MoonriseType)day.MoonriseType == MoonriseType.BeforeSet 
                       ? strMoonrise + ColumnSepInner + strMoonset 
                       : strMoonset + ColumnSepInner + strMoonrise;
        string textDate = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[(int)dayDate.DayOfWeek];
        textDate = textDate.Replace(".", "") + " ";
        textDate += dayDate.Day.ToString("00") + ".";
        textDate += dayDate.Month.ToString("00") + ".";
        textDate += dayDate.Year;
        string strDesc = "";
        string s1 = Localizer.SeasonEventText.GetLang((SeasonChangeType)day.SeasonChange);
        string s2 = Localizer.TorahEventText.GetLang((TorahEventType)day.TorahEvents);
        strDesc = s1 != "" && s2 != "" ? s1 + " - " + s2 : s1 + s2;
        strDesc += new string(' ', CalendarFieldSize[ReportFieldType.Events] - 2 - strDesc.Length) + ColumnSepRight;
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
      content.Append(headerSep + Environment.NewLine);
      var row = LunisolarCalendar.Report.NewReportRow();
      row.Content = content.ToString();
      LunisolarCalendar.Report.AddReportRow(row);
      return content.ToString();
    }

  }

}
