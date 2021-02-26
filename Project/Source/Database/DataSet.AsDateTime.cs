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

    partial class LunisolarDaysRow
    {

      private DateTime? ConvertTime(string time)
      {
        if ( time.IsNullOrEmpty() ) return null;
        var date = SQLiteDate.ToDateTime(Date);
        var parts = time.Split(':');
        return date.AddHours(int.Parse(parts[0])).AddMinutes(int.Parse(parts[1]));
      }

      public DateTime? MoonsetAsDateTime => ConvertTime(Moonset);
      public DateTime? MoonriseAsDateTime => ConvertTime(Moonrise);
      public DateTime? SunsetAsDateTime => ConvertTime(Sunset);
      public DateTime? SunriseAsDateTime => ConvertTime(Sunrise);

    }

  }

}
