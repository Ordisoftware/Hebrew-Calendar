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
/// <created> 2019-11 </created>
/// <edited> 2019-11 </edited>
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Ordisoftware.HebrewCalendar
{

  public partial class LockSessionForm : Form
  {

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool LockWorkStation();

    static private LockSessionForm Instance;

    DateTime Start = DateTime.Now;

    static public void Run()
    {
      if ( Instance == null )
        Instance = new LockSessionForm();
      Instance.Show();
    }

    private LockSessionForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void LockSessionForm_Load(object sender, EventArgs e)
    {
      LabelMessage.Text = string.Format(LabelMessage.Text, Program.Settings.AutoLockSessionTimeOut);
      Timer.Start();
      Timer_Tick(null, null);
    }

    private void LockSessionForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Instance = null;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      int remain = Program.Settings.AutoLockSessionTimeOut - ( DateTime.Now - Start ).Seconds;
      LabelCountDown.Text = remain.ToString();
      if ( remain != 0 ) return;
      LockSession();
    }

    private void ActionOk_Click(object sender, EventArgs e)
    {
      LockSession();
    }

    private void ActionCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void LockSession()
    {
      Timer.Enabled = false;
      Close();
      if ( !LockWorkStation() )
        MessageBox.Show("Lock Session Error: " + Marshal.GetLastWin32Error());
    }

  }

}
