/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private void DoExport(ExportAction action, ExportActions process, Action<ViewMode> after)
  {
    DateTime check(int year, int delta)
    {
      var query = LunisolarDays.Where(day => day.Date.Year == year && day.IsNewYear);
      return query.FirstOrDefault()?.Date.AddDays(delta) ?? DateTime.MinValue;
    }
    var interval = new ExportInterval();
    var available = ViewMode.None;
    var view = Settings.CurrentView;
    foreach ( var item in process.Where(p => p.Value != null) ) available |= item.Key;
    if ( !SelectExportTargetForm.Run(action, ref view, available, ref interval) ) return;
    if ( process[view] == null ) throw new AdvancedNotImplementedException(Settings.CurrentView);
    if ( interval.IsDefined )
    {
      interval.Start = check(interval.Start.Value.Year, 0);
      interval.End = check(interval.End.Value.Year + 1, -1);
    }
    if ( process[view].Invoke(interval) )
      after?.Invoke(view);
  }

  private IEnumerable<LunisolarDay> GetDayRows(ExportInterval interval)
  {
    if ( !interval.IsDefined ) return LunisolarDays;
    return LunisolarDays.Where(day => day.Date >= interval.Start.Value && day.Date <= interval.End.Value);
  }

  private IEnumerable<string> GetTextReportLines(ExportInterval interval)
  {
    if ( !interval.IsDefined ) return CalendarText.Lines;
    int lengthToCheck = ApplicationDatabase.CalendarFieldSize[ReportFieldText.Date]
                      + ApplicationDatabase.ColumnSepLeft.Length;
    int lengthToExtract = ApplicationDatabase.ColumnSepLeft.Length + 4;
    var linesFiltered = CalendarText.Lines
                                    .Skip(3)
                                    .SkipWhile(line => filter(line, interval.Start.Value, true))
                                    .TakeWhile(line => filter(line, interval.End.Value, false));
    var result = CalendarText.Lines.Take(3).Concat(linesFiltered);
    return Enumerable.Append(result, CalendarText.Lines.Last());
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

  private bool ProcessTextExport(ExportInterval interval, Func<IEnumerable<string>, bool> action)
  {
    var lines = GetTextReportLines(interval);
    if ( lines.Any() ) return action(lines);
    DisplayManager.ShowInformation(SysTranslations.EmptySlot.GetLang().TrimFirstLast().Titleize());
    return false;
  }

}

public struct ExportInterval
{
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
  public bool IsDefined => Start.HasValue && End.HasValue;
  public int MonthsCount => IsDefined
                            ? ( End.Value.Year - Start.Value.Year ) * 12 + End.Value.Month - Start.Value.Month
                            : 0;
}

[Serializable]
class ExportActions : NullSafeDictionary<ViewMode, Func<ExportInterval, bool>>
{
  public ExportActions()
  {
  }
  protected ExportActions(SerializationInfo info, StreamingContext context) : base(info, context)
  {
  }
}
