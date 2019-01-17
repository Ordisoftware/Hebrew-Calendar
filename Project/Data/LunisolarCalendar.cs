using System.Linq;

namespace Ordisoftware.HebrewCalendar.Data
{

  partial class LunisolarCalendar
  {

    public int YearMin
    {
      get { return LunisolarDays.Count == 0 ? 0 : SQLiteUtility.GetDate(LunisolarDays.Min(p => p.Date)).Year; }
    }

    public int YearMax
    {
      get { return LunisolarDays.Count == 0 ? 0 : SQLiteUtility.GetDate(LunisolarDays.Max(p => p.Date)).Year; }
    }


  }

}
