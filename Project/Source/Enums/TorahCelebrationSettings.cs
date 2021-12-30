/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Torah celebrations days and durations.
/// </summary>
static class TorahCelebrationSettings
{

  /// <summary>
  /// The pessah month.
  /// </summary>
  static public readonly int PessahMonth = 1;

  /// <summary>
  /// The spring lamb day.
  /// </summary>
  static public readonly int NewLambDay = 10;

  /// <summary>
  /// The pessah start day.
  /// </summary>
  static public readonly int PessahStartDay = 14;

  /// <summary>
  /// The pessah length.
  /// </summary>
  static public readonly int PessahLenght = 7;

  /// <summary>
  /// The pessah last day.
  /// </summary>
  static public readonly int PessahEndDay = PessahStartDay + PessahLenght - 1;

  /// <summary>
  /// The chavouot length.
  /// </summary>
  static public readonly int ChavouotLenght = 50;

  /// <summary>
  /// The Yoms month.
  /// </summary>
  static public readonly int YomsMonth = 7;

  /// <summary>
  /// The hakipourim day.
  /// </summary>
  static public readonly int YomHaKipourimDay = 10;

  /// <summary>
  /// The soukot start day.
  /// </summary>
  static public readonly int SoukotStartDay = 15;

  /// <summary>
  /// The soukot length.
  /// </summary>
  static public readonly int SoukotLenght = 7 + 1;

  /// <summary>
  /// The soukot last day.
  /// </summary>
  static public readonly int SoukotEndDay = SoukotStartDay + SoukotLenght - 1;

  /// <summary>
  /// The 'hanouka month.
  /// </summary>
  static public readonly int HanoukaMonth = 9;

  /// <summary>
  /// The 'hanouka day.
  /// </summary>
  static public readonly int HanoukaStartDay = 25;

  /// <summary>
  /// The 'hanouka length.
  /// </summary>
  static public readonly int HanoukaLenght = 7 + 1;

  /// <summary>
  /// The 'hanouka last day.
  /// </summary>
  static public readonly int HanoukaEndDay = HanoukaStartDay + HanoukaEndDay - 1;

  /// <summary>
  /// The pourim month.
  /// </summary>
  static public readonly int PourimMonth = 12;

  /// <summary>
  /// The pourim day.
  /// </summary>
  static public readonly int PourimDay = 14;

  /// <summary>
  /// Indicates managed events list.
  /// </summary>
  static public readonly IEnumerable<TorahCelebrationDay> ManagedEvents
    = Enums.GetValues<TorahCelebrationDay>()
           .Skip(1)
           .TakeUntil(v => v == TorahCelebrationDay.SoukotD8);

  /// <summary>
  /// Indicates major avents list.
  /// </summary>
  static public readonly IEnumerable<TorahCelebrationDay> MajorEvents
    = Enums.GetValues<TorahCelebrationDay>()
           .SkipUntil(v => v == TorahCelebrationDay.NewYearD10)
           .TakeUntil(v => v == TorahCelebrationDay.SoukotD8);

  /// <summary>
  /// Indicates minor avents list.
  /// </summary>
  static public readonly IEnumerable<TorahCelebrationDay> MinorEvents
    = Enums.GetValues<TorahCelebrationDay>()
           .SkipUntil(v => v == TorahCelebrationDay.SoukotD8)
           .TakeUntil(v => v == TorahCelebrationDay.Pourim);

  /// <summary>
  /// Indicates special celebration days.
  /// </summary>
  static public readonly IEnumerable<TorahCelebrationDay> SpecialDays
    = new List<TorahCelebrationDay>
    {
        TorahCelebrationDay.PessahD1,
        TorahCelebrationDay.PessahD7,
        TorahCelebrationDay.YomTerouah,
        TorahCelebrationDay.YomHaKipourim,
        TorahCelebrationDay.SoukotD1,
        TorahCelebrationDay.SoukotD8
    };

}
