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
using System.Linq;
using Serilog.Core;
using Serilog.Events;
using System.Threading;
using Serilog;
using System.IO;

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

    static public void Trace(LogTraceEvent traceEvent, string text = "")
    {
      if ( !_Enabled || !_TraceEnabled ) return;
      try
      {
        string message = string.Empty;
        if ( traceEvent != LogTraceEvent.System )
        {
          string traceEventName = traceEvent.ToString().ToUpper();
          message += $"[ {traceEventName} ]".PadRight(TraceEventMaxLength + 1);
        }
        if ( traceEvent == LogTraceEvent.Leave ) CurrentMargin -= MarginSize;
        message += text.Indent(CurrentMargin, CurrentMargin + message.Length);
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
      string platform = "Undefined";
      try { platform = SystemStatistics.Instance.Platform.SplitNoEmptyLines().Join(" | "); }
      catch { }
      if ( SystemManager.AllowMultipleInstances && Globals.SameRunningProcessesNotThisOne.Count() > 0 )
        Trace(LogTraceEvent.System);
      Trace(LogTraceEvent.System, Separator);
      Trace(LogTraceEvent.System, "# " + "START   : " + Globals.AssemblyTitle);
      Trace(LogTraceEvent.System, "# " + "SYSTEM  : " + platform);
      Trace(LogTraceEvent.System, Separator);
      Trace(LogTraceEvent.System);
    }

    static private void WriteFooter()
    {
      Trace(LogTraceEvent.System);
      Trace(LogTraceEvent.System, Separator);
      Trace(LogTraceEvent.System, "# " + "STOP    : " + Globals.AssemblyTitle);
      Trace(LogTraceEvent.System, "# " + "UNLEFT  : " + EnterCount);
      Trace(LogTraceEvent.System, Separator);
      if ( SystemManager.AllowMultipleInstances && Globals.SameRunningProcessesNotThisOne.Count() == 0 )
        Trace(LogTraceEvent.System);
    }

    public static void ClearTraces(bool norestart = false)
    {
      try
      {
        bool isEnabled = _Enabled;
        try
        {
          string folder = Globals.SinkFileFolderPath;
          string code = Globals.SinkFileCode;
          string extension = Globals.SinkFileExtension;
          Stop();
          foreach ( string path in Directory.GetFiles(folder, code + "*" + extension) )
            try { File.Delete(path); } catch { }
          TraceForm?.TextBox.Clear();
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
