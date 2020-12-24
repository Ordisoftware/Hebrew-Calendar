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
using System.Linq;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;
using KVPDataExportTarget = System.Collections.Generic.KeyValuePair<Ordisoftware.Core.DataExportTarget, string>;
using KVPImageExportTarget = System.Collections.Generic.KeyValuePair<Ordisoftware.Core.ImageExportTarget, string>;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm : Form
  {

    private bool IsReady;
    private bool InitialHotKeyEnabled;

    public int OldShabatDay { get; private set; }
    public string OldLatitude { get; private set; }
    public string OldLongitude { get; private set; }
    public string OldTimeZone { get; private set; }
    public bool OldUseMoonDays { get; private set; }
    public bool MustRefreshMonthView { get; private set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    private PreferencesForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ActionMonthViewThemeDark.Visible = Globals.IsDevExecutable; // TODO remove when ready
      Initialize();
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_Load(object sender, EventArgs e)
    {
      this.CenterToMainFormElseScreen();
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_Shown(object sender, EventArgs e)
    {
      SystemManager.TryCatchManage(() => Globals.BringToFrontApplicationHotKey.Active = false);
      TopMost = MainForm.Instance.TopMost;
      BringToFront();
      UpdateLanguagesButtons();
      LoadSettings();
      EditVacuumAtStartup_CheckedChanged(null, null);
      EditCheckUpdateAtStartup_CheckedChanged(null, null);
      EditBalloon_CheckedChanged(null, null);
      EditAutoRegenerate_CheckedChanged(null, null);
      EditRemindAutoLock_CheckedChanged(null, null);
      EditRemindShabat_ValueChanged(null, null);
      EditTimerEnabled_CheckedChanged(null, null);
      EditUseColors_CheckedChanged(null, null);
      EditLogEnabled_CheckedChanged(null, null);
      ActiveControl = ActionClose;
      ActionResetSettings.TabStop = false;
      IsReady = true;
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
      IsReady = true;
    }

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

    private void EditStartWithWindows_CheckedChanged(object sender, EventArgs e)
    {
      SystemManager.StartWithWindowsUserRegistry = EditStartWithWindows.Checked;
    }

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
      MainForm.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
      StatisticsForm.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
    }

    private void EditUsageStatisticsEnabled_CheckedChanged(object sender, EventArgs e)
    {
      MainForm.Instance.ActionViewStats.Enabled = EditUsageStatisticsEnabled.Checked;
      StatisticsForm.Instance.Timer.Enabled = EditUsageStatisticsEnabled.Checked;
      if ( !EditUsageStatisticsEnabled.Checked )
        StatisticsForm.Instance.Close();
    }

    private void ActionGetGPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !SelectCityForm.Run(e != null) ) return;
      EditGPSLatitude.Text = Settings.GPSLatitude;
      EditGPSLongitude.Text = Settings.GPSLongitude;
      EditTimeZone.Text = Settings.GetGPSText();
      MainForm.Instance.InitializeCurrentTimeZone();
    }

    private void ActionCountAsMoonHelp_Click(object sender, EventArgs e)
    {
      MainForm.Instance.ActionShowCelebrationsNotice_Click(null, null);
    }

    private void ActionPersonalShabatHelp_Click(object sender, EventArgs e)
    {
      MainForm.Instance.ActionShowShabatNotice_Click(null, null);
    }

    private void ActionHotKeyInfo_Click(object sender, EventArgs e)
    {
      DisplayManager.ShowInformation(AppTranslations.HotKeyNotice.GetLang());
    }

    private void ActionAutoGenerateHelp_Click(object sender, EventArgs e)
    {
      DisplayManager.ShowInformation(AppTranslations.AutoGenerateIntervalNotice.GetLang());
    }

    private void ActionMoonDayTextFormatHelp_Click(object sender, EventArgs e)
    {
      DisplayManager.ShowInformation(AppTranslations.NoticeMoonDayTextFormat.GetLang());
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

    private void EditMonthViewSunToolTips_CheckedChanged(object sender, EventArgs e)
    {
      MustRefreshMonthView = true;
    }

    private void EditMoonDayTextFormat_TextChanged(object sender, EventArgs e)
    {
      if ( IsReady ) MustRefreshMonthView = true;
    }

    private void MenuSelectMoonDayTextFormat_Click(object sender, EventArgs e)
    {
      EditMoonDayTextFormat.Text = (string)( sender as ToolStripMenuItem ).Tag;
    }

    private void ActionMoonDayTextFormatReset_Click(object sender, EventArgs e)
    {
      MenuSelectMoonDayTextFormat.Show(ActionMoonDayTextFormatReset,
                                       new Point(0, ActionMoonDayTextFormatReset.Height));
    }

    private void EditMaxYearsInterval_ValueChanged(object sender, EventArgs e)
    {
      if ( Created ) Program.Settings.GenerateIntervalMaximum = (int)EditMaxYearsInterval.Value;
      YearsIntervalItem.InitializeMenu(MenuPredefinedYears,
                                       Program.AutoGenerateYearsIntervalMax,
                                       PredefinedYearsItem_Click);
    }

    private void EditReportFont_Changed(object sender, EventArgs e)
    {
      if ( !IsReady ) return;
      Settings.FontName = EditFontName.Text;
      Settings.FontSize = (int)EditFontSize.Value;
      MainForm.Instance.UpdateTextCalendar();
    }

    private void EditBalloon_CheckedChanged(object sender, EventArgs e)
    {
      EditBalloonLoomingDelay.Enabled = EditBalloon.Checked;
      EditBalloonAutoHide.Enabled = EditBalloon.Checked;
      EditBalloonOnlyIfMainFormIsHidden.Enabled = EditBalloon.Checked;
    }

    private void EditRemindAutoLock_CheckedChanged(object sender, EventArgs e)
    {
      LabelRemindAutoLockTimeOut.Enabled = EditAutoLockSession.Checked;
      EditAutoLockSessionTimeOut.Enabled = EditAutoLockSession.Checked;
    }

    private void EditAutoRegenerate_CheckedChanged(object sender, EventArgs e)
    {
      EditAutoGenerateYearsInterval.Enabled = EditAutoRegenerate.Checked;
      SelectAutoGenerateYearsInterval.Enabled = EditAutoRegenerate.Checked;
      ActionAutoGenerateHelp.Enabled = EditAutoRegenerate.Checked;
    }

    private void EditRemindShabat_ValueChanged(object sender, EventArgs e)
    {
      EditRemindShabatOnlyLight.Enabled = EditReminderShabatEnabled.Checked;
      LabelRemindShabatHoursBefore.Enabled = EditReminderShabatEnabled.Checked;
      EditRemindShabatHoursBefore.Enabled = EditReminderShabatEnabled.Checked;
      LabelRemindShabatEveryMinutes.Enabled = EditReminderShabatEnabled.Checked;
      EditRemindShabatEveryMinutes.Enabled = EditReminderShabatEnabled.Checked;
    }

    private void EditTimerEnabled_CheckedChanged(object sender, EventArgs e)
    {
      LabelTimerInterval.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditReminderCelebrationsDaysBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditEvents.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditEventsDay.Enabled = EditReminderCelebrationsEnabled.Checked;
      LabelRemindCelebrationHoursBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditRemindCelebrationHoursBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
      LabelRemindCelebrationEveryMinutes.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditRemindCelebrationEveryMinutes.Enabled = EditReminderCelebrationsEnabled.Checked;
    }

    private void ActionUseSystemColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      NavigationForm.Instance.Show();
      EditNavigateTopColor.BackColor = SystemColors.Control;
      EditNavigateMiddleColor.BackColor = SystemColors.Control;
      EditNavigateBottomColor.BackColor = SystemColors.Control;
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    }

    private void ActionUseBlackAndWhiteColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      NavigationForm.Instance.Show();
      EditNavigateTopColor.BackColor = Color.White;
      EditNavigateMiddleColor.BackColor = Color.Gainsboro;
      EditNavigateBottomColor.BackColor = Color.White;
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    }

    private void ActionUseDefaultColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      NavigationForm.Instance.Show();
      EditNavigateTopColor.BackColor = Color.LemonChiffon;
      EditNavigateMiddleColor.BackColor = Color.AliceBlue;
      EditNavigateBottomColor.BackColor = Color.Honeydew;
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    }

    private void PanelTextColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditTextColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditTextColor.BackColor = DialogColor.Color;
      MainForm.Instance.CalendarText.ForeColor = DialogColor.Color;
    }

    private void PanelBackColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditTextBackground.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditTextBackground.BackColor = DialogColor.Color;
      MainForm.Instance.CalendarText.BackColor = DialogColor.Color;
    }

    private void PanelTopColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = EditNavigateTopColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditNavigateTopColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
    }

    private void PanelMiddleColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = EditNavigateMiddleColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditNavigateMiddleColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
    }

    private void PanelBottomColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = EditNavigateBottomColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditNavigateBottomColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    }

    private void PanelEventColorTorah_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorTorah.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorTorah.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelEventColorSeason_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorSeason.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorSeason.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelEventColorShabat_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorShabat.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorShabat.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelEventColorNewMonth_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorMonth.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorMonth.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelEventColorNext_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorNext.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorNext.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelCurrentDayColor_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCurrentDayForeColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCurrentDayForeColor.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelCurrentDayBackColor_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCurrentDayBackColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCurrentDayBackColor.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelTorahEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditCalendarColorTorahEvent.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorTorahEvent.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelSeasonEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditCalendarColorSeason.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorSeason.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelMoonEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditCalendarColorMoon.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorMoon.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelFullMoonColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditCalendarColorFullMoon.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorFullMoon.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void EditCalendarColorEmpty_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCalendarColorEmpty.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorEmpty.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void EditCalendarColorDefaultText_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCalendarColorDefaultText.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorDefaultText.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void EditCalendarColorNoDay_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCalendarColorNoDay.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorNoDay.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void EditUseColors_CheckedChanged(object sender, EventArgs e)
    {
      if ( IsReady ) MustRefreshMonthView = true;
      PanelCalendarColors.Enabled = EditUseColors.Checked;
    }
    private void EditMonthViewFontSize_ValueChanged(object sender, EventArgs e)
    {
      if ( IsReady ) MustRefreshMonthView = EditMonthViewFontSize.Value != Settings.MonthViewFontSize;
    }

    private void EditPreferedDataExportFileFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !IsReady ) return;
      Settings.ExportDataPreferredTarget = ( (KVPDataExportTarget)EditDataExportFileFormat.SelectedItem ).Key;
    }

    private void EditDataExportFileFormat_Format(object sender, ListControlConvertEventArgs e)
    {
      e.Value = ( (KVPDataExportTarget)e.ListItem ).Key.ToString();
    }

    private void EditImageExportFileFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !IsReady ) return;
      Settings.ExportImagePreferredTarget = ( (KVPImageExportTarget)EditImageExportFileFormat.SelectedItem ).Key;
    }

    private void EditImageExportFileFormat_Format(object sender, ListControlConvertEventArgs e)
    {
      e.Value = ( (KVPImageExportTarget)e.ListItem ).Key.ToString();
    }

    private void ActionSelectExportFolder_Click(object sender, EventArgs e)
    {
      SystemManager.TryCatch(() =>
      {
        FolderBrowserDialog.SelectedPath = Settings.GetExportDirectory();
      });
      if ( FolderBrowserDialog.ShowDialog() == DialogResult.OK )
        EditExportFolder.Text = FolderBrowserDialog.SelectedPath;
    }

    private void ActionSelectCalculatorPath_Click(object sender, EventArgs e)
    {
      SystemManager.TryCatch(() =>
      {
        OpenExeFileDialog.InitialDirectory = Path.GetDirectoryName(EditCalculatorPath.Text);
      });
      SystemManager.TryCatch(() =>
      {
        OpenExeFileDialog.FileName = Path.GetFileName(EditCalculatorPath.Text);
      });
      if ( OpenExeFileDialog.ShowDialog() == DialogResult.OK )
        EditCalculatorPath.Text = OpenExeFileDialog.FileName;
    }

    private void ActionSelectHebrewLettersPath_Click(object sender, EventArgs e)
    {
      SystemManager.TryCatch(() =>
      {
        OpenExeFileDialog.InitialDirectory = Path.GetDirectoryName(EditHebrewLettersPath.Text);
      });
      SystemManager.TryCatch(() =>
      {
        OpenExeFileDialog.FileName = Path.GetFileName(EditHebrewLettersPath.Text);
      });
      if ( OpenExeFileDialog.ShowDialog() == DialogResult.OK )
        EditHebrewLettersPath.Text = OpenExeFileDialog.FileName;
    }

    private void SelectAutoGenerateYearsInterval_Click(object sender, EventArgs e)
    {
      MenuPredefinedYears.Show(SelectAutoGenerateYearsInterval,
                               new Point(0, SelectAutoGenerateYearsInterval.Height));
    }

    private void PredefinedYearsItem_Click(object sender, EventArgs e)
    {
      var value = ( (YearsIntervalItem)( sender as ToolStripMenuItem ).Tag ).OriginalValue;
      EditAutoGenerateYearsInterval.Text = value.ToString();
    }

    private void ActionResetExportFolder_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
        EditExportFolder.Text = (string)Settings.Properties["ExportFolder"].DefaultValue;
    }

    private void ActionResetCalculatorPath_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
        EditCalculatorPath.Text = (string)Settings.Properties["CalculatorExe"].DefaultValue;
    }

    private void ActionResetHebrewLettersPath_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetParameter.GetLang()) )
        EditHebrewLettersPath.Text = (string)Settings.Properties["HebrewLettersExe"].DefaultValue;
    }

    private void EditVacuumAtStartup_CheckedChanged(object sender, EventArgs e)
    {
      EditVacuumAtStartupInterval.Enabled = EditVacuumAtStartup.Checked;
    }

    private void EditCheckUpdateAtStartup_CheckedChanged(object sender, EventArgs e)
    {
      EditCheckUpdateEveryWeek.Enabled = EditCheckUpdateAtStartup.Checked;
      EditCheckUpdateAtStartupInterval.Enabled = EditCheckUpdateAtStartup.Checked;
    }

    private void EditVolume_ValueChanged(object sender, EventArgs e)
    {
      VolumeMixer.SetApplicationVolume(System.Diagnostics.Process.GetCurrentProcess().Id, EditVolume.Value);
      LabelVolumeValue.Text = EditVolume.Value + "%";
      Program.Settings.ApplicationVolume = EditVolume.Value;
      Program.Settings.Save();
      DisplayManager.DoSound(Globals.ClipboardSoundFilePath);
    }

    private void LabelSelectReminderSound_Click(object sender, EventArgs e)
    {
      SelectSoundForm.Run();
    }

    private void ActionManageBookmarks_Click(object sender, EventArgs e)
    {
      if ( ManageDateBookmarksForm.Run() )
        DatesDiffCalculatorForm.Instance.LoadMenuBookmarks();
    }

    private void EditDateBookmarksCount_ValueChanged(object sender, EventArgs e)
    {
      Settings.DateBookmarksCount = (int)EditDateBookmarksCount.Value;
      Program.DateBookmarks.Resize(Settings.DateBookmarksCount);
      DatesDiffCalculatorForm.Instance.LoadMenuBookmarks();
    }

    private void EditAutoOpenExportedFile_CheckedChanged(object sender, EventArgs e)
    {
      if ( EditAutoOpenExportedFile.Checked && EditAutoOpenExportFolder.Checked )
        EditAutoOpenExportFolder.Checked = false;
    }

    private void EditAutoOpenExportFolder_CheckedChanged(object sender, EventArgs e)
    {
      if ( EditAutoOpenExportedFile.Checked && EditAutoOpenExportFolder.Checked )
        EditAutoOpenExportedFile.Checked = false;
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

    private void EditGlobalHotKeyPopupMainFormEnabled_CheckedChanged(object sender, EventArgs e)
    {
      if ( !IsReady ) return;
      InitialHotKeyEnabled = EditGlobalHotKeyPopupMainFormEnabled.Checked;
    }

    private void SelectGlobalHotKeyPopupMainFormKey_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !IsReady ) return;
      var key = Globals.BringToFrontApplicationHotKey.Key;
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
      if ( !PanelHotKey.Controls.OfType<CheckBox>().Where(c => c != checkbox).ToList().All(c => !c.Checked) )
        return true;
      checkbox.Checked = true;
      return false;
    }

  }

}
