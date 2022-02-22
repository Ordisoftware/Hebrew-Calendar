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
/// <created> 2016-04 </created>
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.Xml;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class PreferencesForm
{

  static public int TabIndexApplication { get; private set; }
  static public int TabIndexCelebrations { get; private set; }
  static public int TabIndexGeneration { get; private set; }
  static public int TabIndexMonthView { get; private set; }
  static public int TabIndexNavigation { get; private set; }
  static public int TabIndexPaths { get; private set; }
  static public int TabIndexPrint { get; private set; }
  static public int TabIndexReminder { get; private set; }
  static public int TabIndexShabat { get; private set; }
  static public int TabIndexStartup { get; private set; }
  static public int TabIndexTextReport { get; private set; }
  static public int TabIndexTrayIcon { get; private set; }
  static public int TabIndexParashah { get; private set; }
  static public int TabIndexWeather { get; private set; }

  // Mono spaced fonts list
  static private readonly string[] MonoSpacedFonts =
  {
    "andalé mono", "bitstream vera sans mono", "cascadia code", "consolas", "courier new", "courier",
    "cutive mono", "dejavu sans mono", "droid sans mono", "droid sans mono", "everson mono", "fixed",
    "fixedsys", "freemono", "go mono", "inconsolata", "iosevka", "jetbrains mono", "letter gothic",
    "liberation mono", "lucida console", "menlo", "monaco", "monofur", "monospace", "nimbus mono l",
    "noto mono", "overpass mono", "oxygen mono", "pragmatapro", "prestige elite", "pro font",
    "roboto mono", "san francisco mono", "source code pro", "terminal", "terminus",
    "tex gyre cursor", "ubuntu mono", "um typewriter"
  };

  // Intervals Min, Max, Default, Increment
  static public readonly (int, int, int, int) CheckUpdateInterval = (1, 28, 7, 1);
  static public readonly (int, int, int, int) DateBookmarksCountInterval = (0, 30, 15, 1);
  static public readonly (int, int, int, int) PrintingMarginInterval = (10, 150, 50, 10);
  static public readonly (int, int, int, int) PrintPageCountWarningInterval = (10, 100, 20, 10);
  static public readonly (int, int, int, int) SaveImageCountWarningInterval = (25, 300, 50, 25);
  static public readonly (int, int, int, int) LoomingDelayInterval = (500, 5000, 1000, 250);
  static public readonly (int, int, int, int) GenerateIntervalInterval = (10, 200, 120, 5);
  static public readonly (int, int, int, int) RemindShabatHoursBeforeInterval = (1, 24, 6, 1);
  static public readonly (int, int, int, int) RemindShabatEveryMinutesInterval = (5, 120, 15, 5);
  static public readonly (int, int, int, int) RemindCelebrationDaysBeforeInterval = (1, 60, 14, 1);
  static public readonly (int, int, int, int) RemindCelebrationHoursBeforeInterval = (1, 48, 24, 1);
  static public readonly (int, int, int, int) RemindCelebrationEveryMinutesInterval = (5, 120, 15, 5);
  static public readonly (int, int, int, int) RemindAutoLockTimeOutInterval = (10, 300, 30, 5);
  static public readonly (int, int, int, int) TextReportFontSizeInterval = (7, 30, 10, 1);
  static public readonly (int, int, int, int) VisualMonthFontSizeInterval = (7, 30, 9, 1);
  static public readonly (int, int, int, int) LineSpacingInterval = (0, 10, 5, 1);

  // Available keys for hotkey keys
  static private readonly List<Keys> AvailableHotKeyKeys;

  static private readonly Properties.Settings Settings = Program.Settings;

  static public bool Reseted { get; private set; }
  static private bool DoReset;
  static private bool LanguageChanged;

  static PreferencesForm()
  {
    using ( var form = new PreferencesForm() )
    {
      TabIndexApplication = form.TabControl.TabPages.IndexOf(form.TabPageApplication);
      TabIndexCelebrations = form.TabControl.TabPages.IndexOf(form.TabPageCelebrations);
      TabIndexGeneration = form.TabControl.TabPages.IndexOf(form.TabPageGeneration);
      TabIndexMonthView = form.TabControl.TabPages.IndexOf(form.TabPageMonthView);
      TabIndexNavigation = form.TabControl.TabPages.IndexOf(form.TabPageNavigation);
      TabIndexPaths = form.TabControl.TabPages.IndexOf(form.TabPagePaths);
      TabIndexPrint = form.TabControl.TabPages.IndexOf(form.TabPagePrint);
      TabIndexReminder = form.TabControl.TabPages.IndexOf(form.TabPageReminder);
      TabIndexShabat = form.TabControl.TabPages.IndexOf(form.TabPageShabat);
      TabIndexStartup = form.TabControl.TabPages.IndexOf(form.TabPageStartup);
      TabIndexTextReport = form.TabControl.TabPages.IndexOf(form.TabPageTextReport);
      TabIndexTrayIcon = form.TabControl.TabPages.IndexOf(form.TabPageTrayIcon);
      TabIndexParashah = form.TabControl.TabPages.IndexOf(form.TabPageParashah);
      TabIndexWeather = form.TabControl.TabPages.IndexOf(form.TabPageWeather);
    }
    var filter1 = new Regex("(^F[0-9]{1,2}$)");
    var filter2 = new Regex("(^[A-Z]$)");
    var filter3 = new Regex("(^D[0-D9]$)");
    var filter4 = new Regex("(^NumPad[0-D9]$)");
    AvailableHotKeyKeys = Enums.GetValues<Keys>().Where(x => filter1.Match(x.ToString()).Success)
                               .Concat(Enums.GetValues<Keys>().Where(x => filter2.Match(x.ToString()).Success))
                               .Concat(Enums.GetValues<Keys>().Where(x => filter3.Match(x.ToString()).Success))
                               .Concat(Enums.GetValues<Keys>().Where(x => filter4.Match(x.ToString()).Success))
                               .ToList();
  }

  static public bool Run(int index = -1)
  {
    Reseted = false;
    Language lang = Settings.LanguageSelected;
    var form = new PreferencesForm();
    if ( !MainForm.Instance.Visible )
      form.ShowInTaskbar = true;
    if ( index >= 0 )
      form.TabControl.SelectedIndex = index;
    else
      form.TabControl.SelectedIndex = Settings.PreferencesFormSelectedTabIndex;
    form.ShowDialog();
    while ( LanguageChanged || DoReset )
    {
      LanguageChanged = false;
      DoReset = false;
      form.Dispose();
      form = new PreferencesForm();
      if ( !MainForm.Instance.Visible )
        form.ShowInTaskbar = true;
      form.ShowDialog();
    }
    bool result = Reseted
               || form.OldShabatDay != Settings.ShabatDay
               || form.OldLatitude != Settings.GPSLatitude
               || form.OldLongitude != Settings.GPSLongitude
               || form.OldUseMoonDays != Settings.TorahEventsCountAsMoon
               || form.OldUseSod != Settings.UseSodHaibour
               || form.OldTimeZone != Settings.TimeZone
               || form.OldUseSimhat != Settings.UseSimhatTorahOutside
               || lang != Settings.LanguageSelected;
    if ( !result && form.MustRefreshMonthView )
      MainForm.Instance.UpdateCalendarMonth(true);
    SystemManager.TryCatch(() =>
    {
      MainForm.Instance.CurrentGPSLatitude = (float)XmlConvert.ToDouble(Settings.GPSLatitude);
      MainForm.Instance.CurrentGPSLongitude = (float)XmlConvert.ToDouble(Settings.GPSLongitude);
      if ( result ) CalendarDates.Instance.Clear();
    });
    Settings.PreferencesFormSelectedTabIndex = form.TabControl.SelectedIndex;
    form.Dispose();
    form = null;
    return result;
  }

}
