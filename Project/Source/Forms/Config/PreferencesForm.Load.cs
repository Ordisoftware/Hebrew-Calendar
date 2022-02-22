/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class PreferencesForm
{

  private void LoadSettings()
  {
    SystemManager.TryCatch(() => EditTrayIconUseSpecialDayIcon.Checked = Settings.TrayIconUseSpecialDayIcon);
    SystemManager.TryCatch(() => EditMonthViewNoDaysBackColor.BackColor = Settings.MonthViewNoDaysBackColor);
    SystemManager.TryCatch(() => EditMonthViewBackColor.BackColor = Settings.MonthViewBackColor);
    SystemManager.TryCatch(() => EditMonthViewTextColor.BackColor = Settings.MonthViewTextColor);
    SystemManager.TryCatch(() => EditDebuggerEnabled.Checked = Settings.DebuggerEnabled);
    SystemManager.TryCatch(() => EditVacuumAtStartup.Checked = Settings.VacuumAtStartup);
    SystemManager.TryCatch(() => EditVacuumAtStartupInterval.Value = Settings.VacuumAtStartupDaysInterval);
    SystemManager.TryCatch(() => EditHebrewLettersPath.Text = Settings.HebrewLettersExe);
    SystemManager.TryCatch(() => EditHebrewWordsPath.Text = Settings.HebrewWordsExe);
    SystemManager.TryCatch(() => EditCalculatorPath.Text = Settings.CalculatorExe);
    SystemManager.TryCatch(() => EditAutoLockSession.Checked = Settings.AutoLockSession);
    SystemManager.TryCatch(() => EditAutoLockSessionTimeOut.Value = Settings.AutoLockSessionTimeOut);
    SystemManager.TryCatch(() => EditAutoOpenExportFolder.Checked = Settings.AutoOpenExportFolder);
    SystemManager.TryCatch(() => EditAutoOpenExportedFile.Checked = Settings.AutoOpenExportedFile);
    SystemManager.TryCatch(() => EditBalloon.Checked = Settings.BalloonEnabled);
    SystemManager.TryCatch(() => EditBalloonOnlyIfMainFormIsHidden.Checked = Settings.BalloonOnlyIfMainFormIsHidden);
    SystemManager.TryCatch(() => EditBalloonAutoHide.Checked = Settings.BalloonAutoHide);
    SystemManager.TryCatch(() => EditBalloonLoomingDelay.Value = Settings.BalloonLoomingDelay);
    SystemManager.TryCatch(() => EditCalendarColorFullMoon.BackColor = Settings.CalendarColorFullMoon);
    SystemManager.TryCatch(() => EditCalendarColorMoon.BackColor = Settings.CalendarColorMoon);
    SystemManager.TryCatch(() => EditCalendarColorSeason.BackColor = Settings.CalendarColorSeason);
    SystemManager.TryCatch(() => EditCalendarColorParashah.BackColor = Settings.CalendarColorParashah);
    SystemManager.TryCatch(() => EditCalendarColorTorahEvent.BackColor = Settings.CalendarColorTorahEvent);
    SystemManager.TryCatch(() => EditCheckUpdateAtStartup.Checked = Settings.CheckUpdateAtStartup);
    SystemManager.TryCatch(() => EditCurrentDayBackColor.BackColor = Settings.CurrentDayBackColor);
    SystemManager.TryCatch(() => EditCurrentDayForeColor.BackColor = Settings.CurrentDayForeColor);
    SystemManager.TryCatch(() => EditSelectedDayBoxColor.BackColor = Settings.SelectedDayBoxColor);
    SystemManager.TryCatch(() => EditCalendarColorActiveDay.BackColor = Settings.CalendarColorActiveDay);
    SystemManager.TryCatch(() => EditCalendarColorHoverEffect.BackColor = Settings.CalendarColorHoverEffect);
    SystemManager.TryCatch(() => EditEventColorMonth.BackColor = Settings.EventColorMonth);
    SystemManager.TryCatch(() => EditEventColorNext.BackColor = Settings.EventColorNext);
    SystemManager.TryCatch(() => EditEventColorSeason.BackColor = Settings.EventColorSeason);
    SystemManager.TryCatch(() => EditEventColorShabat.BackColor = Settings.EventColorShabat);
    SystemManager.TryCatch(() => EditEventColorTorah.BackColor = Settings.EventColorTorah);
    SystemManager.TryCatch(() => EditTextReportFontSize.Value = Settings.FontSize);
    SystemManager.TryCatch(() => EditGPSLatitude.Text = Settings.GPSLatitude);
    SystemManager.TryCatch(() => EditGPSLongitude.Text = Settings.GPSLongitude);
    SystemManager.TryCatch(() => EditMonthViewChangeDayOnClick.Checked = Settings.MonthViewChangeDayOnClick);
    SystemManager.TryCatch(() => EditNavigateBottomColor.BackColor = Settings.NavigateBottomColor);
    SystemManager.TryCatch(() => EditNavigateMiddleColor.BackColor = Settings.NavigateMiddleColor);
    SystemManager.TryCatch(() => EditNavigateTopColor.BackColor = Settings.NavigateTopColor);
    SystemManager.TryCatch(() => EditRemindCelebrationEveryMinutes.Value = Settings.RemindCelebrationEveryMinutes);
    SystemManager.TryCatch(() => EditRemindCelebrationHoursBefore.Value = Settings.RemindCelebrationHoursBefore);
    SystemManager.TryCatch(() => EditReminderCelebrationsEnabled.Checked = Settings.ReminderCelebrationsEnabled);
    SystemManager.TryCatch(() => EditRemindCelebrationsDaysBefore.Value = Settings.ReminderCelebrationsInterval);
    SystemManager.TryCatch(() => EditReminderShabatEnabled.Checked = Settings.ReminderShabatEnabled);
    SystemManager.TryCatch(() => EditRemindShabatEveryMinutes.Value = Settings.RemindShabatEveryMinutes);
    SystemManager.TryCatch(() => EditRemindShabatHoursBefore.Value = Settings.RemindShabatHoursBefore);
    SystemManager.TryCatch(() => EditRemindShabatOnlyLight.Checked = Settings.RemindShabatOnlyLight);
    SystemManager.TryCatch(() => EditShowReminderInTaskBar.Checked = Settings.ShowReminderInTaskBar);
    SystemManager.TryCatch(() => EditStartupHide.Checked = Settings.StartupHide);
    SystemManager.TryCatch(() => EditTextReportBackColor.BackColor = Settings.TextBackground);
    SystemManager.TryCatch(() => EditTextReportTextColor.BackColor = Settings.TextColor);
    SystemManager.TryCatch(() => EditUseSimhatTorahOutside.Checked = Settings.UseSimhatTorahOutside);
    SystemManager.TryCatch(() => EditUseColors.Checked = Settings.UseColors);
    SystemManager.TryCatch(() => EditMoonDayTextFormat.Text = Settings.MoonDayTextFormat);
    SystemManager.TryCatch(() => EditWebLinksMenuEnabled.Checked = Settings.WebLinksMenuEnabled);
    SystemManager.TryCatch(() => EditAllowSuspendReminder.Checked = Settings.AllowSuspendReminder);
    SystemManager.TryCatch(() => EditCheckUpdateEveryWeek.Checked = Settings.CheckUpdateEveryWeekWhileRunning);
    SystemManager.TryCatch(() => EditCheckUpdateAtStartupInterval.Value = Settings.CheckUpdateAtStartupDaysInterval);
    SystemManager.TryCatch(() => EditAutoRegenerate.Checked = Settings.AutoRegenerate);
    SystemManager.TryCatch(() => EditMaxYearsInterval.Value = Settings.GenerateIntervalMaximum);
    SystemManager.TryCatch(() => EditAutoGenerateYearsInterval.Text = Settings.AutoGenerateYearsInternal.ToString());
    SystemManager.TryCatch(() => EditCloseReminderFormOnClick.Checked = Settings.ReminderFormCloseOnClick);
    SystemManager.TryCatch(() => EditBigCalendarWarning.Checked = Settings.BigCalendarWarningEnabled);
    SystemManager.TryCatch(() => EditLogEnabled.Checked = Settings.TraceEnabled);
    SystemManager.TryCatch(() => EditExportFolder.Text = Settings.ExportFolder);
    SystemManager.TryCatch(() => EditVolume.Value = Settings.ApplicationVolume);
    SystemManager.TryCatch(() => EditUsageStatisticsEnabled.Checked = Settings.UsageStatisticsEnabled);
    SystemManager.TryCatch(() => EditRestoreLastViewAtStartup.Checked = Settings.RestoreLastViewAtStartup);
    SystemManager.TryCatch(() => EditShowPrintDialog.Checked = Settings.ShowPrintPreviewDialog);
    SystemManager.TryCatch(() => EditPrintingMargin.Value = Settings.PrintingMargin);
    SystemManager.TryCatch(() => EditPrintPageCountWarning.Value = Settings.PrintPageCountWarning);
    SystemManager.TryCatch(() => EditPrintImageInLandscape.Checked = Settings.PrintImageInLandscape);
    SystemManager.TryCatch(() => EditExportDataEnumsAsTranslations.Checked = Settings.ExportDataEnumsAsTranslations);
    SystemManager.TryCatch(() => EditSaveImageCountWarning.Value = Settings.SaveImageCountWarning);
    SystemManager.TryCatch(() => EditGlobalHotKeyPopupMainFormEnabled.Checked = Settings.GlobalHotKeyPopupMainFormEnabled);
    SystemManager.TryCatch(() => EditMainFormShownGoToToday.Checked = Settings.MainFormShownGoToToday);
    SystemManager.TryCatch(() => EditWindowsDoubleBufferingEnabled.Checked = Settings.WindowsDoubleBufferingEnabled);
    SystemManager.TryCatch(() => EditWeatherAppPath.Text = Settings.WeatherAppPath);
    SystemManager.TryCatch(() => EditWeatherMenuItemsEnabled.Checked = Settings.WeatherMenuItemsEnabled);
    SystemManager.TryCatch(() => EditMainFormTitleBarShowToday.Checked = Settings.MainFormTitleBarShowToday);
    SystemManager.TryCatch(() => EditMainFormTitleBarShowCelebration.Checked = Settings.MainFormTitleBarShowCelebration);
    SystemManager.TryCatch(() => EditShowLastNewInVersionAfterUpdate.Checked = Settings.ShowLastNewInVersionAfterUpdate);
    SystemManager.TryCatch(() => EditCalendarLineSpacing.Value = Settings.CalendarLineSpacing);
    SystemManager.TryCatch(() => EditConfirmShutdown.Checked = Settings.LockSessionConfirmLogOffOrMore);
    SystemManager.TryCatch(() => EditAskRegenerateIfIntervalGreater.Checked = Settings.AskRegenerateIfIntervalGreater);
    SystemManager.TryCatch(() => EditReminderShowLockoutIcon.Checked = Settings.ReminderShowLockoutIcon);
    SystemManager.TryCatch(() => EditLoadingFormHidden.Checked = Settings.LoadingFormHidden);
    SystemManager.TryCatch(() => EditNavigationWindowCloseOnShowMainForm.Checked = Settings.NavigationWindowCloseOnShowMainForm);
    SystemManager.TryCatch(() => EditNavigationWindowUseUnicodeIcons.Checked = Settings.NavigationWindowUseUnicodeIcons);
    SystemManager.TryCatch(() => EditCalendarUseHoverEffect.Checked = Settings.CalendarUseHoverEffect);
    SystemManager.TryCatch(() => EditCalendarShowSelectedBox.Checked = Settings.CalendarShowSelectedBox);
    SystemManager.TryCatch(() => EditSelectedDayBoxColorOnlyCurrent.Checked = Settings.SelectedDayBoxColorOnlyCurrent);
    SystemManager.TryCatch(() => EditCalendarShowParashah.Checked = Settings.CalendarShowParashah);
    SystemManager.TryCatch(() => EditMainFormTitleBarShowWeeklyParashah.Checked = Settings.MainFormTitleBarShowWeeklyParashah);
    SystemManager.TryCatch(() => EditParashahCaptionWithBookAndRef.Checked = Settings.ParashahCaptionWithBookAndRef);
    SystemManager.TryCatch(() => EditReminderShabatShowParashah.Checked = Settings.ReminderShabatShowParashah);
    SystemManager.TryCatch(() => EditWeeklyParashahShowAtStartup.Checked = Settings.WeeklyParashahShowAtStartup);
    SystemManager.TryCatch(() => EditWeeklyParashahShowAtNewWeek.Checked = Settings.WeeklyParashahShowAtNewWeek);
    SystemManager.TryCatch(() => EditCustomWebSearch.Text = Settings.CustomWebSearch);
    // Assigned by the form on user action
    SystemManager.TryCatch(() => EditMonthViewFontSize.Value = Settings.MonthViewFontSize);
    SystemManager.TryCatch(() => EditDateBookmarksCount.Value = Settings.DateBookmarksCount);
    SystemManager.TryCatch(() => EditWeatherOnlineUseDay.Checked = Settings.WeatherOnlineUseDay);
    // Special
    SystemManager.TryCatch(() => LabelLastStartupCheckDate.Text = Settings.CheckUpdateLastDone.ToShortDateString() + " " + Settings.CheckUpdateLastDone.ToShortTimeString());
    SystemManager.TryCatch(() => LabelLastDBOptimizeDate.Text = Settings.VacuumLastDone.ToShortDateString() + " " + Settings.VacuumLastDone.ToShortTimeString());
    //Old values
    SystemManager.TryCatch(() => OldLatitude = Settings.GPSLatitude);
    SystemManager.TryCatch(() => OldLongitude = Settings.GPSLongitude);
    SystemManager.TryCatch(() => OldShabatDay = Settings.ShabatDay);
    SystemManager.TryCatch(() => OldTimeZone = Settings.TimeZone);
    SystemManager.TryCatch(() => OldUseMoonDays = Settings.TorahEventsCountAsMoon);
    SystemManager.TryCatch(() => OldUseSod = Settings.UseSodHaibour);
    SystemManager.TryCatch(() => OldUseSimhat = Settings.UseSimhatTorahOutside);
    // Moon/Sun/Sod
    if ( Settings.UseSodHaibour )
      SelectUseSodHaibour.Checked = true;
    else
    if ( Settings.TorahEventsCountAsMoon )
      SelectOmerMoon.Checked = true;
    else
      SelectOmerSun.Checked = true;
    // Hot-key
    InitHotKeyControls();
    // System
    EditStartWithWindows.Checked = SystemManager.StartWithWindowsUserRegistry;
    EditLogEnabled.Enabled = DebugManager.Enabled;
    // Weather online provider
    switch ( Settings.WeatherOnlineProvider )
    {
      case WeatherProvider.MeteoblueDotCom:
        SelectWeatherOnlineMeteoblueDotCom.Select();
        break;
      case WeatherProvider.WeatherDotCom:
        SelectWeatherOnlineWeatherDotCom.Select();
        break;
      case WeatherProvider.MicrosoftNetworkDotCom:
        SelectWeatherOnlineMicrosoftNetworkDotCom.Select();
        break;
      default:
        SelectWeatherOnlineMeteoblueDotCom.Select();
        break;
    }
    // TrayIcon
    switch ( Settings.TrayIconClickOpen )
    {
      case TrayIconClickOpen.NavigationForm:
        SelectOpenNavigationForm.Select();
        break;
      case TrayIconClickOpen.NextCelebrationsForm:
        SelectOpenNextCelebrationsForm.Select();
        break;
      default:
        SelectOpenMainForm.Select();
        break;
    }
    // Calendar double click
    switch ( Settings.CalendarDoubleClickAction )
    {
      case CalendarDoubleClickAction.Nothing:
        SelectCalendarDoubleClickActionNothing.Select();
        break;
      case CalendarDoubleClickAction.SetActive:
        SelectCalendarDoubleClickActionSetActive.Select();
        break;
      default:
        SelectCalendarDoubleClickActionSelect.Select();
        break;
    }
    // GPS
    if ( Settings.GPSLatitude.IsNullOrEmpty() || Settings.GPSLongitude.IsNullOrEmpty() )
      ActionGetGPS_LinkClicked(null, null);
    EditTimeZone.Text = Settings.GetGPSText();
  }

}
