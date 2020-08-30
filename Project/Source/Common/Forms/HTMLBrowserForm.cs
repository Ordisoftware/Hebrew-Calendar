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
/// <created> 2019-09 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  public partial class HTMLBrowserForm : Form
  {

    private NullSafeStringDictionary Title;

    private string FilenameTemplate;

    public HTMLBrowserForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
      ActiveControl = WebBrowser;
    }

    public HTMLBrowserForm(NullSafeStringDictionary title,
                           string filenameTemplate,
                           string locationPropertyName,
                           string clientSizePropertyName)
      : this()
    {
      Title = title;
      FilenameTemplate = filenameTemplate;
      Location = (Point)Globals.Settings[locationPropertyName];
      ClientSize = (Size)Globals.Settings[clientSizePropertyName];
      DataBindings.Add(new Binding("Location", Globals.Settings, locationPropertyName, true, 
                                   DataSourceUpdateMode.OnPropertyChanged));
      DataBindings.Add(new Binding("ClientSize", Globals.Settings, clientSizePropertyName, true, 
                                   DataSourceUpdateMode.OnPropertyChanged));
    }

    private void HTMLBrowserForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
    }

    internal void HTMLBrowserForm_Shown(object sender, EventArgs e)
    {
      if ( Title != null ) Text = Title.GetLang();
      if ( FilenameTemplate == null ) return;
      string filename = string.Format(FilenameTemplate, Languages.Current);
      if ( File.Exists(filename) )
        WebBrowser.Navigate(filename);
      else
        DisplayManager.ShowError(Localizer.FileNotFound.GetLang(filename));
    }

    private void HTMLBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      ActiveControl = WebBrowser;
      Close();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if ( keyData == Keys.Escape)
      {
        Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

  }

}
