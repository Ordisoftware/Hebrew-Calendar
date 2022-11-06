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
/// <edited> 2022-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides Program class.
/// </summary>
static partial class Program
{

  /// <summary>
  /// Indicates the default Settings instance.
  /// </summary>
  static public readonly Properties.Settings Settings
    = Properties.Settings.Default;

  /// <summary>
  /// Indicates the file path of the application's pause icon.
  /// </summary>
  static public string ApplicationPauseIconFilePath
    => Path.Combine(Globals.SystemFolderPath, "ApplicationPause.ico");

  /// <summary>
  /// Indicates the file path of the application's pause when special day icon.
  /// </summary>
  static public string ApplicationPauseEventIconFilePath
    => Path.Combine(Globals.SystemFolderPath, "ApplicationPauseEvent.ico");

  /// <summary>
  /// Indicates the file path of the application's event icon.
  /// </summary>
  static public string ApplicationEventIconFilePath
    => Path.Combine(Globals.SystemFolderPath, "ApplicationEvent.ico");

  /// <summary>
  /// Indicates image export targets
  /// </summary>
  static public readonly NullSafeOfStringDictionary<ImageExportTarget> ImageExportTargets
    = ExportHelper.CreateExportTargets<ImageExportTarget>().SetUnsupported(ImageExportTarget.GIF);

  /// <summary>
  /// Indicates board export targets
  /// </summary>
  static public readonly NullSafeOfStringDictionary<DataExportTarget> BoardExportTargets
    = ExportHelper.CreateExportTargets(DataExportTarget.TXT, DataExportTarget.CSV, DataExportTarget.JSON);

  /// <summary>
  /// Indicates data grid export targets
  /// </summary>
  static public readonly NullSafeOfStringDictionary<DataExportTarget> GridExportTargets
    = ExportHelper.CreateExportTargets(DataExportTarget.CSV, DataExportTarget.JSON);

  /// <summary>
  /// Indicates minimum items for load data to show the loading form.
  /// </summary>
  public const int LoadingFormLoadDB = 10000;

  /// <summary>
  /// Indicates minimum items for generate data to show the loading form.
  /// </summary>
  public const int LoadingFormGenerate = 5000;

  /// <summary>
  /// Indicates minimum items for calc dates diff to show the loading form.
  /// </summary>
  public const int LoadingFormDatesDiff = 15 * 365;

  /// <summary>
  /// Indicates minimum torah years interval that can be generated.
  /// </summary>
  /// <remarks>
  /// Two torah years need three gregorian years with the previous.
  /// </remarks>
  public const int GenerateIntervalMinimum = 2;

  /// <summary>
  /// Indicates the generate interval previous years
  /// </summary>
  public const int GenerateIntervalPreviousYears = 2;

  /// <summary>
  /// Indicates big calendar advert levels.
  /// </summary>
  static public readonly int[] BigCalendarLevels =
  {
    30, 50, 75, 100, 125
  };

  /// <summary>
  /// Indicates predefined years intervals.
  /// </summary>
  static public readonly int[] PredefinedYearsIntervals =
  {
    5, 10, 15, 20, 25, 30, 40, 50, 75, 100, 120, -5, -10, -15, -20, -25, -30, -40, -50, -75, -100
  };

  /// <summary>
  /// Indicates file path of application image 64x64.
  /// </summary>
  static public string ApplicationImage64FilePath
    => Path.Combine(Globals.ProjectIconsApplicationsFolderPath, "hebrew_calendar64.png");

  /// <summary>
  /// Indicates file path of application image 32x32.
  /// </summary>
  static public string ApplicationImage32FilePath
    => Path.Combine(Globals.ProjectIconsApplicationsFolderPath, "hebrew_calendar32.png");

  /// <summary>
  /// Indicates file path of the text report.
  /// </summary>
  static public string TextReportFilePath
    => Path.ChangeExtension(Globals.ApplicationDatabaseFilePath, ".txt");

  /// <summary>
  /// Indicates file path of date bookmarks.
  /// </summary>
  static public string DateBookmarksFilePath
    => Path.Combine(Globals.UserDataFolderPath, "DateBookmarks.txt");

  /// <summary>
  /// Indicates date bookmarks.
  /// </summary>
  static public readonly DateBookmarks DateBookmarks
    = new(DateBookmarksFilePath);

  /// <summary>
  /// Indicates world cities documents folder.
  /// </summary>
  static public string WorldCitiesFolderPath
    => Path.Combine(Globals.DocumentsFolderPath, "WorldCities");

  /// <summary>
  /// Indicates file path of the GPS database.
  /// </summary>
  static public string GPSFilePath
    => Path.Combine(WorldCitiesFolderPath, "WorldCities.csv");

  /// <summary>
  /// Indicates lunar months documents folder.
  /// </summary>
  static public string LunarMonthsFolderPath
    => Path.Combine(Globals.DocumentsFolderPath, "LunarMonths");

  /// <summary>
  /// Indicates file path of the lunar months meanings.
  /// </summary>
  static public string LunarMonthsMeaningsFilePath
    => Path.Combine(LunarMonthsFolderPath, $"LunarMonths-Meanings-{Languages.Current}.txt");

  /// <summary>
  /// Indicates file path of the lunar months lettriqs.
  /// </summary>
  static public string LunarMonthsLettriqsFilePath
    => Path.Combine(LunarMonthsFolderPath, $"LunarMonths-Lettriqs-{Languages.Current}.txt");

  /// <summary>
  /// Indicates lunar months meanings.
  /// </summary>
  static public NullSafeDictionary<Language, LunarMonthsFile> LunarMonthsMeanings { get; private set; }

  /// <summary>
  /// Indicates lunar months lettriqs.
  /// </summary>
  static public NullSafeDictionary<Language, LunarMonthsFile> LunarMonthsLettriqs { get; private set; }

  /// <summary>
  /// Static constructor.
  /// </summary>
  static Program()
  {
    if ( Globals.IsVisualStudioDesigner ) return;
    LunarMonthsMeanings = new NullSafeDictionary<Language, LunarMonthsFile>();
    LunarMonthsLettriqs = new NullSafeDictionary<Language, LunarMonthsFile>();
    foreach ( Language lang in Languages.Managed )
    {
      LunarMonthsMeanings.Add(lang, new LunarMonthsFile(LunarMonthsMeaningsFilePath,
                                                        true,
                                                        Globals.IsDebugExecutable,
                                                        DataFileFolder.ApplicationDocuments));
      LunarMonthsLettriqs.Add(lang, new LunarMonthsFile(LunarMonthsLettriqsFilePath,
                                                        true,
                                                        Globals.IsDebugExecutable,
                                                        DataFileFolder.ApplicationDocuments));
    }
  }

  /// <summary>
  /// Select a celebration in the CelebrationVersesBoardForm instance.
  /// </summary>
  [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "N/A")]
  static public void SelectCurrentCelebrationInVersesForm(TorahCelebrationDay celebration = TorahCelebrationDay.None)
  {
    if ( CelebrationVersesBoardForm.Instance is null ) return;
    if ( CelebrationVersesBoardForm.Instance.SelectCelebration.Items.Count <= 0 ) return;
    if ( celebration == TorahCelebrationDay.None )
    {
      var dateStart = DateTime.Today;
      var days = ApplicationDatabase.Instance.LunisolarDays;
      var day = days.Find(d => d.Date >= dateStart && d.HasTorahEvent && d.TorahEvent != TorahCelebrationDay.NewYearD1);
      if ( day is not null ) celebration = day.TorahEvent;
    }
    if ( celebration == TorahCelebrationDay.NewYearD10 )
      celebration = TorahCelebrationDay.PessahD1;
    if ( celebration != TorahCelebrationDay.None )
    {
      string str = celebration.ToString();
      foreach ( ListViewItem item in CelebrationVersesBoardForm.Instance.SelectCelebration.Items )
        if ( str.StartsWith(( (TorahCelebration)item.Tag ).ToString(), StringComparison.Ordinal) )
        {
          item.Selected = true;
          item.Focused = true;
          break;
        }
    }
    else
    {
      CelebrationVersesBoardForm.Instance.SelectCelebration.Items[0].Selected = true;
      CelebrationVersesBoardForm.Instance.SelectCelebration.Items[0].Focused = true;
    }
  }

}
