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
/// <created> 2020-12 </created>
/// <edited> 2021-03 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    partial class LunisolarDaysRow
    {

      public MoonRiseOccuring MoonriseOccuringAsEnum
      {
        get { return (MoonRiseOccuring)MoonriseType; }
        set { MoonriseType = (int)value; }
      }

      public MoonPhase MoonPhaseAsEnum
      {
        get { return (MoonPhase)MoonPhase; }
        set { MoonPhase = (int)value; }
      }

      public SeasonChange SeasonChangeAsEnum
      {
        get { return (SeasonChange)SeasonChange; }
        set { SeasonChange = (int)value; }
      }

      public TorahEvent TorahEventsAsEnum
      {
        get { return (TorahEvent)TorahEvents; }
        set { TorahEvents = (int)value; }
      }

      public bool HasSeasonChange
        => SeasonChangeAsEnum != Calendar.SeasonChange.None;

      public bool HasTorahEvent
        => TorahEventsAsEnum != TorahEvent.None;

    }

  }

}
