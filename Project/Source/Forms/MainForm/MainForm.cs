/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
sealed partial class MainForm : Form
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
    LastToolTip.Show(item.ToolTipText, ToolStrip, location, Globals.ToolTipDelay);
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
        // TODO NEXT refactor in UpdateUI and do a clean formatting with gregorian date before hebrew
        var text = Text.IndexOf('(') >= 0
          ? new string(Text.ToCharArray().TakeWhile(c => c != '(').ToArray())
          : Text;
        var lines = text.Replace(HebrewTranslations.Parashah + " ", "").SplitNoEmptyLines(" - ").ToList();
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
        TrayIcon.Text = new string(lines.AsMultiLine().Take(Globals.TrayIconTextLimit).ToArray());
      }
      else
        TrayIcon.Text = string.Empty;
      if ( !Settings.BalloonEnabled || Settings.TrayIconClickOpen == TrayIconClickOpen.NavigationForm )
        return;
      TimerBalloon.Start();
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
    TimerBalloon.Stop();
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
    TimerBalloon.Stop();
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
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A else crash")]
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
        PanelViewTextReport.Parent = null;
        PanelViewMonthlyCalendar.Parent = null;
        PanelViewGrid.Parent = null;
        PanelViewMonthlyCalendar.Visible = false;
        CodeProjectCalendar.NET.Calendar.PenHoverEffect = PensPool.Get(Settings.CalendarColorHoverEffect);
        CodeProjectCalendar.NET.Calendar.CurrentDayForeBrush = SolidBrushesPool.Get(Settings.CurrentDayForeColor);
        CodeProjectCalendar.NET.Calendar.CurrentDayBackBrush = SolidBrushesPool.Get(Settings.CurrentDayBackColor);
        UpdateCalendarMonth(false);
        Thread.Sleep(1000);
        ActionGenerate_Click(null, null);
        PanelViewMonthlyCalendar.Visible = true;
      }
      TimerBalloon.Interval = Settings.BalloonLoomingDelay;
      MonthlyCalendar.ShowEventTooltips = false;
      InitializeMenus();
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
    Globals.KeyboardShortcutsNotice.Popup();
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
    DisplayManager.IconStyle = DisplayManager.FormStyle switch
    {
      MessageBoxFormStyle.System => EditSoundsEnabled.Checked
        ? MessageBoxIconStyle.ForceInformation
        : MessageBoxIconStyle.ForceNone,
      MessageBoxFormStyle.Advanced => MessageBoxIconStyle.ForceInformation,
      _ => throw new AdvNotImplementedException(DisplayManager.FormStyle),
    };
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
      bool exit = WebCheckUpdate.Run(ref lastdone,
                                     Settings.CheckUpdateAtStartupDaysInterval,
                                     e is null,
                                     Settings.CheckUpdateAtStartup);
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
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "N/A")]
  private void ShowNotice(object sender, TranslationsDictionary title, TranslationsDictionary text, int width)
  {
    switch ( DisplayManager.FormStyle )
    {
      case MessageBoxFormStyle.System:
        DisplayManager.Show(title.GetLang(), text.GetLang());
        break;
      case MessageBoxFormStyle.Advanced:
        string titleTranslated = title.GetLang();
        var form = MessageBoxEx.Instances.Find(f => f.Text == titleTranslated)
                   ?? new MessageBoxEx(title, text, width: width);
        form.ShowInTaskbar = true;
        form.Popup(null, sender is null);
        break;
      default:
        throw new AdvNotImplementedException(DisplayManager.FormStyle);
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
  /// Event handler. Called by ActionShowFoodNotice for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowFoodNotice_Click(object sender, EventArgs e)
  {
    ShowNotice(sender,
               AppTranslations.NoticeCelebrationsFoodTitle,
               AppTranslations.NoticeCelebrationsFood,
               MessageBoxEx.DefaultWidthLarge);
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
  /// Event handler. Called by ActionShowTranscriptionGuide for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowTranscriptionGuide_Click(object sender, EventArgs e)
  {
    Program.TranscriptionGuideForm.Popup();
  }

  /// <summary>
  /// Event handler. Called by ActionShowGrammarGuide for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
  {
    Program.GrammarGuideForm.Popup();
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
  /// Event handler. Called by ActionParashahReadDefault for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionParashahReadDefault_Click(object sender, EventArgs e)
  {
    DoReadParashahWeekly(Settings.OpenVerseOnlineURL);
  }

  /// <summary>
  /// Event handler. Called by ActionOpenHebrewWordsVerse for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    HebrewTools.OpenHebrewWordsGoToVerse(ApplicationDatabase.Instance.GetWeeklyParashah().Factory.FullReferenceBegin);
  }

  /// <summary>
  /// Event handler. Called by ActionShowCelebrationVersesBoard for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowCelebrationVersesBoard_Click(object sender, EventArgs e)
  {
    Hebrew.CelebrationVersesBoardForm.Run(TorahCelebration.Pessah,
                                          nameof(Settings.CelebrationVersesBoardFormLocation),
                                          nameof(Settings.CelebrationVersesBoardFormClientSize),
                                          Settings.OpenVerseOnlineURL,
                                          Settings.DoubleClickOnVerseOpenDefaultReader,
                                          value => Settings.DoubleClickOnVerseOpenDefaultReader = value);
  }

  /// <summary>
  /// Event handler. Called by ActionShowCelebrationsBoard for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowCelebrationsBoard_Click(object sender, EventArgs e)
  {
    CelebrationsBoardForm.Run();
  }

  /// <summary>
  /// Event handler. Called by ActionShowMoonsBoard for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowMoonsBoard_Click(object sender, EventArgs e)
  {
    NewMoonsBoardForm.Run();
  }

  /// <summary>
  /// Event handler. Called by ActionShowLunarMonths for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowLunarMonths_Click(object sender, EventArgs e)
  {
    LunarMonthsForm.Run();
  }

  /// <summary>
  /// Event handler. Called by ActionShowParashot for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionShowParashot_Click(object sender, EventArgs e)
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
  /// Event handler. Called by ActionTakeScreenshotWindow for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionTakeScreenshotWindow_Click(object sender, EventArgs e)
  {
    using var bitmap = this.GetBitmap();
    Clipboard.SetImage(bitmap);
    DisplayManager.ShowSuccessOrSound(SysTranslations.ScreenshotDone.GetLang(),
                                      Globals.ScreenshotSoundFilePath);
  }

  /// <summary>
  /// Event handler. Called by ActionTakeScreenshotView for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionTakeScreenshotView_Click(object sender, EventArgs e)
  {
    using var bitmap = PanelMainOuter1.GetBitmap();
    Clipboard.SetImage(bitmap);
    DisplayManager.ShowSuccessOrSound(SysTranslations.ScreenshotDone.GetLang(),
                                      Globals.ScreenshotSoundFilePath);
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
  /// Event handler. Called by ActionOpenFolderExport for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOpenFolderExport_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Settings.GetExportDirectory());
  }

  /// <summary>
  /// Event handler. Called by ActionOpenFolderDatabase for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOpenFolderDatabase_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Globals.DatabaseFolderPath);
  }

  /// <summary>
  /// Event handler. Called by ActionVacuumDB for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  [SuppressMessage("Usage", "GCop517:'{0}()' returns a value but doesn't change the object. It's meaningless to call it without using the returned result.", Justification = "N/A")]
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
    var date = DateTime.Today;
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
      TimerBalloon.Stop();
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
          GoToDate(MonthlyCalendar.CalendarDate.Date);
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

  private bool TextBoxReportMutex;

  /// <summary>
  /// Event handler. Called by TextBoxReport for key down events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TextBoxReport_KeyDown(object sender, KeyEventArgs e)
  {
    TextBoxReportMutex = true;
    if ( e.Control && e.KeyCode == Keys.A )
    {
      TextReport.SelectAll();
      e.Handled = true;
    }
    else
    if ( e.Control && e.Shift && e.KeyCode == Keys.C )
    {
      TextReport.Copy();
      DisplayManager.ShowSuccessOrSound(SysTranslations.SelectionCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
      e.Handled = true;
    }
  }

  /// <summary>
  /// Event handler. Called by TextBoxReport for key up events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void TextBoxReport_KeyUp(object sender, KeyEventArgs e)
  {
    TextBoxReportMutex = false;
    TextBoxReport_SelectionChanged(sender, e);
  }

  /// <summary>
  /// Event handler. Called by TextBoxReport for selection changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  private void TextBoxReport_SelectionChanged(object sender, EventArgs e)
  {
    if ( TextBoxReportMutex ) return;
    if ( Globals.IsGenerating ) return;
    int index = TextReport.SelectionStart;
    int line = TextReport.GetLineFromCharIndex(index);
    if ( line < TextReport.Lines.Length && TextReport.Lines[line].Length >= 16 )
    {
      string str = TextReport.Lines[line].Substring(6, 10);
      if ( DateTime.TryParseExact(str, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) )
        GoToDate(date, scroll: ViewScrollOverride.NoTextReport);
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
  /// Event handler. Called by LabelEnumsAsTranslations for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void LabelEnumsAsTranslations_Click(object sender, EventArgs e)
  {
    EditExportDataEnumsAsTranslations.Checked = !EditExportDataEnumsAsTranslations.Checked;
  }

  /// <summary>
  /// Event handler. Called by EditExportDataEnumsAsTranslations for checked changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void EditExportDataEnumsAsTranslations_CheckedChanged(object sender, EventArgs e)
  {
    Settings.ExportDataEnumsAsTranslations = EditExportDataEnumsAsTranslations.Checked;
    DataGridView.Invalidate();
  }

  /// <summary>
  /// Event handler. Called by CalendarGrid for cell formatting events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void CalendarGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
  {
    if ( e.ColumnIndex == GridColumnMoonriseOccuring.Index )
      e.Value = ( (MoonriseOccurring)e.Value ).ToStringExport(AppTranslations.MoonriseOccurings);
    else
    if ( e.ColumnIndex == GridColumnNewMoon.Index || e.ColumnIndex == GridColumnFullMoon.Index )
      e.Value = (bool)e.Value
        ? Globals.Bullet
        : string.Empty;
    else
    if ( e.ColumnIndex == GridColumnMoonPhase.Index )
      e.Value = ( (MoonPhase)e.Value ).ToStringExport(AppTranslations.MoonPhases);
    else
    if ( e.ColumnIndex == GridColumnSeasonChange.Index )
    {
      var season = (SeasonChange)e.Value;
      e.Value = season == SeasonChange.None
        ? string.Empty
        : season.ToStringExport(AppTranslations.SeasonChanges);
    }
    else if ( e.ColumnIndex == GridColumnTorahEvent.Index )
    {
      var torah = (TorahCelebrationDay)e.Value;
      e.Value = torah == TorahCelebrationDay.None
        ? string.Empty
        : torah.ToStringExport(AppTranslations.CelebrationDays);
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
  private void TimerMidnight_Tick(DateTime time)
  {
    DoTimerMidnight();
  }

  #endregion

  #region Context Menu

  private bool ContextMenuStripDayNoClose;

  private void CalendarMonth_MouseClick(object sender, MouseEventArgs e)
  {
    DoCalendarMonth_MouseClick(sender, e);
  }

  private void ContextMenuDayDate_MouseDown(object sender, MouseEventArgs e)
  {
    ContextMenuStripDayNoClose = true;
  }

  private void ContextMenuStripDay_Closing(object sender, ToolStripDropDownClosingEventArgs e)
  {
    if ( ContextMenuStripDayNoClose )
    {
      ContextMenuStripDayNoClose = false;
      e.Cancel = true;
    }
  }

  private void ContextMenuStripDay_Opened(object sender, EventArgs e)
  {
    DoContextMenuStripDay_Opened(sender, e);
  }

  private void ContextMenuDayNavigation_Click(object sender, EventArgs e)
  {
    if ( !NavigationForm.Instance.Visible )
      ActionNavigate.PerformClick();
    else
      NavigationForm.Instance.Popup();
    NavigationForm.Instance.Date = ContextMenuDayCurrentEvent.Date;
  }

  private void ContextMenuDayCelebrationVersesBoard_Click(object sender, EventArgs e)
  {
    CelebrationVersesBoardForm.Run((TorahCelebration)ContextMenuDayCelebrationVersesBoard.Tag,
                                    nameof(Settings.CelebrationVersesBoardFormLocation),
                                    nameof(Settings.CelebrationVersesBoardFormClientSize),
                                    Settings.OpenVerseOnlineURL,
                                    Settings.DoubleClickOnVerseOpenDefaultReader,
                                    value => Settings.DoubleClickOnVerseOpenDefaultReader = value);
  }

  private void ActionShowShabatVerses_Click(object sender, EventArgs e)
  {
    CelebrationVersesBoardForm.Run(TorahCelebration.Shabat,
                                   nameof(Settings.CelebrationVersesBoardFormLocation),
                                   nameof(Settings.CelebrationVersesBoardFormClientSize),
                                   Settings.OpenVerseOnlineURL,
                                   Settings.DoubleClickOnVerseOpenDefaultReader,
                                   value => Settings.DoubleClickOnVerseOpenDefaultReader = value);
  }

  private void ContextMenuDayParashah_Click(object sender, EventArgs e)
  {
    if ( ContextMenuDayCurrentEvent.GetParashahReadingDay() is LunisolarDay day )
      if ( ParashotFactory.Instance.Get(day.ParashahID) is Parashah parashah )
        if ( sender == ContextMenuDayParashahDescription )
          UserParashot.ShowDescription(parashah, day.HasLinkedParashah, () => ParashotForm.Run(parashah));
        else
        if ( sender == ContextMenuDayParashotBoard )
          ParashotForm.Run(parashah);
  }

  private void ContextMenuOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    if ( ContextMenuDayCurrentEvent.GetParashahReadingDay() is LunisolarDay day )
      if ( ParashotFactory.Instance.Get(day.ParashahID) is Parashah parashah )
        HebrewTools.OpenHebrewWordsGoToVerse(parashah.FullReferenceBegin);
  }

  private void CalendarMonth_MouseMove(object sender, MouseEventArgs e)
  {
    if ( IsCalendarReady ) return;
    if ( TimerMutex ) return;
    MonthlyCalendar.Refresh();
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
      if ( MonthlyCalendar.CalendarDate.Month != DateSelected.Value.Month )
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
    if ( _DateSelected is not null ) ContextMenuDayDatesDiffTo(_DateSelected.Value);
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
    foreach ( ToolStripMenuItem menuitem in ContextMenuDayGoToBookmark.DropDownItems )
    {
      var value = Program.DateBookmarks[(int)menuitem.Tag];
      if ( value == DateTime.MinValue ) menuitem.Enabled = false;
    }
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
    if ( ManageBookmarksForm.Run() ) LoadMenuBookmarks(this);
  }

  private void ContextMenuParashahReadDefault_Click(object sender, EventArgs e)
  {
    DoReadParashahSomeWeek(Settings.OpenVerseOnlineURL);
  }

  #endregion

}
