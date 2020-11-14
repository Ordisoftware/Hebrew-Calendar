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
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm : Form
  {

    /// <summary>
    /// Set the initial directories of dialog boxes.
    /// </summary>
    internal void InitializeDialogsDirectory()
    {
      SaveCSVDialog.InitialDirectory = Globals.UserDocumentsFolderPath;
      SaveFileDialog.InitialDirectory = Globals.UserDocumentsFolderPath;
    }

    /// <summary>
    /// Initialize current time zone.
    /// </summary>
    internal void InitializeCurrentTimeZone()
    {
      CurrentTimeZoneInfo = null;
      foreach ( var item in TimeZoneInfo.GetSystemTimeZones() )
        if ( item.Id == Settings.TimeZone )
        {
          CurrentTimeZoneInfo = item;
          break;
        }
    }

    /// <summary>
    /// Initialize special menus (web links, tray icon and suspend).
    /// </summary>
    internal void InitializeSpecialMenus()
    {
      ActionWebLinks.Visible = Settings.WebLinksMenuEnabled;
      MenuWebLinks.Visible = Settings.WebLinksMenuEnabled;
      if ( Settings.WebLinksMenuEnabled )
      {
        ActionWebLinks.InitializeFromWebLinks(InitializeSpecialMenus);
        ActionWebLinks.DuplicateTo(MenuWebLinks);
      }
      ActionViewMoonMonths.ShortcutKeys = Keys.None;
      ActionTools.DuplicateTo(MenuTools);
      ActionViewMoonMonths.ShortcutKeys = Keys.F10;
      ActionInformation.DuplicateTo(MenuInformation);
      if ( !Settings.AllowSuspendReminder && ActionEnableReminder.Enabled )
        ActionEnableReminder.PerformClick();
      ActionDisableReminder.Enabled = Settings.AllowSuspendReminder;
      MenuDisableReminder.Enabled = ActionDisableReminder.Enabled;
    }

    /// <summary>
    /// Initialize the calendar month view aspect.
    /// </summary>
    private void InitializeCalendarUI()
    {
      CalendarMonth.TheEvents.Clear();
      int sizeFont = Settings.MonthViewFontSize;
      if ( Settings.UseColors )
      {
        CalendarMonth.RogueBrush = new SolidBrush(Settings.MonthViewNoDaysBackColor);
        CalendarMonth.ForeColor = Settings.MonthViewTextColor;
        CalendarMonth.BackColor = Settings.MonthViewBackColor;
        CalendarMonth.CurrentDayForeColor = Settings.CurrentDayForeColor;
        CalendarMonth.CurrentDayBackColor = Settings.CurrentDayBackColor;
      }
      else
      {
        CalendarMonth.RogueBrush = new SolidBrush(Color.WhiteSmoke);
        CalendarMonth.ForeColor = Color.Black;
        CalendarMonth.BackColor = Color.White;
        CalendarMonth.CurrentDayForeColor = Color.White;
        CalendarMonth.CurrentDayBackColor = Color.Black;
      }
      CalendarMonth.DateHeaderFont = new Font("Calibri", sizeFont + 5, FontStyle.Bold);
      CalendarMonth.DayOfWeekFont = new Font("Calibri", sizeFont + 1);
      CalendarMonth.DayViewTimeFont = new Font("Calibri", sizeFont + 1, FontStyle.Bold);
      CalendarMonth.DaysFont = new Font("Calibri", sizeFont + 2);
      CalendarMonth.TodayFont = new Font("Microsoft Sans Serif", sizeFont + 2, FontStyle.Bold);
    }

  }

}
