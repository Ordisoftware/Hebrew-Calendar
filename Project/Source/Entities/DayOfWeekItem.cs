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
/// <created> 2016-04 </created>
/// <edited> 2016-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides day of week item to be displayed in a control.
/// </summary>
class DayOfWeekItem
{

  /// <summary>
  /// Indicates the text of the day.
  /// </summary>
  public string Text { get; set; }

  /// <summary>
  /// Indicates the day of week public enum value.
  /// </summary>
  public System.DayOfWeek Day { get; set; }

  /// <summary>
  /// Returns a <see cref="T:System.String" /> that represents the day.
  /// </summary>
  public override string ToString() => Text;

}
