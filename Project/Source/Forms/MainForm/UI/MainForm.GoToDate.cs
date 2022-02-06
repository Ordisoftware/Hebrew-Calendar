/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private bool GoToDateMutex;

  public void GoToDate(DateTime date,
                       bool bringToFront = false,
                       bool onlyIfOpened = true,
                       bool onlyIfNotMinimized = false,
                       Form regetFocus = null)
  {
    if ( !Globals.IsReady || Globals.IsGenerating ) return;
    if ( GoToDateMutex ) return;
    if ( date < DateFirst ) date = DateFirst;
    if ( date > DateLast ) date = DateLast;
    if ( _DateSelected == DateTime.Today ) _DateSelected = null;
    GoToDateMutex = true;
    try
    {
      // Navigation window
      SystemManager.TryCatch(() =>
      {
        if ( NavigationForm.Instance is not null )
          NavigationForm.Instance.Date = date;
      });
      // Datagridview and bindingsource
      SystemManager.TryCatch(() =>
      {
        int position = LunisolarDaysBindingSource.IndexOf(LunisolarDays.Find(day => day.Date == date));
        if ( position >= 0 )
        {
          LunisolarDaysBindingSource.Position = position;
          CurrentDay = (LunisolarDay)LunisolarDaysBindingSource.Current;
        }
      });
      // Visual month
      SystemManager.TryCatch(() => CalendarMonth.CalendarDate = date);
      if ( Settings.CurrentView == ViewMode.Text )
        SystemManager.TryCatch(() =>
        {
          string strDate = $"{date.Day:00}.{date.Month:00}.{date.Year:0000}";
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
    }
    finally
    {
      if ( bringToFront )
        SystemManager.TryCatch(() =>
        {
          if ( !Visible && !onlyIfOpened )
            MenuShowHide_Click(null, null);
          else
          if ( WindowState == FormWindowState.Minimized && !onlyIfNotMinimized )
            this.Restore();
          else
          if ( Visible && !this.IsVisibleOnTop(80) )
            this.Popup();
          regetFocus?.Popup();
        });
      GoToDateMutex = false;
    }
  }

}
