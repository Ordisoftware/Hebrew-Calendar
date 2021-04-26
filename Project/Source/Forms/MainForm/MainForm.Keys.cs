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
/// <edited> 2021-03 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    /// <summary>
    /// Process the command key.
    /// </summary>
    /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if ( Globals.IsReady )
        switch ( keyData )
        {
          // System close
          case Keys.Alt | Keys.Control | Keys.F4:
            MenuExit.PerformClick();
            return true;
          case Keys.Escape:
            if ( EditESCtoExit.Checked ) Close();
            return true;
          // System tools
          case Keys.F9:
            ActionPreferences.PerformClick();
            return true;
          // Change view
          case Keys.Control | Keys.Shift | Keys.Tab:
            SetView(Settings.CurrentView.Previous(ViewMode.None));
            return true;
          case Keys.Control | Keys.Tab:
            SetView(Settings.CurrentView.Next(ViewMode.None));
            return true;
          // Application functions
          case Keys.F4:
            ActionViewCelebrations.PerformClick();
            return true;
          case Keys.F5:
            ActionSearchEvent.PerformClick();
            return true;
          case Keys.F6:
            ActionSearchMonth.PerformClick();
            return true;
          case Keys.F7:
            ActionSearchGregorianMonth.PerformClick();
            return true;
          case Keys.F8:
          case Keys.Control | Keys.N:
            ActionNavigate.PerformClick();
            return true;
          // Application menus
          case Keys.Alt | Keys.T:
            ActionTools.ShowDropDown();
            return true;
          case Keys.Alt | Keys.P:
            if ( ActionOnlineParashah.DropDownItems.Count <= 0 ) break;
            ActionTools.ShowDropDown();
            ActionOnlineParashah.ShowDropDown();
            ActionOnlineParashah.DropDownItems[0].Select();
            return true;
          case Keys.Alt | Keys.L:
            ActionWebLinks.ShowDropDown();
            return true;
          case Keys.Alt | Keys.V:
            ActionView.ShowDropDown();
            return true;
          // System menus
          case Keys.Alt | Keys.S:
            ActionSettings.ShowDropDown();
            return true;
          case Keys.Alt | Keys.I:
            ActionInformation.ShowDropDown();
            return true;
          // Export
          case Keys.Control | Keys.S:
            ActionSaveToFile.PerformClick();
            return true;
          case Keys.Control | Keys.C:
            ActionCopyToClipboard.PerformClick();
            return true;
          case Keys.Control | Keys.P:
            ActionPrint.PerformClick();
            return true;
          // Search
          case Keys.Control | Keys.D:
            ActionSearchDay.PerformClick();
            return true;
          case Keys.NumPad0:
          case Keys.Control | Keys.T:
            GoToDate(DateTime.Today);
            return true;
        }
      // Visual month navigation
      void search(bool isFuture, Func<int, bool> check)
      {
        var date = CurrentDay.DateAsDateTime.Change(day: 1);
        if ( isFuture ) date = date.AddMonths(1);
        string str = SQLiteDate.ToString(date);
        var query = from day in DataSet.LunisolarDays
                    where check(day.Date.CompareTo(str)) && day.HasTorahEvent && !day.IsNewYear
                    select day;
        var found = isFuture ? query.FirstOrDefault() : query.LastOrDefault();
        if ( found != null ) GoToDate(found.Date);
      }
      if ( Settings.CurrentView == ViewMode.Month && CurrentDay != null )
        switch ( keyData )
        {
          case Keys.Control | Keys.Home:
            search(true, v => v < 0);
            break;
          case Keys.Control | Keys.End:
            search(false, v => v >= 0);
            break;
          case Keys.Control | Keys.Left:
            search(false, v => v < 0);
            break;
          case Keys.Control | Keys.Right:
            search(true, v => v >= 0);
            break;
          case Keys.Home:
            GoToDate(new DateTime(YearFirst, 1, 1));
            return true;
          case Keys.End:
            GoToDate(new DateTime(YearLast, 12, 1));
            return true;
          case Keys.Up:
          case Keys.PageUp:
            GoToDate(CurrentDay.DateAsDateTime.Change(day: 1).AddYears(-1));
            return true;
          case Keys.Down:
          case Keys.PageDown:
            GoToDate(CurrentDay.DateAsDateTime.Change(day: 1).AddYears(1));
            return true;
          case Keys.Left:
            GoToDate(CurrentDay.DateAsDateTime.Change(day: 1).AddMonths(-1));
            return true;
          case Keys.Right:
            GoToDate(CurrentDay.DateAsDateTime.Change(day: 1).AddMonths(1));
            return true;
        }
      return base.ProcessCmdKey(ref msg, keyData);
    }

  }

}
