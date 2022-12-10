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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private void DoExport(ExportAction action, ExportActions process, Action<ViewMode> after)
  {
    DateTime check(int year, int delta)
    {
      return LunisolarDays.Find(day => day.Date.Year == year && day.IsNewYear)?.Date.AddDays(delta)
             ?? DateTime.MinValue;
    }
    var interval = new ExportInterval();
    var available = ViewMode.None;
    var view = Settings.CurrentView;
    foreach ( var item in process.Where(p => p.Value is not null) ) available |= item.Key;
    if ( !SelectExportTargetForm.Run(action, ref view, available, ref interval) ) return;
    if ( process[view] is null ) throw new AdvNotImplementedException(Settings.CurrentView);
    if ( interval.IsDefined )
    {
      interval.Start = check(interval.Start.Value.Year, 0);
      interval.End = check(interval.End.Value.Year + 1, -1);
    }
    if ( process[view].Invoke(interval) )
      after?.Invoke(view);
  }

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  private IEnumerable<LunisolarDay> GetDayRows(ExportInterval interval)
  {
    if ( !interval.IsDefined ) return LunisolarDays;
    return LunisolarDays.Where(day => day.Date >= interval.Start && day.Date <= interval.End);
  }

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  private IEnumerable<string> GetTextReportLines(ExportInterval interval)
  {
    if ( !interval.IsDefined ) return TextReport.Lines;
    int lengthToCheck = ApplicationDatabase.CalendarFieldSize[ReportFieldText.Date]
                      + ApplicationDatabase.ColumnSepLeft.Length;
    int lengthToExtract = ApplicationDatabase.ColumnSepLeft.Length + 4;
    var linesFiltered = TextReport.Lines
                                    .Skip(3)
                                    .SkipWhile(line => filter(line, interval.Start.Value, true))
                                    .TakeWhile(line => filter(line, interval.End.Value, false));
    var result = TextReport.Lines.Take(3).Concat(linesFiltered);
    return result.Append(TextReport.Lines[TextReport.Lines.Length - 1]);
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

[SuppressMessage("Performance", "U2U1004:Public value types should implement equality", Justification = "N/A")]
[StructLayout(LayoutKind.Auto)]
struct ExportInterval
{
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
  public readonly bool IsDefined => Start is not null && End is not null;
  public readonly int MonthsCount => IsDefined
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
