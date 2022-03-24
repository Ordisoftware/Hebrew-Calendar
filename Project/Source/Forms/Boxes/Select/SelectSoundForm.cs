/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class SelectSoundForm : Form
{

  static public int DefaultReminderSoundMaxDuration { get; set; } = 3000;

  static private readonly Properties.Settings Settings = Program.Settings;

  static public void Run(bool topmost = false)
  {
    using var form = new SelectSoundForm();
    form.TopMost = topmost;
    if ( form.ShowDialog() != DialogResult.OK ) return;
    if ( form.SelectNone.Checked )
      Settings.ReminderBoxSoundSource = SoundSource.None;
    else
    if ( form.SelectDialog.Checked )
      Settings.ReminderBoxSoundSource = SoundSource.Dialog;
    else
    if ( form.SelectApplication.Checked )
      Settings.ReminderBoxSoundSource = SoundSource.Application;
    else
    if ( form.SelectWindows.Checked )
      Settings.ReminderBoxSoundSource = SoundSource.Windows;
    else
    if ( form.SelectCustom.Checked )
      Settings.ReminderBoxSoundSource = SoundSource.Custom;
    if ( form.SelectDialogSound.SelectedItem is not null )
      Settings.ReminderBoxSoundDialog = (MessageBoxIcon)form.SelectDialogSound.SelectedItem;
    Settings.ReminderBoxSoundApplication = ( form.SelectApplicationSound.SelectedItem as SoundItem )?.FilePath;
    Settings.ReminderBoxSoundWindows = ( form.SelectWindowsSound.SelectedItem as SoundItem )?.FilePath;
    Settings.ReminderBoxSoundPath = form.EditFilePath.Text;
    SystemManager.TryCatch(Settings.Save);
  }

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  private SelectSoundForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    //
    SelectApplicationSound.Items.AddRange(SoundItem.GetApplicationSounds().ToArray());
    SelectWindowsSound.Items.AddRange(SoundItem.GetWindowsSounds().ToArray());
    SelectDialogSound.Items.Add(MessageBoxIcon.Information);
    SelectDialogSound.Items.Add(MessageBoxIcon.Question);
    SelectDialogSound.Items.Add(MessageBoxIcon.Exclamation);
    SelectDialogSound.Items.Add(MessageBoxIcon.Hand);
    //
    EditFilePath.Text = Settings.ReminderBoxSoundPath;
    SelectDialogSound.SelectedIndex = SelectDialogSound.Items.IndexOf(Settings.ReminderBoxSoundDialog);
    //
    var soundsApp = from SoundItem sound in SelectApplicationSound.Items select sound;
    var soundApp = soundsApp.FirstOrDefault(sound => sound.FilePath == Settings.ReminderBoxSoundApplication);
    if ( soundApp is not null ) SelectApplicationSound.SelectedItem = soundApp;
    //
    var soundsWin = from SoundItem sound in SelectWindowsSound.Items select sound;
    var soundWin = soundsWin.FirstOrDefault(sound => sound.FilePath == Settings.ReminderBoxSoundWindows);
    if ( soundWin is not null ) SelectWindowsSound.SelectedItem = soundWin;
    //
    if ( SelectDialogSound.Items.Count > 0 && SelectDialogSound.SelectedIndex == -1 )
      SelectDialogSound.SelectedIndex = 0;
    if ( SelectApplicationSound.Items.Count > 0 && SelectApplicationSound.SelectedIndex == -1 )
      SelectApplicationSound.SelectedIndex = 0;
    if ( SelectWindowsSound.Items.Count > 0 && SelectWindowsSound.SelectedIndex == -1 )
      SelectWindowsSound.SelectedIndex = 0;
    //
    switch ( Settings.ReminderBoxSoundSource )
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
        throw new AdvancedNotImplementedException(Settings.ReminderBoxSoundSource);
    }
  }

  private void SelectSoundForm_Shown(object sender, EventArgs e)
  {
    EditVolume.Value = Settings.ApplicationVolume;
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
    if ( path.Length == 0 ) path = Globals.UserMusicFolderPath;
    SystemManager.TryCatch(() => OpenFileDialog.InitialDirectory = Path.GetDirectoryName(path));
    SystemManager.TryCatch(() => OpenFileDialog.FileName = Path.GetFileName(EditFilePath.Text));
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
    Settings.ApplicationVolume = EditVolume.Value;
    SystemManager.TryCatch(Settings.Save);
    ActionPlay.PerformClick();
  }

}
