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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class StatisticsForm : Form
  {

    static public StatisticsForm Instance { get; private set; }

    static StatisticsForm()
    {
      Instance = new StatisticsForm();
    }

    static public void Run()
    {
      Instance.UpdateData();
      Instance.Show();
      Instance.BringToFront();
      Instance.Timer.Start();
    }

    public StatisticsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void DatabaseStatisticsForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
    }

    private void DatabaseStatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Timer.Stop();
      e.Cancel = true;
      Hide();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      UpdateData();
    }

    private string FormatMilliseconds(long ms)
    {
      TimeSpan time = TimeSpan.FromMilliseconds(ms);
      return string.Format("{0:D2}d {1:D2}h {2:D2}m {3:D2}s {4:D3}ms",
                           time.Days,
                           time.Hours,
                           time.Minutes,
                           time.Seconds,
                           time.Milliseconds)
                   .Replace("00d 00h 00m 00s", "")
                   .Replace("00d 00h 00m", "")
                   .Replace("00d 00h", "")
                   .Replace("00d ", "");
    }

    private void UpdateData()
    {
      TextBox.Text = "Running time: " + FormatMilliseconds((long)DateTime.Now.Subtract(Program.Settings.BenchmarkStartDateTime).TotalMilliseconds) + Environment.NewLine;
      TextBox.Text += Environment.NewLine;
      TextBox.Text += string.Format("Last starting full time: {0}" + Environment.NewLine +
                                    "Last load data time: {1}" + Environment.NewLine +
                                    "Last generate years time: {2}" + Environment.NewLine,
                                    "Last fill calendar time: {3}" + Environment.NewLine,
                                    FormatMilliseconds(Program.Settings.BenchmarkStartingApp),
                                    FormatMilliseconds(Program.Settings.BenchmarkLoadData),
                                    FormatMilliseconds(Program.Settings.BenchmarkGenerateYears),
                                    FormatMilliseconds(Program.Settings.BenchmarkFillCalendar));
      TextBox.Text += Environment.NewLine;
      TextBox.Text += "DB First year: " + MainForm.Instance.YearFirst + Environment.NewLine;
      TextBox.Text += "DB Last year: " + MainForm.Instance.YearLast + Environment.NewLine;
      TextBox.Text += "DB Records count: " + MainForm.Instance.DataSet.LunisolarDays.Count() + Environment.NewLine;
      TextBox.Text += "DB Events count: " + MainForm.Instance.DataSet.LunisolarDays.Count(d => d.TorahEvents != 0 || d.SeasonChange != 0) + Environment.NewLine;
      TextBox.Text += Environment.NewLine;
      TextBox.Text += "Month calendar items: " + MainForm.Instance.CalendarMonth.Events.Count + Environment.NewLine;
      TextBox.Text += Environment.NewLine;
      //File size
      //Memory
    }

    private void StatisticsForm_Shown(object sender, EventArgs e)
    {
      ;
    }
  }

}
