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

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectDayForm : Form
  {

    public SelectDayForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

  }

}
