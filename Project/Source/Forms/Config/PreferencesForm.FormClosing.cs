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
using System.Xml;
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
      if ( SelectOpenMainForm.Checked )
        Settings.TrayIconClickOpen = TrayIconClickOpen.MainForm;
      else
      if ( SelectOpenNavigationForm.Checked )
        Settings.TrayIconClickOpen = TrayIconClickOpen.NavigationForm;
      else
      if ( SelectOpenNextCelebrationsForm.Checked )
        Settings.TrayIconClickOpen = TrayIconClickOpen.NextCelebrationsForm;
      Settings.ShabatDay = (int)( (DayOfWeekItem)EditShabatDay.SelectedItem ).Day;
      Settings.ReminderCelebrationsInterval = (int)EditReminderCelebrationsDaysBefore.Value;
      for ( int index = 0; index < EditEvents.Items.Count; index++ )
        SystemManager.TryCatch(() =>
        {
          string name = "TorahEventRemind" + ( (TorahEventItem)EditEvents.Items[index] ).Event.ToString();
          Settings[name] = EditEvents.GetItemChecked(index);
        });
      for ( int index = 0; index < EditEventsDay.Items.Count; index++ )
        SystemManager.TryCatch(() =>
        {
          string name = "TorahEventRemindDay" + ( (TorahEventItem)EditEventsDay.Items[index] ).Event.ToString();
          Settings[name] = EditEventsDay.GetItemChecked(index);
        });
      UpdateSettings();
      Settings.MonthViewFontSize = (int)EditMonthViewFontSize.Value;
      Settings.Save();
      SystemManager.TryCatch(() => { Globals.BringToFrontApplicationHotKey.Active = Settings.GlobalHotKeyPopupMainFormEnabled; });
    }

  }

}
