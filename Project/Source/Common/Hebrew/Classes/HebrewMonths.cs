/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2012-10 </created>
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

/// <summary>
/// Provides Hebrew months names.
/// </summary>
static public class HebrewMonths
{

  /// <summary>
  /// Indicates Unicode lunar months names.
  /// </summary>
  static public readonly string[] Unicode =
  {
    string.Empty,
    "ניסן",
    "איר",
    "סיון",
    "תמוז",
    "אב",
    "אלול",
    "תשרי",
    "חשון",
    "כסלו",
    "טבת",
    "שבט",
    "אדר",
    "ואדר"
  };

  /// <summary>
  /// Indicates phonetic lunar months names.
  /// </summary>
  static public readonly NullSafeDictionary<Language, string[]> Transcriptions = new()
  {
    [Language.EN] = new string[]
    {
      string.Empty,
      "Nisan",
      "Iyar",
      "Siwan",
      "Tamuz",
      "Av",
      "Elul",
      "Tishri",
      "'Heshvan",
      "Kislev",
      "Tevet'",
      "Shevat'",
      "Adar",
      "VeAdar",
    },
    [Language.FR] = new string[]
    {
      string.Empty,
      "Nissan",
      "Iyar",
      "Sivan",
      "Tamouz",
      "Av",
      "Eloul",
      "Tishri",
      "'Heshvan",
      "Kislev",
      "Tevet'",
      "Shevat'",
      "Adar",
      "VeAdar"
    }
  };

}
