/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-02 </edited>
using System;
using System.Linq;
using System.Xml;
using System.Drawing.Text;
using System.Windows.Forms;
using EnumsNET;
using MoreLinq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class PreferencesForm
  {

    /// <summary>
    /// Do form load.
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
      LoadDays();
      LoadEvents();
      LoadFonts();
      LoadHotKeys();
    }

    /// <summary>
    /// Do form show.
    /// </summary>
    private void DoFormShow()
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
      EditRemindShabat_Changed(null, null);
      EditRemindCelebrations_Changed(null, null);
      EditUseColors_CheckedChanged(null, null);
      EditLogEnabled_CheckedChanged(null, null);
      ActiveControl = ActionClose;
      ActionResetSettings.TabStop = false;
      IsReady = true;
    }

    /// <summary>
    /// Do form closing.
    /// </summary>
    private void DoFormClosing(object sender, FormClosingEventArgs e)
    {
      if ( DoReset ) return;
      try
      {
        var v1 = (float)XmlConvert.ToDouble(EditGPSLatitude.Text);
        var v2 = (float)XmlConvert.ToDouble(EditGPSLongitude.Text);
      }
      catch
      {
        DisplayManager.ShowError("Invalid GPS coordonates.");
        e.Cancel = true;
        return;
      }
      SaveSettings();
      Settings.Save();
      SystemManager.TryCatch(() => { Globals.BringToFrontApplicationHotKey.Active = Settings.GlobalHotKeyPopupMainFormEnabled; });
    }

    /// <summary>
    /// Load edit intervals.
    /// </summary>
    private void LoadEditIntervals()
    {
      setInterval(EditTextReportFontSize, LabelTextReportFontSizeInterval, TextReportFontSizeInterval);
      setInterval(EditMonthViewFontSize, LabelMonthViewFontSizeInterval, VisualMonthFontSizeInterval);
      setInterval(EditCheckUpdateAtStartupInterval, LabelCheckUpdateAtStartupInfo, CheckUpdateInterval);
      setInterval(EditVacuumAtStartupInterval, LabelOptimizeDatabaseIntervalInfo, CheckUpdateInterval);
      setInterval(EditDateBookmarksCount, LabelDateBookmarksCountIntervalInfo, DateBookmarksCountInterval);
      setInterval(EditPrintingMargin, LabelPrintingMarginIntervalInfo, PrintingMarginInterval);
      setInterval(EditPrintPageCountWarning, LabelPrintPageCountWarningIntervalInfo, PrintPageCountWarningInterval);
      setInterval(EditSaveImageCountWarning, LabelSaveImageCountWarningIntervalInfo, SaveImageCountWarningInterval);
      setInterval(EditBalloonLoomingDelay, LabelLoomingDelayIntervalInfo, LoomingDelayInterval);
      setInterval(EditRemindCelebrationsDaysBefore, LabelReminderCelebrationsIntervalInfo, RemindCelebrationDaysBeforeInterval);
      setInterval(EditRemindShabatHoursBefore, LabelRemindShabatHoursBeforeIntervalInfo, RemindShabatHoursBeforeInterval);
      setInterval(EditRemindShabatEveryMinutes, LabelRemindShabatEveryMinutesIntervalInfo, RemindShabatEveryMinutesInterval);
      setInterval(EditRemindCelebrationHoursBefore, LabelRemindCelebrationHoursBeforeIntervalInfo, RemindCelebrationHoursBeforeInterval);
      setInterval(EditRemindCelebrationEveryMinutes, LabelRemindCelebrationEveryMinutesIntervalInfo, RemindCelebrationEveryMinutesInterval);
      setInterval(EditAutoLockSessionTimeOut, LabelAutoLockSessionTimeOutIntervalInfo, RemindAutoLockTimeOutInterval);
      setInterval(EditMaxYearsInterval, LabelMaxYearsIntervalInfo, GenerateIntervalInterval);
      setInterval(EditCalendarLineSpacing, LabelCalendarLineSpacingInfo, LineSpacingInterval);
      void setInterval(NumericUpDown control, Label label, (int, int, int, int) interval)
      {
        control.Minimum = interval.Item1;
        control.Maximum = interval.Item2;
        control.Value = interval.Item3;
        control.Increment = interval.Item4;
        if (label != null) label.Text = interval.Item1 + " - " + interval.Item2 + " (" + interval.Item3 + ")";
      }
    }

    /// <summary>
    /// Load export file formats.
    /// </summary>
    private void LoadExportFileFormats()
    {
      EditDataExportFileFormat.Fill(Program.GridExportTargets, Settings.ExportDataPreferredTarget);
      EditImageExportFileFormat.Fill(Program.ImageExportTargets, Settings.ExportImagePreferredTarget);
    }

    /// <summary>
    /// Load reminder boxes locations.
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
    /// Load week days.
    /// </summary>
    private void LoadDays()
    {
      foreach ( var value in Enums.GetValues<DayOfWeek>() )
      {
        var item = new DayOfWeekItem() { Text = AppTranslations.DayOfWeek.GetLang(value), Day = value };
        EditShabatDay.Items.Add(item);
        if ( (DayOfWeek)Settings.ShabatDay == value )
          EditShabatDay.SelectedItem = item;
      }
    }

    /// <summary>
    /// Load Torah events.
    /// </summary>
    private void LoadEvents()
    {
      foreach ( var value in TorahCelebrations.MajorEvents )
        SystemManager.TryCatch(() =>
          {
            var item = new TorahEventItem() { Text = AppTranslations.TorahEvent.GetLang(value), Event = value };
            int index = SelectRemindEventsBefore.Items.Add(item);
            if ( (bool)Settings["TorahEventRemind" + value.ToString()] )
              SelectRemindEventsBefore.SetItemChecked(index, true);
            index = SelectRemindEventsDay.Items.Add(item);
            if ( (bool)Settings["TorahEventRemindDay" + value.ToString()] )
              SelectRemindEventsDay.SetItemChecked(index, true);
          });
    }

    /// <summary>
    /// Load fonts names.
    /// </summary>
    private void LoadFonts()
    {
      foreach ( var value in new InstalledFontCollection().Families.OrderBy(f => f.Name) )
        if ( MonoSpacedFonts.Contains(value.Name.ToLower()) )
        {
          int index = EditTextReportFontName.Items.Add(value.Name);
          if ( value.Name == Settings.FontName )
            EditTextReportFontName.SelectedIndex = index;
        }
    }

    /// <summary>
    /// Load hotkeys.
    /// </summary>
    private void LoadHotKeys()
    {
      SelectGlobalHotKeyPopupMainFormKey.Items.Clear();
      foreach ( var item in AvailableHotKeyKeys )
        SelectGlobalHotKeyPopupMainFormKey.Items.Add(item);
    }

    /// <summary>
    /// Initialize HotKey.
    /// </summary>
    private void InitHotKeyControls()
    {
      MainForm.Instance.SetGlobalHotKey(true);
      InitialHotKeyEnabled = EditGlobalHotKeyPopupMainFormEnabled.Checked;
      EditGlobalHotKeyPopupMainFormShift.Checked = Globals.BringToFrontApplicationHotKey.Shift;
      EditGlobalHotKeyPopupMainFormCtrl.Checked = Globals.BringToFrontApplicationHotKey.Control;
      EditGlobalHotKeyPopupMainFormAlt.Checked = Globals.BringToFrontApplicationHotKey.Alt;
      EditGlobalHotKeyPopupMainFormWin.Checked = Globals.BringToFrontApplicationHotKey.Windows;
      SelectGlobalHotKeyPopupMainFormKey.SelectedIndex = SelectGlobalHotKeyPopupMainFormKey.FindString(Globals.BringToFrontApplicationHotKey.Key.ToString());
      CheckHotKeyCombination(null);
    }

    /// <summary>
    /// Check HotKey combination.
    /// </summary>
    private void CheckHotKeyCombination(Action action)
    {
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

}
