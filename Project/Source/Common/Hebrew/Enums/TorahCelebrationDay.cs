/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2025 Olivier Rogier.
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
namespace Ordisoftware.Hebrew;

/// <summary>
/// Torah celebrations details.
/// </summary>
public enum TorahCelebrationDay
{

  // Database values for major celebrations

  /// <summary>
  /// No event.
  /// </summary>
  None,

  /// <summary>
  /// New year day 1.
  /// </summary>
  NewYearD1,

  /// <summary>
  /// New year day 10.
  /// </summary>
  NewYearD10,

  /// <summary>
  /// Pessa'h first day.
  /// </summary>
  PessahD1,

  /// <summary>
  /// Pessa'h last day.
  /// </summary>
  PessahD7,

  /// <summary>
  /// Shavouh'ot diet start.
  /// </summary>
  ChavouotDiet,

  /// <summary>
  /// Shavouh'ot first celebration.
  /// </summary>
  Chavouot1,

  /// <summary>
  /// Shavouh'ot second celebration.
  /// </summary>
  Chavouot2,

  /// <summary>
  /// Yom Terouh'ah.
  /// </summary>
  YomTerouah,

  /// <summary>
  /// Yom HaKipourim.
  /// </summary>
  YomHaKipourim,

  /// <summary>
  /// Soukot first day.
  /// </summary>
  SoukotD1,

  /// <summary>
  /// Soukot last day.
  /// </summary>
  SoukotD8,

  // Database values for minor celebrations

  /// <summary>
  /// 'Hanouka first day.
  /// </summary>
  HanoukaD1,

  /// <summary>
  /// 'Hanouka last day.
  /// </summary>
  HanoukaD8,

  /// <summary>
  /// Pourim day.
  /// </summary>
  Pourim,

  /// <summary>
  /// Lag Bah'omer day.
  /// </summary>
  LagBahomer,

  // Non database values, the value doesn't matter, always at the end.

  /// <summary>
  /// Shabat day.
  /// </summary>
  Shabat

}
