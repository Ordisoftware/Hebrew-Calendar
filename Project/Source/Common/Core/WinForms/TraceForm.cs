/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-04 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

public partial class TraceForm : Form
{

  private readonly string LocationPropertyName;
  private readonly string ClientSizePropertyName;
  private readonly string FontSizepropertyName;
  private readonly string OnlyErrorsPropertyName;

  private TraceForm()
  {
    InitializeComponent();
    ActiveControl = TabControl;
  }

  public TraceForm(string locationPropertyName, string clientSizePropertyName, string fontSizepropertyName, string onlyErrorsPropertyName)
  : this()
  {
    LocationPropertyName = locationPropertyName;
    ClientSizePropertyName = clientSizePropertyName;
    FontSizepropertyName = fontSizepropertyName;
    OnlyErrorsPropertyName = onlyErrorsPropertyName;
    if ( Globals.Settings is not null )
      try
      {
        Location = (Point)Globals.Settings[locationPropertyName];
        ClientSize = (Size)Globals.Settings[clientSizePropertyName];
        TrackBarFontSize.Value = (int)Globals.Settings[fontSizepropertyName];
        EditOnlyErrors.Checked = (bool)Globals.Settings[onlyErrorsPropertyName];
      }
      catch
      {
      }
  }

  private void LogForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
    TrackBarFontSize_ValueChanged(null, null);
  }

  private void TraceForm_Shown(object sender, EventArgs e)
  {
    Icon = Globals.MainForm?.Icon;
  }

  private void LogForm_Activated(object sender, EventArgs e)
  {
    ActionClearLogs.Enabled = DebugManager.Enabled;
    ActionRefreshFiles_Click(ActionRefreshFiles, null);
  }

  private void TraceForm_Deactivate(object sender, EventArgs e)
  {
    if ( Globals.Settings is not null )
      try
      {
        Globals.Settings[LocationPropertyName] = Location;
        Globals.Settings[ClientSizePropertyName] = ClientSize;
        Globals.Settings[FontSizepropertyName] = TrackBarFontSize.Value;
        Globals.Settings[OnlyErrorsPropertyName] = EditOnlyErrors.Checked;
        SystemManager.TryCatch(Globals.Settings.Save);
      }
      catch
      {
      }
  }

  private void TraceForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    Hide();
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void TrackBarFontSize_ValueChanged(object sender, EventArgs e)
  {
    TextBoxCurrent.Font = new Font("Courier New", TrackBarFontSize.Value);
    TextBoxPrevious.Font = new Font("Courier New", TrackBarFontSize.Value);
  }

  private void ActionOpenLogsFolder_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Globals.SinkFileFolderPath);
  }

  private void ActionClearLogs_Click(object sender, EventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToClearLogs.GetLang()) ) return;
    DebugManager.ClearTraces(false, true);
    Show();
    BringToFront();
  }

  public void AppendText(string text, bool scrollBottom = true)
  {
    TextBoxCurrent.SyncUI(() =>
    {
      try
      {
        if ( text.Length == 0 ) return;
        TextBoxCurrent.AppendText(text);
        if ( scrollBottom )
        {
          TextBoxCurrent.SelectionStart = TextBoxCurrent.Text.Length - 1;
          TextBoxCurrent.ScrollToCaret();
        }
      }
      catch
      {
      }
    });
  }

  private void TextBox_TextChanged(object sender, EventArgs e)
  {
    if ( TabControl.SelectedIndex == 0 )
    {
      Text = SysTranslations.TraceFileFormTitleWithLines.GetLang(TextBoxCurrent.Lines.Length);
    }
    else
    {
      Text = SysTranslations.TraceFileFormTitleWithLines.GetLang(TextBoxPrevious.Lines.Length);
      ActiveControl = SelectFile;
    }
  }

  private void ActionRefreshFiles_Click(object sender, EventArgs e)
  {
    TextBoxPrevious.Clear();
    SelectFile.Items.Clear();
    foreach ( var file in DebugManager.GetTraceFiles(false) )
      if ( !EditOnlyErrors.Checked )
        SelectFile.Items.Add(file);
      else
      {
        var content = File.ReadAllText(file);
        string strError = $"{LogTraceEvent.Error} {DebugManager.EventSeparator}";
        string strException = $"{LogTraceEvent.Exception} {DebugManager.EventSeparator}";
        if ( content.IndexOf(strError, StringComparison.OrdinalIgnoreCase) >= 0
          || content.IndexOf(strException, StringComparison.OrdinalIgnoreCase) >= 0 )
          SelectFile.Items.Add(file);
      }
    SelectFileNavigator.Refresh();
    SelectFile.Enabled = SelectFile.Items.Count > 0;
    ActionDeleteFile.Enabled = SelectFile.Enabled;
    LabelFilesCount.Text = SysTranslations.TraceFilesCount.GetLang(SelectFile.Items.Count);
    if ( !SelectFile.Enabled ) return;
    string filePath = (string)SelectFile.SelectedItem;
    var index = filePath is null ? -1 : SelectFile.Items.IndexOf(filePath);
    SelectFile.SelectedIndex = index != -1 ? index : SelectFile.Items.Count - 1;
  }

  private void SelectFile_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = Path.GetFileNameWithoutExtension((string)e.Value);
  }

  private void ActionDeleteFile_Click(object sender, EventArgs e)
  {
    if ( SelectFile.SelectedIndex < 0 ) return;
    string filePath = (string)SelectFile.SelectedItem;
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteFile.GetLang(SelectFile.Text)) ) return;
    File.Delete(filePath);
    ActionRefreshFiles.PerformClick();
  }

  private void SelectFile_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( SelectFile.SelectedIndex < 0 ) return;
    TextBoxPrevious.Clear();
    TextBoxPrevious.Lines = File.ReadAllLines((string)SelectFile.SelectedItem);
  }

}
