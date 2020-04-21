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
/// <edited> 2016-04 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.HebrewCalendar.Properties;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide Settings helper.
  /// </summary>
  static internal class SettingsHelper
  {

    /// <summary>
    /// Indicate the main form instance.
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
      MainForm.SetView(ViewMode.Month);
      settings.Store();
    }

    /// <summary>
    /// The Settings extension method that retrieves the given settings.
    /// </summary>
    /// <param name="settings">The settings to act on.</param>
    static internal void Retrieve(this Settings settings)
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
      MainForm.EditConfirmClosing.Checked = settings.ConfirmClosing;
      MainForm.EditShowTips.Checked = settings.ShowTips;
      MainForm.EditESCtoExit.Checked = settings.ESCtoExit;
    }

    /// <summary>
    /// The Settings extension method that stores the given settings.
    /// </summary>
    /// <param name="settings">The settings to act on.</param>
    static internal void Store(this Settings settings)
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
      settings.ConfirmClosing = MainForm.EditConfirmClosing.Checked;
      settings.ShowTips = MainForm.EditShowTips.Checked;
      settings.ESCtoExit = MainForm.EditESCtoExit.Checked;
      settings.Save();
    }

  }

}
