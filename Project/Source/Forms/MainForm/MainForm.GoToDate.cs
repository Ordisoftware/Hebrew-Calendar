/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-05 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private bool GoToDateMutex;

    public void GoToDate(DateTime date)
    {
      if ( !Globals.IsReady || Globals.IsGenerating || GoToDateMutex ) return;
      if ( date < DateFirst ) date = DateFirst;
      if ( date > DateLast ) date = DateLast;
      GoToDateMutex = true;
      SystemManager.TryCatch(() =>
      {
        if ( NavigationForm.Instance != null )
          NavigationForm.Instance.Date = date;
      });
      SystemManager.TryCatch(() =>
      {
        CalendarMonth.CalendarDate = date;
      });
      SystemManager.TryCatch(() =>
      {
        int position = LunisolarDaysBindingSource.IndexOf(LunisolarDays.Find(day => day.Date == date));
        if ( position >= 0 )
        {
          LunisolarDaysBindingSource.Position = position;
          CurrentDay = (LunisolarDay)LunisolarDaysBindingSource.Current;
        }
      });
      SystemManager.TryCatch(() =>
      {
        string strDate = date.Day.ToString("00") + "." + date.Month.ToString("00") + "." + date.Year.ToString("0000");
        int position = CalendarText.Find(strDate);
        if ( position != -1 )
        {
          CalendarText.SelectionStart = position - 6 - 119;
          CalendarText.SelectionLength = 0;
          CalendarText.ScrollToCaret();
          CalendarText.SelectionStart = position - 6;
          CalendarText.SelectionLength = 119;
        }
      });
      GoToDateMutex = false;
    }

  }

}
