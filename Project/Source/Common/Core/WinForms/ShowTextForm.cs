﻿/// <license>
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
/// <edited> 2020-11 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  partial class ShowTextForm : Form
  {

    private bool HideOnClose;
    private TranslationsDictionary LocalizedTitle;
    private TranslationsDictionary LocalizedText;

    private ShowTextForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm?.Icon;
    }

    public ShowTextForm(string title,
                        string text,
                        bool hideOnClose = false,
                        bool sizeable = true,
                        int width = 400,
                        int height = 300,
                        bool wrap = true,
                        bool justify = true)
      : this()
    {
      Text = title;
      if ( !justify ) TextBox.SelectionAlignment = TextAlign.Left;
      if ( !sizeable ) MaximumSize = new System.Drawing.Size(0, 0);
      TextBox.Text = text;
      Width = width;
      Height = height;
      this.CenterToMainFormElseScreen();
      if ( !sizeable ) FormBorderStyle = FormBorderStyle.FixedSingle;
      TextBox.WordWrap = wrap;
      HideOnClose = hideOnClose;
    }

    public ShowTextForm(TranslationsDictionary title,
                        TranslationsDictionary text,
                        bool hideOnClose = false,
                        bool sizeable = true,
                        int width = 400,
                        int height = 300,
                        bool wrap = true,
                        bool justify = true)
      : this(title.GetLang(), text.GetLang(), hideOnClose, sizeable, width, height, wrap, justify)
    {
      LocalizedTitle = title;
      LocalizedText = text;
    }

    public void Relocalize()
    {
      if ( LocalizedTitle != null ) Text = LocalizedTitle.GetLang();
      if ( LocalizedText != null ) TextBox.Text = LocalizedText.GetLang();
    }

    private void ShowTextForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( !HideOnClose ) return;
      e.Cancel = true;
      Hide();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

  }

}
