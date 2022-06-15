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
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.Drawing.Text;
using System.Xml;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class PreferencesForm
{

  /// <summary>
  /// Does form load.
  /// </summary>
  private void DoFormLoad()
  {
    SaveSettingsDialog.InitialDirectory = Program.Settings.GetExportDirectory();
    OpenSettingsDialog.InitialDirectory = SaveSettingsDialog.InitialDirectory;
    SaveSettingsDialog.Filter = ExportTarget.CreateFilters();
    OpenSettingsDialog.Filter = SaveSettingsDialog.Filter;
    LoadEditIntervals();
    LoadExportFileFormats();
    LoadReminderBoxesLocations();
    LoadPowerActions();
    LoadDays();
    LoadEvents();
    LoadFonts();
    LoadHotKeys();
  }

  /// <summary>
  /// Does form show.
  /// </summary>
  private void DoFormShow()
  {
    SystemManager.TryCatchManage(() => Globals.BringToFrontApplicationHotKey.Active = false);
    TopMost = MainForm.Instance.TopMost;
    BringToFront();
    UpdateLanguagesButtons();
    LoadSettings();
    CheckFirstLaunchNoticesAndChoices();
    EditVacuumAtStartup_CheckedChanged(null, null);
    EditCheckUpdateAtStartup_CheckedChanged(null, null);
    EditBalloon_CheckedChanged(null, null);
    EditAutoRegenerate_CheckedChanged(null, null);
    EditRemindAutoLock_CheckedChanged(null, null);
    EditRemindShabat_Changed(null, null);
    EditRemindCelebrations_Changed(null, null);
    EditUseColors_CheckedChanged(null, null);
    EditLogEnabled_CheckedChanged(null, null);
    EditCalendarShowParashah_Changed(null, null);
    ActiveControl = ActionClose;
    ActionResetSettings.TabStop = false;
    IsReady = true;
  }

  /// <summary>
  /// Checks the first launch to show notices and ask user preferences for generation.
  /// </summary>
  [SuppressMessage("Refactoring", "GCop622:Reverse your IF condition and return. Then move the nested statements to after the IF.", Justification = "Opinion")]
  private void CheckFirstLaunchNoticesAndChoices()
  {
    bool changed = false;
    if ( Settings.FirstLaunch )
    {
      changed = true;
      MainForm.Instance.ActionShowMonthsAndDaysNotice_Click(null, null);
      MainForm.Instance.ActionShowCelebrationsNotice_Click(null, null);
      // TODO update query when sod will be ready
      Settings.TorahEventsCountAsMoon = DisplayManager.QueryYesNo(AppTranslations.AskToUseMoonOmer.GetLang());
      if ( Settings.UseSodHaibour )
        SelectUseSodHaibour.Checked = true;
      else
      if ( Settings.TorahEventsCountAsMoon )
        SelectOmerMoon.Checked = true;
      else
        SelectOmerSun.Checked = true;
      MainForm.Instance.ActionShowShabatNotice_Click(null, null);
      if ( DisplayManager.QueryYesNo(AppTranslations.AskToSetupPersonalShabat.GetLang()) )
        ActionUsePersonalShabat_LinkClicked(null, null);
      string msg = AppTranslations.AskToSetupPessahLastDayForTwo.GetLang();
      Settings.UseTwoDaysForLastPessahDayOutside = DisplayManager.QueryYesNo(msg);
    }
    if ( changed || Settings.FirstLaunchV7_0 || Settings.FirstLaunchV9_14 )
    {
      changed = true;
      if ( Settings.FirstLaunchV7_0 )
      {
        MainForm.Instance.ActionShowParashahNotice_Click(null, null);
        DisplayManager.QueryYesNo(AppTranslations.AskToUseLastDayOfSukotForSimhatTorah.GetLang(),
                                  () => EditUseSimhatTorahOutside.Checked = false,
                                  () => EditUseSimhatTorahOutside.Checked = true);
      }
      if ( !Settings.FirstLaunch && Settings.FirstLaunchV9_14 )
      {
        DisplayManager.Show(AppTranslations.WorldCitiesUpdated.GetLang());
        ActionGetGPS_LinkClicked(null, null);
      }
    }
    if ( changed )
    {
      TabControl.SelectedTab = TabPageGeneration;
      Settings.SetFirstAndUpgradeFlagsOff();
      SystemManager.TryCatch(Settings.Store);
    }
  }

  /// <summary>
  /// Does form closing.
  /// </summary>
  [SuppressMessage("Usage", "GCop517:'{0}()' returns a value but doesn't change the object. It's meaningless to call it without using the returned result.", Justification = "N/A")]
  private void DoFormClosing(object sender, FormClosingEventArgs e)
  {
    if ( DoReset ) return;
    try
    {
      XmlConvert.ToDouble(EditGPSLatitude.Text);
      XmlConvert.ToDouble(EditGPSLongitude.Text);
    }
    catch
    {
      DisplayManager.ShowError("Invalid GPS coordinates.");
      e.Cancel = true;
      return;
    }
    SaveSettings();
    SystemManager.TryCatch(Settings.Store);
    SystemManager.TryCatch(() => Globals.BringToFrontApplicationHotKey.Active = Settings.GlobalHotKeyPopupMainFormEnabled);
  }

  /// <summary>
  /// Loads edit intervals.
  /// </summary>
  private void LoadEditIntervals()
  {
    InitializeNumericInterval(EditTextReportFontSize, LabelTextReportFontSizeInterval, TextReportFontSizeInterval);
    InitializeNumericInterval(EditMonthViewFontSize, LabelMonthViewFontSizeInterval, VisualMonthFontSizeInterval);
    InitializeNumericInterval(EditCheckUpdateAtStartupInterval, LabelCheckUpdateAtStartupInfo, CheckUpdateInterval);
    InitializeNumericInterval(EditVacuumAtStartupInterval, LabelOptimizeDatabaseIntervalInfo, CheckUpdateInterval);
    InitializeNumericInterval(EditPrintingMargin, LabelPrintingMarginIntervalInfo, PrintingMarginInterval);
    InitializeNumericInterval(EditPrintPageCountWarning, LabelPrintPageCountWarningIntervalInfo, PrintPageCountWarningInterval);
    InitializeNumericInterval(EditSaveImageCountWarning, LabelSaveImageCountWarningIntervalInfo, SaveImageCountWarningInterval);
    InitializeNumericInterval(EditBalloonLoomingDelay, LabelLoomingDelayIntervalInfo, LoomingDelayInterval);
    InitializeNumericInterval(EditRemindCelebrationsDaysBefore, LabelReminderCelebrationsIntervalInfo, RemindCelebrationDaysBeforeInterval);
    InitializeNumericInterval(EditRemindShabatHoursBefore, LabelRemindShabatHoursBeforeIntervalInfo, RemindShabatHoursBeforeInterval);
    InitializeNumericInterval(EditRemindShabatEveryMinutes, LabelRemindShabatEveryMinutesIntervalInfo, RemindShabatEveryMinutesInterval);
    InitializeNumericInterval(EditRemindCelebrationHoursBefore, LabelRemindCelebrationHoursBeforeIntervalInfo, RemindCelebrationHoursBeforeInterval);
    InitializeNumericInterval(EditRemindCelebrationEveryMinutes, LabelRemindCelebrationEveryMinutesIntervalInfo, RemindCelebrationEveryMinutesInterval);
    InitializeNumericInterval(EditAutoLockSessionTimeOut, LabelAutoLockSessionTimeOutIntervalInfo, RemindAutoLockTimeOutInterval);
    InitializeNumericInterval(EditMaxYearsInterval, LabelMaxYearsIntervalInfo, GenerateIntervalInterval);
    InitializeNumericInterval(EditCalendarLineSpacing, LabelCalendarLineSpacingInfo, LineSpacingInterval);
    InitializeNumericInterval(EditDateBookmarksCount, LabelDateBookmarksCountIntervalInfo, DateBookmarksCountInterval);
    int countBookmarks = Program.DateBookmarks.MaxCount;
    if ( countBookmarks == -1 ) countBookmarks = DateBookmarksCountInterval.Item1;
    LabelDateBookmarksCountIntervalInfo.Text = countBookmarks.ToString();
    EditDateBookmarksCount.Minimum = countBookmarks;
    SetNumericLabelText(EditDateBookmarksCount, LabelDateBookmarksCountIntervalInfo);
  }

  /// <summary>
  /// Initialize minimum, maximum, value and increment of a numeric edit, and update the associated label info text.
  /// </summary>
  static void InitializeNumericInterval(NumericUpDown control, Label label, (int, int, int, int) interval)
  {
    control.Minimum = interval.Item1;
    control.Maximum = interval.Item2;
    control.Value = interval.Item3;
    control.Increment = interval.Item4;
    SetNumericLabelText(control, label);
  }

  /// <summary>
  /// Update the associated label info text of a numeric edit.
  /// </summary>
  static void SetNumericLabelText(NumericUpDown control, Label label)
  {
    if ( label is not null ) label.Text = $"{control.Minimum} - {control.Maximum} ({control.Value})";
  }

  /// <summary>
  /// Loads export file formats.
  /// </summary>
  private void LoadExportFileFormats()
  {
    EditDataExportFileFormat.Fill(Program.GridExportTargets, Settings.ExportDataPreferredTarget);
    EditImageExportFileFormat.Fill(Program.ImageExportTargets, Settings.ExportImagePreferredTarget);
  }

  /// <summary>
  /// Loads reminder boxes locations.
  /// </summary>
  private void LoadReminderBoxesLocations()
  {
    foreach ( var value in Enums.GetValues<ControlLocation>().Skip(1).SkipLast(2) )
    {
      SelectReminderBoxDesktopLocation.Items.Add(value);
      if ( Settings.ReminderBoxDesktopLocation == value )
        SelectReminderBoxDesktopLocation.SelectedItem = value;
    }
  }

  /// <summary>
  /// Loads week days.
  /// </summary>
  private void LoadPowerActions()
  {
    PowerAction[] avoid = { PowerAction.LogOff, PowerAction.Restart, PowerAction.Shutdown };
    foreach ( var value in SystemManager.GetAvailablePowerActions().Where(a => !avoid.Contains(a)) )
    {
      SelectLockSessionDefaultAction.Items.Add(value);
      if ( Settings.LockSessionDefaultAction == value )
        SelectLockSessionDefaultAction.SelectedItem = value;
    }
  }

  /// <summary>
  /// Loads week days.
  /// </summary>
  private void LoadDays()
  {
    foreach ( var value in Enums.GetValues<DayOfWeek>() )
    {
      var item = new DayOfWeekItem { Text = AppTranslations.DaysOfWeek.GetLang(value), Day = value };
      EditShabatDay.Items.Add(item);
      if ( (DayOfWeek)Settings.ShabatDay == value )
        EditShabatDay.SelectedItem = item;
    }
  }

  /// <summary>
  /// Loads Torah events.
  /// </summary>
  private void LoadEvents()
  {
    foreach ( var value in TorahCelebrationSettings.ManagedEvents )
      SystemManager.TryCatch(() =>
        {
          var item = new TorahEventItem
          {
            Text = AppTranslations.TorahCelebrationDays.GetLang(value),
            Event = value
          };
          int index = SelectRemindEventsBefore.Items.Add(item);
          if ( (bool)Settings["TorahEventRemind" + value] )
            SelectRemindEventsBefore.SetItemChecked(index, true);
          index = SelectRemindEventsDay.Items.Add(item);
          if ( (bool)Settings["TorahEventRemindDay" + value] )
            SelectRemindEventsDay.SetItemChecked(index, true);
        });
  }

  /// <summary>
  /// Loads fonts names.
  /// </summary>
  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "Analysis error")]
  private void LoadFonts()
  {
    using var list = new InstalledFontCollection();
    var fonts = list.Families
                    .Where(value => MonoSpacedFonts.Contains(value.Name.ToLower()))
                    .Select(font => font.Name)
                    .OrderBy(name => name);
    foreach ( var name in fonts )
    {
      int index = EditTextReportFontName.Items.Add(name);
      if ( name == Settings.FontName )
        EditTextReportFontName.SelectedIndex = index;
    }
  }


  /// <summary>
  /// Loads Hot-Keys.
  /// </summary>
  [SuppressMessage("Roslynator", "RCS1235:Optimize method call.", Justification = "Analysis error")]
  private void LoadHotKeys()
  {
    SelectGlobalHotKeyPopupMainFormKey.Items.Clear();
    foreach ( var item in AvailableHotKeyKeys )
      SelectGlobalHotKeyPopupMainFormKey.Items.Add(item);
  }

  /// <summary>
  /// Initializes HotKey.
  /// </summary>
  private void InitHotKeyControls()
  {
    MainForm.Instance.SetGlobalHotKey(true);
    InitialHotKeyEnabled = EditGlobalHotKeyPopupMainFormEnabled.Checked;
    EditGlobalHotKeyPopupMainFormShift.Checked = Globals.BringToFrontApplicationHotKey.Shift;
    EditGlobalHotKeyPopupMainFormCtrl.Checked = Globals.BringToFrontApplicationHotKey.Control;
    EditGlobalHotKeyPopupMainFormAlt.Checked = Globals.BringToFrontApplicationHotKey.Alt;
    EditGlobalHotKeyPopupMainFormWin.Checked = Globals.BringToFrontApplicationHotKey.Windows;
    string key = Globals.BringToFrontApplicationHotKey.Key.ToString();
    SelectGlobalHotKeyPopupMainFormKey.SelectedIndex = SelectGlobalHotKeyPopupMainFormKey.FindString(key);
    CheckHotKeyCombination(null);
  }

  /// <summary>
  /// Checks HotKey combination.
  /// </summary>
  private void CheckHotKeyCombination(Action action)
  {
    if ( action is null && !EditGlobalHotKeyPopupMainFormEnabled.Checked ) return;
    var tempActiveControl = ActiveControl;
    var tempIsReady = IsReady;
    PanelHotKey.Enabled = false;
    try
    {
      action?.Invoke();
      if ( !Globals.BringToFrontApplicationHotKey.IsValid() )
        throw new Exception(SysTranslations.HotKeyCapturedByAnotherApplication.GetLang());
      LabelHotKeyStatus.Text = SysTranslations.Valid.GetLang();
      IsReady = false;
      EditGlobalHotKeyPopupMainFormEnabled.Checked = InitialHotKeyEnabled;
      EditGlobalHotKeyPopupMainFormEnabled.Enabled = true;
      IsReady = tempIsReady;
    }
    catch ( Exception ex )
    {
      LabelHotKeyStatus.Text = ex.Message;
      IsReady = false;
      EditGlobalHotKeyPopupMainFormEnabled.Checked = false;
      EditGlobalHotKeyPopupMainFormEnabled.Enabled = false;
      IsReady = tempIsReady;
    }
    finally
    {
      PanelHotKey.Enabled = true;
      ActiveControl = tempActiveControl;
    }
  }

}
