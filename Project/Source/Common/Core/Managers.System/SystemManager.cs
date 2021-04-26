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
/// <edited> 2021-04 </edited>
using System;
using System.Linq;
using System.IO;
using System.IO.Pipes;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system manager.
  /// </summary>
  static partial class SystemManager
  {

    public const string RegistryKeyRun = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

    /// <summary>
    /// Application mutex to allow only one process instance.
    /// </summary>
#pragma warning disable S4487 // Unread "private" fields should be removed
    static private Mutex ApplicationMutex;
#pragma warning restore S4487 // Unread "private" fields should be removed

    /// <summary>
    /// IPC server instance.
    /// </summary>
    static private NamedPipeServerStream IPCServer;

    /// <summary>
    /// IPC answers callback.
    /// </summary>
    static public Action IPCSendCommands { get; set; }

    /// <summary>
    /// Indicate if the several instances of the application can run at same time.
    /// </summary>
    static public bool AllowMultipleInstances { get; private set; } = true;

    /// <summary>
    /// Indicate the number of application running processes count.
    /// </summary>
    static public int ApplicationInstancesCount
      => Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length;

    /// <summary>
    /// Create IPC server instance.
    /// </summary>
    static public void CreateIPCServer(AsyncCallback ipcRequests)
    {
      try
      {
        IPCServer = new NamedPipeServerStream(Globals.AssemblyGUID,
                                              PipeDirection.InOut,
                                              1,
                                              PipeTransmissionMode.Message,
                                              PipeOptions.Asynchronous);
        IPCServer.BeginWaitForConnection(ipcRequests, IPCServer);
      }
      catch ( Exception ex )
      {
        IPCServer = null;
        ex.Manage();
      }
    }

    /// <summary>
    /// Check if the process is already running.
    /// </summary>
    static public bool CheckApplicationOnlyOneInstance(AsyncCallback ipcRequests)
    {
      try
      {
        AllowMultipleInstances = false;
        ApplicationMutex = new Mutex(true, Globals.AssemblyGUID, out bool created);
        if ( created )
          CreateIPCServer(ipcRequests);
        else
        {
          if ( CommandLineArguments.Length == 0 )
            CommandLineOptions.ShowMainForm = true;
          try
          {
            IPCSendCommands?.Invoke();
          }
          catch ( Exception ex )
          {
            ex.Manage();
          }
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
    /// Send an IPC command.
    /// </summary>
    static public void IPCSend(string command)
    {
      try
      {
        using ( var client = new NamedPipeClientStream(".", Globals.AssemblyGUID, PipeDirection.InOut) )
        {
          client.Connect();
          new BinaryFormatter().Serialize(client, command);
          client.Close();
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Delete all app settings folders in User\AppData\Local.
    /// </summary>
    static public void CleanAllLocalAppSettingsFolders()
    {
      try
      {
        string filter = Globals.ApplicationExeFileName.Substring(0, 25) + "*";
        string filterold = filter.Replace("Hebrew.", "Hebrew");
        var list = Directory.GetDirectories(Globals.UserLocalDataFolderPath, filter)
                   .Concat(Directory.GetDirectories(Globals.UserLocalDataFolderPath, filterold));
        foreach ( var item in list )
          Directory.Delete(item, true);
      }
      catch ( Exception ex )
      {
        ex.Manage();
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
    /// Indicate if the application stars with windows user session or not.
    /// </summary>
    static public bool StartWithWindowsUserRegistry
    {
      get
      {
        var key = Registry.CurrentUser.OpenSubKey(RegistryKeyRun, true);
        return (string)key.GetValue(Globals.ApplicationFullFileName) == Globals.ApplicationStartupRegistryValue;
      }
      set
      {
        var key = Registry.CurrentUser.OpenSubKey(RegistryKeyRun, true);
        if ( value )
          key.SetValue(Globals.ApplicationFullFileName, Globals.ApplicationStartupRegistryValue);
        else
        {
          key.DeleteValue(Globals.ApplicationFullFileName);
        }
      }
    }

    /// <summary>
    /// Exit the application process.
    /// </summary>
    static public void Exit()
    {
      Globals.IsExiting = true;
      TryCatch(() => DebugManager.Stop());
      Application.Exit();
    }

    /// <summary>
    /// Hard terminate the application process.
    /// </summary>
    static public void Terminate()
    {
      Globals.IsExiting = true;
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
      catch ( Exception ex )
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

  }

}
