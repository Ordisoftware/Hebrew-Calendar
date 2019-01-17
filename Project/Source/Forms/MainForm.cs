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
        lunisolarDaysTableAdapter.Fill(lunisolarCalendar.LunisolarDays);
      }
      catch (Exception ex)
      {
        ex.Manage();
      }
      SetView(Program.Settings.CurrentView, true);
      GenerateReport();
      actionSearchDay_Click(null, null);
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
    private void timerTooltip_Tick(object sender, EventArgs e)
    {
      if ( !editShowTips.Checked ) return;
      var item = (ToolStripItem)LastToolTip.Tag;
      var location = new Point(item.Bounds.Left, item.Bounds.Top - 25);
      LastToolTip.Tag = sender;
      LastToolTip.Show(item.ToolTipText, toolStrip, location, 3000);
      timerTooltip.Enabled = false;
    }

    /// <summary>
    /// Show tooltip on mouse enter event.
    /// </summary>
    private void ShowToolTipOnMouseEnter(object sender, EventArgs e)
    {
      if ( !editShowTips.Checked ) return;
      if ( !( sender is ToolStripItem ) ) return;
      if ( LastToolTip.Tag == sender ) return;
      LastToolTip.Tag = sender;
      if ( ( (ToolStripItem)sender ).ToolTipText == "" ) return;
      timerTooltip.Enabled = true;
    }

    /// <summary>
    /// Show tooltip on mouse leave event.
    /// </summary>
    private void ShowToolTipOnMouseLeave(object sender, EventArgs e)
    {
      if ( !editShowTips.Checked ) return;
      timerTooltip.Enabled = false;
      LastToolTip.Tag = null;
      LastToolTip.Hide(toolStrip);
    }

    /// <summary>
    /// Event handler. Called by actionViewText for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionViewText_Click(object sender, EventArgs e)
    {
      SetView(ViewModeType.Text);
    }

    /// <summary>
    /// Event handler. Called by actionViewGrid for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionViewGrid_Click(object sender, EventArgs e)
    {
      SetView(ViewModeType.Grid);
    }

    /// <summary>
    /// Event handler. Called by miReset for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionResetWinSettings_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(LocalizerHelper.RestoreWinPosText.GetLang()) )
        Program.Settings.RestoreMainForm();
    }

    /// <summary>
    /// Event handler. Called by editScreenPosition for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    internal void editScreenPosition_Click(object sender, EventArgs e)
    {
      DoScreenPosition(sender, e);
    }

    /// <summary>
    /// Event handler. Called by actionPreferences for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionPreferences_Click(object sender, EventArgs e)
    {
      PreferencesForm.Instance.ShowDialog();
      if ( PreferencesForm.Instance.OldShabatDay != Program.Settings.ShabatDay
        || PreferencesForm.Instance.OldLatitude != Program.Settings.Latitude
        || PreferencesForm.Instance.OldLongitude != Program.Settings.Longitude )
        if ( DisplayManager.QueryYesNo(LocalizerHelper.RegenerateCalendarText.GetLang()) )
        {
          actionGenerate.PerformClick();
          actionSearchDay_Click(null, null);
        }
  
    }

    /// <summary>
    /// Event handler. Called by actionAbout for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionAbout_Click(object sender, EventArgs e)
    {
      if ( AboutBox.Instance.Visible )
        AboutBox.Instance.BringToFront();
      else
        AboutBox.Instance.ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by actionHelp for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionHelp_Click(object sender, EventArgs e)
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
    /// Event handler. Called by actionApplicationHome for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionApplicationHome_Click(object sender, EventArgs e)
    {
      AboutBox.Instance.OpenApplicationHome();
    }

    /// <summary>
    /// Event handler. Called by actionContact for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionContact_Click(object sender, EventArgs e)
    {
      AboutBox.Instance.OpenContactPage();
    }

    /// <summary>
    /// Event handler. Called by actionExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionExit_Click(object sender, EventArgs e)
    {
      if ( editConfirmClosing.Checked )
        if ( !DisplayManager.QueryYesNo(LocalizerHelper.ExitApplicationText.GetLang()) )
          return;
      TrayIconForm.Instance.Close();

    }

    /// <summary>
    /// Event handler. Called by actionGenerate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionGenerate_Click(object sender, EventArgs e)
    {
      var form = new SelectYearsForm();
      if ( form.ShowDialog() == DialogResult.Cancel ) return;
      if ( lunisolarCalendar.LunisolarDays.Count > 0 )
        if ( !DisplayManager.QueryYesNo(LocalizerHelper.ReplaceCalendarText.GetLang()) )
          return;
      GenerateDB((int)form.editYearFirst.Value, (int)form.editYearLast.Value);
      GenerateReport();
      actionSearchDay_Click(null, null);
    }

    /// <summary>
    /// Event handler. Called by actionStop for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionStop_Click(object sender, EventArgs e)
    {
      IsGenerating = false;
    }

    /// <summary>
    /// Event handler. Called by actionCopyReportToClipboard for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionCopyReportToClipboard_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(calendarText.Text);
    }

    /// <summary>
    /// Event handler. Called by actionSaveReport for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionSaveReport_Click(object sender, EventArgs e)
    {
      if ( saveFileDialog.ShowDialog() != DialogResult.OK ) return;
      File.WriteAllText(saveFileDialog.FileName, calendarText.Text);
    }

    /// <summary>
    /// Event handler. Called by actionExportCSV for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionExportCSV_Click(object sender, EventArgs e)
    {
      ExportCSV();
    }

    /// <summary>
    /// Event handler. Called by actionSearchDay for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionSearchDay_Click(object sender, EventArgs e)
    {
      DateTime date;
      if ( sender == null )
        date = DateTime.Now;
      else
      {
        var form = new SelectDayForm();
        if ( form.ShowDialog() != DialogResult.OK ) return;
        date = form.monthCalendar.SelectionStart;
      }
      string strDate = date.Day.ToString("00") + "." + date.Month.ToString("00") + "." + date.Year.ToString("0000");
      int pos = calendarText.Find(strDate);
      if ( pos != -1 )
      {
        calendarText.SelectionStart = pos - 6 - 118;
        calendarText.SelectionLength = 0;
        calendarText.ScrollToCaret();
        calendarText.SelectionStart = pos - 6;
        calendarText.SelectionLength = 118;
        lunisolarDaysBindingSource.Position = lunisolarDaysBindingSource.Find("Date", strDate);
      }
    }

  }

}
