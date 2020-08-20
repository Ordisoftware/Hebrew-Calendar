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

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static public readonly Dictionary<string, string> AskToGenerateBigCalendar1
      = new Dictionary<string, string>()
      {
        { "en", "Generate a calendar for more than {0} ({1}) years is not recommanded" + NewLine +
                "and may cause a slight slowdown." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Générer un calendrier pour plus de {0} ({1}) ans n'est pas recommandé" + NewLine +
                "et peut causer un léger ralentissement." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> AskToGenerateBigCalendar2
      = new Dictionary<string, string>()
      {
        { "en", "Generate a calendar for more than {0} ({1}) years is not recommanded" + NewLine +
                "and may cause a noticeable slowdown." + NewLine + NewLine +
                "Do not use this value for a daily usage." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Générer un calendrier pour plus de {0} ({1}) ans n'est pas recommandé" + NewLine +
                "et peut causer un ralentissement notable." + NewLine + NewLine +
                "N'utilisez pas cette valeur pour un usage quotidien." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> AskToGenerateBigCalendar3
      = new Dictionary<string, string>()
      {
        { "en", "Generate a calendar for more than {0} ({1}) years is not recommanded" + NewLine +
                "and can cause a significant slowdown." + NewLine + NewLine +
                "Use this value only for occasional searches." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Générer un calendrier pour plus de {0} ({1}) ans n'est pas recommandé" + NewLine +
                "et peut causer un important ralentissement." + NewLine + NewLine +
                "N'utilisez cette valeur que pour des recherches ponctuelles." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> AskToGenerateBigCalendar4
      = new Dictionary<string, string>()
      {
        { "en", "Generate a calendar for more than {0} ({1}) years is not recommanded" + NewLine +
                "and can cause a considerable slowdown." + NewLine + NewLine +
                "Use this value only with a powerful computer." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Générer un calendrier pour plus de {0} ({1}) ans n'est pas recommandé" + NewLine +
                "et peut causer ralentissement considérable." + NewLine + NewLine +
                "N'utiliser cette valeur qu'avec un ordinateur puissant." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

  }

}
