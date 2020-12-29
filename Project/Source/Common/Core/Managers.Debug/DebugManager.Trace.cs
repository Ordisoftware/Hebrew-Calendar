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
/// <edited> 2020-09 </edited>
using System;
using System.Linq;
using System.IO;

namespace Ordisoftware.Core
{

  static public partial class DebugManager
  {

    static DebugManager()
    {
      TraceForm = new TraceForm("TraceFormLocation", "TraceFormSize", "TraceFormTextBoxFontSize");
      TraceEventMaxLength = Enum.GetNames(typeof(LogTraceEvent)).Max(v => v.Length);
    }

    static public readonly TraceForm TraceForm;

    public const int MarginSize = 4;
    public const int EnterCountSkip = 2;

    static private int TraceEventMaxLength;
    static private int StackSkip = 1;
    static private int EnterCount = 0;
    static private int CurrentMargin = 0;

    static private string Separator = new string('-', 120);

    static private void TraceFileChanged(Listener sender, string filePath)
    {
      if ( TraceForm == null ) return;
      if ( TraceForm.IsDisposed ) return;
      if ( !File.Exists(filePath) ) return;
      TraceForm.Text = Path.GetFileNameWithoutExtension(filePath);
      TraceForm.TextBox.Clear();
      TraceForm.AppendText(File.ReadAllText(filePath));
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
        string message = "";
        if ( traceEvent != LogTraceEvent.System )
        {
          string traceEventName = traceEvent.ToString().ToUpper().PadRight(TraceEventMaxLength);
          message += $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [ {traceEventName} ] ";
        }
        if ( traceEvent == LogTraceEvent.Leave ) CurrentMargin -= MarginSize;
        message += text.Indent(CurrentMargin, CurrentMargin + message.Length) + Globals.NL;
        try
        {
          if ( !TraceForm.IsDisposed )
            TraceForm?.AppendText(message);
        }
        catch
        {
        }
        System.Diagnostics.Trace.Write(message);
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
      try
      {
        platform = SystemStatistics.Instance.Platform.SplitNoEmptyLines().Join(" | ");
      }
      catch
      {
      }
      Trace(LogTraceEvent.System, Separator);
      Trace(LogTraceEvent.System, "# " + "START   : " + DateTime.Now);
      Trace(LogTraceEvent.System, "# " + "PROCESS : " + Globals.AssemblyTitle);
      Trace(LogTraceEvent.System, "# " + "SYSTEM  : " + platform);
      Trace(LogTraceEvent.System, Separator);
      Trace(LogTraceEvent.System);
    }

    static private void WriteFooter()
    {
      string unleft = TraceListener != null ? TraceListener.IsRollOver ? " (RollOver)" : "" : "";
      Trace(LogTraceEvent.System);
      Trace(LogTraceEvent.System, Separator);
      Trace(LogTraceEvent.System, "# " + "STOP    : " + DateTime.Now);
      Trace(LogTraceEvent.System, "# " + "PROCESS : " + Globals.AssemblyTitle);
      Trace(LogTraceEvent.System, "# " + "UNLEFT  : " + EnterCount + unleft);
      Trace(LogTraceEvent.System, Separator);
      Trace(LogTraceEvent.System);
    }

    public static void ClearTraces(bool norestart = false)
    {
      if ( TraceListener == null ) return;
      try
      {
        bool isEnabled = _Enabled;
        try
        {
          string folder = TraceListener.Folder;
          string code = TraceListener.Code;
          string extension = TraceListener.Extension;
          Stop();
          foreach ( string path in Directory.GetFiles(folder, code + "*" + extension) )
            try
            {
              File.Delete(path);
            }
            catch
            {
            }
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
