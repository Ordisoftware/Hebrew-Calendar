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
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Torah celebrations days and durations.
/// </summary>
static class TorahCelebrationSettings
{

  /// <summary>
  /// Pessa'h month.
  /// </summary>
  static public readonly int PessahMonth = 1;

  /// <summary>
  /// Spring lamb day.
  /// </summary>
  static public readonly int NewLambDay = 10;

  /// <summary>
  /// Pessa'h start day.
  /// </summary>
  static public readonly int PessahStartDay = 14;

  /// <summary>
  /// Pessa'h length.
  /// </summary>
  static public readonly int PessahLenght = 7;

  /// <summary>
  /// Pessa'h last day.
  /// </summary>
  static public readonly int PessahEndDay = PessahStartDay + PessahLenght - 1;

  /// <summary>
  /// Shavouh'ot length.
  /// </summary>
  static public readonly int ChavouotLenght = 50;

  /// <summary>
  /// 'Hanouka month.
  /// </summary>
  static public readonly int ChavouotMonth = 3;

  /// <summary>
  /// Yoms month.
  /// </summary>
  static public readonly int YomsMonth = 7;

  /// <summary>
  /// Yom Terouh'ah day.
  /// </summary>
  static public readonly int YomTerouahDay = 1;

  /// <summary>
  /// Yom HaKipourim day.
  /// </summary>
  static public readonly int YomHaKipourimDay = 10;

  /// <summary>
  /// Soukot start day.
  /// </summary>
  static public readonly int SoukotStartDay = 15;

  /// <summary>
  /// Soukot length.
  /// </summary>
  static public readonly int SoukotLenght = 7 + 1;

  /// <summary>
  /// Soukot last day.
  /// </summary>
  static public readonly int SoukotEndDay = SoukotStartDay + SoukotLenght - 1;

  /// <summary>
  /// Pessa'h month.
  /// </summary>
  static public readonly int SimhatTorah = 22;

  /// <summary>
  /// 'Hanouka month.
  /// </summary>
  static public readonly int HanoukaMonth = 9;

  /// <summary>
  /// 'Hanouka day.
  /// </summary>
  static public readonly int HanoukaStartDay = 25;

  /// <summary>
  /// 'Hanouka length.
  /// </summary>
  static public readonly int HanoukaLenght = 7 + 1;

  /// <summary>
  /// 'Hanouka last day.
  /// </summary>
  static public readonly int HanoukaEndDay = HanoukaStartDay + HanoukaEndDay - 1;

  /// <summary>
  /// Pourim month.
  /// </summary>
  static public readonly int PourimMonth = 12; // or 13 for a year with Adar II

  /// <summary>
  /// Pourim day.
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

  static public TorahCelebration Convert(TorahCelebrationDay torahevent) => torahevent switch
  {
    TorahCelebrationDay.NewYearD10 => TorahCelebration.Pessah,
    TorahCelebrationDay.PessahD1 => TorahCelebration.Pessah,
    TorahCelebrationDay.PessahD7 => TorahCelebration.Pessah,
    TorahCelebrationDay.Chavouot1 => TorahCelebration.Chavouot,
    TorahCelebrationDay.ChavouotDiet => TorahCelebration.Chavouot,
    TorahCelebrationDay.Chavouot2 => TorahCelebration.Chavouot,
    TorahCelebrationDay.YomTerouah => TorahCelebration.YomTerouah,
    TorahCelebrationDay.YomHaKipourim => TorahCelebration.YomHaKipourim,
    TorahCelebrationDay.SoukotD1 => TorahCelebration.Soukot,
    TorahCelebrationDay.SoukotD8 => TorahCelebration.Soukot,
    _ => TorahCelebration.None
  };

}
