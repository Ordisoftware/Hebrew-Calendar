/// <license>
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
/// <created> 2020-08 </created>
/// <edited> 2021-08 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public readonly NullSafeDictionary<Language, NullSafeList<SuspendDelayItem>> SuspendReminderDelays = new()
  {
    [Language.EN] =
    [
      new("None", 0),
      new("5 minutes", 5),
      new("10 minutes", 10),
      new("15 minutes", 15),
      new("30 minutes", 30),
      new("1 hour", 60),
      new("2 hours", 120),
      new("3 hours", 180),
      new("4 hours", 240),
      new("6 hours", 360),
      new("8 hours", 480),
      new("10 hours", 600),
      new("12 hours", 720),
      new("1 day", 1440),
      new("Custom", -1)
    ],
    [Language.FR] =
    [
      new("Aucun", 0),
      new("5 minutes", 5),
      new("10 minutes", 10),
      new("15 minutes", 15),
      new("30 minutes", 30),
      new("1 heure", 60),
      new("2 heures", 120),
      new("3 heures", 180),
      new("4 heures", 240),
      new("6 heures", 360),
      new("8 heures", 480),
      new("10 heures", 600),
      new("12 heures", 720),
      new("1 jour", 1440),
      new("Personnalisé", -1)
    ]
  };

}
