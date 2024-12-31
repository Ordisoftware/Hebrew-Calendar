/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private string ExportSaveJSON(ExportInterval interval)
  {
    var cursor = Cursor;
    Cursor = Cursors.WaitCursor;
    try
    {
      var data = GetDayRows(interval).Select(day => new
      {
        day.DateAsString,
        day.IsNewMoon,
        day.IsFullMoon,
        day.LunarMonth,
        day.LunarDay,
        day.Sunrise,
        day.Sunset,
        day.Moonrise,
        day.Moonset,
        MoonRiseType = day.MoonriseOccurring.ToStringExport(AppTranslations.MoonriseOccurrences),
        MoonPhase = day.MoonPhase.ToStringExport(AppTranslations.MoonPhases),
        SeasonChange = day.SeasonChange.ToStringExport(AppTranslations.SeasonChanges),
        TorahEvent = day.TorahEvent.ToStringExport(AppTranslations.CelebrationDays),
      });
      using var dataset = new DataSet(Globals.AssemblyTitle);
      dataset.Tables.Add(data.ToDataTable(nameof(LunisolarDays)));
      string result = JsonConvert.SerializeObject(dataset, Newtonsoft.Json.Formatting.Indented);
      dataset.Tables.Clear();
      return result;
    }
    finally
    {
      Cursor = cursor;
    }
  }
}
