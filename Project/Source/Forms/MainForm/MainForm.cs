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
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using EnumsNET;
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
    /// Indicate the singleton instance.
    /// </summary>
    static public MainForm Instance { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static MainForm()
    {
      Instance = new MainForm();
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    private MainForm()
    {
      InitializeComponent();
      SoundItem.Initialize();
      SystemEvents.SessionEnding += SessionEnding;
      SystemEvents.PowerModeChanged += (s, e) =>
      {
        if ( e.Mode == PowerModes.Resume )
        {
          System.Threading.Thread.Sleep(5000);
          DoTimerMidnight();
        }
      };
      SystemManager.TryCatch(() =>
      {
        Icon = new Icon(Globals.ApplicationIconFilePath);
        TrayIconPause = new Icon(Globals.ApplicationPauseIconFilePath).GetBySize(16, 16);
        TrayIconEvent = new Icon(Globals.ApplicationEventIconFilePath).GetBySize(16, 16);
        TrayIconDefault = Icon.GetBySize(16, 16);
        TrayIcon.Icon = TrayIconDefault;
      });
      MenuTray.Enabled = false;
      Globals.AllowClose = false;
      foreach ( var value in Enums.GetValues<TorahEvent>() )
        LastCelebrationReminded.Add(value, null);
      if ( !Globals.IsDevExecutable ) // TODO remove when ready
      {
        ActionShowParashahNotice.Visible = false;
        ActionShowParashahNotice.Tag = int.MinValue;
        ActionViewParashot.Visible = false;
        ActionViewParashot.Tag = int.MinValue;
        ActionViewMoonMonths.Visible = false;
        SeparatorToolsMenuTop.Visible = false;
        ActionViewMoonMonths.Tag = int.MinValue;
        SeparatorToolsMenuTop.Tag = int.MinValue;
      }
    }

    /// <summary>
    /// Event handler. Called by MainForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Load(object sender, EventArgs e)
    {
      DoMainForm_Load(sender, e);
    }

    /// <summary>
    /// Event handler. Called by MainForm for shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Shown(object sender, EventArgs e)
    {
      DoMainForm_Shown(sender, e);
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing ) return;
      if ( !Globals.IsReady ) return;
      if ( Globals.IsExiting ) return;
      if ( Globals.AllowClose ) return;
      e.Cancel = true;
      MenuShowHide.PerformClick();
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      DebugManager.Enter();
      DebugManager.Trace(LogTraceEvent.Data, e.CloseReason.ToStringFull());
      try
      {
        Settings.Store();
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    /// <summary>
    /// Session ending events handler.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Session ending event information.</param>
    internal void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      DoSessionEnding(sender, e);
    }

    /// <summary>
    /// Power mode changed events handler.
    /// </summary>
    private void PowerModeChanged(object s, PowerModeChangedEventArgs e)
    {
      if ( e.Mode == PowerModes.Resume )
      {
        System.Threading.Thread.Sleep(5000);
        DoTimerMidnight();
      }
    }

    /// <summary>
    /// Enable double-buffering.
    /// </summary>
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        if ( Settings.WindowsDoubleBufferingEnabled )
          switch ( Settings.CurrentView )
          {
            case ViewMode.Text:
            case ViewMode.Month:
              cp.ExStyle |= 0x02000000; // + WS_EX_COMPOSITED
              //cp.Style &= ~0x02000000;  // - WS_CLIPCHILDREN
              break;
          }
        return cp;
      }
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

    /// <summary>
    /// Event handler. Called by MenuExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuExit_Click(object sender, EventArgs e)
    {
      if ( IsGenerating )
      {
        DisplayManager.ShowInformation(SysTranslations.CantExitWhileGenerating.GetLang());
        return;
      }
      if ( EditConfirmClosing.Checked || ( e == null && !Globals.IsDevExecutable ) )
        if ( !DisplayManager.QueryYesNo(SysTranslations.AskToExitApplication.GetLang()) )
          return;
      Globals.AllowClose = true;
      Close();
    }

    /// <summary>
    /// Event handler. Called by ActionAbout for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void ActionAbout_Click(object sender, EventArgs e)
    {
      if ( AboutBox.Instance.Visible )
        AboutBox.Instance.BringToFront();
      else
        AboutBox.Instance.ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by ActionWebCheckUpdate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void ActionWebCheckUpdate_Click(object sender, EventArgs e)
    {
      bool menuEnabled = MenuTray.Enabled;
      try
      {
        MenuTray.Enabled = false;
        var lastdone = Settings.CheckUpdateLastDone;
        bool exit = WebCheckUpdate.Run(Settings.CheckUpdateAtStartup,
                                       ref lastdone,
                                       Settings.CheckUpdateAtStartupDaysInterval,
                                       e == null);
        Settings.CheckUpdateLastDone = lastdone;
        if ( exit )
        {
          Globals.AllowClose = true;
          Close();
        }
        else
        if ( Visible )
          BringToFront();
      }
      finally
      {
        MenuTray.Enabled = menuEnabled;
      }
    }

    /// <summary>
    /// Event handler. Called by ActionPreferences for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionPreferences_Click(object sender, EventArgs e)
    {
      bool formEnabled = Globals.MainForm.Enabled;
      try
      {
        Enabled = false;
        ActionPreferences.Visible = false;
        ActionPreferences.Visible = true;
        TimerReminder.Enabled = false;
        MenuTray.Enabled = false;
        ClearLists();
        if ( PreferencesForm.Run() )
        {
          UpdateText();
          CodeProjectCalendar.NET.Calendar.CurrentDayForeColor = Settings.CurrentDayForeColor;
          CodeProjectCalendar.NET.Calendar.CurrentDayBackColor = Settings.CurrentDayBackColor;
          UpdateCalendarMonth(false);
          ActionGenerate_Click(null, EventArgs.Empty);
        }
        TimerBallon.Interval = Settings.BalloonLoomingDelay;
        CalendarMonth.ShowEventTooltips = Settings.MonthViewSunToolTips;
        InitializeSpecialMenus();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      finally
      {
        Enabled = formEnabled;
        MenuTray.Enabled = true;
        GoToDate(DateTime.Now.Date);
        EnableReminder();
      }
    }

    /// <summary>
    /// Event handler. Called by MenuShowHide for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void MenuShowHide_Click(object sender, EventArgs e)
    {
      DoMenuShowHide_Click(sender, e);
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
      CanBallon = !MenuTray.Visible;
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
      TrayIcon.Text = Settings.BalloonEnabled ? "" : Text;
      if ( !Settings.BalloonEnabled || Settings.TrayIconClickOpen == TrayIconClickOpen.NavigationForm )
        return;
      TimerBallon.Start();
      TrayIconMouse = Cursor.Position;
      if ( !TimerTrayMouseMove.Enabled && Settings.BalloonAutoHide )
        TimerTrayMouseMove.Start();
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
      if ( NavigationForm.Instance.Visible && NavigationTrayBallooned )
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
      if ( !CanBallon ) return;
      if ( !NavigationForm.Instance.Visible )
        if ( !Visible || !Settings.BalloonOnlyIfMainFormIsHidden )
          ActionNavigate_Click(null, null);
    }

    /// <summary>
    /// Event handler. Called by TimerTooltip for tick events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void TimerTooltip_Tick(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      var item = (ToolStripItem)LastToolTip.Tag;
      var location = new Point(item.Bounds.Left, item.Bounds.Top + ActionSaveToFile.Height + 5);
      LastToolTip.Tag = sender;
      LastToolTip.Show(item.ToolTipText, ToolStrip, location, 3000);
      TimerTooltip.Enabled = false;
    }

    /// <summary>
    /// Show tooltip on mouse enter event.
    /// </summary>
    private void ShowToolTipOnMouseEnter(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      if ( !( sender is ToolStripItem ) ) return;
      if ( LastToolTip.Tag == sender ) return;
      LastToolTip.Tag = sender;
      if ( ( (ToolStripItem)sender ).ToolTipText == "" ) return;
      TimerTooltip.Enabled = true;
    }

    /// <summary>
    /// Hide tooltip on mouse leave event.
    /// </summary>
    private void ShowToolTipOnMouseLeave(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      TimerTooltip.Enabled = false;
      LastToolTip.Tag = null;
      LastToolTip.Hide(ToolStrip);
    }

    /// <summary>
    /// Event handler. Called by EditDialogBoxesSettings for checked changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void EditDialogBoxesSettings_CheckedChanged(object sender, EventArgs e)
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
      Settings.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
      DisplayManager.ShowSuccessDialogs = EditShowSuccessDialogs.Checked;
    }

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
    /// Event handler. Called by ActionSelectReminderBoxSound for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSelectReminderBoxSound_Click(object sender, EventArgs e)
    {
      SelectSoundForm.Run();
    }

    /// <summary>
    /// Event handler. Called by EditScreenPosition for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void EditScreenPosition_Click(object sender, EventArgs e)
    {
      DoScreenPosition(sender, e);
    }

    /// <summary>
    /// Event handler. Called by ActionExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExit_Click(object sender, EventArgs e)
    {
      MenuShowHide.PerformClick();
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

    /// <summary>
    /// Show a notice.
    /// </summary>
    private void ShowNotice(object sender, TranslationsDictionary title, TranslationsDictionary text, int width)
    {
      var form = MessageBoxEx.Instances.FirstOrDefault(f => f.Text == title.GetLang());
      if ( form == null )
        form = new MessageBoxEx(title, text, width); form.ShowInTaskbar = true;
      form.Popup(null, sender == null);
    }

    /// <summary>
    /// Event handler. Called by ActionShowCelebrationsNotice for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void ActionShowCelebrationsNotice_Click(object sender, EventArgs e)
    {
      ShowNotice(sender,
                 AppTranslations.NoticeCelebrationsTitle,
                 AppTranslations.NoticeCelebrations,
                 MessageBoxEx.DefaultMediumWidth);
    }

    /// <summary>
    /// Event handler. Called by ActionShowShabatNotice for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void ActionShowShabatNotice_Click(object sender, EventArgs e)
    {
      ShowNotice(sender,
                 AppTranslations.NoticeShabatTitle,
                 AppTranslations.NoticeShabat,
                 MessageBoxEx.DefaultLargeWidth);
    }

    /// <summary>
    /// Event handler. Called by ActionShowParashahNotice for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionShowParashahNotice_Click(object sender, EventArgs e)
    {
      ShowNotice(sender,
                 HebrewTranslations.NoticeParashahTitle,
                 HebrewTranslations.NoticeParashah,
                 MessageBoxEx.DefaultMediumWidth);
    }

    /// <summary>
    /// Event handler. Called by ActionShowKeyboardNotice for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionShowKeyboardNotice_Click(object sender, EventArgs e)
    {
      NoticeKeyboardShortcutsForm.Popup();
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
    /// Event handler. Called by ActionViewMoonMonths for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewMoonMonths_Click(object sender, EventArgs e)
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
      ParashotForm.Run();
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
    /// Event handler. Called by ActionGenerate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionGenerate_Click(object sender, EventArgs e)
    {
      MenuShowHide_Click(null, null);
      SystemManager.TryCatchManage(() => DoGenerate(sender, e));
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
    /// Event handler. Called by ActionVacuumAtNextStartup for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionVacuumAtNextStartup_Click(object sender, EventArgs e)
    {
      if ( LastVacuum == null ) LastVacuum = Settings.VacuumLastDone;
      Settings.VacuumLastDone = ActionVacuumAtNextStartup.Checked ? DateTime.MinValue : LastVacuum.Value;
    }

    /// <summary>
    /// Event handler. Called by ActionViewStats for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewStats_Click(object sender, EventArgs e)
    {
      StatisticsForm.Run();
    }

    /// <summary>
    /// Event handler. Called by ActionViewLog for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewLog_Click(object sender, EventArgs e)
    {
      DebugManager.TraceForm.Popup();
    }

    /// <summary>
    /// Event handler. Called by ActionSearchDay for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSearchDay_Click(object sender, EventArgs e)
    {
      DateTime date = DateTime.Today;
      if ( sender != null )
        if ( !SelectDayForm.Run(null, ref date, false, true, true) )
          return;
      GoToDate(date);
    }

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
    /// Event handler. Called by ActionSearchEvent for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSearchEvent_Click(object sender, EventArgs e)
    {
      new SearchEventForm().ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by ActionSearchMonth for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSearchMonth_Click(object sender, EventArgs e)
    {
      new SearchLunarMonthForm().ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by ActionSearchGregorianMonth for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSearchGregorianMonth_Click(object sender, EventArgs e)
    {
      new SearchGregorianMonthForm().ShowDialog();
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
        NavigationTrayBallooned = sender == null;
        if ( NavigationForm.Instance.Visible )
        {
          NavigationForm.Instance.Hide();
        }
        else
        {
          if ( Settings.MainFormShownGoToToday )
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
      if ( NextCelebrationsForm.Instance != null && NextCelebrationsForm.Instance.Visible )
        NextCelebrationsForm.Instance.BringToFront();
      else
        NextCelebrationsForm.Run();
    }

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
      EnableReminder();
    }

    /// <summary>
    /// Event handler. Called by MenuDisableReminder for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuDisableReminder_Click(object sender, EventArgs e)
    {
      DisableReminder();
    }

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
    }

    /// <summary>
    /// Event handler. Called by EditExportDataEnumsAsTranslations for checked changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void EditExportDataEnumsAsTranslations_CheckedChanged(object sender, EventArgs e)
    {
      CalendarGrid.Invalidate();
    }

    /// <summary>
    /// Event handler. Called by CalendarGrid for cell formatting events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void CalendarGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      SystemManager.TryCatch(() =>
      {
        switch ( e.ColumnIndex )
        {
          case 7:
            e.Value = ( (MoonRiseOccuring)e.Value ).ToString();
            break;
          case 10:
            e.Value = ( (MoonPhase)e.Value ).ToStringExport(AppTranslations.MoonPhase);
            break;
          case 8:
            e.Value = (int)e.Value == 0 ? "" : "*";
            break;
          case 9:
            e.Value = (int)e.Value == 0 ? "" : "*";
            break;
          case 11:
            var season = (SeasonChange)e.Value;
            e.Value = season == SeasonChange.None ? "" : season.ToStringExport(AppTranslations.SeasonChange);
            break;
          case 12:
            var torah = (TorahEvent)e.Value;
            e.Value = torah == TorahEvent.None ? "" : torah.ToStringExport(AppTranslations.TorahEvent);
            break;
        }
      });
    }

    /// <summary>
    /// Event handler. Called by LunisolarDaysBindingSource for current item changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void LunisolarDaysBindingSource_CurrentItemChanged(object sender, EventArgs e)
    {
      SystemManager.TryCatch(() =>
      {
        if ( LunisolarDaysBindingSource.Current != null )
        {
          var rowview = ( (DataRowView)LunisolarDaysBindingSource.Current ).Row;
          GoToDate(SQLiteDate.ToDateTime(( (Data.DataSet.LunisolarDaysRow)rowview ).Date));
        }
      });
    }

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
    private void TimerMidnight_Tick(DateTime Time)
    {
      DoTimerMidnight();
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
      OpenOlineWeather();
    }

  }

}
