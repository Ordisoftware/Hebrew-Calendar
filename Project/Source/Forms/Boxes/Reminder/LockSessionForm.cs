/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.Runtime.InteropServices;

sealed partial class LockSessionForm : Form
{

  static public LockSessionForm Instance { get; private set; }

  static public void Run()
  {
    ( Instance ??= new LockSessionForm() ).Popup();
  }

  readonly DateTime Start = DateTime.Now;

  private LockSessionForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    ActiveControl = ActionOk;
  }

  private void LockSessionForm_Load(object sender, EventArgs e)
  {
    LabelMessage.Text = string.Format(LabelMessage.Text, Program.Settings.AutoLockSessionTimeOut);
    int width = LabelMessage.Width + LabelMessage.Left + LabelMessage.Left + 10;
    if ( width > Width ) Width = width;
    ActionOk.Text = SysTranslations.PowerActionText.GetLang(Program.Settings.LockSessionDefaultAction);
    ActionLock.Text = SysTranslations.PowerActionText.GetLang(PowerAction.LockSession);
    ActionStandby.Text = SysTranslations.PowerActionText.GetLang(PowerAction.StandBy);
    ActionHibernate.Text = SysTranslations.PowerActionText.GetLang(PowerAction.Hibernate);
    ActionShutdown.Text = SysTranslations.PowerActionText.GetLang(PowerAction.Shutdown);
    ActionStandby.Left = ActionLock.Left + ActionLock.Width + 5;
    ActionHibernate.Left = ActionStandby.Left + ActionStandby.Width + 5;
    ActionShutdown.Left = ActionHibernate.Left + ActionHibernate.Width + 5;
    ActionHibernate.Enabled = SystemManager.CanHibernate;
    ActionStandby.Enabled = SystemManager.CanStandby;
    CenterToScreen();
    Timer.Start();
    Timer_Tick(null, null);
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "Analysis error")]
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
    ActionOk.PerformClick();
  }

  private void ActionDisable_Click(object sender, EventArgs e)
  {
    Program.Settings.AutoLockSession = false;
    SystemManager.TryCatch(Program.Settings.Save);
    ActionCancel.PerformClick();
  }

  private void ActionCancel_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void ActionOk_Click(object sender, EventArgs e)
  {
    var actions = new NullSafeDictionary<PowerAction, Delegate>
    {
      [PowerAction.LockSession] = ActionLock_LinkClicked,
      [PowerAction.StandBy] = ActionStandby_LinkClicked,
      [PowerAction.Hibernate] = ActionHibernate_LinkClicked,
      [PowerAction.Shutdown] = ActionShutdown_LinkClicked
    };
    actions[Program.Settings.LockSessionDefaultAction]?.DynamicInvoke(null, null);
  }

  private void ActionLock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    Close();
    DoMediaPlayingAndVolumeAction();
    if ( !SystemManager.LockWorkStation() )
      MessageBox.Show(SysTranslations.LockSessionError.GetLang(Marshal.GetLastWin32Error()));
  }

  private void ActionStandby_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    Close();
    DoMediaPlayingAndVolumeAction();
    if ( !SystemManager.StandBy() )
      MessageBox.Show(SysTranslations.LockSessionError.GetLang(Marshal.GetLastWin32Error()));
  }

  private void ActionHibernate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    Close();
    DoMediaPlayingAndVolumeAction();
    if ( !SystemManager.Hibernate() )
      MessageBox.Show(SysTranslations.LockSessionError.GetLang(Marshal.GetLastWin32Error()));
  }

  private void ActionShutdown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    Close();
    if ( !SystemManager.Shutdown(Program.Settings.LockSessionConfirmLogOffOrMore) )
      MessageBox.Show(SysTranslations.LockSessionError.GetLang(Marshal.GetLastWin32Error()));
    else
      MainForm.Instance.SessionEnding(null, null);
  }

  private void DoMediaPlayingAndVolumeAction()
  {
    if ( EditMediaStop.Checked )
    {
      MediaMixer.StopPlaying();
      MediaMixer.MuteVolume();
    }
  }

  private void ActionPreferences_Click(object sender, EventArgs e)
  {
    MainForm.Instance.ActionPreferences_Click(PreferencesForm.TabIndexReminder, null);
  }

}
