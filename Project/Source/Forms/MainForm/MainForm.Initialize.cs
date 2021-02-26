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
using CalenderNet = CodeProjectCalendar.NET.Calendar;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm
  {

    public const bool HotKeyEnabledByDefault = true;
    public const Modifiers DefaultHotKeyModifiers = Modifiers.Shift | Modifiers.Control | Modifiers.Alt;
    public const Keys DefaultHotKeyKey = Keys.C;

    public void ReminderBoxDesktopLocation()
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
      Globals.ChronoLoadApp.Stop();
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
      Globals.ChronoLoadApp.Start();
      CalendarText.ForeColor = Settings.TextColor;
      CalendarText.BackColor = Settings.TextBackground;
      InitializeCalendarUI();
      InitializeCurrentTimeZone();
      InitializeDialogsDirectory();
      DebugManager.TraceEnabledChanged += value => CommonMenusControl.Instance.ActionViewLog.Enabled = value;
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
        CheckRegenerateCalendar(force: doforce || Globals.DatabaseUpgraded);
        if ( Settings.GPSLatitude.IsNullOrEmpty() || Settings.GPSLongitude.IsNullOrEmpty() )
          ActionPreferences.PerformClick();
        SystemManager.TryCatch(Settings.Save);
        Globals.ChronoLoadApp.Stop();
        Settings.BenchmarkStartingApp = Globals.ChronoLoadApp.ElapsedMilliseconds;
        Globals.ChronoLoadApp.Start();
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
        Globals.NoticeKeyboardShortcutsForm = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                               AppTranslations.NoticeKeyboardShortcuts,
                                                               true, false, 475, 735, false, false);
        Globals.NoticeKeyboardShortcutsForm.TextBox.BackColor = Globals.NoticeKeyboardShortcutsForm.BackColor;
        Globals.NoticeKeyboardShortcutsForm.TextBox.BorderStyle = BorderStyle.None;
        Globals.NoticeKeyboardShortcutsForm.Padding = new Padding(20, 20, 10, 10);
        SetGlobalHotKey();
        TimerUpdateTitles.Start();
        TimerUpdateTitles_Tick(null, null);
        Globals.ChronoLoadApp.Stop();
        if ( Globals.SettingsUpgraded && Settings.ShowLastNewInVersionAfterUpdate )
          SystemManager.TryCatch(() =>
          {
            var menuRoot = CommonMenusControl.Instance.ActionViewVersionNews;
            var menuItem = menuRoot.DropDownItems.Cast<ToolStripItem>().LastOrDefault();
            if ( menuItem != null ) menuItem.PerformClick();
          });
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    /// <summary>
    /// Set global HotKey combination.
    /// </summary>
    public void SetGlobalHotKey(bool noactive = false)
    {
      var shortcutKey = DefaultHotKeyKey;
      var shortcutModifiers = DefaultHotKeyModifiers;
      SystemManager.TryCatch(() => { shortcutKey = (Keys)Settings.GlobalHotKeyPopupMainFormKey; });
      SystemManager.TryCatch(() => { shortcutModifiers = (Modifiers)Settings.GlobalHotKeyPopupMainFormModifiers; });
      Globals.BringToFrontApplicationHotKey.Key = shortcutKey;
      Globals.BringToFrontApplicationHotKey.Modifiers = shortcutModifiers;
      Globals.BringToFrontApplicationHotKey.KeyPressed = BrintToFrontApplicationHotKey_KeyPressed;
      SystemManager.TryCatch(() =>
      {
        if ( !noactive ) Globals.BringToFrontApplicationHotKey.Active = Settings.GlobalHotKeyPopupMainFormEnabled;
      });
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
    public void DoSessionEnding(object sender, SessionEndingEventArgs e)
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
    public void InitializeDialogsDirectory()
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
    public void InitializeCurrentTimeZone()
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
    public void CreateSystemInformationMenu()
    {
      CommonMenusControl.Instance = new CommonMenusControl(ActionAbout_Click,
                                                           ActionWebCheckUpdate_Click,
                                                           ActionViewLog_Click,
                                                           ActionViewStats_Click);
      var menu = CommonMenusControl.Instance.MenuInformation;
      var list = new List<ToolStripItem>();
      foreach ( ToolStripItem item in menu.DropDownItems ) list.Add(item);
      menu.DropDownItems.Clear();
      ActionInformation.DropDownItems.Clear();
      ActionInformation.DropDownItems.AddRange(list.ToArray());
      CommonMenusControl.Instance.InitializeVersionNewsMenuItems(AppTranslations.NoticeNewFeatures);
      InitializeSpecialMenus();
    }

    /// <summary>
    /// Initialize special menus (web links, tray icon and suspend).
    /// </summary>
    public void InitializeSpecialMenus()
    {
      CommonMenusControl.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
      CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
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
        CalenderNet.CurrentDayForeColor = Settings.CurrentDayForeColor;
        CalenderNet.CurrentDayBackColor = Settings.CurrentDayBackColor;
        CalenderNet.ColorText = Settings.MonthViewTextColor;
        CalenderNet.PenText = new Pen(Settings.MonthViewTextColor);
        CalenderNet.PenTextReduced
          = new Pen(Color.FromArgb(CalenderNet.PenText.Color.R < 125 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.R * 2 / 3,
                                   CalenderNet.PenText.Color.R < 125 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.G * 2 / 3,
                                   CalenderNet.PenText.Color.R < 125 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.B * 2 / 3));
        CalenderNet.BrushText = new SolidBrush(Settings.MonthViewTextColor);
        CalenderNet.BrushBlack = new SolidBrush(Settings.MonthViewTextColor);
        CalenderNet.BrushGrayMedium
          = new SolidBrush(Color.FromArgb(CalenderNet.PenText.Color.R < 85 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.R * 2 / 3,
                                          CalenderNet.PenText.Color.R < 85 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.G * 2 / 3,
                                          CalenderNet.PenText.Color.R < 85 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.B * 2 / 3));
        CalenderNet.BrushGrayLight
          = new SolidBrush(Color.FromArgb((int)( CalenderNet.PenText.Color.R < 20 ? CalenderNet.PenText.Color.R + 255 * 0.92 : CalenderNet.PenText.Color.R * 0.92 ),
                                          (int)( CalenderNet.PenText.Color.R < 20 ? CalenderNet.PenText.Color.R + 255 * 0.92 : CalenderNet.PenText.Color.G * 0.92 ),
                                          (int)( CalenderNet.PenText.Color.R < 20 ? CalenderNet.PenText.Color.R + 255 * 0.92 : CalenderNet.PenText.Color.B * 0.92 )));
        CalenderNet.PenBrushBlack = new Pen(CalenderNet.BrushBlack)
        {
          DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };
      }
      else
      {
        CalendarMonth.RogueBrush = new SolidBrush(Color.WhiteSmoke);
        CalendarMonth.ForeColor = Color.Black;
        CalendarMonth.BackColor = Color.White;
        CalenderNet.CurrentDayForeColor = Color.White;
        CalenderNet.CurrentDayBackColor = Color.Black;
        CalenderNet.CurrentDayForeColor = Color.White;
        CalenderNet.CurrentDayBackColor = Color.Red;
        CalenderNet.ColorText = Color.Black;
        CalenderNet.PenText = Pens.Black;
        CalenderNet.PenTextReduced = Pens.DarkGray;
        CalenderNet.BrushText = Brushes.Black;
        CalenderNet.BrushBlack = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
        CalenderNet.BrushGrayMedium = new SolidBrush(Color.FromArgb(170, 170, 170));
        CalenderNet.BrushGrayLight = new SolidBrush(Color.FromArgb(234, 234, 234));
        CalenderNet.PenBrushBlack = new Pen(CalenderNet.BrushBlack)
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
