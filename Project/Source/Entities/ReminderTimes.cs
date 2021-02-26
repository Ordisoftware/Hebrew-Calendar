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
/// <created> 2019-10 </created>
/// <edited> 2019-10 </edited>
using System;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide reminder times.
  /// </summary>
  partial class ReminderTimes
  {
    public string TimeStart;
    public string TimeEnd;
    public DateTime? DateStartCheck;
    public DateTime? DateStart;
    public DateTime? DateEnd;
    public void Set(DateTime date, string timeStart, string timeEnd, int delta1, int delta2, decimal delta3)
    {
      string[] timesStart = timeStart.Split(':');
      string[] timesEnd = timeEnd.Split(':');
      TimeStart = timeStart;
      TimeEnd = timeEnd;
      DateStart = date.AddDays(delta1).AddHours(Convert.ToInt32(timesStart[0])).AddMinutes(Convert.ToInt32(timesStart[1]));
      DateStartCheck = DateStart.Value.AddMinutes((double)-delta3);
      DateEnd = date.AddDays(delta2).AddHours(Convert.ToInt32(timesEnd[0])).AddMinutes(Convert.ToInt32(timesEnd[1]));
    }


  }

}
