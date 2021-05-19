/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2021-05 </edited>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Serilog.Core;
using Serilog.Events;
using System.Threading;
using Serilog;

namespace Ordisoftware.Core
{

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
        var id = Thread.CurrentThread.ManagedThreadId.ToString(IdWidth);
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", id));
      }
    }

    static public readonly TraceForm TraceForm;
    static public string IdWidth = "D6";
    static public int MarginSize = 4;
    static public int EnterCountSkip = 2;

    static private int StackSkip = 1;
    static private int EnterCount = 0;
    static private int CurrentMargin = 0;
    static private int TraceEventMaxLength;
    static private string Separator = new string('-', 120);

    static DebugManager()
    {
      TraceEventMaxLength = Enum.GetNames(typeof(LogTraceEvent)).Max(v => v.Length);
      TraceForm = new TraceForm("TraceFormLocation", "TraceFormSize", "TraceFormTextBoxFontSize");
    }

    static private void TraceEventAdded(string sourceContext, string str)
    {
      if ( TraceForm == null ) return;
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

    static private Dictionary<LogTraceEvent, char> Signes = new Dictionary<LogTraceEvent, char>
    {
      [LogTraceEvent.System] = ' ',
      [LogTraceEvent.Start] = '>',
      [LogTraceEvent.Stop] = '.',
      [LogTraceEvent.Enter] = '+',
      [LogTraceEvent.Leave] = '-',
      [LogTraceEvent.Message] = '#',
      [LogTraceEvent.Data] = '*',
      [LogTraceEvent.Error] = '!',
      [LogTraceEvent.Exception] = '!'
    };

    static public void Trace(LogTraceEvent traceEvent, string text = "")
    {
      if ( !_Enabled || !_TraceEnabled ) return;
      try
      {
        string message = string.Empty;
        if ( traceEvent != LogTraceEvent.System )
        {
          string traceEventName = traceEvent.ToString().ToUpper().PadLeft(TraceEventMaxLength);
          message += $"| {Signes[traceEvent]} | {traceEventName} | ";
        }
        if ( traceEvent == LogTraceEvent.Leave ) CurrentMargin -= MarginSize;
        message += text.Indent(CurrentMargin, 5 + Globals.SinkFileTemplateSize + CurrentMargin + message.Length);
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
      string platform = "";
      try { platform = SystemStatistics.Instance.Platform.SplitNoEmptyLines().Join(" | "); }
      catch { platform = "Unknown platform"; }
      Trace(LogTraceEvent.Start, Globals.AssemblyTitle);
      Trace(LogTraceEvent.Start, Globals.ApplicationExeFullPath);
      Trace(LogTraceEvent.Start, platform);
      Trace(LogTraceEvent.Start, $"FreeMem: {SystemStatistics.Instance.PhysicalMemoryFree} | RAM: {SystemStatistics.Instance.TotalVisibleMemory}");
    }

    static private void WriteFooter()
    {
      Trace(LogTraceEvent.Stop, Globals.AssemblyTitle + $" (Unleft: {EnterCount})");
      Trace(LogTraceEvent.Stop, $"GC: {SystemStatistics.Instance.MemoryGC} | Peak: {SystemStatistics.Instance.MemoryGCPeak}");
    }

    static public IEnumerable<string> GetTraceFiles()
    {
      string folder = Globals.SinkFileFolderPath;
      string code = Globals.SinkFileCode;
      string extension = Globals.SinkFileExtension;
      foreach ( string file in Directory.GetFiles(folder, code + "*" + extension) )
        // TODO if (not locked)
        yield return file;
    }

    static public void ClearTraces(bool norestart = false)
    {
      try
      {
        bool isEnabled = _Enabled;
        try
        {
          Stop();
          foreach ( string file in GetTraceFiles() )
            try { File.Delete(file); } catch { }
          TraceForm?.TextBoxCurrent.Clear();
        }
        finally
        {
          if ( !norestart && isEnabled )
          {
            Start();
            Trace(LogTraceEvent.Message, $"{nameof(DebugManager)}.{nameof(ClearTraces)}");
          }
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}
