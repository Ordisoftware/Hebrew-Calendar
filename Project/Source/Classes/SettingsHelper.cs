/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2016-04 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCalendar.Properties;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide Settings helper.
  /// </summary>
  static internal class SettingsHelper
  {

    /// <summary>
    /// Indicate the main form.
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
      MainForm.EditESCtoExit.Checked = false;
      MainForm.EditShowTips.Checked = true;
      MainForm.SetView(ViewModeType.Month);
      settings.Store();
    }

    /// <summary>
    /// The Settings extension method that retrieves the given settings.
    /// </summary>
    /// <param name="settings">The settings to act on.</param>
    static internal void Retrieve(this Settings settings)
    {
      var area = SystemInformation.WorkingArea;
      if ( settings.MainFormLeft > area.Left && settings.MainFormLeft < area.Width )
        MainForm.Left = settings.MainFormLeft;
      if ( settings.MainFormTop > area.Right && settings.MainFormTop < area.Height )
        MainForm.Top = settings.MainFormTop;
      if ( settings.MainFormWidth > MainForm.MinimumSize.Width && settings.MainFormWidth < area.Width )
        MainForm.Width = settings.MainFormWidth;
      if ( settings.MainFormHeight > MainForm.MinimumSize.Height && settings.MainFormHeight < area.Height )
        MainForm.Height = settings.MainFormHeight;
      MainForm.EditScreenNone.Checked = settings.MainFormPosition == ControlLocation.Loose;
      MainForm.EditScreenTopLeft.Checked = settings.MainFormPosition == ControlLocation.TopLeft;
      MainForm.EditScreenTopRight.Checked = settings.MainFormPosition == ControlLocation.TopRight;
      MainForm.EditScreenBottomLeft.Checked = settings.MainFormPosition == ControlLocation.BottomLeft;
      MainForm.EditScreenBottomRight.Checked = settings.MainFormPosition == ControlLocation.BottomRight;
      MainForm.EditScreenCenter.Checked = settings.MainFormPosition == ControlLocation.Center;
      MainForm.EditScreenPosition_Click(null, null);
      MainForm.WindowState = settings.MainFormState;
      MainForm.EditConfirmClosing.Checked = settings.ConfirmClosing;
      MainForm.EditESCtoExit.Checked = settings.ESCtoExit;
      MainForm.EditShowTips.Checked = settings.ShowTips;
      PreferencesForm.Instance.PanelTopColor.BackColor = settings.NavigateTopColor;
      PreferencesForm.Instance.PanelMiddleColor.BackColor = settings.NavigateMiddleColor;
      PreferencesForm.Instance.PanelBottomColor.BackColor = settings.NavigateBottomColor;
      PreferencesForm.Instance.PanelTextColor.BackColor = settings.TextColor;
      PreferencesForm.Instance.PanelBackColor.BackColor = settings.TextBackground;
    }

    /// <summary>
    /// The Settings extension method that stores the given settings.
    /// </summary>
    /// <param name="settings">The settings to act on.</param>
    static internal void Store(this Settings settings)
    {
      var winState = MainForm.WindowState;
      if ( winState != FormWindowState.Minimized ) settings.MainFormState = winState;
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
      settings.ConfirmClosing = MainForm.EditConfirmClosing.Checked;
      settings.ESCtoExit = MainForm.EditESCtoExit.Checked;
      settings.ShowTips = MainForm.EditShowTips.Checked;
      settings.NavigateTopColor = PreferencesForm.Instance.PanelTopColor.BackColor;
      settings.NavigateMiddleColor = PreferencesForm.Instance.PanelMiddleColor.BackColor;
      settings.NavigateBottomColor = PreferencesForm.Instance.PanelBottomColor.BackColor;
      settings.TextColor = PreferencesForm.Instance.PanelTextColor.BackColor;
      settings.TextBackground = PreferencesForm.Instance.PanelBackColor.BackColor;
      settings.Save();
    }

  }

}
