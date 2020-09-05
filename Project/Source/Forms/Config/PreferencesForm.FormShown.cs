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
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm : Form
  {

    private void DoFormShown(object sender, EventArgs e)
    {
      if ( Settings.GPSLatitude.IsNullOrEmpty() || Settings.GPSLongitude.IsNullOrEmpty() )
        ActionGetGPS_LinkClicked(null, null);
      if ( Settings.FirstLaunch )
      {
        Settings.FirstLaunchV4 = false;
        Settings.FirstLaunch = false;
        Settings.Save();
        MainForm.Instance.CelebrationsNoticeForm.Popup(this, true);
        Settings.TorahEventsCountAsMoon = DisplayManager.QueryYesNo(Translations.AskToUseMoonOmer.GetLang());
        MainForm.Instance.ShabatNoticeForm.Popup(this, true);
        if ( DisplayManager.QueryYesNo(Translations.AskToSetupPersonalShabat.GetLang()) )
          ActionUsePersonalShabat_LinkClicked(null, null);
      }
      UpdateLanguagesButtons();
      foreach ( var item in EditFontName.Items )
        if ( (string)item == Settings.FontName )
        {
          EditFontName.SelectedItem = item;
          break;
        }
      LoadSettings();
      EditTimeZone.Text = Program.GPSText;
      switch ( Settings.TrayIconClickOpen )
      {
        case TrayIconClickOpen.MainForm:
          SelectOpenMainForm.Select();
          break;
        case TrayIconClickOpen.NavigationForm:
          SelectOpenNavigationForm.Select();
          break;
        case TrayIconClickOpen.NextCelebrationsForm:
          SelectOpenNextCelebrationsForm.Select();
          break;
        default:
          throw new NotImplementedExceptionEx(Settings.TrayIconClickOpen.ToStringFull());
      }
      EditRemindShabat_ValueChanged(null, null);
      EditTimerEnabled_CheckedChanged(null, null);
      EditBalloon_CheckedChanged(null, null);
      SelectOpenNavigationForm_CheckedChanged(null, null);
      EditLogEnabled.Enabled = DebugManager.Enabled;
      ActiveControl = ActionClose;
      ActionResetSettings.TabStop = false;
      IsReady = true;
    }

  }

}
