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
/// <edited> 221-02 </edited>
using System;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Torah event enum.
  /// </summary>
  public enum TorahEvent
  {

    // Database values

    /// <summary>
    /// The no event.
    /// </summary>
    None,

    /// <summary>
    /// The new year day 1.
    /// </summary>
    NewYearD1,

    /// <summary>
    /// The new year day 10.
    /// </summary>
    NewYearD10,

    /// <summary>
    /// The pessah first day.
    /// </summary>
    PessahD1,

    /// <summary>
    /// The pessah last day.
    /// </summary>
    PessahD7,

    /// <summary>
    /// The chavouot diet start.
    /// </summary>
    ChavouotDiet,

    /// <summary>
    /// The chavouot first celebration.
    /// </summary>
    Chavouot1,

    /// <summary>
    /// The chavouot second celebration.
    /// </summary>
    Chavouot2,

    /// <summary>
    /// The yom terouah.
    /// </summary>
    YomTerouah,

    /// <summary>
    /// The yom hakipourim.
    /// </summary>
    YomHaKipourim,

    /// <summary>
    /// The soukot first day.
    /// </summary>
    SoukotD1,

    /// <summary>
    /// The soukot last day.
    /// </summary>
    SoukotD8,

    /// <summary>
    /// The shabat day.
    /// </summary>
    Shabat,

    // TODO manage as user custom remind list
    // Actually non database values
    /*
    /// <summary>
    /// The 'hanouka first day.
    /// </summary>
    HanoukaD1,

    /// <summary>
    /// The 'hanouka last day.
    /// </summary>
    HanoukaD8,

    /// <summary>
    /// The pourim day.
    /// </summary>
    Pourim,

    /// <summary>
    /// The sun aniversary.
    /// </summary>
    AnniversarySun,

    /// <summary>
    /// The moon aniversary.
    /// </summary>
    AnniversaryMoon*/

    // Hanouka = 25 Kislev(9) 8j
    // Pourim = 14 Adar(12)

  }

}
