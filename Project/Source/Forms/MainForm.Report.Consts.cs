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
using System.Collections.Generic;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private enum ReportFieldType { Date, Month, Sun, Moon, Events }

    private enum EphemerisType { Rise, Set, SummerHour, WinterHour }

    const int ColumnEventLenght = 38;
    const string SeparatorV = "|";
    const string SeparatorH = "-";
    const string ColumnSepLeft = SeparatorV + " ";
    const string ColumnSepInner = " " + SeparatorV + " ";
    const string ColumnSepRight = " " + SeparatorV;
    const string MoonNoText = "        ";
    const string ShabatText = "[S]";
    const string MoonFullText = "○";
    internal readonly string MoonNewText = "●";

    private bool TrimBeforeNewLunarYear = true;
    private bool ShowWinterSummerHour = true;
    private bool ShowShabat = true;

    private Dictionary<ReportFieldType, int> CalendarFieldSize
      = new Dictionary<ReportFieldType, int>()
      {
        { ReportFieldType.Date, 16 },
        { ReportFieldType.Month, 11 },
        { ReportFieldType.Sun, 23 },
        { ReportFieldType.Moon, 21 },
        { ReportFieldType.Events, 40 },
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

    static private readonly Dictionary<ReportFieldType, Dictionary<string, string>> CalendarFieldNames
      = new Dictionary<ReportFieldType, Dictionary<string, string>>()
      {
        {
          ReportFieldType.Date, new Dictionary<string, string>
          {
            { "en", "Date" },
            { "fr", "Date" }
          }
        },
        {
          ReportFieldType.Month, new Dictionary<string, string>
          {
            { "en", "Month" },
            { "fr", "Mois" }
          }
        },
        {
          ReportFieldType.Sun, new Dictionary<string, string>
          {
            { "en", "Sun" },
            { "fr", "Soleil" }
          }
        },
        {
          ReportFieldType.Moon, new Dictionary<string, string>
          {
            { "en", "Moon" },
            { "fr", "Lune" }
          }
        },
        {
          ReportFieldType.Events, new Dictionary<string, string>
          {
            { "en", "Events" },
            { "fr", "Évènements" }
          }
        }
      };

  }

}
