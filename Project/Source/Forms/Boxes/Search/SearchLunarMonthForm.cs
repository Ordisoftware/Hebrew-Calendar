/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class SearchLunarMonthForm : Form
{

  private readonly MainForm MainForm = MainForm.Instance;

  private List<LunisolarDay> LunisolarDays => ApplicationDatabase.Instance.LunisolarDays;

  public LunisolarDay CurrentDay { get; private set; }

  private int CurrentDayIndex = -1;

  public SearchLunarMonthForm()
  {
    InitializeComponent();
    Icon = MainForm.Icon;
    ActiveControl = ListItems;
    CurrentDay = MainForm.CurrentDay;
    int year = CurrentDay is null ? DateTime.Today.Year : MainForm.CurrentDayYear;
    SelectYear.Fill(MainForm.YearsIntervalArray, year);
  }

  private void SearchLunarMonthForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
  }

  private void SearchLunarMonthForm_Shown(object sender, EventArgs e)
  {
    ListItems_SelectedIndexChanged(null, null);
  }

  private void SearchMonthForm_FormClosing(object sender, FormClosingEventArgs e)
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
    string selectedKey = ListItems.SelectedItems.Count > 0 ? ListItems.SelectedItems[0].Text : null;
    CurrentDayIndex = SelectDay.SelectedIndex;
    ListItems.Items.Clear();
    ListViewItem itemToSelect = null;
    ListViewItem itemToSelectDefault = null;
    foreach ( var row in LunisolarDays.Where(row => row.IsNewMoon && row.Date.Year == year && row.LunarMonth > 0) )
    {
      string key = Program.Settings.HebrewNamesInUnicode
        ? HebrewAlphabet.IntToUnicode(row.LunarMonth)
        : row.LunarMonth.ToString();
      string date = row.Date.ToLongDateString();
      var item = ListItems.Items.Add(key);
      item.SubItems.Add(HebrewTranslations.GetLunarMonthDisplayText(row.LunarMonth));
      item.SubItems.Add(date.Titleize());
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

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( ListItems.SelectedItems.Count <= 0 ) return;
    var row = (LunisolarDay)ListItems.SelectedItems[0].Tag;
    SelectDay.Items.Clear();
    int year = SelectYear.Value;
    var days = LunisolarDays.Where(day => day.Date.Year == year && day.LunarMonth == row.LunarMonth);
    SelectDay.Items.AddRange(days.ToArray());
    if ( CurrentDayIndex == -1 ) CurrentDayIndex = 0;
    if ( CurrentDayIndex >= SelectDay.Items.Count )
      CurrentDayIndex = SelectDay.Items.Count - 1;
    SelectDay.SelectedIndex = CurrentDayIndex;
  }

  private void SelectDay_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = ( (LunisolarDay)e.ListItem ).LunarDay.ToString();
  }

  private void SelectDay_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( SelectDay.SelectedItem is not null )
      MainForm.GoToDate(( (LunisolarDay)SelectDay.SelectedItem ).Date);
  }

}
