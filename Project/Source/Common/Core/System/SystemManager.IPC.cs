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
/// <edited> 2021-05 </edited>
namespace Ordisoftware.Core;

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
#pragma warning disable S4487 // Unread "private" fields should be removed
#pragma warning disable IDE0052 // Supprimer les membres privés non lus
  static private Mutex ApplicationMutex;
#pragma warning restore IDE0052 // Supprimer les membres privés non lus
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
  /// Indicates if the several instances of the application can run at same time.
  /// </summary>
  static public bool AllowMultipleInstances { get; private set; } = true;

  /// <summary>
  /// Checks if the process is already running.
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
        if ( CommandLineArguments?.Length == 0 )
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
  /// Creates IPC server instance.
  /// </summary>
  static public void CreateIPCServer(AsyncCallback ipcRequests)
  {
    if ( ipcRequests == null ) return;
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
  /// Sends an IPC command.
  /// </summary>
  static public void IPCSend(string command)
  {
    try
    {
      using var client = new NamedPipeClientStream(".", Globals.AssemblyGUID, PipeDirection.InOut);
      client.Connect();
      new BinaryFormatter().Serialize(client, command);
      client.Close();
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

}
