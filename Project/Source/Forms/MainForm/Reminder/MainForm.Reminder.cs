﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Linq;
using System.Threading.Tasks;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private bool IsSpecialDay;

    public void DoTimerReminder()
    {
      if ( TimerMutex ) return;
      if ( Globals.IsExiting ) return;
      if ( !Globals.IsReady ) return;
      if ( !TimerReminder.Enabled ) return;
      TimerMutex = true;
      CheckProcessRelicate();
      try
      {
        IsSpecialDay = false;
        IsSpecialDay = CheckShabat(!SystemManager.IsForegroundFullScreenOrScreensaverRunning && !IsReminderPaused && Settings.ReminderShabatEnabled) || IsSpecialDay;
        IsSpecialDay = CheckCelebrationDay(!SystemManager.IsForegroundFullScreenOrScreensaverRunning && !IsReminderPaused && Settings.ReminderCelebrationsEnabled) || IsSpecialDay;
        if ( !SystemManager.IsForegroundFullScreenOrScreensaverRunning && !IsReminderPaused && Settings.ReminderCelebrationsEnabled )
          CheckCelebrations();
      }
      catch ( Exception ex )
      {
        if ( TimerErrorShown ) return;
        TimerErrorShown = true;
        ex.Manage();
      }
      finally
      {
        TimerMutex = false;
        SystemManager.TryCatch(() =>
        {
          if ( Globals.IsExiting ) return;
          if ( TrayIcon == null ) return;
          if ( CommonMenusControl.Instance == null ) return;
          CommonMenusControl.Instance.ActionCheckUpdate.Enabled = !IsSpecialDay;
          TrayIcon.Icon = TrayIcons[!IsReminderPaused][Settings.TrayIconUseSpecialDayIcon && IsSpecialDay];
        });
        SystemManager.TryCatch(() =>
        {
          if ( LockSessionForm.Instance?.Visible ?? false )
            LockSessionForm.Instance.Popup();
        });
      }
    }

    private void DoTimerMidnight()
    {
      if ( !Globals.IsReady ) return;
      this.SyncUI(() =>
      {
        System.Threading.Thread.Sleep(1000);
        CheckRegenerateCalendar();
        CalendarMonth.Refresh();
        if ( CurrentDay.Date == DateTime.Today.AddDays(-1) )
          GoToDate(DateTime.Today);
        if ( Settings.CheckUpdateEveryWeekWhileRunning )
          ActionWebCheckUpdate_Click(null, null);
      });
    }

    private void EnableReminderTimer(bool calltimer = true)
    {
      TimerResumeReminder.Enabled = false;
      ActionResetReminder.Enabled = true;
      ActionEnableReminder.Visible = false;
      ActionDisableReminder.Visible = true;
      ActionEnableReminder.Enabled = false;
      ActionDisableReminder.Enabled = Settings.AllowSuspendReminder;
      MenuResetReminder.Enabled = true;
      MenuEnableReminder.Visible = false;
      MenuDisableReminder.Visible = true;
      MenuEnableReminder.Enabled = false;
      MenuDisableReminder.Enabled = Settings.AllowSuspendReminder;
      IsReminderPaused = false;
      UpdateTitles();
      if ( calltimer )
      {
        ClearLists();
        TimerReminder_Tick(null, null);
      }
    }

    private void DisableReminderTimer()
    {
      try
      {
        MenuTray.Enabled = false;
        var delay = SelectSuspendDelayForm.Run();
        if ( delay == null ) return;
        IsReminderPaused = true;
        ActionResetReminder.Enabled = false;
        ActionEnableReminder.Visible = true;
        ActionDisableReminder.Visible = false;
        ActionEnableReminder.Enabled = true;
        ActionDisableReminder.Enabled = false;
        MenuResetReminder.Enabled = false;
        MenuEnableReminder.Visible = true;
        MenuDisableReminder.Visible = false;
        MenuEnableReminder.Enabled = true;
        MenuDisableReminder.Enabled = false;
        ClearLists();
        UpdateTitles();
        if ( delay > 0 )
        {
          TimerResumeReminder.Interval = delay.Value * 60 * 1000;
          TimerResumeReminder.Start();
        }
        TimerReminder_Tick(null, null);
      }
      finally
      {
        MenuTray.Enabled = true;
      }
    }

    private void CheckProcessRelicate()
    {
      SystemManager.TryCatch(() =>
      {
        var processes = Globals.SameRunningProcessesNotThisOne;
        if ( processes.Count() != 0 )
          TimerKillProcesses.Start();
      });
    }

  }

}

/*if ( Settings.ReminderAnniversarySunEnabled )
{
  CheckAnniversarySunDay();
  CheckAnniversaryMoonDay();
  CheckAnniversarySun();
  CheckAnniversaryMoon();
}*/