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
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm
  {

    /// <summary>
    /// Center the form to the screen.
    /// </summary>
    protected internal new void CenterToScreen()
    {
      base.CenterToScreen();
    }

    private bool DoScreenPositionMutex;

    /// <summary>
    /// Execute the screen location operation.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    protected void DoScreenPosition(object sender, EventArgs e)
    {
      if ( DoScreenPositionMutex ) return;
      try
      {
        DoScreenPositionMutex = true;
        int left = SystemInformation.WorkingArea.Left;
        int top = SystemInformation.WorkingArea.Top;
        int width = SystemInformation.WorkingArea.Width;
        int height = SystemInformation.WorkingArea.Height;
        if ( sender != null && sender is ToolStripMenuItem )
        {
          var value = sender as ToolStripMenuItem;
          var list = ( (ToolStripMenuItem)value.OwnerItem ).DropDownItems;
          foreach ( ToolStripMenuItem item in list )
            item.Checked = item == value;
        }
        if ( EditScreenNone.Checked )
          return;
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
        EditScreenNone.Checked = false;
      }
      finally
      {
        DoScreenPositionMutex = false;
      }
    }

  }

}
