/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm : Form
{

  #region Singleton

  /// <summary>
  /// Indicates the singleton instance.
  /// </summary>
  static internal MainForm Instance { get; private set; }

  /// <summary>
  /// Static constructor.
  /// </summary>
  static MainForm()
  {
    Instance = new MainForm();
  }

  #endregion

  #region Form Management

  /// <summary>
  /// Default constructor.
  /// </summary>
  private MainForm()
  {
    InitializeComponent();
    DoConstructor();
  }

  /// <summary>
  /// Event handler. Called by MainForm for load events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MainForm_Load(object sender, EventArgs e)
  {
    DoFormLoad(sender, e);
  }

  /// <summary>
  /// Event handler. Called by MainForm for shown events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MainForm_Shown(object sender, EventArgs e)
  {
    DoFormShown(sender, e);
  }

  /// <summary>
  /// Event handler. Called by MainForm for form closing events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    DoFormClosing(sender, e);
  }

  /// <summary>
  /// Event handler. Called by MainForm for form closed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    DoFormClosed(sender, e);
  }

  /// <summary>
  /// Event handler. Called by MainForm for windows changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MainForm_WindowsChanged(object sender, EventArgs e)
  {
    if ( !Visible ) return;
    if ( !Globals.IsReady ) return;
    if ( Globals.IsExiting ) return;
    if ( WindowState != FormWindowState.Normal ) return;
    EditScreenNone.PerformClick();
  }

  #endregion

  #region Top Menu Tool-Tips

  /// <summary>
  /// Event handler. Called by TimerTooltip for tick events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TimerTooltip_Tick(object sender, EventArgs e)
  {
    if ( !EditShowTips.Checked ) return;
    var item = (ToolStripItem)LastToolTip.Tag;
    var location = new Point(item.Bounds.Left, item.Bounds.Top + ActionExit.Height + 5);
    LastToolTip.Tag = sender;
    LastToolTip.Show(item.ToolTipText, ToolStrip, location, 3000);
    TimerTooltip.Enabled = false;
  }

  /// <summary>
  /// Event handler. Called by ShowToolTip for on mouse enter events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ShowToolTip_OnMouseEnter(object sender, EventArgs e)
  {
    if ( !EditShowTips.Checked ) return;
    if ( sender is not ToolStripItem ) return;
    if ( LastToolTip.Tag == sender ) return;
    LastToolTip.Tag = sender;
    if ( ( (ToolStripItem)sender ).ToolTipText.Length == 0 ) return;
    TimerTooltip.Enabled = true;
  }

  /// <summary>
  /// Event handler. Called by ShowToolTip for on mouse leave events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ShowToolTip_OnMouseLeave(object sender, EventArgs e)
  {
    if ( !EditShowTips.Checked ) return;
    TimerTooltip.Enabled = false;
    LastToolTip.Tag = null;
    LastToolTip.Hide(ToolStrip);
  }

  #endregion

  #region Tray Icon

  /// <summary>
  /// Event handler. Called by MenuExit for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MenuExit_Click(object sender, EventArgs e)
  {
    DoMenuExit_Click(sender, e);
  }

  /// <summary>
  /// Event handler. Called by MenuShowHide for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void MenuShowHide_Click(object sender, EventArgs e)
  {
    DoMenuShowHide_Click(sender, e);
  }

  public void ForceHideToTray()
  {
    if ( Visible )
    {
      if ( WindowState == FormWindowState.Minimized )
        MenuShowHide.PerformClick();
      MenuShowHide.PerformClick();
    }
  }

  /// <summary>
  /// Event handler. Called by TrayIcon for mouse click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Mouse event information.</param>
  private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
  {
    DoTrayIconMouse_Click(sender, e);
  }

  /// <summary>
  /// Event handler. Called by MenuTray for visible changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MenuTray_VisibleChanged(object sender, EventArgs e)
  {
    TrayIconCanBallon = !MenuTray.Visible;
  }

  /// <summary>
  /// Event handler. Called by TrayIcon for mouse move events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TrayIcon_MouseMove(object sender, MouseEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( !MenuTray.Enabled ) return;
    SystemManager.TryCatch(() =>
    {
      if ( !Settings.BalloonEnabled || ( Settings.BalloonOnlyIfMainFormIsHidden && Visible ) )
      {
        var lines = Text.Replace("Parashah ", "").SplitNoEmptyLines(" - ").ToList();
        if ( lines.Count >= 3 )
        {
          lines.Insert(2, DateTime.Today.ToShortDateString());
          int index = lines.Count - 1;
          int pos = lines[index].IndexOf('(');
          if ( pos != -1 )
            lines[index] = lines[index].Substring(0, pos - 1);
        }
        else
          lines.Add(DateTime.Today.ToShortDateString());
        TrayIcon.Text = new string(string.Join(Globals.NL, lines).Take(63).ToArray());
      }
      else
        TrayIcon.Text = string.Empty;
      if ( !Settings.BalloonEnabled || Settings.TrayIconClickOpen == TrayIconClickOpen.NavigationForm )
        return;
      TimerBallon.Start();
      TrayIconMouse = Cursor.Position;
      if ( !TimerTrayMouseMove.Enabled && Settings.BalloonAutoHide )
        TimerTrayMouseMove.Start();
    });
  }

  /// <summary>
  /// Event handler. Called by TimerTrayMouseMove for tick events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TimerTrayMouseMove_Tick(object sender, EventArgs e)
  {
    if ( Cursor.Position == TrayIconMouse ) return;
    TimerBallon.Stop();
    TimerTrayMouseMove.Stop();
    if ( NavigationForm.Instance.Visible && IsTrayBallooned )
      ActionNavigate.PerformClick();
  }

  /// <summary>
  /// Event handler. Called by TimerBallon for tick events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TimerBallon_Tick(object sender, EventArgs e)
  {
    TimerBallon.Stop();
    if ( !TrayIconCanBallon ) return;
    if ( !NavigationForm.Instance.Visible )
      if ( !Visible || !Settings.BalloonOnlyIfMainFormIsHidden )
        if ( TrayIconMouse.X != 0 && TrayIconMouse.Y != 0 && Cursor.Position == TrayIconMouse )
          ActionNavigate_Click(null, null);
  }

  #endregion

  #region Menu System

  /// <summary>
  /// Event handler. Called by ActionExit for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionExit_Click(object sender, EventArgs e)
  {
    MenuShowHide.PerformClick();
    ActionExit.Visible = false;
    ActionExit.Visible = true;
  }

  /// <summary>
  /// Event handler. Called by ActionExit for mouse up events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionExit_MouseUp(object sender, MouseEventArgs e)
  {
    if ( e.Button == MouseButtons.Right )
      MenuExit_Click(MenuExit, null);
  }

  internal bool PreferencesMutex;

  /// <summary>
  /// Event handler. Called by ActionPreferences for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  internal void ActionPreferences_Click(object sender, EventArgs e)
  {
    if ( !ActionPreferences.Enabled ) return;
    var dateOld = CurrentDay?.Date;
    bool formEnabled = Enabled;
    bool trayEnabled = MenuTray.Enabled;
    ActionPreferences.Visible = false;
    ActionPreferences.Visible = true;
    ToolStrip.Enabled = false;
    TimerReminder.Enabled = false;
    MenuTray.Enabled = false;
    PreferencesMutex = true;
    try
    {
      ClearLists();
      if ( PreferencesForm.Run(sender is int index ? index : -1) )
      {
        PanelViewText.Parent = null;
        PanelViewMonth.Parent = null;
        PanelViewGrid.Parent = null;
        PanelViewMonth.Visible = false;
        CodeProjectCalendar.NET.Calendar.PenHoverEffect = new Pen(Settings.CalendarColorHoverEffect);
        CodeProjectCalendar.NET.Calendar.CurrentDayForeBrush = new SolidBrush(Settings.CurrentDayForeColor);
        CodeProjectCalendar.NET.Calendar.CurrentDayBackBrush = new SolidBrush(Settings.CurrentDayBackColor);
        UpdateCalendarMonth(false);
        Thread.Sleep(1000);
        ActionGenerate_Click(null, null);
        PanelViewMonth.Visible = true;
      }
      TimerBallon.Interval = Settings.BalloonLoomingDelay;
      CalendarMonth.ShowEventTooltips = false;
      InitializeSpecialMenus();
      InitializeDialogsDirectory();
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      ToolStrip.Enabled = formEnabled;
      MenuTray.Enabled = trayEnabled;
      TimerReminder.Enabled = true;
      EnableReminderTimer();
      if ( dateOld is null )
        GoToDate(DateTime.Today);
      else
        GoToDate(dateOld.Value);
      UpdateTitles(true);
      PreferencesMutex = false;
    }
  }

  #endregion

  #region Menu Settings

  /// <summary>
  /// Event handler. Called by ActionResetWinSettings for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionResetWinSettings_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo(SysTranslations.AskToRestoreWindowPosition.GetLang()) )
      Settings.RestoreMainForm();
  }

  /// <summary>
  /// Event handler. Called by EditScreenPosition for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void EditScreenPosition_Click(object sender, EventArgs e)
  {
    DoScreenPosition(sender, e);
  }

  /// <summary>
  /// Event handler. Called by ActionShowKeyboardNotice for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowKeyboardNotice_Click(object sender, EventArgs e)
  {
    Globals.NoticeKeyboardShortcutsForm.Popup();
  }

  /// <summary>
  /// Event handler. Called by EditDialogBoxesSettings for checked changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void EditDialogBoxesSettings_CheckedChanged(object sender, EventArgs e)
  {
    Settings.SoundsEnabled = EditSoundsEnabled.Checked;
    DisplayManager.AdvancedFormUseSounds = EditSoundsEnabled.Checked;
    DisplayManager.FormStyle = EditUseAdvancedDialogBoxes.Checked
                               ? MessageBoxFormStyle.Advanced
                               : MessageBoxFormStyle.System;
    switch ( DisplayManager.FormStyle )
    {
      case MessageBoxFormStyle.System:
        DisplayManager.IconStyle = EditSoundsEnabled.Checked
                                   ? MessageBoxIconStyle.ForceInformation
                                   : MessageBoxIconStyle.ForceNone;
        break;
      case MessageBoxFormStyle.Advanced:
        DisplayManager.IconStyle = MessageBoxIconStyle.ForceInformation;
        break;
    }
  }

  /// <summary>
  /// Event handler. Called by EditShowSuccessDialogs for checked changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void EditShowSuccessDialogs_CheckedChanged(object sender, EventArgs e)
  {
    DisplayManager.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
  }

  /// <summary>
  /// Event handler. Called by ActionSelectReminderBoxSound for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionSelectReminderBoxSound_Click(object sender, EventArgs e)
  {
    SelectSoundForm.Run();
  }

  #endregion

  #region Menu Information

  /// <summary>
  /// Event handler. Called by ActionWebCheckUpdate for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void ActionWebCheckUpdate_Click(object sender, EventArgs e)
  {
    if ( IsSpecialDay ) return;
    bool menuEnabled = MenuTray.Enabled;
    try
    {
      MenuTray.Enabled = false;
      var lastdone = Settings.CheckUpdateLastDone;
      bool exit = WebCheckUpdate.Run(Settings.CheckUpdateAtStartup,
                                     ref lastdone,
                                     Settings.CheckUpdateAtStartupDaysInterval,
                                     e is null);
      Settings.CheckUpdateLastDone = lastdone;
      if ( exit )
      {
        Globals.AllowClose = true;
        Close();
      }
    }
    finally
    {
      MenuTray.Enabled = menuEnabled;
    }
  }

  /// <summary>
  /// Event handler. Called by ActionViewLog for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void ActionViewLog_Click(object sender, EventArgs e)
  {
    DebugManager.TraceForm.Popup();
  }

  /// <summary>
  /// Event handler. Called by ActionViewStats for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void ActionViewStats_Click(object sender, EventArgs e)
  {
    StatisticsForm.Run();
  }

  #endregion

  #region Menu Tools

  /// <summary>
  /// Shows a notice.
  /// </summary>
  private void ShowNotice(object sender, TranslationsDictionary title, TranslationsDictionary text, int width)
  {
    switch ( DisplayManager.FormStyle )
    {
      case MessageBoxFormStyle.System:
        DisplayManager.Show(title.GetLang(), text.GetLang());
        break;
      case MessageBoxFormStyle.Advanced:
        var form = MessageBoxEx.Instances.Find(f => f.Text == title.GetLang())
                   ?? new MessageBoxEx(title, text, width: width);
        form.ShowInTaskbar = true;
        form.Popup(null, sender is null);
        break;
      default:
        throw new AdvancedNotImplementedException(DisplayManager.FormStyle);
    }
  }

  /// <summary>
  /// Event handler. Called by ActionShowMonthsAndDaysNotice for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void ActionShowMonthsAndDaysNotice_Click(object sender, EventArgs e)
  {
    ShowNotice(sender,
               AppTranslations.NoticeMonthsAndDaysTitle,
               AppTranslations.NoticeMonthsAndDays,
               MessageBoxEx.DefaultWidthMedium);
  }

  /// <summary>
  /// Event handler. Called by ActionShowCelebrationsNotice for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void ActionShowCelebrationsNotice_Click(object sender, EventArgs e)
  {
    ShowNotice(sender,
               AppTranslations.NoticeCelebrationsTitle,
               AppTranslations.NoticeCelebrations,
               MessageBoxEx.DefaultWidthMedium);
  }

  /// <summary>
  /// Event handler. Called by ActionShowShabatNotice for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void ActionShowShabatNotice_Click(object sender, EventArgs e)
  {
    ShowNotice(sender,
               AppTranslations.NoticeShabatTitle,
               AppTranslations.NoticeShabat,
               MessageBoxEx.DefaultWidthLarge);
  }

  /// <summary>
  /// Event handler. Called by ActionShowParashahNotice for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void ActionShowParashahNotice_Click(object sender, EventArgs e)
  {
    ShowNotice(sender,
               AppTranslations.NoticeParashahTitle,
               AppTranslations.NoticeParashah,
               MessageBoxEx.DefaultWidthMedium);
  }

  /// <summary>
  /// Event handler. Called by ActionViewParashahInfos for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewParashahInfos_Click(object sender, EventArgs e)
  {
    ApplicationDatabase.Instance.ShowWeeklyParashahDescription();
  }

  /// <summary>
  /// Event handler. Called by ActionOpenHebrewWordsVerse for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOpenHebrewWordsVerse_Click_1(object sender, EventArgs e)
  {
    HebrewTools.OpenHebrewWordsGoToVerse(ApplicationDatabase.Instance.GetWeeklyParashah().Factory.FullReferenceBegin,
                                         Settings.HebrewWordsExe);
  }

  /// <summary>
  /// Event handler. Called by CelebrationVersesBoard for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void CelebrationVersesBoard_Click(object sender, EventArgs e)
  {
    CelebrationVersesBoardForm.Run();
  }

  /// <summary>
  /// Event handler. Called by ActionViewCelebrationsBoard for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewCelebrationsBoard_Click(object sender, EventArgs e)
  {
    CelebrationsBoardForm.Run();
  }

  /// <summary>
  /// Event handler. Called by ActionViewMoonsBoard for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewMoonsBoard_Click(object sender, EventArgs e)
  {
    NewMoonsBoardForm.Run();
  }

  /// <summary>
  /// Event handler. Called by ActionViewLunarMonths for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewLunarMonths_Click(object sender, EventArgs e)
  {
    LunarMonthsForm.Run();
  }

  /// <summary>
  /// Event handler. Called by ActionViewParashot for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewParashot_Click(object sender, EventArgs e)
  {
    ParashotForm.Run(ApplicationDatabase.Instance.GetWeeklyParashah().Factory);
  }

  /// <summary>
  /// Event handler. Called by ActionOpenCalculator for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOpenCalculator_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Settings.CalculatorExe);
  }

  /// <summary>
  /// Event handler. Called by ActionOpenSystemDateAndTime for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOpenSystemDateAndTime_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell("timedate.cpl");
  }

  /// <summary>
  /// Event handler. Called by ActionCalculateDateDiff for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionCalculateDateDiff_Click(object sender, EventArgs e)
  {
    DatesDiffCalculatorForm.Run();
  }

  /// <summary>
  /// Event handler. Called by ActionLocalWeather for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionLocalWeather_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Settings.WeatherAppPath);
  }

  /// <summary>
  /// Event handler. Called by ActionOnlineWeather for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOnlineWeather_Click(object sender, EventArgs e)
  {
    OpenOnlineWeather();
  }

  /// <summary>
  /// Event handler. Called by ActionGenerate for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionGenerate_Click(object sender, EventArgs e)
  {
    MenuShowHide_Click(null, null);
    SystemManager.TryCatchManage(() => DoGenerate(sender, e));
    UpdateTitles(true);
  }

  /// <summary>
  /// Event handler. Called by ActionOpenExportFolder for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOpenExportFolder_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Settings.GetExportDirectory());
  }

  /// <summary>
  /// Event handler. Called by ActionVacuumDB for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionVacuumDB_Click(object sender, EventArgs e)
  {
    Settings.VacuumLastDone = ApplicationDatabase.Instance
                                                 .Connection
                                                 .Optimize(Settings.VacuumLastDone,
                                                           Settings.VacuumAtStartupDaysInterval,
                                                           true);
    HebrewDatabase.Instance.Connection.Optimize(DateTime.MinValue, force: true);
    ApplicationStatistics.UpdateDBCommonFileSizeRequired = true;
    ApplicationStatistics.UpdateDBFileSizeRequired = true;
    DisplayManager.Show(SysTranslations.DatabaseVacuumSuccess.GetLang());
  }

  #endregion

  #region Menu Application View

  /// <summary>
  /// Event handler. Called by ActionViewReport for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewReport_Click(object sender, EventArgs e)
  {
    SetView(ViewMode.Text);
  }

  /// <summary>
  /// Event handler. Called by ActionViewMonth for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewMonth_Click(object sender, EventArgs e)
  {
    SetView(ViewMode.Month);
  }

  /// <summary>
  /// Event handler. Called by ActionViewGrid for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewGrid_Click(object sender, EventArgs e)
  {
    SetView(ViewMode.Grid);
  }

  #endregion

  #region Menu Application Export

  /// <summary>
  /// Event handler. Called by ActionSave for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionSave_Click(object sender, EventArgs e)
  {
    ExportSave();
  }

  /// <summary>
  /// Event handler. Called by ActionCopyToClipboard for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionCopyToClipboard_Click(object sender, EventArgs e)
  {
    ExportToClipboard();
  }

  /// <summary>
  /// Event handler. Called by ActionPrint for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionPrint_Click(object sender, EventArgs e)
  {
    ExportPrint();
  }

  #endregion

  #region Menu Application Search

  /// <summary>
  /// Event handler. Called by ActionSearchDay for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionSearchDay_Click(object sender, EventArgs e)
  {
    DateTime date = DateTime.Today;
    if ( sender is not null )
      if ( !SelectDayForm.Run(null, ref date, false, true, true) )
        return;
    GoToDate(date);
  }

  /// <summary>
  /// Event handler. Called by ActionSearchEvent for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionSearchEvent_Click(object sender, EventArgs e)
  {
    using var form = new SearchEventForm();
    form.ShowDialog();
  }

  /// <summary>
  /// Event handler. Called by ActionSearchMonth for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionSearchMonth_Click(object sender, EventArgs e)
  {
    using var form = new SearchLunarMonthForm();
    form.ShowDialog();
  }

  /// <summary>
  /// Event handler. Called by ActionSearchGregorianMonth for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionSearchGregorianMonth_Click(object sender, EventArgs e)
  {
    using var form = new SearchGregorianMonthForm();
    form.ShowDialog();
  }

  /// <summary>
  /// Event handler. Called by ActionNavigate for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionNavigate_Click(object sender, EventArgs e)
  {
    SystemManager.TryCatchManage(() =>
    {
      TimerBallon.Stop();
      IsTrayBallooned = sender is null;
      if ( NavigationForm.Instance.Visible )
      {
        NavigationForm.Instance.Hide();
      }
      else
      {
        if ( sender != ActionNavigate && Settings.MainFormShownGoToToday )
          GoToDate(DateTime.Today);
        else
          GoToDate(CalendarMonth.CalendarDate.Date);
        NavigationForm.Instance.ShowPopup(true);
      }
    });
  }

  /// <summary>
  /// Event handler. Called by ActionViewCelebrations for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewCelebrations_Click(object sender, EventArgs e)
  {
    if ( NextCelebrationsForm.Instance?.Visible == true )
      NextCelebrationsForm.Instance.BringToFront();
    else
      NextCelebrationsForm.Run();
  }

  #endregion

  #region Menu Application Reminder

  /// <summary>
  /// Event handler. Called by MenuRefreshReminder for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MenuRefreshReminder_Click(object sender, EventArgs e)
  {
    ClearLists();
    TimerReminder_Tick(null, null);
  }

  /// <summary>
  /// Event handler. Called by MenuEnableReminder for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MenuEnableReminder_Click(object sender, EventArgs e)
  {
    EnableReminderTimer();
  }

  /// <summary>
  /// Event handler. Called by MenuDisableReminder for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void MenuDisableReminder_Click(object sender, EventArgs e)
  {
    DisableReminderTimer();
  }

  #endregion

  #region View Text Report

  /// <summary>
  /// Event handler. Called by CalendarText for key down events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void CalendarText_KeyDown(object sender, KeyEventArgs e)
  {
    if ( e.Control && e.KeyCode == Keys.A )
    {
      CalendarText.SelectAll();
      e.Handled = true;
    }
    else
    if ( e.Control && e.Shift && e.KeyCode == Keys.C )
    {
      CalendarText.Copy();
      DisplayManager.ShowSuccessOrSound(SysTranslations.SelectionCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
      e.Handled = true;
    }
  }

  #endregion

  #region Data Grid View

  /// <summary>
  /// Event handler. Called by LabelGridGoToToday for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void LabelGridGoToToday_Click(object sender, EventArgs e)
  {
    GoToDate(DateTime.Today);
  }

  /// <summary>
  /// Event handler. Called by EditExportDataEnumsAsTranslations for checked changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void EditExportDataEnumsAsTranslations_CheckedChanged(object sender, EventArgs e)
  {
    Settings.ExportDataEnumsAsTranslations = EditExportDataEnumsAsTranslations.Checked;
    CalendarGrid.Invalidate();
  }

  /// <summary>
  /// Event handler. Called by CalendarGrid for cell formatting events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void CalendarGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
  {
    switch ( e.ColumnIndex )
    {
      case 5:
        e.Value = ( (MoonriseOccurring)e.Value ).ToStringExport(AppTranslations.MoonriseOccurings);
        break;
      case 8:
      case 9:
        e.Value = (bool)e.Value ? Globals.Bullet : string.Empty;
        break;
      case 10:
        e.Value = ( (MoonPhase)e.Value ).ToStringExport(AppTranslations.MoonPhases);
        break;
      case 11:
        var season = (SeasonChange)e.Value;
        e.Value = season == SeasonChange.None
                  ? string.Empty
                  : season.ToStringExport(AppTranslations.SeasonChanges);
        break;
      case 12:
        var torah = (TorahCelebrationDay)e.Value;
        e.Value = torah == TorahCelebrationDay.None
                  ? string.Empty
                  : torah.ToStringExport(AppTranslations.TorahCelebrationDays);
        break;
    }
  }

  /// <summary>
  /// Event handler. Called by LunisolarDaysBindingSource for current item changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void LunisolarDaysBindingSource_CurrentItemChanged(object sender, EventArgs e)
  {
    if ( GoToDateMutex ) return;
    SystemManager.TryCatch(() =>
    {
      if ( LunisolarDaysBindingSource.Current is not null )
        GoToDate(( (LunisolarDay)LunisolarDaysBindingSource.Current ).Date);
    });
  }

  #endregion

  #region Timers

  /// <summary>
  /// Event handler. Called by TimerReminder for tick events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TimerReminder_Tick(object sender, EventArgs e)
  {
    DoTimerReminder();
  }

  /// <summary>
  /// Event handler. Called by TimerUpdateTitles for tick events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TimerUpdateTitles_Tick(object sender, EventArgs e)
  {
    if ( Globals.IsExiting || Globals.IsSessionEnding )
      TimerUpdateTitles.Stop();
    else
      UpdateTitles();
  }

  /// <summary>
  /// Event handler. Called by TimerResumeReminder for tick events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TimerResumeReminder_Tick(object sender, EventArgs e)
  {
    TimerResumeReminder.Enabled = false;
    MenuEnableReminder.PerformClick();
  }


  /// <summary>
  /// Event handler. Called by TimerMidnight for tick events.
  /// </summary>
  [SuppressMessage("Redundancy", "RCS1163:Unused parameter.", Justification = "Event Handler")]
  private void TimerMidnight_Tick(DateTime Time)
  {
    DoTimerMidnight();
  }

  #endregion

  #region Context Menu

  private void CalendarMonth_MouseClick(object sender, MouseEventArgs e)
  {
    DoCalendarMonth_MouseClick(sender, e);
  }

  private void ContextMenuStripDay_Opened(object sender, EventArgs e)
  {
    DoContextMenuStripDay_Opened(sender, e);
  }

  private void ContextMenuDayNavigation_Click(object sender, EventArgs e)
  {
    ActionNavigate.PerformClick();
  }

  private void ContextMenuDayCelebrationVersesBoard_Click(object sender, EventArgs e)
  {
    CelebrationVersesBoardForm.Run(ContextMenuDayCurrentEvent.Date);
  }

  private void ContextMenuDayParashah_Click(object sender, EventArgs e)
  {
    if ( ContextMenuDayCurrentEvent.GetParashahReadingDay() is LunisolarDay day )
      if ( ParashotFactory.Instance.Get(day.ParashahID) is Parashah parashah )
        if ( sender == ContextMenuDayParashahShowDescription )
          UserParashot.ShowDescription(parashah, day.HasLinkedParashah, () => ParashotForm.Run(parashah));
        else
        if ( sender == ContextMenuDayParashotBoard )
          ParashotForm.Run(parashah);
  }

  private void ContextMenuOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    if ( ContextMenuDayCurrentEvent.GetParashahReadingDay() is LunisolarDay day )
      if ( ParashotFactory.Instance.Get(day.ParashahID) is Parashah parashah )
        HebrewTools.OpenHebrewWordsGoToVerse(parashah.FullReferenceBegin, Settings.HebrewWordsExe);
  }

  private void CalendarMonth_MouseMove(object sender, MouseEventArgs e)
  {
    if ( IsCalendarReady ) return;
    if ( TimerMutex ) return;
    CalendarMonth.Refresh();
  }

  private void ContextMenuDaySetAsActive_Click(object sender, EventArgs e)
  {
    GoToDate(ContextMenuDayCurrentEvent.Date);
  }

  private void ContextMenuDayGoToToday_Click(object sender, EventArgs e)
  {
    GoToDate(DateTime.Today);
  }

  private void ContextMenuDayGoToSelected_Click(object sender, EventArgs e)
  {
    GoToDate(DateSelected.Value);
  }

  private void ContextMenuDaySelect_Click(object sender, EventArgs e)
  {
    DateSelected = ContextMenuDayCurrentEvent.Date;
    if ( DateSelected is not null )
      if ( CalendarMonth.CalendarDate.Month != DateSelected.Value.Month )
        GoToDate(DateSelected.Value);
  }

  private void ContextMenuDayClearSelection_Click(object sender, EventArgs e)
  {
    DateSelected = null;
  }

  private void ContextMenuDayDatesDiffToToday_Click(object sender, EventArgs e)
  {
    ContextMenuDayDatesDiffTo(DateTime.Today);
  }

  private void ContextMenuDayDatesDiffToSelected_Click(object sender, EventArgs e)
  {
    if ( _DateSelected.HasValue ) ContextMenuDayDatesDiffTo(_DateSelected.Value);
  }

  private void ContextMenuDayDatesDiffTo(DateTime date)
  {
    var tuple = new Tuple<DateTime, DateTime>(ContextMenuDayCurrentEvent.Date, date);
    DatesDiffCalculatorForm.Run(tuple, ensureOrder: true);
  }

  private ToolStripMenuItem CurrentBookmarkMenu;

  internal void LoadMenuBookmarks(Form caller)
  {
    DatesDiffCalculatorForm.LoadMenuBookmarks(MenuBookmarks.Items, Bookmarks_MouseUp);
    if ( caller != DatesDiffCalculatorForm.Instance )
      DatesDiffCalculatorForm.Instance.LoadMenuBookmarks(this);
    MenuBookmarks.DuplicateTo(ContextMenuDayGoToBookmark);
    MenuBookmarks.DuplicateTo(ContextMenuDaySaveBookmark);
  }

  private void ContextMenuDayGoToBookmark_DropDownOpened(object sender, EventArgs e)
  {
    CurrentBookmarkMenu = sender as ToolStripMenuItem;
  }

  private void Bookmarks_MouseUp(object sender, MouseEventArgs e)
  {
    DoBookmarksMouseUp(sender, e);
  }

  private void ContextMenuDayManageBookmark_Click(object sender, EventArgs e)
  {
    if ( ManageBookmarksForm.Run() )
      LoadMenuBookmarks(this);
  }

  #endregion

}
