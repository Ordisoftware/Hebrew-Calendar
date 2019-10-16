/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SearchEventForm : Form
  {

    private Data.LunisolarCalendar.LunisolarDaysRow CurrentDay;

    private bool Mutex;

    public SearchEventForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void SearchEventForm_Load(object sender, EventArgs e)
    {
      Mutex = true;
      CurrentDay = MainForm.Instance.CurrentDay;
      EditYear.Minimum = MainForm.Instance.YearFirst;
      EditYear.Maximum = MainForm.Instance.YearLast;
      EditYear.Value = EditYear.Minimum;
      foreach ( TorahEventType type in Enum.GetValues(typeof(TorahEventType)) )
        if ( type != TorahEventType.None )
        {
          var item = new TorahEventItem() { Text = Translations.TorahEvent.GetLang(type), Event = type };
          int index = SelectEvents.Items.Add(item);
        }
      SelectEvents.SelectedIndex = 0;
      Mutex = false;
    }

    private void SearchEventForm_Shown(object sender, EventArgs e)
    {
      SelectChanged(null, null);
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
      if ( CurrentDay != null )
        MainForm.Instance.GoToDate(SQLiteUtility.GetDate(CurrentDay.Date));
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void SelectEvents_DoubleClick(object sender, EventArgs e)
    {
      ButtonOk.PerformClick();
    }

    private void SelectChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      var row = ( from day in MainForm.Instance.LunisolarCalendar.LunisolarDays
                  where (TorahEventType)day.TorahEvents == ( (TorahEventItem)SelectEvents.SelectedItem ).Event
                      && SQLiteUtility.GetDate(day.Date).Year == EditYear.Value
                  select day ).FirstOrDefault();
      if ( row == null ) return;
      MainForm.Instance.GoToDate(SQLiteUtility.GetDate(row.Date));
    }

  }

}
