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
/// <edited> 2022-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using static Ordisoftware.Hebrew.HebrewTranslations;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public readonly TranslationsDictionary Start = new()
  {
    [Language.EN] = "Start",
    [Language.FR] = "Début"
  };

  static public readonly TranslationsDictionary End = new()
  {
    [Language.EN] = "End",
    [Language.FR] = "Fin"
  };

  static public readonly TranslationsDictionary Lamb = new()
  {
    [Language.EN] = "Lamb",
    [Language.FR] = "Agneau"
  };

  static public readonly TranslationsDictionary VersesAboutCurrentCelebration = new()
  {
    [Language.EN] = "Verses about {0}",
    [Language.FR] = "Versets sur {0}"
  };

  static public readonly TranslationsDictionary VersesAboutNextCelebration = new()
  {
    [Language.EN] = "Verses about next {0}",
    [Language.FR] = "Versets sur prochain {0}"
  };

  static public readonly TranslationsDictionary PessahDay = new()
  {
    [Language.EN] = TorahCelebrations[TorahCelebration.Pessah][Language.EN] + " Day {0}",
    [Language.FR] = TorahCelebrations[TorahCelebration.Pessah][Language.FR] + " Jour {0}"
  };

  static public readonly TranslationsDictionary SoukotDay = new()
  {
    [Language.EN] = TorahCelebrations[TorahCelebration.Soukot][Language.EN] + " Day {0}",
    [Language.FR] = TorahCelebrations[TorahCelebration.Soukot][Language.FR] + " Jour {0}"
  };

  static public readonly NullSafeDictionary<TorahCelebrationDay, TranslationsDictionary> TorahCelebrationDays = new()
  {
    [TorahCelebrationDay.None] = new TranslationsDictionary
    {
      [Language.EN] = "",
      [Language.FR] = ""
    },
    [TorahCelebrationDay.NewYearD1] = new TranslationsDictionary
    {
      [Language.EN] = "New Year",
      [Language.FR] = "Nouvelle Année"
    },
    [TorahCelebrationDay.NewYearD10] = new TranslationsDictionary
    {
      [Language.EN] = "Set Aside " + Lamb[Language.EN],
      [Language.FR] = "Réserver " + Lamb[Language.FR]
    },
    [TorahCelebrationDay.PessahD1] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.Pessah][Language.EN] + " " + Start[Language.EN],
      [Language.FR] = TorahCelebrations[TorahCelebration.Pessah][Language.FR] + " " + Start[Language.FR]
    },
    [TorahCelebrationDay.PessahD7] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.Pessah][Language.EN] + " " + End[Language.EN],
      [Language.FR] = TorahCelebrations[TorahCelebration.Pessah][Language.FR] + " " + End[Language.FR]
    },
    [TorahCelebrationDay.ChavouotDiet] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.Chavouot][Language.EN] + " Diet",
      [Language.FR] = TorahCelebrations[TorahCelebration.Chavouot][Language.FR] + " Régime"
    },
    [TorahCelebrationDay.Chavouot1] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.Chavouot][Language.EN] + " " + Lamb[Language.EN],
      [Language.FR] = TorahCelebrations[TorahCelebration.Chavouot][Language.FR] + " " + Lamb[Language.FR]
    },
    [TorahCelebrationDay.Chavouot2] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.Chavouot][Language.EN] + " " + End[Language.EN],
      [Language.FR] = TorahCelebrations[TorahCelebration.Chavouot][Language.FR] + " " + End[Language.FR]
    },
    [TorahCelebrationDay.YomTerouah] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.YomTerouah][Language.EN],
      [Language.FR] = TorahCelebrations[TorahCelebration.YomTerouah][Language.FR]
    },
    [TorahCelebrationDay.YomHaKipourim] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.YomHaKipourim][Language.EN],
      [Language.FR] = TorahCelebrations[TorahCelebration.YomHaKipourim][Language.FR]
    },
    [TorahCelebrationDay.SoukotD1] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.Soukot][Language.EN] + " " + Start[Language.EN],
      [Language.FR] = TorahCelebrations[TorahCelebration.Soukot][Language.FR] + " " + Start[Language.FR]
    },
    [TorahCelebrationDay.SoukotD8] = new TranslationsDictionary
    {
      [Language.EN] = TorahCelebrations[TorahCelebration.Soukot][Language.EN] + " " + End[Language.EN],
      [Language.FR] = TorahCelebrations[TorahCelebration.Soukot][Language.FR] + " " + End[Language.FR]
    }
    // TODO manage as user custom remind list
    /*[TorahCelebrationDay.HanoukaD1] = new TranslationsDictionary
    {
      [Language.EN] = "'Hanouka start",
      [Language.FR] = "Début de 'Hanouka"
    },
    [TorahCelebrationDay.HanoukaD8] = new TranslationsDictionary
    {
      [Language.EN] = "'Hanouka end",
      [Language.FR] = "'Fin de Hanouka"
    },
    [TorahCelebrationDay.Pourim] = new TranslationsDictionary
    {
      [Language.EN] = "Pourim",
      [Language.FR] = "Pourim"
    },
    [TorahCelebrationDay.AnniversarySun] = new TranslationsDictionary
    {
      [Language.EN] = "Solar anniversary",
      [Language.FR] = "Anniversaire solaire"
    },
    [TorahCelebrationDay.AnniversaryMoon] = new TranslationsDictionary
    {
      [Language.EN] = "Lunar anniversary",
      [Language.FR] = "Anniversaire lunaire"
    }*/
  };

}
