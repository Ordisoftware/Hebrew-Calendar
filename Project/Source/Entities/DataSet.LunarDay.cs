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
/// <edited> 2021-02 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    public LunisolarDaysRow GetLunarNow()
    {
      // TODO use a timer to not call each time needed ?
      return GetLunarDay(DateTime.Now);
    }

    public LunisolarDaysRow GetLunarDay(DateTime date)
    {
      var dateStr = SQLiteDate.ToString(date);
      if ( Program.Settings.TorahEventsCountAsMoon )
      {
        int delta = 2;
        var rowCurrent = LunisolarDays.FindByDate(dateStr);
        int indexrow = LunisolarDays.Rows.IndexOf(rowCurrent);
        int indexStart = Math.Max(0, indexrow - delta);
        int indexEnd = Math.Min(indexrow + delta, LunisolarDays.Count - 1);
        bool isInBounds = false;
        LunisolarDaysRow rowLast = null;
        LunisolarDaysRow rowFirst = null;
        for ( int index = indexEnd; index > indexStart; index-- )
        {
          rowCurrent = LunisolarDays[index];
          if ( !isInBounds && rowCurrent.MoonsetAsDateTime < date )
          {
            isInBounds = true;
            rowFirst = rowCurrent;
          }
          else
          if ( isInBounds && rowCurrent.MoonsetAsDateTime <= date )
            return !rowCurrent.Moonrise.IsNullOrEmpty() ? rowLast : rowFirst;
          rowLast = rowCurrent;
        }
      }
      else
      {
        ;
      }
      return null;
    }

  }

}
