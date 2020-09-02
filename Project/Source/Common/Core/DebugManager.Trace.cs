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

    static public readonly LogForm LogForm = new LogForm("LogFormLocation", "LogFormSize");

    private const int MarginSize = 4;
    private const int EnterCountSkip = 2;

    static private int StackSkip = 1;
    static private int EnterCount = 0;
    static private int CurrentMargin = 0;

    static private string Separator = new string('-', 120);

    static private void ChangingTraceFile(RollOverTextWriterTraceListener sender, string filename)
    {
      LogForm.Text = Path.GetFileNameWithoutExtension(filename);
      LogForm.AppendText(File.ReadAllText(filename), true);
    }

    static public void Enter()
    {
      if ( !_Enabled ) return;
      EnterCount++;
      Log(LogEvent.Enter, ExceptionInfo.GetCallerName(EnterCountSkip));
    }

    static public void Leave()
    {
      if ( !_Enabled || EnterCount == 0 ) return;
      EnterCount--;
      Log(LogEvent.Leave, ExceptionInfo.GetCallerName(EnterCountSkip));
    }

    static private void LeaveInternal()
    {
      if ( !_Enabled || EnterCount == 0 ) return;
      Log(LogEvent.Leave, ExceptionInfo.GetCallerName(EnterCountSkip + StackSkip));
      EnterCount--;
      StackSkip = 1;
    }

    static public void Log(LogEvent logevent, string text = "")
    {
      if ( !Enabled ) return;
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
        SystemHelper.TryCatch(() => LogForm.AppendText(s, true));
        System.Diagnostics.Trace.Write(s);
        if ( logevent == LogEvent.Enter ) CurrentMargin += MarginSize;
      }
      catch
      {
      }
    }

    static private void WriteHeader()
    {
      if ( !_Enabled ) return;
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
      if ( !_Enabled ) return;
      Log(LogEvent.System);
      Log(LogEvent.System, "# " + "UNLEFT : " + EnterCount.ToString());
      Log(LogEvent.System, "# " + "APP    : " + Globals.AssemblyTitle);
      Log(LogEvent.System, "# " + "STOP   : " + DateTime.Now.ToString());
      Log(LogEvent.System, Separator);
      Log(LogEvent.System);
    }

    public static void ClearLogs()
    {
      if ( !_Enabled ) return;
      try
      {
        string path = TraceListener.FilePath;
        string code = TraceListener.FileCode;
        string extension = TraceListener.FileExtension;
        Stop();
        foreach ( string filename in Directory.GetFiles(path, code + "*" + extension) )
        {
          string date = Path.GetFileNameWithoutExtension(filename).Replace(code, "").Trim();
          SystemHelper.TryCatch(() => File.Delete(filename));
        }
        LogForm.TextBox.Clear();
      }
      finally
      {
        Start();
      }
    }

  }

}
