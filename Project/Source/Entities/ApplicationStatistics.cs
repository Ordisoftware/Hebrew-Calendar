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

  public class ApplicationStatistics
  {
    static public ApplicationStatistics Instance = new ApplicationStatistics();

    public string StartingTime => Program.Settings.BenchmarkStartingApp.FormatMilliseconds();
    public string LoadDataTime => Program.Settings.BenchmarkLoadData.FormatMilliseconds();
    public string GenerateYearsTime => Program.Settings.BenchmarkGenerateYears.FormatMilliseconds();
    public DateTime LastGenerated => Program.Settings.LastGenerated;
    public string FillMonthViewTime => Program.Settings.BenchmarkFillCalendar.FormatMilliseconds();

    public string DBFileSize => SystemHelper.GetFileSize(Globals.DatabaseFileName).FormatBytesSize();
    public string DBMemorySize => MainForm.Instance.DataSet.SizeOf().FormatBytesSize();

    public int DBFirstYear => MainForm.Instance.YearFirst;
    public int DBLastYear => MainForm.Instance.YearLast;
    public int DBYearsInterval => MainForm.Instance.YearLast - MainForm.Instance.YearFirst + 1;
    public int DBRecordsCount => MainForm.Instance.DataSet.LunisolarDays.Count();
    public int DBEventsCount => MainForm.Instance.DataSet.LunisolarDays.Count(d => d.TorahEvents != 0 || d.SeasonChange != 0);
    public int MonthViewEventsCount => MainForm.Instance.CalendarMonth.TheEvents.Count;
  }

}
