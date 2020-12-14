/// <license>
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
/// <created> 2020-12 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void DoExport(ExportAction action, ExportActions process, Action<ViewMode> after)
    {
      DateTime check(int year, int delta)
      {
        var query = DataSet.LunisolarDays.Where(day => SQLiteDate.ToDateTime(day.Date).Year == year
                                                    && day.TorahEventsAsEnum == TorahEvent.NewYearD1);
        return SQLiteDate.ToDateTime(query.FirstOrDefault()?.Date).AddDays(delta);
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

    private IEnumerable<Data.DataSet.LunisolarDaysRow> GetDays(ExportInterval interval)
    {
      if ( interval.IsDefined )
      {
        string start = SQLiteDate.ToString(interval.Start.Value);
        string end = SQLiteDate.ToString(interval.End.Value);
        return DataSet.LunisolarDays.Where(day => day.Date.CompareTo(start) >= 0 && day.Date.CompareTo(end) <= 0);
      }
      else
        return DataSet.LunisolarDays;
    }

  }

  public struct ExportInterval
  {
    public DateTime? Start;
    public DateTime? End;
    public bool IsDefined => Start.HasValue && End.HasValue;
  }

  public class ExportActions : NullSafeDictionary<ViewMode, Func<ExportInterval, bool>>
  {
  }

}
