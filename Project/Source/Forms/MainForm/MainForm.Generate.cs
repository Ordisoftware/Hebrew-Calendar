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
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    /// <summary>
    /// Check if the calendar must be generated again in it comes near the end.
    /// </summary>
    private string CheckRegenerateCalendar(bool auto = false)
    {
      try
      {
        if ( DateTime.Today.Year >= YearLast )
          if ( auto || Settings.AutoRegenerate )
          {
            var interval = new YearsIntervalItem(Program.Settings.AutoGenerateYearsInternal);
            int year = DateTime.Today.Year - 1;
            int yearFirst = year - interval.YearsBefore;
            int yearLast = year + interval.YearsAfter - 1;
            return DoGenerate(new Tuple<int, int>(yearFirst, yearLast), EventArgs.Empty);
          }
          else
            ActionGenerate_Click(ActionGenerate, null);
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      return null;
    }

    private string DoGenerate(object sender, EventArgs e)
    {
      try
      {
        bool isTimerEnabled = TimerReminder.Enabled;
        TimerReminder.Enabled = false;
        MenuTray.Enabled = false;
        try
        {
          int yearFirst;
          int yearLast;
          if ( sender != null )
            if ( sender is Tuple<int, int> values )
            {
              yearFirst = values.Item1;
              yearLast = values.Item2;
            }
            else
            {
              if ( !SelectYearsForm.Run(e != null, out yearFirst, out yearLast) )
                return null;
            }
          else
          {
            yearFirst = YearFirst;
            yearLast = YearLast;
          }
          ClearLists();
          return CreateData(yearFirst, yearLast);
        }
        finally
        {
          MenuTray.Enabled = true;
          UpdateButtons();
          if ( e != null )
          {
            GoToDate(DateTime.Today);
            TimerReminder.Enabled = isTimerEnabled;
            if ( TimerReminder.Enabled )
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