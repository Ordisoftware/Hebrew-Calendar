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
/// <created> 2020-08 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides dates difference item.
/// </summary>
class DatesDiffItem
{

  private DateTime DateStart;
  private DateTime DateEnd;

  public int SolarDays { get; set; }
  public int SolarWeeks { get; set; }
  public int SolarMonths { get; set; }
  public int SolarYears { get; set; }
  public int MoonDays { get; set; }
  public int LunarMonths { get; set; }
  public int MoonYears { get; set; }

  public DatesDiffItem(Form sender, DateTime date1, DateTime date2)
  {
    SetDates(sender, date1, date2);
  }

  public void SetDates(Form sender, DateTime date1, DateTime date2)
  {
    date1 = date1.Date;
    date2 = date2.Date;
    if ( DateStart == date1 && DateEnd == date2 )
      return;
    else
    if ( date1 > date2 )
      (date2, date1) = (date1, date2);
    DateStart = date1;
    DateEnd = date2;
    Calculate(sender);
  }

  private void Calculate(Form sender)
  {
    try
    {
      int count = (int)( DateEnd - DateStart ).TotalDays;
      int countData = CalendarDates.Instance.Count;
      if ( count - countData >= Program.LoadingFormDatesDiff )
      {
        LoadingForm.Instance.Initialize(AppTranslations.ProgressCreateDays.GetLang(),
                                        count,
                                        Program.LoadingFormDatesDiff + 1);
        if ( sender is not null ) sender.Enabled = false;
      }
      var data = CalendarDates.Instance[DateStart];
      SolarDays = ( DateEnd - DateStart ).Days + 1;
      SolarWeeks = (int)Math.Ceiling((decimal)SolarDays / Globals.DaysOfWeekCount);
      SolarMonths = 1;
      SolarYears = 1;
      MoonDays = 0;
      LunarMonths = 1;
      MoonYears = 1;
      if ( DateStart.Day == 1 ) SolarMonths = 0;
      if ( DateStart.Month == 1 && DateStart.Day == 1 ) SolarYears = 0;
      if ( data.MoonDay == 1 && data.Ephemerisis.Moonrise is not null ) LunarMonths = 0;
      if ( data.TorahSeasonChange == SeasonChange.SpringEquinox ) MoonYears = 0;
      for ( DateTime index = DateStart; index <= DateEnd; index = index.AddDays(1) )
      {
        if ( LoadingForm.Instance.Visible ) LoadingForm.Instance.DoProgress();
        data = CalendarDates.Instance[index];
        if ( index.Day == 1 ) SolarMonths++;
        if ( index.Month == 1 && index.Day == 1 ) SolarYears++;
        if ( data.Ephemerisis.Moonrise is null ) continue;
        MoonDays++;
        if ( data.MoonDay == 1 ) LunarMonths++;
        if ( data.TorahSeasonChange == SeasonChange.SpringEquinox ) MoonYears++;
      }
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      if ( sender?.Enabled == false ) sender.Enabled = true;
      if ( LoadingForm.Instance.Visible ) LoadingForm.Instance.Hide();
    }
  }

}
