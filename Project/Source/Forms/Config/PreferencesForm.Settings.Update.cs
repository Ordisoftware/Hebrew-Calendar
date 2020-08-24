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
      Program.Settings.MonthViewNoDaysBackColor = EditCalendarColorNoDay.BackColor;
      Program.Settings.MonthViewBackColor = EditCalendarColorEmpty.BackColor;
      Program.Settings.MonthViewTextColor = EditCalendarColorDefaultText.BackColor;
      Program.Settings.DebuggerEnabled = EditDebuggerEnabled.Checked;
      Program.Settings.VacuumAtStartup = EditVacuumAtStartup.Checked;
      Program.Settings.HebrewLettersExe = EditHebrewLettersPath.Text;
      Program.Settings.AutoLockSession = EditAutoLockSession.Checked;
      Program.Settings.AutoLockSessionTimeOut = (int)EditAutoLockSessionTimeOut.Value;
      Program.Settings.AutoOpenExportFolder = EditAutoOpenExportFolder.Checked;
      Program.Settings.BalloonAutoHide = EditBalloonAutoHide.Checked;
      Program.Settings.BalloonEnabled = EditBalloon.Checked;
      Program.Settings.BalloonLoomingDelay = (int)EditBalloonLoomingDelay.Value;
      Program.Settings.CalendarColorFullMoon = EditCalendarColorFullMoon.BackColor;
      Program.Settings.CalendarColorMoon = EditCalendarColorMoon.BackColor;
      Program.Settings.CalendarColorSeason = EditCalendarColorSeason.BackColor;
      Program.Settings.CalendarColorTorahEvent = EditCalendarColorTorahEvent.BackColor;
      Program.Settings.CheckUpdateAtStartup = EditCheckUpdateAtStartup.Checked;
      Program.Settings.CurrentDayBackColor = EditCurrentDayBackColor.BackColor;
      Program.Settings.CurrentDayForeColor = EditCurrentDayForeColor.BackColor;
      Program.Settings.EventColorMonth = EditEventColorMonth.BackColor;
      Program.Settings.EventColorNext = EditEventColorNext.BackColor;
      Program.Settings.EventColorSeason = EditEventColorSeason.BackColor;
      Program.Settings.EventColorShabat = EditEventColorShabat.BackColor;
      Program.Settings.EventColorTorah = EditEventColorTorah.BackColor;
      Program.Settings.FontSize = (int)EditFontSize.Value;
      Program.Settings.GPSLatitude = EditGPSLatitude.Text;
      Program.Settings.GPSLongitude = EditGPSLongitude.Text;
      Program.Settings.MonthViewSunToolTips = EditMonthViewSunToolTips.Checked;
      Program.Settings.NavigateBottomColor = EditNavigateBottomColor.BackColor;
      Program.Settings.NavigateMiddleColor = EditNavigateMiddleColor.BackColor;
      Program.Settings.NavigateTopColor = EditNavigateTopColor.BackColor;
      Program.Settings.RemindCelebrationEveryMinutes = EditRemindCelebrationEveryMinutes.Value;
      Program.Settings.RemindCelebrationHoursBefore = EditRemindCelebrationHoursBefore.Value;
      Program.Settings.ReminderCelebrationsEnabled = EditReminderCelebrationsEnabled.Checked;
      Program.Settings.ReminderCelebrationsInterval = EditReminderCelebrationsInterval.Value;
      Program.Settings.ReminderShabatEnabled = EditReminderShabatEnabled.Checked;
      Program.Settings.RemindShabatEveryMinutes = EditRemindShabatEveryMinutes.Value;
      Program.Settings.RemindShabatHoursBefore = EditRemindShabatHoursBefore.Value;
      Program.Settings.RemindShabatOnlyLight = EditRemindShabatOnlyLight.Checked;
      Program.Settings.ShowReminderInTaskBar = EditShowReminderInTaskBar.Checked;
      Program.Settings.StartupHide = EditStartupHide.Checked;
      Program.Settings.TextBackground = EditTextBackground.BackColor;
      Program.Settings.TextColor = EditTextColor.BackColor;
      Program.Settings.TorahEventsCountAsMoon = EditTorahEventsCountAsMoon.Checked;
      Program.Settings.UseColors = EditUseColors.Checked;
      Program.Settings.MoonDayTextFormat = EditMoonDayTextFormat.Text;
      Program.Settings.WebLinksMenuEnabled = EditWebLinksMenuEnabled.Checked;
    }

  }

}
