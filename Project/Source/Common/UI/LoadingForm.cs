/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  public partial class LoadingForm : Form
  {

    public LoadingForm()
    {
      InitializeComponent();
      this.CenterToMainForm();
      LabelTitle.Text = Globals.AssemblyTitle;
    }

    public void UpdateProgress(int index, int count, string text)
    {
      if ( index == 0 ) ProgressBar.Maximum = count;
      ProgressBar.Value = index > count ? count : index;
      ProgressBar.Update();
      if ( LabelOperation.Text != text )
      {
        LabelOperation.Text = text;
        LabelOperation.Refresh();
      }
      Application.DoEvents();
    }

  }

}
