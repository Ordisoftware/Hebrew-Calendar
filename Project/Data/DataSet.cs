using System.Linq;

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

    }

  }

}
