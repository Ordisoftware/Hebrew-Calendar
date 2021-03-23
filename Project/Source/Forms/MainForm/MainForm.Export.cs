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
/// <created> 2020-12 </created>
/// <edited> 2021-03 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Ordisoftware.Core;
using LunisolarDaysRow = Ordisoftware.Hebrew.Calendar.Data.DataSet.LunisolarDaysRow;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private void DoExport(ExportAction action, ExportActions process, Action<ViewMode> after)
    {
      DateTime check(int year, int delta)
      {
        var query = DataSet.LunisolarDays.Where(day => day.DateAsDateTime.Year == year && day.IsNewYear);
        return query.FirstOrDefault()?.DateAsDateTime.AddDays(delta) ?? DateTime.MinValue;
      }
      var interval = new ExportInterval();
      var available = ViewMode.None;
      var view = Settings.CurrentView;
      foreach ( var item in process.Where(p => p.Value != null) ) available |= item.Key;
      if ( !SelectExportTargetForm.Run(action, ref view, available, ref interval) ) return;
      if ( process[view] == null ) throw new NotImplementedExceptionEx(Settings.CurrentView);
      if ( interval.IsDefined )
      {
        interval.Start = check(interval.Start.Value.Year, 0);
        interval.End = check(interval.End.Value.Year + 1, -1);
      }
      if ( process[view].Invoke(interval) )
        after?.Invoke(view);
    }

    private IEnumerable<LunisolarDaysRow> GetDayRows(ExportInterval interval)
    {
      if ( !interval.IsDefined ) return DataSet.LunisolarDays;
      string start = SQLiteDate.ToString(interval.Start.Value);
      string end = SQLiteDate.ToString(interval.End.Value);
      return DataSet.LunisolarDays.Where(day => day.Date.CompareTo(start) >= 0 && day.Date.CompareTo(end) <= 0);
    }

    private IEnumerable<string> GetTextReportLines(ExportInterval interval)
    {
      if ( !interval.IsDefined ) return CalendarText.Lines;
      int lengthToCheck = CalendarFieldSize[ReportFieldText.Date] + ColumnSepLeft.Length;
      int lengthToExtract = ColumnSepLeft.Length + 4;
      var linesFiltered = CalendarText.Lines
                                      .Skip(3)
                                      .SkipWhile(line => filter(line, interval.Start.Value, true))
                                      .TakeWhile(line => filter(line, interval.End.Value, false));
      return CalendarText.Lines.Take(3).Concat(linesFiltered).Append(CalendarText.Lines.Last());
      //
      bool filter(string line, DateTime dateTrigger, bool strict)
      {
        if ( line.Length < lengthToCheck ) return true;
        string str = line.Substring(lengthToExtract, 10);
        if ( DateTime.TryParseExact(str, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) )
          return strict ? date < dateTrigger : date <= dateTrigger;
        else
          return true;
      }
    }

  }

  public struct ExportInterval
  {
    public DateTime? Start;
    public DateTime? End;
    public bool IsDefined => Start.HasValue && End.HasValue;
    public int MonthsCount => IsDefined
                              ? ( End.Value.Year - Start.Value.Year ) * 12 + End.Value.Month - Start.Value.Month
                              : 0;
  }

  [Serializable]
  partial class ExportActions : NullSafeDictionary<ViewMode, Func<ExportInterval, bool>>
  {
    public ExportActions() : base()
    {
    }
    protected ExportActions(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }

}
