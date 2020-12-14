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

    static public (int, int, int, int) CheckUpdateInterval = (1, 28, 7, 1);
    static public (int, int, int, int) DateBookmarksCountInterval = (0, 30, 15, 1);
    static public (int, int, int, int) PrintingMarginInterval = (10, 150, 50, 10);
    static public (int, int, int, int) PrintPageCountWarningInterval = (0, 100, 20, 10);
    static public (int, int, int, int) SaveImageCountWarningInterval = (25, 300, 50, 25);
    static public (int, int, int, int) LoomingDelayInterval = (500, 5000, 1000, 250);
    static public (int, int, int, int) GenerateIntervalInterval = (10, 200, 120, 5);
    static public (int, int, int, int) RemindShabatHoursBeforeInterval = (1, 24, 6, 1);
    static public (int, int, int, int) RemindShabatEveryMinutesInterval = (5, 120, 15, 5);
    static public (int, int, int, int) RemindCelebrationDaysBeforeInterval = (1, 60, 14, 1);
    static public (int, int, int, int) RemindCelebrationHoursBeforeInterval = (1, 48, 24, 1);
    static public (int, int, int, int) RemindCelebrationEveryMinutesInterval = (5, 120, 15, 5);
    static public (int, int, int, int) RemindAutoLockTimeOutInterval = (10, 300, 30, 5);

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
      if ( result ) CalendarDates.Instance.Clear();
      return result;
    }

  }

}
