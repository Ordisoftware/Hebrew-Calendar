/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Core;

using CommandLine;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Provides system management.
/// </summary>
static partial class SystemManager
{

  /// <summary>
  /// Application mutex to allow only one process instance.
  /// </summary>
  [SuppressMessage("CodeQuality", "IDE0052:Supprimer les membres privés non lus", Justification = "Required")]
  static private Mutex ApplicationMutex;

  /// <summary>
  /// IPC server instance.
  /// </summary>
  static private NamedPipeServerStream IPCServer;

  /// <summary>
  /// Indicates if the several instances of the application can run at same time.
  /// </summary>
  static public bool AllowMultipleInstances { get; private set; } = true;

  /// <summary>
  /// IPC answers callback.
  /// </summary>
  static public Action IPCSendCommands { get; set; }

  /// <summary>
  /// Indicates if IPC is available.
  /// </summary>
  static public bool IsIPCAllowed => Globals.IsCurrentUserAdmin;

  /// <summary>
  /// Checks if IPC is available and returns true, else shows a message and returns false.
  /// </summary>
  static public bool CheckIPCAllowed()
  {
    if ( !Globals.IsCurrentUserAdmin )
    {
      string str = CommandLineArguments.Count > 0 ? CommandLineArguments.AsMultiSpace() : "show";
      DisplayManager.ShowWarning(SysTranslations.IPCNotAvailable.GetLang($"'{str}'"));
    }
    return Globals.IsCurrentUserAdmin;
  }

  /// <summary>
  /// Checks if the process is already running.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
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
        if ( CommandLineArguments.Count == 0 )
        {
          CommandLineOptions.ShowMainForm = true;
          CommandLineArguments.Add("--show");
        }
        try
        {
          if ( CheckIPCAllowed() )
            IPCSendCommandLineArguments();
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
  /// Creates IPC server instance.
  /// </summary>
  static public void CreateIPCServer(AsyncCallback ipcRequests)
  {
    if ( ipcRequests is null ) return;
    if ( !Globals.IsCurrentUserAdmin ) return;
    try
    {
      IPCServer?.Dispose();
      IPCServer = new NamedPipeServerStream(Globals.AssemblyGUID,
                                            PipeDirection.InOut,
                                            1,
                                            PipeTransmissionMode.Message,
                                            PipeOptions.Asynchronous);
      IPCServer.BeginWaitForConnection(ipcRequests, IPCServer);
    }
    catch ( Exception ex )
    {
      IPCServer?.Dispose();
      IPCServer = null;
      ex.Manage();
    }
  }

  /// <summary>
  /// Sends IPC commands.
  /// </summary>
  static private void IPCSendCommandLineArguments()
  {
    string arguments = CommandLine.Parser.Default.FormatCommandLine(CommandLineOptions);
    IPCSend(arguments);
  }

  /// <summary>
  /// Sends an IPC command.
  /// </summary>
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  static public void IPCSend(string command)
  {
    try
    {
      using var client = new NamedPipeClientStream(".", Globals.AssemblyGUID, PipeDirection.InOut);
      client.Connect(2000);
      try
      {
        new BinaryFormatter().Serialize(client, command);
      }
      finally
      {
        client.Close();
      }
    }
    catch
    {
    }
  }

}
