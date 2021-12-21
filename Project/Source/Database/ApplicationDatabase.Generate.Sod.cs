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
/// <created> 2021-12 </created>
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase
{

  /// <summary>
  /// Creates the calendar items using Sod Ha'ibur.
  /// </summary>
  /// <remarkl>
  /// Omer is implicitly as sun and there is no difference between north and south hemisphere,
  /// thus all days are precalculated as sun omer.
  /// </remarkl>
  public bool AnalyseDaysSod(int progressCount)
  {
    // TODO Define months, celebrations, and parashot.
    return false;
  }

}
