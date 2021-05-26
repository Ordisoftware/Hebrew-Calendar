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
/// <edited> 2021-05 </edited>
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EnumsNET;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    const string SeparatorV = "|";
    const string SeparatorH = "-";
    const string ColumnSepLeft = SeparatorV + " ";
    const string ColumnSepInner = " " + SeparatorV + " ";
    const string ColumnSepRight = " " + SeparatorV;
    const string MoonNoText = "        ";
    const string ShabatText = "[S]";
    const string MoonFullText = "o";
    public readonly string MoonNewText = "•";

    private bool ShowWinterSummerHour = true;
    private bool ShowShabat = true;

    private Dictionary<ReportFieldText, int> CalendarFieldSize
      = new Dictionary<ReportFieldText, int>()
      {
        { ReportFieldText.Date, 16 },
        { ReportFieldText.Month, 11 },
        { ReportFieldText.Sun, 23 },
        { ReportFieldText.Moon, 21 },
        { ReportFieldText.Events, 42 },
      };

    private string GenerateReportText(bool processInsert = false)
    {
      var Chrono = new Stopwatch();
      Chrono.Start();
      try
      {

        var headerSep = SeparatorV;
        var headerTxt = SeparatorV;
        foreach ( var field in Enums.GetValues<ReportFieldText>() )
        {
          string str = AppTranslations.ReportFieldText.GetLang(field);
          headerSep += new string(SeparatorH[0], CalendarFieldSize[field]) + SeparatorV.ToString();
          headerTxt += " " + str + new string(' ', CalendarFieldSize[field] - str.Length - 2) + " " + SeparatorV.ToString();
        }
        headerSep = headerSep.Remove(headerSep.Length - 1) + SeparatorV;
        var content = new StringBuilder();
        content.Append(headerSep + Globals.NL);
        content.Append(headerTxt + Globals.NL);
        if ( LunisolarDays.Count <= 0 ) return string.Empty;
        var lastyear = LunisolarDays.OrderByDescending(p => p.Date).First().Date.Year;
        LoadingForm.Instance.Initialize(AppTranslations.ProgressGenerateReport.GetLang(),
                                        LunisolarDays.Count,
                                        Program.LoadingFormLoadDB);
        foreach ( LunisolarDay day in LunisolarDays )
          try
          {
            if ( processInsert ) ApplicationDatabase.Instance.Connection.Insert(day);
            var dayDate = day.Date;
            LoadingForm.Instance.DoProgress();
            if ( day.LunarMonth == 0 ) continue;
            if ( dayDate.Year == lastyear && day.LunarMonth == 1 ) break;
            if ( day.IsNewMoon ) content.Append(headerSep + Globals.NL);
            string strMonth = day.IsNewMoon && day.LunarMonth != 0 ? $"{day.LunarMonth:00}" : "  ";
            string strDay = day.MoonriseOccuring == MoonriseOccuring.NextDay && Settings.TorahEventsCountAsMoon
                            ? "  "
                            : $"{day.LunarDay:00}";
            strDay += " " + ( day.IsNewMoon ? MoonNewText : day.IsFullMoon ? MoonFullText : " " );
            string strSun = day.SunriseAsString + " - " + day.SunsetAsString;
            strSun = ShowWinterSummerHour
                     ? ( TimeZoneInfo.Local.IsDaylightSavingTime(dayDate.AddDays(1))
                         ? AppTranslations.Ephemeris.GetLang(Ephemeris.SummerHour)
                         : AppTranslations.Ephemeris.GetLang(Ephemeris.WinterHour) )
                       + " " + strSun
                     : strSun + new string(' ', 3 + 1);
            strSun += " " + ( ShowShabat && dayDate.DayOfWeek == (DayOfWeek)Settings.ShabatDay
                              ? ShabatText
                              : "   " );
            string strMoonrise = day.Moonrise == null
                               ? MoonNoText
                               : AppTranslations.Ephemeris.GetLang(Ephemeris.Rise) + day.MoonriseAsString;
            string strMoonset = day.Moonset == null
                              ? MoonNoText
                              : AppTranslations.Ephemeris.GetLang(Ephemeris.Set) + day.MoonsetAsString;
            string strMoon = day.MoonriseOccuring == MoonriseOccuring.BeforeSet
                           ? strMoonrise + ColumnSepInner + strMoonset
                           : strMoonset + ColumnSepInner + strMoonrise;
            string textDate = AppTranslations.DayOfWeek.GetLang(dayDate.DayOfWeek).Substring(0, 3);
            textDate = textDate.Replace(".", string.Empty) + " ";
            textDate += $"{dayDate.Day:00}.";
            textDate += $"{dayDate.Month:00}.";
            textDate += dayDate.Year;
            string strDesc = string.Empty;
            string s1 = day.TorahEventText;
            string s2 = AppTranslations.SeasonChange.GetLang(day.SeasonChange);
            strDesc = s1 != string.Empty && s2 != string.Empty ? s1 + " - " + s2 : s1 + s2;
            int lengthAvailable = CalendarFieldSize[ReportFieldText.Events];
            int length = lengthAvailable - 2 - strDesc.Length;
            if ( length < 0 )
              throw new Exception("Field if too short." + Globals.NL +
                                  "    Available chars: " + lengthAvailable + Globals.NL +
                                  "    Missing chars: " + length);
            strDesc += new string(' ', length) + ColumnSepRight;
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
            content.Append(Globals.NL);
          }
          catch ( Exception ex )
          {
            GenerateErrors.Add($"{day.DateAsString}: [{nameof(GenerateReportText)}] { ex.Message}");
          }
        content.Append(headerSep + Globals.NL);
        try
        {
          File.WriteAllText(Program.TextReportFilePath, content.ToString(), Encoding.UTF8);
        }
        catch ( Exception ex )
        {
          DisplayManager.ShowWarning(SysTranslations.LoadFileError.GetLang(Program.TextReportFilePath, ex.Message));
        }
        return content.ToString();
      }
      finally
      {
        Chrono.Stop();
        Settings.BenchmarkGenerateTextReport = Chrono.ElapsedMilliseconds;
      }
    }

  }

}