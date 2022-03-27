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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using KVPDataExportTarget = KeyValuePair<DataExportTarget, string>;
using KVPImageExportTarget = KeyValuePair<ImageExportTarget, string>;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class PreferencesForm : Form
{

  #region Variables

  private bool IsReady;
  private bool InitialHotKeyEnabled;

  public int OldShabatDay { get; private set; }
  public string OldLatitude { get; private set; }
  public string OldLongitude { get; private set; }
  public string OldTimeZone { get; private set; }
  public bool OldUseMoonDays { get; private set; }
  public bool OldUseSod { get; private set; }
  public bool OldUseSimhat { get; private set; }
  public bool MustRefreshMonthView { get; private set; }

  #endregion

  #region Form Management

  /// <summary>
  /// Default constructor.
  /// </summary>
  private PreferencesForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    ActionMonthViewThemeDark.Visible = Globals.IsDevExecutable; // TODO remove when dark theme will be ready
    this.InitDropDowns();
    if ( !Globals.IsDebugExecutable ) // TODO remove when sod will be ready
      SelectUseSodHaibour.Enabled = false;
  }

  /// <summary>
  /// Event handler. Called by PreferencesForm for load events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void PreferencesForm_Load(object sender, EventArgs e)
  {
    this.CenterToMainFormElseScreen();
    DoFormLoad();
  }

  /// <summary>
  /// Event handler. Called by PreferencesForm for shown events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void PreferencesForm_Shown(object sender, EventArgs e)
  {
    DoFormShow();
  }

  /// <summary>
  /// Event handler. Called by PreferencesForm for closing events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing ) return;
    DoFormClosing(sender, e);
  }

  /// <summary>
  /// Event handler. Called by PreferencesForm for closed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    IsReady = false;
  }

  #endregion

  #region Export and import

  private void ActionExportSettings_Click(object sender, EventArgs e)
  {
    DoExportSettings();
  }

  private void ActionImportSettings_Click(object sender, EventArgs e)
  {
    DoImportSettings();
  }

  private void ActionResetSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    DoResetSettings();
  }

  #endregion

  #region Help and Info

  private void ActionCountAsMoonHelp_Click(object sender, EventArgs e)
  {
    MainForm.Instance.ActionShowCelebrationsNotice_Click(null, null);
  }

  private void ActionParashahHelp_Click(object sender, EventArgs e)
  {
    MainForm.Instance.ActionShowParashahNotice_Click(null, null);
  }

  private void ActionAstronomyInfo_Click(object sender, EventArgs e)
  {
    MainForm.Instance.ActionShowMonthsAndDaysNotice_Click(null, null);
  }

  private void ActionPersonalShabatHelp_Click(object sender, EventArgs e)
  {
    MainForm.Instance.ActionShowShabatNotice_Click(null, null);
  }

  private void ActionHotKeyInfo_Click(object sender, EventArgs e)
  {
    DisplayManager.ShowInformation(AppTranslations.NoticeHotKey.GetLang());
  }

  private void ActionAutoGenerateHelp_Click(object sender, EventArgs e)
  {
    DisplayManager.ShowInformation(AppTranslations.NoticeAutoGenerateInterval.GetLang());
  }

  private void ActionMoonDayTextFormatHelp_Click(object sender, EventArgs e)
  {
    DisplayManager.ShowInformation(AppTranslations.NoticeMoonDayTextFormat.GetLang());
  }

  #endregion

  #region Language

  private void ActionSelectLangEN_Click(object sender, EventArgs e)
  {
    if ( Settings.LanguageSelected == Language.EN ) return;
    Settings.LanguageSelected = Language.EN;
    Program.UpdateLocalization();
    UpdateLanguagesButtons();
    LanguageChanged = true;
    Close();
  }

  private void ActionSelectLangFR_Click(object sender, EventArgs e)
  {
    if ( Settings.LanguageSelected == Language.FR ) return;
    Settings.LanguageSelected = Language.FR;
    Program.UpdateLocalization();
    UpdateLanguagesButtons();
    LanguageChanged = true;
    Close();
  }

  private void UpdateLanguagesButtons()
  {
    if ( Settings.LanguageSelected == Language.EN )
    {
      ActionSelectLangEN.BackColor = SystemColors.ControlLightLight;
      ActionSelectLangFR.BackColor = SystemColors.Control;
    }
    if ( Settings.LanguageSelected == Language.FR )
    {
      ActionSelectLangFR.BackColor = SystemColors.ControlLightLight;
      ActionSelectLangEN.BackColor = SystemColors.Control;
    }
  }

  #endregion

  #region Application

  private void EditDebuggerEnabled_CheckedChanged(object sender, EventArgs e)
  {
    if ( !EditDebuggerEnabled.Checked )
      EditLogEnabled.Checked = false;
    DebugManager.Enabled = EditDebuggerEnabled.Checked;
    EditLogEnabled.Enabled = DebugManager.Enabled;
  }

  private void EditLogEnabled_CheckedChanged(object sender, EventArgs e)
  {
    DebugManager.TraceEnabled = EditLogEnabled.Checked;
    CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
    StatisticsForm.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
  }

  private void EditUsageStatisticsEnabled_CheckedChanged(object sender, EventArgs e)
  {
    CommonMenusControl.Instance.ActionViewStats.Enabled = EditUsageStatisticsEnabled.Checked;
    AboutBox.Instance.ActionViewStats.Enabled = EditUsageStatisticsEnabled.Checked;
    StatisticsForm.Instance.Timer.Enabled = EditUsageStatisticsEnabled.Checked;
    if ( !EditUsageStatisticsEnabled.Checked )
      StatisticsForm.Instance.Close();
  }

  private void ActionManageBookmarks_Click(object sender, EventArgs e)
  {
    if ( ManageBookmarksForm.Run() )
      DatesDiffCalculatorForm.Instance.LoadMenuBookmarks(this);
  }

  private void EditDateBookmarksCount_ValueChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    Settings.DateBookmarksCount = (int)EditDateBookmarksCount.Value;
    Program.DateBookmarks.Resize(Settings.DateBookmarksCount);
    DatesDiffCalculatorForm.Instance.LoadMenuBookmarks(this);
  }

  private void EditVolume_ValueChanged(object sender, EventArgs e)
  {
    MediaMixer.SetApplicationVolume(Globals.ProcessId, EditVolume.Value);
    LabelVolumeValue.Text = $"{EditVolume.Value}%";
    if ( !IsReady ) return;
    Settings.ApplicationVolume = EditVolume.Value;
    SystemManager.TryCatch(Settings.Store);
    DisplayManager.DoSound(Globals.ClipboardSoundFilePath);
  }

  private void EditLoadingFormHidden_CheckedChanged(object sender, EventArgs e)
  {
    LoadingForm.Instance.Hidden = EditLoadingFormHidden.Checked;
  }

  #endregion

  #region Startup

  private void EditStartWithWindows_CheckedChanged(object sender, EventArgs e)
  {
    SystemManager.StartWithWindowsUserRegistry = EditStartWithWindows.Checked;
  }

  private void EditCheckUpdateAtStartup_CheckedChanged(object sender, EventArgs e)
  {
    EditCheckUpdateEveryWeek.Enabled = EditCheckUpdateAtStartup.Checked;
    EditCheckUpdateAtStartupInterval.Enabled = EditCheckUpdateAtStartup.Checked;
  }

  private void EditVacuumAtStartup_CheckedChanged(object sender, EventArgs e)
  {
    EditVacuumAtStartupInterval.Enabled = EditVacuumAtStartup.Checked;
  }

  #endregion

  #region Navigation Window Colors

  private void DoChangePanelColorNavigation(Panel panelSetting, Panel panelForm)
  {
    NavigationForm.Instance.ShowPopup();
    DialogColor.Color = panelSetting.BackColor;
    if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
    panelSetting.BackColor = DialogColor.Color;
    panelForm.BackColor = panelSetting.BackColor;
  }

  private void PanelTopColor_MouseClick(object sender, MouseEventArgs e)
  {
    DoChangePanelColorNavigation(EditNavigateTopColor, NavigationForm.Instance.PanelTop);
  }

  private void PanelMiddleColor_MouseClick(object sender, MouseEventArgs e)
  {
    DoChangePanelColorNavigation(EditNavigateMiddleColor, NavigationForm.Instance.PanelMiddle);
  }

  private void PanelBottomColor_MouseClick(object sender, MouseEventArgs e)
  {
    DoChangePanelColorNavigation(EditNavigateBottomColor, NavigationForm.Instance.PanelBottom);
  }

  private void DoNavigationUseColors(Color colorTop, Color colorMiddle, Color colorBottom)
  {
    EditNavigateTopColor.BackColor = colorTop;
    EditNavigateMiddleColor.BackColor = colorMiddle;
    EditNavigateBottomColor.BackColor = colorBottom;
    NavigationForm.Instance.SetColors(colorTop, colorMiddle, colorBottom);
    NavigationForm.Instance.ShowPopup();
  }

  private void ActionUseSystemColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    DoNavigationUseColors(SystemColors.Control, SystemColors.Control, SystemColors.Control);
  }

  private void ActionUseBlackAndWhiteColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    DoNavigationUseColors(Color.White, Color.Gainsboro, Color.White);
  }

  private void ActionUseDefaultColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    DoNavigationUseColors(Color.LemonChiffon, Color.AliceBlue, Color.Honeydew);
  }

  #endregion

  #region Generate

  private void PredefinedYearsItem_Click(object sender, EventArgs e)
  {
    var value = ( (YearsIntervalItem)( sender as ToolStripMenuItem )?.Tag ).OriginalValue;
    EditAutoGenerateYearsInterval.Text = value.ToString();
  }

  private void EditMaxYearsInterval_ValueChanged(object sender, EventArgs e)
  {
    YearsIntervalItem.InitializeMenu(MenuPredefinedYears,
                                     Program.AutoGenerateYearsIntervalMax,
                                     PredefinedYearsItem_Click);
  }

  private void EditAutoRegenerate_CheckedChanged(object sender, EventArgs e)
  {
    bool isChecked = EditAutoRegenerate.Checked;
    EditAutoGenerateYearsInterval.Enabled = isChecked;
    SelectAutoGenerateYearsInterval.Enabled = isChecked;
    ActionAutoGenerateHelp.Enabled = isChecked;
    EditAskRegenerateIfIntervalGreater.Enabled = isChecked;
  }

  private void SelectAutoGenerateYearsInterval_Click(object sender, EventArgs e)
  {
    MenuPredefinedYears.Show(SelectAutoGenerateYearsInterval, new Point(0, SelectAutoGenerateYearsInterval.Height));
  }

  private void ActionGetGPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if ( !SelectCityForm.Run(e is not null) ) return;
    EditGPSLatitude.Text = Settings.GPSLatitude;
    EditGPSLongitude.Text = Settings.GPSLongitude;
    EditTimeZone.Text = Settings.GetGPSText();
    MainForm.Instance.InitializeCurrentTimeZone();
  }

  #endregion

  #region Reminder

  private void SelectReminderBoxDesktopLocation_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = SysTranslations.ControlLocationText.GetLang((ControlLocation)e.Value);
  }

  private void SelectLockSessionDefaultAction_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = SysTranslations.PowerActionText.GetLang((PowerAction)e.Value);
  }

  private void EditRemindAutoLock_CheckedChanged(object sender, EventArgs e)
  {
    LabelRemindAutoLockTimeOut.Enabled = EditAutoLockSession.Checked;
    EditAutoLockSessionTimeOut.Enabled = EditAutoLockSession.Checked;
  }

  private void LabelSelectReminderSound_Click(object sender, EventArgs e)
  {
    SelectSoundForm.Run();
  }

  #endregion

  #region Shabat

  private void EditRemindShabat_Changed(object sender, EventArgs e)
  {
    EditRemindShabatOnlyLight.Enabled = EditReminderShabatEnabled.Checked;
    LabelRemindShabatHoursBefore.Enabled = EditReminderShabatEnabled.Checked;
    EditRemindShabatHoursBefore.Enabled = EditReminderShabatEnabled.Checked;
    LabelRemindShabatEveryMinutes.Enabled = EditReminderShabatEnabled.Checked;
    EditRemindShabatEveryMinutes.Enabled = EditReminderShabatEnabled.Checked;
  }

  private void ActionUsePersonalShabat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    var date = DateTime.Today; // TODO use saved birthday
    if ( !SelectDayForm.Run(AppTranslations.SelectBirthday.GetLang(), ref date) ) return;
    if ( !SelectBirthTimeForm.Run(out var time) ) return;
    if ( time >= new TimeSpan(0, 0, 0) && time < CalendarDates.Instance[date].Ephemerisis.Sunset )
      date = date.AddDays(-1);
    Settings.ShabatDay = (int)date.DayOfWeek;
    foreach ( DayOfWeekItem day in EditShabatDay.Items )
      if ( (DayOfWeek)Settings.ShabatDay == day.Day )
        EditShabatDay.SelectedItem = day;
  }

  #endregion

  #region Celebrations

  private void EditRemindCelebrations_Changed(object sender, EventArgs e)
  {
    LabelRemindCelebrationDaysBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
    EditRemindCelebrationsDaysBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
    SelectRemindEventsBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
    SelectRemindEventsDay.Enabled = EditReminderCelebrationsEnabled.Checked;
    LabelRemindCelebrationHoursBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
    EditRemindCelebrationHoursBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
    LabelRemindCelebrationEveryMinutes.Enabled = EditReminderCelebrationsEnabled.Checked;
    EditRemindCelebrationEveryMinutes.Enabled = EditReminderCelebrationsEnabled.Checked;
  }

  private void SetChecked(CheckedListBox control, bool state)
  {
    for ( int i = 0; i < control.Items.Count; i++ )
      control.SetItemChecked(i, state);
  }

  private void ActionRemindEventsBeforeSelectAll_Click(object sender, EventArgs e)
  {
    SetChecked(SelectRemindEventsBefore, true);
  }

  private void ActionRemindEventsBeforeSelectNone_Click(object sender, EventArgs e)
  {
    SetChecked(SelectRemindEventsBefore, false);
  }

  private void ActionRemindEventsBeforeReset_Click(object sender, EventArgs e)
  {
    SetChecked(SelectRemindEventsBefore, true);
    SelectRemindEventsBefore.SetItemChecked(0, false);
  }

  private void ActionEventsDaySelectAll_Click(object sender, EventArgs e)
  {
    SetChecked(SelectRemindEventsDay, true);
  }

  private void ActionEventsDaySelectNone_Click(object sender, EventArgs e)
  {
    SetChecked(SelectRemindEventsDay, false);
  }

  private void ActionEventsDayReset_Click(object sender, EventArgs e)
  {
    SetChecked(SelectRemindEventsDay, true);
    SelectRemindEventsDay.SetItemChecked(0, false);
  }

  #endregion

  #region Parashah

  private void EditCalendarShowParashah_Changed(object sender, EventArgs e)
  {
    if ( IsReady ) MustRefreshMonthView = true;
    EditMainFormTitleBarShowWeeklyParashah.Enabled = EditCalendarShowParashah.Checked;
    EditParashahCaptionWithBookAndRef.Enabled = EditCalendarShowParashah.Checked;
    EditReminderShabatShowParashah.Enabled = EditCalendarShowParashah.Checked;
    EditWeeklyParashahShowAtStartup.Enabled = EditCalendarShowParashah.Checked;
    EditWeeklyParashahShowAtNewWeek.Enabled = EditCalendarShowParashah.Checked;
  }

  #endregion

  #region Text Report

  private void EditTextReportFontName_Changed(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    Settings.FontName = EditTextReportFontName.Text;
    Settings.FontSize = (int)EditTextReportFontSize.Value;
    MainForm.Instance.UpdateTextCalendar();
  }

  private void TextReportForeColor_Click(object sender, EventArgs e)
  {
    DialogColor.Color = EditTextReportTextColor.BackColor;
    if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
    EditTextReportTextColor.BackColor = DialogColor.Color;
    MainForm.Instance.CalendarText.ForeColor = DialogColor.Color;
  }

  private void TextReportBackColor_Click(object sender, EventArgs e)
  {
    DialogColor.Color = EditTextReportBackColor.BackColor;
    if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
    EditTextReportBackColor.BackColor = DialogColor.Color;
    MainForm.Instance.CalendarText.BackColor = DialogColor.Color;
  }

  #endregion

  #region Month View

  private void MenuSelectMoonDayTextFormat_Click(object sender, EventArgs e)
  {
    EditMoonDayTextFormat.Text = (string)( sender as ToolStripMenuItem )?.Tag;
  }

  private void EditMonthViewOption_Changed(object sender, EventArgs e)
  {
    if ( IsReady ) MustRefreshMonthView = true;
  }

  private void ActionMoonDayTextFormatReset_Click(object sender, EventArgs e)
  {
    MenuSelectMoonDayTextFormat.Show(ActionMoonDayTextFormatReset,
                                     new Point(0, ActionMoonDayTextFormatReset.Height));
  }

  private void EditUseColors_CheckedChanged(object sender, EventArgs e)
  {
    if ( IsReady ) MustRefreshMonthView = true;
    PanelCalendarColors.Enabled = EditUseColors.Checked;
    EditSelectedDayBoxColorOnlyCurrent.Enabled = EditUseColors.Checked;
  }

  private void EditCalendarColor_Click(object sender, EventArgs e)
  {
    var panel = (Panel)sender;
    DialogColor.Color = panel.BackColor;
    if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
    panel.BackColor = DialogColor.Color;
    MustRefreshMonthView = true;
  }

  private void ActionMonthViewThemeLight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    SetThemeLight();
  }

  private void ActionMonthViewThemeDark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    SetThemeDark();
  }

  private void ActionOpenTheme_Click(object sender, EventArgs e)
  {
    OpenTheme();
  }

  private void ActionSaveTheme_Click(object sender, EventArgs e)
  {
    SaveTheme();
  }

  #endregion

  #region Export Save, Copy and Print

  private void EditExportDataEnumsAsTranslations_CheckedChanged(object sender, EventArgs e)
  {
    MainForm.Instance.EditExportDataEnumsAsTranslations.Checked = EditExportDataEnumsAsTranslations.Checked;
  }

  private void EditAutoOpenExportFolder_CheckedChanged(object sender, EventArgs e)
  {
    if ( EditAutoOpenExportedFile.Checked && EditAutoOpenExportFolder.Checked )
      EditAutoOpenExportedFile.Checked = false;
  }

  private void EditAutoOpenExportedFile_CheckedChanged(object sender, EventArgs e)
  {
    if ( EditAutoOpenExportedFile.Checked && EditAutoOpenExportFolder.Checked )
      EditAutoOpenExportFolder.Checked = false;
  }

  private void EditDataExportFileFormat_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = ( (KVPDataExportTarget)e.ListItem ).Key.ToString();
  }

  private void EditDataExportFileFormat_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    Settings.ExportDataPreferredTarget = ( (KVPDataExportTarget)EditDataExportFileFormat.SelectedItem ).Key;
  }

  private void EditImageExportFileFormat_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = ( (KVPImageExportTarget)e.ListItem ).Key.ToString();
  }

  private void EditImageExportFileFormat_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    Settings.ExportImagePreferredTarget = ( (KVPImageExportTarget)EditImageExportFileFormat.SelectedItem ).Key;
  }

  #endregion

  #region Paths

  private void ActionSelectExportFolder_Click(object sender, EventArgs e)
  {
    SystemManager.TryCatch(() => FolderBrowserDialog.SelectedPath = Settings.GetExportDirectory());
    if ( FolderBrowserDialog.ShowDialog() == DialogResult.OK )
      EditExportFolder.Text = FolderBrowserDialog.SelectedPath;
  }

  private void DoActionSelectPath(OpenFileDialog dialog, TextBoxEx edit)
  {
    SystemManager.TryCatch(() => dialog.InitialDirectory = Path.GetDirectoryName(edit.Text));
    SystemManager.TryCatch(() => dialog.FileName = Path.GetFileName(edit.Text));
    if ( OpenExeFileDialog.ShowDialog() == DialogResult.OK )
      edit.Text = dialog.FileName;
  }

  private void ActionSelectCalculatorPath_Click(object sender, EventArgs e)
  {
    DoActionSelectPath(OpenExeFileDialog, EditCalculatorPath);
  }

  private void ActionSelectWeatherAppPath_Click(object sender, EventArgs e)
  {
    DoActionSelectPath(OpenExeFileDialog, EditWeatherAppPath);
  }

  private void ActionSelectHebrewLettersPath_Click(object sender, EventArgs e)
  {
    DoActionSelectPath(OpenExeFileDialog, EditHebrewLettersPath);
  }

  private void ActionSelectHebrewWordsPath_Click(object sender, EventArgs e)
  {
    DoActionSelectPath(OpenExeFileDialog, EditHebrewWordsPath);
  }

  private void ActionResetExportFolder_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditExportFolder.Text = (string)Settings.Properties[nameof(Settings.ExportFolder)].DefaultValue;
  }

  private void ActionResetCalculatorPath_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditCalculatorPath.Text = (string)Settings.Properties[nameof(Settings.CalculatorExe)].DefaultValue;
  }

  private void ActionResetWeatherAppPath_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditWeatherAppPath.Text = (string)Settings.Properties[nameof(Settings.WeatherAppPath)].DefaultValue;
  }

  private void ActionResetHebrewLettersPath_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditHebrewLettersPath.Text = (string)Settings.Properties[nameof(Settings.HebrewLettersExe)].DefaultValue;
  }

  private void ActionResetHebrewWordsPath_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditHebrewWordsPath.Text = (string)Settings.Properties[nameof(Settings.HebrewWordsExe)].DefaultValue;
  }

  private void ActionResetCustomWebSearch_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditCustomWebSearch.Text = (string)Settings.Properties[nameof(Settings.CustomWebSearch)].DefaultValue;
  }

  private void SelectWeatherOnlineMeteoblueDotCom_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineProvider = WeatherProvider.MeteoblueDotCom;
    EditWeatherOnlineUseDay.Enabled = true;
  }

  private void SelectWeatherOnlineWeatherDotCom_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineProvider = WeatherProvider.WeatherDotCom;
    EditWeatherOnlineUseDay.Enabled = true;
  }

  private void SelectWeatherOnlineMicrosoftNetworkDotCom_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineProvider = WeatherProvider.MicrosoftNetworkDotCom;
    EditWeatherOnlineUseDay.Enabled = false;
  }

  private void EditWeatherOnlineUseDay_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineUseDay = EditWeatherOnlineUseDay.Checked;
  }

  private void ActionWeatherOnlineTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    MainForm.Instance.ActionOnlineWeather.PerformClick();
  }

  #endregion

  #region Tray Icon and Global HotKey

  private void SelectOpenNavigationForm_CheckedChanged(object sender, EventArgs e)
  {
    PanelBalloon.Enabled = !SelectOpenNavigationForm.Checked;
  }

  private void EditBalloon_CheckedChanged(object sender, EventArgs e)
  {
    EditBalloonLoomingDelay.Enabled = EditBalloon.Checked;
    EditBalloonAutoHide.Enabled = EditBalloon.Checked;
    EditBalloonOnlyIfMainFormIsHidden.Enabled = EditBalloon.Checked;
  }

  private void EditGlobalHotKeyPopupMainFormEnabled_CheckedChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    InitialHotKeyEnabled = EditGlobalHotKeyPopupMainFormEnabled.Checked;
    CheckHotKeyCombination(null);
  }

  private void SelectGlobalHotKeyPopupMainFormKey_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    CheckHotKeyCombination(() => Globals.BringToFrontApplicationHotKey.Key = (Keys)SelectGlobalHotKeyPopupMainFormKey.SelectedItem);
  }

  private void EditGlobalHotKeyPopupMainFormShift_CheckedChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    if ( !CheckHotKeyModifiersChanged(sender) ) return;
    CheckHotKeyCombination(() => Globals.BringToFrontApplicationHotKey.Shift = EditGlobalHotKeyPopupMainFormShift.Checked);
  }

  private void EditGlobalHotKeyPopupMainFormCtrl_CheckedChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    if ( !CheckHotKeyModifiersChanged(sender) ) return;
    CheckHotKeyCombination(() => Globals.BringToFrontApplicationHotKey.Control = EditGlobalHotKeyPopupMainFormCtrl.Checked);
  }

  private void EditGlobalHotKeyPopupMainFormAlt_CheckedChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    if ( !CheckHotKeyModifiersChanged(sender) ) return;
    CheckHotKeyCombination(() => Globals.BringToFrontApplicationHotKey.Alt = EditGlobalHotKeyPopupMainFormAlt.Checked);
  }

  private void EditGlobalHotKeyPopupMainFormWin_CheckedChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    if ( !CheckHotKeyModifiersChanged(sender) ) return;
    CheckHotKeyCombination(() => Globals.BringToFrontApplicationHotKey.Windows = EditGlobalHotKeyPopupMainFormWin.Checked);
  }

  private void ActionHotKeyReset_Click(object sender, EventArgs e)
  {
    Settings.GlobalHotKeyPopupMainFormKey = (int)MainForm.DefaultHotKeyKey;
    Settings.GlobalHotKeyPopupMainFormModifiers = (int)MainForm.DefaultHotKeyModifiers;
    InitHotKeyControls();
  }

  private bool CheckHotKeyModifiersChanged(object sender)
  {
    var checkbox = (CheckBox)sender;
    if ( checkbox.Checked ) return true;
    if ( PanelHotKey.Controls.OfType<CheckBox>().Any(c => c != checkbox && c.Checked) )
      return true;
    checkbox.Checked = true;
    return false;
  }

  private void EditWeatherMenuItemsEnabled_CheckedChanged(object sender, EventArgs e)
  {
    bool enabled = EditWeatherMenuItemsEnabled.Checked;
    MainForm.Instance.ActionLocalWeather.Visible = enabled;
    MainForm.Instance.ActionOnlineWeather.Visible = enabled;
    MainForm.Instance.SeparatorMenuWeather.Visible = enabled;
    MainForm.Instance.ActionLocalWeather.Enabled = enabled;
    MainForm.Instance.ActionOnlineWeather.Enabled = enabled;
    MainForm.Instance.SeparatorMenuWeather.Enabled = enabled;
    PanelWeatherOnline.Enabled = enabled;
  }

  #endregion

}
