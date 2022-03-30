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
/// <created> 2016-04 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase
{

  public const string SeparatorV = "|";
  public const string SeparatorH = "-";
  public const string ColumnSepLeft = SeparatorV + " ";
  public const string ColumnSepInner = " " + SeparatorV + " ";
  public const string ColumnSepRight = " " + SeparatorV;
  public const string MoonNoText = "        ";
  public const string ShabatText = "[S]";
  public const string MoonFullText = "o";
  public const string MoonNewText = "•";

  static public bool ShowWinterSummerHour { get; set; } = true;
  static public bool ShowShabat { get; set; } = true;

  static public readonly Dictionary<ReportFieldText, int> CalendarFieldSize = new()
  {
    { ReportFieldText.Date, 16 },
    { ReportFieldText.Month, 11 },
    { ReportFieldText.Sun, 23 },
    { ReportFieldText.Moon, 21 },
    { ReportFieldText.Events, 42 },
  };

  [SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "N/A")]
  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  public string GenerateReport(bool processInsert = false)
  {
    var tempSep = SQLiteDate.DaySeparator;
    var tempOrder = SQLiteDate.DayOrder;
    var chrono = new Stopwatch();
    chrono.Start();
    try
    {
      string headerSep = SeparatorV;
      string headerTxt = SeparatorV;
      foreach ( var field in Enums.GetValues<ReportFieldText>() )
      {
        string str = AppTranslations.ReportFields.GetLang(field);
        headerSep += new string(SeparatorH[0], CalendarFieldSize[field]) + SeparatorV;
        headerTxt += $" {str}{new string(' ', CalendarFieldSize[field] - str.Length - 2)} {SeparatorV}";
      }
      headerSep = headerSep.Remove(headerSep.Length - 1) + SeparatorV;
      var content = new StringBuilder(LunisolarDays.Count * headerSep.Length);
      content.AppendLine(headerSep);
      content.AppendLine(headerTxt);
      if ( LunisolarDays.Count == 0 ) return string.Empty;
      SQLiteDate.DaySeparator = SQLiteDateDayTextSeparator.Point;
      SQLiteDate.DayOrder = SQLiteDateDayTextOrder.DayFirst;
      var lastyear = LunisolarDays.OrderByDescending(p => p.Date).First().Date.Year;
      LoadingForm.Instance.Initialize(AppTranslations.ProgressGenerateReport.GetLang(),
                                      LunisolarDays.Count,
                                      Program.LoadingFormLoadDB);
      foreach ( LunisolarDay day in LunisolarDays )
        try
        {
          if ( processInsert ) Connection.Insert(day);
          var dayDate = day.Date;
          LoadingForm.Instance.DoProgress();
          if ( day.LunarMonth == 0 ) continue;
          if ( dayDate.Year == lastyear && day.LunarMonth == 1 ) break;
          if ( day.IsNewMoon ) content.AppendLine(headerSep);
          string strMonth = day.IsNewMoon && day.LunarMonth != 0
            ? $"{day.LunarMonth:00}"
            : "  ";
          string strDay = day.MoonriseOccuring == MoonriseOccurring.NextDay && Settings.TorahEventsCountAsMoon
            ? "  "
            : $"{day.LunarDay:00}";
          strDay += " ";
          strDay += day.IsNewMoon
            ? MoonNewText
            : day.IsFullMoon
              ? MoonFullText
              : " ";
          string strSun = day.SunriseAsString + " - " + day.SunsetAsString;
          strSun = ShowWinterSummerHour
            ? ( TimeZoneInfo.Local.IsDaylightSavingTime(dayDate.AddDays(1))
              ? AppTranslations.EphemerisCodes.GetLang(Ephemeris.SummerHour)
              : AppTranslations.EphemerisCodes.GetLang(Ephemeris.WinterHour) ) + $" {strSun}"
            : strSun + new string(' ', 3 + 1);
          strSun += " ";
          strSun += ShowShabat && dayDate.DayOfWeek == (DayOfWeek)Settings.ShabatDay
            ? ShabatText
            : "   ";
          string strMoonrise = day.Moonrise is null
            ? MoonNoText
            : AppTranslations.EphemerisCodes.GetLang(Ephemeris.Rise) + day.MoonriseAsString;
          string strMoonset = day.Moonset is null
            ? MoonNoText
            : AppTranslations.EphemerisCodes.GetLang(Ephemeris.Set) + day.MoonsetAsString;
          string strMoon = day.MoonriseOccuring == MoonriseOccurring.BeforeSet
            ? strMoonrise + ColumnSepInner + strMoonset
            : strMoonset + ColumnSepInner + strMoonrise;
          string textDay = AppTranslations.DaysOfWeek.GetLang(dayDate.DayOfWeek).Substring(0, 3);
          string textDate = $"{textDay} {SQLiteDate.ToString(dayDate)}";
          string strDesc;
          string strEvent = day.TorahEventText;
          string sSeason = AppTranslations.SeasonChanges.GetLang(day.SeasonChange);
          strDesc = strEvent.Length != 0 && sSeason.Length != 0
            ? strEvent + " - " + sSeason
            : strEvent + sSeason;
          int lengthAvailable = CalendarFieldSize[ReportFieldText.Events];
          int length = lengthAvailable - 2 - strDesc.Length;
          if ( length < 0 )
            throw new Exception(SysTranslations.ColumnTooShort.GetLang(nameof(ReportFieldText.Events),
                                                                       lengthAvailable,
                                                                       length));
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
          if ( AddGenerateErrorAndCheckIfTooMany(nameof(GenerateReport), day.DateAsString, ex) )
            break;
        }
      content.AppendLine(headerSep);
      try
      {
        File.WriteAllText(Program.TextReportFilePath, content.ToString(), Encoding.UTF8);
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowWarning(SysTranslations.WriteFileError.GetLang(Program.TextReportFilePath, ex.Message));
      }
      return content.ToString();
    }
    finally
    {
      chrono.Stop();
      Settings.BenchmarkGenerateTextReport = chrono.ElapsedMilliseconds;
      SQLiteDate.DaySeparator = tempSep;
      SQLiteDate.DayOrder = tempOrder;
    }
  }

}
