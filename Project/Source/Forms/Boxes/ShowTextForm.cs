/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
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
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{
  public partial class ShowTextForm : Form
  {

    static public void RunShabatNotice()
    {
      Create(Translations.NoticeShabatTitle, Translations.NoticeShabatText, 650, 510).Show();
    }

    static public void RunCelebrationsNotice()
    {
      Create(Translations.NoticeCelebrationsTitle, Translations.NoticeCelebrationsText, 500, 350).Show();
    }

    static public ShowTextForm Create(string title, string str, int width, int height)
    {
      ShowTextForm form = null;
      foreach ( Form item in Application.OpenForms )
        if ( item is ShowTextForm )
          if ( ( (ShowTextForm)item ).Text == title )
            form = (ShowTextForm)item;
      if ( form == null )
        form = new ShowTextForm();
      else
      {
        if ( form.WindowState == FormWindowState.Minimized )
          form.WindowState = FormWindowState.Normal;
        form.BringToFront();
      }
      form.Text = title;
      form.TextBox.Text = str;
      form.Width = width;
      form.Height = height;
      return form;
    }

    static public ShowTextForm Create(Dictionary<string, string> localizedTitle, Dictionary<string, string> localizedText, int width, int height)
    {
      var form = Create(localizedTitle.GetLang(), localizedText.GetLang(), width, height);
      form.LocalizedTitle = localizedTitle;
      form.LocalizedText = localizedText;
      return form;
    }

    private Dictionary<string, string> LocalizedTitle;
    private Dictionary<string, string> LocalizedText;

    private ShowTextForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    public void RelocalizeText()
    {
      if ( LocalizedTitle != null ) Text = LocalizedTitle.GetLang();
      if ( LocalizedText != null ) TextBox.Text = LocalizedText.GetLang();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

  }

}
