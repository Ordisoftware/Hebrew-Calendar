/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
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
/// <edited> 2023-09 </edited>
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
  [SuppressMessage("Refactoring", "GCop622:Reverse your IF condition and return. Then move the nested statements to after the IF.", Justification = "Opinion")]
  private void DoConstructor()
  {
    Interlocks.Take();
    InitializeViewConnectors();
    new Task(InitializeIconsAndSound).Start();
    new Task(InitializeDialogsDirectory).Start();
    new Task(SelectCityForm.LoadGPS).Start();
    SystemManager.TryCatch(() => Icon = new Icon(Globals.ApplicationIconFilePath));
    Text = Globals.AssemblyTitle;
    ContextMenuStripDay.ImageList = ImageListRisesAndSets;
    ContextMenuDaySunrise.ImageIndex = 0;
    ContextMenuDaySunset.ImageIndex = 1;
    ToolStrip.Renderer = new CheckedButtonsToolStripRenderer();
    SystemEvents.SessionEnding += SessionEnding;
    SystemEvents.PowerModeChanged += PowerModeChanged;
    MenuTray.Enabled = false;
    Globals.AllowClose = false;
    MessageBoxEx.ForceTopMostExcludedForms.Add(typeof(ReminderForm));
    foreach ( var value in Enums.GetValues<TorahCelebrationDay>() )
      LastCelebrationReminded.Add(value, null);
    if ( !SystemManager.CommandLineOptions.IsPreviewEnabled ) // TODO when ready : remove
    {
      ActionShowLunarMonths.Enabled = false;
      ActionShowLunarMonths.Visible = false;
      ActionShowLunarMonths.Tag = int.MinValue;
    }
  }

  /// <summary>
  /// Does Form Load event.
  /// </summary>
  private void DoFormLoad(object sender, EventArgs e)
  {
    if ( Globals.IsExiting ) return;
    Settings.Retrieve();
    DisplayManager.DoubleBufferingEnabled = Settings.WindowsDoubleBufferingEnabled;
    Program.UpdateLocalization();
    StatisticsForm.Run(true, Settings.UsageStatisticsEnabled);
    Globals.ChronoStartingApp.Stop();
    var lastdone = Settings.CheckUpdateLastDone;
    bool exit = WebCheckUpdate.Run(ref lastdone,
                                   Settings.CheckUpdateAtStartupDaysInterval,
                                   true,
                                   Settings.CheckUpdateAtStartup);
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
      TextReport.ForeColor = Settings.TextColor;
      TextReport.BackColor = Settings.TextBackground;
      InitializeCalendarUI();
      Refresh();
      ClearLists();
      LoadData();
      LoadMenuBookmarks(this);
      Settings.InitializeReminderBoxDesktopLocation();
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
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  private void DoFormShown(object sender, EventArgs e)
  {
    if ( Globals.IsExiting ) return;
    try
    {
      Cursor = Cursors.WaitCursor;
      this.InitDropDowns();
      UpdateTextCalendar();
      MonthlyCalendar.CalendarDateChanged += date => GoToDate(date.Date);
      MenuShowHide.Text = SysTranslations.HideRestoreCaption.GetLang(Visible);
      Globals.KeyboardShortcutsNotice = new ShowTextForm(AppTranslations.NoticeKeyboardShortcutsTitle,
                                                             AppTranslations.NoticeKeyboardShortcuts,
                                                             true, false,
                                                             MessageBoxEx.DefaultWidthSmallMedium,
                                                             MessageBoxEx.DefaultHeightVeryHuge,
                                                             false, false);
      Globals.KeyboardShortcutsNotice.TextBox.BackColor = Globals.KeyboardShortcutsNotice.BackColor;
      Globals.KeyboardShortcutsNotice.TextBox.BorderStyle = BorderStyle.None;
      Globals.KeyboardShortcutsNotice.Padding = new Padding(20, 20, 10, 10);
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
      TimerBalloon.Interval = Settings.BalloonLoomingDelay;
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
    foreach ( var label in PanelTitleInner.Controls.OfType<Label>() )
      label.Visible = true;
    Settings.SetFirstAndUpgradeFlagsOff();
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
    if ( ApplicationCommandLine.Instance is null ) return;
    if ( ApplicationCommandLine.Instance.AppStats )
      CommonMenusControl.Instance.ActionViewStats.PerformClick();
    if ( ApplicationCommandLine.Instance.Generate )
      ActionGenerate.PerformClick();
    if ( ApplicationCommandLine.Instance.ResetReminder )
      ActionResetReminder.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenNavigation )
      ActionNavigate.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenDatesDifference )
      ActionCalculateDateDiff.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenCelebrationVersesBoard )
      ActionShowCelebrationVersesBoard.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenCelebrationsBoard )
      ActionShowCelebrationsBoard.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenNewMoonsBoard )
      ActionShowNewMoonsBoard.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenParashotBoard )
      ActionShowParashotBoard.PerformClick();
    if ( ApplicationCommandLine.Instance.OpenWeeklyParashahBox )
      ActionWeeklyParashahDescription.PerformClick();
    if ( SystemManager.CommandLineOptions.IsPreviewEnabled ) // TODO when ready : remove
      if ( ApplicationCommandLine.Instance.OpenLunarMonthsBoard )
        ActionShowLunarMonths.PerformClick();
  }

  /// <summary>
  /// Sets global HotKey combination.
  /// </summary>
  public void SetGlobalHotKey(bool noActive = false)
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
      if ( !noActive ) Globals.BringToFrontApplicationHotKey.Active = Settings.GlobalHotKeyPopupMainFormEnabled;
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
      MonthlyCalendar.Refresh();
      var forms = Application.OpenForms.GetAll().Where(f => f.Visible).ToList();
      if ( forms.Count > 0 )
      {
        foreach ( var form in forms )
          form.ForceBringToFront();
        forms[forms.Count - 1].Popup();
      }
    });
  }

  /// <summary>
  /// Does Form Closing event.
  /// </summary>
  private void DoFormClosing(object sender, FormClosingEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( Globals.AllowClose ) return;
    if ( Globals.IsExiting ) return;
    if ( Globals.IsSessionEnding ) return;
    if ( e.CloseReason == CloseReason.None || e.CloseReason == CloseReason.UserClosing )
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
    SystemManager.TryCatch(Settings.Store);
    Globals.AllowClose = true;
    Globals.IsExiting = true;
    Interlocks.Release();
    DebugManager.Stop();
    TimerTooltip.Stop();
    TimerBalloon.Stop();
    TimerTrayMouseMove.Stop();
    TimerMidnight.Stop();
    TimerReminder.Stop();
    TimerResumeReminder.Stop();
    LockSessionForm.Instance?.Timer.Stop();
    SystemManager.TryCatch(ClearLists);
    FormsHelper.CloseAll();
  }

  /// <summary>
  /// Does Session Ending event.
  /// </summary>
  public void SessionEnding(object sender, SessionEndingEventArgs e)
  {
    if ( Globals.IsExiting ) return;
    if ( Globals.IsSessionEnding ) return;
    DebugManager.Trace(LogTraceEvent.Data, e?.Reason.ToStringFull() ?? nameof(NativeMethods.WM_QUERYENDSESSION));
    Globals.AllowClose = true;
    Globals.IsSessionEnding = true;
    Close();
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
  /// WndProc override.
  /// </summary>
  [SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "Overrided")]
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
    SelectImagesFolderDialog.SelectedPath = Settings.GetExportImagesDirectory();
    SaveReportDialog.InitialDirectory = Settings.GetExportDirectory();
    SaveImageDialog.InitialDirectory = Settings.GetExportImagesDirectory();
    SaveGridDialog.InitialDirectory = Settings.GetExportDataDirectory();
    SaveDataBoardDialog.InitialDirectory = Settings.GetExportBoardsDirectory();
    SaveImageDialog.Filter = Program.ImageExportTargets.CreateFilters();
    SaveGridDialog.Filter = Program.GridExportTargets.CreateFilters();
    SaveDataBoardDialog.Filter = Program.BoardExportTargets.CreateFilters();
  }

  /// <summary>
  /// Initializes icons
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "N/A")]
  private void InitializeIconsAndSound()
  {
    SystemManager.TryCatch(() =>
    {
      TrayIcons[false][true] = new Icon(Program.ApplicationPauseEventIconFilePath).GetBySize(Globals.IconSize16);
      TrayIcons[false][false] = new Icon(Program.ApplicationPauseIconFilePath).GetBySize(Globals.IconSize16);
      TrayIcons[true][true] = new Icon(Program.ApplicationEventIconFilePath).GetBySize(Globals.IconSize16);
      TrayIcons[true][false] = new Icon(Globals.ApplicationIconFilePath).GetBySize(Globals.IconSize16);
    });
    SoundItem.Initialize();
    SystemManager.TryCatch(() => DisplayManager.DoSound(Globals.EmptySoundFilePath));
    SystemManager.TryCatch(() => MediaMixer.SetApplicationVolume(Globals.ProcessId, Settings.ApplicationVolume));
  }

  /// <summary>
  /// Initializes the calendar monthly view aspect.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  private void InitializeCalendarUI()
  {
    MonthlyCalendar.TheEvents.Clear();
    int sizeFont = Settings.MonthViewFontSize;
    if ( Settings.UseColors )
    {
      PanelMainInner2.BackColor = Settings.MonthViewNoDaysBackColor;
      CalenderNet.ColorText = Settings.MonthViewTextColor;
      MonthlyCalendar.ForeColor = Settings.MonthViewTextColor;
      MonthlyCalendar.BackColor = Settings.MonthViewBackColor;
      MonthlyCalendar.RogueBrush = SolidBrushesPool.Get(Settings.MonthViewNoDaysBackColor);
      CalenderNet.PenHoverEffect = PensPool.Get(Settings.CalendarColorHoverEffect);
      CalenderNet.PenActiveDay = PensPool.Get(Settings.CalendarColorActiveDay);
      CalenderNet.CurrentDayForeBrush = SolidBrushesPool.Get(Settings.CurrentDayForeColor);
      CalenderNet.CurrentDayBackBrush = SolidBrushesPool.Get(Settings.CurrentDayBackColor);
      CalenderNet.PenSelectedDay = PensPool.Get(Settings.SelectedDayBoxColor);
      CalenderNet.PenText = PensPool.Get(Settings.MonthViewTextColor);
      CalenderNet.PenTextReduced
        = PensPool.Get(Color.FromArgb(CalenderNet.PenText.Color.R < 125 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.R * 2 / 3,
                                      CalenderNet.PenText.Color.R < 125 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.G * 2 / 3,
                                      CalenderNet.PenText.Color.R < 125 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.B * 2 / 3));
      CalenderNet.BrushText = SolidBrushesPool.Get(Settings.MonthViewTextColor);
      CalenderNet.BrushBlack = SolidBrushesPool.Get(Settings.MonthViewTextColor);
      CalenderNet.BrushGrayMedium
        = SolidBrushesPool.Get(Color.FromArgb(CalenderNet.PenText.Color.R < 85 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.R * 2 / 3,
                                              CalenderNet.PenText.Color.R < 85 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.G * 2 / 3,
                                              CalenderNet.PenText.Color.R < 85 ? CalenderNet.PenText.Color.R + 255 * 2 / 3 : CalenderNet.PenText.Color.B * 2 / 3));
      CalenderNet.BrushGrayLight
        = SolidBrushesPool.Get(Color.FromArgb((int)( CalenderNet.PenText.Color.R < 20 ? CalenderNet.PenText.Color.R + 255 * 0.92 : CalenderNet.PenText.Color.R * 0.92 ),
                                              (int)( CalenderNet.PenText.Color.R < 20 ? CalenderNet.PenText.Color.R + 255 * 0.92 : CalenderNet.PenText.Color.G * 0.92 ),
                                              (int)( CalenderNet.PenText.Color.R < 20 ? CalenderNet.PenText.Color.R + 255 * 0.92 : CalenderNet.PenText.Color.B * 0.92 )));
      CalenderNet.PenBlack = Pens.Black;
    }
    else
    {
      PanelMainInner2.BackColor = SystemColors.Window;
      MonthlyCalendar.RogueBrush = Brushes.WhiteSmoke;
      MonthlyCalendar.ForeColor = Color.Black;
      MonthlyCalendar.BackColor = Color.White;
      CalenderNet.PenHoverEffect = Pens.Silver;
      CalenderNet.PenActiveDay = Pens.LightGray;
      CalenderNet.CurrentDayForeBrush = Brushes.White;
      CalenderNet.CurrentDayBackBrush = Brushes.Black;
      CalenderNet.ColorText = Color.Black;
      CalenderNet.PenText = Pens.Black;
      CalenderNet.PenTextReduced = Pens.LightGray;
      CalenderNet.BrushText = Brushes.Black;
      CalenderNet.BrushBlack = SolidBrushesPool.Get(Color.Black);
      CalenderNet.BrushGrayMedium = SolidBrushesPool.Get(Color.DarkGray);
      CalenderNet.BrushGrayLight = SolidBrushesPool.Get(CustomColor.PlatinumLight);
      CalenderNet.PenBlack = Pens.Black;
    }
    const string fontname = "Calibri";
    MonthlyCalendar.DateHeaderFont = new Font(fontname, sizeFont + 5, FontStyle.Bold);
    MonthlyCalendar.DayOfWeekFont = new Font(fontname, sizeFont + 1);
    MonthlyCalendar.DayViewTimeFont = new Font(fontname, sizeFont + 1, FontStyle.Bold);
    MonthlyCalendar.DaysFont = new Font(fontname, sizeFont + 2);
    MonthlyCalendar.TodayFont = new Font("Microsoft Sans Serif", sizeFont + 2, FontStyle.Bold);
  }

}
