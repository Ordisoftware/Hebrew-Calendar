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
/// <edited> 2020-04 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm : Form
  {

    const int RemindShabatHoursBeforeMin = 1;
    const int RemindShabatHoursBeforeMax = 12;
    const int RemindShabatHoursBeforeValue = 6;
    const int RemindShabatEveryMinutesMin = 5;
    const int RemindShabatEveryMinutesMax = 60;
    const int RemindShabatEveryMinutesValue = 15;
    const int RemindCelebrationBeforeMin = 1;
    const int RemindCelebrationBeforeMax = 60;
    const int RemindCelebrationBeforeValue = 7;
    const int RemindCelebrationHoursBeforeMin = 1;
    const int RemindCelebrationHoursBeforeMax = 24;
    const int RemindCelebrationHoursBeforeValue = 6;
    const int RemindCelebrationEveryMinutesMin = 5;
    const int RemindCelebrationEveryMinutesMax = 60;
    const int RemindCelebrationEveryMinutesValue = 15;
    const int RemindAutoLockTimeOutMin = 5;
    const int RemindAutoLockTimeOutMax = 60;
    const int RemindAutoLockTimeOutValue = 30;

    static private bool IsCenteredToScreen;
    static private bool LanguageChanged;
    static private bool DoReset;
    static public bool Reseted { get; private set; }

    static public bool Run(bool isCenteredToScreen = false)
    {
      Reseted = false;
      IsCenteredToScreen = isCenteredToScreen;
      string lang = Program.Settings.Language;
      var form = new PreferencesForm();
      if ( !MainForm.Instance.Visible )
        form.ShowInTaskbar = true;
      form.ShowDialog();
      while ( LanguageChanged || DoReset )
      {
        NavigationForm.Instance.Close();
        LanguageChanged = false;
        DoReset = false;
        form = new PreferencesForm();
        if ( !MainForm.Instance.Visible )
          form.ShowInTaskbar = true;
        form.ShowDialog();
      }
      bool result = Reseted
                 || form.OldShabatDay != Program.Settings.ShabatDay
                 || form.OldLatitude != Program.Settings.GPSLatitude
                 || form.OldLongitude != Program.Settings.GPSLongitude
                 || form.OldReminderUseColors != Program.Settings.UseColors
                 || form.OldReminderShabatDayColor != Program.Settings.EventColorShabat
                 || form.OldReminderCurrentDayColor != Program.Settings.EventColorTorah
                 || form.OldUseMoonDays != Program.Settings.TorahEventsCountAsMoon
                 || form.OldTimeZone != Program.Settings.TimeZone
                 || lang != Program.Settings.Language;
      if ( !result && form.MustRefreshMonthView )
        MainForm.Instance.UpdateCalendarMonth(true);
      return result;
    }

  }

}
