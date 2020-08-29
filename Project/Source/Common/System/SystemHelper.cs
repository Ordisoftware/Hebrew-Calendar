﻿/// <license>
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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.IO;
using System.IO.Pipes;
using System.Configuration;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide system helper.
  /// </summary>
  static partial class SystemHelper
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
        bool created;
        ApplicationMutex = new Mutex(true, Globals.AssemblyGUID, out created);
        if ( created )
        {
          CreateIPCServer(duplicated);
        }
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
    static public void UpgradeIfRequired(this ApplicationSettingsBase settings, ref bool upgradeRequired)
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
    /// Get the memory size of a serializable object.
    /// </summary>
    static public long SizeOf(this object instance)
    {
      if ( instance == null ) return 0;
      if ( !instance.GetType().IsSerializable ) return -1;
      using ( MemoryStream stream = new MemoryStream() )
        try
        {
          new BinaryFormatter().Serialize(stream, instance);
          return stream.Length;
        }
        catch
        {
          return -1;
        }
    }

  }

}
