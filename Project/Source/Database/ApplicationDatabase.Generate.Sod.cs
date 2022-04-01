/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-12 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase
{

  /// <summary>
  /// Creates the calendar items using Sod Ha'ibur (Knowledge on the cycle of stars).
  /// </summary>
  /// <remarkl>
  /// Omer is implicitly as sun and there is no difference between north and south hemisphere.
  /// </remarkl>
  public bool AnalyseDaysSod(int progressCount)
  {
    LoadingForm.Instance.Initialize(AppTranslations.ProgressAnalyzeDays.GetLang(),
                                    progressCount,
                                    Program.LoadingFormGenerate);
    var chrono = new Stopwatch();
    chrono.Start();
    //var parashot = ParashotFactory.Instance?.All?.ToList() ?? new List<Parashah>();
    try
    {
      foreach ( var day in LunisolarDays )
        try
        {
          LoadingForm.Instance.DoProgress();
          throw new NotImplementedException();
          return false; // TODO define months, celebrations, and parashot.
        }
        catch ( Exception ex )
        {
          if ( AddGenerateErrorAndCheckIfTooMany(nameof(AnalyseDaysOmer), day.DateAsString, ex) )
            return false;
        }
    }
    finally
    {
      chrono.Stop();
      Settings.BenchmarkAnalyseDays = chrono.ElapsedMilliseconds;
    }
    return true;
  }

}
