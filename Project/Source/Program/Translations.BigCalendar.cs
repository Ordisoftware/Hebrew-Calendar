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
/// <created> 2020-04 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static private readonly string AskToGenerateBigCalendarEN
      = "Generate a calendar for more than {0} ({1}) years is not recommanded and can cause ";

    static private readonly string AskToGenerateBigCalendarFR
      = "Générer un calendrier pour plus de {0} ({1}) ans n'est pas recommandé et peut causer ";

    static public readonly Dictionary<string, string> AskToGenerateBigCalendar1
      = new Dictionary<string, string>()
      {
        { "en", AskToGenerateBigCalendarEN + "a slight slowdown." + NewLine + NewLine +
                Globals.DoYouWantToContinue["en"] },
        { "fr", AskToGenerateBigCalendarFR + "un léger ralentissement." + NewLine + NewLine +
                Globals.DoYouWantToContinue["fr"] },
      };

    static public readonly Dictionary<string, string> AskToGenerateBigCalendar2
      = new Dictionary<string, string>()
      {
        { "en", AskToGenerateBigCalendarEN + "a noticeable slowdown." + NewLine + NewLine +
                "Do not use this value for a daily usage." + NewLine + NewLine +
                Globals.DoYouWantToContinue["en"] },
        { "fr", AskToGenerateBigCalendarFR + "un ralentissement notable." + NewLine + NewLine +
                "N'utilisez pas cette valeur pour un usage quotidien." + NewLine + NewLine +
                Globals.DoYouWantToContinue["fr"] },
      };

    static public readonly Dictionary<string, string> AskToGenerateBigCalendar3
      = new Dictionary<string, string>()
      {
        { "en", AskToGenerateBigCalendarEN + "a significant slowdown." + NewLine + NewLine +
                "Use this value only for occasional searches." + NewLine + NewLine +
                Globals.DoYouWantToContinue["en"] },
        { "fr", AskToGenerateBigCalendarFR + "un important ralentissement." + NewLine + NewLine +
                "N'utilisez cette valeur que pour des recherches ponctuelles." + NewLine + NewLine +
                Globals.DoYouWantToContinue["fr"] },
      };

    static public readonly Dictionary<string, string> AskToGenerateBigCalendar4
      = new Dictionary<string, string>()
      {
        { "en", AskToGenerateBigCalendarEN + "a considerable slowdown." + NewLine + NewLine +
                "Use this value only with a powerful computer." + NewLine + NewLine +
                Globals.DoYouWantToContinue["en"] },
        { "fr", AskToGenerateBigCalendarFR + "ralentissement considérable." + NewLine + NewLine +
                "N'utiliser cette valeur qu'avec un ordinateur puissant." + NewLine + NewLine +
                Globals.DoYouWantToContinue["fr"] },
      };

  }

}
