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
/// <created> 2019-01 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectYearsForm : Form
  {

    const int MinInterval = 2;
    const int DefaultInterval = 4;
    const int MaxRecommended = 20;

    public SelectYearsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private bool Mutex;
    private int Year;

    private void SelectYearsRangeForm_Load(object sender, EventArgs e)
    {
      DateTime date = DateTime.Now;
      Year = date.Year;
      if ( date.Month < 3 ) Year--;
      Mutex = true;
      EditYearFirst.Minimum = Year - 120;
      EditYearFirst.Maximum = Year + 120;
      EditYearLast.Minimum = Year - 120;
      EditYearLast.Maximum = Year + 120;
      EditYearFirst.Value = Year;
      EditYearLast.Value = Year + DefaultInterval;
      Mutex = false;
    }

    private void EditYearFirst_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( EditYearFirst.Value > Year )
        EditYearFirst.Value = Year;
      if ( EditYearFirst.Value >= EditYearLast.Value - 1 )
        EditYearLast.Value = EditYearFirst.Value + MinInterval;
    }

    private void EditYearLast_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( EditYearLast.Value < Year + MinInterval )
        EditYearLast.Value = Year + MinInterval;
      if ( EditYearLast.Value <= EditYearFirst.Value + 1 )
        EditYearFirst.Value = EditYearLast.Value - MinInterval;
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
      int yearFirst = (int)EditYearFirst.Value;
      int yearLast = (int)EditYearLast.Value;
      if ( yearFirst > yearLast )
      {
        int temp = yearFirst;
        yearFirst = yearLast;
        yearLast = temp;
      }
      if ( yearFirst == yearLast || yearFirst == yearLast + 1 )
        yearLast = yearFirst + DefaultInterval;
      if ( yearFirst > Year || Year > yearLast )
      {
        yearFirst = Year;
        yearLast = Year + DefaultInterval;
      }
      if ( yearLast - yearFirst > MaxRecommended )
        if ( !DisplayManager.QueryYesNo(Translations.BigCalendar.GetLang(MaxRecommended)) )
          return;
      EditYearFirst.Value = yearFirst;
      EditYearLast.Value = yearLast;
      DialogResult = DialogResult.OK;
    }

  }

}
