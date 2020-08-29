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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using Ordisoftware.HebrewCommon;

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

    private Dictionary<ReportFieldText, int> CalendarFieldSize
      = new Dictionary<ReportFieldText, int>()
      {
        { ReportFieldText.Date, 16 },
        { ReportFieldText.Month, 11 },
        { ReportFieldText.Sun, 23 },
        { ReportFieldText.Moon, 21 },
        { ReportFieldText.Events, 42 },
      };

    private string GenerateReport()
    {
      var Chrono = new Stopwatch();
      Chrono.Start();
      try
      {

        var headerSep = SeparatorV;
        var headerTxt = SeparatorV;
        foreach ( ReportFieldText v in Enum.GetValues(typeof(ReportFieldText)) )
        {
          string str = Translations.CalendarField.GetLang(v);
          headerSep += new string(SeparatorH[0], CalendarFieldSize[v]) + SeparatorV.ToString();
          headerTxt += " " + str + new string(' ', CalendarFieldSize[v] - str.Length - 2) + " " + SeparatorV.ToString();
        }
        headerSep = headerSep.Remove(headerSep.Length - 1) + SeparatorV;
        var content = new StringBuilder();
        content.Append(headerSep + Environment.NewLine);
        content.Append(headerTxt + Environment.NewLine);
        if ( DataSet.LunisolarDays.Count <= 0 ) return "";
        var lastyear = SQLiteDate.ToDateTime(DataSet.LunisolarDays.OrderByDescending(p => p.Date).First().Date).Year;
        LoadingForm.Instance.Initialize(Translations.ProgressGenerateReport.GetLang(),
                                        DataSet.LunisolarDays.Count,
                                        Program.LoadingFormLoadDB);
        foreach ( Data.DataSet.LunisolarDaysRow day in DataSet.LunisolarDays.Rows )
          try
          {
            var dayDate = SQLiteDate.ToDateTime(day.Date);
            LoadingForm.Instance.DoProgress();
            if ( day.LunarMonth == 0 ) continue;
            if ( dayDate.Year == lastyear && day.LunarMonth == 1 ) break;
            if ( day.IsNewMoon == 1 ) content.Append(headerSep + Environment.NewLine);
            string strMonth = day.IsNewMoon == 1 && day.LunarMonth != 0 ? day.LunarMonth.ToString("00") : "  ";
            string strDay = ( (MoonRise)day.MoonriseType == MoonRise.NextDay
                          ? "  "
                          : string.Format("{0:00}", day.LunarDay) ) + " " + ( day.IsNewMoon == 1
                                                                            ? MoonNewText
                                                                            : day.IsFullMoon == 1
                                                                              ? MoonFullText
                                                                              : " " );
            string strSun = day.Sunrise + " - " + day.Sunset;
            strSun = ShowWinterSummerHour
                   ? ( TimeZoneInfo.Local.IsDaylightSavingTime(dayDate.AddDays(1))
                                                              ? Translations.Ephemeris.GetLang(Ephemeris.SummerHour)
                                                              : Translations.Ephemeris.GetLang(Ephemeris.WinterHour) )
                                                                + " " + strSun
                   : strSun + new string(' ', 3 + 1);
            strSun += " " + ( ShowShabat && dayDate.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay
                              ? ShabatText
                              : "   " );
            string strMoonrise = day.Moonrise == ""
                               ? MoonNoText
                               : Translations.Ephemeris.GetLang(Ephemeris.Rise) + day.Moonrise;
            string strMoonset = day.Moonset == ""
                              ? MoonNoText
                              : Translations.Ephemeris.GetLang(Ephemeris.Set) + day.Moonset;
            string strMoon = (MoonRise)day.MoonriseType == MoonRise.BeforeSet
                           ? strMoonrise + ColumnSepInner + strMoonset
                           : strMoonset + ColumnSepInner + strMoonrise;
            string textDate = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[(int)dayDate.DayOfWeek];
            textDate = textDate.Replace(".", "") + " ";
            textDate += dayDate.Day.ToString("00") + ".";
            textDate += dayDate.Month.ToString("00") + ".";
            textDate += dayDate.Year;
            string strDesc = "";
            string s1 = Translations.SeasonEvent.GetLang((SeasonChange)day.SeasonChange);
            string s2 = Translations.TorahEvent.GetLang((TorahEvent)day.TorahEvents);
            strDesc = s1 != "" && s2 != "" ? s1 + " - " + s2 : s1 + s2;
            int lengthAvailable = CalendarFieldSize[ReportFieldText.Events];
            int length = lengthAvailable - 2 - strDesc.Length;
            if ( length < 0 )
              throw new Exception($"Field if too short.{Environment.NewLine}" +
                                  $"    Available chars: {lengthAvailable}{Environment.NewLine}" +
                                  $"    Missing chars: {length}");
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
            content.Append(Environment.NewLine);
          }
          catch ( Exception ex )
          {
            GenerateErrors.Add($"{day.Date}: [{nameof(GenerateReport)}] { ex.Message}");
          }
        content.Append(headerSep + Environment.NewLine);
        var row = DataSet.Report.NewReportRow();
        row.Content = content.ToString();
        DataSet.Report.AddReportRow(row);
        return content.ToString();
      }
      finally
      {
        Chrono.Stop();
        Program.Settings.BenchmarkGenerateTextReport = Chrono.ElapsedMilliseconds;
      }
    }

  }

}