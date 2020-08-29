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
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{
  public partial class ShowTextForm : Form
  {

    static public ShowTextForm Create(string title, 
                                      string text,
                                      int width = 400, 
                                      int height = 300,
                                      bool sizeable = true,
                                      bool wrap = true)
    {
      for ( int index = Application.OpenForms.Count - 1; index >= 0; index-- )
        if ( Application.OpenForms[index] is ShowTextForm )
          if ( Application.OpenForms[index].Text == title )
            Application.OpenForms[index].Close();
      var form = new ShowTextForm();
      form.Text = title;
      form.TextBox.Text = text;
      form.Width = width;
      form.Height = height;
      form.CenterToMainFormElseScreen();
      if ( !sizeable ) form.FormBorderStyle = FormBorderStyle.FixedSingle;
      form.TextBox.WordWrap = wrap;
      return form;
    }

    static public ShowTextForm Create(NullSafeStringDictionary title, 
                                      NullSafeStringDictionary text,
                                      int width = 400,
                                      int height = 300,
                                      bool sizeable = true,
                                      bool wrap = true)
    {
      var form = Create(title.GetLang(), text.GetLang(), width, height, sizeable, wrap);
      form.LocalizedTitle = title;
      form.LocalizedText = text;
      return form;
    }

    private NullSafeStringDictionary LocalizedTitle;
    private NullSafeStringDictionary LocalizedText;

    private ShowTextForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
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
