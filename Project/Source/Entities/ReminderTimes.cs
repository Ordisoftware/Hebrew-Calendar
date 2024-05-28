/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
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
/// <edited> 2021-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides reminder times.
/// </summary>
class ReminderTimes
{
  public TimeSpan TimeStart;
  public TimeSpan TimeEnd;
  public DateTime DateStartCheck;
  public DateTime DateStart;
  public DateTime DateEnd;
  public void Set(DateTime date,
                  TimeSpan timeStart,
                  TimeSpan timeEnd,
                  int offsetDayStart,
                  int offsetDayEnd,
                  decimal offsetRemindBefore)
  {
    TimeStart = timeStart;
    TimeEnd = timeEnd;
    DateStart = date.AddDays(offsetDayStart).AddHours(timeStart.Hours).AddMinutes(timeStart.Minutes);
    DateStartCheck = DateStart.AddMinutes((double)-offsetRemindBefore);
    DateEnd = date.AddDays(offsetDayEnd).AddHours(timeEnd.Hours).AddMinutes(timeEnd.Minutes);
  }

}
