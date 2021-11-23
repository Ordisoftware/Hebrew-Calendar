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
/// <edited> 2021-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using Ordisoftware.Hebrew.Calendar.Properties;

/// <summary>
/// Provides Settings helper.
/// </summary>
static class SettingsHelper
{

  static private bool Mutex;

  /// <summary>
  /// Indicates the main form instance.
  /// </summary>
  static private readonly MainForm MainForm = MainForm.Instance;

  /// <summary>
  /// The Settings extension method that restores the main form settings.
  /// </summary>
  /// <param name="settings">The settings to act on.</param>
  static internal void RestoreMainForm(this Settings settings)
  {
    MainForm.Width = MainForm.MinimumSize.Width;
    MainForm.Height = MainForm.MinimumSize.Height;
    MainForm.WindowState = FormWindowState.Normal;
    MainForm.CenterToScreen();
    MainForm.EditScreenNone.Checked = false;
    MainForm.EditScreenTopLeft.Checked = false;
    MainForm.EditScreenTopRight.Checked = false;
    MainForm.EditScreenBottomLeft.Checked = false;
    MainForm.EditScreenBottomRight.Checked = false;
    MainForm.EditScreenCenter.Checked = true;
    MainForm.EditConfirmClosing.Checked = true;
    MainForm.EditShowTips.Checked = true;
    MainForm.EditESCtoExit.Checked = true;
    MainForm.EditSoundsEnabled.Checked = true;
    DisplayManager.AdvancedFormUseSounds = true;
    MainForm.EditUseAdvancedDialogBoxes.Checked = true;
    DisplayManager.FormStyle = MessageBoxFormStyle.Advanced;
    MainForm.EditShowSuccessDialogs.Checked = false;
    DisplayManager.ShowSuccessDialogs = false;
    settings.ReminderBoxSoundSource = SoundSource.Dialog;
    settings.ReminderBoxSoundDialog = MessageBoxIcon.Asterisk;
    settings.ApplicationVolume = 100;
    MediaMixer.SetApplicationVolume(Globals.ProcessId, settings.ApplicationVolume);
    MainForm.SetView(ViewMode.Month);
    settings.Store();
  }

  /// <summary>
  /// The Settings extension method that retrieves the given settings.
  /// </summary>
  /// <param name="settings">The settings to act on.</param>
  static internal void Retrieve(this Settings settings)
  {
    if ( Mutex ) return;
    Mutex = true;
    try
    {
      var area = SystemInformation.WorkingArea;
      if ( settings.MainFormLeft >= area.Left && settings.MainFormLeft <= area.Width )
        MainForm.Left = settings.MainFormLeft;
      else
        MainForm.Left = area.Left;
      if ( settings.MainFormTop >= area.Top && settings.MainFormTop <= area.Height )
        MainForm.Top = settings.MainFormTop;
      else
        MainForm.Top = area.Top;
      if ( settings.MainFormWidth >= MainForm.MinimumSize.Width && settings.MainFormWidth <= area.Width )
        MainForm.Width = settings.MainFormWidth;
      else
        MainForm.Width = MainForm.MinimumSize.Width;
      if ( settings.MainFormHeight >= MainForm.MinimumSize.Height && settings.MainFormHeight <= area.Height )
        MainForm.Height = settings.MainFormHeight;
      else
        MainForm.Height = MainForm.MinimumSize.Height;
      MainForm.EditScreenNone.Checked = settings.MainFormPosition == ControlLocation.Loose;
      MainForm.EditScreenTopLeft.Checked = settings.MainFormPosition == ControlLocation.TopLeft;
      MainForm.EditScreenTopRight.Checked = settings.MainFormPosition == ControlLocation.TopRight;
      MainForm.EditScreenBottomLeft.Checked = settings.MainFormPosition == ControlLocation.BottomLeft;
      MainForm.EditScreenBottomRight.Checked = settings.MainFormPosition == ControlLocation.BottomRight;
      MainForm.EditScreenCenter.Checked = settings.MainFormPosition == ControlLocation.Center;
      MainForm.EditScreenPosition_Click(null, null);
      MainForm.WindowState = settings.MainFormState;
      //
      MainForm.EditConfirmClosing.Checked = settings.ConfirmClosing;
      MainForm.EditShowTips.Checked = settings.ShowTips;
      MainForm.EditESCtoExit.Checked = settings.ESCtoExit;
      MainForm.EditSoundsEnabled.Checked = settings.SoundsEnabled;
      MainForm.EditUseAdvancedDialogBoxes.Checked = settings.AdvancedDialogBoxes;
      MainForm.EditShowSuccessDialogs.Checked = settings.ShowSuccessDialogs;
      DisplayManager.ShowSuccessDialogs = settings.ShowSuccessDialogs;
      MainForm.EditDialogBoxesSettings_CheckedChanged(null, null);
      //
      if ( settings.AutoOpenExportedFile && settings.AutoOpenExportFolder )
        settings.AutoOpenExportFolder = false;
    }
    finally
    {
      Mutex = false;
    }
  }

  /// <summary>
  /// The Settings extension method that stores the given settings.
  /// </summary>
  /// <param name="settings">The settings to act on.</param>
  static internal void Store(this Settings settings)
  {
    if ( Mutex ) return;
    Mutex = true;
    try
    {
      var winState = MainForm.WindowState;
      if ( winState != FormWindowState.Minimized )
        settings.MainFormState = winState;
      if ( winState == FormWindowState.Normal )
      {
        settings.MainFormLeft = MainForm.Left;
        settings.MainFormTop = MainForm.Top;
        settings.MainFormWidth = MainForm.Width;
        settings.MainFormHeight = MainForm.Height;
      }
      if ( MainForm.EditScreenNone.Checked ) settings.MainFormPosition = ControlLocation.Loose;
      if ( MainForm.EditScreenTopLeft.Checked ) settings.MainFormPosition = ControlLocation.TopLeft;
      if ( MainForm.EditScreenTopRight.Checked ) settings.MainFormPosition = ControlLocation.TopRight;
      if ( MainForm.EditScreenBottomLeft.Checked ) settings.MainFormPosition = ControlLocation.BottomLeft;
      if ( MainForm.EditScreenBottomRight.Checked ) settings.MainFormPosition = ControlLocation.BottomRight;
      if ( MainForm.EditScreenCenter.Checked ) settings.MainFormPosition = ControlLocation.Center;
      //
      settings.ConfirmClosing = MainForm.EditConfirmClosing.Checked;
      settings.ShowTips = MainForm.EditShowTips.Checked;
      settings.ESCtoExit = MainForm.EditESCtoExit.Checked;
      settings.SoundsEnabled = MainForm.EditSoundsEnabled.Checked;
      settings.AdvancedDialogBoxes = MainForm.EditUseAdvancedDialogBoxes.Checked;
      settings.ShowSuccessDialogs = MainForm.EditShowSuccessDialogs.Checked;
      SystemManager.TryCatch(settings.Save);
    }
    finally
    {
      Mutex = false;
    }
  }

  /// <summary>
  /// Sets the upgrade flags off.
  /// </summary>
  static internal void SetUpgradeFlagsOff(this Settings settings)
  {
    settings.UpgradeResetRequiredV3_0 = false;
    settings.UpgradeResetRequiredV3_6 = false;
    settings.UpgradeResetRequiredV4_1 = false;
    settings.UpgradeResetRequiredV5_10 = false;
    settings.UpgradeRequired = false;
  }

  /// <summary>
  /// Sets the first and upgrade flags off.
  /// </summary>
  static internal void SetFirstAndUpgradeFlagsOff(this Settings settings)
  {
    settings.SetUpgradeFlagsOff();
    settings.FirstLaunch = false;
    settings.FirstLaunchV4 = false;
    settings.FirstLaunchV7_0 = false;
  }

  /// <summary>
  /// Returns a string representing the GPS location.
  /// </summary>
  static internal string GetGPSText(this Settings settings)
  {
    var builder = new StringBuilder();
    builder.Append("• ").AppendLine(settings.GPSCountry);
    builder.Append("• ").Append(settings.GPSCity);
    foreach ( var item in TimeZoneInfo.GetSystemTimeZones() )
      if ( item.Id == settings.TimeZone )
      {
        builder.AppendLine();
        builder.Append(item.DisplayName);
        break;
      }
    return builder.ToString();
  }

  static internal string GetExportDirectory(this Settings settings)
  {
    string directory = settings.ExportFolder;
    if ( directory == "%USER_APP_DOCUMENTS%" )
      directory = Globals.UserDocumentsFolderPath;
    return directory;
  }

}
