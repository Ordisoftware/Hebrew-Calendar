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
/// <created> 2020-04 </created>
/// <edited> 2020-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public readonly TranslationsDictionary ClickOnIgnoreToDisableOption = new()
  {
    [Language.EN] = "Click Cancel to process and disable this option.",

    [Language.FR] = "Cliquez sur Annuler pour valider et désactiver cette option.",
  };

  static public readonly TranslationsDictionary AskToRegenerate = new()
  {
    [Language.EN] = "Current years interval is greater than {0} ({1})." + Globals.NL2 +
                    "Do you want to regenerate the data for the next {0} years?" + Globals.NL2 +
                    ClickOnIgnoreToDisableOption[Language.EN],

    [Language.FR] = "L'intervalle des années en cours est supérieur à {0} ({1})." + Globals.NL2 +
                    "Voulez-vous régénérer les données pour les {0} prochaines années ?" + Globals.NL2 +
                    ClickOnIgnoreToDisableOption[Language.FR],
  };

  private const string AskToGenerateBigCalendarEN
    = "Generate a calendar for more than {0} ({1}) years is not recommended and can cause ";

  private const string AskToGenerateBigCalendarFR
    = "Générer un calendrier pour plus de {0} ({1}) ans n'est pas recommandé et peut causer ";

  static public readonly NullSafeList<TranslationsDictionary> AskToGenerateBigCalendar = new()
  {
    new TranslationsDictionary
    {
      [Language.EN] = AskToGenerateBigCalendarEN + "a slight slowdown." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.EN] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.EN],

      [Language.FR] = AskToGenerateBigCalendarFR + "un léger ralentissement." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.FR] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.FR]
    },
    new TranslationsDictionary
    {
      [Language.EN] = AskToGenerateBigCalendarEN + "a noticeable slowdown." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.EN] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.EN],

      [Language.FR] = AskToGenerateBigCalendarFR + "un ralentissement notable." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.FR] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.FR]
    },
    new TranslationsDictionary
    {
      [Language.EN] = AskToGenerateBigCalendarEN + "a significant slowdown." + Globals.NL2 +
                      "Do not use this value for a daily usage." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.EN] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.EN],

      [Language.FR] = AskToGenerateBigCalendarFR + "un ralentissement important." + Globals.NL2 +
                      "N'utilisez pas cette valeur pour un usage quotidien." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.FR] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.FR]
    },
    new TranslationsDictionary
    {
      [Language.EN] = AskToGenerateBigCalendarEN + "a considerable slowdown." + Globals.NL2 +
                      "Use this value only for occasional searches." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.EN] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.EN],

      [Language.FR] = AskToGenerateBigCalendarFR + "ralentissement considérable." + Globals.NL2 +
                      "N'utilisez cette valeur que pour des recherches ponctuelles." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.FR] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.FR]
    },
    new TranslationsDictionary
    {
      [Language.EN] = AskToGenerateBigCalendarEN + "a serious slowdown." + Globals.NL2 +
                      "Use this value only with a powerful computer." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.EN] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.EN],

      [Language.FR] = AskToGenerateBigCalendarFR + "ralentissement sévère." + Globals.NL2 +
                      "N'utiliser cette valeur qu'avec un ordinateur puissant." + Globals.NL2 +
                      SysTranslations.AskToContinue[Language.FR] + Globals.NL2 +
                      ClickOnIgnoreToDisableOption[Language.FR]
    }
  };

}
