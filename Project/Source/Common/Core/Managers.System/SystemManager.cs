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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.IO;
using System.IO.Pipes;
using System.Configuration;
using System.Threading;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system manager.
  /// </summary>
  static public partial class SystemManager
  {

    /// <summary>
    /// Application mutex to allow only one process instance.
    /// </summary>
    static private Mutex ApplicationMutex;

    /// <summary>
    /// IPC server instance.
    /// </summary>
    static private NamedPipeServerStream IPCServer;

    /// <summary>
    /// Create IPC server instance.
    /// </summary>
    static public void CreateIPCServer(AsyncCallback duplicated)
    {
      IPCServer = new NamedPipeServerStream(Globals.AssemblyGUID,
                                            PipeDirection.InOut,
                                            1,
                                            PipeTransmissionMode.Message,
                                            PipeOptions.Asynchronous);
      IPCServer.BeginWaitForConnection(duplicated, IPCServer);
    }

    /// <summary>
    /// Check if the process is already running.
    /// </summary>
    static public bool CheckApplicationOnlyOneInstance(AsyncCallback duplicated)
    {
      try
      {
        ApplicationMutex = new Mutex(true, Globals.AssemblyGUID, out bool created);
        if ( created )
          CreateIPCServer(duplicated);
        else
        {
          var client = new NamedPipeClientStream(".", Globals.AssemblyGUID, PipeDirection.InOut);
          client.Connect();
          new BinaryFormatter().Serialize(client, "BringToFront");
          client.Close();
        }
        return created;
      }
      catch ( Exception ex )
      {
        ex.Manage();
        return false;
      }
    }

    /// <summary>
    /// Check is application's settings must be upgraded and apply it if necessary.
    /// </summary>
    static public void CheckUpgradeRequired(this ApplicationSettingsBase settings, ref bool upgradeRequired)
    {
      try
      {
        if ( upgradeRequired )
        {
          settings.Upgrade();
          upgradeRequired = false;
          settings.Save();
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Exit the application process.
    /// </summary>
    static public void Exit()
    {
      TryCatch(() => DebugManager.Stop());
      Application.Exit();
    }

    /// <summary>
    /// Hard terminate the application process.
    /// </summary>
    static public void Terminate()
    {
      TryCatch(() => DebugManager.Stop());
      Environment.Exit(-1);
    }

    /// <summary>
    /// Call an action without raising exceptions.
    /// </summary>
    static public bool TryCatch(Action action)
    {
      try
      {
        action();
        return true;
      }
      catch (Exception ex)
      {
        ex.Manage(ShowExceptionMode.None);
        return false;
      }
    }

    /// <summary>
    /// Call an action without raising exceptions.
    /// </summary>
    static public bool TryCatchManage(Action action)
    {
      try
      {
        action();
        return true;
      }
      catch ( Exception ex )
      {
        ex.Manage();
        return false;
      }
    }

    /// <summary>
    /// Call an action without raising exceptions.
    /// </summary>
    static public bool TryCatchManage(ShowExceptionMode mode, Action action)
    {
      try
      {
        action();
        return true;
      }
      catch ( Exception ex )
      {
        ex.Manage(mode);
        return false;
      }
    }

    /// <summary>
    /// Get the memory size of a serializable object.
    /// </summary>
    static public long SizeOf(this object instance)
    {
      long result = -1;
      if ( instance == null ) return 0;
      if ( instance.GetType().IsSerializable )
        using ( var stream = new MemoryStream() )
          TryCatch(() => { new BinaryFormatter().Serialize(stream, instance); result = stream.Length; });
      return result;
    }

    /// <summary>
    /// Get a file size.
    /// </summary>
    static public long GetFileSize(string filePath)
    {
      long result = -1;
      TryCatch(() => { if ( File.Exists(filePath) ) result = new FileInfo(filePath).Length; });
      return result;
    }

    private const string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";

    /// <summary>
    /// Indicate the processor name.
    /// </summary>
    static public string Processor
    {
      get
      {
        if ( _Processor.IsNullOrEmpty() )
          try
          {
            var list = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor").Get();
            var enumerator = list.GetEnumerator();
            bool newline = false;
            if ( enumerator.MoveNext() )
              do
              {
                _Processor = (string)enumerator.Current["Name"];
                newline = enumerator.MoveNext();
                if ( newline ) _Processor += Globals.NL;
              }
              while ( newline );
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
        if ( _Platform.IsNullOrEmpty() )
        {
          string osName = get(() => Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString());
          string osRelease = get(() => Registry.GetValue(HKLMWinNTCurrent, "ReleaseId", "").ToString());
          if ( !osRelease.IsNullOrEmpty() ) osRelease = $" ({ osRelease})";
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
        if ( _TotalVisibleMemory.IsNullOrEmpty() )
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
