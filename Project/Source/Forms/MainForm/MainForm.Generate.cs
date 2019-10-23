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
/// <created> 2016-04 </created>
/// <edited> 2019-10 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void DoGenerate(object sender, EventArgs e)
    {
      try
      {
        IsReady = false;
        TimerReminder.Enabled = false;
        try
        {
          int yearFirst;
          int yearLast;
          if ( sender != null )
          {
            var form = new SelectYearsForm();
            if ( form.ShowDialog() == DialogResult.Cancel ) return;
            yearFirst = (int)form.EditYearFirst.Value;
            yearLast = (int)form.EditYearLast.Value;
          }
          else
          {
            yearFirst = YearFirst;
            yearLast = YearLast;
          }
          ClearLists();
          GenerateData(yearFirst, yearLast);
        }
        finally
        {
          IsReady = true;
          if ( e != null )
          {
            GoToDate(DateTime.Now);
            TimerReminder.Enabled = true;
            Timer_Tick(this, null);
          }
        }
      }
      catch ( AbortException )
      {
        throw;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}