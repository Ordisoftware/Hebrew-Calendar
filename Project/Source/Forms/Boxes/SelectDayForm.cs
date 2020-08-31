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
/// <created> 2019-01 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectDayForm : Form
  {

    private bool IsGotoRealtime;

    private Data.DataSet.LunisolarDaysRow CurrentDay;

    public SelectDayForm(bool isOnlyGeneratedCalendar = false, bool isGotoRealtime = false)
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      if ( isOnlyGeneratedCalendar )
      {
        MonthCalendar.MinDate = MainForm.Instance.DateFirst;
        MonthCalendar.MaxDate = MainForm.Instance.DateLast;
      }
      else
      {
        MonthCalendar.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
        MonthCalendar.MaxDate = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime;
      }
      MonthCalendar.FirstDayOfWeek = (Day)Program.Settings.ShabatDay;
      CurrentDay = MainForm.Instance.CurrentDay;
      IsGotoRealtime = isGotoRealtime;
    }

    private void SelectDayForm_Shown(object sender, EventArgs e)
    {
      MonthCalendar_DateChanged(null, null);
    }

    private void ActionCancel_Click(object sender, EventArgs e)
    {
      if ( IsGotoRealtime && CurrentDay != null )
        MainForm.Instance.GoToDate(SQLiteDate.ToDateTime(CurrentDay.Date));
    }

    private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
    {
      if ( !IsGotoRealtime ) return;
      string date = SQLiteDate.ToString(MonthCalendar.SelectionStart);
      if ( MonthCalendar.SelectionStart < MainForm.Instance.DateFirst )
        date = SQLiteDate.ToString(MainForm.Instance.DateFirst);
      else
      if ( MonthCalendar.SelectionStart > MainForm.Instance.DateLast )
        date = SQLiteDate.ToString(MainForm.Instance.DateLast);
      MainForm.Instance.GoToDate(SQLiteDate.ToDateTime(date));
    }

  }

}
