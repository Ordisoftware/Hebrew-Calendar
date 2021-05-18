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
/// <created> 2019-11 </created>
/// <edited> 2021-05 </edited>
using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide SystemManager helper.
  /// </summary>
  static partial class SystemManager
  {

    static public void PreventSleep()
      => NativeMethods.SetThreadExecutionState(NativeMethods.SleepDisallow);

    static public void AllowSleep()
      => NativeMethods.SetThreadExecutionState(NativeMethods.SleepAllow);

    static public bool CanStandby
      => NativeMethods.IsPwrSuspendAllowed();

    static public bool CanHibernate
    {
      get
      {
        try
        {
          using ( RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Power") )
            if ( key != null )
            {
              var value = key.GetValue("HibernateEnabled", 0);
              return value != null && (bool)value;
            }
        }
        catch
        {
          return File.Exists(@"C:\hiberfil.sys");
        }
        return false;
      }
    }

    static public bool IsScreensaverRunning
    {
      get
      {
        int running = 0;
        NativeMethods.SystemParametersInfo(NativeMethods.SPI_GETSCREENSAVERRUNNING, 0, ref running, 0);
        return running != 0;
      }
    }

    static public bool IsForegroundFullScreenOrScreensaverRunning
    {
      get
      {
        return IsForegroundFullScreen() || IsScreensaverRunning;
      }
    }

    static public bool IsForegroundFullScreen(Screen screen = null)
    {
      if ( screen == null ) screen = Screen.PrimaryScreen;
      NativeMethods.RECT rect = new NativeMethods.RECT();
      NativeMethods.GetWindowRect(new HandleRef(null, NativeMethods.GetForegroundWindow()), ref rect);
      var rectangle = new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
      return rectangle.Contains(screen.Bounds);
    }

    static public bool LockWorkStation()
    {
      return NativeMethods.LockWorkStation();
    }

    static public void StandBy()
    {
      Application.SetSuspendState(PowerState.Suspend, false, false);
    }

    static public void Hibernate()
    {
      Application.SetSuspendState(PowerState.Hibernate, false, false);
    }

    static public void LogOff()
    {
      RunShell("shutdown", "/l /t 0");
    }

    static public void Restart()
    {
      RunShell("shutdown", "/r /t 0");
    }

    static public void Shutdown()
    {
      RunShell("shutdown", "/s /t 0");
    }

    static public void DoPowerAction(PowerActions action)
    {
      switch ( action )
      {
        case PowerActions.None:
          break;
        case PowerActions.LockSession:
          LockWorkStation();
          break;
        case PowerActions.StandBy:
          StandBy();
          break;
        case PowerActions.Hibernate:
          Hibernate();
          break;
        case PowerActions.LogOff:
          LogOff();
          break;
        case PowerActions.Restart:
          Restart();
          break;
        case PowerActions.Shutdown:
          Shutdown();
          break;
        default:
          throw new AdvancedNotImplementedException(action);
      }
    }

  }

}
