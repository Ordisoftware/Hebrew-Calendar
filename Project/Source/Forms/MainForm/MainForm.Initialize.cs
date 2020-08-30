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
        if ( item.Id == Program.Settings.TimeZone )
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
      ActionWebLinks.Visible = Program.Settings.WebLinksMenuEnabled;
      MenuWebLinks.Visible = Program.Settings.WebLinksMenuEnabled;
      if ( Program.Settings.WebLinksMenuEnabled )
      {
        ActionWebLinks.InitializeFromWebLinks(InitializeSpecialMenus);
        ActionWebLinks.DuplicateTo(MenuWebLinks);
      }
      ActionViewMoonMonths.ShortcutKeys = Keys.None;
      ActionTools.DuplicateTo(MenuTools);
      ActionViewMoonMonths.ShortcutKeys = Keys.F10;
      ActionInformation.DuplicateTo(MenuInformation);
      if ( !Program.Settings.AllowSuspendReminder && ActionEnableReminder.Enabled )
        ActionEnableReminder.PerformClick();
      ActionDisableReminder.Enabled = Program.Settings.AllowSuspendReminder;
      MenuDisableReminder.Enabled = ActionDisableReminder.Enabled;
    }

    /// <summary>
    /// Initialize the calendar month view aspect.
    /// </summary>
    private void InitializeCalendarUI()
    {
      int sizeFont = Program.Settings.MonthViewFontSize;
      CalendarMonth.RogueBrush = new SolidBrush(Program.Settings.MonthViewNoDaysBackColor);
      CalendarMonth.ForeColor = Program.Settings.MonthViewTextColor;
      CalendarMonth.BackColor = Program.Settings.MonthViewBackColor;
      CalendarMonth.CurrentDayForeColor = Program.Settings.CurrentDayForeColor;
      CalendarMonth.CurrentDayBackColor = Program.Settings.CurrentDayBackColor;
      CalendarMonth.DateHeaderFont = new Font("Calibri", sizeFont + 5, FontStyle.Bold);
      CalendarMonth.DayOfWeekFont = new Font("Calibri", sizeFont + 1);
      CalendarMonth.DayViewTimeFont = new Font("Calibri", sizeFont + 1, FontStyle.Bold);
      CalendarMonth.DaysFont = new Font("Calibri", sizeFont + 2);
      CalendarMonth.TodayFont = new Font("Microsoft Sans Serif", sizeFont + 2, FontStyle.Bold);
      CalendarMonth.TheEvents.Clear();
    }

    /// <summary>
    /// Check if the calendar must be generated again in it comes near the end.
    /// </summary>
    private string CheckRegenerateCalendar(bool auto = false)
    {
      try
      {
        if ( DateTime.Today.Year >= YearLast )
          if ( auto || Program.Settings.AutoRegenerate )
          {
            int yearFirst = DateTime.Today.Year - 1;
            int yearLast = YearFirst + Program.Settings.AutoGenerateYearsInternal - 1;
            return DoGenerate(new Tuple<int, int>(yearFirst, yearLast), EventArgs.Empty);
          }
          else
            ActionGenerate.PerformClick();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      return null;
    }

  }

}
