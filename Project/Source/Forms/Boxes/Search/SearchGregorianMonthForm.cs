﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-03 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;
using LunisolarDaysRow = Ordisoftware.Hebrew.Calendar.Data.DataSet.LunisolarDaysRow;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class SearchGregorianMonthForm : Form
  {

    private MainForm MainForm = MainForm.Instance;

    public LunisolarDaysRow CurrentDay { get; private set; }

    public SearchGregorianMonthForm()
    {
      InitializeComponent();
      Icon = MainForm.Icon;
      ActiveControl = ListItems;
      CurrentDay = MainForm.CurrentDay;
      int year = CurrentDay == null ? DateTime.Today.Year : MainForm.CurrentDayYear;
      SelectYear.Fill(MainForm.YearsIntervalArray, year);
    }

    private void SearchEventForm_Load(object sender, EventArgs e)
    {
      this.CheckLocationOrCenterToMainFormElseScreen();
    }

    private void SearchGregorianMonthForm_Shown(object sender, EventArgs e)
    {
      ListItems_SelectedIndexChanged(null, null);
    }

    private void SearchMonthForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( DialogResult == DialogResult.Cancel && CurrentDay != null )
        MainForm.GoToDate(CurrentDay.Date);
    }

    private void ListItems_DoubleClick(object sender, EventArgs e)
    {
      ActionOK.PerformClick();
    }

    private void SelectYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedKey = ListItems.SelectedIndices.Count > 0 ? ListItems.SelectedIndices[0] : -1;
      ListItems.Items.Clear();
      for ( int index = 0; index < 12; index++ )
      {
        string key = new DateTime(2000, index + 1, 1).ToString("MMMM");
        var item = ListItems.Items.Add(( index + 1 ).ToString());
        item.SubItems.Add(key.Titleize());
        if ( index == 0 && selectedKey == -1 )
        {
          ListItems.Items[index].Focused = true;
          ListItems.Items[index].Selected = true;
        }
        else
        if ( selectedKey == index )
        {
          ListItems.Items[selectedKey].Focused = true;
          ListItems.Items[selectedKey].Selected = true;
        }
      }
      ListItems.Columns[ListItems.Columns.Count - 1].Width = -2;
    }

    private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( ListItems.SelectedIndices.Count > 0 )
        MainForm.GoToDate(new DateTime(SelectYear.Value, ListItems.SelectedIndices[0] + 1, 1));
    }

  }

}
