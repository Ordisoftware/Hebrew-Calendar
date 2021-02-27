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
/// <created> 2020-12 </created>
/// <edited> 2020-12 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    partial class LunisolarDaysRow
    {

      public string DayAndMonthText
        => LunarDay + " " + HebrewMonths.Transliterations[LunarMonth];

      public string DayAndMonthWithYearText
        => DayAndMonthText + " " + int.Parse(Date.Substring(0,4));

      public string DayAndMonthFormattedText
        => Program.Settings.MoonDayTextFormat.ToUpper()
                  .Replace("%MONTHNAME%", HebrewMonths.Transliterations[LunarMonth])
                  .Replace("%MONTHNUM%", LunarMonth.ToString())
                  .Replace("%DAYNUM%", LunarDay.ToString());

    }

  }

}
