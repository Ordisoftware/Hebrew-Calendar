/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
/// <edited> 2020-11 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  public enum WebUpdateSelection
  {
    None,
    Install,
    Download,
  }

  public partial class WebUpdateForm : Form
  {

    static public WebUpdateSelection Run (Version version)
    {
      using ( var form = new WebUpdateForm() )
      {
        form.LabelCurrentversion.Text += Globals.AssemblyVersion;
        form.LabelNewVersion.Text += version;
        form.ActionReleaseNotes.Tag = string.Format(Globals.ApplicationReleaseNotesURL, version);
        if ( form.ShowDialog() != DialogResult.OK ) return WebUpdateSelection.None;
        if ( form.SelectInstall.Checked ) return WebUpdateSelection.Install;
        if ( form.SelectDownload.Checked ) return WebUpdateSelection.Download;
        throw new NotImplementedExceptionEx($"User selection in {form.GetType().Name}.{nameof(Run)}");
      }
    }

    private WebUpdateForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
      Text = Text + Globals.AssemblyTitle;
      this.CenterToMainFormElseScreen();
    }

    private void ActionOpenWebPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      SystemManager.OpenWebLink((string)( (LinkLabel)sender ).Tag);
    }

    private void WebUpdateForm_Shown(object sender, EventArgs e)
    {
      DisplayManager.DoSound(MessageBoxIcon.Question);
    }
  }

}
