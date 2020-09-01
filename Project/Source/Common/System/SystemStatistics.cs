/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
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
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// provide system statistics.
  /// </summary>
  public class SystemStatistics
  {

    static public SystemStatistics Instance = new SystemStatistics();

    static private Process Process = Process.GetCurrentProcess();

    static private PerformanceCounter PerformanceCounter;

    public string Processor
      => SystemHelper.Processor;

    public string Platform
      => SystemHelper.Platform;

    public string ProcessPriority
      => Globals.RealProcessPriority.ToString();

    public string ThreadPriority
      => Thread.CurrentThread.Priority.ToString();

    public string RunningTime
      => ( (long)( DateTime.Now - Globals.StartDateTime ).TotalMilliseconds ).FormatMilliseconds(true);

    public string ExecutableMode
      => Globals.IsDebugExecutable ? "Debug" : "Release";

    public string TotalVisibleMemory
      => SystemHelper.TotalVisibleMemory;

    public string PhysicalMemoryFree
      => SystemHelper.PhysicalMemoryFree;

    public string MemoryPrivate
      => Process.PrivateMemorySize64.FormatBytesSize();

    public string MemoryWorking
      => Process.WorkingSet64.FormatBytesSize();

    public string MemoryWorkingPeak
      => Process.PeakWorkingSet64.FormatBytesSize();

    public string MemoryPaged
      => Process.PagedMemorySize64.FormatBytesSize();

    public string MemoryPagedPeak
      => Process.PeakPagedMemorySize64.FormatBytesSize();

    public string MemoryPagedSystem
      => Process.PagedSystemMemorySize64.FormatBytesSize();

    public string MemoryVirtual
      => Process.VirtualMemorySize64.FormatBytesSize();

    public string MemoryVirtualPeak
      => Process.PeakVirtualMemorySize64.FormatBytesSize();

    public string MemoryGCPeak
      => _MemoryGCPeak.FormatBytesSize();

    public string MemoryGC
    {
      get
      {
        long value = GC.GetTotalMemory(true);
        if ( value > _MemoryGCPeak ) _MemoryGCPeak = value;
        return value.FormatBytesSize();
      }
    }
    static private long _MemoryGCPeak;

    public string CPULoad
    {
      get
      {
        if ( PerformanceCounter == null )
        {
          LoadingForm.Instance.Initialize(Localizer.Initializing.GetLang(), 1, 0);
          LoadingForm.Instance.SetProgress(1);
          Application.DoEvents();
          PerformanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
          LoadingForm.Instance.Hide();
        }
        return (int)PerformanceCounter.NextValue() + "%";
      }
    }

  }

}
