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
/// <edited> 2020-12 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

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
      SystemManager.TryCatchManage(() => { EditCalendarColorNoDay.BackColor = Settings.MonthViewNoDaysBackColor; });
      SystemManager.TryCatchManage(() => { EditCalendarColorEmpty.BackColor = Settings.MonthViewBackColor; });
      SystemManager.TryCatchManage(() => { EditCalendarColorDefaultText.BackColor = Settings.MonthViewTextColor; });
      SystemManager.TryCatchManage(() => { EditDebuggerEnabled.Checked = Settings.DebuggerEnabled; });
      SystemManager.TryCatchManage(() => { EditVacuumAtStartup.Checked = Settings.VacuumAtStartup; });
      SystemManager.TryCatchManage(() => { EditVacuumAtStartupInterval.Value = Settings.VacuumAtStartupDaysInterval; });
      SystemManager.TryCatchManage(() => { EditHebrewLettersPath.Text = Settings.HebrewLettersExe; });
      SystemManager.TryCatchManage(() => { EditCalculatorPath.Text = Settings.CalculatorExe; });
      SystemManager.TryCatchManage(() => { EditAutoLockSession.Checked = Settings.AutoLockSession; });
      SystemManager.TryCatchManage(() => { EditAutoLockSessionTimeOut.Value = Settings.AutoLockSessionTimeOut; });
      SystemManager.TryCatchManage(() => { EditAutoOpenExportFolder.Checked = Settings.AutoOpenExportFolder; });
      SystemManager.TryCatchManage(() => { EditAutoOpenExportedFile.Checked = Settings.AutoOpenExportedFile; });
      SystemManager.TryCatchManage(() => { EditBalloon.Checked = Settings.BalloonEnabled; });
      SystemManager.TryCatchManage(() => { EditBalloonOnlyIfMainFormIsHidden.Checked = Settings.BalloonOnlyIfMainFormIsHidden; });
      SystemManager.TryCatchManage(() => { EditBalloonAutoHide.Checked = Settings.BalloonAutoHide; });
      SystemManager.TryCatchManage(() => { EditBalloonLoomingDelay.Value = Settings.BalloonLoomingDelay; });
      SystemManager.TryCatchManage(() => { EditCalendarColorFullMoon.BackColor = Settings.CalendarColorFullMoon; });
      SystemManager.TryCatchManage(() => { EditCalendarColorMoon.BackColor = Settings.CalendarColorMoon; });
      SystemManager.TryCatchManage(() => { EditCalendarColorSeason.BackColor = Settings.CalendarColorSeason; });
      SystemManager.TryCatchManage(() => { EditCalendarColorTorahEvent.BackColor = Settings.CalendarColorTorahEvent; });
      SystemManager.TryCatchManage(() => { EditCheckUpdateAtStartup.Checked = Settings.CheckUpdateAtStartup; });
      SystemManager.TryCatchManage(() => { EditCurrentDayBackColor.BackColor = Settings.CurrentDayBackColor; });
      SystemManager.TryCatchManage(() => { EditCurrentDayForeColor.BackColor = Settings.CurrentDayForeColor; });
      SystemManager.TryCatchManage(() => { EditEventColorMonth.BackColor = Settings.EventColorMonth; });
      SystemManager.TryCatchManage(() => { EditEventColorNext.BackColor = Settings.EventColorNext; });
      SystemManager.TryCatchManage(() => { EditEventColorSeason.BackColor = Settings.EventColorSeason; });
      SystemManager.TryCatchManage(() => { EditEventColorShabat.BackColor = Settings.EventColorShabat; });
      SystemManager.TryCatchManage(() => { EditEventColorTorah.BackColor = Settings.EventColorTorah; });
      SystemManager.TryCatchManage(() => { EditFontSize.Value = Settings.FontSize; });
      SystemManager.TryCatchManage(() => { EditGPSLatitude.Text = Settings.GPSLatitude; });
      SystemManager.TryCatchManage(() => { EditGPSLongitude.Text = Settings.GPSLongitude; });
      SystemManager.TryCatchManage(() => { EditMonthViewSunToolTips.Checked = Settings.MonthViewSunToolTips; });
      SystemManager.TryCatchManage(() => { EditNavigateBottomColor.BackColor = Settings.NavigateBottomColor; });
      SystemManager.TryCatchManage(() => { EditNavigateMiddleColor.BackColor = Settings.NavigateMiddleColor; });
      SystemManager.TryCatchManage(() => { EditNavigateTopColor.BackColor = Settings.NavigateTopColor; });
      SystemManager.TryCatchManage(() => { EditRemindCelebrationEveryMinutes.Value = Settings.RemindCelebrationEveryMinutes; });
      SystemManager.TryCatchManage(() => { EditRemindCelebrationHoursBefore.Value = Settings.RemindCelebrationHoursBefore; });
      SystemManager.TryCatchManage(() => { EditReminderCelebrationsEnabled.Checked = Settings.ReminderCelebrationsEnabled; });
      SystemManager.TryCatchManage(() => { EditReminderCelebrationsDaysBefore.Value = Settings.ReminderCelebrationsInterval; });
      SystemManager.TryCatchManage(() => { EditReminderShabatEnabled.Checked = Settings.ReminderShabatEnabled; });
      SystemManager.TryCatchManage(() => { EditRemindShabatEveryMinutes.Value = Settings.RemindShabatEveryMinutes; });
      SystemManager.TryCatchManage(() => { EditRemindShabatHoursBefore.Value = Settings.RemindShabatHoursBefore; });
      SystemManager.TryCatchManage(() => { EditRemindShabatOnlyLight.Checked = Settings.RemindShabatOnlyLight; });
      SystemManager.TryCatchManage(() => { EditShowReminderInTaskBar.Checked = Settings.ShowReminderInTaskBar; });
      SystemManager.TryCatchManage(() => { EditStartupHide.Checked = Settings.StartupHide; });
      SystemManager.TryCatchManage(() => { EditTextBackground.BackColor = Settings.TextBackground; });
      SystemManager.TryCatchManage(() => { EditTextColor.BackColor = Settings.TextColor; });
      SystemManager.TryCatchManage(() => { EditTorahEventsCountAsMoon.Checked = Settings.TorahEventsCountAsMoon; });
      SystemManager.TryCatchManage(() => { EditUseColors.Checked = Settings.UseColors; });
      SystemManager.TryCatchManage(() => { EditMonthViewFontSize.Value = Settings.MonthViewFontSize; });
      SystemManager.TryCatchManage(() => { OldLatitude = Settings.GPSLatitude; });
      SystemManager.TryCatchManage(() => { OldLongitude = Settings.GPSLongitude; });
      SystemManager.TryCatchManage(() => { OldShabatDay = Settings.ShabatDay; });
      SystemManager.TryCatchManage(() => { OldTimeZone = Settings.TimeZone; });
      SystemManager.TryCatchManage(() => { OldUseMoonDays = Settings.TorahEventsCountAsMoon; });
      SystemManager.TryCatchManage(() => { EditMoonDayTextFormat.Text = Settings.MoonDayTextFormat; });
      SystemManager.TryCatchManage(() => { EditWebLinksMenuEnabled.Checked = Settings.WebLinksMenuEnabled; });
      SystemManager.TryCatchManage(() => { EditAllowSuspendReminder.Checked = Settings.AllowSuspendReminder; });
      SystemManager.TryCatchManage(() => { EditCheckUpdateEveryWeek.Checked = Settings.CheckUpdateEveryWeekWhileRunning; });
      SystemManager.TryCatchManage(() => { EditCheckUpdateAtStartupInterval.Value = Settings.CheckUpdateAtStartupDaysInterval; });
      SystemManager.TryCatchManage(() => { EditAutoRegenerate.Checked = Settings.AutoRegenerate; });
      SystemManager.TryCatchManage(() => { EditMaxYearsInterval.Value = Settings.GenerateIntervalMaximum; });
      SystemManager.TryCatchManage(() => { EditAutoGenerateYearsInterval.Text = Settings.AutoGenerateYearsInternal.ToString(); });
      SystemManager.TryCatchManage(() => { EditCloseReminderFormOnClick.Checked = Settings.ReminderFormCloseOnClick; });
      SystemManager.TryCatchManage(() => { EditBigCalendarWarning.Checked = Settings.BigCalendarWarningEnabled; });
      SystemManager.TryCatchManage(() => { EditLogEnabled.Checked = Settings.TraceEnabled; });
      SystemManager.TryCatchManage(() => { EditExportFolder.Text = Settings.ExportFolder; });
      SystemManager.TryCatchManage(() => { EditVolume.Value = Settings.ApplicationVolume; });
      SystemManager.TryCatchManage(() => { EditDateBookmarksCount.Value = Settings.DateBookmarksCount; });
      SystemManager.TryCatchManage(() => { EditUsageStatisticsEnabled.Checked = Settings.UsageStatisticsEnabled; });
      SystemManager.TryCatchManage(() => { EditRestoreLastViewAtStartup.Checked = Settings.RestoreLastViewAtStartup; });
      SystemManager.TryCatchManage(() => { EditShowPrintDialog.Checked = Settings.ShowPrintPreviewDialog; });
      SystemManager.TryCatchManage(() => { EditPrintingMargin.Value = Settings.PrintingMargin; });
      SystemManager.TryCatchManage(() => { EditPrintPageCountWarning.Value = Settings.PrintPageCountWarning; });
      SystemManager.TryCatchManage(() => { EditPrintImageInLandscape.Checked = Settings.PrintImageInLandscape; });
      EditLogEnabled_CheckedChanged(null, null);
      LabelLastStartupCheckDate.Text = Settings.CheckUpdateLastDone.ToShortDateString() + " " + Settings.CheckUpdateLastDone.ToShortTimeString();
      LabelLastDBOptimizeDate.Text = Settings.VacuumLastDone.ToShortDateString() + " " + Settings.VacuumLastDone.ToShortTimeString();
    }
  }

}
