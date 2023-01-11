/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  [SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "N/A")]
  private string ExportSaveCSV(ExportInterval interval)
  {
    UpdateButtons();
    var cursor = Cursor;
    Cursor = Cursors.WaitCursor;
    try
    {
      var items = GetDayRows(interval).ToList();
      var lastyear = LunisolarDays.OrderByDescending(p => p.Date).First().Date.Year;
      string csvSeparator = Globals.CSVSeparator.ToString();
      string headerTxt = string.Empty;
      foreach ( var field in Enums.GetValues<ReportFieldCSV>() )
        headerTxt += field.ToString() + Globals.CSVSeparator;
      headerTxt = headerTxt.Remove(headerTxt.Length - 1);
      var result = new StringBuilder(items.Count * headerTxt.Length);
      result.AppendLine(headerTxt);
      if ( LunisolarDays.Count == 0 ) return null;
      LoadingForm.Instance.Initialize(AppTranslations.ProgressGenerateReport.GetLang(),
                                      items.Count,
                                      Program.LoadingFormLoadDB);
      foreach ( LunisolarDay day in items )
      {
        LoadingForm.Instance.DoProgress();
        var dayDate = day.Date;
        if ( day.LunarMonth == 0 ) continue;
        if ( dayDate.Year == lastyear && day.LunarMonth == 1 ) break;
        result.Append(day.DateAsString).Append(csvSeparator);
        result.Append(day.IsNewMoon).Append(csvSeparator);
        result.Append(day.IsFullMoon).Append(csvSeparator);
        result.Append(day.LunarMonth).Append(csvSeparator);
        result.Append(day.LunarDay).Append(csvSeparator);
        result.Append(day.SunriseAsString).Append(csvSeparator);
        result.Append(day.SunsetAsString).Append(csvSeparator);
        result.Append(day.MoonriseAsString).Append(csvSeparator);
        result.Append(day.MoonsetAsString).Append(csvSeparator);
        string strMoonriseType = day.MoonriseOccuring.ToStringExport(AppTranslations.MoonriseOccurings);
        string strPhase = day.MoonPhase.ToStringExport(AppTranslations.MoonPhases);
        string strSeason = day.SeasonChange.ToStringExport(AppTranslations.SeasonChanges);
        string strEvent = day.TorahEvent.ToStringExport(AppTranslations.CelebrationDays);
        result.Append(strMoonriseType).Append(csvSeparator);
        result.Append(strPhase).Append(csvSeparator);
        result.Append(strSeason).Append(csvSeparator);
        result.AppendLine(strEvent);
      }
      return result.ToString();
    }
    catch ( Exception ex )
    {
      ex.Manage();
      return null;
    }
    finally
    {
      Cursor = cursor;
      UpdateButtons();
    }
  }

}
