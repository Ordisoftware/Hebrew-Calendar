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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm : Form
  {

    private void LoadSettings()
    {
      EditCalendarColorNoDay.BackColor = Settings.MonthViewNoDaysBackColor;
      EditCalendarColorEmpty.BackColor = Settings.MonthViewBackColor;
      EditCalendarColorDefaultText.BackColor = Settings.MonthViewTextColor;
      EditDebuggerEnabled.Checked = Settings.DebuggerEnabled;
      EditVacuumAtStartup.Checked = Settings.VacuumAtStartup;
      EditHebrewLettersPath.Text = Settings.HebrewLettersExe;
      EditAutoLockSession.Checked = Settings.AutoLockSession;
      EditAutoLockSessionTimeOut.Value = Settings.AutoLockSessionTimeOut;
      EditAutoOpenExportFolder.Checked = Settings.AutoOpenExportFolder;
      EditBalloon.Checked = Settings.BalloonEnabled;
      EditBalloonAutoHide.Checked = Settings.BalloonAutoHide;
      EditBalloonLoomingDelay.Value = Settings.BalloonLoomingDelay;
      EditCalendarColorFullMoon.BackColor = Settings.CalendarColorFullMoon;
      EditCalendarColorMoon.BackColor = Settings.CalendarColorMoon;
      EditCalendarColorSeason.BackColor = Settings.CalendarColorSeason;
      EditCalendarColorTorahEvent.BackColor = Settings.CalendarColorTorahEvent;
      EditCheckUpdateAtStartup.Checked = Settings.CheckUpdateAtStartup;
      EditCurrentDayBackColor.BackColor = Settings.CurrentDayBackColor;
      EditCurrentDayForeColor.BackColor = Settings.CurrentDayForeColor;
      EditEventColorMonth.BackColor = Settings.EventColorMonth;
      EditEventColorNext.BackColor = Settings.EventColorNext;
      EditEventColorSeason.BackColor = Settings.EventColorSeason;
      EditEventColorShabat.BackColor = Settings.EventColorShabat;
      EditEventColorTorah.BackColor = Settings.EventColorTorah;
      EditFontSize.Value = Settings.FontSize;
      EditGPSLatitude.Text = Settings.GPSLatitude;
      EditGPSLongitude.Text = Settings.GPSLongitude;
      EditMonthViewSunToolTips.Checked = Settings.MonthViewSunToolTips;
      EditNavigateBottomColor.BackColor = Settings.NavigateBottomColor;
      EditNavigateMiddleColor.BackColor = Settings.NavigateMiddleColor;
      EditNavigateTopColor.BackColor = Settings.NavigateTopColor;
      EditRemindCelebrationEveryMinutes.Value = Settings.RemindCelebrationEveryMinutes;
      EditRemindCelebrationHoursBefore.Value = Settings.RemindCelebrationHoursBefore;
      EditReminderCelebrationsEnabled.Checked = Settings.ReminderCelebrationsEnabled;
      EditReminderCelebrationsInterval.Value = Settings.ReminderCelebrationsInterval;
      EditReminderShabatEnabled.Checked = Settings.ReminderShabatEnabled;
      EditRemindShabatEveryMinutes.Value = Settings.RemindShabatEveryMinutes;
      EditRemindShabatHoursBefore.Value = Settings.RemindShabatHoursBefore;
      EditRemindShabatOnlyLight.Checked = Settings.RemindShabatOnlyLight;
      EditShowReminderInTaskBar.Checked = Settings.ShowReminderInTaskBar;
      EditStartupHide.Checked = Settings.StartupHide;
      EditTextBackground.BackColor = Settings.TextBackground;
      EditTextColor.BackColor = Settings.TextColor;
      EditTorahEventsCountAsMoon.Checked = Settings.TorahEventsCountAsMoon;
      EditUseColors.Checked = Settings.UseColors;
      EditMonthViewFontSize.Value = Settings.MonthViewFontSize;
      OldLatitude = Settings.GPSLatitude;
      OldLongitude = Settings.GPSLongitude;
      OldShabatDay = Settings.ShabatDay;
      OldTimeZone = Settings.TimeZone;
      OldUseMoonDays = Settings.TorahEventsCountAsMoon;
      EditMoonDayTextFormat.Text = Settings.MoonDayTextFormat;
      EditWebLinksMenuEnabled.Checked = Settings.WebLinksMenuEnabled;
      EditAllowSuspendReminder.Checked = Settings.AllowSuspendReminder;
      EditCheckUpdateEveryWeek.Checked = Settings.CheckUpdateEveryWeekWhileRunning;
      EditAutoRegenerate.Checked = Settings.AutoRegenerate;
      EditMaxYearsInterval.Value = Settings.GenerateIntervalMaximum;
      EditAutoGenerateYearsInterval.Text = Settings.AutoGenerateYearsInternal.ToString();
      EditCloseReminderFormOnClick.Checked = Settings.ReminderFormCloseOnClick;
      EditBigCalendarWarning.Checked = Settings.BigCalendarWarningEnabled;
      EditLogEnabled.Checked = Settings.TraceEnabled;
      EditLogEnabled_CheckedChanged(null, null);
    }

  }

}
