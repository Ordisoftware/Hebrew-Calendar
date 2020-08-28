/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
using System.Management;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public class SystemStatistics
  {
    public string RunningTime => FormatSeconds((long)DateTime.Now.Subtract(Program.Settings.BenchmarkStartDateTime).TotalMilliseconds);
    public string StartingTime => FormatMilliseconds(Program.Settings.BenchmarkStartingApp);
    public string LoadDataTime => FormatMilliseconds(Program.Settings.BenchmarkLoadData);
    public string GenerateYearsTime => FormatMilliseconds(Program.Settings.BenchmarkGenerateYears);
    public string FillMonthViewTime => FormatMilliseconds(Program.Settings.BenchmarkFillCalendar);
    public string DBFileSize => "668 KB";
    public string DBFirstYear => MainForm.Instance.YearFirst.ToString();
    public string DBLastYear => MainForm.Instance.YearLast.ToString();
    public string DBYearsInterval => (MainForm.Instance.YearLast - MainForm.Instance.YearFirst + 1).ToString();
    public string DBRecordsCount => MainForm.Instance.DataSet.LunisolarDays.Count().ToString();
    public string DBEventsCount => MainForm.Instance.DataSet.LunisolarDays.Count(d => d.TorahEvents != 0 || d.SeasonChange != 0).ToString();
    public string MonthViewEventsCount => MainForm.Instance.CalendarMonth.Events.Count.ToString();

    public string DBMemorySize
    {
      get
      {
        if ( !Globals.IsDesignTime )
          try
          {
            return ( (ulong)SizeOf(MainForm.Instance.DataSet) ).FormatBytesSize();
          }
          catch
          {
          }
        return Localizer.EmptySlot.GetLang();
      }
    }

    public string TotalVisibleMemory
    {
      get
      {
        if ( !Globals.IsDesignTime )
          try
          {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            if ( results.Count > 0 )
            {
              var enumerator = results.GetEnumerator();
              if ( enumerator.MoveNext() )
              {
                var instance = enumerator.Current;
                return ( (ulong)instance["TotalVisibleMemorySize"] * 1024 ).FormatBytesSize();
              }
            }
          }
          catch
          {
          }
        return Localizer.EmptySlot.GetLang();
      }
    }

    public string PhysicalMemoryFree
    {
      get
      {
        if ( !Globals.IsDesignTime )
          try
          {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            if ( results.Count > 0 )
            {
              var enumerator = results.GetEnumerator();
              if ( enumerator.MoveNext() )
              {
                var instance = enumerator.Current;
                return ( (ulong)instance["FreePhysicalMemory"] * 1024 ).FormatBytesSize();
              }
            }
          }
          catch
          {
          }
        return Localizer.EmptySlot.GetLang();
      }
    }

    public string OperatingSystem
    {
      get
      {
        if ( !Globals.IsDesignTime )
          if ( _OperatingSystem == "" )
            try
            {
              var key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
              _OperatingSystem = (string)key.GetValue("productName")
                               + " " + ( Environment.Is64BitOperatingSystem ? "64-bits" : "32-bits" );
            }
            catch
            {
              _OperatingSystem = Localizer.EmptySlot.GetLang();
            }
        return _OperatingSystem;
      }
    }
    public string _OperatingSystem = "";

    private string FormatMilliseconds(long ms)
    {
      TimeSpan time = TimeSpan.FromMilliseconds(ms);
      return string.Format("{0:D2} d {1:D2} h {2:D2} m {3:D2} s {4:D3} ms",
                           time.Days,
                           time.Hours,
                           time.Minutes,
                           time.Seconds,
                           time.Milliseconds)
                   .Replace("00 d 00 h 00 m 00 s", "")
                   .Replace("00 d 00 h 00 m", "")
                   .Replace("00 d 00 h", "")
                   .Replace("00 d ", "");
    }
    private string FormatSeconds(long ms)
    {
      TimeSpan time = TimeSpan.FromMilliseconds(ms);
      return string.Format("{0:D2} d {1:D2} h {2:D2} m {3:D2} s",
                           time.Days,
                           time.Hours,
                           time.Minutes,
                           time.Seconds)
                   .Replace("00 d 00 h 00 m", "")
                   .Replace("00 d 00 h", "")
                   .Replace("00 d ", "");
    }

    public long SizeOf(object obj)
    {
      if ( obj == null ) return 0;
      try
      {
        using ( MemoryStream stream = new MemoryStream() )
        {
          new BinaryFormatter().Serialize(stream, obj);
          return stream.Length;
        }
      }
      catch { return -1; }
    }

  }

}
