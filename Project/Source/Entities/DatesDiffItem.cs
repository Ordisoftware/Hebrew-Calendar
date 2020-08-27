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
/// <created> 2020-08 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public class DatesDiffItem
  {

    private DateTime Date1;
    private DateTime Date2;

    public int SolarDays { get; set; }
    public int SolarWeeks { get; set; }
    public int SolarMonths { get; set; }
    public int SolarYears { get; set; }
    public int MoonDays { get; set; }
    public int MoonMonths { get; set; }
    public int MoonYears { get; set; }

    public DatesDiffItem(Form sender, DateTime date1, DateTime date2)
    {
      SetDates(sender, date1, date2);
    }

    public void SetDates(Form sender, DateTime date1, DateTime date2)
    {
      if ( date1 > date2 )
      {
        var temp = date1;
        date1 = date2;
        date2 = temp;
      }
      if ( Date1 == date1 && Date2 == date2 ) return;
      Date1 = date1;
      Date2 = date2;
      Calculate(sender);
    }

    private void Calculate(Form sender)
    {
      try
      {
        int minimum = 2*365;
        int count = (int)( Date2 - Date1 ).TotalDays;
        int countData = Dates.Count;
        if ( count - countData >= minimum )
        {
          LoadingForm.Instance.Initialize(Translations.ProgressCreateDays.GetLang(), count, minimum + 1);
          if ( sender != null ) sender.Enabled = false;
        }
        var data = Dates.Get(Date1);
        SolarDays = ( Date2 - Date1 ).Days + 1;
        SolarWeeks = (int)Math.Ceiling(SolarDays / 7d);
        SolarMonths = 1;
        SolarYears = 1;
        MoonDays = 0;
        MoonMonths = 1;
        MoonYears = 1;
        if ( Date1.Day == 1 ) SolarMonths = 0;
        if ( Date1.Month == 1 && Date1.Day == 1 ) SolarYears = 0;
        if ( data.DayOfMonth == 1 && data.MoonRise != null ) MoonMonths = 0;
        if ( data.SeasonChange == SeasonChange.SpringEquinox ) MoonYears = 0;
        for ( DateTime index = Date1; index <= Date2; index = index.AddDays(1) )
        {
          if ( LoadingForm.Instance.Visible ) LoadingForm.Instance.DoProgress();
          data = Dates.Get(index);
          if ( index.Day == 1 ) SolarMonths++;
          if ( index.Month == 1 && index.Day == 1 ) SolarYears++;
          if ( data.MoonRise == null ) continue;
          MoonDays++;
          if ( data.DayOfMonth == 1 ) MoonMonths++;
          if ( data.SeasonChange == SeasonChange.SpringEquinox ) MoonYears++;
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      finally
      {
        if ( sender != null && !sender.Enabled ) sender.Enabled = true;
        if ( LoadingForm.Instance.Visible ) LoadingForm.Instance.Hide();
      }
    }

  }

}
