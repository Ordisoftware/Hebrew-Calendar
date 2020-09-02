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
using System.Diagnostics;

namespace Ordisoftware.HebrewCommon
{

  public delegate void RollOverTextWriterTraceListenerChangingFile(RollOverTextWriterTraceListener sender, string filename);

  // Adapted from:
  // https://web.archive.org/web/20040628122447/http://weblogs.asp.net/DaveBost/archive/2004/04/30/124224.aspx
  public class RollOverTextWriterTraceListener : TraceListener
  {
    private int KeepCount;
    private DateTime Date;
    private StreamWriter Writer;

    private string FilePath;
    private string FileCode;
    private string FileExtension;
    private string DateFormat;

    public string Filename { get; private set; }

    public bool AutoFlush
    {
      get => Writer.AutoFlush;
      set => Writer.AutoFlush = value;
    }

    public event RollOverTextWriterTraceListenerChangingFile ChangingFile;

    public RollOverTextWriterTraceListener(string filePath,
                                           string fileCode,
                                           string fileExtension,
                                           string dateFormat,
                                           RollOverTextWriterTraceListenerChangingFile changingFile = null,
                                           int keepCount = 7)
    {
      Directory.CreateDirectory(filePath);
      ChangingFile = changingFile;
      KeepCount = keepCount;
      DateFormat = dateFormat;
      FileExtension = fileExtension;
      FileCode = fileCode;
      FilePath = filePath;
      Writer = new StreamWriter(GenerateFilename(), true);
    }

    protected override void Dispose(bool disposing)
    {
      if ( disposing )
      {
        Writer.Close();
      }
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

    private string GenerateFilename()
    {
      if ( KeepCount != 0 )
        try
        {
          var limit = DateTime.Now.Date.AddDays(-KeepCount);
          foreach ( string filename in Directory.GetFiles(FilePath, FileCode + "*" + FileExtension) )
          {
            string date = Path.GetFileNameWithoutExtension(filename).Replace(FileCode, "").Trim();
            if ( DateTime.TryParse(date, out DateTime thedate) )
              if ( thedate <= limit )
                try { File.Delete(filename); }
                catch { }
          }
        }
        catch
        {
        }
      Date = DateTime.Today;
      Filename = Path.Combine(FilePath, $"{FileCode} {Date.ToString(DateFormat)}{FileExtension}");
      try { ChangingFile?.Invoke(this, Filename); }
      catch { }
      return Filename;
    }

  }

}
