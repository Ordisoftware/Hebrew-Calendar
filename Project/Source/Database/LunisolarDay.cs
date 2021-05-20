﻿/// <license>
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
/// <created> 2021-05 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Collections.Generic;
using SQLite;

namespace Ordisoftware.Hebrew.Calendar
{

  [Serializable]
  [Table("LunisolarDays")]
  public partial class LunisolarDay
  {
    [PrimaryKey]
    public DateTime Date { get; set; }
    public int LunarMonth { get; set; }
    public int LunarDay { get; set; }
    public DateTime? Sunrise { get; set; }
    public DateTime? Sunset { get; set; }
    public DateTime? Moonrise { get; set; }
    public DateTime? Moonset { get; set; }
    public string DateAsString { get; set; }
    public string SunriseAsString { get; set; }
    public string SunsetAsString { get; set; }
    public string MoonriseAsString { get; set; }
    public string MoonsetAsString { get; set; }
    public MoonriseOccuring MoonriseOccuring { get; set; }
    public bool IsNewMoon { get; set; }
    public bool IsFullMoon { get; set; }
    public MoonPhase MoonPhase { get; set; }
    public SeasonChange SeasonChange { get; set; }
    public TorahEvent TorahEvent { get; set; }
    public string TorahEventText { get; set; }
    public string ParashahID { get; set; }
    public string LinkedParashahID { get; set; }

    [Ignore]
    public List<LunisolarDay> Table => ApplicationDatabase.Instance.LunisolarDays;

    public bool IsNewYear
      => TorahEvent == TorahEvent.NewYearD1;

    public bool HasSeasonChange
      => SeasonChange != SeasonChange.None;

    public bool HasTorahEvent
      => TorahEvent != TorahEvent.None;

    public string DayAndMonthText
      => LunarDay + " " + HebrewMonths.Transliterations[LunarMonth];

    public string DayAndMonthWithYearText
      => DayAndMonthText + " " + Date.Year;

    public string DayAndMonthFormattedText
      => Program.Settings.MoonDayTextFormat.ToUpper()
                .Replace("%MONTHNAME%", HebrewMonths.Transliterations[LunarMonth])
                .Replace("%MONTHNUM%", LunarMonth.ToString())
                .Replace("%DAYNUM%", LunarDay.ToString());

  }

}
