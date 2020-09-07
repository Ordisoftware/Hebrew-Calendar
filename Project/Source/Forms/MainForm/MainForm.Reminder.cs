/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2019-10 </edited>
using System;
using System.Data;
using System.Drawing;
using System.IO;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void EnableReminder()
    {
      TimerResumeReminder.Enabled = false;
      TrayIcon.Icon = Icon;
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

    private void DisableReminder()
    {
      try
      {
        MenuTray.Enabled = false;
        var delay = SelectSuspendDelayForm.Run();
        if ( delay == null ) return;
        TrayIcon.Icon = new Icon(Path.Combine(Globals.RootFolderPath, "ApplicationPause.ico"));
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

    internal void DoTimerReminder()
    {
      if ( TimerMutex ) return;
      if ( !Globals.IsReady ) return;
      if ( !TimerReminder.Enabled ) return;
      TimerMutex = true;
      try
      {
        if ( !DisplayManager.IsForegroundFullScreenOrScreensaver() )
        {
          if ( Settings.ReminderShabatEnabled )
            CheckShabat();
          if ( Settings.ReminderCelebrationsEnabled )
          {
            CheckCelebrationDay();
            CheckEvents();
          }
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
        if ( SQLiteDate.ToDateTime(CurrentDay.Date) == DateTime.Today.AddDays(-1) )
          GoToDate(DateTime.Today);
        if ( Settings.CheckUpdateEveryWeekWhileRunning )
          ActionWebCheckUpdate_Click(null, null);
      });
    }

    private void SetTimes(ReminderTimes times, 
                          DateTime date, 
                          string timeStart, 
                          string timeEnd, 
                          int delta1, 
                          int delta2, 
                          decimal delta3)
    {
      string[] timesStart = timeStart.Split(':');
      string[] timesEnd = timeEnd.Split(':');
      times.timeStart = timeStart;
      times.timeEnd = timeEnd;
      times.dateStart = date.AddDays(delta1).AddHours(Convert.ToInt32(timesStart[0]))
                            .AddMinutes(Convert.ToInt32(timesStart[1]));
      times.dateStartCheck = times.dateStart.Value.AddMinutes((double)-delta3);
      times.dateEnd = date.AddDays(delta2).AddHours(Convert.ToInt32(timesEnd[0]))
                          .AddMinutes(Convert.ToInt32(timesEnd[1]));
    }

    private ReminderTimes CreateCelebrationTimes(Data.DataSet.LunisolarDaysRow row, decimal delta3)
    {
      var times = new ReminderTimes();
      var dateRow = SQLiteDate.ToDateTime(row.Date);
      var rowPrevious = DataSet.LunisolarDays.FindByDate(SQLiteDate.ToString(dateRow.AddDays(-1)));
      var rowNext = DataSet.LunisolarDays.FindByDate(SQLiteDate.ToString(dateRow.AddDays(+1)));
      if ( rowPrevious == null || rowNext == null )
        return null;
      if ( Settings.TorahEventsCountAsMoon )
      {
        if ( rowNext.Date == SQLiteDate.ToString(DateTime.Today) )
          SetTimes(times, dateRow, row.Moonset, rowNext.Moonset, 0, 1, delta3);
        else
        if ( row.Moonset != "" && (MoonRise)row.MoonriseType == MoonRise.AfterSet )
          SetTimes(times, dateRow, row.Moonset, rowNext.Moonset, 0, 1, delta3);
        else
        if ( row.Moonset != "" && (MoonRise)row.MoonriseType == MoonRise.NextDay )
          SetTimes(times, dateRow, row.Moonset, rowNext.Moonset, 0, 1, delta3);
        else
        if ( row.Moonset != "" && (MoonRise)row.MoonriseType == MoonRise.BeforeSet )
          SetTimes(times, dateRow, rowPrevious.Moonset, row.Moonset, -1, 0, delta3);
        else
        if ( row.Moonset == "" )
          SetTimes(times, dateRow, rowPrevious.Moonset, rowNext.Moonset, -1, 1, delta3);
        else
          throw new Exception("Error on calculating celebration dates and times.");
      }
      else
        SetTimes(times, dateRow, rowPrevious.Sunset, row.Sunset, -1, 0, delta3);
      return times;
    }

  }

}
