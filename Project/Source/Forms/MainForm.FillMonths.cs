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
/// <edited> 2016-04 </edited>
using System;
using System.Drawing;
using Calendar.NET;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void FillMonths()
    {
      string strToolTip = "Error on getting sun rise and set";
      int progress = 0;
      foreach ( var row in LunisolarCalendar.LunisolarDays )
      {
        if ( !UpdateProgress(progress++, Count, Localizer.ProgressFillMonthsText.GetLang()) ) return;
        int rank = 0;
        void add(Color color, string text)
        {
          var item = new CustomEvent();
          item.Date = SQLiteUtility.GetDate(row.Date);
          item.EventFont = new Font("Calibri", 9f);
          item.EventColor = Color.White;
          item.EventTextColor = color;
          item.EventText = text;
          item.Rank = rank++;
          item.TooltipEnabled = true;
          item.IgnoreTimeComponent = true;
          item.ToolTipText = strToolTip;
          CalendarMonth.AddEvent(item);
        }
        strToolTip = EphemerisNames.GetLang(EphemerisType.Rise) + row.Sunrise + Environment.NewLine 
                   + EphemerisNames.GetLang(EphemerisType.Set) + row.Sunset;
        Color colorMoon = Color.Black;
        string strMonth = row.IsNewMoon == 1
                        ? " " + TorahCelebrations.BabylonianHebrewMonthNames[row.LunarMonth]
                        : "";
        colorMoon = row.IsNewMoon == 1
                  ? Color.DarkRed
                  : ( row.IsFullMoon == 1 ? Color.DarkGoldenrod : Color.DarkBlue );
        if ( (MoonriseType)row.MoonriseType == MoonriseType.AfterSet )
        {
          add(Color.Black, EphemerisNames.GetLang(EphemerisType.Set) + row.Moonset);
          if ( (MoonriseType)row.MoonriseType != MoonriseType.NextDay )
            add(colorMoon, EphemerisNames.GetLang(EphemerisType.Rise) + row.Moonrise + " #" + row.LunarDay + strMonth);
        }
        else
        {
          if ( (MoonriseType)row.MoonriseType != MoonriseType.NextDay )
            add(colorMoon, EphemerisNames.GetLang(EphemerisType.Rise) + row.Moonrise + " #" + row.LunarDay + strMonth);
          add(Color.Black, EphemerisNames.GetLang(EphemerisType.Set) + row.Moonset);
        }
        if ( row.SeasonChange != 0 )
          add(Color.DarkGreen, TorahCelebrations.SeasonEventNames.GetLang((SeasonChangeType)row.SeasonChange));
        if ( row.TorahEvents != 0 )
          add(Color.DarkRed, TorahCelebrations.TorahEventNames.GetLang((TorahEventType)row.TorahEvents));
      }
    }

  }

}
