using System.Linq;

namespace Ordisoftware.HebrewCalendar.Data
{

  partial class LunisolarCalendar
  {

    public int YearMin
    {
      get { return LunisolarDays.Count == 0 ? 0 : SQLiteDateTool.GetDate(LunisolarDays.Min(p => p.Date)).Year; }
    }

    public int YearMax
    {
      get { return LunisolarDays.Count == 0 ? 0 : SQLiteDateTool.GetDate(LunisolarDays.Max(p => p.Date)).Year; }
    }


  }

}
