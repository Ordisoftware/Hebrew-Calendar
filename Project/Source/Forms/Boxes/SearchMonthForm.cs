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
/// <edited> 2019-10 </edited>
using System;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SearchMonthForm : Form
  {

    private Data.DataSet.LunisolarDaysRow CurrentDay;

    private bool Mutex;

    public SearchMonthForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void SearchEventForm_Load(object sender, EventArgs e)
    {
      if ( Location.X == -1 && Location.Y == -1 )
        this.CenterToMainForm();
      Mutex = true;
      CurrentDay = MainForm.Instance.CurrentDay;
      EditYear.Minimum = MainForm.Instance.YearFirst;
      EditYear.Maximum = MainForm.Instance.YearLast;
      EditYear.Value = CurrentDay == null ? DateTime.Today.Year : SQLiteUtility.GetDate(CurrentDay.Date).Year;
      Mutex = false;
      EditYear_ValueChanged(null, null);
      ActiveControl = ListItems;
    }

    private void ActionOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void ActionCancel_Click(object sender, EventArgs e)
    {
      if ( CurrentDay != null )
        MainForm.Instance.GoToDate(SQLiteUtility.GetDate(CurrentDay.Date));
    }

    private void EditYear_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      ListItems.Items.Clear();
      var rows = from day in MainForm.Instance.DataSet.LunisolarDays
                 where day.IsNewMoon == 1
                    && SQLiteUtility.GetDate(day.Date).Year == EditYear.Value
                 orderby day.Date
                 select day;
      foreach ( var row in rows )
        if ( row.LunarMonth > 0 )
        {
          var item = ListItems.Items.Add(row.LunarMonth.ToString());
          item.SubItems.Add(MoonMonths.Names[row.LunarMonth]);
          item.SubItems.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SQLiteUtility.GetDate(row.Date).ToLongDateString()));
          item.Tag = row;
          if ( (TorahEvent)row.TorahEvents == TorahEvent.NewYearD1 )
            item.Selected = true;
        }
      if ( ListItems.Items.Count > 0 && ListItems.SelectedItems.Count == 0 )
        ListItems.Items[0].Selected = true;
    }

    private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( ListItems.SelectedItems.Count > 0 )
      {
        var row = (Data.DataSet.LunisolarDaysRow)ListItems.SelectedItems[0].Tag;
        MainForm.Instance.GoToDate(SQLiteUtility.GetDate(row.Date));
      }
    }

    private void ListItems_DoubleClick(object sender, EventArgs e)
    {
      ActionOk.PerformClick();
    }

  }

}
