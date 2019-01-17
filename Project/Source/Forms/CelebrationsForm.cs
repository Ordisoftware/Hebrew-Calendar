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

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static internal CelebrationsForm Instance { get; private set; }

    static CelebrationsForm()
    {
      Instance = new CelebrationsForm();
    }

    static public void Execute()
    {
      Instance.ListView.Items.Clear();
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
          Instance.ListView.Items.Add(SQLiteUtility.GetDate(row.Date).ToLongDateString())
            .SubItems.Add(TorahCelebrations.SeasonEventNames.GetLang((SeasonChangeType)row.SeasonChange))
            .Tag = row.Date;
        if ( (TorahEventType)row.TorahEvents != TorahEventType.None )
          Instance.ListView.Items.Add(SQLiteUtility.GetDate(row.Date).ToLongDateString())
            .SubItems.Add(TorahCelebrations.TorahEventNames.GetLang((TorahEventType)row.TorahEvents))
            .Tag = row.Date;
      }
      Instance.Show();
      Instance.BringToFront();
    }

    private CelebrationsForm()
    {
      InitializeComponent();
    }

    private void CelebrationsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
      Hide();
    }

    private void ListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      var date = SQLiteUtility.GetDate(ListView.SelectedItems[0].SubItems[1].Tag.ToString());
      MainForm.Instance.GoToDate(date);
      NavigationForm.Instance.Date = date;
    }

  }

}
