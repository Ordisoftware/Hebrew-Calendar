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
/// <created> 2020-08 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SuspendReminderDelayForm : Form
  {

    public class Delay
    {
      public string Text { get; set; }
      public int Minutes { get; set; }
      public override string ToString() => Text;
      public Delay(string text, int minutes)
      {
        Text = text;
        Minutes = minutes;
      }
    }

    static public Dictionary<string, List<Delay>> Delays = new Dictionary<string, List<Delay>>
    {
      { 
        "en",
        new List<Delay> 
        {
          new Delay("None", 0),
          new Delay("5 minutes", 5),
          new Delay("10 minutes", 10),
          new Delay("15 minutes", 15),
          new Delay("30 minutes", 30),
          new Delay("1 hour", 60),
          new Delay("2 hours", 120),
          new Delay("3 hours", 180),
          new Delay("4 hours", 240),
          new Delay("6 hours", 360),
          new Delay("12 hours", 720),
          new Delay("1 day", 1440),
          new Delay("Custom", -1)
        }
      },
      {
        "fr",
        new List<Delay>
        {
          new Delay("Aucun", 0),
          new Delay("5 minutes", 5),
          new Delay("10 minutes", 10),
          new Delay("15 minutes", 15),
          new Delay("30 minutes", 30),
          new Delay("1 heure", 60),
          new Delay("2 heures", 120),
          new Delay("3 heures", 180),
          new Delay("4 heures", 240),
          new Delay("6 heures", 360),
          new Delay("12 heures", 720),
          new Delay("1 jour", 1440),
          new Delay("Personnalisé", -1)
        }
      }
    };

    static public int? Run()
    {
      var form = new SuspendReminderDelayForm();
      if ( form.ShowDialog() == DialogResult.OK )
      {
        var item = form.SelectDelay.SelectedItem;
        int value = ((Delay)form.SelectDelay.SelectedItem).Minutes;
        if ( value == 0 ) value = (int)form.EditDelay.Value;
        return value;
      }
      else
        return null;
    }

    private SuspendReminderDelayForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      SelectDelay.Items.AddRange(Delays.GetLang().ToArray());
      SelectDelay.SelectedIndex = -1;
      foreach ( Delay item in SelectDelay.Items )
        if ( Program.Settings.LastSuspendDelaySelected == item.Minutes )
        {
          SelectDelay.SelectedItem = item;
          break;
        }
      if ( SelectDelay.SelectedItem == null )
      {
        SelectDelay.SelectedIndex = SelectDelay.Items.Count - 1;
        EditDelay.Value = Program.Settings.LastSuspendDelaySelected;
      }
    }

    private void SelectDelay_SelectedIndexChanged(object sender, EventArgs e)
    {
      int value = ( (Delay)SelectDelay.SelectedItem ).Minutes;
      EditDelay.Enabled = value == -1;
      if ( !EditDelay.Enabled )
        EditDelay.Value = value;
    }

    private void ActionOk_Click(object sender, EventArgs e)
    {
      if ( SelectDelay.SelectedIndex == SelectDelay.Items.Count - 1 )
        Program.Settings.LastSuspendDelaySelected = (int)EditDelay.Value;
      else
        Program.Settings.LastSuspendDelaySelected = ( (Delay)SelectDelay.SelectedItem ).Minutes;
      Program.Settings.Save();
    }
  }

}
