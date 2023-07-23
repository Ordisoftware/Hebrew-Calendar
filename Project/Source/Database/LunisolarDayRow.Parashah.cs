/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

public partial class LunisolarDayRow
{

  static private readonly int SearchParashahInterval = Globals.DaysOfWeekCount * 2;

  public string GetParashahText(bool withBookAndRefIfRequired)
  {
    if ( ParashahID.IsNullOrEmpty() ) return string.Empty;
    var parashah = ParashotFactory.Instance.Get(ParashahID);
    return parashah is not null
      ? parashah.ToStringShort(withBookAndRefIfRequired, HasLinkedParashah)
      : SysTranslations.UndefinedSlot.GetLang();
  }

  public LunisolarDayRow GetParashahReadingDay()
  {
    LunisolarDayRow result = null;
    var shabatDay = (DayOfWeek)Settings.ShabatDay;
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
    return result?.ParashahID.IsNullOrEmpty() != false ? null : result;
  }

}
