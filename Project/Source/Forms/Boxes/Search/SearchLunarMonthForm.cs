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
/// <created> 2019-10 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class SearchLunarMonthForm : Form
  {

    private MainForm MainForm = MainForm.Instance;

    private List<LunisolarDay> LunisolarDays => ApplicationDatabase.Instance.LunisolarDays;

    public LunisolarDay CurrentDay { get; private set; }

    private int CurrentDayIndex = -1;

    public SearchLunarMonthForm()
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

    private void SearchLunarMonthForm_Shown(object sender, EventArgs e)
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
      int year = SelectYear.Value;
      var rows = LunisolarDays.Where(row => row.IsNewMoon && row.Date.Year == year);
      string selectedKey = ListItems.SelectedItems.Count > 0 ? ListItems.SelectedItems[0].Text : null;
      CurrentDayIndex = SelectMoonDay.SelectedIndex;
      ListItems.Items.Clear();
      ListViewItem itemToSelect = null;
      ListViewItem itemToSelectDefault = null;
      foreach ( var row in rows.Where(row => row.LunarMonth > 0) )
      {
        string key = row.LunarMonth.ToString();
        string date = row.Date.ToLongDateString();
        var item = ListItems.Items.Add(key);
        item.SubItems.Add(HebrewMonths.Transliterations[row.LunarMonth]);
        item.SubItems.Add(date.Titleize());
        item.Tag = row;
        if ( selectedKey != null && key == selectedKey && itemToSelect == null )
          itemToSelect = item;
        if ( row.IsNewYear )
          itemToSelectDefault = item;
      }
      if ( itemToSelect != null )
      {
        itemToSelect.Focused = true;
        itemToSelect.Selected = true;
      }
      else
      if ( itemToSelectDefault != null )
      {
        itemToSelectDefault.Focused = true;
        itemToSelectDefault.Selected = true;
      }
      else
      if ( ListItems.Items.Count > 0 )
      {
        ListItems.Items[0].Focused = true;
        ListItems.Items[0].Selected = true;
      }
      ListItems.Columns[ListItems.Columns.Count - 1].Width = -2;
    }

    private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( ListItems.SelectedItems.Count > 0 )
      {
        var row = (LunisolarDay)ListItems.SelectedItems[0].Tag;
        SelectMoonDay.Items.Clear();
        int year = SelectYear.Value;
        var days = LunisolarDays.Where(day => day.Date.Year == year && day.LunarMonth == row.LunarMonth);
        SelectMoonDay.Items.AddRange(days.ToArray());
        if ( CurrentDayIndex == -1 ) CurrentDayIndex = 0;
        if ( CurrentDayIndex >= SelectMoonDay.Items.Count )
          CurrentDayIndex = SelectMoonDay.Items.Count - 1;
        SelectMoonDay.SelectedIndex = CurrentDayIndex;
      }
    }

    private void SelectMoonDay_Format(object sender, ListControlConvertEventArgs e)
    {
      e.Value = ( (LunisolarDay)e.ListItem ).LunarDay.ToString();
    }

    private void SelectMoonDay_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( SelectMoonDay.SelectedItem != null )
        MainForm.GoToDate(( (LunisolarDay)SelectMoonDay.SelectedItem ).Date);
    }

    protected override CreateParams CreateParams
    {
      get
      {
        var cp = base.CreateParams;
        if ( Program.Settings.WindowsDoubleBufferingEnabled )
          cp.ExStyle |= 0x02000000;
        return cp;
      }
    }

  }

}
