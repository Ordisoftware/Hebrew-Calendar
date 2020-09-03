/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
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
/// <created> 2020-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{
  public partial class TraceForm : Form
  {

    private TraceForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
    }

    public TraceForm(string locationPropertyName, string clientSizePropertyName)
      : this()
    {
      Location = (Point)Globals.Settings[locationPropertyName];
      ClientSize = (Size)Globals.Settings[clientSizePropertyName];
      DataBindings.Add(new Binding("Location", Globals.Settings, locationPropertyName, true,
                                   DataSourceUpdateMode.OnPropertyChanged));
      DataBindings.Add(new Binding("ClientSize", Globals.Settings, clientSizePropertyName, true,
                                   DataSourceUpdateMode.OnPropertyChanged));
    }

    private void LogForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
    }

    private void ShowTextForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    public void AppendText(string text, bool scrollBottom = true)
    {
      TextBox.AppendText(text);
      if ( scrollBottom )
      {
        TextBox.SelectionStart = TextBox.Text.Length - 1;
        TextBox.ScrollToCaret();
      }
    }

    private void ActionClearLogs_Click(object sender, EventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(Localizer.AskToClearLogs.GetLang()) ) return;
      DebugManager.ClearTraces();
      Show();
      BringToFront();
    }

    private void LogForm_Activated(object sender, EventArgs e)
    {
      ActionClearLogs.Enabled = DebugManager.Enabled;
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
      LabelLinesCount.Text = Localizer.TraceLinesCount.GetLang(TextBox.Lines.Length); ;
    }

  }

}
