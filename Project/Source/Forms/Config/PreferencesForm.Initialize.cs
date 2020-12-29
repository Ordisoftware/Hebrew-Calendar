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
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using System.Drawing.Text;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm
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
      EditRemindShabat_ValueChanged(null, null);
      EditTimerEnabled_CheckedChanged(null, null);
      EditUseColors_CheckedChanged(null, null);
      EditLogEnabled_CheckedChanged(null, null);
      ActiveControl = ActionClose;
      ActionResetSettings.TabStop = false;
      IsReady = true;
    }

    /// <summary>
    /// Load edit intervals.
    /// </summary>
    private void LoadEditIntervals()
    {
      setInterval(EditCheckUpdateAtStartupInterval, LabelCheckUpdateAtStartupInfo, CheckUpdateInterval);
      setInterval(EditVacuumAtStartupInterval, LabelOptimizeDatabaseIntervalInfo, CheckUpdateInterval);
      setInterval(EditDateBookmarksCount, LabelDateBookmarksCountIntervalInfo, DateBookmarksCountInterval);
      setInterval(EditPrintingMargin, LabelPrintingMarginIntervalInfo, PrintingMarginInterval);
      setInterval(EditPrintPageCountWarning, LabelPrintPageCountWarningIntervalInfo, PrintPageCountWarningInterval);
      setInterval(EditSaveImageCountWarning, LabelSaveImageCountWarningIntervalInfo, SaveImageCountWarningInterval);
      setInterval(EditBalloonLoomingDelay, LabelLoomingDelayIntervalInfo, LoomingDelayInterval);
      setInterval(EditReminderCelebrationsDaysBefore, LabelReminderCelebrationsIntervalInfo, RemindCelebrationDaysBeforeInterval);
      setInterval(EditRemindShabatHoursBefore, LabelRemindShabatHoursBeforeIntervalInfo, RemindShabatHoursBeforeInterval);
      setInterval(EditRemindShabatEveryMinutes, LabelRemindShabatEveryMinutesIntervalInfo, RemindShabatEveryMinutesInterval);
      setInterval(EditRemindCelebrationHoursBefore, LabelRemindCelebrationHoursBeforeIntervalInfo, RemindCelebrationHoursBeforeInterval);
      setInterval(EditRemindCelebrationEveryMinutes, LabelRemindCelebrationEveryMinutesIntervalInfo, RemindCelebrationEveryMinutesInterval);
      setInterval(EditAutoLockSessionTimeOut, LabelAutoLockSessionTimeOutIntervalInfo, RemindAutoLockTimeOutInterval);
      setInterval(EditMaxYearsInterval, LabelMaxYearsIntervalInfo, GenerateIntervalInterval);
      void setInterval(NumericUpDown control, Label label, (int, int, int, int) interval)
      {
        control.Minimum = interval.Item1;
        control.Maximum = interval.Item2;
        control.Value = interval.Item3;
        control.Increment = interval.Item4;
        label.Text = interval.Item1 + " - " + interval.Item2 + " (" + interval.Item3 + ")";
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
    /// Load week days.
    /// </summary>
    private void LoadDays()
    {
      foreach ( DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)) )
      {
        var item = new DayOfWeekItem() { Text = AppTranslations.DayOfWeek.GetLang(day), Day = day };
        EditShabatDay.Items.Add(item);
        if ( (DayOfWeek)Settings.ShabatDay == day )
          EditShabatDay.SelectedItem = item;
      }
    }

    /// <summary>
    /// Load Torah events.
    /// </summary>
    private void LoadEvents()
    {
      foreach ( TorahEvent value in Enum.GetValues(typeof(TorahEvent)) )
        if ( value != TorahEvent.None && value <= TorahEvent.SoukotD8 ) // TODO change when manage others
          SystemManager.TryCatch(() =>
          {
            var item = new TorahEventItem() { Text = AppTranslations.TorahEvent.GetLang(value), Event = value };
            int index = EditEvents.Items.Add(item);
            if ( (bool)Settings["TorahEventRemind" + value.ToString()] )
              EditEvents.SetItemChecked(index, true);
            index = EditEventsDay.Items.Add(item);
            if ( (bool)Settings["TorahEventRemindDay" + value.ToString()] )
              EditEventsDay.SetItemChecked(index, true);
          });
    }

    /// <summary>
    /// Load fonts names.
    /// </summary>
    private void LoadFonts()
    {
      foreach ( var item in new InstalledFontCollection().Families.OrderBy(f => f.Name) )
        if ( MonoSpacedFonts.Contains(item.Name.ToLower()) )
        {
          int index = EditFontName.Items.Add(item.Name);
          if ( item.Name == Settings.FontName )
            EditFontName.SelectedIndex = index;
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
      var temp = ActiveControl;
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
        IsReady = true;
      }
      catch ( Exception ex )
      {
        LabelHotKeyStatus.Text = ex.Message;
        IsReady = false;
        EditGlobalHotKeyPopupMainFormEnabled.Checked = false;
        EditGlobalHotKeyPopupMainFormEnabled.Enabled = false;
        IsReady = true;
      }
      finally
      {
        PanelHotKey.Enabled = true;
        ActiveControl = temp;
      }
    }

  }

}
