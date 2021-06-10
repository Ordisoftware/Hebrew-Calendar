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
/// <edited> 2021-06 </edited>
using System;
using System.Linq;
using System.Xml;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using Ordisoftware.Core;
using EnumsNET;
using CalenderNet = CodeProjectCalendar.NET.Calendar;
using Modifiers = Base.Hotkeys.Modifiers;
using System.Threading.Tasks;

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

    /// <summary>
    /// Do constructor
    /// </summary>
    private void DoConstructor()
    {
      new Task(InitializeIconsAndSound).Start();
      Interlocks.Take();
      SystemManager.TryCatch(() => { Icon = new Icon(Globals.ApplicationIconFilePath); });
      Text = Globals.AssemblyTitle;
      ToolStrip.Renderer = new CheckedButtonsToolStripRenderer();
      SystemEvents.SessionEnding += SessionEnding;
      SystemEvents.PowerModeChanged += PowerModeChanged;
      MenuTray.Enabled = false;
      Globals.AllowClose = false;
      foreach ( var value in Enums.GetValues<TorahEvent>() )
        LastCelebrationReminded.Add(value, null);
      if ( !Globals.IsDevExecutable ) // TODO remove when ready
      {
        ActionViewLunarMonths.Visible = false;
        ActionViewLunarMonths.Tag = int.MinValue;
      }
    }

    /// <summary>
    /// Do Form Load event.
    /// </summary>
    private void DoFormLoad(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      Settings.Retrieve();
      LabelSubTitleGPS.Text = SysTranslations.Initializing.GetLang();
      StatisticsForm.Run(true, Settings.UsageStatisticsEnabled);
      Globals.ChronoStartingApp.Stop();
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
      Globals.ChronoStartingApp.Start();
      if ( !Settings.GPSLatitude.IsNullOrEmpty() && !Settings.GPSLongitude.IsNullOrEmpty() )
        SystemManager.TryCatchManage(() =>
        {
          Instance.CurrentGPSLatitude = (float)XmlConvert.ToDouble(Settings.GPSLatitude);
          Instance.CurrentGPSLongitude = (float)XmlConvert.ToDouble(Settings.GPSLongitude);
        });
      new Task(InitializeCurrentTimeZone).Start();
      new Task(InitializeDialogsDirectory).Start();
      Cursor = Cursors.WaitCursor;
      try
      {
        CalendarText.ForeColor = Settings.TextColor;
        CalendarText.BackColor = Settings.TextBackground;
        InitializeCalendarUI();
        InitializeReminderBoxDesktopLocation();
        Refresh();
        ClearLists();
        LoadData();
      }
      catch
      {
        Cursor = Cursors.Default;
        throw;
      }
      DebugManager.TraceEnabledChanged += value => CommonMenusControl.Instance.ActionViewLog.Enabled = value;
    }

    /// <summary>
    /// Do Form Shown event.
    /// </summary>
    private void DoFormShown(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      try
      {
        Cursor = Cursors.WaitCursor;
        ToolStrip.SetDropDownOpening();
        UpdateTextCalendar();
        CalendarMonth.CalendarDateChanged += date => GoToDate(date.Date);
        MenuShowHide.Text = SysTranslations.HideRestoreCaption.GetLang(Visible);
        Globals.NoticeKeyboardShortcutsForm = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                               AppTranslations.NoticeKeyboardShortcuts,
                                                               true, false, 410, 745, false, false);
        Globals.NoticeKeyboardShortcutsForm.TextBox.BackColor = Globals.NoticeKeyboardShortcutsForm.BackColor;
        Globals.NoticeKeyboardShortcutsForm.TextBox.BorderStyle = BorderStyle.None;
        Globals.NoticeKeyboardShortcutsForm.Padding = new Padding(20, 20, 10, 10);
        Globals.IsReady = true;
        SetGlobalHotKey();
        TimerUpdateTitles.Start();
        TimerUpdateTitles_Tick(null, null);
        UpdateButtons();
        GoToDate(DateTime.Today);
        Globals.ChronoStartingApp.Stop();
        Settings.BenchmarkStartingApp = Globals.ChronoStartingApp.ElapsedMilliseconds;
        bool doforce = ApplicationCommandLine.Instance?.Generate ?? false;
        CheckRegenerateCalendar(false, doforce || Globals.IsDatabaseUpgraded, true);
        if ( Settings.GPSLatitude.IsNullOrEmpty() || Settings.GPSLongitude.IsNullOrEmpty() )
          ActionPreferences.PerformClick();
        SystemManager.TryCatch(Settings.Save);
        TimerBallon.Interval = Settings.BalloonLoomingDelay;
        TimerMidnight.TimeReached += TimerMidnight_Tick;
      }
      finally
      {
        Cursor = Cursors.Default;
      }
      TimerMidnight.Start();
      TimerReminder_Tick(null, null);
      this.ForceBringToFront();// Popup();
      if ( Settings.StartupHide || Globals.ForceStartupHide )
        MenuShowHide.PerformClick();
      SystemManager.TryCatch(() =>
      {
        if ( LockSessionForm.Instance?.Visible ?? false )
          LockSessionForm.Instance.Popup();
      });
      ProcessNewsAndCommandLine();
    }

    /// <summary>
    /// Show news and process command line options.
    /// </summary>
    private void ProcessNewsAndCommandLine()
    {
      if ( Globals.IsSettingsUpgraded && Settings.ShowLastNewInVersionAfterUpdate )
        if ( Globals.IsSettingsUpgraded && Settings.ShowLastNewInVersionAfterUpdate )
          SystemManager.TryCatch(CommonMenusControl.Instance.ShowLastNews);
      if ( ApplicationCommandLine.Instance.Generate )
        ActionGenerate.PerformClick();
      if ( ApplicationCommandLine.Instance.ResetReminder )
        ActionResetReminder.PerformClick();
      if ( ApplicationCommandLine.Instance.OpenNavigation )
        ActionNavigate.PerformClick();
      if ( ApplicationCommandLine.Instance.OpenDiffDates )
        ActionCalculateDateDiff.PerformClick();
      if ( ApplicationCommandLine.Instance.OpenCelebrationsBoard )
        ActionViewCelebrationsBoard.PerformClick();
      if ( ApplicationCommandLine.Instance.OpenNewMoonsBoard )
        ActionViewNewMoonsBoard.PerformClick();
      if ( ApplicationCommandLine.Instance.OpenParashotBoard )
        ActionViewParashot.PerformClick();
      if ( Globals.IsDebugExecutable ) // TODO remove when ready
        if ( ApplicationCommandLine.Instance.OpenLunarMonthsBoard )
          ActionViewLunarMonths.PerformClick();
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
      Globals.BringToFrontApplicationHotKey.KeyPressed = BrintToFrontApplicationHotKeyPressed;
      SystemManager.TryCatch(() =>
      {
        if ( !noactive ) Globals.BringToFrontApplicationHotKey.Active = Settings.GlobalHotKeyPopupMainFormEnabled;
      });
    }

    /// <summary>
    /// Execute Global HotKey.
    /// </summary>
    private void BrintToFrontApplicationHotKeyPressed()
    {
      this.SyncUI(() =>
      {
        MenuShowHide_Click(null, null);
        var forms = Application.OpenForms.All().Where(f => f.Visible);
        forms.ToList().ForEach(f => f.ForceBringToFront());
        var form = forms.LastOrDefault();
        if ( form != null && form.Visible )
          form.Popup();
      });
    }

    /// <summary>
    ///  Do Form Closing event.
    /// </summary>
    private void DoFormClosing(object sender, FormClosingEventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( Globals.IsExiting ) return;
      if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing )
      {
        Globals.IsExiting = true;
      }
      else
      if ( !Globals.AllowClose )
      {
        e.Cancel = true;
        MenuShowHide.PerformClick();
      }
    }

    /// <summary>
    /// Do Form Closed event.
    /// </summary>
    private void DoFormClosed(object sender, FormClosedEventArgs e)
    {
      DebugManager.Enter();
      DebugManager.Trace(LogTraceEvent.Data, e.CloseReason.ToStringFull());
      try
      {
        Globals.IsExiting = true;
        Globals.IsSessionEnding = true;
        Globals.AllowClose = true;
        Interlocks.Release();
        Settings.Store();
        TimerTooltip.Stop();
        TimerBallon.Stop();
        TimerTrayMouseMove.Stop();
        TimerMidnight.Stop();
        TimerReminder.Stop();
        TimerResumeReminder.Stop();
        LockSessionForm.Instance?.Timer.Stop();
        SystemManager.TryCatch(() => ClearLists());
        FormsHelper.CloseAll();
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    private static int WM_QUERYENDSESSION = 0x11;
    protected override void WndProc(ref Message m)
    {
      if ( m.Msg == WM_QUERYENDSESSION )
        SessionEnding(this, null);
      base.WndProc(ref m);
    }

    /// <summary>
    /// Do Session Ending event.
    /// </summary>
    public void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      if ( Globals.IsExiting || Globals.IsSessionEnding ) return;
      DebugManager.Trace(LogTraceEvent.Data, e?.Reason.ToStringFull() ?? nameof(WM_QUERYENDSESSION));
      Close();
    }

    /// <summary>
    /// Power mode changed event handler.
    /// </summary>
    private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
      if ( e.Mode == PowerModes.Resume )
      {
        System.Threading.Thread.Sleep(5000);
        DoTimerMidnight();
      }
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
    /// Initialize icons
    /// </summary>
    private void InitializeIconsAndSound()
    {
      SystemManager.TryCatch(() =>
      {
        TrayIcons[false][true] = new Icon(Program.ApplicationPauseEventIconFilePath).GetBySize(16, 16);
        TrayIcons[false][false] = new Icon(Program.ApplicationPauseIconFilePath).GetBySize(16, 16);
        TrayIcons[true][true] = new Icon(Program.ApplicationEventIconFilePath).GetBySize(16, 16);
        TrayIcons[true][false] = new Icon(Globals.ApplicationIconFilePath).GetBySize(16, 16);
      });
      SoundItem.Initialize();
      SystemManager.TryCatch(() => new System.Media.SoundPlayer(Globals.EmptySoundFilePath).Play());
      SystemManager.TryCatch(() => MediaMixer.SetApplicationVolume(Globals.ProcessId, Settings.ApplicationVolume));
    }

    /// <summary>
    /// Create system information menu items.
    /// </summary>
    public void CreateSystemInformationMenu()
    {
      CommonMenusControl.CreateInstance(ToolStrip,
                                        ref ActionInformation,
                                        AppTranslations.NoticeNewFeatures,
                                        ActionAbout_Click,
                                        ActionWebCheckUpdate_Click,
                                        ActionViewLog_Click,
                                        ActionViewStats_Click);
      InitializeSpecialMenus();
    }

    /// <summary>
    /// Initialize special menus (web links, tray icon and suspend).
    /// </summary>
    public void InitializeSpecialMenus()
    {
      ActionStudyOnline.InitializeFromProviders(HebrewGlobals.WebProvidersParashah, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var parashah = ApplicationDatabase.Instance.GetWeeklyParashah();
        HebrewTools.OpenParashahProvider((string)menuitem.Tag, parashah, true);
      });
      ActionOpenVerseOnline.InitializeFromProviders(HebrewGlobals.WebProvidersBible, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var parashah = ApplicationDatabase.Instance.GetWeeklyParashah();
        string verse = $"{(int)parashah.Book + 1}.{parashah.VerseBegin}";
        HebrewTools.OpenBibleProvider((string)menuitem.Tag, verse);
      });
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
      MenuDisableReminder.Enabled = Settings.AllowSuspendReminder;
    }

    /// <summary>
    /// Set reminder boxes location.
    /// </summary>
    public void InitializeReminderBoxDesktopLocation()
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
          default:
            Settings.ReminderBoxDesktopLocation = ControlLocation.BottomRight;
            break;
        }
      }
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
        PanelCalendar.BackColor = Settings.MonthViewNoDaysBackColor;
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
        PanelCalendar.BackColor = SystemColors.Window;
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
