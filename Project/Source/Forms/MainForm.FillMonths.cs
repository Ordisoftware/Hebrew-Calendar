/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2019-08 </edited>
using System;
using System.Drawing;
using Calendar.NET;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    internal void FillMonths()
    {
      string strToolTip = "Error on getting sun rise and set";
      int progress = 0;
      foreach ( var row in LunisolarCalendar.LunisolarDays )
      {
        if ( !UpdateProgress(progress++, Count, Translations.ProgressFillMonthsText.GetLang()) ) return;
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
        strToolTip = Translations.EphemerisText.GetLang(EphemerisType.Rise) + row.Sunrise + Environment.NewLine 
                   + Translations.EphemerisText.GetLang(EphemerisType.Set) + row.Sunset;
        Color colorMoon = Color.Black;
        string strMonth = row.IsNewMoon == 1
                        ? " " + Translations.BabylonianHebrewMonthText[row.LunarMonth]
                        : "";
        colorMoon = row.IsNewMoon == 1
                  ? Program.Settings.TorahEventColor
                  : ( row.IsFullMoon == 1 ? Program.Settings.FullMoonColor : Program.Settings.MoonEventColor );
        if ( (MoonriseType)row.MoonriseType == MoonriseType.AfterSet )
        {
          if ( row.Moonset != "" ) add(Color.Black, Translations.EphemerisText.GetLang(EphemerisType.Set) + row.Moonset);
          if ( (MoonriseType)row.MoonriseType != MoonriseType.NextDay )
            add(colorMoon, Translations.EphemerisText.GetLang(EphemerisType.Rise) + row.Moonrise + " #" + row.LunarDay + strMonth);
        }
        else
        {
          if ( (MoonriseType)row.MoonriseType != MoonriseType.NextDay )
            add(colorMoon, Translations.EphemerisText.GetLang(EphemerisType.Rise) + row.Moonrise + " #" + row.LunarDay + strMonth);
          if ( row.Moonset != "" ) add(Color.Black, Translations.EphemerisText.GetLang(EphemerisType.Set) + row.Moonset);
        }
        if ( row.SeasonChange != 0 )
          add(Program.Settings.SeasonEventColor, Translations.SeasonEventText.GetLang((SeasonChangeType)row.SeasonChange));
        if ( row.TorahEvents != 0 )
          add(Program.Settings.TorahEventColor, Translations.TorahEventText.GetLang((TorahEventType)row.TorahEvents));
      }
    }

  }

}
