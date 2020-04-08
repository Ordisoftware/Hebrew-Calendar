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
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{
  public partial class ShowTextForm : Form
  {

    static public void RunCelebrationsNotice()
    {
      Run(MainForm.Instance.ActionShowCelebrationsNotice.Text, Translations.CelebrationsNotice.GetLang(), 500, 350);
    }

    static public void RunShabatNotice()
    {
      Run(MainForm.Instance.ActionShowShabatNotice.Text, Translations.PersonalShabatNotice.GetLang(), 650, 510);
    }

    static public void Run(string title, string str, int width, int height)
    {
      var form = new ShowTextForm();
      form.Text = title;
      form.TextBox.Text = str;
      form.Width = width;
      form.Height = height;
      form.ShowDialog();
    }

    private ShowTextForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

  }

}
