using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class CelebrationsForm : Form
  {

    static public void Execute()
    {
      var form = new CelebrationsForm();
      var dateStart = DateTime.Now;
      var dateEnd = dateStart.AddYears(1);
      var rows = from day in MainForm.Instance.LunisolarCalendar.LunisolarDays
                 where SQLiteUtility.GetDate(day.Date) >= dateStart && SQLiteUtility.GetDate(day.Date) <= dateEnd
                 && ( (SeasonChangeType)day.SeasonChange != SeasonChangeType.None
                   || (TorahEventType)day.TorahEvents != TorahEventType.None )
                 select day;
      foreach ( var row in rows )
      {
        if ( (SeasonChangeType)row.SeasonChange != SeasonChangeType.None )
          form.ListView.Items.Add(SQLiteUtility.GetDate(row.Date).ToLongDateString())
            .SubItems.Add(TorahCelebrations.SeasonEventNames.GetLang((SeasonChangeType)row.SeasonChange))
            .Tag = row.Date;
        if ( (TorahEventType)row.TorahEvents != TorahEventType.None )
          form.ListView.Items.Add(SQLiteUtility.GetDate(row.Date).ToLongDateString())
            .SubItems.Add(TorahCelebrations.TorahEventNames.GetLang((TorahEventType)row.TorahEvents))
            .Tag = row.Date;
      }
      form.ShowDialog();
    }

    private CelebrationsForm()
    {
      InitializeComponent();
    }

    private void ListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      var date = SQLiteUtility.GetDate(ListView.SelectedItems[0].SubItems[1].Tag.ToString());
      MainForm.Instance.GoToDate(date);
      NavigationForm.Instance.Date = date;
    }
  }

}
