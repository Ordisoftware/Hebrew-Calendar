/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2007-05 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

using Serilog;
using Serilog.Core;
using Serilog.Events;

static partial class DebugManager
{

  class ProcessIdEnricher : ILogEventEnricher
  {
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
      var id = Globals.ProcessId.ToString(IdWidth);
      logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ProcessId", id));
    }
  }

  class ThreadIdEnricher : ILogEventEnricher
  {
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
      var id = Environment.CurrentManagedThreadId.ToString(IdWidth);
      logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", id));
    }
  }

  static public readonly TraceForm TraceForm;
  static public readonly string IdWidth = "D6";
  static public int MarginSize { get; set; } = 4;
  static public int EnterCountSkip { get; set; } = 2;

  static private int StackSkip = 1;
  static private int EnterCount;
  static private int CurrentMargin;
  static private readonly int TraceEventMaxLength;
  static private readonly string Separator = new('-', 120);

  static DebugManager()
  {
    TraceEventMaxLength = Enum.GetNames(typeof(LogTraceEvent)).Max(v => v.Length);
    TraceForm = new TraceForm("TraceFormLocation", "TraceFormSize", "TraceFormTextBoxFontSize", "TraceFormShowOnlyErrors");
  }

  [SuppressMessage("Redundancy", "RCS1163:Unused parameter.", Justification = "Event Handler")]
  static private void TraceEventAdded(string sourceContext, string str)
  {
    if ( TraceForm is null ) return;
    if ( TraceForm.IsDisposed ) return;
    TraceForm.AppendText(str);
  }

  static public void Enter()
  {
    if ( !_Enabled ) return;
    EnterCount++;
    Trace(LogTraceEvent.Enter, ExceptionInfo.GetCallerName(EnterCountSkip));
  }

  static public void Leave()
  {
    if ( !_Enabled || EnterCount == 0 ) return;
    EnterCount--;
    Trace(LogTraceEvent.Leave, ExceptionInfo.GetCallerName(EnterCountSkip));
  }

  static private void LeaveInternal()
  {
    if ( !_Enabled || EnterCount == 0 ) return;
    EnterCount--;
    StackSkip = 1;
    Trace(LogTraceEvent.Leave, ExceptionInfo.GetCallerName(EnterCountSkip + StackSkip));
  }

  static public readonly string EventSeparator = "|";

  [SuppressMessage("CodeQuality", "Serilog004:Constant MessageTemplate verifier", Justification = "N/A")]
  static public void Trace(LogTraceEvent traceEvent, string text = "")
  {
    if ( !_Enabled || !_TraceEnabled ) return;
    try
    {
      string message = string.Empty;
      if ( traceEvent != LogTraceEvent.System )
      {
        string traceEventName = traceEvent.ToString().ToUpper().PadLeft(TraceEventMaxLength);
        message += $"{EventSeparator} {Globals.TraceSigns[traceEvent]} {EventSeparator} {traceEventName} {EventSeparator} ";
      }
      if ( traceEvent == LogTraceEvent.Leave ) CurrentMargin -= MarginSize;
      message += text.Indent(CurrentMargin, Globals.SinkFileEventTemplateSize + CurrentMargin + message.Length);
      Log.Logger.Information(message);
    }
    catch
    {
    }
    finally
    {
      if ( traceEvent == LogTraceEvent.Enter ) CurrentMargin += MarginSize;
    }
  }

  static private void WriteHeader()
  {
    string platform;
    try { platform = SystemStatistics.Instance.Platform.SplitNoEmptyLines().Join($" {EventSeparator} "); }
    catch { platform = "Unknown platform"; }
    Trace(LogTraceEvent.Start, Globals.AssemblyTitle);
    Trace(LogTraceEvent.Start, Globals.ApplicationExeFullPath);
    Trace(LogTraceEvent.Start, platform);
    Trace(LogTraceEvent.Start, $"FreeMem: {SystemStatistics.Instance.PhysicalMemoryFree}" +
                               $" {EventSeparator} RAM: {SystemStatistics.Instance.TotalVisibleMemory}");
  }

  static private void WriteFooter()
  {
    Trace(LogTraceEvent.Stop, Globals.AssemblyTitle + $" (Unleft: {EnterCount})");
    Trace(LogTraceEvent.Stop, $"GC: {SystemStatistics.Instance.MemoryGC}" +
                              $" {EventSeparator} Peak: {SystemStatistics.Instance.MemoryGCPeak}");
  }

  [SuppressMessage("Performance", "U2U1011:Return types should be specific", Justification = "N/A")]
  static public IEnumerable<string> GetTraceFiles(bool sortByDateOnly)
  {
    string folder = Globals.SinkFileFolderPath;
    string code = Globals.SinkFileCode;
    string extension = Globals.TraceFileExtension;
    var list = Directory.GetFiles(folder, code + "*" + extension)
                        .Where(f => !SystemManager.IsFileLocked(f))
                        .OrderBy(f => new FileInfo(f).CreationTime);
    return sortByDateOnly ? list : list.OrderBy(f => new FileInfo(f).CreationTime).ThenBy(f => f);
  }

  static public void ClearTraces(bool norestart = false, bool all = false)
  {
    try
    {
      bool isEnabled = _Enabled;
      try
      {
        switch ( Globals.TraceFileRollOverMode )
        {
          case TraceFileRollOverMode.Session:
            if ( !delete(Globals.SessionFileRetainedFileCountLimit) ) return;
            break;
          case TraceFileRollOverMode.SinkFile:
            if ( !all || !delete(Globals.SinkFileRetainedFileCountLimit) ) return;
            break;
        }
        TraceForm?.TextBoxCurrent.Clear();
        //
        bool delete(int retain)
        {
          if ( retain == 0 ) return false;
          Stop();
          var list = GetTraceFiles(true);
          if ( !all ) list = list.Take(list.Count() - retain + 1);
          foreach ( string file in list )
            try { File.Delete(file); } catch { }
          return true;
        }
      }
      finally
      {
        if ( !norestart && isEnabled )
        {
          Start();
          if ( all ) Trace(LogTraceEvent.Completed, $"{nameof(DebugManager)}.{nameof(ClearTraces)}(all)");
        }
      }
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

}
