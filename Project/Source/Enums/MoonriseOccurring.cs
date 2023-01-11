/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2016-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Moon rise occurring enum.
/// </summary>
public enum MoonriseOccurring
{

  /// <summary>
  /// Moonrise is after moonset.
  /// </summary>
  AfterSet,

  /// <summary>
  /// Moonrise is before moonset.
  /// </summary>
  BeforeSet,

  /// <summary>
  /// Moonrise is on next day.
  /// </summary>
  NextDay

}
