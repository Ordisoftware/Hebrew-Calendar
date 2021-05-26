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
/// <created> 2021-02 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{


  partial class ApplicationDatabase : SQLiteDatabase
  {

    public string WeeklyParashahText
    {
      get
      {
        var parashah = GetWeeklyParashah();
        return ( parashah != null ? parashah.ToStringLinked() : SysTranslations.UndefinedSlot.GetLang() ).ToUpper();
      }
    }

    public Parashah GetWeeklyParashah()
    {
      var today = Program.Settings.TorahEventsCountAsMoon ? GetDayMoon(DateTime.Now) : GetDaySun(DateTime.Now);
      if ( today == null ) return null;
      if ( today.LunarMonth == TorahCelebrations.PessahMonth )
        if ( today.TorahEvent == TorahEvent.PessahD1 || today.TorahEvent == TorahEvent.PessahD7 )
          return null;
        else
        if ( !today.GetWeekLongCelebrationIntermediateDay().IsNullOrEmpty() )
          return null;
      if ( Program.Settings.TorahEventsCountAsMoon ) today = GetDaySun(DateTime.Now);
      return ParashotFactory.Get(today?.GetParashahReadingDay()?.ParashahID) ?? null;
    }

    public bool ShowWeeklyParashahDescription()
    {
      if ( MainForm.UserParashot == null ) return false;
      var parashah = MainForm.UserParashot.Find(p => p.ID == GetWeeklyParashah().ID);
      return ParashotForm.ShowParashahDescription(MainForm.Instance, parashah, true);
    }

  }

  partial class LunisolarDay
  {

    private const int SearchParashahInterval = 14;

    public string ParashahText
    {
      get
      {
        if ( ParashahID.IsNullOrEmpty() ) return string.Empty;
        string result = ParashotFactory.Get(ParashahID).Name;
        if ( !LinkedParashahID.IsNullOrEmpty() )
          result += " - " + ParashotFactory.Get(LinkedParashahID).Name;
        return result;
      }
    }

    public LunisolarDay GetParashahReadingDay()
    {
      LunisolarDay result = null;
      var shabatDay = Program.Settings.WeekParashahIsOnSaturday
                      ? DayOfWeek.Saturday
                      : (DayOfWeek)Program.Settings.ShabatDay;
      int indexStart = Table.IndexOf(this);
      int indexEnd = Math.Min(indexStart + SearchParashahInterval, Table.Count);
      for ( int index = indexStart; index < indexEnd; index++ )
      {
        var row = Table[index];
        if ( row.Date.DayOfWeek == shabatDay )
        {
          result = row;
          break;
        }
      }
      return result == null || result.ParashahID.IsNullOrEmpty() ? null : result;
    }

  }

}
