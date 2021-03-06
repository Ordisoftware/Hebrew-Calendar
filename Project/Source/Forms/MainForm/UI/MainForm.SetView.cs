﻿/// <license>
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
/// <edited> 2020-12 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm
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
    public void SetView(ViewMode view)
    {
      SetView(view, false);
    }

    /// <summary>
    /// Set the view panel.
    /// </summary>
    /// <param name="view">The view mode.</param>
    /// <param name="first">true to first.</param>
    public void SetView(ViewMode view, bool first)
    {
      var ViewPanels = new Dictionary<ViewMode, ViewConnector>()
      {
        {
          ViewMode.Text,
          new ViewConnector
          {
            MenuItem = ActionViewReport,
            Panel = PanelViewText,
            Focused = CalendarText
          }
        },
        {
          ViewMode.Month,
          new ViewConnector
          {
            MenuItem = ActionViewMonth,
            Panel = PanelViewMonth,
            Focused = CalendarMonth
          }
        },
        {
          ViewMode.Grid,
          new ViewConnector
          {
            MenuItem = ActionViewGrid,
            Panel = PanelViewGrid,
            Focused = CalendarGrid
          }
        }
      };
      try
      {
        if ( Settings.CurrentView == view && !first ) return;
        if ( view == ViewMode.None || !Enum.IsDefined(typeof(ViewMode), view) )
          view = ViewMode.Month;
        ViewPanels[Settings.CurrentView].MenuItem.Checked = false;
        ViewPanels[Settings.CurrentView].Panel.Parent = null;
        ViewPanels[view].MenuItem.Checked = true;
        ViewPanels[view].Panel.Parent = PanelCalendar;
        ViewPanels[view].Focused.Focus();
        Settings.CurrentView = view;
        UpdateButtons();
        if (view == ViewMode.Grid)
          if ( CalendarGrid.SelectedRows.Count > 0 )
            CalendarGrid.FirstDisplayedScrollingRowIndex = CalendarGrid.SelectedRows[0].Index;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}