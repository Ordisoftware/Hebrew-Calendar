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
/// <edited> 2020-12 </edited>
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
      string directory = Settings.GetExportDirectory();
      SaveTextDialog.InitialDirectory = directory;
      SaveImageDialog.InitialDirectory = directory;
      SaveDataDialog.InitialDirectory = directory;
      FolderDialog.SelectedPath = directory;
      SaveDataDialog.Filter = Program.GridExportTargets.CreateFilters();
      SaveImageDialog.Filter = Program.ImageExportTargets.CreateFilters();
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
      ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
      ActionViewLog.Enabled = DebugManager.TraceEnabled;
      ActionWebLinks.Visible = Settings.WebLinksMenuEnabled;
      MenuWebLinks.Visible = Settings.WebLinksMenuEnabled;
      if ( Settings.WebLinksMenuEnabled )
      {
        ActionWebLinks.InitializeFromWebLinks(InitializeSpecialMenus);
        ActionWebLinks.DuplicateTo(MenuWebLinks);
      }
      ActionTools.DuplicateTo(MenuTools);
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
        CodeProjectCalendar.NET.Calendar.CurrentDayForeColor = Settings.CurrentDayForeColor;
        CodeProjectCalendar.NET.Calendar.CurrentDayBackColor = Settings.CurrentDayBackColor;
        CodeProjectCalendar.NET.Calendar.ColorText = Settings.MonthViewTextColor;
        CodeProjectCalendar.NET.Calendar.PenText = new Pen(Settings.MonthViewTextColor);
        CodeProjectCalendar.NET.Calendar.PenTextReduced
          = new Pen(Color.FromArgb(CodeProjectCalendar.NET.Calendar.PenText.Color.R < 125 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.R * 2 / 3,
                                   CodeProjectCalendar.NET.Calendar.PenText.Color.R < 125 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.G * 2 / 3,
                                   CodeProjectCalendar.NET.Calendar.PenText.Color.R < 125 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.B * 2 / 3));
        CodeProjectCalendar.NET.Calendar.BrushText = new SolidBrush(Settings.MonthViewTextColor);
        CodeProjectCalendar.NET.Calendar.BrushBlack = new SolidBrush(Settings.MonthViewTextColor);
        CodeProjectCalendar.NET.Calendar.BrushGrayMedium //= new SolidBrush(Color.FromArgb(170, 170, 170));
          = new SolidBrush(Color.FromArgb(CodeProjectCalendar.NET.Calendar.PenText.Color.R < 85 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.R * 2 / 3,
                                          CodeProjectCalendar.NET.Calendar.PenText.Color.R < 85 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.G * 2 / 3,
                                          CodeProjectCalendar.NET.Calendar.PenText.Color.R < 85 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.B * 2 / 3));
        CodeProjectCalendar.NET.Calendar.BrushGrayLight //= new SolidBrush(Color.FromArgb(234, 234, 234));
          = new SolidBrush(Color.FromArgb((int)( CodeProjectCalendar.NET.Calendar.PenText.Color.R < 20 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 0.92 : CodeProjectCalendar.NET.Calendar.PenText.Color.R * 0.92 ),
                                          (int)( CodeProjectCalendar.NET.Calendar.PenText.Color.R < 20 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 0.92 : CodeProjectCalendar.NET.Calendar.PenText.Color.G * 0.92 ),
                                          (int)( CodeProjectCalendar.NET.Calendar.PenText.Color.R < 20 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 0.92 : CodeProjectCalendar.NET.Calendar.PenText.Color.B * 0.92 )));
        CodeProjectCalendar.NET.Calendar.PenBrushBlack = new Pen(CodeProjectCalendar.NET.Calendar.BrushBlack)
        {
          DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };
      }
      else
      {
        CalendarMonth.RogueBrush = new SolidBrush(Color.WhiteSmoke);
        CalendarMonth.ForeColor = Color.Black;
        CalendarMonth.BackColor = Color.White;
        CodeProjectCalendar.NET.Calendar.CurrentDayForeColor = Color.White;
        CodeProjectCalendar.NET.Calendar.CurrentDayBackColor = Color.Black;
        CodeProjectCalendar.NET.Calendar.CurrentDayForeColor = Color.White;
        CodeProjectCalendar.NET.Calendar.CurrentDayBackColor = Color.Red;
        CodeProjectCalendar.NET.Calendar.ColorText = Color.Black;
        CodeProjectCalendar.NET.Calendar.PenText = Pens.Black;
        CodeProjectCalendar.NET.Calendar.PenTextReduced = Pens.DarkGray;
        CodeProjectCalendar.NET.Calendar.BrushText = Brushes.Black;
        CodeProjectCalendar.NET.Calendar.BrushBlack = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
        CodeProjectCalendar.NET.Calendar.BrushGrayMedium = new SolidBrush(Color.FromArgb(170, 170, 170));
        CodeProjectCalendar.NET.Calendar.BrushGrayLight = new SolidBrush(Color.FromArgb(234, 234, 234));
        CodeProjectCalendar.NET.Calendar.PenBrushBlack = new Pen(CodeProjectCalendar.NET.Calendar.BrushBlack)
        {
          DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };
      }
      string fontname = "Calibri";
      CalendarMonth.DateHeaderFont = new Font(fontname, sizeFont + 5, FontStyle.Bold);
      CalendarMonth.DayOfWeekFont = new Font(fontname, sizeFont + 1);
      CalendarMonth.DayViewTimeFont = new Font(fontname, sizeFont + 1, FontStyle.Bold);
      CalendarMonth.DaysFont = new Font(fontname, sizeFont + 2);
      CalendarMonth.TodayFont = new Font("Microsoft Sans Serif", sizeFont + 2, FontStyle.Bold);
    }

  }

}
