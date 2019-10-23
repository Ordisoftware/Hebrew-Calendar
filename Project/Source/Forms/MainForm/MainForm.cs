/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-10 </edited>
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Win32;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm : Form
  {

    /// <summary>
    /// Default constructor.
    /// </summary>
    private MainForm()
    {
      InitializeComponent();
      Text = AboutBox.Instance.AssemblyTitle;
      SystemEvents.SessionEnding += SessionEnding;
    }

    /// <summary>
    /// Event handler. Called by MainForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Load(object sender, EventArgs e)
    {
      TrayIcon.Icon = Icon;
      MenuShowHide.Image = Icon.ToBitmap();
      Program.Settings.Retrieve();
      foreach ( var item in TimeZoneInfo.GetSystemTimeZones() )
        if ( item.Id == Program.Settings.TimeZone )
        {
          CurrentTimeZoneInfo = item;
          break;
        }
      Refresh();
      LoadData();
      ClearLists();
    }

    /// <summary>
    /// Event handler. Called by MainForm for shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Shown(object sender, EventArgs e)
    {
      InitializeDialogsDirectory();
      UpdateTextCalendar();
      CalendarText.ForeColor = Program.Settings.TextColor;
      CalendarText.BackColor = Program.Settings.TextBackground;
      CalendarMonth.CurrentDayForeColor = Program.Settings.CurrentDayForeColor;
      CalendarMonth.CurrentDayBackColor = Program.Settings.CurrentDayBackColor;
      CalendarMonth.CalendarDateChanged += (date) =>
      {
        GoToDate(date);
      };
      UpdateButtons();
      MenuShowHide.Text = Translations.HideRestore.GetLang(Visible);
      IsReady = true;
      GoToDate(DateTime.Now);
      Program.CheckUpdate(true);
      CheckRegenerateCalendar();
      if ( Program.Settings.GPSLatitude == "" || Program.Settings.GPSLongitude == "" )
        ActionPreferences.PerformClick();
      if ( Program.Settings.StartupHide )
        MenuShowHide.PerformClick();
      TimerBallon.Interval = Program.Settings.BalloonLoomingDelay;
      Timer_Tick(null, null);
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( !IsReady ) return;
      if ( AllowClose ) return;
      e.Cancel = true;
      MenuShowHide.PerformClick();
    }

    /// <summary>
    /// Event handler. Called by MainForm_Form for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.Store();
    }

    private void MainForm_WindowsChanged(object sender, EventArgs e)
    {
      if ( !IsReady ) return;
      EditScreenNone.PerformClick();
    }

    /// <summary>
    /// Session ending.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Session ending event information.</param>
    private void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      try
      {
        ClearLists();
        foreach ( Form form in Application.OpenForms )
          if ( form != this && form.Visible )
            form.Close();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      AllowClose = true;
      Close();
    }

    /// <summary>
    /// Set the initial directories of dialog boxes.
    /// </summary>
    internal void InitializeDialogsDirectory()
    {
      SaveCSVDialog.InitialDirectory = Program.UserDocumentsFolderPath;
      SaveFileDialog.InitialDirectory = Program.UserDocumentsFolderPath;
    }

    private void CheckRegenerateCalendar()
    {
      try
      {
        if ( DateTime.Now.Year >= YearLast )
        {
          var diff = YearLast - YearFirst;
          if ( diff < SelectYearsForm.GenerateIntervalDefault )
            diff = SelectYearsForm.GenerateIntervalDefault;
          YearFirst = DateTime.Now.Year - 1;
          YearLast = YearFirst + diff;
          DoGenerate(null, new EventArgs());
        }
      }
      catch ( AbortException ex )
      {
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Event handler. Called by MenuShowHide for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuShowHide_Click(object sender, EventArgs e)
    {
      try
      {
        if ( !Visible )
        {
          FormBorderStyle = FormBorderStyle.Sizable;
          Visible = true;
          ShowInTaskbar = true;
          WindowState = Program.Settings.MainFormState;
          if ( IsReady )
          {
            var old = TopMost;
            TopMost = true;
            BringToFront();
            TopMost = old;
          }
          GoToDate(DateTime.Now);
        }
        else
        {
          Program.Settings.MainFormState = WindowState;
          WindowState = FormWindowState.Minimized;
          Visible = false;
          ShowInTaskbar = false;
          FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }
        MenuShowHide.Text = Translations.HideRestore.GetLang(Visible);
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    private void MenuTray_VisibleChanged(object sender, EventArgs e)
    {
      CanBallon = !MenuTray.Visible;
    }

    private void TrayIcon_MouseMove(object sender, MouseEventArgs e)
    {
      if ( !IsReady ) return;
      TrayIcon.Text = Program.Settings.BalloonEnabled ? "" : Text;
      if ( !Program.Settings.BalloonEnabled ) return;
      TimerBallon.Start();
      TrayIconMouse = Cursor.Position;
      if ( !TimerTrayMouseMove.Enabled && Program.Settings.BalloonAutoHide )
        TimerTrayMouseMove.Start();
    }

    private void TimerBallon_Tick(object sender, EventArgs e)
    {
      TimerBallon.Stop();
      if ( !CanBallon ) return;
      if ( !NavigationForm.Instance.Visible )
        ActionNavigate_Click(null, null);
    }

    private void TimerTrayMouseMove_Tick(object sender, EventArgs e)
    {
      if ( Cursor.Position != TrayIconMouse )
      {
        TimerBallon.Stop();
        TimerTrayMouseMove.Stop();
        if ( NavigationForm.Instance.Visible && NavigationTrayBallooned )
          ActionNavigate.PerformClick();
      }
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
          switch ( Program.Settings.TrayIconClickOpen )
          {
            case TrayIconClickOpen.MainForm:
              MenuShowHide.PerformClick();
              break;
            case TrayIconClickOpen.NavigationForm:
              var form = NavigationForm.Instance;
              if ( form.Visible )
                form.Visible = false;
              else
                try
                {
                  form.Date = DateTime.Now;
                  form.Visible = true;
                }
                catch ( Exception ex )
                {
                  ex.Manage();
                }
              break;
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
    /// Timer event for tooltips.
    /// </summary>
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
      SetView(ViewModeType.Text);
    }

    /// <summary>
    /// Event handler. Called by ActionViewMonth for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewMonth_Click(object sender, EventArgs e)
    {
      SetView(ViewModeType.Month);
    }

    /// <summary>
    /// Event handler. Called by ActionViewGrid for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewGrid_Click(object sender, EventArgs e)
    {
      SetView(ViewModeType.Grid);
    }

    /// <summary>
    /// Event handler. Called by ActionResetWinSettings for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionResetWinSettings_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(Translations.RestoreWinPos.GetLang()) )
        Program.Settings.RestoreMainForm();
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
      try
      {
        ClearLists();
        if ( PreferencesForm.Run() )
        {
          CalendarMonth.CurrentDayForeColor = Program.Settings.CurrentDayForeColor;
          CalendarMonth.CurrentDayBackColor = Program.Settings.CurrentDayBackColor;
          ActionGenerate_Click(null, new EventArgs());
        }
        TimerBallon.Interval = Program.Settings.BalloonLoomingDelay;
        CalendarMonth.ShowEventTooltips = Program.Settings.MonthViewSunToolTips;
        Timer_Tick(this, null);
      }
      catch ( Exception ex )
      {
        ex.Manage();
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
      Program.RunShell(Program.HelpFilename);
    }

    /// <summary>
    /// Event handler. Called by ActionApplicationHome for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionApplicationHome_Click(object sender, EventArgs e)
    {
      AboutBox.Instance.OpenApplicationHome();
    }

    /// <summary>
    /// Event handler. Called by ActionContact for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionContact_Click(object sender, EventArgs e)
    {
      AboutBox.Instance.OpenContactPage();
    }

    /// <summary>
    /// Event handler. Called by ActionCheckUpdate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionCheckUpdate_Click(object sender, EventArgs e)
    {
      Program.CheckUpdate(false);
    }

    private void ActionCreateGitHubIssue_Click(object sender, EventArgs e)
    {
      SystemManager.OpenWebLink(Program.GitHubRepositoryURL + "/issues");
    }

    private void ActionOpenWebsiteURL_Click(object sender, EventArgs e)
    {
      string url = (string)( (ToolStripItem)sender ).Tag;
      SystemManager.OpenWebLink(url);
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

    private void MenuExit_Click(object sender, EventArgs e)
    {
      if ( IsGenerating )
      {
        DisplayManager.ShowAdvert(Translations.CantExitApplicationWhileGenerating.GetLang());
        return;
      }
      if ( EditConfirmClosing.Checked )
        if ( !DisplayManager.QueryYesNo(Translations.ExitApplication.GetLang()) )
          return;
      AllowClose = true;
      Close();
    }

    /// <summary>
    /// Event handler. Called by ActionGenerate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionGenerate_Click(object sender, EventArgs e)
    {
      try
      {
        DoGenerate(sender, e);
      }
      catch ( AbortException )
      {
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Event handler. Called by ActionStop for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionStop_Click(object sender, EventArgs e)
    {
      IsGenerating = false;
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
      SetView(ViewModeType.Month);
      CalendarMonth.ShowTodayButton = false;
      CalendarMonth.ShowArrowControls = false;
      try
      {
        var bitmap = new Bitmap(CalendarMonth.Width, CalendarMonth.Height);
        CalendarMonth.DrawToBitmap(bitmap, new Rectangle(0, 0, CalendarMonth.Width, CalendarMonth.Height));
        var document = new PrintDocument();
        document.DefaultPageSettings.Landscape = true;
        document.PrintPage += (s, ev) => ev.Graphics.DrawImage(bitmap, 75, 75);
        PrintDialog.Document = document;
        if ( PrintDialog.ShowDialog() == DialogResult.Cancel ) return;
        document.Print();
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
      if ( SaveFileDialog.ShowDialog() == DialogResult.OK )
        File.WriteAllText(SaveFileDialog.FileName, CalendarText.Text);
    }

    /// <summary>
    /// Event handler. Called by ActionExportCSV for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExportCSV_Click(object sender, EventArgs e)
    {
      GenerateCSV();
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
        date = DateTime.Now;
      else
      {
        var form = new SelectDayForm();
        form.LiveGoTo = true;
        if ( form.ShowDialog() != DialogResult.OK ) return;
        date = form.MonthCalendar.SelectionStart;
      }
      GoToDate(date);
    }

    private void ActionSearchEvent_Click(object sender, EventArgs e)
    {
      var form = new SearchEventForm();
      form.ShowDialog();
    }

    private void ActionSearchMonth_Click(object sender, EventArgs e)
    {
      var form = new SearchMonthForm();
      if ( form.ShowDialog() != DialogResult.OK ) return;
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
          GoToDate(DateTime.Now); 
          NavigationForm.Instance.Show();
          NavigationForm.Instance.BringToFront();
        }
      }
      catch ( ObjectDisposedException ex )
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
      CelebrationsForm.Run();
    }

    private void MenuRefreshReminder_Click(object sender, EventArgs e)
    {
      ClearLists();
      Timer_Tick(null, null);
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
            e.Value = ( (MoonriseType)e.Value ).ToString();
            break;
          case 10:
            e.Value = Translations.MoonPhase.GetLang((MoonPhaseType)e.Value);
            break;
          case 8:
            e.Value = (int)e.Value == 0 ? "" : "*";
            break;
          case 9:
            e.Value = (int)e.Value == 0 ? "" : "*";
            break;
          case 11:
            var season = (SeasonChangeType)e.Value;
            e.Value = season == SeasonChangeType.None ? "" : Translations.SeasonEvent.GetLang(season);
            break;
          case 12:
            var torah = (TorahEventType)e.Value;
            e.Value = torah == TorahEventType.None ? "" : Translations.TorahEvent.GetLang(torah);
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
        GoToDate(SQLiteUtility.GetDate(( (Data.LunisolarCalendar.LunisolarDaysRow)rowview ).Date));
      }
      catch
      {
      }
    }

    /// <summary>
    /// Event handler. Called by Timer for tick events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void Timer_Tick(object sender, EventArgs e)
    {
      try
      {
        if ( !IsReady ) return;
        if ( !TimerReminder.Enabled ) return;
        if ( CalendarMonth.CalendarDate.Day != DateTime.Now.Day )
          GoToDate(DateTime.Now);
        int active = 1;
        SystemParametersInfo(SPI_GETSCREENSAVERRUNNING, 0, ref active, 0);
        if ( active != 0 ) return;
        if ( IsForegroundFullScreen() ) return;
        if ( Program.Settings.ReminderShabatEnabled ) CheckShabat();
        if ( Program.Settings.ReminderCelebrationsEnabled ) CheckCelebrationDay();
        if ( Program.Settings.ReminderCelebrationsEnabled ) CheckEvents();
      }
      catch ( Exception ex )
      {
        if ( TimerErrorShown ) return;
        TimerErrorShown = true;
        ex.Manage();
      }
    }

  }

}
