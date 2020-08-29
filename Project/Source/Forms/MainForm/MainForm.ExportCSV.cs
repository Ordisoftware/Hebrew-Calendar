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
using System.Text;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private const string CSVSeparator = ",";

    private StringBuilder GenerateCSV()
    {
      IsGenerating = true;
      UpdateButtons();
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      try
      {
        string headerTxt = "";
        foreach ( ReportFieldCSV v in Enum.GetValues(typeof(ReportFieldCSV)) )
          headerTxt += v.ToString() + CSVSeparator;
        headerTxt = headerTxt.Remove(headerTxt.Length - 1);
        var result = new StringBuilder();
        result.AppendLine(headerTxt);
        if ( DataSet.LunisolarDays.Count == 0 ) return null;
        var lastyear = SQLite.GetDate(DataSet.LunisolarDays.OrderByDescending(p => p.Date).First().Date).Year;
        LoadingForm.Instance.Initialize(Translations.ProgressGenerateReport.GetLang(),
                                        DataSet.LunisolarDays.Count,
                                        Program.LoadingFormLoadDB);
        foreach ( Data.DataSet.LunisolarDaysRow day in DataSet.LunisolarDays.Rows )
        {
          LoadingForm.Instance.DoProgress();
          var dayDate = SQLite.GetDate(day.Date);
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
          string strPhase = Translations.MoonPhase.GetLang((MoonPhase)day.MoonPhase);
          result.Append(strPhase + CSVSeparator);
          string strSeason = Translations.SeasonEvent.GetLang((SeasonChange)day.SeasonChange);
          result.Append(strSeason + CSVSeparator);
          string strEvent = Translations.TorahEvent.GetLang((TorahEvent)day.TorahEvents);
          result.AppendLine(strEvent);
        }
        return result;
      }
      catch ( Exception ex )
      {
        ex.Manage();
        return null;
      }
      finally
      {
        Cursor = cursor;
        IsGenerating = false;
        UpdateButtons();
      }
    }

  }

}
