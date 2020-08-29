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
using System.IO;
using System.Management;
using Microsoft.Win32;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide system helper.
  /// </summary>
  static partial class SystemHelper
  {

    /// <summary>
    /// Get file size formatted.
    /// </summary>
    static public long GetFileSize(string filename)
    {
      try
      {
        if ( File.Exists(filename) )
          return new FileInfo(filename).Length;
      }
      catch
      {
      }
      return -1;
    }

    /// <summary>
    /// Indicate the OS name formatted.
    /// </summary>
    static public string OperatingSystem
    {
      get
      {
        if ( _OperatingSystem == "" )
          try
          {
            string name = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "productName", "").ToString();
            string type = Environment.Is64BitOperatingSystem ? "64-bits" : "32-bits";
            string version = Environment.OSVersion.Version.ToString();
            string release = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            string clr = Environment.Version.ToString();
            _OperatingSystem = $"{name} {type} {version} ({release})" + Environment.NewLine
                             + $"CLR {clr}";
          }
          catch
          {
            _OperatingSystem = Localizer.EmptySlot.GetLang();
          }
        return _OperatingSystem;
      }
    }
    static private string _OperatingSystem = "";

    /// <summary>
    /// Indicate the free physical memory formatted.
    /// </summary>
    static public string PhysicalMemoryFree
    {
      get
      {
        object value = GetWin32OperatingSystemValue("FreePhysicalMemory");
        if ( value == null ) return Localizer.EmptySlot.GetLang();
        return ( (ulong)value * 1024 ).FormatBytesSize();
      }
    }

    /// <summary>
    /// Indicate the total physical memory formatted.
    /// </summary>
    static public string TotalVisibleMemory
    {
      get
      {
        if ( _TotalVisibleMemory == "" )
        {
          object value = GetWin32OperatingSystemValue("TotalVisibleMemorySize");
          _TotalVisibleMemory = value != null
                              ? ( (ulong)value * 1024 ).FormatBytesSize()
                              : Localizer.EmptySlot.GetLang();
        }
        return _TotalVisibleMemory;
      }
    }
    static private string _TotalVisibleMemory = "";


    /// <summary>
    /// Get a Windows Management Object value.
    /// </summary>
    static public object GetWin32OperatingSystemValue(string name)
    {
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
