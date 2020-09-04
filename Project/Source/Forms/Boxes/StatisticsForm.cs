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
/// <created> 2020-08 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class StatisticsForm : Form
  {

    static public StatisticsForm Instance { get; private set; }

    static StatisticsForm()
    {
      Instance = new StatisticsForm();
      Instance.SystemStatisticsForm_Load(null, null);
      Instance.EditAlwaysOnTop_CheckedChanged(null, null);
    }

    static public void Run(bool prepareonly = false)
    {
      LoadingForm.Instance.Progressing += FormLoadingProgressing;
      if ( !prepareonly )
      {
        if ( Instance.WindowState == FormWindowState.Minimized )
          Instance.WindowState = FormWindowState.Normal;
        Instance.Show();
        Instance.BringToFront();
        Instance.Timer_Tick(null, null);
        Instance.Timer.Interval = 1000;
      }
      Instance.Timer.Start();
    }

    private StatisticsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ApplicationStatisticsDataBindingSource.DataSource = ApplicationStatistics.Instance;
      SystemStatisticsDataBindingSource.DataSource = SystemStatistics.Instance;
    }

    private void SystemStatisticsForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
    }

    private void SystemStatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      LoadingForm.Instance.Progressing -= FormLoadingProgressing;
      Timer.Interval = 5000;
      e.Cancel = true;
      Hide();
    }

    private void EditAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
    {
      TopMost = EditAlwaysOnTop.Checked;
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private static void FormLoadingProgressing()
    {
      Application.DoEvents();
    }

    internal void Timer_Tick(object sender, EventArgs e)
    {
      if ( Visible )
      {
        LabelApplication1.Text = Globals.AssemblyTitleWithVersion;
        ApplicationStatisticsDataBindingSource.ResetBindings(false);
        SystemStatisticsDataBindingSource.ResetBindings(false);
      }
      else
      {
        string dummy = SystemStatistics.Instance.MemoryGC;
      }
    }

    private void ActionViewLog_Click(object sender, EventArgs e)
    {
      DebugManager.TraceForm.Show();
      DebugManager.TraceForm.BringToFront();
    }

    private void ActionScreenshot_Click(object sender, EventArgs e)
    {
      var bitmap = new Bitmap(PanelMain.Width, PanelMain.Height);
      PanelMain.DrawToBitmap(bitmap, new Rectangle(0, 0, PanelMain.Width, PanelMain.Height));
      Clipboard.SetImage(bitmap);
      DisplayManager.ShowInformation(Localizer.ScreenshotDone.GetLang());
    }

  }

}
