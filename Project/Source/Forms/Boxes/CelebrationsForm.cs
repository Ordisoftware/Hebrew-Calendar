/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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

    static public void Run()
    {
      if ( Instance.Visible )
      {
        Instance.BringToFront();
        return;
      }
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
            .SubItems.Add(Translations.SeasonEvent.GetLang((SeasonChangeType)row.SeasonChange))
            .Tag = row.Date;
        if ( (TorahEventType)row.TorahEvents != TorahEventType.None )
          Instance.ListView.Items.Add(SQLiteUtility.GetDate(row.Date).ToLongDateString())
            .SubItems.Add(Translations.TorahEvent.GetLang((TorahEventType)row.TorahEvents))
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
      try
      {
        NavigationForm.Instance.Date = SQLiteUtility.GetDate(ListView.SelectedItems[0].SubItems[1].Tag.ToString());
      }
      catch
      {
      }
    }

    private void ListView_DoubleClick(object sender, EventArgs e)
    {
      Close();
    }
  }

}
