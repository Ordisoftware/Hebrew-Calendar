/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
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

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectYearsForm : Form
  {

    public SelectYearsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void SelectYearsRangeForm_Load(object sender, EventArgs e)
    {
      DateTime date = DateTime.Now;
      int year = date.Year;
      if ( date.Month < 3 ) year--;
      EditYearFirst.Value = year;
      EditYearLast.Value = year + 2;
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
      int yearFirst = (int)EditYearFirst.Value;
      int yearLast = (int)EditYearLast.Value;
      if ( yearFirst == yearLast )
        yearLast = yearFirst + 1;
      else
      if ( yearFirst > yearLast )
      {
        int temp = yearFirst;
        yearFirst = yearLast;
        yearLast = temp;
      }
      EditYearFirst.Value = yearFirst;
      EditYearLast.Value = yearLast;
      DialogResult = DialogResult.OK;
    }

  }

}
