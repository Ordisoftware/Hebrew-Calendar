/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using Base.Hotkeys;
using Ordisoftware.Hebrew.Calendar.Properties;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class PreferencesForm
{

  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  private void SaveSettings()
  {
    Settings.TrayIconUseSpecialDayIcon = EditTrayIconUseSpecialDayIcon.Checked;
    Settings.MonthViewNoDaysBackColor = EditMonthViewNoDaysBackColor.BackColor;
    Settings.MonthViewBackColor = EditMonthViewBackColor.BackColor;
    Settings.MonthViewTextColor = EditMonthViewTextColor.BackColor;
    Settings.DateBookmarkDefaultTextColor = EditDateBookmarkDefaultTextColor.BackColor;
    Settings.DebuggerEnabled = EditDebuggerEnabled.Checked;
    Settings.VacuumAtStartup = EditVacuumAtStartup.Checked;
    Settings.VacuumAtStartupDaysInterval = (int)EditVacuumAtStartupInterval.Value;
    Settings.HebrewLettersExe = EditHebrewLettersPath.Text;
    Settings.HebrewWordsExe = EditHebrewWordsPath.Text;
    Settings.CalculatorExe = EditCalculatorPath.Text;
    Settings.AutoLockSession = EditAutoLockSession.Checked;
    Settings.AutoLockSessionTimeOut = (int)EditAutoLockSessionTimeOut.Value;
    Settings.AutoOpenExportFolder = EditAutoOpenExportFolder.Checked;
    Settings.AutoOpenExportedFile = EditAutoOpenExportedFile.Checked;
    Settings.BalloonEnabled = EditBalloon.Checked;
    Settings.BalloonOnlyIfMainFormIsHidden = EditBalloonOnlyIfMainFormIsHidden.Checked;
    Settings.BalloonAutoHide = EditBalloonAutoHide.Checked;
    Settings.BalloonLoomingDelay = (int)EditBalloonLoomingDelay.Value;
    Settings.CalendarColorFullMoon = EditCalendarColorFullMoon.BackColor;
    Settings.CalendarColorMoon = EditCalendarColorMoon.BackColor;
    Settings.CalendarColorSeason = EditCalendarColorSeason.BackColor;
    Settings.CalendarColorParashah = EditCalendarColorParashah.BackColor;
    Settings.CalendarColorTorahEvent = EditCalendarColorTorahEvent.BackColor;
    Settings.CheckUpdateAtStartup = EditCheckUpdateAtStartup.Checked;
    Settings.CurrentDayBackColor = EditCurrentDayBackColor.BackColor;
    Settings.CurrentDayForeColor = EditCurrentDayForeColor.BackColor;
    Settings.SelectedDayBoxColor = EditSelectedDayBoxColor.BackColor;
    Settings.CalendarColorActiveDay = EditCalendarColorActiveDay.BackColor;
    Settings.CalendarColorHoverEffect = EditCalendarColorHoverEffect.BackColor;
    Settings.EventColorMonth = EditEventColorMonth.BackColor;
    Settings.EventColorNext = EditEventColorNext.BackColor;
    Settings.EventColorSeason = EditEventColorSeason.BackColor;
    Settings.EventColorShabat = EditEventColorShabat.BackColor;
    Settings.EventColorTorah = EditEventColorTorah.BackColor;
    Settings.FontSize = (int)EditTextReportFontSize.Value;
    Settings.GPSLatitude = EditGPSLatitude.Text;
    Settings.GPSLongitude = EditGPSLongitude.Text;
    Settings.MonthViewChangeDayOnClick = EditMonthViewChangeDayOnClick.Checked;
    Settings.NavigateBottomColor = EditNavigateBottomColor.BackColor;
    Settings.NavigateMiddleColor = EditNavigateMiddleColor.BackColor;
    Settings.NavigateTopColor = EditNavigateTopColor.BackColor;
    Settings.RemindCelebrationEveryMinutes = EditRemindCelebrationEveryMinutes.Value;
    Settings.RemindCelebrationHoursBefore = EditRemindCelebrationHoursBefore.Value;
    Settings.ReminderCelebrationsEnabled = EditReminderCelebrationsEnabled.Checked;
    Settings.ReminderCelebrationsInterval = EditRemindCelebrationsDaysBefore.Value;
    Settings.ReminderShabatEnabled = EditReminderShabatEnabled.Checked;
    Settings.RemindShabatEveryMinutes = EditRemindShabatEveryMinutes.Value;
    Settings.RemindShabatHoursBefore = EditRemindShabatHoursBefore.Value;
    Settings.RemindShabatOnlyLight = EditRemindShabatOnlyLight.Checked;
    Settings.ShowReminderInTaskBar = EditShowReminderInTaskBar.Checked;
    Settings.StartupHide = EditStartupHide.Checked;
    Settings.TextBackground = EditTextReportBackColor.BackColor;
    Settings.TextColor = EditTextReportTextColor.BackColor;
    Settings.UseSimhatTorahOutside = EditUseSimhatTorahOutside.Checked;
    Settings.UseColors = EditUseColors.Checked;
    Settings.MoonDayTextFormat = EditMoonDayTextFormat.Text;
    Settings.WebLinksMenuEnabled = EditWebLinksMenuEnabled.Checked;
    Settings.AllowSuspendReminder = EditAllowSuspendReminder.Checked;
    Settings.CheckUpdateEveryWeekWhileRunning = EditCheckUpdateEveryWeek.Checked;
    Settings.CheckUpdateAtStartupDaysInterval = (int)EditCheckUpdateAtStartupInterval.Value;
    Settings.AutoRegenerate = EditAutoRegenerate.Checked;
    Settings.GenerateIntervalMaximum = (int)EditMaxYearsInterval.Value;
    Settings.AutoGenerateYearsInternal = int.Parse(EditAutoGenerateYearsInterval.Text);
    Settings.ReminderFormCloseOnClick = EditCloseReminderFormOnClick.Checked;
    Settings.BigCalendarWarningEnabled = EditBigCalendarWarning.Checked;
    Settings.TraceEnabled = EditLogEnabled.Checked;
    Settings.ExportFolder = EditExportFolder.Text;
    Settings.ApplicationVolume = EditVolume.Value;
    Settings.UsageStatisticsEnabled = EditUsageStatisticsEnabled.Checked;
    Settings.RestoreLastViewAtStartup = EditRestoreLastViewAtStartup.Checked;
    Settings.ShowPrintPreviewDialog = EditShowPrintDialog.Checked;
    Settings.PrintingMargin = (int)EditPrintingMargin.Value;
    Settings.PrintPageCountWarning = (int)EditPrintPageCountWarning.Value;
    Settings.PrintImageInLandscape = EditPrintImageInLandscape.Checked;
    Settings.ExportDataEnumsAsTranslations = EditExportDataEnumsAsTranslations.Checked;
    Settings.SaveImageCountWarning = (int)EditSaveImageCountWarning.Value;
    Settings.GlobalHotKeyPopupMainFormEnabled = EditGlobalHotKeyPopupMainFormEnabled.Checked;
    Settings.MainFormShownGoToToday = EditMainFormShownGoToToday.Checked;
    Settings.WindowsDoubleBufferingEnabled = EditWindowsDoubleBufferingEnabled.Checked;
    Settings.WeatherAppPath = EditWeatherAppPath.Text;
    Settings.WeatherMenuItemsEnabled = EditWeatherMenuItemsEnabled.Checked;
    Settings.ShowLastNewInVersionAfterUpdate = EditShowLastNewInVersionAfterUpdate.Checked;
    Settings.MainFormTitleBarShowToday = EditMainFormTitleBarShowToday.Checked;
    Settings.MainFormTitleBarShowCelebration = EditMainFormTitleBarShowCelebration.Checked;
    Settings.CalendarLineSpacing = (int)EditCalendarLineSpacing.Value;
    Settings.LockSessionConfirmLogOffOrMore = EditConfirmShutdown.Checked;
    Settings.AskRegenerateIfIntervalGreater = EditAskRegenerateIfIntervalGreater.Checked;
    Settings.ReminderShowLockoutIcon = EditReminderShowLockoutIcon.Checked;
    Settings.LoadingFormHidden = EditLoadingFormHidden.Checked;
    Settings.NavigationWindowCloseOnShowMainForm = EditNavigationWindowCloseOnShowMainForm.Checked;
    Settings.NavigationWindowUseUnicodeIcons = EditNavigationWindowUseUnicodeIcons.Checked;
    Settings.CalendarUseHoverEffect = EditCalendarUseHoverEffect.Checked;
    Settings.CalendarShowSelectedBox = EditCalendarShowSelectedBox.Checked;
    Settings.SelectedDayBoxColorOnlyCurrent = EditSelectedDayBoxColorOnlyCurrent.Checked;
    Settings.CalendarShowParashah = EditParashahEnabled.Checked;
    Settings.MainFormTitleBarShowWeeklyParashah = EditMainFormTitleBarShowWeeklyParashah.Checked;
    Settings.ParashahCaptionWithBookAndRef = EditParashahCaptionWithBookAndRef.Checked;
    Settings.ReminderShabatShowParashah = EditReminderShabatShowParashah.Checked;
    Settings.WeeklyParashahShowAtStartup = EditWeeklyParashahShowAtStartup.Checked;
    Settings.WeeklyParashahShowAtNewWeek = EditWeeklyParashahShowAtNewWeek.Checked;
    Settings.CustomWebSearch = EditCustomWebSearch.Text;
    Settings.UseTwoDaysForLastPessahDayOutside = EditUseTwoDaysForLastPessahDayOutside.Checked;
    Settings.BoxesRetakeFocusAfterDateClick = EditReminderBoxRetakeFocusAfterDateClick.Checked;
    Settings.CalendarHebrewDateSingleLine = EditCalendarHebrewDateSingleLine.Checked;
    Settings.CalendarHebrewDateSingleLineItalic = EditCalendarHebrewDateSingleLineItalic.Checked;
    Settings.HebrewNamesInUnicode = EditHebrewNamesInUnicode.Checked;
    Settings.HebrewInUnicodeKeepArabicNumerals = EditHebrewInUnicodeKeepArabicNumerals.Checked;
    Settings.MonthViewAlignmentDate = (StringAlignment)SelectMonthViewAlignmentDate.SelectedIndex;
    Settings.MonthViewAlignmentEphemeris = (StringAlignment)SelectMonthViewAlignmentEphemeris.SelectedIndex;
    Settings.MonthViewAlignmentCelebration = (StringAlignment)SelectMonthViewAlignmentCelebration.SelectedIndex;
    Settings.MonthViewAlignmentParashah = (StringAlignment)SelectMonthViewAlignmentParashah.SelectedIndex;
    Settings.MonthViewSeparatorForGregorianDay = EditMonthViewSeparatorForGregorianDay.Checked;
    Settings.MonthViewSeparatorForLunarDate = EditMonthViewSeparatorForLunarDate.Checked;
    Settings.MonthViewSeparatorForCelebration = EditMonthViewSeparatorForCelebration.Checked;
    Settings.MonthViewSeparatorForEphemerisSun = EditMonthViewSeparatorForEphemerisSun.Checked;
    Settings.MonthViewSeparatorForEphemerisMoon = EditMonthViewSeparatorForEphemerisMoon.Checked;
    Settings.MonthViewSeparatorForSeasonChange = EditMonthViewSeparatorForSeasonChange.Checked;
    Settings.MonthViewSeparatorForParashahName = EditMonthViewSeparatorForParashahName.Checked;
    Settings.MonthViewSeparatorForParashahReference = EditMonthViewSeparatorForParashahReference.Checked;
    Settings.MonthViewSeparatorSize = (int)EditMonthViewSeparatorSize.Value;
    Settings.EphemerisSignSun = EditEphemerisPrefixSun.Text;
    Settings.EphemerisSignMoon = EditEphemerisPrefixMoon.Text;
    Settings.MonthViewOneLuminaryOneLine = EditMonthViewOneLuminaryOneLine.Checked;
    Settings.MonthViewOneLuminaryOneLineSign = EditMonthViewOneLuminaryOneLineSign.Checked;
    Settings.EphemerisSignBeforeElseAfter = EditEphemerisSignBeforeElseAfter.Checked;
    Settings.HideLuminarySigns = EditHideLuminarySigns.Checked;
    Settings.PrintImageCenterOnPage = EditPrintImageCenterOnPage.Checked;
    Settings.OpenVerseOnlineURL = EditOpenVerseOnlineURL.Text;
    // Moon/Sun/Sod
    Settings.UseSodHaibour = SelectUseSodHaibour.Checked;
    Settings.TorahEventsCountAsMoon = SelectOmerMoon.Checked;
    // Navigation window
    NavigationForm.Instance.Relocalize();
    // Monthly view
    Settings.MonthViewFontNameLatin = SelectMonthViewLatinFontName.Text;
    Settings.MonthViewFontNameHebrew = SelectMonthViewHebrewFontName.Text;
    Settings.MonthViewFontSize = (int)EditMonthViewLatinFontSize.Value;
    Settings.MonthViewHebrewFontSize = (int)EditMonthViewHebrewFontSize.Value;
    // Shabat
    Settings.ShabatDay = (int)( (DayOfWeekItem)EditShabatDay.SelectedItem ).Day;
    // Reminder boxes location
    if ( SelectReminderBoxDesktopLocation.SelectedItem is not null )
      Settings.ReminderBoxDesktopLocation = (ControlLocation)SelectReminderBoxDesktopLocation.SelectedItem;
    Settings.ReminderCelebrationsInterval = (int)EditRemindCelebrationsDaysBefore.Value;
    // Lockout action
    Settings.LockSessionDefaultAction = (PowerAction)SelectLockSessionDefaultAction.SelectedItem;
    // Events
    for ( int index = 0; index < SelectRemindEventsBefore.Items.Count; index++ )
      SystemManager.TryCatch(() =>
      {
        string name = TorahEventRemindPrefix + ( (TorahEventItem)SelectRemindEventsBefore.Items[index] ).Event;
        Settings[name] = SelectRemindEventsBefore.GetItemChecked(index);
      });
    for ( int index = 0; index < SelectRemindEventsDay.Items.Count; index++ )
      SystemManager.TryCatch(() =>
      {
        string name = TorahEventRemindDayPrefix + ( (TorahEventItem)SelectRemindEventsDay.Items[index] ).Event;
        Settings[name] = SelectRemindEventsDay.GetItemChecked(index);
      });
    // Layout
    for ( int index = 0; index < SelectLayoutSections.Items.Count; index++ )
    {
      SystemManager.TryCatch(() =>
      {
        var item = (LayoutSectionItem)SelectLayoutSections.Items[index];
        string prefix = LayoutSectionPrefix + item.Id;
        Settings[prefix + LayoutSectionPosition] = index;
        Settings[prefix + LayoutSectionEnabled] = SelectLayoutSections.GetItemChecked(index);
      });
    }
    // HotKey
    Settings.GlobalHotKeyPopupMainFormEnabled = EditGlobalHotKeyPopupMainFormEnabled.Checked;
    Settings.GlobalHotKeyPopupMainFormKey = (int)(Keys)SelectGlobalHotKeyPopupMainFormKey.SelectedItem;
    var modifierKeys = Modifiers.None;
    if ( EditGlobalHotKeyPopupMainFormWin.Checked )
      modifierKeys |= Modifiers.Win;
    if ( EditGlobalHotKeyPopupMainFormAlt.Checked )
      modifierKeys |= Modifiers.Alt;
    if ( EditGlobalHotKeyPopupMainFormCtrl.Checked )
      modifierKeys |= Modifiers.Control;
    if ( EditGlobalHotKeyPopupMainFormShift.Checked )
      modifierKeys |= Modifiers.Shift;
    Settings.GlobalHotKeyPopupMainFormModifiers = (int)modifierKeys;
    // TrayIcon
    if ( SelectOpenMainForm.Checked )
      Settings.TrayIconClickOpen = TrayIconClickOpen.MainForm;
    else
    if ( SelectOpenNavigationForm.Checked )
      Settings.TrayIconClickOpen = TrayIconClickOpen.NavigationForm;
    else
    if ( SelectOpenNextCelebrationsForm.Checked )
      Settings.TrayIconClickOpen = TrayIconClickOpen.NextCelebrationsForm;
    // Calendar double click
    if ( SelectCalendarDoubleClickActionNothing.Checked )
      Settings.CalendarDoubleClickAction = CalendarDoubleClickAction.Nothing;
    else
    if ( SelectCalendarDoubleClickActionSetActive.Checked )
      Settings.CalendarDoubleClickAction = CalendarDoubleClickAction.SetActive;
    else
    if ( SelectCalendarDoubleClickActionSelect.Checked )
      Settings.CalendarDoubleClickAction = CalendarDoubleClickAction.Select;
    else
    if ( SelectCalendarDoubleClickActionContextMenu.Checked )
      Settings.CalendarDoubleClickAction = CalendarDoubleClickAction.ContextMenu;
    // Weather provider
    if ( SelectWeatherOnlineAccuWeatherDotCom.Checked )
      Settings.WeatherOnlineProvider = WeatherProvider.AccuWeatherDotCom;
    if ( SelectWeatherOnlineMeteoblueDotCom.Checked )
      Settings.WeatherOnlineProvider = WeatherProvider.MeteoblueDotCom;
    if ( SelectWeatherOnlineMicrosoftNetworkDotCom.Checked )
      Settings.WeatherOnlineProvider = WeatherProvider.MicrosoftNetworkDotCom;
    if ( SelectWeatherOnlineWeatherDotCom.Checked )
      Settings.WeatherOnlineProvider = WeatherProvider.WeatherDotCom;
  }

}
