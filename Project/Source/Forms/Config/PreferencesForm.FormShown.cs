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
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
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
        MainForm.Instance.ActionShowCelebrationsNotice_Click(null, null);
        Settings.TorahEventsCountAsMoon = DisplayManager.QueryYesNo(AppTranslations.AskToUseMoonOmer.GetLang());
        MainForm.Instance.ActionShowShabatNotice_Click(null, null);
        if ( DisplayManager.QueryYesNo(AppTranslations.AskToSetupPersonalShabat.GetLang()) )
          ActionUsePersonalShabat_LinkClicked(null, null);
      }
      UpdateLanguagesButtons();
      LoadSettings();
      foreach ( var item in EditFontName.Items )
        if ( (string)item == Settings.FontName )
        {
          EditFontName.SelectedItem = item;
          break;
        }
      foreach ( KeyValuePair<DataExportTarget, string> item in EditDataExportFileFormat.Items )
        if ( item.Key == Settings.ExportDataPreferredTarget)
        {
          EditDataExportFileFormat.SelectedItem = item;
          break;
        }
      EditTimeZone.Text = Settings.GetGPSText();
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
          throw new NotImplementedExceptionEx(Settings.TrayIconClickOpen);
      }
      EditStartWithWindows.Checked = SystemManager.StartWithWindowsUserRegistry;
      EditLogEnabled.Enabled = DebugManager.Enabled;
      EditVacuumAtStartup_CheckedChanged(null, null);
      EditCheckUpdateAtStartup_CheckedChanged(null, null);
      EditBalloon_CheckedChanged(null, null);
      EditAutoRegenerate_CheckedChanged(null, null);
      EditRemindAutoLock_CheckedChanged(null, null);
      EditRemindShabat_ValueChanged(null, null);
      EditTimerEnabled_CheckedChanged(null, null);
      EditUseColors_CheckedChanged(null, null);
      ActiveControl = ActionClose;
      ActionResetSettings.TabStop = false;
      IsReady = true;
    }

  }

}
