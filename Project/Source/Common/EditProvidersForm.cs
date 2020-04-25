/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
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
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  public partial class EditProvidersForm : Form
  {

    static public bool Run(OnlineProviders providers, string nameInstance)
    {
      var form = new EditProvidersForm();
      form.Text = nameInstance;
      AddTab(form.TabControl, providers);
      bool result = form.ShowDialog() == DialogResult.OK;
      if ( result ) providers.ReLoad();
      return result;
    }

    static public bool Run(List<OnlineProviders> listProviders, string nameInstance)
    {
      var form = new EditProvidersForm();
      form.Text = nameInstance;
      foreach ( var item in listProviders )
        AddTab(form.TabControl, item);
      bool result = form.ShowDialog() == DialogResult.OK;
      if (result) foreach ( var item in listProviders ) item.ReLoad();
      return result;
    }

    static void AddTab(TabControl tabcontrol, OnlineProviders providers)
    {
      if ( !File.Exists(providers.FilenameUser) )
      {
        DisplayManager.ShowError(Globals.FileNotFound.GetLang(providers.FilenameUser));
        return;
      }
      var textbox = new UndoRedoTextBox();
      textbox.Font = new Font("Consolas", 11F);
      textbox.Multiline = true;
      textbox.WordWrap = false;
      textbox.ScrollBars = ScrollBars.Both;
      textbox.Dock = DockStyle.Fill;
      textbox.Text = File.ReadAllText(providers.FilenameUser);
      var tabpage = new TabPage(Path.GetFileName(providers.FilenameUser).Replace(".txt", ""));
      tabpage.Tag = providers;
      tabpage.Controls.Add(textbox);
      tabcontrol.TabPages.Add(tabpage);
    }

    public EditProvidersForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
    }

    private void EditProvidersForm_Load(object sender, EventArgs e)
    {
      if ( Location.X == -1 || Location.Y == -1 )
        this.CenterToMainForm();
    }

    private void EditProvidersForm_Shown(object sender, EventArgs e)
    {
      UndoRedoTextBox textbox = (UndoRedoTextBox)TabControl.TabPages[0].Controls[0];
      textbox.Focus();
      textbox.SelectionLength = 0;
    }

    private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      UndoRedoTextBox textbox = (UndoRedoTextBox)TabControl.SelectedTab.Controls[0];
      textbox.Focus();
      textbox.SelectionLength = 0;
    }

    private void ActionReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(Globals.AskToLoadInstalledData.GetLang()) ) return;
      foreach ( TabPage page in TabControl.TabPages )
        try
        {
          ( (TextBox)page.Controls[0] ).Text = File.ReadAllText(( (OnlineProviders)page.Tag ).FilenameDefault);
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
    }

    private void ActionOk_Click(object sender, EventArgs e)
    {
      foreach ( TabPage page in TabControl.TabPages )
        try
        {
          File.WriteAllText(( (OnlineProviders)page.Tag ).FilenameUser, ( (TextBox)page.Controls[0] ).Text);
        }
        catch ( Exception ex )
        {
          ex.Manage();
        }
    }

  }

}
