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
/// <created> 2020-08 </created>
/// <edited> 2020-09 </edited>
using System;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// provide application statistics.
  /// </summary>
  public class ApplicationStatistics
  {

    static public ApplicationStatistics Instance
      = new ApplicationStatistics();

    public string StartingTime
      => Program.Settings.BenchmarkStartingApp.FormatMilliseconds();

    public string LoadDataTime
      => Program.Settings.BenchmarkLoadData.FormatMilliseconds();

    public string GenerateYearsTime
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : Program.Settings.BenchmarkGenerateYears.FormatMilliseconds();

    public string GeneratePopulateDaysTime
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : Program.Settings.BenchmarkPopulateDays.FormatMilliseconds();

    public string GenerateAnalyseDaysTime
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : Program.Settings.BenchmarkAnalyseDays.FormatMilliseconds();

    public string GenerateTextReportTime
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : Program.Settings.BenchmarkGenerateTextReport.FormatMilliseconds();

    public string LastGenerated
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : Program.Settings.LastGenerated.ToString("g");

    public string FillMonthViewTime
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : Program.Settings.BenchmarkFillCalendar.FormatMilliseconds();

    public string DBFirstYear
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : MainForm.Instance.YearFirst.ToString();

    public string DBLastYear
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : MainForm.Instance.YearLast.ToString();

    public string DBYearsInterval
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : MainForm.Instance.YearsInterval.ToString();

    public string DBRecordsCount
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : MainForm.Instance.DataSet.LunisolarDays.Count().ToString();

    public string DBEventsCount
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : MainForm.Instance.DataSet.LunisolarDays.Count(d => d.TorahEvents != 0 || d.SeasonChange != 0).ToString();

    public string MonthViewEventsCount
      => MainForm.Instance.IsGenerating
         ? Localizer.Processing.GetLang()
         : MainForm.Instance.CalendarMonth.TheEvents.Count.ToString();

    public string DBEngine
      => SQLiteOdbcHelper.EngineNameAndVersion;

    public string DBADOdotNETProvider
      => SQLiteOdbcHelper.ADOdotNETProviderName;

    public string DBFileSize
    {
      get
      {
        if ( UpdateDBFileSizeRequired )
        {
          UpdateDBFileSizeRequired = false;
          _DBFileSize = SystemManager.GetFileSize(Globals.DatabaseFilePath).FormatBytesSize().ToString();
        }
        return MainForm.Instance.IsGenerating ? Localizer.Processing.GetLang() : _DBFileSize;
      }
    }
    static private string _DBFileSize;
    static internal bool UpdateDBFileSizeRequired = true;

    public string DBMemorySize
    {
      get
      {
        if ( UpdateDBMemorySizeRequired )
        {
          UpdateDBMemorySizeRequired = false;
          _DBMemorySize = MainForm.Instance.DataSet.SizeOf().FormatBytesSize();
        }
        return MainForm.Instance.IsGenerating ? Localizer.Processing.GetLang() : _DBMemorySize;
      }
    }
    static private string _DBMemorySize;
    static internal bool UpdateDBMemorySizeRequired = true;

  }

}
