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

    static public string PhysicalMemoryFree
    {
      get
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

    static public string TotalVisibleMemory
    {
      get
      {
        if ( _TotalVisibleMemory == "" )
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
                _TotalVisibleMemory = ( (ulong)instance["TotalVisibleMemorySize"] * 1024 ).FormatBytesSize();
              }
            }
          }
          catch
          {
            _TotalVisibleMemory = Localizer.EmptySlot.GetLang();
          }
        return _TotalVisibleMemory;
      }
    }
    static private string _TotalVisibleMemory = "";

    static public string OperatingSystem
    {
      get
      {
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
    static private string _OperatingSystem = "";

    static public string DatabaseFileSize
    {
      get
      {
        try
        {
          string filename = Globals.AssemblyTitle.Replace(" ", "-") + Globals.DBFileExtension;
          filename = Globals.UserDataFolderPath + filename;
          if ( File.Exists(filename) )
            return ( (ulong)new FileInfo(filename).Length ).FormatBytesSize();
        }
        catch
        {
        }
        return Localizer.EmptySlot.GetLang();
      }
    }

  }

}
