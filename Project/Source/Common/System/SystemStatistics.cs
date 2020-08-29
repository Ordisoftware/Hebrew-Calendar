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

  public class SystemStatistics
  {

    static public SystemStatistics Instance = new SystemStatistics();

    static private PerformanceCounter PerformanceCounter;
    static private Process Process = Process.GetCurrentProcess();

    public string ProcessorName => SystemHelper.ProcessorName;
    public string OperatingSystem => SystemHelper.OperatingSystem;
    public string ProcessPriority => Process.PriorityClass.ToString();
    public string CurrentThreadPriority => Thread.CurrentThread.Priority.ToString();
    public string RunningTime => ( (long)DateTime.Now.Subtract(Globals.StartDateTime).TotalMilliseconds ).FormatMilliseconds(true);

    public string TotalVisibleMemory => SystemHelper.TotalVisibleMemory;
    public string PhysicalMemoryFree => SystemHelper.PhysicalMemoryFree;
    public string MemoryGC => GC.GetTotalMemory(true).FormatBytesSize();
    public string MemoryPrivate => Process.PrivateMemorySize64.FormatBytesSize();
    public string MemoryWorking => Process.WorkingSet64.FormatBytesSize();
    public string MemoryWorkingPeak => Process.PeakWorkingSet64.FormatBytesSize();
    public string MemoryPaged => Process.PagedMemorySize64.FormatBytesSize();
    public string MemoryPagedPeak => Process.PeakPagedMemorySize64.FormatBytesSize();
    public string MemoryPagedSystem => Process.PagedSystemMemorySize64.FormatBytesSize();
    public string MemoryVirtual => Process.VirtualMemorySize64.FormatBytesSize();
    public string MemoryVirtualPeak => Process.PeakVirtualMemorySize64.FormatBytesSize();

    public string CPULoad
    {
      get
      {
        if ( PerformanceCounter == null )
        {
          LoadingForm.Instance.Initialize(Localizer.Initialization.GetLang(), 1, 0);
          LoadingForm.Instance.DoProgress(1);
          Application.DoEvents();
          PerformanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
          LoadingForm.Instance.Hide();
        }
        return (int)PerformanceCounter.NextValue() + "%";
      }
    }

  }

}
