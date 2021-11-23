/// <license>
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
/// <created> 2019-10 </created>
/// <edited> 2021-04 </edited>
namespace Ordisoftware.Core;

partial class SelectYearsControl : UserControl
{

  public event EventHandler SelectedIndexChanged
  {
    add { if ( SelectValue != null ) SelectValue.SelectedIndexChanged += value; }
    remove { if ( SelectValue != null ) SelectValue.SelectedIndexChanged -= value; }
  }

  public ComboBox.ObjectCollection Items
    => SelectValue?.Items;

  public int Count
    => SelectValue?.Items.Count ?? -1;

  public int SelectedIndex
  {
    get => SelectValue?.SelectedIndex ?? -1;
    set { if ( SelectValue != null ) SelectValue.SelectedIndex = value; }
  }

  public object SelectedItem
  {
    get => SelectValue?.SelectedItem;
    set { if ( SelectValue != null ) SelectValue.SelectedItem = value; }
  }

  public int Value
  {
    get => SelectValue.SelectedItem is int value ? value : -1;
    set { if ( SelectValue != null ) SelectValue.SelectedItem = value; }
  }

  public SelectYearsControl()
    => InitializeComponent();

  public void Fill(IEnumerable<int> list, int selected = -1)
    => Navigator.Fill(list, selected);

}
