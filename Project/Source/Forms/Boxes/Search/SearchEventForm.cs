/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class SearchEventForm : Form
{

  private readonly MainForm MainForm = MainForm.Instance;

  private List<LunisolarDayRow> LunisolarDays => ApplicationDatabase.Instance.LunisolarDays;

  public LunisolarDayRow CurrentDay { get; private set; }

  private bool GoToDateMutex;

  public SearchEventForm()
  {
    InitializeComponent();
    Icon = MainForm.Icon;
    ActiveControl = ListItems;
    GoToDateMutex = true;
    CurrentDay = MainForm.CurrentDay;
    int year = CurrentDay is null ? DateTime.Today.Year : MainForm.CurrentDayYear;
    SelectYear.Fill(MainForm.YearsIntervalArray, year);
  }

  private void SearchEventForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
    GoToDateMutex = false;
    int month = CurrentDay.LunarMonth;
    var item = ListItems.Items
                        .AsIEnumerable()
                        .FirstOrDefault(item => ( (LunisolarDayRow)item.Tag ).LunarMonth == month);
    if ( item is null )
      ListItems_SelectedIndexChanged(this, EventArgs.Empty);
    else
    {
      item.Focused = true;
      item.Selected = true;
    }
  }

  private void SearchEventForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if ( DialogResult == DialogResult.Cancel && CurrentDay is not null )
      MainForm.GoToDate(CurrentDay.Date);
  }

  private void ListItems_DoubleClick(object sender, EventArgs e)
  {
    ActionOK.PerformClick();
  }

  private void SelectYear_SelectedIndexChanged(object sender, EventArgs e)
  {
    int year = SelectYear.Value;
    var rows = LunisolarDays.Where(row => row.HasTorahEvent && row.Date.Year == year);
    string selectedKey = ListItems.SelectedItems.Count > 0 ? ListItems.SelectedItems[0].Text : null;
    ListItems.Items.Clear();
    ListViewItem itemToSelect = null;
    ListViewItem itemToSelectDefault = null;
    foreach ( var row in rows )
    {
      string key = AppTranslations.GetCelebrationDayDisplayText(row.TorahEvent);
      string date = row.Date.ToLongDateString();
      var item = ListItems.Items.Add(key);
      item.SubItems.Add(date.Titleize());
      item.SubItems.Add(row.DayAndMonthText);
      item.Tag = row;
      if ( selectedKey is not null && key == selectedKey && itemToSelect is null )
        itemToSelect = item;
      if ( row.IsNewYear )
        itemToSelectDefault = item;
    }
    if ( itemToSelect is not null )
    {
      itemToSelect.Focused = true;
      itemToSelect.Selected = true;
    }
    else
    if ( itemToSelectDefault is not null )
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
    if ( !GoToDateMutex && ListItems.SelectedItems.Count > 0 )
      MainForm.GoToDate(( (LunisolarDayRow)ListItems.SelectedItems[0].Tag ).Date);
  }

}
