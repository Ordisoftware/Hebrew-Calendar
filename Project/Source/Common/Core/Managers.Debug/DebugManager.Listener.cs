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
/// <created> 2020-08 </created>
/// <edited> 2020-10 </edited>
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Ordisoftware.Core
{

  static partial class DebugManager
  {

    internal partial class Listener : TraceListener
    {

      public event TraceFileChanged Changed;

      public bool AutoFlush
      {
        get => Writer.AutoFlush;
        set => Writer.AutoFlush = value;
      }

      public TraceFileRollOverMode Mode { get; set; }
      public int KeepCount { get; set; }

      public string Folder { get; }
      public string Code { get; }
      public string Extension { get; }

      public DateTime Date { get; private set; }
      public string FilePath { get; private set; }

      private StreamWriter Writer;

      public Listener(string fileFolder,
                      string fileCode,
                      string fileExtension,
                      TraceFileRollOverMode mode,
                      int keepCount,
                      TraceFileChanged fileChanged = null)
      {
        Directory.CreateDirectory(fileFolder);
        Folder = fileFolder;
        Code = fileCode;
        Extension = fileExtension;
        Changed = fileChanged;
        Mode = mode;
        KeepCount = keepCount;
        Writer = new StreamWriter(GenerateFilePath(), true);
      }

      protected override void Dispose(bool disposing)
      {
        if ( disposing ) Writer.Close();
      }

      public override void Write(string value)
      {
        CheckRollOver();
        Writer.Write(value);
      }

      public override void WriteLine(string value)
      {
        CheckRollOver();
        Writer.WriteLine(value);
      }

      private bool TraceMutex;
      public bool IsRollOver { get; private set; }

      private void CheckRollOver()
      {
        if ( TraceMutex ) return;
        if ( Date.Date == DateTime.Today ) return;
        TraceMutex = true;
        try
        {
          IsRollOver = true;
          try
          {
            Trace(LogTraceEvent.Data, $"{nameof(DebugManager)}.{nameof(TraceListener)}.{nameof(CheckRollOver)} = TRUE");
            WriteFooter();
            Writer.Close();
            Writer = null;
            Writer = new StreamWriter(GenerateFilePath(), true);
            WriteHeader();
            Trace(LogTraceEvent.Data, $"{nameof(DebugManager)}.{nameof(TraceListener)}.{nameof(CheckRollOver)} = TRUE");
          }
          catch
          {
          }
        }
        finally
        {
          IsRollOver = false;
          TraceMutex = false;
        }
      }

      private class FileItem
      {
        public string FilePath;
        public DateTime Date;
      }

      private string GenerateFilePath()
      {
        Purge();
        Date = DateTime.Today;
        string ProcessName = SystemManager.AllowMultipleInstances ? $" ({Globals.ProcessId})" : string.Empty;
        FilePath = Path.Combine(Folder, $"{Code} {SQLiteDate.ToString(Date)}{ProcessName}{Extension}");
        SystemManager.TryCatchManage(() => { Changed?.Invoke(this, FilePath); });
        return FilePath;
      }

      private void Purge()
      {
        if ( KeepCount == 0 ) return;
        try
        {
          bool ResolveDate(FileItem item)
          {
            string dateCode = Path.GetFileNameWithoutExtension(item.FilePath).Replace(Code, string.Empty);
            dateCode = dateCode.SplitNoEmptyLines(" (")[0];
            try
            {
              item.Date = SQLiteDate.ToDateTime(dateCode.Trim());
              return true;
            }
            catch
            {
              return false;
            }
          }
          var list = Directory.GetFiles(Folder, Code + "*" + Extension)
                              .Select(path => new FileItem { FilePath = path })
                              .Where(item => ResolveDate(item));
          DateTime limit;
          switch ( Mode )
          {
            case TraceFileRollOverMode.Daily:
              limit = DateTime.Now.Date.AddDays(-KeepCount);
              break;
            case TraceFileRollOverMode.Monthly:
              limit = DateTime.Now.Date.AddMonths(-KeepCount);
              break;
            default:
              throw new NotImplementedExceptionEx(Mode);
          }
          foreach ( var file in list.Where(f => f.Date <= limit) )
            try
            {
              File.Delete(file.FilePath);
            }
            catch
            {
            }
        }
        catch
        {
        }
      }

    }

  }

}
