using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar.Data
{

  partial class DataSet
  {

    partial class LunisolarDaysRow
    {

      public DateTime GetEventStartDateTime(bool useRealDay)
      {
        var day = this;
        if ( useRealDay || day.MoonriseOccuringAsEnum == MoonRiseOccuring.NextDay )
        {
          if ( day.MoonriseOccuringAsEnum == MoonRiseOccuring.BeforeSet || day.Moonset == "" )
          {
            int index = day.Table.Rows.IndexOf(day) - 1;
            if ( index >= 0 )
              day = (LunisolarDaysRow)day.Table.Rows[index];
            else
              return SQLiteDate.ToDateTime(day.Date);
          }
          return SQLiteDate.ToDateTime(day.Date)
                           .AddHours(int.Parse(day.Moonset.Substring(0, 2)))
                           .AddMinutes(int.Parse(day.Moonset.Substring(3, 2)));
        }
        else
          return SQLiteDate.ToDateTime(day.Date)
                           .AddHours(int.Parse(day.Moonrise.Substring(0, 2)))
                           .AddMinutes(int.Parse(day.Moonrise.Substring(3, 2)));
      }

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

    }

  }

}
