﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

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
      Thread.Sleep(2000);
      SystemManager.TryCatch(() =>
      {
        CheckRegenerateCalendar();
        var today = DateTime.Today;
        if ( CurrentDay is not null && CurrentDay.Date == today.AddDays(-1) )
          GoToDate(today);
        else
        if ( Settings.CurrentView == ViewMode.Month )
          MonthlyCalendar.Refresh();
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
      ActionDisableReminder.Enabled = false;
      ActionPreferences.Enabled = false;
      ActionResetReminder.Enabled = false;
      MenuDisableReminder.Enabled = false;
      MenuPreferences.Enabled = false;
      MenuResetReminder.Enabled = false;
      SystemManager.TryCatch(Settings.Store);
      bool showbox = !IsReminderPaused;
      bool isSpecialDayOld = IsSpecialDay;
      IsSpecialDay = false;
      IsSpecialDay = CheckShabat(showbox && Settings.ReminderShabatEnabled) || IsSpecialDay;
      IsSpecialDay = CheckCelebrationDay(showbox && Settings.ReminderCelebrationsEnabled) || IsSpecialDay;
      if ( showbox && Settings.ReminderCelebrationsEnabled ) CheckCelebrations();
#pragma warning disable S2589 // Boolean expressions should not be gratuitous - False warning due to try...finally
      if ( !IsSpecialDay && !isSpecialDayOld )
        WeeklyParashahShownAtNewWeek = true;
      else
      if ( !IsSpecialDay && isSpecialDayOld )
        WeeklyParashahShownAtNewWeek = false;
      else
      if ( IsSpecialDay )
        WeeklyParashahShownAtNewWeek = false;
#pragma warning restore S2589 // Boolean expressions should not be gratuitous
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
      ActionDisableReminder.Enabled = Settings.AllowSuspendReminder;
      ActionPreferences.Enabled = true;
      ActionResetReminder.Enabled = true;
      MenuDisableReminder.Enabled = Settings.AllowSuspendReminder;
      MenuPreferences.Enabled = true;
      MenuResetReminder.Enabled = true;
      SystemManager.TryCatch(UpdateTrayIcon, UpdateUI, ShowNewParashah, ShowLockSession);
    }
    //
    void UpdateTrayIcon()
    {
      if ( Globals.IsExiting ) return;
      if ( TrayIcon is null ) return;
      if ( CommonMenusControl.Instance is null ) return;
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
      if ( Settings.CalendarShowParashah && Settings.WeeklyParashahShowAtStartup && !IsSpecialDay && !WeeklyParashahShownAtStartup )
        doshow = true;
      else
      if ( Settings.CalendarShowParashah && Settings.WeeklyParashahShowAtNewWeek && !WeeklyParashahShownAtNewWeek && !IsSpecialDay )
        doshow = true;
      else
      if ( IsSpecialDay )
        WeeklyParashahShownAtNewWeek = false;
      if ( doshow )
      {
        var dayInfos = DBApp.GetToday()?.GetWeekLongCelebrationIntermediateDay();
        if ( dayInfos is not null )
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
          ActionWeeklyParashahDescription.PerformClick();
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
