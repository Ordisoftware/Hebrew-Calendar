﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class SelectSuspendDelayForm : Form
  {

    static private readonly Properties.Settings Settings = Program.Settings;

    static public int? Run()
    {
      using ( var form = new SelectSuspendDelayForm() )
      {
        if ( form.ShowDialog() != DialogResult.OK ) return null;
        int value = ( (SuspendDelayItem)form.SelectDelay.SelectedItem ).Minutes;
        if ( value == -1 ) value = (int)form.EditDelay.Value;
        return value;
      }
    }

    private SelectSuspendDelayForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void SelectSuspendDelayForm_Load(object sender, EventArgs e)
    {
      if ( MainForm.Instance.Visible )
        this.CenterToMainFormElseScreen();
      else
        this.SetLocation(ControlLocation.BottomRight);
      SelectDelay.Items.AddRange(AppTranslations.SuspendReminderDelays.GetLang().ToArray());
      SelectDelay.SelectedIndex = -1;
      foreach ( SuspendDelayItem item in SelectDelay.Items )
        if ( Settings.LastSuspendDelaySelected == item.Minutes )
        {
          SelectDelay.SelectedItem = item;
          break;
        }
      if ( SelectDelay.SelectedIndex == -1 )
      {
        SelectDelay.SelectedIndex = SelectDelay.Items.Count - 1;
        EditDelay.Value = Settings.LastSuspendDelaySelected;
      }
    }

    private void SelectDelay_SelectedIndexChanged(object sender, EventArgs e)
    {
      int value = ( (SuspendDelayItem)SelectDelay.SelectedItem ).Minutes;
      EditDelay.Enabled = value == -1;
      LabelCustom.Enabled = EditDelay.Enabled;
      if ( !EditDelay.Enabled )
        EditDelay.Value = value;
    }

    private void ActionOK_Click(object sender, EventArgs e)
    {
      Settings.LastSuspendDelaySelected = SelectDelay.SelectedIndex == SelectDelay.Items.Count - 1
                                          ? (int)EditDelay.Value
                                          : ( (SuspendDelayItem)SelectDelay.SelectedItem ).Minutes;
      SystemManager.TryCatch(Settings.Save);
    }

  }

}
