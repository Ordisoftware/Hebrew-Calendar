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
/// <edited> 2021-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// View mode enum.
/// </summary>
[Flags]
public enum ViewMode
{

  None = 0,

  /// <summary>
  /// Text view mode to display the report.
  /// </summary>
  Text = 1,

  /// <summary>
  /// Month view mode to display the month calendar.
  /// </summary>
  Month = 2,

  /// <summary>
  /// Grid view mode to display the database table.
  /// </summary>
  Grid = 4

}
