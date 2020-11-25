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
/// <edited> 2020-11 </edited>
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
  public partial class PreferencesForm : Form
  {

    const int CheckUpdateMin = 1;
    const int CheckUpdateMax = 28;
    const int CheckUpdateDefault = 7;
    const int LoomingDelayMin = 500;
    const int LoomingDelayMax = 5000;
    const int LoomingDelayDefault = 1000;
    const int RemindShabatHoursBeforeMin = 1;
    const int RemindShabatHoursBeforeMax = 24;
    const int RemindShabatHoursBeforeDefault = 6;
    const int RemindShabatEveryMinutesMin = 5;
    const int RemindShabatEveryMinutesMax = 120;
    const int RemindShabatEveryMinutesDefault = 15;
    const int RemindCelebrationDaysBeforeMin = 1;
    const int RemindCelebrationDaysBeforeMax = 60;
    const int RemindCelebrationDaysBeforeDefault = 14;
    const int RemindCelebrationHoursBeforeMin = 1;
    const int RemindCelebrationHoursBeforeMax = 48;
    const int RemindCelebrationHoursBeforeDefault = 24;
    const int RemindCelebrationEveryMinutesMin = 5;
    const int RemindCelebrationEveryMinutesMax = 120;
    const int RemindCelebrationEveryMinutesDefault = 15;
    const int RemindAutoLockTimeOutMin = 10;
    const int RemindAutoLockTimeOutMax = 300;
    const int RemindAutoLockTimeOutDefault = 30;

    static private readonly Properties.Settings Settings = Program.Settings;

    static private bool LanguageChanged;
    static private bool DoReset;
    static public bool Reseted { get; private set; }

    static public bool Run()
    {
      Reseted = false;
      Language lang = Settings.LanguageSelected;
      var form = new PreferencesForm();
      if ( !MainForm.Instance.Visible )
        form.ShowInTaskbar = true;
      form.ShowDialog();
      while ( LanguageChanged || DoReset )
      {
        LanguageChanged = false;
        DoReset = false;
        form = new PreferencesForm();
        if ( !MainForm.Instance.Visible )
          form.ShowInTaskbar = true;
        form.ShowDialog();
      }
      MainForm.Instance.InitializeDialogsDirectory();
      bool result = Reseted
                 || form.OldShabatDay != Settings.ShabatDay
                 || form.OldLatitude != Settings.GPSLatitude
                 || form.OldLongitude != Settings.GPSLongitude
                 || form.OldUseMoonDays != Settings.TorahEventsCountAsMoon
                 || form.OldTimeZone != Settings.TimeZone
                 || lang != Settings.LanguageSelected;
      if ( !result && form.MustRefreshMonthView )
        MainForm.Instance.UpdateCalendarMonth(true);
      SystemManager.TryCatch(() =>
      {
        MainForm.Instance.CurrentGPSLatitude = (float)XmlConvert.ToDouble(Settings.GPSLatitude);
        MainForm.Instance.CurrentGPSLongitude = (float)XmlConvert.ToDouble(Settings.GPSLongitude);
      });
      if (result ) CalendarDates.Instance.Clear();
      return result;
    }

  }

}
