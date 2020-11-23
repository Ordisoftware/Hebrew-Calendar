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
/// <created> 2020-09 </created>
/// <edited> 2020-09 </edited>
using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class SelectSoundForm : Form
  {

    static public int DefaultReminderSoundMaxDuration = 3000;

    static public void Run(bool topmost = false)
    {
      using ( var form = new SelectSoundForm() )
      {
        form.TopMost = topmost;
        if ( form.ShowDialog() != DialogResult.OK ) return;
        if ( form.SelectNone.Checked )
          Program.Settings.ReminderBoxSoundSource = SoundSource.None;
        else
        if ( form.SelectDialog.Checked )
          Program.Settings.ReminderBoxSoundSource = SoundSource.Dialog;
        else
        if ( form.SelectWindows.Checked ) 
          Program.Settings.ReminderBoxSoundSource = SoundSource.Windows;
        else
        if ( form.SelectCustom.Checked )
          Program.Settings.ReminderBoxSoundSource = SoundSource.Custom;
        Program.Settings.ReminderBoxSoundDialog = (MessageBoxIcon)form.SelectDialogSound.SelectedItem;
        Program.Settings.ReminderBoxSoundWinows = ( (SoundItem)form.SelectWindowsSound.SelectedItem ).ToString();
        Program.Settings.ReminderBoxSoundPath = form.EditFilePath.Text;
        Program.Settings.Save();
      }
    }

    private SelectSoundForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      SelectWindowsSound.Items.AddRange(SoundItem.GetWindowsSounds().ToArray());
      SelectDialogSound.Items.Add(MessageBoxIcon.Information);
      SelectDialogSound.Items.Add(MessageBoxIcon.Question);
      SelectDialogSound.Items.Add(MessageBoxIcon.Exclamation);
      SelectDialogSound.Items.Add(MessageBoxIcon.Hand);
      EditFilePath.Text = Program.Settings.ReminderBoxSoundPath;
      SelectDialogSound.SelectedIndex = SelectDialogSound.Items.IndexOf(Program.Settings.ReminderBoxSoundDialog);
      var item = ( from SoundItem sound in SelectWindowsSound.Items
                   where sound.ToString() == Program.Settings.ReminderBoxSoundWinows
                   select sound ).FirstOrDefault();
      if (item != null) SelectWindowsSound.SelectedItem = item;
      if ( SelectDialogSound.Items.Count > 0 && SelectDialogSound.SelectedIndex == -1 ) SelectDialogSound.SelectedIndex = 0;
      if ( SelectWindowsSound.Items.Count > 0 && SelectWindowsSound.SelectedIndex == -1 ) SelectWindowsSound.SelectedIndex = 0;
      switch ( Program.Settings.ReminderBoxSoundSource )
      {
        case SoundSource.None:
          SelectNone.Checked = true;
          break;
        case SoundSource.Dialog:
          SelectDialog.Checked = true;
          break;
        case SoundSource.Windows:
          SelectWindows.Checked = true;
          break;
        case SoundSource.Custom:
          SelectCustom.Checked = true;
          break;
        default:
          throw new NotImplementedExceptionEx(Program.Settings.ReminderBoxSoundSource.ToStringFull());
      }
    }

    private void SelectNone_CheckedChanged(object sender, EventArgs e)
    {
      ActionPlay.Enabled = false;
      SelectDialogSound.Enabled = false;
      EditFilePath.Enabled = false;
      ActionSelectFilePath.Enabled = false;
      SelectWindowsSound.Enabled = false;
    }

    private void SelectDialog_CheckedChanged(object sender, EventArgs e)
    {
      ActionPlay.Enabled = true;
      SelectDialogSound.Enabled = true;
      EditFilePath.Enabled = false;
      ActionSelectFilePath.Enabled = false;
      SelectWindowsSound.Enabled = false;
    }

    private void SelectWindows_CheckedChanged(object sender, EventArgs e)
    {
      ActionPlay.Enabled = true;
      EditFilePath.Enabled = false;
      ActionSelectFilePath.Enabled = false;
      SelectDialogSound.Enabled = false;
      SelectWindowsSound.Enabled = true;
    }

    private void SelectCustom_CheckedChanged(object sender, EventArgs e)
    {
      ActionPlay.Enabled = true;
      SelectDialogSound.Enabled = false;
      EditFilePath.Enabled = true;
      ActionSelectFilePath.Enabled = true;
      SelectWindowsSound.Enabled = false;
    }

    private void SelectDialogSound_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Created ) return;
      DisplayManager.DoSound((MessageBoxIcon)SelectDialogSound.SelectedItem);
    }

    private void SelectWindowsSound_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Created ) return;
      ( (SoundItem)SelectWindowsSound.SelectedItem ).Play();
    }

    private void SelectFilePath_Click(object sender, EventArgs e)
    {
      SystemManager.TryCatch(() => { OpenFileDialog.InitialDirectory = Path.GetDirectoryName(EditFilePath.Text); });
      SystemManager.TryCatch(() => { OpenFileDialog.FileName = Path.GetFileName(EditFilePath.Text); });
      if ( OpenFileDialog.ShowDialog() != DialogResult.OK ) return;
      var sound = new SoundItem(OpenFileDialog.FileName);
      if ( sound.DurationMS > DefaultReminderSoundMaxDuration )
        DisplayManager.ShowWarning($"Duration must be less than {DefaultReminderSoundMaxDuration / 1000} seconds: " +
                                   ( (long)sound.DurationMS ).FormatMilliseconds());
      else
      {
        sound.Play();
        EditFilePath.Text = OpenFileDialog.FileName;
      }
    }

    private void ActionPlay_Click(object sender, EventArgs e)
    {
      if ( SelectDialog.Checked )
        SelectDialogSound_SelectedIndexChanged(null, null);
      else
      if ( SelectCustom.Checked )
        new SoundItem(EditFilePath.Text).Play();
      else
      if ( SelectWindows.Checked )
        SelectWindowsSound_SelectedIndexChanged(null, null);
    }

  }

}
