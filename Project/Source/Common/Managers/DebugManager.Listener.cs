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
/// <created> 2020-08 </created>
/// <edited> 2020-08 </edited>
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Ordisoftware.HebrewCommon
{

  static public partial class DebugManager
  {

    public class Listener : TraceListener
    {

      public event TraceFileChanged Changed;

      public bool AutoFlush
      {
        get => Writer.AutoFlush;
        set => Writer.AutoFlush = value;
      }

      public TraceFileRollOverMode Mode { get; set; }
      public int KeepCount { get; set; }

      public string Path { get; }
      public string Code { get; }
      public string Extension { get; }

      public DateTime Date { get; private set; }
      public string Filename { get; private set; }

      private StreamWriter Writer;

      public Listener(string filePath,
                      string fileCode,
                      string fileExtension,
                      TraceFileRollOverMode mode,
                      int keepCount,
                      TraceFileChanged fileChanged = null)
      {
        Directory.CreateDirectory(filePath);
        Path = filePath;
        Code = fileCode;
        Extension = fileExtension;
        Changed = fileChanged;
        Mode = mode;
        KeepCount = keepCount;
        Writer = new StreamWriter(GenerateFilename(), true);
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

      private void CheckRollOver()
      {
        if ( TraceMutex ) return;
        if ( Date.Date == DateTime.Today ) return;
        TraceMutex = true;
        try
        {
          SystemManager.TryCatch(() =>
          {
            Trace(HebrewCommon.TraceEvent.Data, $"{nameof(DebugManager)}.{nameof(TraceListener)}.{nameof(CheckRollOver)} = TRUE");
            WriteFooter();
            Writer.Close();
            Writer = null;
            Writer = new StreamWriter(GenerateFilename(), true);
            WriteHeader();
            Trace(HebrewCommon.TraceEvent.Data, $"{nameof(DebugManager)}.{nameof(TraceListener)}.{nameof(CheckRollOver)} = TRUE");
          });
        }
        finally
        {
          TraceMutex = false;
        }
      }

      private class FileItem
      {
        public string Filename;
        public DateTime Date;
      }

      private string GenerateFilename()
      {
        Purge();
        Date = DateTime.Today;
        Filename = System.IO.Path.Combine(Path, $"{Code} {SQLiteDate.ToString(Date)}{Extension}");
        SystemManager.TryCatch(() => { Changed?.Invoke(this, Filename); });
        return Filename;
      }

      private void Purge()
      {
        if ( KeepCount == 0 ) return;
        SystemManager.TryCatch(() =>
        {
          bool ResolveDate(FileItem item)
          {
            string dateCode = System.IO.Path.GetFileNameWithoutExtension(item.Filename).Replace(Code, "");
            return SystemManager.TryCatch(() => { item.Date = SQLiteDate.ToDateTime(dateCode.Trim()); });
          }
          var list = Directory.GetFiles(Path, Code + "*" + Extension)
                              .Select(filename => new FileItem { Filename = filename })
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
              throw new NotImplementedExceptionEx(Mode.ToStringFull());
          }
          foreach ( var file in list.Where(f => f.Date <= limit) )
            SystemManager.TryCatch(() => File.Delete(file.Filename));
        });
      }

    }

  }

}
