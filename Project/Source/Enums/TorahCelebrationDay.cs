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
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Torah event enum.
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
  /// Shavou'ot diet start.
  /// </summary>
  ChavouotDiet,

  /// <summary>
  /// Shavou'ot first celebration.
  /// </summary>
  Chavouot1,

  /// <summary>
  /// Shavou'ot second celebration.
  /// </summary>
  Chavouot2,

  /// <summary>
  /// Yom Terou'ah.
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

  // Non database values (always at the end)

  /// <summary>
  /// Shabat day.
  /// </summary>
  Shabat

}

/*
/// <summary>
/// Sun anniversary.
/// </summary>
AnniversarySun,

/// <summary>
/// Moon anniversary.
/// </summary>
AnniversaryMoon
*/
