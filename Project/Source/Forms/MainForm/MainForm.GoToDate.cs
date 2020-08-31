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
/// <edited> 2019-10 </edited>
using System;
using System.Data;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private bool GoToDateMutex;

    /// <summary>
    /// Set the data position.
    /// </summary>
    /// <param name="date">The date.</param>
    internal void GoToDate(DateTime date)
    {
      if ( !Globals.IsReady || IsGenerating || GoToDateMutex ) return;
      GoToDateMutex = true;
      if ( date < DateFirst ) date = DateFirst;
      if ( date > DateLast ) date = DateLast;
      try
      {
        if ( NavigationForm.Instance != null )
          NavigationForm.Instance.Date = date;
      }
      catch
      {
      }
      try
      {
        CalendarMonth.CalendarDate = date;
      }
      catch
      {
      }
      try
      {
        int position = LunisolarDaysBindingSource.Find("Date", SQLiteDate.ToString(date));
        if ( position >= 0 )
        {
          LunisolarDaysBindingSource.Position = LunisolarDaysBindingSource.Find("Date", SQLiteDate.ToString(date));
          CurrentDay = (Data.DataSet.LunisolarDaysRow)( (DataRowView)LunisolarDaysBindingSource.Current ).Row;
          CalendarGrid.Update();
        }
      }
      catch
      {
      }
      try
      {
        string strDate = date.Day.ToString("00") + "." + date.Month.ToString("00") + "." + date.Year.ToString("0000");
        int pos = CalendarText.Find(strDate);
        if ( pos != -1 )
        {
          CalendarText.SelectionStart = pos - 6 - 118;
          CalendarText.SelectionLength = 0;
          CalendarText.ScrollToCaret();
          CalendarText.SelectionStart = pos - 6;
          CalendarText.SelectionLength = 118;
        }
      }
      catch
      {
      }
      GoToDateMutex = false;
    }

  }

}
