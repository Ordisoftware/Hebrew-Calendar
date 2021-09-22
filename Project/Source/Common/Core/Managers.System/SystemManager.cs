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
/// <edited> 2021-09 </edited>
using System;
using System.Linq;
using System.IO;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Win32;
using InputSimulatorStandard;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system manager.
  /// </summary>
  static partial class SystemManager
  {

    public const string RegistryKeyRun = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

    static public readonly InputSimulator InputSimulator = new InputSimulator();

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
          try { settings.Save(); } catch { }
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
    /// Get the memory size of a serializable object.
    /// </summary>
    static public long SizeOf(this object instance)
    {
      long result = -1;
      if ( instance == null ) return 0;
      if ( instance.GetType().IsSerializable )
        try
        {
          using ( var stream = new MemoryStream() )
          {
            new BinaryFormatter().Serialize(stream, instance);
            result = stream.Length;
          }
        }
        catch ( Exception ex1 )
        {
          ex1.Manage(ShowExceptionMode.None);
          try
          {
            result = System.Runtime.InteropServices.Marshal.SizeOf(instance);
          }
          catch ( Exception ex2 )
          {
            ex2.Manage(ShowExceptionMode.None);
          }
        }
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

    /// <summary>
    /// Indicate if a file is locked or not.
    /// </summary>
    static public bool IsFileLocked(string filePath)
    {
      try
      {
        using ( FileStream stream = new FileInfo(filePath).Open(FileMode.Open, FileAccess.Read, FileShare.None) )
          stream.Close();
        return false;
      }
      catch ( IOException )
      {
        return true;
      }
    }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static SystemManager()
    {
      if ( Globals.PreLoadSSLCertificate )
        LoadSSLCertificate();
    }

  }

}
