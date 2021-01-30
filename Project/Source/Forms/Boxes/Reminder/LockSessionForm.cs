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
/// <created> 2019-11 </created>
/// <edited> 2021-01 </edited>
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class LockSessionForm : Form
  {

    static public LockSessionForm Instance { get; private set; }

    static public void Run()
    {
      if ( Instance == null )
        Instance = new LockSessionForm();
      Instance.Popup();
    }

    DateTime Start = DateTime.Now;

    private LockSessionForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ActiveControl = ActionLock;
    }

    private void LockSessionForm_Load(object sender, EventArgs e)
    {
      LabelMessage.Text = string.Format(LabelMessage.Text, Program.Settings.AutoLockSessionTimeOut);
      int width = LabelMessage.Width + LabelMessage.Left + LabelMessage.Left + 10;
      if ( width > Width ) Width = width;
      ActionHibernate.Left = ActionStandby.Left + ActionStandby.Width + 5;
      ActionShutdown.Left = ActionHibernate.Left + ActionHibernate.Width + 5;
      ActionHibernate.Enabled = SystemManager.CanHibernate;
      ActionStandby.Enabled = SystemManager.CanStandby;
      CenterToScreen();
      Timer.Start();
      Timer_Tick(null, null);
    }

    private void LockSessionForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Timer.Stop();
      Instance = null;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      int remain = Program.Settings.AutoLockSessionTimeOut - ( DateTime.Now - Start ).Seconds;
      LabelCountDown.Text = remain.ToString();
      if ( remain != 0 ) return;
      LockSession();
    }

    private void ActionDisable_Click(object sender, EventArgs e)
    {
      Program.Settings.AutoLockSession = false;
      Program.Settings.Save();
      ActionCancel.PerformClick();
    }

    private void ActionCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ActionOK_Click(object sender, EventArgs e)
    {
      LockSession();
    }

    private void ActionShutdown_Click(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToShutdownComputer.GetLang()) ) return;
      Close();
      SystemManager.StopPlaying();
      SystemManager.RunShell("shutdown", "/s /t 0");
      MainForm.Instance.SessionEnding(null, null);
    }

    private void ActionHibernate_Click(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Close();
      SystemManager.StopPlaying();
      Application.SetSuspendState(PowerState.Hibernate, false, false);
    }

    private void ActionStandby_Click(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Close();
      SystemManager.StopPlaying();
      Application.SetSuspendState(PowerState.Suspend, false, false);
    }

    private void LockSession()
    {
      if ( EditMediaStop.Checked )
      {
        SystemManager.StopPlaying();
        SystemManager.MuteVolume();
      }
      Close();
      if ( !NativeMethods.LockWorkStation() )
        MessageBox.Show(SysTranslations.LockSessionError.GetLang(Marshal.GetLastWin32Error()));
    }

  }

}
