/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-04 </edited>
using System;
using System.IO;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Indicate the default Settings instance.
    /// </summary>
    static public readonly Properties.Settings Settings
      = Properties.Settings.Default;

    /// <summary>
    /// Indicate the file path of the application's pause icon.
    /// </summary>
    static public string ApplicationPauseIconFilePath
      => Path.Combine(Globals.SystemFolderPath, "ApplicationPause.ico");

    /// <summary>
    /// Indicate the file path of the application's pause when special day icon.
    /// </summary>
    static public string ApplicationPauseEventIconFilePath
      => Path.Combine(Globals.SystemFolderPath, "ApplicationPauseEvent.ico");

    /// <summary>
    /// Indicate the file path of the application's event icon.
    /// </summary>
    static public string ApplicationEventIconFilePath
      => Path.Combine(Globals.SystemFolderPath, "ApplicationEvent.ico");

    static public readonly NullSafeOfStringDictionary<DataExportTarget> GridExportTargets
      = ExportHelper.CreateExportTargets(DataExportTarget.CSV, DataExportTarget.JSON);

    static public readonly NullSafeOfStringDictionary<DataExportTarget> BoardExportTargets
      = ExportHelper.CreateExportTargets(DataExportTarget.TXT, DataExportTarget.CSV, DataExportTarget.JSON);

    static public readonly NullSafeOfStringDictionary<ImageExportTarget> ImageExportTargets
      = ExportHelper.CreateExportTargets<ImageExportTarget>().SetUnsupported(ImageExportTarget.GIF);

    /// <summary>
    /// Indicate minimum items for load data to show the loading form.
    /// </summary>
    public const int LoadingFormLoadDB = 10000 * 2;

    /// <summary>
    /// Indicate minimum items for generate data to show the loading form.
    /// </summary>
    public const int LoadingFormGenerate = 3000;

    /// <summary>
    /// Indicate minimum items for calc dates diff to show the loading form.
    /// </summary>
    public const int LoadingFormDatesDiff = 15 * 365;

    /// <summary>
    /// Indicate minimum torah years interval that can be generated.
    /// </summary>
    /// <remarks>
    /// Two torah years need three gregorian years with the previous.
    /// </remarks>
    public const int GenerateIntervalMinimum = 2;

    public const int AutoGenerateYearsIntervalMax = 50;

    public const int GenerateIntervalPreviousYears = 2;

    /// <summary>
    /// Indicate big calendar advert levels.
    /// </summary>
    static public readonly int[] BigCalendarLevels = { 20, 40, 60, 80, 120 };

    /// <summary>
    /// Indicate predefined years intervals.
    /// </summary>
    static public readonly int[] PredefinedYearsIntervals =
    {
      5, 10, 15, 20, 25, 30, 40, 50, 75, 100, 120, -5, -10, -15, -20, -25, -30, -40, -50, -75, -100
    };

    /// <summary>
    /// Indicate the grammar guide form.
    /// </summary>
    static public HTMLBrowserForm GrammarGuideForm
    {
      get
      {
        if ( _GrammarGuideForm == null )
          _GrammarGuideForm = new HTMLBrowserForm(HebrewTranslations.GrammarGuideTitle,
                                                  HebrewGlobals.HebrewGrammarGuideFilePath,
                                                  nameof(Settings.GrammarGuideFormLocation),
                                                  nameof(Settings.GrammarGuideFormSize));
        return _GrammarGuideForm;
      }
    }
    static private HTMLBrowserForm _GrammarGuideForm;

    /// <summary>
    /// Indicate file path of reminder box image.
    /// </summary>
    static public string ReminderBoxImageFilePath
      => Path.Combine(Globals.ProjectIconsFolderPath, "hebrew-calendar-64.png");

    /// <summary>
    /// Indicate file path of the text report.
    /// </summary>
    static public string TextReportFilePath
      => Path.ChangeExtension(Globals.DatabaseFilePath, ".txt");

    /// <summary>
    /// Indicate file path of date bookmarks.
    /// </summary>
    static public string DateBookmarksFilePath
      => Path.Combine(Globals.UserDataFolderPath, "DateBookmarks.txt");

    /// <summary>
    /// Indicate date bookmarks.
    /// </summary>
    static public readonly DateBookmarks DateBookmarks
      = new DateBookmarks(DateBookmarksFilePath);

    /// <summary>
    /// Indicate world cities documents folder.
    /// </summary>
    static public string WorldCitiesFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "WorldCities");

    /// <summary>
    /// Indicate file path of the GPS database.
    /// </summary>
    static public string GPSFilePath
      => Path.Combine(WorldCitiesFolderPath, "WorldCities.csv");

    /// <summary>
    /// Indicate lunar months documents folder.
    /// </summary>
    static public string LunarMonthsFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "LunarMonths");

    /// <summary>
    /// Indicate file path of the lunar months meanings.
    /// </summary>
    static public string LunarMonthsMeaningsFilePath
      => Path.Combine(LunarMonthsFolderPath, $"LunarMonths-Meanings-{Languages.Current.ToString()}.txt");

    /// <summary>
    /// Indicate file path of the lunar months lettriqs.
    /// </summary>
    static public string LunarMonthsLettriqsFilePath
      => Path.Combine(LunarMonthsFolderPath, $"LunarMonths-Lettriqs-{Languages.Current.ToString()}.txt");

    /// <summary>
    /// Indicate lunar months meanings.
    /// </summary>
    static public NullSafeDictionary<Language, LunarMonthsFile> LunarMonthsMeanings { get; private set; }

    /// <summary>
    /// Indicate lunar months lettriqs.
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
        LunarMonthsMeanings.Add(lang,
                                new LunarMonthsFile(string.Format(LunarMonthsMeaningsFilePath, Languages.Codes[lang].ToUpper()),
                                                    true,
                                                    Globals.IsDevExecutable,
                                                    DataFileFolder.ApplicationDocuments));
        LunarMonthsLettriqs.Add(lang,
                                new LunarMonthsFile(string.Format(LunarMonthsLettriqsFilePath, Languages.Codes[lang].ToUpper()),
                                                    true,
                                                    Globals.IsDevExecutable,
                                                    DataFileFolder.ApplicationDocuments));
      }
    }

  }

}
