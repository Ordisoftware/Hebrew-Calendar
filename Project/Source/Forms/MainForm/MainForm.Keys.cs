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
/// <edited> 2020-04 </edited>
using System;
using System.Windows.Forms;

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
        case Keys.Control | Keys.Tab:
          if ( Program.Settings.CurrentView == ViewMode.Text )
            SetView(ViewMode.Month);
          else
          if ( Program.Settings.CurrentView == ViewMode.Month )
            SetView(ViewMode.Grid);
          else
          if ( Program.Settings.CurrentView == ViewMode.Grid )
            SetView(ViewMode.Text);
          return true;
        case Keys.Control | Keys.T:
          GoToDate(DateTime.Today);
          return true;
        case Keys.Control | Keys.D:
          ActionSearchDay.PerformClick();
          return true;
        case Keys.Control | Keys.E:
          ActionSearchEvent.PerformClick();
          return true;
        case Keys.Control | Keys.M:
          ActionSearchMonth.PerformClick();
          return true;
        case Keys.Control | Keys.N:
          ActionNavigate.PerformClick();
          return true;
        case Keys.Control | Keys.A:
          if ( ActiveControl == CalendarText )
            CalendarText.SelectAll();
          else
            ActionViewCelebrations.PerformClick();
          return true;
        case Keys.Control | Keys.P:
          ActionPrint.PerformClick();
          return true;
        case Keys.Alt | Keys.C:
          ActionOpenCalculator.PerformClick();
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
        case Keys.F8:
          ActionPreferences.PerformClick();
          return true;
        case Keys.F11:
          ActionHelp.PerformClick();
          return true;
        case Keys.F12:
          ActionAbout.PerformClick();
          return true;
        case Keys.Escape:
          if ( EditESCtoExit.Checked )
            Close();
          return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

  }

}
