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
/// <created> 2019-01 </created>
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private void EnableReminderTimer(bool calltimer = true)
  {
    TimerResumeReminder.Enabled = false;
    ActionResetReminder.Enabled = true;
    ActionEnableReminder.Visible = false;
    ActionDisableReminder.Visible = true;
    ActionEnableReminder.Enabled = false;
    ActionDisableReminder.Enabled = Settings.AllowSuspendReminder;
    MenuResetReminder.Enabled = true;
    MenuEnableReminder.Visible = false;
    MenuDisableReminder.Visible = true;
    MenuEnableReminder.Enabled = false;
    MenuDisableReminder.Enabled = Settings.AllowSuspendReminder;
    IsReminderPaused = false;
    if ( calltimer )
    {
      ClearLists();
      TimerReminder_Tick(null, null);
    }
    else
      UpdateTitles(true);
  }

  private void DisableReminderTimer()
  {
    try
    {
      MenuTray.Enabled = false;
      var delay = SelectSuspendDelayForm.Run();
      if ( delay is null ) return;
      IsReminderPaused = true;
      ActionResetReminder.Enabled = false;
      ActionEnableReminder.Visible = true;
      ActionDisableReminder.Visible = false;
      ActionEnableReminder.Enabled = true;
      ActionDisableReminder.Enabled = false;
      MenuResetReminder.Enabled = false;
      MenuEnableReminder.Visible = true;
      MenuDisableReminder.Visible = false;
      MenuEnableReminder.Enabled = true;
      MenuDisableReminder.Enabled = false;
      ClearLists();
      UpdateTitles(true);
      if ( delay > 0 )
      {
        TimerResumeReminder.Interval = delay.Value * 60 * 1000;
        TimerResumeReminder.Start();
      }
    }
    finally
    {
      MenuTray.Enabled = true;
    }
  }

}
