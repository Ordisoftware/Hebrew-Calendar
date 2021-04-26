﻿/// <license>
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
/// <created> 2020-09 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class SelectSoundForm : Form
  {

    static public int DefaultReminderSoundMaxDuration { get; set; } = 3000;

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
        if ( form.SelectApplication.Checked )
          Program.Settings.ReminderBoxSoundSource = SoundSource.Application;
        else
        if ( form.SelectWindows.Checked )
          Program.Settings.ReminderBoxSoundSource = SoundSource.Windows;
        else
        if ( form.SelectCustom.Checked )
          Program.Settings.ReminderBoxSoundSource = SoundSource.Custom;
        if ( form.SelectDialogSound.SelectedItem != null )
          Program.Settings.ReminderBoxSoundDialog = (MessageBoxIcon)form.SelectDialogSound.SelectedItem;
        Program.Settings.ReminderBoxSoundApplication = ( form.SelectApplicationSound.SelectedItem as SoundItem )?.FilePath;
        Program.Settings.ReminderBoxSoundWindows = ( form.SelectWindowsSound.SelectedItem as SoundItem )?.FilePath;
        Program.Settings.ReminderBoxSoundPath = form.EditFilePath.Text;
        Program.Settings.Save();
      }
    }

    private SelectSoundForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      SelectApplicationSound.Items.AddRange(SoundItem.GetApplicationSounds().ToArray());
      SelectWindowsSound.Items.AddRange(SoundItem.GetWindowsSounds().ToArray());
      SelectDialogSound.Items.Add(MessageBoxIcon.Information);
      SelectDialogSound.Items.Add(MessageBoxIcon.Question);
      SelectDialogSound.Items.Add(MessageBoxIcon.Exclamation);
      SelectDialogSound.Items.Add(MessageBoxIcon.Hand);
      EditFilePath.Text = Program.Settings.ReminderBoxSoundPath;
      SelectDialogSound.SelectedIndex = SelectDialogSound.Items.IndexOf(Program.Settings.ReminderBoxSoundDialog);
      var item = ( from SoundItem sound in SelectApplicationSound.Items
                   where sound.FilePath == Program.Settings.ReminderBoxSoundApplication
                   select sound ).FirstOrDefault();
      if ( item != null ) SelectApplicationSound.SelectedItem = item;
      item = ( from SoundItem sound in SelectWindowsSound.Items
               where sound.FilePath == Program.Settings.ReminderBoxSoundWindows
               select sound ).FirstOrDefault();
      if ( item != null ) SelectWindowsSound.SelectedItem = item;
      if ( SelectDialogSound.Items.Count > 0 && SelectDialogSound.SelectedIndex == -1 )
        SelectDialogSound.SelectedIndex = 0;
      if ( SelectApplicationSound.Items.Count > 0 && SelectApplicationSound.SelectedIndex == -1 )
        SelectApplicationSound.SelectedIndex = 0;
      if ( SelectWindowsSound.Items.Count > 0 && SelectWindowsSound.SelectedIndex == -1 )
        SelectWindowsSound.SelectedIndex = 0;
      switch ( Program.Settings.ReminderBoxSoundSource )
      {
        case SoundSource.None:
          SelectNone.Checked = true;
          break;
        case SoundSource.Dialog:
          SelectDialog.Checked = true;
          break;
        case SoundSource.Application:
          SelectApplication.Checked = true;
          break;
        case SoundSource.Windows:
          SelectWindows.Checked = true;
          break;
        case SoundSource.Custom:
          SelectCustom.Checked = true;
          break;
        default:
          throw new AdvancedNotImplementedException(Program.Settings.ReminderBoxSoundSource);
      }
    }

    private void SelectSoundForm_Shown(object sender, EventArgs e)
    {
      EditVolume.Value = Program.Settings.ApplicationVolume;
      ActionPlay.PerformClick();
    }

    private void SelectNone_CheckedChanged(object sender, EventArgs e)
    {
      if ( !SelectNone.Checked ) return;
      ActionPlay.Enabled = false;
      SelectDialogSound.Enabled = false;
      SelectApplicationSound.Enabled = false;
      SelectWindowsSound.Enabled = false;
      ActionSelectFilePath.Enabled = false;
      EditFilePath.Enabled = false;
    }

    private void SelectDialog_CheckedChanged(object sender, EventArgs e)
    {
      if ( !SelectDialog.Checked ) return;
      ActionPlay.Enabled = true;
      SelectDialogSound.Enabled = true;
      SelectApplicationSound.Enabled = false;
      SelectWindowsSound.Enabled = false;
      EditFilePath.Enabled = false;
      ActionSelectFilePath.Enabled = false;
      ActionPlay.PerformClick();
    }

    private void SelectApplication_CheckedChanged(object sender, EventArgs e)
    {
      if ( !SelectApplication.Checked ) return;
      ActionPlay.Enabled = true;
      SelectDialogSound.Enabled = false;
      SelectApplicationSound.Enabled = true;
      SelectWindowsSound.Enabled = false;
      EditFilePath.Enabled = false;
      ActionSelectFilePath.Enabled = false;
      ActionPlay.PerformClick();
    }

    private void SelectWindows_CheckedChanged(object sender, EventArgs e)
    {
      if ( !SelectWindows.Checked ) return;
      ActionPlay.Enabled = true;
      SelectDialogSound.Enabled = false;
      SelectApplicationSound.Enabled = false;
      SelectWindowsSound.Enabled = true;
      EditFilePath.Enabled = false;
      ActionSelectFilePath.Enabled = false;
      ActionPlay.PerformClick();
    }

    private void SelectCustom_CheckedChanged(object sender, EventArgs e)
    {
      if ( !SelectCustom.Checked ) return;
      ActionPlay.Enabled = true;
      SelectDialogSound.Enabled = false;
      SelectApplicationSound.Enabled = false;
      SelectWindowsSound.Enabled = false;
      EditFilePath.Enabled = true;
      ActionSelectFilePath.Enabled = true;
      ActionPlay.PerformClick();
    }

    private void SelectDialogSound_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Created ) return;
      DisplayManager.DoSound((MessageBoxIcon)SelectDialogSound.SelectedItem);
    }

    private void SelectApplicationSound_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Created ) return;
      ( SelectApplicationSound.SelectedItem as SoundItem )?.Play();
    }

    private void SelectWindowsSound_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Created ) return;
      ( SelectWindowsSound.SelectedItem as SoundItem )?.Play();
    }

    private void SelectFilePath_Click(object sender, EventArgs e)
    {
      string path = EditFilePath.Text;
      if ( path == string.Empty ) path = Globals.UserMusicFolderPath;
      SystemManager.TryCatch(() => { OpenFileDialog.InitialDirectory = Path.GetDirectoryName(path); });
      SystemManager.TryCatch(() => { OpenFileDialog.FileName = Path.GetFileName(EditFilePath.Text); });
      if ( OpenFileDialog.ShowDialog() != DialogResult.OK ) return;
      var sound = new SoundItem(OpenFileDialog.FileName);
      if ( sound.DurationMS > DefaultReminderSoundMaxDuration )
      {
        string msg = AppTranslations.SoundTooLong.GetLang(DefaultReminderSoundMaxDuration / 1000,
                                                          ( (long)sound.DurationMS ).FormatMilliseconds());
        DisplayManager.ShowWarning(msg);
      }
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
      if ( SelectApplication.Checked )
        SelectApplicationSound_SelectedIndexChanged(null, null);
      else
      if ( SelectWindows.Checked )
        SelectWindowsSound_SelectedIndexChanged(null, null);
      else
      if ( SelectCustom.Checked )
        new SoundItem(EditFilePath.Text).Play();
    }

    private void EditVolume_ValueChanged(object sender, EventArgs e)
    {
      MediaMixer.SetApplicationVolume(Globals.ProcessId, EditVolume.Value);
      LabelVolumeValue.Text = EditVolume.Value + "%";
      Program.Settings.ApplicationVolume = EditVolume.Value;
      Program.Settings.Save();
      ActionPlay.PerformClick();
    }

  }

}
