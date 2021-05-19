/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2020-12 </edited>
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Ordisoftware.Core
{
  partial class TraceForm : Form
  {

    private string LocationPropertyName;
    private string ClientSizePropertyName;
    private string FontSizepropertyName;

    private TraceForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm?.Icon;
    }

    public TraceForm(string locationPropertyName, string clientSizePropertyName, string fontSizepropertyName)
      : this()
    {
      LocationPropertyName = locationPropertyName;
      ClientSizePropertyName = clientSizePropertyName;
      FontSizepropertyName = fontSizepropertyName;
      try
      {
        Location = (Point)Globals.Settings[locationPropertyName];
        ClientSize = (Size)Globals.Settings[clientSizePropertyName];
        TrackBarFontSize.Value = (int)Globals.Settings[fontSizepropertyName];
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
    }

    private void LogForm_Activated(object sender, EventArgs e)
    {
      ActionClearLogs.Enabled = DebugManager.Enabled;
      ActionRefreshFiles_Click(ActionRefreshFiles, EventArgs.Empty);
    }

    private void TraceForm_Deactivate(object sender, EventArgs e)
    {
      try
      {
        Globals.Settings[LocationPropertyName] = Location;
        Globals.Settings[ClientSizePropertyName] = ClientSize;
        Globals.Settings[FontSizepropertyName] = TrackBarFontSize.Value;
        Globals.Settings.Save();
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
      DebugManager.ClearTraces();
      Show();
      BringToFront();
    }

    public void AppendText(string text, bool scrollBottom = true)
    {
      TextBoxCurrent.AppendText(text);
      if ( text == string.Empty ) return;
      if ( scrollBottom )
      {
        TextBoxCurrent.SelectionStart = TextBoxCurrent.Text.Length - 1;
        TextBoxCurrent.ScrollToCaret();
      }
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
      if ( TabControl.SelectedIndex == 0 )
        LabelLinesCount.Text = SysTranslations.TraceLinesCount.GetLang(TextBoxCurrent.Lines.Length);
      else
        LabelLinesCount.Text = SysTranslations.TraceLinesCount.GetLang(TextBoxPrevious.Lines.Length);
    }

    private void ActionRefreshFiles_Click(object sender, EventArgs e)
    {
      TextBoxPrevious.Clear();
      SelectFile.Items.Clear();
      foreach ( var file in DebugManager.GetTraceFiles().OrderBy(f => f) )
        if ( !SystemManager.IsFileLocked(file) )
          SelectFile.Items.Add(file);
      SelectFile.Enabled = SelectFile.Items.Count > 0;
      ActionDeleteFile.Enabled = SelectFile.Enabled;
      if ( SelectFile.Enabled )
        SelectFile.SelectedIndex = SelectFile.Items.Count - 1;
    }

    private void SelectFile_Format(object sender, ListControlConvertEventArgs e)
    {
      e.Value = Path.GetFileNameWithoutExtension((string)e.Value);
    }

    private void ActionDeleteFile_Click(object sender, EventArgs e)
    {
      if ( SelectFile.SelectedIndex < 0 ) return;
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteFile.GetLang(SelectFile.Text)) ) return;
      File.Delete((string)SelectFile.SelectedItem);
      ActionRefreshFiles.PerformClick();
    }

    private void SelectFile_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( SelectFile.SelectedIndex < 0 ) return;
      TextBoxPrevious.Clear();
      TextBoxPrevious.Lines = File.ReadAllLines((string)SelectFile.SelectedItem);
    }

  }

}
