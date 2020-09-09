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
/// <created> 2019-09 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  public partial class HTMLBrowserForm : Form
  {

    private string LocationPropertyName;
    private string ClientSizePropertyName;

    private TranslationsDictionary Title;

    private string FilePathTemplate;

    private HTMLBrowserForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
      ActiveControl = WebBrowser;
    }

    public HTMLBrowserForm(TranslationsDictionary title,
                           string filePathTemplate,
                           string locationPropertyName,
                           string clientSizePropertyName) : this()
    {
      Title = title;
      FilePathTemplate = filePathTemplate;
      LocationPropertyName = locationPropertyName;
      ClientSizePropertyName = clientSizePropertyName;
      Location = (Point)Globals.Settings[locationPropertyName];
      ClientSize = (Size)Globals.Settings[clientSizePropertyName];
    }

    private void HTMLBrowserForm_Load(object sender, EventArgs e)
    {
      this.CheckLocationOrCenterToMainFormElseScreen();
    }

    internal void HTMLBrowserForm_Shown(object sender, EventArgs e)
    {
      if ( Title != null ) Text = Title.GetLang();
      if ( FilePathTemplate == null ) return;
      string filePath = string.Format(FilePathTemplate, Languages.CurrentCode);
      if ( File.Exists(filePath) )
        WebBrowser.Navigate(filePath);
      else
        DisplayManager.ShowError(Localizer.FileNotFound.GetLang(filePath));
    }

    private void HTMLBrowserForm_Deactivate(object sender, EventArgs e)
    {
      Globals.Settings[LocationPropertyName] = Location;
      Globals.Settings[ClientSizePropertyName] = ClientSize;
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
