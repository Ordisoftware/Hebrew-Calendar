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

using KVPDataExportTarget = KeyValuePair<DataExportTarget, string>;
using KVPImageExportTarget = KeyValuePair<ImageExportTarget, string>;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
sealed partial class PreferencesForm : Form
{

  #region Variables

  private bool IsReady;
  private bool InitialHotKeyEnabled;

  public int OldShabatDay { get; private set; }
  public string OldLatitude { get; private set; }
  public string OldLongitude { get; private set; }
  public string OldTimeZone { get; private set; }
  public bool OldHebrewNamesInUnicode { get; private set; }
  public bool OldUseMoonDays { get; private set; }
  public bool OldUseSod { get; private set; }
  public bool OldUseSimhat { get; private set; }
  public bool OldUseTwoDaysForLastPessahDayOutside { get; private set; }
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
    ActionMonthViewThemeDark.Visible = SystemManager.CommandLineOptions.IsPreviewEnabled; // TODO when ready : remove
    this.InitDropDowns();
    if ( !SystemManager.CommandLineOptions.IsPreviewEnabled ) // TODO when ready : remove
      SelectUseSodHaibour.Enabled = false;
    foreach ( var item in HebrewGlobals.WebProvidersBible.Items )
      if ( item.Name == "-" )
        MenuSelectOnlineVerseProviderURL.Items.Add(new ToolStripSeparator());
      else
        MenuSelectOnlineVerseProviderURL.Items.Add(item.CreateMenuItem(openVerseOnline));
    //
    void openVerseOnline(object sender, EventArgs e)
      => EditOpenVerseOnlineURL.Text = (string)( (ToolStripMenuItem)sender ).Tag;
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

  private void SetMustRefreshEnabled(object sender, EventArgs e)
  {
    if ( IsReady ) MustRefreshMonthView = true;
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
    AppTranslations.ShowCelebrationsNotice();
  }

  private void ActionParashahHelp_Click(object sender, EventArgs e)
  {
    AppTranslations.ShowParashahNotice();
  }

  private void ActionAstronomyInfo_Click(object sender, EventArgs e)
  {
    AppTranslations.ShowMonthsAndDaysNotice();
  }

  private void ActionPersonalShabatHelp_Click(object sender, EventArgs e)
  {
    AppTranslations.ShowShabatNotice();
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

  private void EditWindowsDoubleBufferingEnabled_CheckedChanged(object sender, EventArgs e)
  {
    DisplayManager.DoubleBufferingEnabled = Settings.WindowsDoubleBufferingEnabled;
  }

  //TODO delete 
  //private void ActionManageBookmarks_Click(object sender, EventArgs e)
  //{
  //  if ( !ManageBookmarksForm.Run() ) return;
  //  int countBookmarks = Math.Max(Program.DateBookmarks.MinListSize, DateBookmarksCountInterval.Item1);
  //  if ( countBookmarks == 0 ) countBookmarks = DateBookmarksCountInterval.Item1;
  //  DatesDiffCalculatorForm.Instance.LoadMenuBookmarks(this);
  //  EditDateBookmarksCount.Minimum = countBookmarks;
  //  EditDateBookmarksCount.Value = Settings.DateBookmarksCount;
  //  SetNumericLabelText(EditDateBookmarksCount, LabelDateBookmarksCountIntervalInfo);
  //}

  private void EditDateBookmarksCount_ValueChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    Settings.DateBookmarksCount = (int)EditDateBookmarksCount.Value;
    DatesDifferenceForm.Instance.LoadMenuBookmarks(this);
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

  private void EditHebrewNamesInUnicode_CheckedChanged(object sender, EventArgs e)
  {
    EditHebrewInUnicodeKeepArabicNumerals.Enabled = EditHebrewNamesInUnicode.Checked;
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
    var value = ( (YearsIntervalItem)( sender as ToolStripMenuItem )?.Tag )?.OriginalValue ?? -1;
    EditAutoGenerateYearsInterval.Text = value.ToString();
  }

  private void EditMaxYearsInterval_ValueChanged(object sender, EventArgs e)
  {
    YearsIntervalItem.InitializeMenu(MenuPredefinedYears, PredefinedYearsItem_Click);
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
    if ( e is null && SelectCityForm.ConfigLoaded )
    {
      LanguageChanged = true;
      DoReset = true;
      Reseted = true;
      Close();
    }
  }

  private void SelectOmerMoon_CheckedChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    if ( !SelectOmerMoon.Checked ) return;
    if ( SunChecked && !MoonChecked )
    {
      SunChecked = false;
      MoonChecked = true;
    }
  }

  private void SelectOmerSun_CheckedChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    if ( !SelectOmerSun.Checked ) return;
    if ( !SunChecked && MoonChecked )
    {
      SunChecked = true;
      MoonChecked = false;
    }
  }

  private void SelectUseSodHaibour_CheckedChanged(object sender, EventArgs e)
  {
    if ( !IsReady ) return;
    if ( !SelectUseSodHaibour.Checked ) return;
    if ( !SunChecked && MoonChecked )
    {
      SunChecked = true;
      MoonChecked = false;
    }
  }

  private void ActionSwitchToMonthViewLayout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    TabControlMain.SelectedTab = TabPageMonthView;
    TabControlMonthView.SelectedTab = TabPageMonthViewLayout;
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
    if ( time >= new TimeSpan(0, 0, 0) && time < CalendarDates.Instance[date].Ephemeris.Sunset )
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
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToSetAllOptions.GetLang()) )
      SetChecked(SelectRemindEventsBefore, true);
  }

  private void ActionRemindEventsBeforeSelectNone_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToUnsetAllOptions.GetLang()) )
      SetChecked(SelectRemindEventsBefore, false);
  }

  private void ActionRemindEventsBeforeReset_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      for ( int index = 0; index < SelectRemindEventsBefore.Items.Count; index++ )
        SystemManager.TryCatch(() =>
        {
          string name = TorahEventRemindPrefix + ( (TorahEventItem)SelectRemindEventsBefore.Items[index] ).Event;
          bool state = Convert.ToBoolean((string)Settings.Properties[name].DefaultValue);
          SelectRemindEventsBefore.SetItemChecked(index, state);
        });
  }

  private void ActionEventsDaySelectAll_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToSetAllOptions.GetLang()) )
      SetChecked(SelectRemindEventsDay, true);
  }

  private void ActionEventsDaySelectNone_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToUnsetAllOptions.GetLang()) )
      SetChecked(SelectRemindEventsDay, false);
  }

  private void ActionEventsDayReset_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      for ( int index = 0; index < SelectRemindEventsDay.Items.Count; index++ )
        SystemManager.TryCatch(() =>
        {
          string name = TorahEventRemindDayPrefix + ( (TorahEventItem)SelectRemindEventsDay.Items[index] ).Event;
          bool state = Convert.ToBoolean((string)Settings.Properties[name].DefaultValue);
          SelectRemindEventsDay.SetItemChecked(index, state);
        });
  }

  #endregion

  #region Parashah

  private void EditParashahEnabled_Changed(object sender, EventArgs e)
  {
    EditMainFormTitleBarShowWeeklyParashah.Enabled = EditParashahEnabled.Checked;
    EditParashahCaptionWithBookAndRef.Enabled = EditParashahEnabled.Checked;
    EditReminderShabatShowParashah.Enabled = EditParashahEnabled.Checked;
    EditWeeklyParashahShowAtStartup.Enabled = EditParashahEnabled.Checked;
    EditWeeklyParashahShowAtNewWeek.Enabled = EditParashahEnabled.Checked;
    if ( !IsReady ) return;
    SunChecked = true;
    MoonChecked = false;
    ParashahNameChecked = EditParashahEnabled.Checked;
    if ( !EditParashahEnabled.Checked )
      ParashahRefChecked = false;
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
    MainForm.Instance.TextReport.ForeColor = DialogColor.Color;
  }

  private void TextReportBackColor_Click(object sender, EventArgs e)
  {
    DialogColor.Color = EditTextReportBackColor.BackColor;
    if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
    EditTextReportBackColor.BackColor = DialogColor.Color;
    MainForm.Instance.TextReport.BackColor = DialogColor.Color;
  }

  #endregion

  #region Colors

  private void EditUseColors_CheckedChanged(object sender, EventArgs e)
  {
    SetMustRefreshEnabled(null, null);
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

  #region Month View

  private void ActionSwitchToOmerSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    TabControlMain.SelectedTab = TabPageGeneration;
  }

  private void ActionSwitchToParashahSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    TabControlMain.SelectedTab = TabPageParashah;
  }

  private void MenuSelectMoonDayTextFormat_Click(object sender, EventArgs e)
  {
    EditMoonDayTextFormat.Text = (string)( sender as ToolStripMenuItem )?.Tag;
  }

  private void ActionMoonDayTextFormatReset_Click(object sender, EventArgs e)
  {
    MenuSelectMoonDayTextFormat.Show(ActionMoonDayTextFormatReset,
                                     new Point(0, ActionMoonDayTextFormatReset.Height));
  }

  private void SelectMonthViewFontNameLatin_SelectedIndexChanged(object sender, EventArgs e)
  {
    SetMustRefreshEnabled(null, null);
    LabelMonthViewFontNameLatinSample.Font = new Font(SelectMonthViewLatinFontName.Text,
                                                      (float)EditMonthViewLatinFontSize.Value);
  }

  private void SelectMonthViewFontNameHebrew_SelectedIndexChanged(object sender, EventArgs e)
  {
    SetMustRefreshEnabled(null, null);
    LabelMonthViewFontNameHebrewSample.Font = new Font(SelectMonthViewHebrewFontName.Text,
                                                       (float)EditMonthViewHebrewFontSize.Value);
  }

  private void ActionSeparatorsCheckAll_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToSetAllOptions.GetLang()) )
      SetAllSeparators(true);
  }

  private void ActionSeparatorsUncheckAll_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToUnsetAllOptions.GetLang()) )
      SetAllSeparators(false);
  }

  void SetAllSeparators(bool enabled)
  {
    EditMonthViewSeparatorForCelebration.Checked = enabled;
    EditMonthViewSeparatorForEphemerisMoon.Checked = enabled;
    EditMonthViewSeparatorForEphemerisSun.Checked = enabled;
    EditMonthViewSeparatorForLunarDate.Checked = enabled;
    EditMonthViewSeparatorForParashahName.Checked = enabled;
    EditMonthViewSeparatorForParashahReference.Checked = enabled;
    EditMonthViewSeparatorForSeasonChange.Checked = enabled;
  }

  private void ActionSetAllAlignmentsLeft_Click(object sender, EventArgs e)
  {
    SetAllAlignments(0);
  }

  private void ActionSetAllAlignmentsCenter_Click(object sender, EventArgs e)
  {
    SetAllAlignments(1);
  }

  private void ActionSetAllAlignmentsRight_Click(object sender, EventArgs e)
  {
    SetAllAlignments(2);
  }

  void SetAllAlignments(int index)
  {
    SelectMonthViewAlignmentDate.SelectedIndex = index;
    SelectMonthViewAlignmentEphemeris.SelectedIndex = index;
    SelectMonthViewAlignmentCelebration.SelectedIndex = index;
    SelectMonthViewAlignmentParashah.SelectedIndex = index;
  }

  private sealed class LuminaryEventArgs : EventArgs { public bool OneLuminary { get; set; } }

  private void SelectLayoutSections_ItemCheck(object sender, ItemCheckEventArgs e)
  {
    if ( !IsReady ) return;
    var item = (LayoutSectionItem)SelectLayoutSections.Items[e.Index];
    if ( item.Id == MonthlyViewLayoutSection.LunarDate )
      e.NewValue = CheckState.Checked;
    if ( item.Id == MonthlyViewLayoutSection.ParashahName && !EditParashahEnabled.Checked )
      e.NewValue = CheckState.Unchecked;
    else
    if ( item.Id == MonthlyViewLayoutSection.ParashahReference && !EditParashahEnabled.Checked )
      e.NewValue = CheckState.Unchecked;
    else
    if ( item.Id == MonthlyViewLayoutSection.EphemerisSun )
    {
      if ( !SelectOmerMoon.Checked ) e.NewValue = CheckState.Checked;
      var args = new LuminaryEventArgs() { OneLuminary = ( e.NewValue == CheckState.Checked ) ^ MoonChecked };
      UpdateMonthViewCheckBoxes(SelectLayoutSections, args);
      return;
    }
    else
    if ( item.Id == MonthlyViewLayoutSection.EphemerisMoon )
    {
      if ( SelectOmerMoon.Checked ) e.NewValue = CheckState.Checked;
      var args = new LuminaryEventArgs() { OneLuminary = SunChecked ^ ( e.NewValue == CheckState.Checked ) };
      UpdateMonthViewCheckBoxes(SelectLayoutSections, args);
      return;
    }
    SetMustRefreshEnabled(null, null);
  }

  private void UpdateMonthViewCheckBoxes(object sender, EventArgs e)
  {
    SetMustRefreshEnabled(null, null);
    bool oneLuminary = e is LuminaryEventArgs args ? args.OneLuminary : SunChecked ^ MoonChecked;
    EditMonthViewOneLuminaryOneLine.Enabled = oneLuminary;
    EditMonthViewOneLuminaryOneLineSign.Enabled = oneLuminary
                                                  && EditMonthViewOneLuminaryOneLine.Checked
                                                  && !EditHideLuminarySigns.Checked;
  }

  private void ActionLayoutSectionUp_Click(object sender, EventArgs e)
  {
    SelectLayoutSections.MoveSelectedItem(-1);
    SelectLayoutSections.Focus();
    SetMustRefreshEnabled(null, null);
  }

  private void ActionLayoutSectionDown_Click(object sender, EventArgs e)
  {
    SelectLayoutSections.MoveSelectedItem(1);
    SelectLayoutSections.Focus();
  }

  private void ActionResetEphemerisPrefixSun_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditEphemerisPrefixSun.Text = (string)Settings.Properties[nameof(Settings.EphemerisSignSun)].DefaultValue;
  }

  private void ActionResetEphemerisPrefixMoon_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
      EditEphemerisPrefixMoon.Text = (string)Settings.Properties[nameof(Settings.EphemerisSignMoon)].DefaultValue;
  }

  private void EditCalendarHebrewDateSingleLine_CheckedChanged(object sender, EventArgs e)
  {
    SetMustRefreshEnabled(null, null);
    EditCalendarHebrewDateSingleLineItalic.Enabled = EditCalendarHebrewDateSingleLine.Checked;
  }

  private void ActionLayoutResetSections_Click(object sender, EventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) ) return;
    foreach ( LayoutSectionItem item in SelectLayoutSections.Items )
    {
      string prefix = $"{LayoutSectionPrefix}{item.Id}";
      item.Position = Convert.ToInt32((string)Settings.Properties[prefix + LayoutSectionPosition].DefaultValue);
      item.Enabled = Convert.ToBoolean((string)Settings.Properties[prefix + LayoutSectionEnabled].DefaultValue);
    }
    // Sorting does not sort checks!
    SelectLayoutSections.Sort((item1, item2) => ( (LayoutSectionItem)item1 ).Position.CompareTo(( (LayoutSectionItem)item2 ).Position));
    for ( int index = 0; index < SelectLayoutSections.Items.Count; index++ )
      if ( ( (LayoutSectionItem)SelectLayoutSections.Items[index] ).Enabled )
        SelectLayoutSections.SetItemChecked(index, true);
    SetMustRefreshEnabled(null, null);
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
    SystemManager.TryCatch(() => FolderBrowserDialog.SelectedPath = Settings.GetExportSettingsDirectory());
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

  private void SelectWeatherOnlineAccuWeatherDotCom_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineProvider = WeatherProvider.AccuWeatherDotCom;
    EditWeatherOnlineUseDay.Enabled = false;
  }

  private void SelectWeatherOnlineMeteoblueDotCom_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineProvider = WeatherProvider.MeteoblueDotCom;
    EditWeatherOnlineUseDay.Enabled = true;
  }

  private void SelectWeatherOnlineMicrosoftNetworkDotCom_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineProvider = WeatherProvider.MicrosoftNetworkDotCom;
    EditWeatherOnlineUseDay.Enabled = false;
  }

  private void SelectWeatherOnlineWeatherDotCom_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineProvider = WeatherProvider.WeatherDotCom;
    EditWeatherOnlineUseDay.Enabled = true;
  }

  private void EditWeatherOnlineUseDay_CheckedChanged(object sender, EventArgs e)
  {
    Settings.WeatherOnlineUseDay = EditWeatherOnlineUseDay.Checked;
  }

  private void ActionWeatherOnlineTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    MainForm.Instance.ActionOnlineWeather.PerformClick();
  }

  private void ActionSelectOnlineVerseURL_Click(object sender, EventArgs e)
  {
    MenuSelectOnlineVerseProviderURL.Show(ActionSelectOnlineVerseURL, new Point(0, ActionSelectOnlineVerseURL.Height));
  }

  private void ActionOnlineVerseHelp_Click(object sender, EventArgs e)
  {
    DisplayManager.ShowInformation(HebrewTranslations.NoticeOnlineBibleProvider.GetLang());
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
