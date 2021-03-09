/// <license>
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
/// <edited> 2021-02 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private bool IsSpecialDay;

    public void DoTimerReminder()
    {
      if ( TimerMutex ) return;
      if ( !Globals.IsReady ) return;
      if ( !TimerReminder.Enabled ) return;
      TimerMutex = true;
      SystemManager.TryCatch(() =>
      {
        var today = DataSet.GetLunarToday();
        IsSpecialDay = today.DateAsDateTime.DayOfWeek == (DayOfWeek)Settings.ShabatDay
                    || ( today.TorahEventsAsEnum == TorahEvent.PessahD1
                      && today.TorahEventsAsEnum == TorahEvent.PessahD7
                      && today.TorahEventsAsEnum != TorahEvent.SoukotD1
                      && today.TorahEventsAsEnum != TorahEvent.SoukotD8
                      && today.TorahEventsAsEnum != TorahEvent.YomHaKipourim
                      && today.TorahEventsAsEnum != TorahEvent.YomTerouah );
        CommonMenusControl.Instance.ActionCheckUpdate.Enabled = !IsSpecialDay;
        if ( Settings.TrayIconUseSpecialDayIcon )
          TrayIcon.Icon = IsSpecialDay ? TrayIconEvent : TrayIconDefault;
      });
      try
      {
        if ( !SystemManager.IsForegroundFullScreenOrScreensaver )
        {
          if ( Settings.ReminderShabatEnabled ) CheckShabat();
          if ( Settings.ReminderCelebrationsEnabled )
          {
            CheckCelebrationDay();
            CheckCelebrations();
          }
          /*if ( Settings.ReminderAnniversarySunEnabled )
          {
            CheckAnniversarySunDay();
            CheckAnniversaryMoonDay();
            CheckAnniversarySun();
            CheckAnniversaryMoon();
          }*/
        }
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
        if ( CurrentDay.DateAsDateTime == DateTime.Today.AddDays(-1) )
          GoToDate(DateTime.Today);
        if ( Settings.CheckUpdateEveryWeekWhileRunning )
          ActionWebCheckUpdate_Click(null, null);
      });
    }

    private void EnableReminderTimer()
    {
      TimerResumeReminder.Enabled = false;
      TrayIcon.Icon = TrayIconDefault;
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
      TimerReminder.Enabled = true;
      TimerReminder_Tick(null, null);
    }

    private void DisableReminderTimer()
    {
      try
      {
        MenuTray.Enabled = false;
        var delay = SelectSuspendDelayForm.Run();
        if ( delay == null ) return;
        TrayIcon.Icon = TrayIconPause;
        TimerReminder.Enabled = false;
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
        if ( delay > 0 )
        {
          TimerResumeReminder.Interval = delay.Value * 60 * 1000;
          TimerResumeReminder.Start();
        }
      }
      finally
      {
        MenuTray.Enabled = true;
      }
    }


  }

}
