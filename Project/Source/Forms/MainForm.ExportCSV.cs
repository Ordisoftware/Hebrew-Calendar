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
/// <created> 2019-01 </created>
/// <edited> 2019-01 </edited>
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private enum CSVFieldType { Date, IsNewMoon, IsFullMoon, Month, Day, Sunrise, Sunset, Moonrise, Moonset, Events }

    private const string CSVSeparator = ",";

    private void ExportCSV()
    {
      IsGenerating = true;
      UseWaitCursor = true;
      UpdateButtons();
      try
      {
        DoExportCSV();
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

    private void DoExportCSV()
    {
      string headerTxt = "";
      foreach ( CSVFieldType v in Enum.GetValues(typeof(CSVFieldType)) )
        headerTxt += v.ToString() + CSVSeparator;
      headerTxt = headerTxt.Remove(headerTxt.Length - 1);
      var content = new StringBuilder();
      content.AppendLine(headerTxt);
      int progress = 0;
      int count = LunisolarCalendar.LunisolarDays.Count;
      if ( count == 0 ) return;
      var lastyear = SQLiteUtility.GetDate(LunisolarCalendar.LunisolarDays.OrderByDescending(p => p.Date).First().Date).Year;
      foreach ( Data.LunisolarCalendar.LunisolarDaysRow day in LunisolarCalendar.LunisolarDays.Rows )
      {
        var dayDate = SQLiteUtility.GetDate(day.Date);
        if ( !UpdateProgress(progress++, count, LocalizerHelper.ProgressGenerateResultText.GetLang()) ) return;
        if ( day.LunarMonth == 0 ) continue;
        if ( dayDate.Year == lastyear && day.LunarMonth == 1 ) break;
        content.Append(day.Date + CSVSeparator);
        content.Append(day.IsNewMoon + CSVSeparator);
        content.Append(day.IsFullMoon + CSVSeparator);
        content.Append(day.LunarMonth + CSVSeparator);
        content.Append(day.LunarDay + CSVSeparator);
        content.Append(day.Sunrise + CSVSeparator);
        content.Append(day.Sunset + CSVSeparator);
        content.Append(day.Moonrise + CSVSeparator);
        content.Append(day.Moonset + CSVSeparator);
        string strDesc = "";
        string s1 = TorahCelebrations.SeasonEventNames.GetLang((SeasonChangeType)day.SeasonChange);
        string s2 = TorahCelebrations.TorahEventNames.GetLang((TorahEventType)day.TorahEvents);
        strDesc = s1 != "" && s2 != "" ? s1 + " - " + s2 : s1 + s2;
        content.AppendLine(strDesc);
      }
      if ( SaveCSVDialog.ShowDialog() != DialogResult.OK ) return;
      File.WriteAllText(SaveCSVDialog.FileName, content.ToString());

    }

  }

}
