/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using System.Data;
using Ordisoftware.Core;
using Newtonsoft.Json;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private string ExportSaveJSON(ExportInterval interval)
    {
      // todo interval
      var data = DataSet.LunisolarDays.Select(day => new
      {
        day.Date,
        IsNewMoon = Convert.ToBoolean(day.IsNewMoon),
        IsFullMoon = Convert.ToBoolean(day.IsFullMoon),
        day.LunarMonth,
        day.LunarDay,
        day.Sunrise,
        day.Sunset,
        day.Moonrise,
        day.Moonset,
        MoonRiseType = day.MoonriseOccuringAsEnum.ToStringExport(AppTranslations.MoonRiseOccuring),
        MoonPhase = day.MoonPhaseAsEnum.ToStringExport(AppTranslations.MoonPhase),
        SeasonChange = day.SeasonChangeAsEnum.ToStringExport(AppTranslations.SeasonChange),
        TorahEvent = day.TorahEventsAsEnum.ToStringExport(AppTranslations.TorahEvent),
      });
      var dataset = new DataSet(Globals.AssemblyTitle);
      dataset.Tables.Add(data.ToDataTable(DataSet.LunisolarDays.TableName));
      return JsonConvert.SerializeObject(dataset, Formatting.Indented);
    }
  }

}
