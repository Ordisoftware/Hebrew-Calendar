/// <license>
/// This file is part of Ordisoftware Core Library.
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
/// <edited> 2020-09 </edited>
using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system statistics.
  /// </summary>
  public class SystemStatistics
  {

    static private PerformanceCounter PerformanceCounterCPULoad;
    static private PerformanceCounter PerformanceCounterCPUProcessLoad;

    static public ProcessPriorityClass RealProcessPriority
    {
      get
      {
        var list = Process.GetProcessesByName(Globals.ProcessName);
        return list.Length == 1 ? list[0].PriorityClass : 0;
      }
    }

    static private Process Process
      = Process.GetCurrentProcess();

    static public SystemStatistics Instance
      = new SystemStatistics();

    public string Processor
      => SystemManager.Processor;

    public string Platform
      => SystemManager.Platform;

    public string ProcessPriority
      => RealProcessPriority.ToString();

    public string ThreadPriority
      => Thread.CurrentThread.Priority.ToString();

    public string RunningTime
      => ( (long)( DateTime.Now - Globals.StartDateTime ).TotalMilliseconds ).FormatMilliseconds(true);

    public string ProcessorTime
      => ( (long)Process.TotalProcessorTime.TotalMilliseconds ).FormatMilliseconds(true);

    public string ExecutableMode
      => Globals.IsDebugExecutable ? "Debug" : "Release";

    public string TotalVisibleMemory
      => SystemManager.TotalVisibleMemory;

    public string PhysicalMemoryFree
      => SystemManager.PhysicalMemoryFree;

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

    public string CPUProcessLoadMax
      => _CPUProcessLoadMax + "%";

    public string CPUProcessLoad
    {
      get
      {
        if ( PerformanceCounterCPUProcessLoad == null )
        {
          LoadingForm.Instance.Initialize(SysTranslations.Initializing.GetLang(), 1, 0);
          LoadingForm.Instance.SetProgress(1);
          Application.DoEvents();
          PerformanceCounterCPUProcessLoad = new PerformanceCounter("Process", "% Processor Time", Globals.ApplicationExeFileName);
          LoadingForm.Instance.Hide();
        }
        int value = (int)PerformanceCounterCPUProcessLoad.NextValue();
        if ( value > _CPUProcessLoadMax ) _CPUProcessLoadMax = value;
        return value + "%";
      }
    }
    private int _CPUProcessLoadMax;

    public string CPULoad
    {
      get
      {
        if ( PerformanceCounterCPULoad == null )
        {
          LoadingForm.Instance.Initialize(SysTranslations.Initializing.GetLang(), 1, 0);
          LoadingForm.Instance.SetProgress(1);
          Application.DoEvents();
          PerformanceCounterCPULoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
          LoadingForm.Instance.Hide();
        }
        return (int)PerformanceCounterCPULoad.NextValue() + "%";
      }
    }

  }

}
