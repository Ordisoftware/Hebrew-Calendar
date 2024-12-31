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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private ViewConnectors<ViewMode, ToolStripMenuItem> ViewConnectors;

  private void InitializeViewConnectors()
  {
    ViewConnectors = new ViewConnectors<ViewMode, ToolStripMenuItem>
    {
      {
        ViewMode.Text,
        new ViewConnector<ToolStripMenuItem>
        {
          Component = ActionViewReport,
          Panel = PanelViewTextReport,
          Focused = TextReport
        }
      },
      {
        ViewMode.Month,
        new ViewConnector<ToolStripMenuItem>
        {
          Component = ActionViewMonth,
          Panel = PanelViewMonthlyCalendar,
          Focused = MonthlyCalendar
        }
      },
      {
        ViewMode.Grid,
        new ViewConnector<ToolStripMenuItem>
        {
          Component = ActionViewGrid,
          Panel = PanelViewGrid,
          Focused = DataGridView
        }
      }
    };
  }

}
