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
/// <edited> 2020-12 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{
  public partial class SelectYearControl : UserControl
  {

    public Data.DataSet.LunisolarDaysRow CurrentDay { get; private set; }

    public event EventHandler SelectedIndexChanged
    {
      add { SelectYear.SelectedIndexChanged += value; }
      remove { SelectYear.SelectedIndexChanged -= value; }
    }

    public int Count
    {
      get { return SelectYear.Items.Count; }
    }

    public ComboBox.ObjectCollection Items
    {
      get { return SelectYear.Items; }
    }

    public int SelectedIndex
    {
      get { return SelectYear.SelectedIndex; }
      set { SelectYear.SelectedIndex = value; }
    }

    public object SelectedItem
    {
      get { return SelectYear.SelectedItem; }
      set { SelectYear.SelectedItem = value; }
    }

    public SelectYearControl()
    {
      InitializeComponent();
    }

    public void Fill()
    {
      CurrentDay = MainForm.Instance.CurrentDay;
      int year = CurrentDay == null ? DateTime.Today.Year : SQLiteDate.ToDateTime(CurrentDay.Date).Year;
      Fill(MainForm.Instance.YearsIntervalArray, year);
    }

    public void Fill(IEnumerable<int> list, int selected)
    {
      foreach ( int value in list )
      {
        int index = SelectYear.Items.Add(value);
        if ( value == selected )
          SelectYear.SelectedIndex = index;
      }
      Refresh();
    }

    public override void Refresh()
    {
      base.Refresh();
      ActionFirst.Enabled = SelectYear.SelectedIndex > 0;
      ActionPrevious.Enabled = ActionFirst.Enabled;
      ActionLast.Enabled = SelectYear.SelectedIndex < SelectYear.Items.Count - 1;
      ActionNext.Enabled = ActionLast.Enabled;
    }

    private void SelectYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      Refresh();
    }

    private void ActionFirst_Click(object sender, EventArgs e)
    {
      SelectYear.SelectedIndex = 0;
      ActiveControl = ActionNext;
    }

    private void ActionPrevious_Click(object sender, EventArgs e)
    {
      if ( SelectYear.SelectedIndex > 0 ) SelectYear.SelectedIndex--;
      if ( SelectYear.SelectedIndex == 0 ) ActiveControl = ActionNext;
    }

    private void ActionNext_Click(object sender, EventArgs e)
    {
      if ( SelectYear.SelectedIndex < SelectYear.Items.Count - 1 ) SelectYear.SelectedIndex++;
      if ( SelectYear.SelectedIndex == SelectYear.Items.Count - 1 ) ActiveControl = ActionPrevious;
    }

    private void ActionLast_Click(object sender, EventArgs e)
    {
      SelectYear.SelectedIndex = SelectYear.Items.Count - 1;
      ActiveControl = ActionPrevious;
    }

  }

}
