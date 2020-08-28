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
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public class SystemStatistics
  {
    public string OperatingSystem => SystemHelper.OperatingSystem;
    public string TotalVisibleMemory => SystemHelper.TotalVisibleMemory;
    public string PhysicalMemoryFree => SystemHelper.PhysicalMemoryFree;
    public string RunningTime => ( (long)DateTime.Now.Subtract(Program.Settings.BenchmarkStartDateTime).TotalMilliseconds ).FormatSeconds();
    public string StartingTime => Program.Settings.BenchmarkStartingApp.FormatMilliseconds();
    public string LoadDataTime => Program.Settings.BenchmarkLoadData.FormatMilliseconds();
    public string GenerateYearsTime => Program.Settings.BenchmarkGenerateYears.FormatMilliseconds();
    public string FillMonthViewTime => Program.Settings.BenchmarkFillCalendar.FormatMilliseconds();
    public string DBFirstYear => MainForm.Instance.YearFirst.ToString();
    public string DBLastYear => MainForm.Instance.YearLast.ToString();
    public string DBYearsInterval => ( MainForm.Instance.YearLast - MainForm.Instance.YearFirst + 1 ).ToString();
    public string DBRecordsCount => MainForm.Instance.DataSet.LunisolarDays.Count().ToString();
    public string DBEventsCount => MainForm.Instance.DataSet.LunisolarDays.Count(d => d.TorahEvents != 0 || d.SeasonChange != 0).ToString();
    public string MonthViewEventsCount => MainForm.Instance.CalendarMonth.Events.Count.ToString();
    public string DBFileSize => SystemHelper.DatabaseFileSize;
    public string DBMemorySize
    {
      get
      {
        long size = MainForm.Instance.DataSet.SizeOf();
        return size >= 0 ? size.FormatBytesSize() : Localizer.EmptySlot.GetLang();
      }
    }

  }

}
