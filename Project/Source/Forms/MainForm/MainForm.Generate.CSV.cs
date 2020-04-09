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
/// <edited> 2019-01 </edited>
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private const string CSVSeparator = ",";

    private StringBuilder GenerateCSV()
    {
      IsGenerating = true;
      UpdateButtons();
      Cursor = Cursors.WaitCursor;
      try
      {
        string headerTxt = "";
        foreach ( CSVReportField v in Enum.GetValues(typeof(CSVReportField)) )
          headerTxt += v.ToString() + CSVSeparator;
        headerTxt = headerTxt.Remove(headerTxt.Length - 1);
        var result = new StringBuilder();
        result.AppendLine(headerTxt);
        int progress = 0;
        int count = DataSet.LunisolarDays.Count;
        if ( count == 0 ) return null;
        var lastyear = SQLiteUtility.GetDate(DataSet.LunisolarDays.OrderByDescending(p => p.Date).First().Date).Year;
        foreach ( Data.DataSet.LunisolarDaysRow day in DataSet.LunisolarDays.Rows )
        {
          var dayDate = SQLiteUtility.GetDate(day.Date);
          if ( !UpdateProgress(progress++, count, Translations.ProgressGenerateReport.GetLang()) ) return null;
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
      catch ( Exception except )
      {
        except.Manage();
        return null;
      }
      finally
      {
        Cursor = Cursors.Default;
        IsGenerating = false;
        UpdateButtons();
      }
    }

  }

}
