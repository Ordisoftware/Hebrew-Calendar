/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Originally developped for Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.IO;

namespace Ordisoftware.HebrewCommon
{

  static public partial class DebugManager
  {

    static DebugManager()
    {
      TraceForm = new TraceForm("TraceFormLocation", "TraceFormSize");
      TraceEventMaxLength = Enum.GetNames(typeof(TraceEvent)).Max(v => v.Length);

    }

    static public readonly TraceForm TraceForm;

    public const int MarginSize = 4;
    public const int EnterCountSkip = 2;

    static private int TraceEventMaxLength;
    static private int StackSkip = 1;
    static private int EnterCount = 0;
    static private int CurrentMargin = 0;

    static private string Separator = new string('-', 120);

    static private void TraceFileChanged(Listener sender, string filename)
    {
      if ( TraceForm == null ) return;
      if ( TraceForm.IsDisposed ) return;
      if ( !File.Exists(filename) ) return;
      TraceForm.Text = Path.GetFileNameWithoutExtension(filename);
      TraceForm.TextBox.Clear();
      TraceForm.AppendText(File.ReadAllText(filename));
    }

    static public void Enter()
    {
      if ( !_Enabled ) return;
      EnterCount++;
      Trace(TraceEvent.Enter, ExceptionInfo.GetCallerName(EnterCountSkip));
    }

    static public void Leave()
    {
      if ( !_Enabled || EnterCount == 0 ) return;
      EnterCount--;
      Trace(TraceEvent.Leave, ExceptionInfo.GetCallerName(EnterCountSkip));
    }

    static private void LeaveInternal()
    {
      if ( !_Enabled || EnterCount == 0 ) return;
      Trace(TraceEvent.Leave, ExceptionInfo.GetCallerName(EnterCountSkip + StackSkip));
      EnterCount--;
      StackSkip = 1;
    }

    static public void Trace(TraceEvent traceEvent, string text = "")
    {
      if ( !Enabled ) return;
      SystemManager.TryCatch(() =>
      {
        string message = "";
        if ( traceEvent != TraceEvent.System )
        {
          string traceEventName = traceEvent.ToString().ToUpper().PadRight(TraceEventMaxLength);
          message += $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [ {traceEventName} ] ";
        }
        try
        {
          if ( traceEvent == TraceEvent.Leave ) CurrentMargin -= MarginSize;
          message += text.Indent(CurrentMargin, CurrentMargin + message.Length) + Globals.NL;
          SystemManager.TryCatch(() => { if ( !TraceForm.IsDisposed ) TraceForm?.AppendText(message); });
          System.Diagnostics.Trace.Write(message);
        }
        finally
        {
          if ( traceEvent == TraceEvent.Enter ) CurrentMargin += MarginSize;
        }
      });
    }

    static private void WriteHeader()
    {
      if ( !_Enabled ) return;
      string platform = "Undefined";
      SystemManager.TryCatch(() => { platform = SystemStatistics.Instance.Platform.SplitNoEmptyLines().Join(" | "); });
      Trace(TraceEvent.System, Separator);
      Trace(TraceEvent.System, "# " + "APP    : " + Globals.AssemblyTitle);
      Trace(TraceEvent.System, "# " + "START  : " + DateTime.Now);
      Trace(TraceEvent.System, "# " + "SYSTEM : " + platform);
      Trace(TraceEvent.System, Separator);
      Trace(TraceEvent.System);
    }

    static private void WriteFooter()
    {
      if ( !_Enabled ) return;
      Trace(TraceEvent.System);
      Trace(TraceEvent.System, Separator);
      Trace(TraceEvent.System, "# " + "APP    : " + Globals.AssemblyTitle);
      Trace(TraceEvent.System, "# " + "STOP   : " + DateTime.Now);
      Trace(TraceEvent.System, "# " + "UNLEFT : " + EnterCount);
      Trace(TraceEvent.System, Separator);
      Trace(TraceEvent.System);
    }

    public static void ClearTraces(bool norestart = false)
    {
      if ( !_Enabled ) return;
      if ( _Enabled && !_TraceEnabled ) return;
      SystemManager.TryCatchManage(() =>
      {
        try
        {
          string path = TraceListener.Path;
          string code = TraceListener.Code;
          string extension = TraceListener.Extension;
          Stop();
          foreach ( string filename in Directory.GetFiles(path, code + "*" + extension) )
          {
            string date = Path.GetFileNameWithoutExtension(filename).Replace(code, "").Trim();
            SystemManager.TryCatch(() => File.Delete(filename));
          }
          TraceForm?.TextBox.Clear();
        }
        finally
        {
          if ( !norestart )
          {
            Start();
            Trace(TraceEvent.Message, $"{nameof(DebugManager)}.{nameof(ClearTraces)}");
          }
        }
      });
    }

  }

}
