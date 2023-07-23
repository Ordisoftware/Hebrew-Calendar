/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides system statistics.
/// </summary>
public class SystemStatistics
{

  public const int TimerIntervalActive = 1000;
  public const int TimerIntervalIdle = 5000;

  static private readonly Process Process = Process.GetCurrentProcess();
  static private PerformanceCounter PerformanceCounterCPULoad;
  static private PerformanceCounter PerformanceCounterCPUProcessLoad;

  static public ProcessPriorityClass RealProcessPriority
  {
    get
    {
      var list = Process.GetProcessesByName(Globals.ProcessName);
      return list.Length >= 1 ? list[0].PriorityClass : ProcessPriorityClass.Normal;
    }
  }

  static public readonly SystemStatistics Instance = new();

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

  public string CompiledDate
    => Globals.CompiledDateTime.ToString("g");

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

  static private bool CPUProcessLoadInitMutex;

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP007:Don't dispose injected", Justification = "N/A")]
  public string CPUProcessLoad
  {
    get
    {
      if ( PerformanceCounterCPUProcessLoad is null )
      {
        CPUProcessLoadInitMutex = true;
        new Task(process).Start();
        //
        void process()
        {
          var process = Process.GetCurrentProcess();
          var name = string.Empty;
          foreach ( var instance in from instance in new PerformanceCounterCategory("Process").GetInstanceNames()
                                    where instance.StartsWith(process.ProcessName, StringComparison.CurrentCultureIgnoreCase)
                                    select instance )
          {
            using var processId = new PerformanceCounter("Process", "ID Process", instance, true);
            if ( process.Id == (int)processId.RawValue )
            {
              name = instance;
              break;
            }
          }
          PerformanceCounterCPUProcessLoad = new PerformanceCounter("Process", "% Processor Time", name, true);
          CPUProcessLoadInitMutex = false;
        }
      }
      if ( CPUProcessLoadInitMutex ) return "(init)";
      int value = 0;
      try
      {
        do
          value = (int)PerformanceCounterCPUProcessLoad.NextValue();
        while ( value > 100 );
      }
      catch
      {
        PerformanceCounterCPUProcessLoad?.Dispose();
        PerformanceCounterCPUProcessLoad = null;
      }
      if ( value > _CpuProcessLoadMax && value <= 100 ) _CpuProcessLoadMax = value;
      _CpuProcessLoadCount++;
      _CpuProcessLoadAverage += (ulong)value;
      return $"{value}%";
    }
  }
  static private int _CpuProcessLoadMax;
  static private ulong _CpuProcessLoadCount;
  static private ulong _CpuProcessLoadAverage;

  public string CPUProcessLoadAverage
    => _CpuProcessLoadCount == 0 ? "-" : $"{_CpuProcessLoadAverage / _CpuProcessLoadCount}%";

  public string CPUProcessLoadMax
    => $"{_CpuProcessLoadMax}%";

  static private bool CPULoadInitMutex;

  public string CPULoad
  {
    get
    {
      if ( PerformanceCounterCPULoad is null )
      {
        CPULoadInitMutex = true;
        new Task(() =>
        {
          PerformanceCounterCPULoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
          CPULoadInitMutex = false;
        }).Start();
      }
      if ( CPULoadInitMutex ) return "(init)";
      return $"{(int)PerformanceCounterCPULoad.NextValue()}%";
    }
  }

}
