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
/// <created> 2019-10 </created>
/// <edited> 2019-10 </edited>
using System;
using System.Linq;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SearchMonthForm : Form
  {

    private Data.LunisolarCalendar.LunisolarDaysRow CurrentDay;

    private bool Mutex;

    public SearchMonthForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void SearchEventForm_Load(object sender, EventArgs e)
    {
      Mutex = true;
      CurrentDay = MainForm.Instance.CurrentDay;
      EditYear.Minimum = MainForm.Instance.YearFirst;
      EditYear.Maximum = MainForm.Instance.YearLast;
      Mutex = false;
      EditYear.Value = DateTime.Now.Year;
      ActiveControl = SelectMonth;
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
      if ( CurrentDay != null )
        MainForm.Instance.GoToDate(SQLiteUtility.GetDate(CurrentDay.Date));
    }

    private void SelectEvents_DoubleClick(object sender, EventArgs e)
    {
      ButtonOk.PerformClick();
    }

    private void EditYear_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      SelectMonth.Items.Clear();
      var rows = from day in MainForm.Instance.LunisolarCalendar.LunisolarDays
                 where day.LunarDay == 1
                    && SQLiteUtility.GetDate(day.Date).Year == EditYear.Value
                 orderby day.Date
                 select day;
      foreach ( var row in rows )
        if (row.LunarMonth > 0)
          SelectMonth.Items.Add(row);
      SelectMonth.SelectedIndex = 0;
    }

    private void SelectMonth_Format(object sender, ListControlConvertEventArgs e)
    {
      if ( Mutex ) return;
      int month = ( (Data.LunisolarCalendar.LunisolarDaysRow)e.ListItem ).LunarMonth;
      e.Value = Translations.BabylonianHebrewMonthText[month];
    }

    private void SelectMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      var row = (Data.LunisolarCalendar.LunisolarDaysRow)SelectMonth.SelectedItem;
      MainForm.Instance.GoToDate(SQLiteUtility.GetDate(row.Date));
    }
  }

}
