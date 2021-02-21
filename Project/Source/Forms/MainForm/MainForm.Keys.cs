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
/// <edited> 2021-02 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
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
          // System process
          case Keys.Alt | Keys.Control | Keys.F4:
            MenuExit.PerformClick();
            return true;
          case Keys.Escape:
            if ( EditESCtoExit.Checked ) Close();
            return true;
          // System function
          case Keys.F9:
            ActionPreferences.PerformClick();
            return true;
          //case Keys.F12:
            //ActionAbout_Click(null, null);
            //return true;
          // Application function
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
          case Keys.Alt | Keys.P:
            ActionViewParashot.PerformClick();
            return true;
          // Change view
          case Keys.Control | Keys.Shift | Keys.Tab:
            SetView(Settings.CurrentView.Previous(new[] { ViewMode.None }));
            return true;
          case Keys.Control | Keys.Tab:
            SetView(Settings.CurrentView.Next(new[] { ViewMode.None }));
            return true;
          // Application menu
          case Keys.Alt | Keys.T:
            ActionTools.ShowDropDown();
            return true;
          case Keys.Alt | Keys.L:
            ActionWebLinks.ShowDropDown();
            return true;
          case Keys.Alt | Keys.V:
            ActionView.ShowDropDown();
            return true;
          // System menu
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
      if ( Settings.CurrentView == ViewMode.Month )
        switch ( keyData )
        {
          case Keys.Home:
            GoToDate(new DateTime(YearFirst, 1, 1));
            return true;
          case Keys.End:
            GoToDate(new DateTime(YearLast, 12, 1));
            return true;
          case Keys.Up:
          case Keys.PageUp:
            GoToDate(SQLiteDate.ToDateTime(CurrentDay.Date).Change(day: 1).AddYears(-1));
            return true;
          case Keys.Down:
          case Keys.PageDown:
            GoToDate(SQLiteDate.ToDateTime(CurrentDay.Date).Change(day: 1).AddYears(1));
            return true;
          case Keys.Left:
            GoToDate(SQLiteDate.ToDateTime(CurrentDay.Date).Change(day: 1).AddMonths(-1));
            return true;
          case Keys.Right:
            GoToDate(SQLiteDate.ToDateTime(CurrentDay.Date).Change(day: 1).AddMonths(1));
            return true;
        }
      return base.ProcessCmdKey(ref msg, keyData);
    }

  }

}
