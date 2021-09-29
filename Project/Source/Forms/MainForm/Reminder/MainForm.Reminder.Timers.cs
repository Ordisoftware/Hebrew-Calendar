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
/// <edited> 2021-09 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private bool IsSpecialDay;
    private bool WeeklyParashahShownAtStartup;
    private bool WeeklyParashahShownAtNewWeek;

    private void DoTimerMidnight()
    {
      if ( !Globals.IsReady ) return;
      this.SyncUI(() =>
      {
        System.Threading.Thread.Sleep(2000);
        SystemManager.TryCatch(() =>
        {
          CheckRegenerateCalendar();
          var today = DateTime.Today;
          if ( CurrentDay.Date == today.AddDays(-1) )
            GoToDate(today);
          else
          if ( Settings.CurrentView == ViewMode.Month )
            CalendarMonth.Refresh();
          UpdateTitles(true);
          if ( Settings.CheckUpdateEveryWeekWhileRunning )
            ActionWebCheckUpdate_Click(null, null);
        });
      });
    }

    public void DoTimerReminder()
    {
      if ( TimerMutex ) return;
      if ( Globals.IsExiting ) return;
      if ( !Globals.IsReady ) return;
      try
      {
        if ( !TimerReminder.Enabled ) return;
        if ( SystemManager.IsForegroundFullScreenOrScreensaverRunning ) return;
        TimerMutex = true;
        UpdateTitlesMutex = true;
        SystemManager.TryCatch(CheckProcessRelicate);
        SystemManager.TryCatch(Settings.Store);
        bool showbox = !IsReminderPaused;
        bool IsSpecialDayOld = IsSpecialDay;
        IsSpecialDay = false;
        IsSpecialDay = CheckShabat(showbox && Settings.ReminderShabatEnabled) || IsSpecialDay;
        IsSpecialDay = CheckCelebrationDay(showbox && Settings.ReminderCelebrationsEnabled) || IsSpecialDay;
        if ( showbox && Settings.ReminderCelebrationsEnabled ) CheckCelebrations();
#pragma warning disable S2589 // Boolean expressions should not be gratuitous - False warning due to try...finally
        if ( !IsSpecialDay && !IsSpecialDayOld )
          WeeklyParashahShownAtNewWeek = true;
        else
        if ( !IsSpecialDay && IsSpecialDayOld )
          WeeklyParashahShownAtNewWeek = false;
        else
        if ( IsSpecialDay )
          WeeklyParashahShownAtNewWeek = false;
#pragma warning restore S2589 // Boolean expressions should not be gratuitous - False warning due to try...finally
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
        UpdateTitlesMutex = false;
        SystemManager.TryCatch(UpdateTrayIcon, UpdateUI, ShowNewParashah, ShowLockSession);
      }
      //
      void CheckProcessRelicate()
      {
        var processes = Globals.SameRunningProcessesNotThisOne;
        if ( processes.Any() )
          TimerKillProcesses.Start();
      }
      //
      void UpdateTrayIcon()
      {
        if ( Globals.IsExiting ) return;
        if ( TrayIcon == null ) return;
        if ( CommonMenusControl.Instance == null ) return;
        CommonMenusControl.Instance.ActionCheckUpdate.Enabled = !IsSpecialDay;
        AboutBox.Instance.ActionCheckUpdate.Enabled = !IsSpecialDay;
        TrayIcon.Icon = TrayIcons[!IsReminderPaused][Settings.TrayIconUseSpecialDayIcon && IsSpecialDay];
      }
      //
      void UpdateUI()
      {
        UpdateTitles(true);
      }
      //
      void ShowLockSession()
      {
        if ( LockSessionForm.Instance?.Visible ?? false )
          LockSessionForm.Instance.Popup();
      }
      //
      void ShowNewParashah()
      {
        bool doshow = false;
        if ( !IsSpecialDay && !WeeklyParashahShownAtStartup && Settings.WeeklyParashahShowAtStartup )
          doshow = true;
        else
        if ( !WeeklyParashahShownAtNewWeek && Settings.WeeklyParashahShowAtNewWeek && !IsSpecialDay )
          doshow = true;
        else
        if ( IsSpecialDay )
          WeeklyParashahShownAtNewWeek = false;
        if ( doshow )
        {
          var dayInfos = ApplicationDatabase.Instance.GetToday()?.GetWeekLongCelebrationIntermediateDay();
          if ( dayInfos != null )
          {
            doshow = dayInfos.Value.Event == TorahCelebration.None
                     || ( dayInfos.Value.Event != TorahCelebration.Pessah
                          && dayInfos.Value.Event != TorahCelebration.YomTerouah
                          && dayInfos.Value.Event != TorahCelebration.YomHaKipourim
                          && dayInfos.Value.Event != TorahCelebration.Soukot
                        )
                     || ( dayInfos.Value.Event == TorahCelebration.Soukot
                          && dayInfos.Value.Index == 8
                          && !Settings.UseSimhatTorahOutside
                        );
            WeeklyParashahShownAtNewWeek = doshow;
          }
          if ( doshow )
          {
            WeeklyParashahShownAtStartup = true;
            WeeklyParashahShownAtNewWeek = true;
            ActionViewParashahDescription.PerformClick();
          }
        }
      }
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
