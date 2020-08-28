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

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    /// <summary>
    /// Process the command key.
    /// </summary>
    /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch ( keyData )
      {
        // Change view
        case Keys.Control | Keys.Shift | Keys.Tab:
          SetView(Program.Settings.CurrentView.Previous());
          return true;
        case Keys.Control | Keys.Tab:
          SetView(Program.Settings.CurrentView.Next());
          return true;
        // Function keys
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
          ActionPreferences.PerformClick();
          return true;
        case Keys.F9:
        case Keys.Control | Keys.N:
          ActionNavigate.PerformClick();
          return true;
        case Keys.F10:
        case Keys.Control | Keys.M:
          if ( !Globals.IsDev ) return false; // TODO remove when finished
          ActionViewMoonMonths.PerformClick();
          return true;
        case Keys.F11:
          ActionHelp.PerformClick();
          return true;
        case Keys.F12:
          ActionAbout.PerformClick();
          return true;
        //Various actions
        case Keys.Escape:
          if ( EditESCtoExit.Checked )
            Close();
          return true;
        case Keys.Control | Keys.T:
          GoToDate(DateTime.Today);
          return true;
        case Keys.Control | Keys.D:
          ActionSearchDay.PerformClick();
          return true;
        case Keys.Control | Keys.P:
          ActionPrint.PerformClick();
          return true;
        case Keys.Control | Keys.C:
          ActionCopyReportToClipboard.PerformClick();
          return true;
        case Keys.Control | Keys.S:
          ActionSaveReport.PerformClick();
          return true;
        case Keys.Alt | Keys.S:
          ActionExportCSV.PerformClick();
          return true;
        // Month view calendar navigation
        case Keys.Home:
          if ( Program.Settings.CurrentView == ViewMode.Month )
          {
            GoToDate(new DateTime(YearFirst, 1, 1));
            return true;
          }
          break;
        case Keys.End:
          if ( Program.Settings.CurrentView == ViewMode.Month )
          {
            GoToDate(new DateTime(YearLast, 12, 1));
            return true;
          }
          break;
        case Keys.Right:
          if ( Program.Settings.CurrentView == ViewMode.Month )
          {
            var date = SQLite.GetDate(CurrentDay.Date);
            date = new DateTime(date.Year, date.Month, 1);
            GoToDate(date.AddMonths(1));
            return true;
          }
          break;
        case Keys.Left:
          if ( Program.Settings.CurrentView == ViewMode.Month )
          {
            var date = SQLite.GetDate(CurrentDay.Date);
            date = new DateTime(date.Year, date.Month, 1);
            GoToDate(date.AddMonths(-1));
            return true;
          }
          break;
        case Keys.Up:
          if ( Program.Settings.CurrentView == ViewMode.Month )
          {
            var date = SQLite.GetDate(CurrentDay.Date);
            date = new DateTime(date.Year, date.Month, 1);
            GoToDate(date.AddYears(1));
            return true;
          }
          break;
        case Keys.Down:
          if ( Program.Settings.CurrentView == ViewMode.Month )
          {
            var date = SQLite.GetDate(CurrentDay.Date);
            date = new DateTime(date.Year, date.Month, 1);
            GoToDate(date.AddYears(-1));
            return true;
          }
          break;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

  }

}
