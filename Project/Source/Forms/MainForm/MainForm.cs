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
using System.Xml;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Win32;
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

    private Stopwatch ChronoStart = new Stopwatch();

    /// <summary>
    /// Default constructor.
    /// </summary>
    private MainForm()
    {
      InitializeComponent();
      Text = Globals.AssemblyTitle;
      SystemEvents.SessionEnding += SessionEnding;
      try { Icon = Icon.ExtractAssociatedIcon(Globals.ApplicationIconFilename); }
      catch { }
      TrayIcon.Icon = Icon;
      MenuTray.Enabled = false;
      Globals.AllowClose = false;
      foreach ( TorahEvent value in Enum.GetValues(typeof(TorahEvent)) )
        LastCelebrationReminded.Add(value, null);
      ActionViewMoonMonths.Visible = Globals.IsDev; // TODO remove when ready
      ActionViewMoonMonthsSeparator.Visible = Globals.IsDev; // TODO remove when ready
      ChronoStart.Start();
    }

    /// <summary>
    /// Event handler. Called by MainForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Load(object sender, EventArgs e)
    {
      if ( Globals.IsExiting ) return;
      Settings.Retrieve();
      StatisticsForm.Run(true);
      if ( !string.IsNullOrEmpty(Settings.GPSLatitude)
        && !string.IsNullOrEmpty(Settings.GPSLongitude) )
        try
        {
          Instance.CurrentGPSLatitude = (float)XmlConvert.ToDouble(Settings.GPSLatitude);
          Instance.CurrentGPSLongitude = (float)XmlConvert.ToDouble(Settings.GPSLongitude);
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
      var lastdone = Settings.CheckUpdateLastDone;
      bool exit = WebCheckUpdate.Run(Settings.CheckUpdateAtStartup, ref lastdone, true);
      Settings.CheckUpdateLastDone = lastdone;
      if ( exit ) return;
      ActionViewLog.Enabled = DebugManager.Enabled;
      CalendarText.ForeColor = Settings.TextColor;
      CalendarText.BackColor = Settings.TextBackground;
      InitializeCalendarUI();
      InitializeCurrentTimeZone();
      InitializeDialogsDirectory();
      Refresh();
      ClearLists();
      LoadData();
    }

    /// <summary>
    /// Event handler. Called by MainForm for shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Shown(object sender, EventArgs e)
    {
      DebugManager.Enter();
      try
      {
        if ( Globals.IsExiting ) return;
        UpdateTextCalendar();
        CalendarMonth.CalendarDateChanged += date => GoToDate(date);
        MenuShowHide.Text = Localizer.HideRestore.GetLang(Visible);
        Globals.IsReady = true;
        UpdateButtons();
        GoToDate(DateTime.Today);
        CheckRegenerateCalendar();
        if ( string.IsNullOrEmpty(Settings.GPSLatitude)
          || string.IsNullOrEmpty(Settings.GPSLongitude) )
          ActionPreferences.PerformClick();
        if ( Settings.StartupHide )
          MenuShowHide.PerformClick();
        TimerBallon.Interval = Settings.BalloonLoomingDelay;
        TimerMidnight.TimeReached += TimerMidnight_Tick;
        TimerMidnight.Start();
        TimerReminder_Tick(null, null);
        ChronoStart.Stop();
        Settings.BenchmarkStartingApp = ChronoStart.ElapsedMilliseconds;
        Settings.Save();
        BringToFront();
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      DebugManager.Enter();
      DebugManager.Log(LogEvent.Data, e.CloseReason.ToStringFull());
      try
      {
        if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing ) return;
        if ( !Globals.IsReady ) return;
        if ( Globals.IsExiting ) return;
        if ( Globals.AllowClose ) return;
        e.Cancel = true;
        MenuShowHide.PerformClick();
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      DebugManager.Enter();
      DebugManager.Log(LogEvent.Data, e.CloseReason.ToStringFull());
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
    /// Session ending event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Session ending event information.</param>
    internal void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      DebugManager.Enter();
      DebugManager.Log(LogEvent.Data, e.Reason.ToStringFull());
      try
      {
        if ( Globals.IsSessionEnding ) return;
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
        try { ClearLists(); }
        catch { }
        try
        {
          foreach ( Form form in Application.OpenForms )
            if ( form != this && form.Visible )
              try { form.Close(); }
              catch { }
        }
        catch
        {
        }
        Close();
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    /// <summary>
    /// Event handler. Called by MainForm for windows changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_WindowsChanged(object sender, EventArgs e)
    {
      if ( !Globals.IsReady ) return;
      if ( !Visible ) return;
      if ( Globals.IsExiting ) return;
      Settings.Store();
      if ( WindowState != FormWindowState.Normal ) return;
      EditScreenNone.PerformClick(); // TODO don't call if minimized
    }

    /// <summary>
    /// Event handler. Called by MenuExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuExit_Click(object sender, EventArgs e)
    {
      DebugManager.Enter();
      try
      {
        if ( IsGenerating )
        {
          DisplayManager.ShowInformation(Translations.CantExitWhileGenerating.GetLang());
          return;
        }
        if ( EditConfirmClosing.Checked || ( e == null && !Globals.IsDev ) )
          if ( !DisplayManager.QueryYesNo(Localizer.AskToExitApplication.GetLang()) )
            return;
        Globals.AllowClose = true;
        Close();
      }
      finally
      {
        DebugManager.Leave();
      }
    }

    /// <summary>
    /// Event handler. Called by MenuShowHide for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void MenuShowHide_Click(object sender, EventArgs e)
    {
      DebugManager.Enter();
      try
      {
        if ( Visible && WindowState == FormWindowState.Minimized )
        {
          WindowState = Settings.MainFormState;
          var old = TopMost;
          TopMost = true;
          BringToFront();
          Show();
          TopMost = old;
        }
        else
        if ( !Visible || e == null )
        {
          FormBorderStyle = FormBorderStyle.Sizable;
          Visible = true;
          ShowInTaskbar = true;
          bool temp = Globals.IsReady;
          try
          {
            Globals.IsReady = false;
            WindowState = Settings.MainFormState;
          }
          finally
          {
            Globals.IsReady = temp;
          }
          if ( Globals.IsReady )
          {
            var old = TopMost;
            TopMost = true;
            BringToFront();
            Show();
            TopMost = old;
          }
          if ( !NavigationForm.Instance.Visible )
            GoToDate(DateTime.Today);
        }
        else
        {
          Settings.MainFormState = WindowState;
          WindowState = FormWindowState.Minimized;
          Visible = false;
          ShowInTaskbar = false;
          FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }
        MenuShowHide.Text = Localizer.HideRestore.GetLang(Visible);
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      finally
      {
        DebugManager.Leave();
      }
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
        ActionNavigate_Click(null, null);
    }

    /// <summary>
    /// Event handler. Called by TrayIcon for mouse click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Mouse event information.</param>
    private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
    {
      try
      {
        TimerBallon.Stop();
        TimerTrayMouseMove.Stop();
        if ( e == null ) return;
        if ( e.Button == MouseButtons.Left )
          switch ( Settings.TrayIconClickOpen )
          {
            case TrayIconClickOpen.MainForm:
              MenuShowHide_Click(TrayIcon, MenuTray.Enabled ? new EventArgs() : null);
              break;
            case TrayIconClickOpen.NextCelebrationsForm:
              if ( CelebrationsForm.Instance != null && CelebrationsForm.Instance.Visible )
                CelebrationsForm.Instance.Close();
              else
                ActionViewCelebrations.PerformClick();
              break;
            case TrayIconClickOpen.NavigationForm:
              var form = NavigationForm.Instance;
              if ( form.Visible )
                form.Visible = false;
              else
                try
                {
                  form.Date = DateTime.Today;
                  form.Visible = true;
                }
                catch ( Exception ex )
                {
                  ex.Manage();
                }
              break;
            default:
              throw new NotImplementedExceptionEx(Settings.TrayIconClickOpen.ToStringFull());
          }
        else
        if ( e.Button == MouseButtons.Right )
          if ( NavigationForm.Instance.Visible )
            ActionNavigate.PerformClick();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
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
      var location = new Point(item.Bounds.Left, item.Bounds.Top + ActionSaveReport.Height + 5);
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
    /// Event handler. Called by ActionResetWinSettings for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionResetWinSettings_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(Localizer.AskToRestoreWindowPosition.GetLang()) )
        Settings.RestoreMainForm();
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
          CalendarMonth.CurrentDayForeColor = Settings.CurrentDayForeColor;
          CalendarMonth.CurrentDayBackColor = Settings.CurrentDayBackColor;
          UpdateCalendarMonth(false);
          ActionGenerate_Click(null, new EventArgs());
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
        TimerReminder.Enabled = !MenuEnableReminder.Enabled;
        TimerReminder_Tick(null, null);
      }
    }

    /// <summary>
    /// Event handler. Called by ActionAbout for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionAbout_Click(object sender, EventArgs e)
    {
      if ( AboutBox.Instance.Visible )
        AboutBox.Instance.BringToFront();
      else
        AboutBox.Instance.ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by ActionHelp for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionHelp_Click(object sender, EventArgs e)
    {
      Shell.Run(Globals.HelpFilename);
    }

    /// <summary>
    /// Event handler. Called by ActionApplicationHome for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionApplicationHome_Click(object sender, EventArgs e)
    {
      Shell.OpenApplicationHome();
    }

    /// <summary>
    /// Event handler. Called by ActionWebReleaseNotes for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionWebReleaseNotes_Click(object sender, EventArgs e)
    {
      Shell.OpenApplicationReleaseNotes();
    }

    /// <summary>
    /// Event handler. Called by ActionContact for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionContact_Click(object sender, EventArgs e)
    {
      Shell.OpenContactPage();
    }

    /// <summary>
    /// Event handler. Called by ActionWebCheckUpdate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionWebCheckUpdate_Click(object sender, EventArgs e)
    {
      bool menuEnabled = MenuTray.Enabled;
      try
      {
        MenuTray.Enabled = false;
        var lastdone = Settings.CheckUpdateLastDone;
        bool exit = WebCheckUpdate.Run(Settings.CheckUpdateAtStartup, ref lastdone, e == null);
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
    /// Event handler. Called by ActionCreateGitHubIssue for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionCreateGitHubIssue_Click(object sender, EventArgs e)
    {
      Shell.CreateGitHubIssue();
    }

    /// <summary>
    /// Event handler. Called by ActionOpenWebsiteURL for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionOpenWebsiteURL_Click(object sender, EventArgs e)
    {
      Shell.OpenWebLink((string)( (ToolStripItem)sender ).Tag);
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
    /// Event handler. Called by ActionShowShabatNotice for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionShowShabatNotice_Click(object sender, EventArgs e)
    {
      Program.ShabatNoticeForm.Show();
    }

    /// <summary>
    /// Event handler. Called by ActionShowCelebrationsNotice for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionShowCelebrationsNotice_Click(object sender, EventArgs e)
    {
      Program.CelebrationsNoticeForm.Show();
    }

    /// <summary>
    /// Event handler. Called by ActionViewMoonMonths for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewMoonMonths_Click(object sender, EventArgs e)
    {
      MoonMonthsForm.Run();
    }

    /// <summary>
    /// Event handler. Called by ActionOpenCalculator for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionOpenCalculator_Click(object sender, EventArgs e)
    {
      Shell.Run("calc.exe");
    }

    /// <summary>
    /// Event handler. Called by ActionOpenSystemDateAndTime for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionOpenSystemDateAndTime_Click(object sender, EventArgs e)
    {
      Shell.Run("timedate.cpl");
    }

    /// <summary>
    /// Event handler. Called by ActionCalculateDateDiff for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionCalculateDateDiff_Click(object sender, EventArgs e)
    {
      DatesDiffForm.Run();
    }

    /// <summary>
    /// Event handler. Called by ActionGenerate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionGenerate_Click(object sender, EventArgs e)
    {
      MenuShowHide_Click(null, null);
      try
      {
        DoGenerate(sender, e);
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    private DateTime? LastVacuum = null;

    /// <summary>
    /// Event handler. Called by ActionVacuumAtNextStartup for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionVacuumAtNextStartup_Click(object sender, EventArgs e)
    {
      if ( LastVacuum == null )
        LastVacuum = Settings.VacuumLastDone;
      if ( ActionVacuumAtNextStartup.Checked )
        Settings.VacuumLastDone = new DateTime(2020, 1, 1);
      else
        Settings.VacuumLastDone = LastVacuum.Value;
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
      DebugManager.LogForm.Show();
      DebugManager.LogForm.BringToFront();
    }

    /// <summary>
    /// Event handler. Called by ActionCopyReportToClipboard for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionCopyReportToClipboard_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(CalendarText.Text);
    }

    /// <summary>
    /// Event handler. Called by ActionPrint for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionPrint_Click(object sender, EventArgs e)
    {
      SetView(ViewMode.Month);
      CalendarMonth.ShowTodayButton = false;
      CalendarMonth.ShowArrowControls = false;
      try
      {
        var bitmap = new Bitmap(CalendarMonth.Width, CalendarMonth.Height);
        CalendarMonth.DrawToBitmap(bitmap, new Rectangle(0, 0, CalendarMonth.Width, CalendarMonth.Height));
        bitmap = bitmap.Resize(1000, CalendarMonth.Height * 1000 / CalendarMonth.Width);
        using ( var document = new PrintDocument() )
        {
          document.DefaultPageSettings.Landscape = true;
          document.PrintPage += (s, ev) => ev.Graphics.DrawImage(bitmap, 75, 75);
          PrintDialog.Document = document;
          if ( PrintDialog.ShowDialog() == DialogResult.Cancel ) return;
          try
          {
            document.Print();
          }
          catch ( Exception ex )
          {
            ex.Manage();
          }
        }
      }
      finally
      {
        CalendarMonth.ShowTodayButton = true;
        CalendarMonth.ShowArrowControls = true;
      }
    }

    /// <summary>
    /// Event handler. Called by ActionSaveReport for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSaveReport_Click(object sender, EventArgs e)
    {
      if ( SaveFileDialog.ShowDialog() != DialogResult.OK ) return;
      File.WriteAllText(SaveFileDialog.FileName, CalendarText.Text);
      if ( Settings.AutoOpenExportFolder )
        Shell.Run(Path.GetDirectoryName(SaveFileDialog.FileName));
    }

    /// <summary>
    /// Event handler. Called by ActionExportCSV for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExportCSV_Click(object sender, EventArgs e)
    {
      var content = GenerateCSV();
      if ( content == null ) return;
      if ( SaveCSVDialog.ShowDialog() != DialogResult.OK ) return;
      File.WriteAllText(SaveCSVDialog.FileName, content.ToString());
      if ( Settings.AutoOpenExportFolder )
        Shell.Run(Path.GetDirectoryName(SaveCSVDialog.FileName));
    }

    /// <summary>
    /// Event handler. Called by ActionSearchDay for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSearchDay_Click(object sender, EventArgs e)
    {
      DateTime date;
      if ( sender == null )
        date = DateTime.Today;
      else
      {
        var form = new SelectDayForm(true, true);
        if ( form.ShowDialog() != DialogResult.OK ) return;
        date = form.MonthCalendar.SelectionStart;
      }
      GoToDate(date);
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
      retry:
      try
      {
        TimerBallon.Stop();
        NavigationTrayBallooned = sender == null;
        if ( NavigationForm.Instance.Visible )
        {
          NavigationForm.Instance.Hide();
        }
        else
        {
          GoToDate(DateTime.Today);
          NavigationForm.Instance.Show();
          NavigationForm.Instance.BringToFront();
        }
      }
      catch ( ObjectDisposedException )
      {
        NavigationForm.Instance = new NavigationForm();
        goto retry;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Event handler. Called by ActionViewCelebrations for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewCelebrations_Click(object sender, EventArgs e)
    {
      if ( CelebrationsForm.Instance != null && CelebrationsForm.Instance.Visible )
        CelebrationsForm.Instance.BringToFront();
      else
        CelebrationsForm.Run();
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
      TimerResumeReminder.Enabled = false;
      TrayIcon.Icon = Icon;
      MenuResetReminder.Enabled = true;
      ActionResetReminder.Enabled = true;
      MenuEnableReminder.Visible = false;
      MenuDisableReminder.Visible = true;
      MenuEnableReminder.Enabled = false;
      MenuDisableReminder.Enabled = true;
      ActionEnableReminder.Visible = false;
      ActionDisableReminder.Visible = true;
      ActionEnableReminder.Enabled = false;
      ActionDisableReminder.Enabled = true;
      TimerReminder.Enabled = true;
      TimerReminder_Tick(null, null);
    }

    /// <summary>
    /// Event handler. Called by MenuDisableReminder for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuDisableReminder_Click(object sender, EventArgs e)
    {
      try
      {
        MenuTray.Enabled = false;
        var delay = SelectSuspendDelayForm.Run();
        if ( delay == null ) return;
        TrayIcon.Icon = new Icon(Path.Combine(Globals.RootFolderPath, "ApplicationPause.ico"));
        TimerReminder.Enabled = false;
        MenuResetReminder.Enabled = false;
        ActionResetReminder.Enabled = false;
        MenuEnableReminder.Visible = true;
        MenuDisableReminder.Visible = false;
        MenuEnableReminder.Enabled = true;
        MenuDisableReminder.Enabled = false;
        ActionEnableReminder.Visible = true;
        ActionDisableReminder.Visible = false;
        ActionEnableReminder.Enabled = true;
        ActionDisableReminder.Enabled = false;
        ClearLists();
        if ( delay > 0 )
        {
          TimerResumeReminder.Interval = delay.Value * 60 * 1000;
          TimerResumeReminder.Start();
        }
      }
      finally
      {
        MenuTray.Enabled = true;
      }
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
    /// Event handler. Called by CalendarGrid for cell formatting events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void CalendarGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      try
      {
        switch ( e.ColumnIndex )
        {
          case 7:
            e.Value = ( (MoonRise)e.Value ).ToString();
            break;
          case 10:
            e.Value = Translations.MoonPhase.GetLang((MoonPhase)e.Value);
            break;
          case 8:
            e.Value = (int)e.Value == 0 ? "" : "*";
            break;
          case 9:
            e.Value = (int)e.Value == 0 ? "" : "*";
            break;
          case 11:
            var season = (SeasonChange)e.Value;
            e.Value = season == SeasonChange.None ? "" : Translations.SeasonEvent.GetLang(season);
            break;
          case 12:
            var torah = (TorahEvent)e.Value;
            e.Value = torah == TorahEvent.None ? "" : Translations.TorahEvent.GetLang(torah);
            break;
        }
      }
      catch
      {
      }
    }

    /// <summary>
    /// Event handler. Called by LunisolarDaysBindingSource for current item changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void LunisolarDaysBindingSource_CurrentItemChanged(object sender, EventArgs e)
    {
      try
      {
        if ( LunisolarDaysBindingSource.Current == null ) return;
        var rowview = ( (DataRowView)LunisolarDaysBindingSource.Current ).Row;
        GoToDate(SQLiteDate.ToDateTime(( (Data.DataSet.LunisolarDaysRow)rowview ).Date));
      }
      catch
      {
      }
    }

    /// <summary>
    /// Event handler. Called by TimerMidnight for tick events.
    /// </summary>
    private void TimerMidnight_Tick(DateTime Time)
    {
      if ( !Globals.IsReady ) return;
      this.SyncUI(() =>
      {
        System.Threading.Thread.Sleep(1000);
        CheckRegenerateCalendar();
        CalendarMonth.Refresh();
        if ( SQLiteDate.ToDateTime(CurrentDay.Date) == DateTime.Today.AddDays(-1) )
          GoToDate(DateTime.Today);
        if ( Settings.CheckUpdateEveryWeekWhileRunning )
          ActionWebCheckUpdate_Click(null, null);
      });
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
    /// Event handler. Called by TimerReminder for tick events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void TimerReminder_Tick(object sender, EventArgs e)
    {
      if ( TimerMutex ) return;
      if ( !Globals.IsReady ) return;
      if ( !TimerReminder.Enabled ) return;
      TimerMutex = true;
      try
      {
        if ( !IsForegroundFullScreenOrScreensaver() )
        {
          if ( Settings.ReminderShabatEnabled )
            CheckShabat();
          if ( Settings.ReminderCelebrationsEnabled )
          {
            CheckCelebrationDay();
            CheckEvents();
          }
        }
      }
      catch ( Exception ex )
      {
        if ( TimerErrorShown ) return;
        TimerErrorShown = true;
        ex.Manage();
      }
      finally
      {
        TimerMutex = false;
      }
    }

  }

}
