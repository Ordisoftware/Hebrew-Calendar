﻿/// <license>
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
/// <created> 2020-08 </created>
/// <edited> 2021-05 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides calendar date item.
/// </summary>
class CalendarDateItem
{
  public DateTime Date { get; set; }
  public int MoonDay { get; set; }
  public MoonPhase MoonPhase { get; set; }
  public SeasonChange TorahSeasonChange { get; set; }
  public SeasonChange RealSeasonChange { get; set; }
  public SunAndMoonRiseAndSet Ephemeris { get; set; }
  public override string ToString() => SQLiteDate.ToString(Date);
}
