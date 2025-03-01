/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words/Pi.
/// Copyright 2012-2025 Olivier Rogier.
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
/// <edited> 2023-01 </edited>
namespace Ordisoftware.Hebrew;

/// <summary>
/// Localization strings.
/// </summary>
static public partial class HebrewTranslations
{

  static public readonly TranslationsDictionary TranscriptionGuideTitle = new()
  {
    [Language.EN] = "Transcription guide",
    [Language.FR] = "Guide de transcription"
  };

  static public readonly TranslationsDictionary GrammarGuideTitle = new()
  {
    [Language.EN] = "Grammar guide",
    [Language.FR] = "Guide de grammaire"
  };

  static public readonly TranslationsDictionary MethodNoticeTitle = new()
  {
    [Language.EN] = "Lettriq analysis method notice",
    [Language.FR] = "Notice de la méthode d'analyse lettrique"
  };

  static public readonly TranslationsDictionary Hebrew = new()
  {
    [Language.EN] = "Hebrew",
    [Language.FR] = "Hébreu"
  };

  static public readonly TranslationsDictionary Unicode = new()
  {
    [Language.EN] = "Unicode",
    [Language.FR] = "Unicode"
  };

  static public readonly TranslationsDictionary Translation = new()
  {
    [Language.EN] = "Translation",
    [Language.FR] = "Traduction"
  };

  static public readonly TranslationsDictionary Transcription = new()
  {
    [Language.EN] = "Transcription",
    [Language.FR] = "Transcription"
  };

  static public readonly TranslationsDictionary Lettriq = new()
  {
    [Language.EN] = "Lettriq",
    [Language.FR] = "Lettrique"
  };

  static public readonly TranslationsDictionary LetterDetails = new()
  {
    [Language.EN] = "View details about {0}",
    [Language.FR] = "Voir les détails sur {0}"
  };

  static public readonly TranslationsDictionary AskToResetParashot = new()
  {
    [Language.EN] = "Data will be restored to their default values, except memos. Erase all data before to delete memos too." + Globals.NL2 +
                    "All changes will be lost and the action cannot be undone." + Globals.NL2 +
                    SysTranslations.AskToContinue[Language.EN],

    [Language.FR] = "Les données seront restaurées à leurs valeurs par défaut, sauf les memos. Pour effacer les mémos, supprimez toutes les données d'abord." + Globals.NL2 +
                    "Toutes les modifications seront perdues et l'action ne pourra pas être annulée." + Globals.NL2 +
                    SysTranslations.AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary BookNotAvailable = new()
  {
    [Language.EN] = "Book {0} is not yet available.",
    [Language.FR] = "Le livre {0} n'est pas encore disponible."
  };

  static public readonly TranslationsDictionary ParashahNotFound = new()
  {
    [Language.EN] = "Parashah not found : it's Pessa'h or data are not generated.",
    [Language.FR] = "Parashah non trouvée : c'est Pessa'h ou les données n'ont pas été générées."
  };

  static public readonly TranslationsDictionary WeeklyParashah = new()
  {
    [Language.EN] = "Weekly parashah",
    [Language.FR] = "Parashah de la semaine"
  };

  static public readonly TranslationsDictionary ParashahReading = new()
  {
    [Language.EN] = "Parashah reading",
    [Language.FR] = "Lecture de la Parashah"
  };

  static public readonly TranslationsDictionary HebrewLettersAnalysis = new()
  {
    [Language.EN] = "Analyze with Hebrew Letters",
    [Language.FR] = "Analyser avec Hebrew Letters"
  };

  static public readonly TranslationsDictionary HebrewWordsVerse = new()
  {
    [Language.EN] = "Open with Hebrew Words",
    [Language.FR] = "Ouvrir avec Hebrew Words"
  };

  static public readonly TranslationsDictionary HebrewWordsSearch = new()
  {
    [Language.EN] = "Search with Hebrew Words",
    [Language.FR] = "Chercher avec Hebrew Words"
  };

  static public readonly NullSafeDictionary<TorahCelebration, TranslationsDictionary> CelebrationsInLatinChars = new()
  {
    [TorahCelebration.Pessah] = new TranslationsDictionary
    {
      [Language.EN] = "Pessa'h",
      [Language.FR] = "Pessa'h"
    },
    [TorahCelebration.Chavouot] = new TranslationsDictionary
    {
      [Language.EN] = "Shavuh'ot",
      [Language.FR] = "Shavouh'ot"
    },
    [TorahCelebration.YomTerouah] = new TranslationsDictionary
    {
      [Language.EN] = "Yom Teruh'ah",
      [Language.FR] = "Yom Terouh'ah"
    },
    [TorahCelebration.YomHaKipourim] = new TranslationsDictionary
    {
      [Language.EN] = "Yom HaKipurim",
      [Language.FR] = "Yom HaKipourim"
    },
    [TorahCelebration.Soukot] = new TranslationsDictionary
    {
      [Language.EN] = "Sukot",
      [Language.FR] = "Soukot"
    },
    // TODO when ready : check and uncomment 
    //Tevet10,
    //TouBichvat,
    //Hanouka,
    //Pourim,
    //TaanitBekhorim,
    //YomHaShoah,
    //LagBahomer,
    //Tammouz17,
    //TishaBeAv,
    //TouBeAv,
    //ShimhatTorah,
    [TorahCelebration.Shabat] = new TranslationsDictionary
    {
      [Language.EN] = "Shabat",
      [Language.FR] = "Shabat"
    }
  };

  static public readonly Dictionary<TorahCelebration, string> CelebrationsInHebrewChars = new()
  {
    [TorahCelebration.Pessah] = "פסח",
    [TorahCelebration.Chavouot] = "שבועות",
    [TorahCelebration.YomTerouah] = "יומ תרועה",
    [TorahCelebration.YomHaKipourim] = "יומ הכיפורים",
    [TorahCelebration.Soukot] = "סכות",
    [TorahCelebration.Shabat] = "שבת"
  };

  static public string GetCelebrationDisplayText(TorahCelebration celebration)
    => HebrewDatabase.HebrewNamesInUnicode
       ? CelebrationsInHebrewChars[celebration]
       : CelebrationsInLatinChars[celebration].GetLang();

  static public string GetLunarMonthDisplayText(int month)
    => HebrewDatabase.HebrewNamesInUnicode
     ? HebrewMonths.Unicode[month]
     : HebrewMonths.Transcriptions.GetLang()[month];

  static public string Shabat
    => HebrewDatabase.HebrewNamesInUnicode
       ? CelebrationsInHebrewChars[TorahCelebration.Shabat]
       : CelebrationsInLatinChars.GetLang(TorahCelebration.Shabat);

  static public string Parashah
    => HebrewDatabase.HebrewNamesInUnicode
       ? "פרשה"
       : "Parashah";

}
