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
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SystemStatisticsForm : Form
  {

    static public SystemStatisticsForm Instance { get; private set; }

    static SystemStatisticsForm()
    {
      Instance = new SystemStatisticsForm();
    }

    static public void Run()
    {
      Instance.SystemStatisticsForm_Load(null, null);
      Instance.Show();
      Instance.BringToFront();
      Instance.Timer.Start();
    }

    private SystemStatistics Stats;

    public SystemStatisticsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      Stats = new SystemStatistics();
      StatisticsDataBindingSource.DataSource = Stats;
    }

    private void SystemStatisticsForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
    }

    private void SystemStatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
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
      Timer.Interval = MainForm.Instance.IsGenerating ? 2000 : 1000;
      StatisticsDataBindingSource.ResetBindings(false);
    }

  }

}
