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
/// <edited> 2019-08 </edited>
using Microsoft.Win32;
using Ordisoftware.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Drawing.Printing;

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
    static public readonly MainForm Instance;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static MainForm()
    {
      Instance = new MainForm();
    }

    /// <summary>
    /// Indicate if generation is in progress.
    /// </summary>
    private bool IsGenerating = false;

    /// <summary>
    /// Indicate if application can be closed.
    /// </summary>
    private bool AllowClose = false;

    /// <summary>
    /// INdicate last showned tooltip.
    /// </summary>
    private ToolTip LastToolTip = new ToolTip();

    /// <summary>
    /// Indicate list of events reminded.
    /// </summary>
    private List<string> Reminded = new List<string>();

    /// <summary>
    /// Default constructor.
    /// </summary>
    private MainForm()
    {
      InitializeComponent();
      Text = AboutBox.Instance.AssemblyTitle;
      SystemEvents.SessionEnding += SessionEnding;
      CalendarText.ForeColor = Program.Settings.TextColor;
      CalendarText.BackColor = Program.Settings.TextBackground;
      CalendarMonth.CalendarDateChanged += (date) =>
      {
        NavigationForm.Instance.Date = date;
      };
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
      Refresh();
      LoadData();
    }

    /// <summary>
    /// Event handler. Called by MainForm for shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Shown(object sender, EventArgs e)
    {
      UpdateTextCalendar();
      UpdateButtons();
      MenuShowHide.Text = Localizer.HideRestoreText.GetLang(Visible);
      NavigationForm.Instance.Date = DateTime.Now;
      CheckUpdate(true);
      if ( Program.Settings.StartupHide ) MenuShowHide.PerformClick();
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
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

    /// <summary>
    /// Session ending.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Session ending event information.</param>
    private void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      AllowClose = true;
      Close();
    }

    /// <summary>
    /// Check if a newer version is available.
    /// </summary>
    private void CheckUpdate(bool auto)
    {
      try
      {
        string title = AboutBox.Instance.AssemblyTitle;
        string url = "http://www.ordisoftware.com/files/" + title.Replace(" ", "") + ".update";
        using ( WebClient client = new WebClient() )
        {
          string[] partsVersion = client.DownloadString(url).Split('.');
          var version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]));
          string[] partsAssemblyVersion = AboutBox.Instance.AssemblyVersion.Split('.');
          if ( version.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) <= 0 )
          {
            if ( !auto )
              DisplayManager.Show(Localizer.CheckUpdateNoNewText.GetLang());
          }
          else
            if ( DisplayManager.QueryYesNo(Localizer.CheckUpdateResultText.GetLang() + version + Environment.NewLine +
                                           Environment.NewLine +
                                           Localizer.CheckUpdateAskDownloadText.GetLang()) )
            AboutBox.Instance.OpenApplicationHome();
        }
      }
      catch
      {
      }
    }

    /// <summary>
    /// Event handler. Called by MenuShowHide for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuShowHide_Click(object sender, EventArgs e)
    {
      if ( !Visible )
      {
        FormBorderStyle = FormBorderStyle.Sizable;
        Visible = true;
        ShowInTaskbar = true;
        WindowState = Program.Settings.MainFormState;
        NavigationForm.Instance.Date = DateTime.Now;
      }
      else
      {
        Program.Settings.MainFormState = WindowState;
        WindowState = FormWindowState.Minimized;
        Visible = false;
        ShowInTaskbar = false;
        FormBorderStyle = FormBorderStyle.SizableToolWindow;
      }
      MenuShowHide.Text = Localizer.HideRestoreText.GetLang(Visible);
    }

    /// <summary>
    /// Event handler. Called by TrayIcon for mouse click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Mouse event information.</param>
    private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
    {
      if ( e != null && e.Button == MouseButtons.Left )
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
      if ( DisplayManager.QueryYesNo(Localizer.RestoreWinPosText.GetLang()) )
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
      PreferencesForm.Instance.ShowDialog();
      CalendarMonth.ShowEventTooltips = Program.Settings.MonthViewSunToolTips;
      TimerReminder.Enabled = Program.Settings.ReminderEnabled;
      Timer_Tick(null, null);
      if ( PreferencesForm.Instance.OldShabatDay != Program.Settings.ShabatDay
        || PreferencesForm.Instance.OldLatitude != Program.Settings.Latitude
        || PreferencesForm.Instance.OldLongitude != Program.Settings.Longitude )
        if ( DisplayManager.QueryYesNo(Localizer.RegenerateCalendarText.GetLang()) )
          ActionGenerate.PerformClick();
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
      using ( var process = new Process() )
        try
        {
          process.StartInfo.FileName = Program.HelpFilename;
          process.Start();
        }
        catch ( Exception ex )
        {
          DisplayManager.ShowError(ex.Message);
        }
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
      CheckUpdate(false);
    }

    /// <summary>
    /// Event handler. Called by ActionExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExit_Click(object sender, EventArgs e)
    {
      if ( IsGenerating )
      {
        DisplayManager.ShowAdvert(Localizer.CantExitApplicationWhileGeneratingText.GetLang());
        return;
      }
      if ( EditConfirmClosing.Checked )
        if ( !DisplayManager.QueryYesNo(Localizer.ExitApplicationText.GetLang()) )
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
      TimerReminder.Enabled = false;
      try
      {
        var form = new SelectYearsForm();
        if ( form.ShowDialog() == DialogResult.Cancel ) return;
        if ( LunisolarCalendar.LunisolarDays.Count > 0 )
          if ( !DisplayManager.QueryYesNo(Localizer.ReplaceCalendarText.GetLang()) )
            return;
        GenerateData((int)form.EditYearFirst.Value, (int)form.EditYearLast.Value);
        NavigationForm.Instance.Date = DateTime.Now;
      }
      finally
      {
        Reminded.Clear();
        TimerReminder.Enabled = Program.Settings.ReminderEnabled;
        Timer_Tick(this, null);
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
        document.PrintPage += (s, ev) => ev.Graphics.DrawImage(bitmap, 100, 100);
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
        if ( form.ShowDialog() != DialogResult.OK ) return;
        date = form.MonthCalendar.SelectionStart;
      }
      NavigationForm.Instance.Date = date;
    }

    /// <summary>
    /// Event handler. Called by ActionNavigate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionNavigate_Click(object sender, EventArgs e)
    {
      NavigationForm.Instance.Date = DateTime.Now;
      NavigationForm.Instance.Visible = true;
      NavigationForm.Instance.BringToFront();
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

    /// <summary>
    /// Event handler. Called by CalendarGrid for cell formatting events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void CalendarGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      switch ( e.ColumnIndex )
      {
        case 7:
          e.Value = ( (MoonriseType)e.Value ).ToString();
          break;
        case 10:
          e.Value = Localizer.MoonPhaseText.GetLang((MoonPhaseType)e.Value);
          break;
        case 8:
          e.Value = (int)e.Value == 0 ? "" : "*";
          break;
        case 9:
          e.Value = (int)e.Value == 0 ? "" : "*";
          break;
        case 11:
          var season = (SeasonChangeType)e.Value;
          e.Value = season == SeasonChangeType.None ? "" : Localizer.SeasonEventText.GetLang(season);
          break;
        case 12:
          var torah = (TorahEventType)e.Value;
          e.Value = torah == TorahEventType.None ? "" : Localizer.TorahEventText.GetLang(torah);
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
      try
      {
        if ( LunisolarDaysBindingSource.Current == null ) return;
        var rowview = ( (DataRowView)LunisolarDaysBindingSource.Current ).Row;
        NavigationForm.Instance.Date = SQLiteUtility.GetDate(( (Data.LunisolarCalendar.LunisolarDaysRow)rowview ).Date);
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
    private void Timer_Tick(object sender, EventArgs e)
    {
      if ( !TimerReminder.Enabled ) return;
      CheckEvents();
      if ( Program.Settings.RemindShabat ) CheckShabat();
    }

    /// <summary>
    /// Set the data position.
    /// </summary>
    /// <param name="date">The date.</param>
    internal void GoToDate(DateTime date)
    {
      string strDate = date.Day.ToString("00") + "." + date.Month.ToString("00") + "." + date.Year.ToString("0000");
      int pos = CalendarText.Find(strDate);
      if ( pos != -1 )
      {
        CalendarText.SelectionStart = pos - 6 - 118;
        CalendarText.SelectionLength = 0;
        CalendarText.ScrollToCaret();
        CalendarText.SelectionStart = pos - 6;
        CalendarText.SelectionLength = 118;
        LunisolarDaysBindingSource.Position = LunisolarDaysBindingSource.Find("Date", SQLiteUtility.GetDate(date));
        CalendarGrid.Update();
        CalendarMonth.CalendarDate = date;
      }
    }

  }

}
