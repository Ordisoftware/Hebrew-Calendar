/// <license>
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
/// <edited> 2021-02 </edited>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using Ordisoftware.Core;
using Modifiers = Base.Hotkeys.Modifiers;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm
  {

    public const bool HotKeyEnabledByDefault = true;
    public const Modifiers DefaultHotKeyModifiers = Modifiers.Shift | Modifiers.Control | Modifiers.Alt;
    public const Keys DefaultHotKeyKey = Keys.C;

    internal void ReminderBoxDesktopLocation()
    {
      if ( Settings.ReminderBoxDesktopLocation == ControlLocation.Fixed )
      {
        var anchor = DisplayManager.GetTaskbarAnchorStyle();
        switch ( anchor )
        {
          case AnchorStyles.Top:
            Settings.ReminderBoxDesktopLocation = ControlLocation.TopRight;
            break;
          case AnchorStyles.Left:
            Settings.ReminderBoxDesktopLocation = ControlLocation.BottomLeft;
            break;
          case AnchorStyles.Bottom:
          case AnchorStyles.Right:
          default:
            Settings.ReminderBoxDesktopLocation = ControlLocation.BottomRight;
            break;
        }
      }
    }

    /// <summary>
    /// Do Form Load event.
    /// </summary>
    private void DoMainForm_Load(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      Settings.Retrieve();
      ProcessLocksTable.Lock();
      ReminderBoxDesktopLocation();
      SystemManager.TryCatch(() => new System.Media.SoundPlayer(Globals.EmptySoundFilePath).Play());
      SystemManager.TryCatch(() => MediaMixer.SetApplicationVolume(Process.GetCurrentProcess().Id,
                                                                   Settings.ApplicationVolume));
      StatisticsForm.Run(true, Settings.UsageStatisticsEnabled);
      if ( !Settings.GPSLatitude.IsNullOrEmpty() && !Settings.GPSLongitude.IsNullOrEmpty() )
        SystemManager.TryCatchManage(() =>
        {
          Instance.CurrentGPSLatitude = (float)XmlConvert.ToDouble(Settings.GPSLatitude);
          Instance.CurrentGPSLongitude = (float)XmlConvert.ToDouble(Settings.GPSLongitude);
        });
      ChronoStart.Stop();
      var lastdone = Settings.CheckUpdateLastDone;
      bool exit = WebCheckUpdate.Run(Settings.CheckUpdateAtStartup,
                                     ref lastdone,
                                     Settings.CheckUpdateAtStartupDaysInterval,
                                     true);
      Settings.CheckUpdateLastDone = lastdone;
      if ( exit )
      {
        SystemManager.Exit();
        return;
      }
      ChronoStart.Start();
      CalendarText.ForeColor = Settings.TextColor;
      CalendarText.BackColor = Settings.TextBackground;
      InitializeCalendarUI();
      InitializeCurrentTimeZone();
      InitializeDialogsDirectory();
      DebugManager.TraceEnabledChanged += value => SystemInformationMenu.ActionViewLog.Enabled = value;
      Refresh();
      ClearLists();
      LoadData();
    }

    /// <summary>
    /// Do Form Shown event.
    /// </summary>
    private void DoMainForm_Shown(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      DebugManager.Enter();
      try
      {
        EditEnumsAsTranslations.Left = LunisolarDaysBindingNavigator.Width - EditEnumsAsTranslations.Width - 3;
        UpdateTextCalendar();
        CalendarMonth.CalendarDateChanged += date => GoToDate(date.Date);
        MenuShowHide.Text = SysTranslations.HideRestoreCaption.GetLang(Visible);
        Globals.IsReady = true;
        UpdateButtons();
        GoToDate(DateTime.Today);
        bool doforce = ApplicationCommandLine.Instance?.Generate ?? false;
        if ( DbUpgradedForParashotSupport ) doforce = true;
        CheckRegenerateCalendar(force: doforce);
        if ( Settings.GPSLatitude.IsNullOrEmpty() || Settings.GPSLongitude.IsNullOrEmpty() )
          ActionPreferences.PerformClick();
        SystemManager.TryCatch(Settings.Save);
        ChronoStart.Stop();
        Settings.BenchmarkStartingApp = ChronoStart.ElapsedMilliseconds;
        TimerBallon.Interval = Settings.BalloonLoomingDelay;
        TimerMidnight.TimeReached += TimerMidnight_Tick;
        TimerMidnight.Start();
        TimerReminder_Tick(null, null);
        this.Popup();
        if ( Settings.StartupHide || Globals.ForceStartupHide )
          MenuShowHide.PerformClick();
        SystemManager.TryCatch(() =>
        {
          if ( LockSessionForm.Instance?.Visible ?? false )
            LockSessionForm.Instance.Popup();
        });
        NoticeKeyboardShortcutsForm = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                       AppTranslations.NoticeKeyboardShortcuts,
                                                       true, false, 475, 745, false, false);
        NoticeKeyboardShortcutsForm.TextBox.BackColor = NoticeKeyboardShortcutsForm.BackColor;
        NoticeKeyboardShortcutsForm.TextBox.BorderStyle = BorderStyle.None;
        NoticeKeyboardShortcutsForm.Padding = new Padding(20, 20, 20, 20);
        SetGlobalHotKey();
        UpdateTitles();
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    /// <summary>
    /// Set global HotKey combination.
    /// </summary>
    internal void SetGlobalHotKey(bool noactive = false)
    {
      var shortcutKey = DefaultHotKeyKey;
      var shortcutModifiers = DefaultHotKeyModifiers;
      SystemManager.TryCatch(() => { shortcutKey = (Keys)Settings.GlobalHotKeyPopupMainFormKey; });
      SystemManager.TryCatch(() => { shortcutModifiers = (Modifiers)Settings.GlobalHotKeyPopupMainFormModifiers; });
      Globals.BringToFrontApplicationHotKey.Key = shortcutKey;
      Globals.BringToFrontApplicationHotKey.Modifiers = shortcutModifiers;
      Globals.BringToFrontApplicationHotKey.KeyPressed = BrintToFrontApplicationHotKey_KeyPressed;
      if ( !noactive )
        SystemManager.TryCatch(() => { Globals.BringToFrontApplicationHotKey.Active = Settings.GlobalHotKeyPopupMainFormEnabled; });
    }

    /// <summary>
    /// Execute Global HotKey.
    /// </summary>
    private void BrintToFrontApplicationHotKey_KeyPressed()
    {
      this.SyncUI(() =>
      {
        MenuShowHide_Click(null, null);
        var forms = Application.OpenForms.ToList().Where(f => f.Visible);
        forms.ToList().ForEach(f => f.ForceBringToFront());
        var form = forms.LastOrDefault();
        if ( form != null && form.Visible )
          form.Popup();
      });
    }

    /// <summary>
    /// Do Session Ending event.
    /// </summary>
    internal void DoSessionEnding(object sender, SessionEndingEventArgs e)
    {
      if ( Globals.IsSessionEnding ) return;
      DebugManager.Enter();
      DebugManager.Trace(LogTraceEvent.Data, e.Reason.ToStringFull());
      try
      {
        Globals.IsExiting = true;
        Globals.IsSessionEnding = true;
        Globals.AllowClose = true;
        LockSessionForm.Instance.Timer.Stop();
        TimerTooltip.Stop();
        TimerBallon.Stop();
        TimerTrayMouseMove.Stop();
        TimerResumeReminder.Stop();
        TimerMidnight.Stop();
        TimerReminder.Stop();
        MessageBoxEx.CloseAll();
        SystemManager.TryCatch(() => ClearLists());
        SystemManager.TryCatch(() =>
        {
          foreach ( Form form in Application.OpenForms )
            if ( form != this && form.Visible )
              SystemManager.TryCatch(() => form.Close());
        });
        Close();
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    /// <summary>
    /// Set the initial directories of dialog boxes.
    /// </summary>
    internal void InitializeDialogsDirectory()
    {
      string directory = Settings.GetExportDirectory();
      SaveTextDialog.InitialDirectory = directory;
      SaveImageDialog.InitialDirectory = directory;
      SaveDataGridDialog.InitialDirectory = directory;
      SaveDataBoardDialog.InitialDirectory = directory;
      FolderDialog.SelectedPath = directory;
      SaveDataGridDialog.Filter = Program.GridExportTargets.CreateFilters();
      SaveDataBoardDialog.Filter = Program.BoardExportTargets.CreateFilters();
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
    /// Create system information menu items.
    /// </summary>
    internal void CreateSystemInformationMenu()
    {
      SystemInformationMenu = new CommonMenusControl(ActionAbout_Click,
                                                     ActionWebCheckUpdate_Click,
                                                     ActionViewLog_Click,
                                                     ActionViewStats_Click);
      var menu = SystemInformationMenu.MenuInformation;
      var list = new List<ToolStripItem>();
      foreach ( ToolStripItem item in menu.DropDownItems ) list.Add(item);
      menu.DropDownItems.Clear();
      ActionInformation.DropDownItems.Clear();
      ActionInformation.DropDownItems.AddRange(list.ToArray());
      SystemInformationMenu.InitializeVersionNewsMenuItems(AppTranslations.NoticeNewFeatures);
      InitializeSpecialMenus();
    }

    /// <summary>
    /// Initialize special menus (web links, tray icon and suspend).
    /// </summary>
    internal void InitializeSpecialMenus()
    {
      SystemInformationMenu.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
      SystemInformationMenu.ActionViewLog.Enabled = DebugManager.TraceEnabled;
      ActionWebLinks.Visible = Settings.WebLinksMenuEnabled;
      ActionLocalWeather.Visible = Settings.WeatherMenuItemsEnabled;
      ActionOnlineWeather.Visible = Settings.WeatherMenuItemsEnabled;
      SeparatorMenuWeather.Visible = Settings.WeatherMenuItemsEnabled;
      var isVisible = Settings.WeatherMenuItemsEnabled ? (int?)null : int.MinValue;
      ActionLocalWeather.Tag = isVisible;
      ActionOnlineWeather.Tag = isVisible;
      SeparatorMenuWeather.Tag = isVisible;
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
        CodeProjectCalendar.NET.Calendar.BrushGrayMedium
          = new SolidBrush(Color.FromArgb(CodeProjectCalendar.NET.Calendar.PenText.Color.R < 85 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.R * 2 / 3,
                                          CodeProjectCalendar.NET.Calendar.PenText.Color.R < 85 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.G * 2 / 3,
                                          CodeProjectCalendar.NET.Calendar.PenText.Color.R < 85 ? CodeProjectCalendar.NET.Calendar.PenText.Color.R + 255 * 2 / 3 : CodeProjectCalendar.NET.Calendar.PenText.Color.B * 2 / 3));
        CodeProjectCalendar.NET.Calendar.BrushGrayLight
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
