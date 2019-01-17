/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2016-04 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm
  {

    /// <summary>
    /// Provide view connector.
    /// </summary>
    private class ViewConnector
    {

      /// <summary>
      /// The menu item.
      /// </summary>
      public ToolStripMenuItem MenuItem;

      /// <summary>
      /// The panel.
      /// </summary>
      public Panel Panel;

      /// <summary>
      /// The focused control.
      /// </summary>
      public Control Focused;

    }

    /// <summary>
    /// Set the view panel.
    /// </summary>
    /// <param name="view">The view mode.</param>
    internal void SetView(ViewModeType view)
    {
      SetView(view, false);
    }

    /// <summary>
    /// Set the view panel.
    /// </summary>
    /// <param name="view">The view mode.</param>
    /// <param name="first">true to first.</param>
    internal void SetView(ViewModeType view, bool first)
    {
      var ViewPanels = new Dictionary<ViewModeType, ViewConnector>()
      {
        {
          ViewModeType.Text,
          new ViewConnector
          {
            MenuItem = ActionViewText,
            Panel = PanelViewText,
            Focused = CalendarText
          }
        },
        {
          ViewModeType.Grid,
          new ViewConnector
          {
            MenuItem = ActionViewGrid,
            Panel = PanelViewGrid,
            Focused = CalendarGrid
          }
        }
      };
      if ( Program.Settings.CurrentView == view && !first ) return;
      ViewPanels[Program.Settings.CurrentView].MenuItem.Checked = false;
      ViewPanels[Program.Settings.CurrentView].Panel.Parent = null;
      ViewPanels[view].MenuItem.Checked = true;
      ViewPanels[view].Panel.Parent = PanelCalendar;
      ViewPanels[view].Focused.Focus();
      Program.Settings.CurrentView = view;
    }

    /// <summary>
    /// Update progress bar.
    /// </summary>
    private bool UpdateProgress(int index, int count, string text)
    {
      if ( index == 0 ) BarProgress.Maximum = count;
      BarProgress.Value = index > count ? count : index;
      BarProgress.Update();
      SetStatus(text);
      Application.DoEvents();
      return IsGenerating;
    }

    /// <summary>
    /// Update the buttons.
    /// </summary>
    private void UpdateButtons()
    {
      try
      {
        ActionSaveReport.Enabled = !IsGenerating && LunisolarCalendar.LunisolarDays.Count > 0;
        ActionExportCSV.Enabled = ActionSaveReport.Enabled;
        ActionCopyReportToClipboard.Enabled = ActionSaveReport.Enabled;
        ActionSearchDay.Enabled = ActionSaveReport.Enabled;
        ActionNavigate.Enabled = ActionSaveReport.Enabled;
        ActionGenerate.Enabled = !IsGenerating;
        ActionStop.Enabled = IsGenerating;
        SctionPreferences.Enabled = !IsGenerating;
        BarProgress.Value = 0;
        LabelStatus.Text = "";
        Refresh();
      }
      catch ( Exception except )
      {
        DisplayManager.ShowError(except.Message);
      }
    }

    /// <summary>
    /// Update the text calendar view aspect.
    /// </summary>
    public void UpdateTextCalendar()
    {
      CalendarText.Font = new Font(Program.Settings.FontName, Program.Settings.FontSize);
    }

    /// <summary>
    /// Set the status label text.
    /// </summary>
    /// <param name="text">The text.</param>
    private void SetStatus(string text)
    {
      if ( LabelStatus.Text == text ) return;
      LabelStatus.Text = text;
      StatusBottom.Refresh();
    }

    /// <summary>
    /// Center the form to the screen.
    /// </summary>
    protected internal new void CenterToScreen()
    {
      base.CenterToScreen();
    }

    /// <summary>
    /// Execute the screen position operation.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    protected void DoScreenPosition(object sender, EventArgs e)
    {
      int left = SystemInformation.WorkingArea.Left;
      int top = SystemInformation.WorkingArea.Top;
      int width = SystemInformation.WorkingArea.Width;
      int height = SystemInformation.WorkingArea.Height;
      if ( sender != null && sender is ToolStripMenuItem )
      {
        var value = sender as ToolStripMenuItem;
        var list = ( (ToolStripMenuItem)value.OwnerItem ).DropDownItems;
        foreach ( ToolStripMenuItem item in list ) item.Checked = item == value;
      }
      if ( EditScreenTopLeft.Checked )
        Location = new Point(left, top);
      else
      if ( EditScreenTopRight.Checked )
        Location = new Point(left + width - Width, top);
      else
      if ( EditScreenBottomLeft.Checked )
        Location = new Point(left, top + height - Height);
      else
      if ( EditScreenBottomRight.Checked )
        Location = new Point(left + width - Width, top + height - Height);
      else
      if ( EditScreenCenter.Checked )
        CenterToScreen();
    }

  }

}
