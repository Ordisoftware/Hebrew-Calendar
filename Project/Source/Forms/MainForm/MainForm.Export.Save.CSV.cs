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
/// <edited> 2021-01 </edited>
using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using EnumsNET;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private const string CSVSeparator = ",";

    private string ExportSaveCSV(ExportInterval interval)
    {
      UpdateButtons();
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      try
      {
        string headerTxt = string.Empty;
        foreach ( var field in Enums.GetValues<ReportFieldCSV>() )
          headerTxt += field.ToString() + CSVSeparator;
        headerTxt = headerTxt.Remove(headerTxt.Length - 1);
        var result = new StringBuilder();
        result.AppendLine(headerTxt);
        if ( DataSet.LunisolarDays.Count == 0 ) return null;
        var items = GetDayRows(interval);
        var lastyear = SQLiteDate.ToDateTime(DataSet.LunisolarDays.OrderByDescending(p => p.Date).First().Date).Year;
        LoadingForm.Instance.Initialize(AppTranslations.ProgressGenerateReport.GetLang(),
                                        items.Count(),
                                        Program.LoadingFormLoadDB);
        foreach ( Data.DataSet.LunisolarDaysRow day in items )
        {
          LoadingForm.Instance.DoProgress();
          var dayDate = SQLiteDate.ToDateTime(day.Date);
          if ( day.LunarMonth == 0 ) continue;
          if ( dayDate.Year == lastyear && day.LunarMonth == 1 ) break;
          result.Append(day.Date + CSVSeparator);
          result.Append(day.IsNewMoon + CSVSeparator);
          result.Append(day.IsFullMoon + CSVSeparator);
          result.Append(day.LunarMonth + CSVSeparator);
          result.Append(day.LunarDay + CSVSeparator);
          result.Append(day.Sunrise + CSVSeparator);
          result.Append(day.Sunset + CSVSeparator);
          result.Append(day.Moonrise + CSVSeparator);
          result.Append(day.Moonset + CSVSeparator);
          string strMoonriseType = day.MoonriseOccuringAsEnum.ToStringExport(AppTranslations.MoonRiseOccuring);
          string strPhase = day.MoonPhaseAsEnum.ToStringExport(AppTranslations.MoonPhase);
          string strSeason = day.SeasonChangeAsEnum.ToStringExport(AppTranslations.SeasonChange);
          string strEvent = day.TorahEventsAsEnum.ToStringExport(AppTranslations.TorahEvent);
          result.Append(strMoonriseType + CSVSeparator);
          result.Append(strPhase + CSVSeparator);
          result.Append(strSeason + CSVSeparator);
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

}
