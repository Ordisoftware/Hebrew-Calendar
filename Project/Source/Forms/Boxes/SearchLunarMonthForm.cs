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
/// <created> 2019-10 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SearchLunarMonthForm : Form
  {

    private bool Mutex;

    private Data.DataSet.LunisolarDaysRow CurrentDay;

    public SearchLunarMonthForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ActiveControl = ListItems;
    }

    private void SearchEventForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
      Mutex = true;
      CurrentDay = MainForm.Instance.CurrentDay;
      int yearSelected = CurrentDay == null ? DateTime.Today.Year : SQLiteDate.ToDateTime(CurrentDay.Date).Year;
      foreach ( int indexYear in MainForm.Instance.YearsIntervalArray )
      {
        int index = EditYear.Items.Add(indexYear);
        if ( indexYear == yearSelected )
          EditYear.SelectedIndex = index;
      }
      Mutex = false;
      EditYear_SelectedIndexChanged(null, null);
    }

    private void SearchMonthForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( DialogResult == DialogResult.Cancel )
        if ( CurrentDay != null )
          MainForm.Instance.GoToDate(SQLiteDate.ToDateTime(CurrentDay.Date));
    }

    private void ListItems_DoubleClick(object sender, EventArgs e)
    {
      ActionOK.PerformClick();
    }

    private void EditYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      ListItems.Items.Clear();
      var rows = from day in MainForm.Instance.DataSet.LunisolarDays
                 where day.IsNewMoon == 1
                    && SQLiteDate.ToDateTime(day.Date).Year == (int)EditYear.SelectedItem
                 orderby day.Date
                 select day;
      foreach ( var row in rows )
        if ( row.LunarMonth > 0 )
        {
          var item = ListItems.Items.Add(row.LunarMonth.ToString());
          item.SubItems.Add(Program.MoonMonthsNames[row.LunarMonth]);
          string str = SQLiteDate.ToDateTime(row.Date).ToLongDateString();
          item.SubItems.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str));
          item.Tag = row;
          if ( (TorahEvent)row.TorahEvents == TorahEvent.NewYearD1 )
          {
            item.Focused = true;
            item.Selected = true;
          }
        }
      if ( ListItems.Items.Count > 0 && ListItems.SelectedItems.Count == 0 )
      {
        ListItems.Items[0].Focused = true;
        ListItems.Items[0].Selected = true;
      }
      ListItems.Columns[ListItems.Columns.Count - 1].Width = -2;
    }

    private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( ListItems.SelectedItems.Count > 0 )
      {
        var row = (Data.DataSet.LunisolarDaysRow)ListItems.SelectedItems[0].Tag;
        MainForm.Instance.GoToDate(SQLiteDate.ToDateTime(row.Date));
      }
    }

  }

}
