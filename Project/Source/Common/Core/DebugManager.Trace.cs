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
using System.IO;

namespace Ordisoftware.HebrewCommon
{

  static public partial class DebugManager
  {

    static public ShowTextForm TraceContent
    {
      get
      {
        if ( _TraceContent == null )
        {
          _TraceContent = ShowTextForm.Create("Log", "", 800, 600, true, false, false);
          _TraceContent.TextBox.Font = new System.Drawing.Font("Courier New", 8);
          _TraceContent.MaximumSize = new System.Drawing.Size(0, 0);
          _TraceContent.MinimizeBox = true;
          _TraceContent.MaximizeBox = true;
        }
        return _TraceContent;
      }
    }
    static private ShowTextForm _TraceContent;

    private const int MarginSize = 4;
    private const int EnterCountSkip = 2;

    static private int StackSkip = 1;
    static private int EnterCount = 0;
    static private int CurrentMargin = 0;

    static private string Separator = new string('-', 120);

    static private void ChangingTraceFile(RollOverTextWriterTraceListener sender, string filename)
    {
      TraceContent.Text = Path.GetFileNameWithoutExtension(filename);
      TraceContent.TextBox.Text = File.ReadAllText(filename);
    }

    static public void Enter()
    {
      if ( !_Active ) return;
      EnterCount++;
      Log(LogEvent.Enter, ExceptionInfo.GetCallerName(EnterCountSkip));
    }

    static public void Leave()
    {
      if ( !_Active || EnterCount == 0 ) return;
      EnterCount--;
      Log(LogEvent.Leave, ExceptionInfo.GetCallerName(EnterCountSkip));
    }

    static private void LeaveInternal()
    {
      if ( !_Active || EnterCount == 0 ) return;
      Log(LogEvent.Leave, ExceptionInfo.GetCallerName(EnterCountSkip + StackSkip));
      EnterCount--;
      StackSkip = 1;
    }

    static public void Log(LogEvent logevent, string text = "")
    {
      if ( !Active ) return;
      try
      {
        string s = "";
        if ( logevent != LogEvent.System )
        {
          string str = logevent.ToString().ToUpper();
          if ( str.Length < 9 ) str += new string(' ', 9 - str.Length);
          s += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " [ " + str + " ] ";
        }
        if ( logevent == LogEvent.Leave ) CurrentMargin -= MarginSize;
        s = s + new string(' ', CurrentMargin) + text;
        s = s.Indent(0, CurrentMargin + s.Length);
        s += Globals.NL;
        TraceContent.TextBox.AppendText(s);
        System.Diagnostics.Trace.Write(s);
        if ( logevent == LogEvent.Enter ) CurrentMargin += MarginSize;
      }
      catch
      {
      }
    }

    static private void WriteHeader()
    {
      if ( !_Active ) return;
      Log(LogEvent.System, Separator);
      Log(LogEvent.System, "# " + "START  : " + DateTime.Now.ToString());
      Log(LogEvent.System, "# " + "APP    : " + Globals.AssemblyTitle);
      Log(LogEvent.System, "# " + "PATH   : " + Globals.RootFolderPath);
      string platformStr = SystemStatistics.Instance.Platform;
      var platformLines = platformStr.Split(StringSplitOptions.RemoveEmptyEntries);
      Log(LogEvent.System, "# " + "SYSTEM : " + string.Join(" | ", platformLines));
      Log(LogEvent.System);
    }

    static private void WriteFooter()
    {
      if ( !_Active ) return;
      Log(LogEvent.System);
      Log(LogEvent.System, "# " + "UNLEFT : " + EnterCount.ToString());
      Log(LogEvent.System, "# " + "APP    : " + Globals.AssemblyTitle);
      Log(LogEvent.System, "# " + "STOP   : " + DateTime.Now.ToString());
      Log(LogEvent.System, Separator);
      Log(LogEvent.System);
    }

  }

}
