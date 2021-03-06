﻿/// <license>
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
using System.Collections.Generic;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide SystemManager helper.
  /// </summary>
  static partial class SystemManager
  {

    static public List<PowerActions> GetAvailablePowerActions()
    {
      var list = new List<PowerActions>();
      list.Add(PowerActions.LockSession);
      if ( CanStandby ) list.Add(PowerActions.StandBy);
      if ( CanHibernate ) list.Add(PowerActions.Hibernate);
      list.Add(PowerActions.LogOff);
      list.Add(PowerActions.Restart);
      list.Add(PowerActions.Shutdown);
      return list;
    }

    static public bool IsUserSession { get; private set; }

    static public bool IsSessionLocked { get; private set; }

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

    static public bool IsForegroundFullScreenOrScreensaverRunning
    {
      get
      {
        return IsForegroundFullScreen() || IsScreensaverRunning;
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

    static public bool StandBy()
    {
      return Application.SetSuspendState(PowerState.Suspend, false, false);
    }

    static public bool Hibernate()
    {
      return Application.SetSuspendState(PowerState.Hibernate, false, false);
    }

    static public bool LogOff(bool confirm)
    {
      return RunProtectedPowerAction(() => { RunShell("shutdown", "/l /t 0"); }, confirm);
    }

    static public bool Restart(bool confirm)
    {
      return RunProtectedPowerAction(() => { RunShell("shutdown", "/r /t 0"); }, confirm);
    }

    static public bool Shutdown(bool confirm)
    {
      return RunProtectedPowerAction(() => { RunShell("shutdown", "/s /t 0"); }, confirm);
    }

    static private bool RunProtectedPowerAction(Action action, bool confirm)
    {
      if ( confirm )
        if ( !DisplayManager.QueryYesNo(SysTranslations.AskToShutdownComputer.GetLang()) )
          return false;
      action();
      return true;
    }

    static public bool DoPowerAction(PowerActions action, bool confirmLogOffOrMore)
    {
      switch ( action )
      {
        case PowerActions.None:
          return true;
        case PowerActions.LockSession:
          return LockWorkStation();
        case PowerActions.StandBy:
          return StandBy();
        case PowerActions.Hibernate:
          return Hibernate();
        case PowerActions.LogOff:
          return LogOff(confirmLogOffOrMore);
        case PowerActions.Restart:
          return Restart(confirmLogOffOrMore);
        case PowerActions.Shutdown:
          return Shutdown(confirmLogOffOrMore);
        default:
          throw new AdvancedNotImplementedException(action);
      }
    }

  }

}
