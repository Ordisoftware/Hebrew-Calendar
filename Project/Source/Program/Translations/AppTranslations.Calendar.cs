﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public readonly NullSafeDictionary<DayOfWeek, TranslationsDictionary> DaysOfWeek = new()
  {
    [DayOfWeek.Monday] = new TranslationsDictionary
    {
      [Language.EN] = "Monday",
      [Language.FR] = "Lundi"
    },
    [DayOfWeek.Tuesday] = new TranslationsDictionary
    {
      [Language.EN] = "Tuesday",
      [Language.FR] = "Mardi"
    },
    [DayOfWeek.Wednesday] = new TranslationsDictionary
    {
      [Language.EN] = "Wednesday",
      [Language.FR] = "Mercredi"
    },
    [DayOfWeek.Thursday] = new TranslationsDictionary
    {
      [Language.EN] = "Thursday",
      [Language.FR] = "Jeudi"
    },
    [DayOfWeek.Friday] = new TranslationsDictionary
    {
      [Language.EN] = "Friday",
      [Language.FR] = "Vendredi"
    },
    [DayOfWeek.Saturday] = new TranslationsDictionary
    {
      [Language.EN] = "Saturday",
      [Language.FR] = "Samedi"
    },
    [DayOfWeek.Sunday] = new TranslationsDictionary
    {
      [Language.EN] = "Sunday",
      [Language.FR] = "Dimanche"
    }
  };

  static public readonly TranslationsDictionary Today = new()
  {
    [Language.EN] = "Today",
    [Language.FR] = "Aujourd'hui"
  };

  static public readonly TranslationsDictionary Shabat = new()
  {
    [Language.EN] = "Shabat",
    [Language.FR] = "Shabat"
  };

  static public readonly TranslationsDictionary NavigationMonth = new()
  {
    [Language.EN] = "Month No. {0}",
    [Language.FR] = "Mois n°{0}"
  };

  static public readonly TranslationsDictionary NavigationDay = new()
  {
    [Language.EN] = "Day No. {0}",
    [Language.FR] = "Jour n°{0}"
  };

  static public readonly TranslationsDictionary Sunrise = new()
  {
    [Language.EN] = "{0} Sunrise",
    [Language.FR] = "{0} Lever du soleil"
  };

  static public readonly TranslationsDictionary Sunset = new()
  {
    [Language.EN] = "{0} Sunset",
    [Language.FR] = "{0} Coucher du soleil"
  };

  static public readonly TranslationsDictionary Moonrise = new()
  {
    [Language.EN] = "{0} Moonrise",
    [Language.FR] = "{0} Lever de la lune"
  };

  static public readonly TranslationsDictionary Moonset = new()
  {
    [Language.EN] = "{0} Moonset",
    [Language.FR] = "{0} Coucher de la lune"
  };

  static public readonly NullSafeDictionary<Ephemeris, TranslationsDictionary> EphemerisCodes = new()
  {
    [Ephemeris.Rise] = new TranslationsDictionary
    {
      [Language.EN] = "R: ",
      [Language.FR] = "L: "
    },
    [Ephemeris.Set] = new TranslationsDictionary
    {
      [Language.EN] = "S: ",
      [Language.FR] = "C: "
    },
    [Ephemeris.SummerHour] = new TranslationsDictionary
    {
      [Language.EN] = "(S)",
      [Language.FR] = "(E)"
    },
    [Ephemeris.WinterHour] = new TranslationsDictionary
    {
      [Language.EN] = "(W)",
      [Language.FR] = "(H)"
    }
  };

  static public readonly NullSafeDictionary<MoonriseOccurring, TranslationsDictionary> MoonriseOccurrences = new()
  {
    [MoonriseOccurring.AfterSet] = new TranslationsDictionary
    {
      [Language.EN] = "After the set",
      [Language.FR] = "Après le lever"
    },
    [MoonriseOccurring.BeforeSet] = new TranslationsDictionary
    {
      [Language.EN] = "Before the set",
      [Language.FR] = "Avant le lever"
    },
    [MoonriseOccurring.NextDay] = new TranslationsDictionary
    {
      [Language.EN] = "The next day",
      [Language.FR] = "Le jour d'après"
    },
  };

  static public readonly NullSafeDictionary<MoonPhase, TranslationsDictionary> MoonPhases = new()
  {
    [MoonPhase.New] = new TranslationsDictionary
    {
      [Language.EN] = "New moon",
      [Language.FR] = "Nouvelle lune"
    },
    [MoonPhase.WaxingCrescent] = new TranslationsDictionary
    {
      [Language.EN] = "Waxing crescent",
      [Language.FR] = "Premier croissant"
    },
    [MoonPhase.FirstQuarter] = new TranslationsDictionary
    {
      [Language.EN] = "First quarter",
      [Language.FR] = "Premier quartier"
    },
    [MoonPhase.WaxingGibbous] = new TranslationsDictionary
    {
      [Language.EN] = "Waxing gibbous",
      [Language.FR] = "Gibbeuse croissante"
    },
    [MoonPhase.Full] = new TranslationsDictionary
    {
      [Language.EN] = "Full moon",
      [Language.FR] = "Pleine lune"
    },
    [MoonPhase.WaningGibbous] = new TranslationsDictionary
    {
      [Language.EN] = "Waning gibbous",
      [Language.FR] = "Gibbeuse décroissante"
    },
    [MoonPhase.LastQuarter] = new TranslationsDictionary
    {
      [Language.EN] = "Last quarter",
      [Language.FR] = "Dernier quartier"
    },
    [MoonPhase.WaningCrescent] = new TranslationsDictionary
    {
      [Language.EN] = "Waning crescent",
      [Language.FR] = "Dernier croissant"
    }
  };

  static public readonly NullSafeDictionary<SeasonChange, TranslationsDictionary> SeasonChanges = new()
  {
    [SeasonChange.None] = new TranslationsDictionary
    {
      [Language.EN] = "",
      [Language.FR] = ""
    },
    [SeasonChange.SpringEquinox] = new TranslationsDictionary
    {
      [Language.EN] = "Spring equinox",
      [Language.FR] = "Équinoxe de printemps"
    },
    [SeasonChange.SummerSolstice] = new TranslationsDictionary
    {
      [Language.EN] = "Summer solstice",
      [Language.FR] = "Solstice d'été"
    },
    [SeasonChange.AutumnEquinox] = new TranslationsDictionary
    {
      [Language.EN] = "Autumn equinox",
      [Language.FR] = "Équinoxe d'automne"
    },
    [SeasonChange.WinterSolstice] = new TranslationsDictionary
    {
      [Language.EN] = "Winter solstice",
      [Language.FR] = "Solstice d'hiver"
    }
  };

  static public readonly Dictionary<SeasonChange, string> HebrewCharsSeasons = new()
  {
    [SeasonChange.None] = "",
    [SeasonChange.SpringEquinox] = "שוויון אביבי",
    [SeasonChange.SummerSolstice] = "היפוך הקיץ",
    [SeasonChange.AutumnEquinox] = "שוויון סתווי",
    [SeasonChange.WinterSolstice] = "היפוך חורף"
  };

  static public string GetSeasonChangeDisplayText(SeasonChange value)
    => Program.Settings.HebrewNamesInUnicode
       ? HebrewCharsSeasons[value]
       : SeasonChanges.GetLang(value);

  static public readonly NullSafeDictionary<ReportFieldText, TranslationsDictionary> ReportFields = new()
  {
    [ReportFieldText.Date] = new TranslationsDictionary
    {
      [Language.EN] = "Date",
      [Language.FR] = "Date"
    },
    [ReportFieldText.Month] = new TranslationsDictionary
    {
      [Language.EN] = "Month",
      [Language.FR] = "Mois"
    },
    [ReportFieldText.Sun] = new TranslationsDictionary
    {
      [Language.EN] = "Sun",
      [Language.FR] = "Soleil"
    },
    [ReportFieldText.Moon] = new TranslationsDictionary
    {
      [Language.EN] = "Moon",
      [Language.FR] = "Lune"
    },
    [ReportFieldText.Events] = new TranslationsDictionary
    {
      [Language.EN] = "Events",
      [Language.FR] = "Évènements"
    }
  };

  static public readonly NullSafeDictionary<Language, NullSafeList<string>> WikipediaMonths = new()
  {
    [Language.EN] =
    [
      "https://en.wikipedia.org/wiki/Hebrew_calendar",
      "https://en.wikipedia.org/wiki/Nisan",
      "https://en.wikipedia.org/wiki/Iyar",
      "https://en.wikipedia.org/wiki/Sivan",
      "https://en.wikipedia.org/wiki/Tammuz_(Hebrew_month)",
      "https://en.wikipedia.org/wiki/Av",
      "https://en.wikipedia.org/wiki/Elul",
      "https://en.wikipedia.org/wiki/Tishrei",
      "https://en.wikipedia.org/wiki/Cheshvan",
      "https://en.wikipedia.org/wiki/Kislev",
      "https://en.wikipedia.org/wiki/Tevet",
      "https://en.wikipedia.org/wiki/Shevat",
      "https://en.wikipedia.org/wiki/Adar",
      "https://en.wikipedia.org/wiki/Adar"
    ],
    [Language.FR] =
    [
      "https://fr.wikipedia.org/wiki/Calendrier_h%C3%A9bra%C3%AFque",
      "https://fr.wikipedia.org/wiki/Nissan_(mois)",
      "https://fr.wikipedia.org/wiki/Iyar",
      "https://fr.wikipedia.org/wiki/Sivan",
      "https://fr.wikipedia.org/wiki/Tammouz",
      "https://fr.wikipedia.org/wiki/Av",
      "https://fr.wikipedia.org/wiki/Eloul",
      "https://fr.wikipedia.org/wiki/Tishri",
      "https://fr.wikipedia.org/wiki/Heshvan",
      "https://fr.wikipedia.org/wiki/Kislev",
      "https://fr.wikipedia.org/wiki/Tevet",
      "https://fr.wikipedia.org/wiki/Shevat",
      "https://fr.wikipedia.org/wiki/Adar",
      "https://fr.wikipedia.org/wiki/Adar"
    ]
  };

}
