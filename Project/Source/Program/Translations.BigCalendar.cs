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
/// <edited> 2020-08 </edited>
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

    static public readonly List<Dictionary<string, string>> AskToGenerateBigCalendar
      = new List<Dictionary<string, string>>
      {
        new Dictionary<string, string>
          {
            { Localizer.EN, AskToGenerateBigCalendarEN + "a slight slowdown." + Localizer.NL + Localizer.NL +
                            Globals.DoYouWantToContinue[Localizer.EN] },
            { Localizer.FR, AskToGenerateBigCalendarFR + "un léger ralentissement." + Localizer.NL + Localizer.NL +
                            Globals.DoYouWantToContinue[Localizer.FR] },
        },
        new Dictionary<string, string>
        {
          { Localizer.EN, AskToGenerateBigCalendarEN + "a noticeable slowdown." + Localizer.NL + Localizer.NL +
                          Globals.DoYouWantToContinue[Localizer.EN] },
          { Localizer.FR, AskToGenerateBigCalendarFR + "un ralentissement notable." + Localizer.NL + Localizer.NL +
                          Globals.DoYouWantToContinue[Localizer.FR] },
        },
        new Dictionary<string, string>
        {
          { Localizer.EN, AskToGenerateBigCalendarEN + "a significant slowdown." + Localizer.NL + Localizer.NL +
                          "Do not use this value for a daily usage." + Localizer.NL + Localizer.NL +
                          Globals.DoYouWantToContinue[Localizer.EN] },
          { Localizer.FR, AskToGenerateBigCalendarFR + "un ralentissement important." + Localizer.NL + Localizer.NL +
                          "N'utilisez pas cette valeur pour un usage quotidien." + Localizer.NL + Localizer.NL +
                          Globals.DoYouWantToContinue[Localizer.FR] },
        },
        new Dictionary<string, string>
        {
          { Localizer.EN, AskToGenerateBigCalendarEN + "a considerable slowdown." + Localizer.NL + Localizer.NL +
                          "Use this value only for occasional searches." + Localizer.NL + Localizer.NL +
                          Globals.DoYouWantToContinue[Localizer.EN] },
          { Localizer.FR, AskToGenerateBigCalendarFR + "ralentissement considérable." + Localizer.NL + Localizer.NL +
                          "N'utilisez cette valeur que pour des recherches ponctuelles." + Localizer.NL + Localizer.NL +
                          Globals.DoYouWantToContinue[Localizer.FR] },
        },
        new Dictionary<string, string>
        {
          { Localizer.EN, AskToGenerateBigCalendarEN + "a serious slowdown." + Localizer.NL + Localizer.NL +
                          "Use this value only with a powerful computer." + Localizer.NL + Localizer.NL +
                          Globals.DoYouWantToContinue[Localizer.EN] },
          { Localizer.FR, AskToGenerateBigCalendarFR + "ralentissement sévère." + Localizer.NL + Localizer.NL +
                          "N'utiliser cette valeur qu'avec un ordinateur puissant." + Localizer.NL + Localizer.NL +
                          Globals.DoYouWantToContinue[Localizer.FR] },
        }
      };

  }

}
