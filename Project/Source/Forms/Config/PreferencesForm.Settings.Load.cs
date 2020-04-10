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
/// <edited> 2020-04 </edited>
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

    private void LoadSettings()
    {
      EditAutoLockSession.Checked = Program.Settings.AutoLockSession;
      EditAutoLockSessionTimeOut.Value = Program.Settings.AutoLockSessionTimeOut;
      EditAutoOpenExportFolder.Checked = Program.Settings.AutoOpenExportFolder;
      EditBalloon.Checked = Program.Settings.BalloonEnabled;
      EditBalloonAutoHide.Checked = Program.Settings.BalloonAutoHide;
      EditBalloonLoomingDelay.Value = Program.Settings.BalloonLoomingDelay;
      EditCalendarColorFullMoon.BackColor = Program.Settings.CalendarColorFullMoon;
      EditCalendarColorMoon.BackColor = Program.Settings.CalendarColorMoon;
      EditCalendarColorSeason.BackColor = Program.Settings.CalendarColorSeason;
      EditCalendarColorTorahEvent.BackColor = Program.Settings.CalendarColorTorahEvent;
      EditCheckUpdateAtStartup.Checked = Program.Settings.CheckUpdateAtStartup;
      EditCurrentDayBackColor.BackColor = Program.Settings.CurrentDayBackColor;
      EditCurrentDayForeColor.BackColor = Program.Settings.CurrentDayForeColor;
      EditEventColorMonth.BackColor = Program.Settings.EventColorMonth;
      EditEventColorNext.BackColor = Program.Settings.EventColorNext;
      EditEventColorSeason.BackColor = Program.Settings.EventColorSeason;
      EditEventColorShabat.BackColor = Program.Settings.EventColorShabat;
      EditEventColorTorah.BackColor = Program.Settings.EventColorTorah;
      EditFontSize.Value = Program.Settings.FontSize;
      EditGPSLatitude.Text = Program.Settings.GPSLatitude;
      EditGPSLongitude.Text = Program.Settings.GPSLongitude;
      EditMonthViewSunToolTips.Checked = Program.Settings.MonthViewSunToolTips;
      EditNavigateBottomColor.BackColor = Program.Settings.NavigateBottomColor;
      EditNavigateMiddleColor.BackColor = Program.Settings.NavigateMiddleColor;
      EditNavigateTopColor.BackColor = Program.Settings.NavigateTopColor;
      EditRemindCelebrationEveryMinutes.Value = Program.Settings.RemindCelebrationEveryMinutes;
      EditRemindCelebrationHoursBefore.Value = Program.Settings.RemindCelebrationHoursBefore;
      EditReminderCelebrationsEnabled.Checked = Program.Settings.ReminderCelebrationsEnabled;
      EditReminderCelebrationsInterval.Value = Program.Settings.ReminderCelebrationsInterval;
      EditReminderShabatEnabled.Checked = Program.Settings.ReminderShabatEnabled;
      EditRemindShabatEveryMinutes.Value = Program.Settings.RemindShabatEveryMinutes;
      EditRemindShabatHoursBefore.Value = Program.Settings.RemindShabatHoursBefore;
      EditRemindShabatOnlyLight.Checked = Program.Settings.RemindShabatOnlyLight;
      EditShowReminderInTaskBar.Checked = Program.Settings.ShowReminderInTaskBar;
      EditStartupHide.Checked = Program.Settings.StartupHide;
      EditTextBackground.BackColor = Program.Settings.TextBackground;
      EditTextColor.BackColor = Program.Settings.TextColor;
      EditTorahEventsCountAsMoon.Checked = Program.Settings.TorahEventsCountAsMoon;
      EditUseColors.Checked = Program.Settings.UseColors;
      EditMonthViewFontSize.Value = Program.Settings.MonthViewFontSize;
      LabelGPSCity.Text = Program.Settings.GPSCity;
      LabelGPSCountry.Text = Program.Settings.GPSCountry;
      OldLatitude = Program.Settings.GPSLatitude;
      OldLongitude = Program.Settings.GPSLongitude;
      OldReminderCurrentDayColor = Program.Settings.EventColorTorah;
      OldReminderShabatDayColor = Program.Settings.EventColorShabat;
      OldReminderUseColors = Program.Settings.UseColors;
      OldShabatDay = Program.Settings.ShabatDay;
      OldTimeZone = Program.Settings.TimeZone;
      OldUseMoonDays = Program.Settings.TorahEventsCountAsMoon;
    }

  }

}
