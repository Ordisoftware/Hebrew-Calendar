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
/// <edited> 2019-10 </edited>
using System;
using System.Linq;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectDayForm : Form
  {

    private Data.LunisolarCalendar.LunisolarDaysRow CurrentDay;

    public SelectDayForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      MonthCalendar.FirstDayOfWeek = (Day)Program.Settings.ShabatDay;
      CurrentDay = MainForm.Instance.CurrentDay;
    }

    private void SelectDayForm_Shown(object sender, EventArgs e)
    {
      MonthCalendar_DateChanged(null, null);
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
      if ( CurrentDay != null )
        MainForm.Instance.GoToDate(SQLiteUtility.GetDate(CurrentDay.Date));
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
    {
      string date = SQLiteUtility.GetDate(MonthCalendar.SelectionStart);
      if ( MonthCalendar.SelectionStart < MainForm.Instance.DateFirst )
        date = SQLiteUtility.GetDate(MainForm.Instance.DateFirst);
      else
      if ( MonthCalendar.SelectionStart > MainForm.Instance.DateLast )
        date = SQLiteUtility.GetDate(MainForm.Instance.DateLast);
      MainForm.Instance.GoToDate(SQLiteUtility.GetDate(date));
    }

  }

}
