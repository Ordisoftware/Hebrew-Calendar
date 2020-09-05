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

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm : Form
  {

    private void UpdateSettings()
    {
      Settings.MonthViewNoDaysBackColor = EditCalendarColorNoDay.BackColor;
      Settings.MonthViewBackColor = EditCalendarColorEmpty.BackColor;
      Settings.MonthViewTextColor = EditCalendarColorDefaultText.BackColor;
      Settings.DebuggerEnabled = EditDebuggerEnabled.Checked;
      Settings.VacuumAtStartup = EditVacuumAtStartup.Checked;
      Settings.HebrewLettersExe = EditHebrewLettersPath.Text;
      Settings.AutoLockSession = EditAutoLockSession.Checked;
      Settings.AutoLockSessionTimeOut = (int)EditAutoLockSessionTimeOut.Value;
      Settings.AutoOpenExportFolder = EditAutoOpenExportFolder.Checked;
      Settings.BalloonAutoHide = EditBalloonAutoHide.Checked;
      Settings.BalloonEnabled = EditBalloon.Checked;
      Settings.BalloonLoomingDelay = (int)EditBalloonLoomingDelay.Value;
      Settings.CalendarColorFullMoon = EditCalendarColorFullMoon.BackColor;
      Settings.CalendarColorMoon = EditCalendarColorMoon.BackColor;
      Settings.CalendarColorSeason = EditCalendarColorSeason.BackColor;
      Settings.CalendarColorTorahEvent = EditCalendarColorTorahEvent.BackColor;
      Settings.CheckUpdateAtStartup = EditCheckUpdateAtStartup.Checked;
      Settings.CurrentDayBackColor = EditCurrentDayBackColor.BackColor;
      Settings.CurrentDayForeColor = EditCurrentDayForeColor.BackColor;
      Settings.EventColorMonth = EditEventColorMonth.BackColor;
      Settings.EventColorNext = EditEventColorNext.BackColor;
      Settings.EventColorSeason = EditEventColorSeason.BackColor;
      Settings.EventColorShabat = EditEventColorShabat.BackColor;
      Settings.EventColorTorah = EditEventColorTorah.BackColor;
      Settings.FontSize = (int)EditFontSize.Value;
      Settings.GPSLatitude = EditGPSLatitude.Text;
      Settings.GPSLongitude = EditGPSLongitude.Text;
      Settings.MonthViewSunToolTips = EditMonthViewSunToolTips.Checked;
      Settings.NavigateBottomColor = EditNavigateBottomColor.BackColor;
      Settings.NavigateMiddleColor = EditNavigateMiddleColor.BackColor;
      Settings.NavigateTopColor = EditNavigateTopColor.BackColor;
      Settings.RemindCelebrationEveryMinutes = EditRemindCelebrationEveryMinutes.Value;
      Settings.RemindCelebrationHoursBefore = EditRemindCelebrationHoursBefore.Value;
      Settings.ReminderCelebrationsEnabled = EditReminderCelebrationsEnabled.Checked;
      Settings.ReminderCelebrationsInterval = EditReminderCelebrationsInterval.Value;
      Settings.ReminderShabatEnabled = EditReminderShabatEnabled.Checked;
      Settings.RemindShabatEveryMinutes = EditRemindShabatEveryMinutes.Value;
      Settings.RemindShabatHoursBefore = EditRemindShabatHoursBefore.Value;
      Settings.RemindShabatOnlyLight = EditRemindShabatOnlyLight.Checked;
      Settings.ShowReminderInTaskBar = EditShowReminderInTaskBar.Checked;
      Settings.StartupHide = EditStartupHide.Checked;
      Settings.TextBackground = EditTextBackground.BackColor;
      Settings.TextColor = EditTextColor.BackColor;
      Settings.TorahEventsCountAsMoon = EditTorahEventsCountAsMoon.Checked;
      Settings.UseColors = EditUseColors.Checked;
      Settings.MoonDayTextFormat = EditMoonDayTextFormat.Text;
      Settings.WebLinksMenuEnabled = EditWebLinksMenuEnabled.Checked;
      Settings.AllowSuspendReminder = EditAllowSuspendReminder.Checked;
      Settings.CheckUpdateEveryWeekWhileRunning = EditCheckUpdateEveryWeek.Checked;
      Settings.AutoRegenerate = EditAutoRegenerate.Checked;
      Settings.GenerateIntervalMaximum = (int)EditMaxYearsInterval.Value;
      Settings.AutoGenerateYearsInternal = int.Parse(EditAutoGenerateYearsInterval.Text);
      Settings.ReminderFormCloseOnClick = EditCloseReminderFormOnClick.Checked;
      Settings.BigCalendarWarningEnabled = EditBigCalendarWarning.Checked;
      Settings.TraceEnabled = EditLogEnabled.Checked;
    }

  }

}
