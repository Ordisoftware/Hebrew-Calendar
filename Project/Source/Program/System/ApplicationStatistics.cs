﻿/// <license>
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
/// <created> 2020-08 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Collections.Generic;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// provide application statistics.
  /// </summary>
  partial class ApplicationStatistics
  {

    static private List<LunisolarDay> LunisolarDays => ApplicationDatabase.Instance.LunisolarDays;

    static public readonly ApplicationStatistics Instance
      = new ApplicationStatistics();

    public string StartingTime
      => Program.Settings.BenchmarkStartingApp.FormatMilliseconds();

    public string TranslateTime
      => Program.Settings.BenchmarkTranslate.FormatMilliseconds();

    public string LoadDataTime
      => Program.Settings.BenchmarkLoadData.FormatMilliseconds();

    public string GenerateYearsTime
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : Program.Settings.BenchmarkGenerateYears.FormatMilliseconds();

    public string GeneratePopulateDaysTime
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : Program.Settings.BenchmarkPopulateDays.FormatMilliseconds();

    public string GenerateAnalyseDaysTime
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : Program.Settings.BenchmarkAnalyseDays.FormatMilliseconds();

    public string GenerateTextReportTime
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : Program.Settings.BenchmarkGenerateTextReport.FormatMilliseconds();

    public string LastGenerated
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : Program.Settings.LastGenerated.ToString("g");

    public string FillMonthViewTime
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : Program.Settings.BenchmarkFillCalendar.FormatMilliseconds();

    public string DBFirstYear
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : MainForm.Instance.YearFirst.ToString();

    public string DBLastYear
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : MainForm.Instance.YearLast.ToString();

    public string DBYearsInterval
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : MainForm.Instance.YearsInterval.ToString();

    public string DBRecordsCount
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : LunisolarDays.Count.ToString();

    public string DBEventsCount
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : LunisolarDays.Count(d => d.TorahEvent != 0 || d.SeasonChange != 0).ToString();

    public string MonthViewEventsCount
      => Globals.IsGenerating
         ? SysTranslations.Processing.GetLang()
         : MainForm.Instance.CalendarMonth.TheEvents.Count.ToString();

    public string DBEngine
      => SQLiteNetHelper.EngineNameAndVersion;

    public string DBProvider
      => SQLiteNetHelper.ProviderName;

    public string DBFileSize
    {
      get
      {
        if ( UpdateDBFileSizeRequired )
        {
          UpdateDBFileSizeRequired = false;
          _DBFileSize = SystemManager.GetFileSize(Globals.ApplicationDatabaseFilePath).FormatBytesSize().ToString();
        }
        return Globals.IsGenerating ? SysTranslations.Processing.GetLang() : _DBFileSize;
      }
    }
    static private string _DBFileSize;
    static internal bool UpdateDBFileSizeRequired { get; set; } = true;

    public string DBMemorySize
    {
      get
      {
        if ( UpdateDBMemorySizeRequired )
        {
          UpdateDBMemorySizeRequired = false;
          _DBMemorySize = LunisolarDays.SizeOf().FormatBytesSize();
        }
        return Globals.IsGenerating ? SysTranslations.Processing.GetLang() : _DBMemorySize;
      }
    }
    static private string _DBMemorySize;
    static internal bool UpdateDBMemorySizeRequired { get; set; } = true;

    public string DBCommonFileSize
    {
      get
      {
        if ( UpdateDBCommonFileSizeRequired )
        {
          UpdateDBCommonFileSizeRequired = false;
          _DBCommonFileSize = SystemManager.GetFileSize(Globals.CommonDatabaseFilePath).FormatBytesSize().ToString();
        }
        return _DBCommonFileSize;
      }
    }
    static private string _DBCommonFileSize;
    static internal bool UpdateDBCommonFileSizeRequired { get; set; } = true;

    public string DBParashotMemorySize
    {
      get
      {
        if ( UpdateDDParashotMemorySizeRequired )
        {
          UpdateDDParashotMemorySizeRequired = false;
          _DDParashotMemorySize = HebrewDatabase.Instance.Parashot?.SizeOf().FormatBytesSize()
                               ?? SysTranslations.DatabaseTableClosed.GetLang();
        }
        return _DDParashotMemorySize;
      }
    }
    static private string _DDParashotMemorySize;
    static internal bool UpdateDDParashotMemorySizeRequired { get; set; } = true;

  }

}
