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
/// <created> 2016-04 </created>
/// <edited> 2021-11 </edited>
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Management;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provides system manager.
  /// </summary>
  static partial class SystemManager
  {

    private const string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";

    /// <summary>
    /// Indicates the processor name.
    /// </summary>
    static public string Processor
    {
      get
      {
        if ( _Processor.IsNullOrEmpty() )
          try
          {
            var procs = new List<string>();
            var list = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_Processor").Get();
            var enumerator = list.GetEnumerator();
            bool newline = false;
            int index = 0;
            if ( enumerator.MoveNext() )
              do
              {
                string name = (string)enumerator.Current["Name"];
                newline = enumerator.MoveNext();
                if ( newline )
                  procs.Add($"P{++index}: " + name.Trim());
                else
                  procs.Add(name.Trim());
              }
              while ( newline );
            _Processor = string.Join(" | ", procs);
          }
          catch
          {
            _Processor = SysTranslations.UndefinedSlot.GetLang();
          }
        return _Processor;
      }
    }
    static private string _Processor;

    /// <summary>
    /// Indicates the operating system, framework and CLR names and versions.
    /// </summary>
    static public string Platform
    {
      get
      {
        if ( _Platform.IsNullOrEmpty() )
        {
          string osName = get(() => Registry.GetValue(HKLMWinNTCurrent, "ProductName", string.Empty).ToString());
          //
          string osDisplayVersion = get(() => Registry.GetValue(HKLMWinNTCurrent, "DisplayVersion", string.Empty).ToString());
          if ( osDisplayVersion.IsNullOrEmpty() )
            osDisplayVersion = get(() => Registry.GetValue(HKLMWinNTCurrent, "ReleaseId", string.Empty).ToString());
          if ( !osDisplayVersion.IsNullOrEmpty() )
            osDisplayVersion = $" {osDisplayVersion}";
          //
          string osSP = get(() => Registry.GetValue(HKLMWinNTCurrent, "CSDVersion", string.Empty).ToString());
          if ( !osSP.IsNullOrEmpty() )
            osDisplayVersion += $" {osSP.Replace("Service Pack ", "SP")}";
          //
          string osVersion = get(() => Registry.GetValue(HKLMWinNTCurrent, "CurrentVersion", string.Empty).ToString());
          if ( osVersion.IsNullOrEmpty() )
            osVersion = Environment.OSVersion.Version.ToString();
          else
          if ( !osVersion.IsNullOrEmpty() )
          {
            string osBuild = get(() => Registry.GetValue(HKLMWinNTCurrent, "CurrentBuild", string.Empty).ToString());
            if ( !osBuild.IsNullOrEmpty() )
              osVersion += $".{osBuild}";
          }
          if ( !osVersion.IsNullOrEmpty() )
            osVersion = $" v{osVersion}";
          //
          string dotnet = get(() =>
          {
            var attributes = Assembly.GetExecutingAssembly().CustomAttributes;
            var result = attributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            return result == null
                   ? ".NET " + SysTranslations.UndefinedSlot.GetLang()
                   : result.NamedArguments[0].TypedValue.Value.ToString();
          });
          //
          string osType = Environment.Is64BitOperatingSystem ? "64-bits" : "32-bits";
          _Platform = $"{osName}{osDisplayVersion} {osType}{osVersion}" + Globals.NL +
                      $"{dotnet}" + Globals.NL +
                      $"CLR {Environment.Version}";
        }
        return _Platform;
        //
        static string get(Func<string> func)
        {
          try { return func().Trim(); }
          catch { return string.Empty; }
        }
      }
    }
    static private string _Platform;

    /// <summary>
    /// Indicates the free physical memory formatted.
    /// </summary>
    static public string PhysicalMemoryFree
    {
      get
      {
        object value = GetWin32OperatingSystemValue("FreePhysicalMemory");
        return value != null ? ( (ulong)value * 1024 ).FormatBytesSize() : SysTranslations.UndefinedSlot.GetLang();
      }
    }

    /// <summary>
    /// Indicates the total physical memory formatted.
    /// </summary>
    static public string TotalVisibleMemory
    {
      get
      {
        if ( _TotalVisibleMemory.IsNullOrEmpty() )
        {
          object value = GetWin32OperatingSystemValue("TotalVisibleMemorySize");
          _TotalVisibleMemory = value != null
                                ? ( (ulong)value * 1024 ).FormatBytesSize()
                                : SysTranslations.UndefinedSlot.GetLang();
        }
        return _TotalVisibleMemory;
      }
    }
    static private string _TotalVisibleMemory;


    /// <summary>
    /// Gets a Windows Management Object value.
    /// </summary>
    static public object GetWin32OperatingSystemValue(string name)
    {
      try
      {
        var wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
        var list = new ManagementObjectSearcher(wql).Get();
        if ( list.Count > 0 )
        {
          var enumerator = list.GetEnumerator();
          if ( enumerator.MoveNext() )
          {
            var instance = enumerator.Current;
            return instance[name];
          }
        }
      }
      catch
      {
      }
      return null;
    }
  }

}
