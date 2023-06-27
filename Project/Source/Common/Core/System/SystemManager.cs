/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
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
/// <edited> 2022-05 </edited>
namespace Ordisoftware.Core;

using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using GregsStack.InputSimulatorStandard;
using Microsoft.Win32;

/// <summary>
/// Provides system management.
/// </summary>
static public partial class SystemManager
{

  private const int FilePathTruncatePosition = 25;

  public const string RegistryKeyRun = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

  static public readonly InputSimulator InputSimulator = new();

  /// <summary>
  /// Deletes all app settings folders in User\AppData\Local.
  /// </summary>
  static public void CleanAllLocalAppSettingsFolders()
  {
    try
    {
      string filter = Globals.ApplicationExecutableFileName.Substring(0, FilePathTruncatePosition) + "*";
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
  /// Checks is application's settings must be upgraded and apply it if necessary.
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
  /// Indicates if the application stars with windows user session or not.
  /// </summary>
  static public bool StartWithWindowsUserRegistry
  {
    get
    {
      using var key = Registry.CurrentUser.OpenSubKey(RegistryKeyRun, true);
      return (string)key.GetValue(Globals.ApplicationFullFileName) == Globals.ApplicationStartupRegistryValue;
    }
    set
    {
      using var key = Registry.CurrentUser.OpenSubKey(RegistryKeyRun, true);
      if ( value )
        key.SetValue(Globals.ApplicationFullFileName, Globals.ApplicationStartupRegistryValue);
      else
      {
        key.DeleteValue(Globals.ApplicationFullFileName);
      }
    }
  }

  /// <summary>
  /// Finalize the application before exit or terminate.
  /// </summary>
  static private void CleanBeforeProcessEnd()
  {
    Globals.IsExiting = true;
    TryCatch(() => DebugManager.Stop());
    TryCatch(PensPool.Clear);
    TryCatch(SolidBrushesPool.Clear);
  }

  /// <summary>
  /// Exits the application process.
  /// </summary>
  static public void Exit()
  {
    CleanBeforeProcessEnd();
    Application.Exit();
  }

  /// <summary>
  /// Does a hard termination of the application process.
  /// </summary>
  static public void Terminate()
  {
    CleanBeforeProcessEnd();
    Environment.Exit(-1);
  }

  /// <summary>
  /// Gets the memory size of a serializable object.
  /// </summary>
  static public long SizeOf(this object instance)
  {
    long result = -1;
    if ( instance is null ) return 0;
    if ( instance.GetType().IsSerializable )
      try
      {
        using var stream = new MemoryStream();
        new BinaryFormatter().Serialize(stream, instance);
        result = stream.Length;
      }
      catch ( Exception ex1 )
      {
        ex1.Manage(ShowExceptionMode.None);
        try
        {
          result = Marshal.SizeOf(instance);
        }
        catch ( Exception ex2 )
        {
          ex2.Manage(ShowExceptionMode.None);
        }
      }
    return result;
  }

  /// <summary>
  /// Gets a file size.
  /// </summary>
  static public long GetFileSize(string filePath)
  {
    long result = -1;
    TryCatch(() => { if ( File.Exists(filePath) ) result = new FileInfo(filePath).Length; });
    return result;
  }

  /// <summary>
  /// Indicates if a file is locked or not.
  /// </summary>
  static public bool IsFileLocked(string filePath)
  {
    try
    {
      using var stream = new FileInfo(filePath).Open(FileMode.Open, FileAccess.Read, FileShare.None);
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
