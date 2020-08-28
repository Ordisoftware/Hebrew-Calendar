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
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private string DoGenerate(object sender, EventArgs e)
    {
      try
      {
        Globals.IsReady = false;
        TimerReminder.Enabled = false;
        try
        {
          int yearFirst;
          int yearLast;
          if ( sender != null )
          {
            var form = new SelectYearsForm();
            if ( e == null ) form.ActionCancel.Enabled = false;
            if ( form.ShowDialog() == DialogResult.Cancel ) return null;
            yearFirst = (int)form.EditYearFirst.Value;
            yearLast = (int)form.EditYearLast.Value;
          }
          else
          {
            yearFirst = YearFirst;
            yearLast = YearLast;
          }
          ClearLists();
          return GenerateData(yearFirst, yearLast);
        }
        finally
        {
          Globals.IsReady = true;
          UpdateButtons();
          if ( e != null )
          {
            GoToDate(DateTime.Today);
            TimerReminder.Enabled = MenuDisableReminder.Enabled;
            TimerReminder_Tick(null, null);
          }
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
        return null;
      }
    }

  }

}