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
using System.Globalization;
using System.Text;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void GenerateReport()
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
      var headerSep = SeparatorV;
      var headerTxt = SeparatorV;
      foreach ( ReportFieldType v in Enum.GetValues(typeof(ReportFieldType)) )
      {
        string str = CalendarFieldNames.GetLang(v);
        headerSep += new string(SeparatorH[0], CalendarFieldSize[v]) + SeparatorV.ToString();
        headerTxt += " " + str + new string(' ', CalendarFieldSize[v] - str.Length - 2) + " " + SeparatorV.ToString();
      }
      headerSep = headerSep.Remove(headerSep.Length - 1) + SeparatorV;
      var content = new StringBuilder();
      content.Append(headerSep + Environment.NewLine);
      content.Append(headerTxt + Environment.NewLine);
      int progress = 0;
      int count = lunisolarCalendar.LunisolarDays.Count;
      if ( count <= 0 ) return;
      var lastyear = SQLiteUtility.GetDate(lunisolarCalendar.LunisolarDays.OrderByDescending(p=> p.Date).First().Date).Year;
      foreach ( Data.LunisolarCalendar.LunisolarDaysRow day in lunisolarCalendar.LunisolarDays.Rows )
      {
        var dayDate = SQLiteUtility.GetDate(day.Date);
        if ( !UpdateProgress(progress++, count, LocalizerHelper.ProgressGenerateResultText.GetLang()) ) return;
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
               ? (TimeZoneInfo.Local.IsDaylightSavingTime(dayDate.AddDays(1)) ? EphemerisNames.GetLang(EphemerisType.SummerHour) : EphemerisNames.GetLang(EphemerisType.WinterHour) ) + " " + strSun
               : strSun + new string(' ', 3 + 1);
        strSun += " " + (ShowShabat && dayDate.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay ? ShabatText : "   ");
        string strMoonrise = day.Moonrise == "" ? MoonNoText : EphemerisNames.GetLang(EphemerisType.Rise) + day.Moonrise;
        string strMoonset = day.Moonset == "" ? MoonNoText : EphemerisNames.GetLang(EphemerisType.Set) + day.Moonset;
        string strMoon = (MoonriseType)day.MoonriseType == MoonriseType.BeforeSet ? strMoonrise + ColumnSepInner + strMoonset : strMoonset + ColumnSepInner + strMoonrise;
        string textDate = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[(int)dayDate.DayOfWeek];
        textDate = textDate.Replace(".", "") + " ";
        textDate += dayDate.Day.ToString("00") + ".";
        textDate += dayDate.Month.ToString("00") + ".";
        textDate += dayDate.Year;
        string strDesc = "";
        string s1 = TorahCelebrations.SeasonEventNames.GetLang((SeasonChangeType)day.SeasonChange);
        string s2 = TorahCelebrations.TorahEventNames.GetLang((TorahEventType)day.TorahEvents);
        strDesc = s1 != "" && s2 != "" ? s1 + " - " + s2 : s1 + s2;
        System.Diagnostics.Debug.WriteLine(strDesc);
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
      calendarText.Text = content.ToString();
    }

  }

}
