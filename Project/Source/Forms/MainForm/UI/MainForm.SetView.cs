/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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

  /// <summary>
  /// Sets the view panel.
  /// </summary>
  /// <param name="view">The view mode.</param>
  /// <param name="first">true to first.</param>
  public void SetView(ViewMode view, bool first = false)
  {
    try
    {
      if ( Settings.CurrentView == view && !first ) return;
      if ( first )
      {
        ActionViewReport.Checked = false;
        ActionViewMonth.Checked = false;
        ActionViewGrid.Checked = false;
      }
      if ( view == ViewMode.None || !Enum.IsDefined(typeof(ViewMode), view) )
        view = ViewMode.Month;
      ViewConnectors[Settings.CurrentView].Component.Checked = false;
      ViewConnectors[Settings.CurrentView].Panel.Parent = null;
      ViewConnectors[view].Component.Checked = true;
      ViewConnectors[view].Panel.Parent = PanelMainInner2;
      ViewConnectors[view].Focused.Focus();
      Settings.CurrentView = view;
      UpdateButtons();
      if ( view == ViewMode.Text )
        GoToDate(CurrentDay?.Date ?? DateTime.Today, scroll: ViewScrollOverride.ForceTextReport);
      else
      if ( view == ViewMode.Grid && DataGridView.SelectedRows.Count > 0 )
        DataGridView.FirstDisplayedScrollingRowIndex = DataGridView.SelectedRows[0].Index;
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

}
