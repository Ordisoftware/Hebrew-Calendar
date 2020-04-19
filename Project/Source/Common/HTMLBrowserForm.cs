/// <license>
/// This file is part of Ordisoftware Hebrew Words.
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
/// <edited> 2020-04 </edited>
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  public partial class HTMLBrowserForm : Form
  {

    private Dictionary<string, string> Title;

    private string Filename;

    public HTMLBrowserForm()
    {
      InitializeComponent();
      Icon = SystemHelper.MainForm.Icon;
      ActiveControl = WebBrowser;
    }

    public HTMLBrowserForm(Dictionary<string, string> title,
                           string filename,
                           string locationPropertyName,
                           string clientSizePropertyName)
      : this()
    {
      Title = title;
      Filename = filename;
      Location = (Point)SystemHelper.Settings[locationPropertyName];
      ClientSize = (Size)SystemHelper.Settings[clientSizePropertyName];
      DataBindings.Add(new Binding("Location", SystemHelper.Settings, locationPropertyName, true, DataSourceUpdateMode.OnPropertyChanged));
      DataBindings.Add(new Binding("ClientSize", SystemHelper.Settings, clientSizePropertyName, true, DataSourceUpdateMode.OnPropertyChanged));
    }

    private void HTMLBrowserForm_Load(object sender, EventArgs e)
    {
      if ( Location.X == -1 && Location.Y == -1 )
        this.CenterToMainForm();
    }

    internal void HTMLBrowserForm_Shown(object sender, EventArgs e)
    {
      if ( Title != null ) Text = Title.GetLang();
      if ( Filename != "" ) WebBrowser.Navigate(Filename.Replace("%LANG%", Localizer.Language));
    }

    private void HTMLBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
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

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

  }

}
