/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-10 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.Hebrew
{
  partial class SelectValueComboBox : UserControl
  {

    public event EventHandler SelectedIndexChanged
    {
      add { SelectValue.SelectedIndexChanged += value; }
      remove { SelectValue.SelectedIndexChanged -= value; }
    }

    public ComboBox.ObjectCollection Items
    {
      get { return SelectValue.Items; }
    }

    public int Count
    {
      get { return SelectValue.Items.Count; }
    }

    public int SelectedIndex
    {
      get { return SelectValue.SelectedIndex; }
      set { SelectValue.SelectedIndex = value; }
    }

    public object SelectedItem
    {
      get { return SelectValue.SelectedItem; }
      set { SelectValue.SelectedItem = value; }
    }

    public SelectValueComboBox()
    {
      InitializeComponent();
    }

    public void Fill(IEnumerable<int> list, int selected = -1)
    {
      foreach ( int value in list )
      {
        int index = SelectValue.Items.Add(value);
        if ( value == selected )
          SelectValue.SelectedIndex = index;
      }
      if ( SelectValue.SelectedIndex == -1 )
        if ( SelectValue.Items.Count > 0 )
          SelectValue.SelectedIndex = 0;
      Refresh();
    }

    public override void Refresh()
    {
      base.Refresh();
      ActionFirst.Enabled = SelectValue.SelectedIndex > 0;
      ActionPrevious.Enabled = ActionFirst.Enabled;
      ActionLast.Enabled = SelectValue.SelectedIndex < SelectValue.Items.Count - 1;
      ActionNext.Enabled = ActionLast.Enabled;
    }

    private void SelectYearControl_VisibleChanged(object sender, EventArgs e)
    {
      Refresh();
    }

    private void SelectYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      Refresh();
    }

    private void ActionFirst_Click(object sender, EventArgs e)
    {
      SelectValue.SelectedIndex = 0;
      ActiveControl = ActionNext;
    }

    private void ActionPrevious_Click(object sender, EventArgs e)
    {
      if ( SelectValue.SelectedIndex > 0 ) SelectValue.SelectedIndex--;
      if ( SelectValue.SelectedIndex == 0 ) ActiveControl = ActionNext;
    }

    private void ActionNext_Click(object sender, EventArgs e)
    {
      if ( SelectValue.SelectedIndex < SelectValue.Items.Count - 1 ) SelectValue.SelectedIndex++;
      if ( SelectValue.SelectedIndex == SelectValue.Items.Count - 1 ) ActiveControl = ActionPrevious;
    }

    private void ActionLast_Click(object sender, EventArgs e)
    {
      SelectValue.SelectedIndex = SelectValue.Items.Count - 1;
      ActiveControl = ActionPrevious;
    }

  }

}
