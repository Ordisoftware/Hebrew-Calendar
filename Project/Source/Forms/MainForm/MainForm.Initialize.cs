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
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.Xml;
using Microsoft.Win32;

using CalenderNet = CodeProjectCalendar.NET.Calendar;
using Modifiers = Base.Hotkeys.Modifiers;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  public const bool HotKeyEnabledByDefault = true;
  public const Modifiers DefaultHotKeyModifiers = Modifiers.Shift | Modifiers.Control | Modifiers.Alt;
  public const Keys DefaultHotKeyKey = Keys.C;

  /// <summary>
  /// Does constructor
  /// </summary>
  private void DoConstructor()
  {
    Interlocks.Take();
    new Task(InitializeIconsAndSound).Start();
    new Task(InitializeDialogsDirectory).Start();
    new Task(SelectCityForm.Preload).Start();
    SystemManager.TryCatch(() => Icon = new Icon(Globals.ApplicationIconFilePath));
    Text = Globals.AssemblyTitle;
    ContextMenuStripDay.ImageList = ImageListRisesAndSets;
    ContextMenuDaySunrise.ImageIndex = 1;
    ContextMenuDaySunset.ImageIndex = 1;
    ToolStrip.Renderer = new CheckedButtonsToolStripRenderer();
    SystemEvents.SessionEnding += SessionEnding;
    SystemEvents.PowerModeChanged += PowerModeChanged;
    MenuTray.Enabled = false;
    Globals.AllowClose = false;
    foreach ( var value in Enums.GetValues<TorahCelebrationDay>() )
      LastCelebrationReminded.Add(value, null);
    if ( !Globals.IsDevExecutable ) // TODO remove when lunar months ready
    {
      ActionViewLunarMonths.Enabled = false;
      ActionViewLunarMonths.Visible = false;
      ActionViewLunarMonths.Tag = int.MinValue;
    }
  }

  /// <summary>
  /// Does Form Load event.
  /// </summary>
  private void DoFormLoad(object sender, EventArgs e)
  {
    if ( Globals.IsExiting ) return;
    Settings.Retrieve();
    Program.UpdateLocalization();
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
      LoadMenuBookmarks(this);
    }
    catch
    {
      Cursor = Cursors.Default;
      throw;
    }
    DebugManager.TraceEnabledChanged += value => CommonMenusControl.Instance.ActionViewLog.Enabled = value;
  }

  /// <summary>
  /// Does Form Shown event.
  /// </summary>
  private void DoFormShown(object sender, EventArgs e)
  {
    if ( Globals.IsExiting ) return;
    try
    {
      Cursor = Cursors.WaitCursor;
      this.InitDropDowns();
      UpdateTextCalendar();
      CalendarMonth.CalendarDateChanged += date => GoToDate(date.Date);
      MenuShowHide.Text = SysTranslations.HideRestoreCaption.GetLang(Visible);
      Globals.NoticeKeyboardShortcutsForm = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                             AppTranslations.NoticeKeyboardShortcuts,
                                                             true, false, 430, 500, false, false);
      Globals.NoticeKeyboardShortcutsForm.TextBox.BackColor = Globals.NoticeKeyboardShortcutsForm.BackColor;
      Globals.NoticeKeyboardShortcutsForm.TextBox.BorderStyle = BorderStyle.None;
      Globals.NoticeKeyboardShortcutsForm.Padding = new Padding(20, 20, 20, 20);
      SetGlobalHotKey();
      Globals.IsReady = true;
      GoToDate(DateTime.Today);
      UpdateButtons();
      Globals.ChronoStartingApp.Stop();
      Settings.BenchmarkStartingApp = Globals.ChronoStartingApp.ElapsedMilliseconds;
      bool doforce = ApplicationCommandLine.Instance?.Generate ?? false;
      CheckRegenerateCalendar(false, doforce || Globals.IsDatabaseUpgraded, true);
      if ( Settings.GPSLatitude.IsNullOrEmpty() || Settings.GPSLongitude.IsNullOrEmpty() )
        ActionPreferences.PerformClick();
      SystemManager.TryCatch(Settings.Store);
      TimerBallon.Interval = Settings.BalloonLoomingDelay;
      TimerMidnight.TimeReached += TimerMidnight_Tick;
    }
    finally
    {
      Cursor = Cursors.Default;
    }
    TimerUpdateTitles.Start();
    TimerMidnight.Start();
    TimerReminder_Tick(null, null);
    this.ForceBringToFront();
    if ( Settings.StartupHide || Globals.ForceStartupHide )
      MenuShowHide.PerformClick();
    SystemManager.TryCatch(() =>
    {
      if ( LockSessionForm.Instance?.Visible ?? false )
        LockSessionForm.Instance.Popup();
    });
    SystemManager.TryCatchManage(ProcessNewsAndCommandLine);
    IsCalendarReady = false;
  }

  private bool IsCalendarReady = true;

  /// <summary>
  /// Shows news and process command line options.
  /// </summary>
  private void ProcessNewsAndCommandLine()
  {
    if ( Globals.IsSettingsUpgraded && Settings.ShowLastNewInVersionAfterUpdate )
    {
      SystemManager.TryCatch(CommonMenusControl.Instance.ShowLastNews);
      Application.DoEvents();
      Thread.Sleep(500);
    }
    if ( ApplicationCommandLine.Instance.Generate )
      ActionGenerate.PerformClick();
    if ( ApplicationCommandLine.Instance.ResetReminder )
      ActionResetReminder.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenNavigation )
      ActionNavigate.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenDiffDates )
      ActionCalculateDateDiff.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenCelebrationVersesBoard )
      ActionShowCelebrationVersesBoard.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenCelebrationsBoard )
      ActionViewCelebrationsBoard.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenNewMoonsBoard )
      ActionViewNewMoonsBoard.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenParashotBoard )
      ActionViewParashot.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenWeeklyParashahBox )
      ActionViewParashahDescription.PerformClick();
    if ( Globals.IsDebugExecutable ) // TODO remove when lunar months ready
      if ( ApplicationCommandLine.Instance.OpenLunarMonthsBoard )
        ActionViewLunarMonths.PerformClick();
  }

  /// <summary>
  /// Sets global HotKey combination.
  /// </summary>
  public void SetGlobalHotKey(bool noactive = false)
  {
    var shortcutKey = DefaultHotKeyKey;
    var shortcutModifiers = DefaultHotKeyModifiers;
    SystemManager.TryCatch(() => shortcutKey = (Keys)Settings.GlobalHotKeyPopupMainFormKey);
    SystemManager.TryCatch(() => shortcutModifiers = (Modifiers)Settings.GlobalHotKeyPopupMainFormModifiers);
    Globals.BringToFrontApplicationHotKey.Key = shortcutKey;
    Globals.BringToFrontApplicationHotKey.Modifiers = shortcutModifiers;
    Globals.BringToFrontApplicationHotKey.KeyPressed = BrintToFrontApplicationHotKeyPressed;
    SystemManager.TryCatch(() =>
    {
      if ( !noactive ) Globals.BringToFrontApplicationHotKey.Active = Settings.GlobalHotKeyPopupMainFormEnabled;
    });
  }

  /// <summary>
  /// Executes Global HotKey.
  /// </summary>
  private void BrintToFrontApplicationHotKeyPressed()
  {
    this.SyncUI(() =>
    {
      MenuShowHide_Click(null, null);
      CalendarMonth.Refresh();
      var forms = Application.OpenForms.GetAll().Where(f => f.Visible);
      forms.ToList().ForEach(f => f.ForceBringToFront());
      var form = forms.LastOrDefault();
      if ( form?.Visible == true )
        form.Popup();
    });
  }

  /// <summary>
  /// Does Form Closing event.
  /// </summary>
  private void DoFormClosing(object sender, FormClosingEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( Globals.IsExiting ) return;
    if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing )
      Globals.IsExiting = true;
    else
    if ( !Globals.AllowClose )
    {
      e.Cancel = true;
      MenuShowHide.PerformClick();
    }
  }

  /// <summary>
  /// Does Form Closed event.
  /// </summary>
  private void DoFormClosed(object sender, FormClosedEventArgs e)
  {
    DebugManager.Trace(LogTraceEvent.Data, e.CloseReason.ToStringFull());
    Globals.IsExiting = true;
    Globals.IsSessionEnding = true;
    Globals.AllowClose = true;
    SystemManager.TryCatch(Settings.Store);
    Interlocks.Release();
    TimerTooltip.Stop();
    TimerBallon.Stop();
    TimerTrayMouseMove.Stop();
    TimerMidnight.Stop();
    TimerReminder.Stop();
    TimerResumeReminder.Stop();
    LockSessionForm.Instance?.Timer.Stop();
    SystemManager.TryCatch(ClearLists);
    FormsHelper.CloseAll();
  }

  /// <summary>
  /// Power mode changed event handler.
  /// </summary>
  private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
  {
    if ( e.Mode == PowerModes.Resume )
    {
      Thread.Sleep(10000);
      DoTimerMidnight();
    }
  }

  /// <summary>
  /// Does Session Ending event.
  /// </summary>
  public void SessionEnding(object sender, SessionEndingEventArgs e)
  {
    if ( Globals.IsExiting || Globals.IsSessionEnding ) return;
    DebugManager.Enter();
    try
    {
      DebugManager.Trace(LogTraceEvent.Data, e?.Reason.ToStringFull() ?? nameof(NativeMethods.WM_QUERYENDSESSION));
      Close();
    }
    finally
    {
      DebugManager.Leave();
    }
  }

  /// <summary>
  /// WndProc override.
  /// </summary>
  protected override void WndProc(ref Message m)
  {
    switch ( m.Msg )
    {
      case NativeMethods.WM_QUERYENDSESSION:
        SessionEnding(this, null);
        break;
      default:
        base.WndProc(ref m);
        break;
    }
  }

  /// <summary>
  /// Initializes current time zone.
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
  /// Sets the initial directories of dialog boxes.
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
  /// Initializes icons
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
    SystemManager.TryCatch(() => new SoundPlayer(Globals.EmptySoundFilePath).Play());
    SystemManager.TryCatch(() => MediaMixer.SetApplicationVolume(Globals.ProcessId, Settings.ApplicationVolume));
  }

  /// <summary>
  /// Sets reminder boxes location.
  /// </summary>
  public void InitializeReminderBoxDesktopLocation()
  {
    if ( Settings.ReminderBoxDesktopLocation == ControlLocation.Fixed )
    {
      var anchor = DisplayManager.GetTaskbarAnchorStyle();
      Settings.ReminderBoxDesktopLocation = anchor switch
      {
        AnchorStyles.Top => ControlLocation.TopRight,
        AnchorStyles.Left => ControlLocation.BottomLeft,
        _ => ControlLocation.BottomRight,
      };
    }
  }

  /// <summary>
  /// Initializes the calendar month view aspect.
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
      CalenderNet.PenHoverEffect = new Pen(Settings.CalendarColorHoverEffect);
      CalenderNet.PenActiveDay = new Pen(Settings.CalendarColorActiveDay);
      CalenderNet.CurrentDayForeBrush = new SolidBrush(Settings.CurrentDayForeColor);
      CalenderNet.CurrentDayBackBrush = new SolidBrush(Settings.CurrentDayBackColor);
      CalenderNet.PenSelectedDay = new Pen(Settings.SelectedDayBoxColor);
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
      CalenderNet.PenBlack = new Pen(CalenderNet.BrushBlack);
    }
    else
    {
      PanelCalendar.BackColor = SystemColors.Window;
      CalendarMonth.RogueBrush = Brushes.WhiteSmoke;
      CalendarMonth.ForeColor = Color.Black;
      CalendarMonth.BackColor = Color.White;
      CalenderNet.PenHoverEffect = Pens.Silver;
      CalenderNet.PenActiveDay = Pens.LightGray;
      CalenderNet.CurrentDayForeBrush = Brushes.White;
      CalenderNet.CurrentDayBackBrush = Brushes.Black;
      CalenderNet.ColorText = Color.Black;
      CalenderNet.PenText = Pens.Black;
      CalenderNet.PenTextReduced = Pens.LightGray;
      CalenderNet.BrushText = Brushes.Black;
      CalenderNet.BrushBlack = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
      CalenderNet.BrushGrayMedium = new SolidBrush(Color.FromArgb(170, 170, 170));
      CalenderNet.BrushGrayLight = new SolidBrush(Color.FromArgb(234, 234, 234));
      CalenderNet.PenBlack = Pens.Black;
    }
    const string fontname = "Calibri";
    CalendarMonth.DateHeaderFont = new Font(fontname, sizeFont + 5, FontStyle.Bold);
    CalendarMonth.DayOfWeekFont = new Font(fontname, sizeFont + 1);
    CalendarMonth.DayViewTimeFont = new Font(fontname, sizeFont + 1, FontStyle.Bold);
    CalendarMonth.DaysFont = new Font(fontname, sizeFont + 2);
    CalendarMonth.TodayFont = new Font("Microsoft Sans Serif", sizeFont + 2, FontStyle.Bold);
  }

}
