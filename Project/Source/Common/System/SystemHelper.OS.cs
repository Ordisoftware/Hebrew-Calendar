/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Management;
using Microsoft.Win32;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide system helper.
  /// </summary>
  static partial class SystemHelper
  {

    private const string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";

    /// <summary>
    /// Indicate the processor name.
    /// </summary>
    static public string Processor
    {
      get
      {
        if ( string.IsNullOrEmpty(_Processor) )
          try
          {
            var list = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor").Get();
            foreach ( var item in list )
            {
              _Processor = (string)item["Name"];
              break;
            }
          }
          catch
          {
            _Processor = Localizer.UndefinedSlot.GetLang();
          }
        return _Processor;
      }
    }
    static private string _Processor;

    /// <summary>
    /// Indicate the operating system, framework and CLR names and versions.
    /// </summary>
    static public string Platform
    {
      get
      {
        if ( string.IsNullOrEmpty(_Platform) )
        {
          string osName = get(() => Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString());
          string osRelease = get(() => Registry.GetValue(HKLMWinNTCurrent, "ReleaseId", "").ToString());
          if ( !string.IsNullOrEmpty(osRelease) ) osRelease = $" ({ osRelease})";
          string osVersion = Environment.OSVersion.Version.ToString();
          string osType = Environment.Is64BitOperatingSystem ? "64-bits" : "32-bits";
          string clr = Environment.Version.ToString();
          string dotnet = get(() =>
          {
            var attributes = Assembly.GetExecutingAssembly().CustomAttributes;
            var result = attributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            return result == null
                   ? ".NET Framework " + Localizer.UndefinedSlot.GetLang()
                   : result.NamedArguments[0].TypedValue.Value.ToString();
          });
          _Platform = $"{osName} {osType} {osVersion}{osRelease}{Globals.NL}{dotnet}{Globals.NL}CLR {clr}";
        }
        return _Platform;
        string get(Func<string> func)
        {
          try { return func(); }
          catch { return Localizer.UndefinedSlot.GetLang(); }
        }
      }
    }
    static private string _Platform;

    /// <summary>
    /// Indicate the free physical memory formatted.
    /// </summary>
    static public string PhysicalMemoryFree
    {
      get
      {
        object value = GetWin32OperatingSystemValue("FreePhysicalMemory");
        return value != null ? ( (ulong)value * 1024 ).FormatBytesSize() : Localizer.UndefinedSlot.GetLang();
      }
    }

    /// <summary>
    /// Indicate the total physical memory formatted.
    /// </summary>
    static public string TotalVisibleMemory
    {
      get
      {
        if ( string.IsNullOrEmpty(_TotalVisibleMemory) )
        {
          object value = GetWin32OperatingSystemValue("TotalVisibleMemorySize");
          _TotalVisibleMemory = value != null
                              ? ( (ulong)value * 1024 ).FormatBytesSize()
                              : Localizer.UndefinedSlot.GetLang();
        }
        return _TotalVisibleMemory;
      }
    }
    static private string _TotalVisibleMemory;


    /// <summary>
    /// Get a Windows Management Object value.
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
