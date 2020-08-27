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
using System.Collections.Generic;
using System.Windows.Forms;
using AASharp;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public class DatesDiffItem
  {

    private class DataItem
    {
      public int DayOfMonth;
      public int MonthOfYear;
      public SeasonChange SeasonChange;
      public TimeSpan? MoonRise;
    }

    static private Dictionary<DateTime, DataItem> Data
      = new Dictionary<DateTime, DataItem>();

    static private DataItem GetData(DateTime date)
    {
      DataItem value = null;
      if ( !Data.ContainsKey(date) )
      {
        value = new DataItem
        {
          DayOfMonth = AstronomyHelper.LunisolerCalendar.GetDayOfMonth(date),
          MoonRise = date.GetSunMoonEphemeris().Moonrise,
          MonthOfYear = AstronomyHelper.LunisolerCalendar.GetMonth(date)
        };
        var aasdate = new AASDate();
        long jdYear = 0, jdMonth = 0, jdDay = 0, jdHour = 0, jdMinute = 0;
        double second = 0;
        void set(SeasonChange season, Func<long, bool, double> action)
        {
          aasdate.Set(action(date.Year, true), true);
          aasdate.Get(ref jdYear, ref jdMonth, ref jdDay, ref jdHour, ref jdMinute, ref second);
          var dateJulian = new DateTime((int)jdYear, (int)jdMonth, (int)jdDay, 0, 0, 0);
          if (date.Date == dateJulian.Date) value.SeasonChange = season;
        }
        var lat = MainForm.Instance.CurrentGPSLatitude;
        if ( lat >= 0 || !Program.Settings.TorahEventsCountAsMoon )
        {
          set(SeasonChange.SpringEquinox, AASEquinoxesAndSolstices.NorthwardEquinox);
          set(SeasonChange.SummerSolstice, AASEquinoxesAndSolstices.NorthernSolstice);
          set(SeasonChange.AutumnEquinox, AASEquinoxesAndSolstices.SouthwardEquinox);
          set(SeasonChange.WinterSolstice, AASEquinoxesAndSolstices.SouthernSolstice);
        }
        else
        {
          set(SeasonChange.SpringEquinox, AASEquinoxesAndSolstices.SouthwardEquinox);
          set(SeasonChange.SummerSolstice, AASEquinoxesAndSolstices.SouthernSolstice);
          set(SeasonChange.AutumnEquinox, AASEquinoxesAndSolstices.NorthwardEquinox);
          set(SeasonChange.WinterSolstice, AASEquinoxesAndSolstices.NorthernSolstice);
        }
        if ( lat < 0 && !Program.Settings.TorahEventsCountAsMoon )
          {
            if ( value.SeasonChange == SeasonChange.SpringEquinox )
            value.SeasonChange = SeasonChange.AutumnEquinox;
            else
            if ( value.SeasonChange == SeasonChange.AutumnEquinox )
            value.SeasonChange = SeasonChange.SpringEquinox;
            else
            if ( value.SeasonChange == SeasonChange.WinterSolstice )
            value.SeasonChange = SeasonChange.SummerSolstice;
            else
            if ( value.SeasonChange == SeasonChange.SummerSolstice )
            value.SeasonChange = SeasonChange.WinterSolstice;
          }
        Data.Add(date, value);
      }
      else
        value = Data[date];
      return value;
    }

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
        int countData = Data.Keys.Count;
        if ( count - countData >= minimum )
        {
          LoadingForm.Instance.Initialize(Translations.ProgressCreateDays.GetLang(), count, minimum + 1);
          if ( sender != null ) sender.Enabled = false;
        }
        var data = GetData(Date1);
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
          data = GetData(index);
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
