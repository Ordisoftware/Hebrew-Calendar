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
using Ordisoftware.HebrewWords;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MoonMonthsForm : Form
  {

    public MoonMonthsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      EventHandler action = (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var control = ( (ContextMenuStrip)menuitem.OwnerItem.Owner ).SourceControl;
        Program.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", ListView.FocusedItem.Text));
      };
      int index = 0;
      foreach ( var item in OnlineWordProviders.Items )
      {
        if ( item.Name == "-" )
          ActionSearchOnline.DropDownItems.Insert(index++, new ToolStripSeparator());
        else
          ActionSearchOnline.DropDownItems.Insert(index++, item.CreateMenuItem(action));
      }
      for ( index = 1; index < MoonMonths.Names.Length; index++ )
      {
        var item = ListView.Items.Add(MoonMonths.Hebrew[index]);
        item.SubItems.Add(MoonMonths.Names[index]);
        item.SubItems.Add(MoonMonths.Meanings[index]);
        item.SubItems.Add(MoonMonths.Lettriqs[index]);
      }
    }

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      Program.OpenHebrewLetters(HebrewLetters.ConvertToHebrewFont(ListView.FocusedItem.Text));
    }

  }

}
