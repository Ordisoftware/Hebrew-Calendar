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
using System.Collections.Generic;
using System.IO;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
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
    public const int LoadingFormLoadDB = 15000 * 2;

    /// <summary>
    /// Indicate minimum items for generate data to show the loading form.
    /// </summary>
    public const int LoadingFormGenerate = 4000;

    /// <summary>
    /// Indicate minimum items for calc dates diff to show the loading form.
    /// </summary>
    public const int LoadingFormDatesDiff = 20 * 365;

    /// <summary>
    /// Indicate maximum gregorian years interval that can be generated.
    /// </summary>
    public const int GenerateIntervalMaximumHigh = 200;

    /// <summary>
    /// Indicate minimum gregorian years interval that can be generated.
    /// </summary>
    public const int GenerateIntervalMaximumLow = 10;

    /// <summary>
    /// Indicate minimum torah years interval that can be generated.
    /// </summary>
    /// <remarks>
    /// Two torah years need three gregorian years with the previous.
    /// </remarks>
    public const int GenerateIntervalMinimum = 2;

    /// <summary>
    /// Indicate big calendar advert levels.
    /// </summary>
    static public readonly int[] BigCalendarLevels = { 20, 40, 60, 80, 120 };

    /// <summary>
    /// Indicate predefined years intervals.
    /// </summary>
    static public readonly int[] PredefinedYearsIntervals = 
    {
      5, 10, 20, 30, 40, 50,
      -5, -10, -15, -20, -25
    };

    /// <summary>
    /// Indicate shabat notice form.
    /// </summary>
    static public ShowTextForm ShabatNoticeForm
      => ShowTextForm.Create(Translations.NoticeShabatTitle, Translations.NoticeShabat, 600, 520);

    /// <summary>
    /// Indicate celebrations notice form.
    /// </summary>
    static public ShowTextForm CelebrationsNoticeForm
      => ShowTextForm.Create(Translations.NoticeCelebrationsTitle, Translations.NoticeCelebrations, 600, 320);

    /// <summary>
    /// Indicate moon months notice form.
    /// </summary>
    static public ShowTextForm MoonMonthsNoticeForm
      => ShowTextForm.Create(Translations.NoticeMoonMonthsTitle, Translations.NoticeMoonMonths, 400, 300);

    /// <summary>
    /// Indicate dates diff notice form.
    /// </summary>
    static public ShowTextForm DatesDiffNoticeForm
      => ShowTextForm.Create(Translations.DatesDiffNoticeTitle, Translations.DatesDiffNotice, 500, 440);

    /// <summary>
    /// Indicate filename of the text report.
    /// </summary>
    static public string TextReportFilename
      => Path.ChangeExtension(Globals.DatabaseFileName, ".txt");

    /// <summary>
    /// Indicate filename of the GPS database.
    /// </summary>
    static public string GPSFilename
      => Globals.DocumentsFolderPath + "WorldCities.csv";

    /// <summary>
    /// Indicate the moon months documents folder.
    /// </summary>
    static public string MoonMonthsFolderPath
      => Globals.DocumentsFolderPath + "MoonMonths" + Path.DirectorySeparatorChar;

    /// <summary>
    /// Indicate filename of the moon months meanings.
    /// </summary>
    static public string MoonMonthsMeaningsFilename
      = MoonMonthsFolderPath + "MoonMonthsMeanings{0}.txt";

    /// <summary>
    /// Indicate filename of the moon months lettriqs.
    /// </summary>
    static public string MoonMonthsLettriqsFilename
      => MoonMonthsFolderPath + "MoonMonthsLettriqs{0}.txt";

    /// <summary>
    /// Indicate the moon months meanings.
    /// </summary>
    static public Dictionary<string, MoonMonthsFile> MoonMonthsMeanings { get; private set; }

    /// <summary>
    /// Indicate the moon months lettriqs.
    /// </summary>
    static public Dictionary<string, MoonMonthsFile> MoonMonthsLettriqs { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Program()
    {
      MoonMonthsMeanings = new Dictionary<string, MoonMonthsFile>();
      MoonMonthsLettriqs = new Dictionary<string, MoonMonthsFile>();
      foreach ( var lang in Languages.Names )
      {
        MoonMonthsMeanings.Add(lang.Value,
                               new MoonMonthsFile(string.Format(MoonMonthsMeaningsFilename, lang.Value.ToUpper()),
                                                  true,
                                                  Globals.IsDev,
                                                  DataFileFolder.ApplicationDocuments));
        MoonMonthsLettriqs.Add(lang.Value,
                               new MoonMonthsFile(string.Format(MoonMonthsLettriqsFilename, lang.Value.ToUpper()),
                                                  true,
                                                  Globals.IsDev,
                                                  DataFileFolder.ApplicationDocuments));
      }
    }

  }

}
