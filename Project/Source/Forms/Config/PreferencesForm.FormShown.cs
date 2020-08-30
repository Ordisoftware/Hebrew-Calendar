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
      if ( Program.Settings.GPSLatitude == "" || Program.Settings.GPSLongitude == "" )
        ActionGetGPS_LinkClicked(null, null);
      if ( Program.Settings.FirstLaunch )
      {
        Program.Settings.FirstLaunchV4 = false;
        Program.Settings.FirstLaunch = false;
        Program.Settings.Save();
        Program.CelebrationsNoticeForm.ShowDialog();
        Program.Settings.TorahEventsCountAsMoon = DisplayManager.QueryYesNo(Translations.AskToUseMoonOmer.GetLang());
        Program.ShabatNoticeForm.ShowDialog();
        if ( DisplayManager.QueryYesNo(Translations.AskToSetupPersonalShabat.GetLang()) )
          ActionUsePersonalShabat_LinkClicked(null, null);
      }
      UpdateLanguagesButtons();
      foreach ( var item in EditFontName.Items )
        if ( (string)item == Program.Settings.FontName )
        {
          EditFontName.SelectedItem = item;
          break;
        }
      LoadSettings();
      EditTimeZone.Text = Program.ToStringGPS();
      switch ( Program.Settings.TrayIconClickOpen )
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
          throw new NotImplementedException(Program.Settings.TrayIconClickOpen.ToString());
      }
      EditRemindShabat_ValueChanged(null, null);
      EditTimerEnabled_CheckedChanged(null, null);
      EditBalloon_CheckedChanged(null, null);
      SelectOpenNavigationForm_CheckedChanged(null, null);
      ActiveControl = ActionClose;
      IsReady = true;
    }

  }

}
