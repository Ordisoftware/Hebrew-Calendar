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
/// <created> 2020-08 </created>
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class SearchGregorianMonthForm : Form
{

  private readonly MainForm MainForm = MainForm.Instance;

  public LunisolarDayRow CurrentDay { get; private set; }

  private int CurrentDayIndex = -1;

  private bool GoToDateMutex;

  public SearchGregorianMonthForm()
  {
    InitializeComponent();
    Icon = MainForm.Icon;
    ActiveControl = ListItems;
    GoToDateMutex = true;
    CurrentDay = MainForm.CurrentDay;
    int year = CurrentDay is null ? DateTime.Today.Year : MainForm.CurrentDayYear;
    SelectYear.Fill(MainForm.YearsIntervalArray, year);
  }

  private void SearchGregorianMonthForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
    ListItems.Items[CurrentDay.Date.Month - 1].Selected = true;
    GoToDateMutex = false;
    SelectDay.SelectedIndex = CurrentDay.Date.Day - 1;
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

  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  private void SelectYear_SelectedIndexChanged(object sender, EventArgs e)
  {
    int selectedKey = ListItems.SelectedIndices.Count > 0 ? ListItems.SelectedIndices[0] : -1;
    CurrentDayIndex = SelectDay.SelectedIndex;
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
    if ( ListItems.SelectedIndices.Count <= 0 ) return;
    SelectDay.Items.Clear();
    var listDays = Enumerable.Range(1, DateTime.DaysInMonth(SelectYear.Value, ListItems.SelectedIndices[0] + 1));
    SelectDay.Items.AddRange([.. listDays.Cast<object>()]);
    if ( CurrentDayIndex == -1 ) CurrentDayIndex = 0;
    if ( CurrentDayIndex >= SelectDay.Items.Count )
      CurrentDayIndex = SelectDay.Items.Count - 1;
    SelectDay.SelectedIndex = CurrentDayIndex;
  }

  private void SelectDay_SelectedIndexChanged(object sender, EventArgs e)
  {
    CurrentDayIndex = SelectDay.SelectedIndex;
    if ( !GoToDateMutex && SelectDay.SelectedItem is not null )
      MainForm.GoToDate(new DateTime(SelectYear.Value, ListItems.SelectedIndices[0] + 1, CurrentDayIndex + 1));
  }

}
