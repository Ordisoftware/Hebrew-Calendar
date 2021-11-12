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
/// <created> 2019-10 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Collections.Generic;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  static partial class DayOfWeekMap
  {

    /// <summary>
    /// Provide mapping table for Calendar.NET names.
    /// </summary>
    static public readonly Dictionary<DayOfWeek, DayOfWeek[]> Names = new()
    {
      {
        DayOfWeek.Monday,
        new DayOfWeek[]
          {
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
          }
      },
      {
        DayOfWeek.Tuesday,
        new DayOfWeek[]
          {
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
          }
      },
      {
        DayOfWeek.Wednesday,
        new DayOfWeek[]
          {
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
          }
      },
      {
        DayOfWeek.Thursday,
        new DayOfWeek[]
          {
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
          }
      },
      {
        DayOfWeek.Friday,
        new DayOfWeek[]
          {
            DayOfWeek.Saturday,
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
          }
      },
      {
        DayOfWeek.Saturday,
        new DayOfWeek[]
          {
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
          }
      },
      {
        DayOfWeek.Sunday,
        new DayOfWeek[]
          {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday,
          }
      },
    };

    static public readonly Dictionary<Language, Dictionary<DayOfWeek, List<string>>> LocalizedNamesText = new();

    static DayOfWeekMap()
    {
      foreach ( var lang in Languages.Managed )
      {
        var dic = new Dictionary<DayOfWeek, List<string>>();
        LocalizedNamesText.Add(lang, dic);
        foreach ( var kvp in Names )
        {
          dic.Add(kvp.Key, new List<string>());
          foreach ( var item in kvp.Value )
          {
            dic[kvp.Key].Add(AppTranslations.DaysOfWeek[item][lang].Substring(0, 3));
          }
        }
      }
    }

  }

}
