﻿/// <license>
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
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{
  public partial class ShowTextForm : Form
  {

    static public ShowTextForm CreateShabatNotice()
    {
      return Create(Translations.NoticeShabatTitle, Translations.NoticeShabatText, 600, 520);
    }

    static public ShowTextForm CreateCelebrationsNotice()
    {
      return Create(Translations.NoticeCelebrationsTitle, Translations.NoticeCelebrationsText, 600, 320);
    }

    static public ShowTextForm Create(string title, string str, int width, int height)
    {
      for ( int index = Application.OpenForms.Count - 1; index >= 0; index-- )
        if ( Application.OpenForms[index] is ShowTextForm )
          if ( Application.OpenForms[index].Text == title )
            Application.OpenForms[index].Close();
      var form = new ShowTextForm();
      form.Text = title;
      form.TextBox.Text = str;
      form.Width = width;
      form.Height = height;
      return form;
    }

    static public ShowTextForm Create(Dictionary<string, string> title, 
                                      Dictionary<string, string> text,
                                      int width,
                                      int height)
    {
      var form = Create(title.GetLang(), text.GetLang(), width, height);
      form.LocalizedTitle = title;
      form.LocalizedText = text;
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
