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
/// <edited> 2019-01 </edited>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private enum CalendarFieldType { Date, Month, Sun, Moon, Events }

    private enum EphemerisType { Rise, Set, SummerHour, WinterHour }

    string HeaderSep;
    string HeaderTxt;
    string ColumnSepLeft = "| ";
    string ColumnSepInner = " | ";
    string ColumnSepRight = " |";
    string ShabatText = "[S]";
    int ColumnEventLenght = 38;
    string MoonNoText = "        ";
    public string MoonNewText = "●";
    public string MoonFullText = "○";

    bool TrimBeforeNewLunarYear = true;
    bool ShowWinterSummerHour = true;
    bool ShowShabat = true;

    private Dictionary<CalendarFieldType, int> CalendarFieldSize
      = new Dictionary<CalendarFieldType, int>()
      {
        { CalendarFieldType.Date, 16 },
        { CalendarFieldType.Month, 11 },
        { CalendarFieldType.Sun, 23 },
        { CalendarFieldType.Moon, 21 },
        { CalendarFieldType.Events, 40 },
      };

    static private readonly Dictionary<EphemerisType, Dictionary<string, string>> EphemerisNames
      = new Dictionary<EphemerisType, Dictionary<string, string>>()
      {
        {
          EphemerisType.Rise, new Dictionary<string, string>
          {
            { "en", "R: " },
            { "fr", "L: " }
          }
        },
        {
          EphemerisType.Set, new Dictionary<string, string>
          {
            { "en", "S: " },
            { "fr", "C: " }
          }
        },
        {
          EphemerisType.SummerHour, new Dictionary<string, string>
          {
            { "en", "(S)" },
            { "fr", "(E)" }
          }
        },
        {
          EphemerisType.WinterHour, new Dictionary<string, string>
          {
            { "en", "(W)" },
            { "fr", "(H)" }
          }
        }
      };

    static private readonly Dictionary<CalendarFieldType, Dictionary<string, string>> CalendarFieldNames
      = new Dictionary<CalendarFieldType, Dictionary<string, string>>()
      {
        {
          CalendarFieldType.Date, new Dictionary<string, string>
          {
            { "en", "Date" },
            { "fr", "Date" }
          }
        },
        {
          CalendarFieldType.Month, new Dictionary<string, string>
          {
            { "en", "Month" },
            { "fr", "Mois" }
          }
        },
        {
          CalendarFieldType.Sun, new Dictionary<string, string>
          {
            { "en", "Sun" },
            { "fr", "Soleil" }
          }
        },
        {
          CalendarFieldType.Moon, new Dictionary<string, string>
          {
            { "en", "Moon" },
            { "fr", "Lune" }
          }
        },
        {
          CalendarFieldType.Events, new Dictionary<string, string>
          {
            { "en", "Events" },
            { "fr", "Évènements" }
          }
        }
      };

  }

}
