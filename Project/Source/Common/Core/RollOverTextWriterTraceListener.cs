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

  public enum TraceRollOverMode
  {
    Daily,
    Monthly
  }

  public delegate void RollOverTextWriterTraceListenerChangingFile(RollOverTextWriterTraceListener sender, string filename);

  // Adapted from:
  // https://web.archive.org/web/20040628122447/http://weblogs.asp.net/DaveBost/archive/2004/04/30/124224.aspx
  public class RollOverTextWriterTraceListener : TraceListener
  {

    public bool AutoFlush
    {
      get => Writer.AutoFlush;
      set => Writer.AutoFlush = value;
    }

    public string FilePath { get; }
    public string FileCode { get; }
    public string FileExtension { get; }

    public TraceRollOverMode Mode { get; private set; }
    public DateTime Date { get; private set; }
    public string Filename { get; private set; }

    public int KeepCount { get; set; }

    private StreamWriter Writer;

    public event RollOverTextWriterTraceListenerChangingFile ChangingFile;

    public RollOverTextWriterTraceListener(string filePath,
                                           string fileCode,
                                           string fileExtension,
                                           TraceRollOverMode mode,
                                           int keepCount,
                                           RollOverTextWriterTraceListenerChangingFile changingFile = null)
    {
      Directory.CreateDirectory(filePath);
      ChangingFile = changingFile;
      KeepCount = keepCount;
      Mode = mode;
      FileExtension = fileExtension;
      FileCode = fileCode;
      FilePath = filePath;
      Writer = new StreamWriter(GenerateFilename(), true);
    }

    protected override void Dispose(bool disposing)
    {
      if ( disposing ) Writer.Close();
    }

    public override void Write(string value)
    {
      CheckRollover();
      Writer.Write(value);
    }

    public override void WriteLine(string value)
    {
      CheckRollover();
      Writer.WriteLine(value);
    }

    private void CheckRollover()
    {
      if ( Date.Date == DateTime.Today ) return;
      try
      {
        Writer.Close();
        Writer = new StreamWriter(GenerateFilename(), true);
      }
      catch
      {
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
      Filename = Path.Combine(FilePath, $"{FileCode} {SQLiteDate.ToString(Date)}{FileExtension}");
      try { ChangingFile?.Invoke(this, Filename); }
      catch { }
      return Filename;
    }

    private void Purge()
    {
      if ( KeepCount == 0 ) return;
      try
      {
        var list = Directory.GetFiles(FilePath, FileCode + "*" + FileExtension)
                            .Select(filename => new FileItem { Filename = filename })
                            .Where(item => ResolveDate(item));
        bool ResolveDate(FileItem item)
        {
          string dateCode = Path.GetFileNameWithoutExtension(item.Filename).Replace(FileCode, "");
          return SystemHelper.TryCatch(() => { item.Date = SQLiteDate.ToDateTime(dateCode.Trim()); });
        }
        DateTime limit;
        switch ( Mode )
        {
          case TraceRollOverMode.Daily:
            limit = DateTime.Now.Date.AddDays(-KeepCount);
            break;
          case TraceRollOverMode.Monthly:
            limit = DateTime.Now.Date.AddMonths(-KeepCount);
            break;
          default:
            throw new NotImplementedExceptionEx(Mode.ToStringFull());
        }
        foreach ( var file in list.Where(f => f.Date <= limit) )
          SystemHelper.TryCatch(() => File.Delete(file.Filename));
      }
      catch
      {
      }
    }

  }

}
