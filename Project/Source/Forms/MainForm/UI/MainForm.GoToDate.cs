/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2022-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private bool GoToDateMutex;

  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  [SuppressMessage("Design", "GCop176:This anonymous method should not contain complex code, Instead call other focused methods to perform the complex logic", Justification = "<En attente>")]
  public void GoToDate(DateTime date,
                       bool bringToFront = false,
                       bool onlyIfOpened = true,
                       bool onlyIfNotMinimized = false,
                       Form retakeFocus = null,
                       ViewScrollOverride scroll = ViewScrollOverride.None)
  {
    if ( !Globals.IsReady ) return;
    if ( Globals.IsProcessingData ) return;
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
      // Grid and binding source
      SystemManager.TryCatch(() =>
      {
        int position = LunisolarDaysBindingSource.IndexOf(LunisolarDays.Find(day => day.Date == date));
        if ( position >= 0 )
        {
          LunisolarDaysBindingSource.Position = position;
          CurrentDay = (LunisolarDayRow)LunisolarDaysBindingSource.Current;
        }
      });
      // Visual month and text report
      SystemManager.TryCatch(() => MonthlyCalendar.CalendarDate = date);
      if ( scroll != ViewScrollOverride.NoTextReport )
        if ( scroll == ViewScrollOverride.ForceTextReport || Settings.CurrentView == ViewMode.Text )
          SystemManager.TryCatch(() =>
          {
            var tempSep = SQLiteDate.DaySeparator;
            var tempOrder = SQLiteDate.DayOrder;
            try
            {
              SQLiteDate.DaySeparator = SQLiteDateDayTextSeparator.Point;
              SQLiteDate.DayOrder = SQLiteDateDayTextOrder.DayFirst;
              string strDatePattern = SQLiteDate.ToString(date);
              int position = TextReport.Find(strDatePattern);
              if ( position != -1 )
              {
                string line = TextReport.Lines[TextReport.GetLineFromCharIndex(TextReport.SelectionStart)];
                bool needScroll = line.IndexOf(strDatePattern, StringComparison.Ordinal) == -1;
                TextReport.SelectionStart = position - 6;
                TextReport.SelectionLength = 119;
                if ( needScroll ) TextReport.ScrollToCaret();
              }
            }
            finally
            {
              SQLiteDate.DaySeparator = tempSep;
              SQLiteDate.DayOrder = tempOrder;
            }
          });
    }
    finally
    {
      if ( bringToFront )
        SystemManager.TryCatch(() =>
        {
          if ( onlyIfOpened ) return;
          if ( !Visible )
            MenuShowHide_Click(null, null);
          else
          if ( WindowState == FormWindowState.Minimized && !onlyIfNotMinimized )
            this.Restore();
          else
          if ( Visible && !this.IsVisibleOnTop(Globals.WindowDetectionMargin) )
            this.Popup();
          if ( retakeFocus is not null )
            retakeFocus.Popup();
          else
            this.Popup();
        });
      GoToDateMutex = false;
    }
  }

}
