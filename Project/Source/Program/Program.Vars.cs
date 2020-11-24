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
    /// Indicate phonetic moon months names.
    /// </summary>
    static public readonly string[] MoonMonthsNames =
    {
      "",
      "Nissan", "Iyar", "Sivan", "Tamouz", "Av", "Eloul",
      "Tishri", "Heshvan", "Kislev", "Tevet", "Chevat", "Adar",
      "Adar II"
    };

    /// <summary>
    /// Indicate unicode moon months names.
    /// </summary>
    static public readonly string[] MoonMonthsUnicode =
    {
      "",
      "ניסן", "איר", "סיון", "תמוז", "אב", "אלול",
      "תשרי", "חשון", "כסלו", "טבת", "שבט", "אדר א",
      "אדר ב"
    };

    /// <summary>
    /// Indicate minimum items for load data to show the loading form.
    /// </summary>
    public const int DatesBookmarksCount = 10;

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
    /// Indicate maximum gregorian years interval that can be generated.
    /// </summary>
    public const int GenerateIntervalMaximumHigh = 200;

    /// <summary>
    /// Indicate minimum gregorian years interval that can be generated.
    /// </summary>
    public const int GenerateIntervalMaximumLow = 10;

    /// <summary>
    /// Indicate default gregorian years interval that can be generated.
    /// </summary>
    public const int GenerateIntervalMaximumDefault = 120;

    /// <summary>
    /// Indicate increment for gregorian years interval that can be generated.
    /// </summary>
    public const int GenerateIntervalMaximumIncrement = 5;

    /// <summary>
    /// Indicate minimum torah years interval that can be generated.
    /// </summary>
    /// <remarks>
    /// Two torah years need three gregorian years with the previous.
    /// </remarks>
    public const int GenerateIntervalMinimum = 2;

    public const int AutoGenerateYearsIntervalMax = 50;

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
    /// Indicate the application sounds folder.
    /// </summary>
    static public string ApplicationSoundsFolderPath
      => Path.Combine(Globals.RootFolderPath, "Sounds");

    /// <summary>
    /// Indicate file path of date bookmarks.
    /// </summary>
    static public string DateBookmarksFilePath
      => Path.Combine(Globals.UserDataFolderPath, "DateBookmarks.txt");

    /// <summary>
    /// Indicate date bookmarks.
    /// </summary>
    static public readonly DateBookmarks DateBookmarks = new DateBookmarks(DateBookmarksFilePath);

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
    /// Indicate file path of the GPS database.
    /// </summary>
    static public string GPSFilePath
      => Path.Combine(Globals.DocumentsFolderPath, "WorldCities.csv");

    /// <summary>
    /// Indicate the moon months documents folder.
    /// </summary>
    static public string MoonMonthsFolderPath
      => Path.Combine(Globals.DocumentsFolderPath, "MoonMonths");

    /// <summary>
    /// Indicate file path of the moon months meanings.
    /// </summary>
    static public string MoonMonthsMeaningsFilePath
      = Path.Combine(MoonMonthsFolderPath, "MoonMonthsMeanings{0}.txt");

    /// <summary>
    /// Indicate file path of the moon months lettriqs.
    /// </summary>
    static public string MoonMonthsLettriqsFilePath
      => Path.Combine(MoonMonthsFolderPath, "MoonMonthsLettriqs{0}.txt");

    /// <summary>
    /// Indicate the moon months meanings.
    /// </summary>
    static public NullSafeDictionary<Language, MoonMonthsFile> MoonMonthsMeanings { get; private set; }

    /// <summary>
    /// Indicate the moon months lettriqs.
    /// </summary>
    static public NullSafeDictionary<Language, MoonMonthsFile> MoonMonthsLettriqs { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Program()
    {
      MoonMonthsMeanings = new NullSafeDictionary<Language, MoonMonthsFile>();
      MoonMonthsLettriqs = new NullSafeDictionary<Language, MoonMonthsFile>();
      foreach ( Language lang in Languages.Managed )
      {
        MoonMonthsMeanings.Add(lang,
                               new MoonMonthsFile(string.Format(MoonMonthsMeaningsFilePath, Languages.Codes[lang].ToUpper()),
                                                  true,
                                                  Globals.IsDevExecutable,
                                                  DataFileFolder.ApplicationDocuments));
        MoonMonthsLettriqs.Add(lang,
                               new MoonMonthsFile(string.Format(MoonMonthsLettriqsFilePath, Languages.Codes[lang].ToUpper()),
                                                  true,
                                                  Globals.IsDevExecutable,
                                                  DataFileFolder.ApplicationDocuments));
      }
    }

  }

}