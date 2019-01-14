/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2016-04 </edited>
using System;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide the torah events type (flags).
  /// </summary>
  [Flags]
  public enum TorahEventType
  {
    /// <summary>
    /// The no event flag.
    /// </summary>
    None = 0,

    /// <summary>
    /// The shabat flag.
    /// </summary>
    Shabat = 1 << 1,

    /// <summary>
    /// The new year day 1 flag.
    /// </summary>
    NewYearD1 = 1 << 2,

    /// <summary>
    /// The new year day 10 flag.
    /// </summary>
    NewYearD10 = 1 << 3,

    /// <summary>
    /// The pessah first day flag.
    /// </summary>
    PessahD1 = 1 << 4,

    /// <summary>
    /// The pessah last day flag.
    /// </summary>
    PessahD8 = 1 << 5,

    /// <summary>
    /// The chavouot diet start flag.
    /// </summary>
    ChavouotDiet = 1 << 6,

    /// <summary>
    /// The chavouot first celebration flag.
    /// </summary>
    Chavouot1 = 1 << 7,

    /// <summary>
    /// The chavouot second celebration flag.
    /// </summary>
    Chavouot2 = 1 << 8,

    /// <summary>
    /// The yom terouah flag.
    /// </summary>
    YomTerouah = 1 << 9,

    /// <summary>
    /// The yom hakipourim flag.
    /// </summary>
    YomHaKipourim = 1 << 10,

    /// <summary>
    /// The soukot first day flag.
    /// </summary>
    SoukotD1 = 1 << 11,

    /// <summary>
    /// The soukot last day flag.
    /// </summary>
    SoukotD8 = 1 << 12

  }

}
