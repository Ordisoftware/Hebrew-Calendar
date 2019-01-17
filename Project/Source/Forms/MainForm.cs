/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm : Form
  {

    /// <summary>
    /// Filename of the help file.
    /// </summary>
    static public readonly string HelpFilename = ".." + Path.DirectorySeparatorChar
                                               + "Help" + Path.DirectorySeparatorChar
                                               + "index.htm";

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

    private ToolTip LastToolTip = new ToolTip();

    /// <summary>
    /// Default constructor.
    /// </summary>
    public MainForm()
    {
      InitializeComponent();
      Text = DisplayManager.Title;
      CalendarText.ForeColor = Program.Settings.TextColor;
      CalendarText.BackColor = Program.Settings.TextBackground;
    }

    /// <summary>
    /// Event handler. Called by MainForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MainForm_Load(object sender, EventArgs e)
    {
      Program.Settings.Retrieve();
      try
      {
        SQLiteUtility.CheckDB();
        LunisolarDaysTableAdapter.Fill(LunisolarCalendar.LunisolarDays);
        ReportTableAdapter.Fill(LunisolarCalendar.Report);
        SetView(Program.Settings.CurrentView, true);
        var row = LunisolarCalendar.Report.FirstOrDefault();
        CalendarText.Text = row == null ? "" : row.Content;
        ActionSearchDay_Click(null, null);
      }
      catch (Exception ex)
      {
        ex.Manage();
      }
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
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closing event information.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( IsGenerating )
      {
        e.Cancel = true;
        DisplayManager.ShowAdvert(LocalizerHelper.CantExitApplicationWhileGeneratingText.GetLang());
      }
      else
      {
        e.Cancel = true;
        TrayIconForm.Instance.MenuShowHide.PerformClick();
      }
    }

    /// <summary>
    /// Event handler. Called by MainForm for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closed event information.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      //Calendar.Dispose();
    }

    /// <summary>
    /// Timer event
    /// </summary>
    private void TimerTooltip_Tick(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      var item = (ToolStripItem)LastToolTip.Tag;
      var location = new Point(item.Bounds.Left, item.Bounds.Top - 25);
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
    /// Show tooltip on mouse leave event.
    /// </summary>
    private void ShowToolTipOnMouseLeave(object sender, EventArgs e)
    {
      if ( !EditShowTips.Checked ) return;
      TimerTooltip.Enabled = false;
      LastToolTip.Tag = null;
      LastToolTip.Hide(ToolStrip);
    }

    /// <summary>
    /// Event handler. Called by ActionViewText for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewText_Click(object sender, EventArgs e)
    {
      SetView(ViewModeType.Text);
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
      if ( DisplayManager.QueryYesNo(LocalizerHelper.RestoreWinPosText.GetLang()) )
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
      if ( PreferencesForm.Instance.OldShabatDay != Program.Settings.ShabatDay
        || PreferencesForm.Instance.OldLatitude != Program.Settings.Latitude
        || PreferencesForm.Instance.OldLongitude != Program.Settings.Longitude )
        if ( DisplayManager.QueryYesNo(LocalizerHelper.RegenerateCalendarText.GetLang()) )
        {
          ActionGenerate.PerformClick();
          ActionSearchDay_Click(null, null);
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
      using ( var process = new Process() )
        try
        {
          process.StartInfo.FileName = HelpFilename;
          process.Start();
        }
        catch ( Exception except )
        {
          DisplayManager.ShowError(except.Message);
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
    /// Event handler. Called by ActionExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExit_Click(object sender, EventArgs e)
    {
      if ( EditConfirmClosing.Checked )
        if ( !DisplayManager.QueryYesNo(LocalizerHelper.ExitApplicationText.GetLang()) )
          return;
      TrayIconForm.Instance.Close();

    }

    /// <summary>
    /// Event handler. Called by ActionGenerate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionGenerate_Click(object sender, EventArgs e)
    {
      var form = new SelectYearsForm();
      if ( form.ShowDialog() == DialogResult.Cancel ) return;
      if ( LunisolarCalendar.LunisolarDays.Count > 0 )
        if ( !DisplayManager.QueryYesNo(LocalizerHelper.ReplaceCalendarText.GetLang()) )
          return;
      GenerateDB((int)form.EditYearFirst.Value, (int)form.EditYearLast.Value);
      ActionSearchDay_Click(null, null);
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
    /// Event handler. Called by ActionSaveReport for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSaveReport_Click(object sender, EventArgs e)
    {
      if ( SaveFileDialog.ShowDialog() != DialogResult.OK ) return;
      File.WriteAllText(SaveFileDialog.FileName, CalendarText.Text);
    }

    /// <summary>
    /// Event handler. Called by ActionExportCSV for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionExportCSV_Click(object sender, EventArgs e)
    {
      ExportCSV();
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
      string strDate = date.Day.ToString("00") + "." + date.Month.ToString("00") + "." + date.Year.ToString("0000");
      int pos = CalendarText.Find(strDate);
      if ( pos != -1 )
      {
        CalendarText.SelectionStart = pos - 6 - 118;
        CalendarText.SelectionLength = 0;
        CalendarText.ScrollToCaret();
        CalendarText.SelectionStart = pos - 6;
        CalendarText.SelectionLength = 118;
        LunisolarDaysBindingSource.Position = LunisolarDaysBindingSource.Find("Date", strDate);
      }
    }

    private void ActionNavigate_Click(object sender, EventArgs e)
    {
      var form = NavigationForm.Instance;
      try
      {
        form.Date = DateTime.Now;
        form.Visible = true;
        form.BringToFront();
      }
      catch
      {
      }
    }
  }

}
