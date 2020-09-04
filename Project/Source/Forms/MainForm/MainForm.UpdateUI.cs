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
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm
  {

    /// <summary>
    /// Bring to front improved.
    /// </summary>
    public new void BringToFront()
    {
      var temp = TopMost;
      TopMost = true;
      base.BringToFront();
      TopMost = temp;
    }

    /// <summary>
    /// Update the buttons.
    /// </summary>
    internal void UpdateButtons()
    {
      SystemManager.TryCatchManage(() =>
      {
        if ( LoadingForm.Instance.Visible ) LoadingForm.Instance.Hide();
        MenuTray.Enabled = Globals.IsReady && !IsGenerating;
        ToolStrip.Enabled = !IsGenerating;
        ActionSaveReport.Enabled = DataSet.LunisolarDays.Count > 0;
        ActionExportCSV.Enabled = ActionSaveReport.Enabled;
        ActionCopyReportToClipboard.Enabled = ActionSaveReport.Enabled;
        ActionPrint.Enabled = ActionSaveReport.Enabled;
        ActionSearchEvent.Enabled = ActionSaveReport.Enabled;
        ActionSearchMonth.Enabled = ActionSaveReport.Enabled;
        ActionSearchDay.Enabled = ActionSaveReport.Enabled;
        ActionNavigate.Enabled = ActionSaveReport.Enabled;
        ActionViewCelebrations.Enabled = ActionSaveReport.Enabled;
        Refresh();
      });
    }

    /// <summary>
    /// Update the text view aspect.
    /// </summary>
    public void UpdateTextCalendar()
    {
      CalendarText.Font = new Font(Settings.FontName, Settings.FontSize);
    }

    /// <summary>
    /// Update the month view.
    /// </summary>
    internal void UpdateCalendarMonth(bool doFill)
    {
      IsGenerating = true;
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      Enabled = false;
      PanelViewMonth.Parent = null;
      try
      {
        InitializeCalendarUI();
        if ( doFill ) FillMonths();
      }
      finally
      {
        Enabled = true;
        Cursor = cursor;
        IsGenerating = false;
        SetView(Settings.CurrentView, true);
        UpdateButtons();
      }
    }

  }

}
