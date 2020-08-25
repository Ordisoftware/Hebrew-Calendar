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
/// <created> 2020-08 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SearchGregorianMonthForm : Form
  {

    private Data.DataSet.LunisolarDaysRow CurrentDay;

    private bool Mutex;

    public SearchGregorianMonthForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ActiveControl = ListItems;
    }

    private void SearchEventForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainForm();
      Mutex = true;
      CurrentDay = MainForm.Instance.CurrentDay;
      int yearSelected = CurrentDay == null ? DateTime.Today.Year : SQLite.GetDate(CurrentDay.Date).Year;
      for ( int indexYear = MainForm.Instance.YearFirst; indexYear <= MainForm.Instance.YearLast; indexYear++ )
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
          MainForm.Instance.GoToDate(SQLite.GetDate(CurrentDay.Date));
    }

    private void ListItems_DoubleClick(object sender, EventArgs e)
    {
      ActionOk.PerformClick();
    }

    private void EditYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      ListItems.Items.Clear();
      for ( int month = 1; month <= 12; month++ )
      {
        var item = ListItems.Items.Add(month.ToString());
        string str = new DateTime(2000, month, 1).ToString("MMMM");
        item.SubItems.Add(str.First().ToString().ToUpper() + str.Substring(1));
      }
      ListItems.Items[0].Focused = true;
      ListItems.Items[0].Selected = true;
    }

    private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( ListItems.SelectedItems.Count > 0 )
      {
        int month = int.Parse(ListItems.SelectedItems[0].Text);
        MainForm.Instance.GoToDate(new DateTime(int.Parse(EditYear.Text), month, 1));
      }
    }

  }

}
