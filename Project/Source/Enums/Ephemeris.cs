/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
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
/// Ephemeris enum.
/// </summary>
public enum Ephemeris
{
  /// <summary>
  /// Moon or sun rise.
  /// </summary>
  Rise,

  /// <summary>
  /// Moon or sun set.
  /// </summary>
  Set,

  /// <summary>
  /// In daylight saving time.
  /// </summary>
  SummerHour,

  /// <summary>
  /// Not in daylight saving time.
  /// </summary>
  WinterHour

}
