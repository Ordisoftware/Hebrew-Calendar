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
/// <created> 2021-02 </created>
/// <edited> 2021-03 </edited>
namespace Ordisoftware.Core;

using System;
using System.Windows.Forms;

public class ComboBoxEx : ComboBox
{

  private bool Mutex;

  private int SelectedIndexLast = -1;

  public int SelectedIndexPrevious { get; private set; }

  public ComboBoxEx()
  {
    SelectedIndexPrevious = SelectedIndexLast;
  }

  protected override void OnSelectedIndexChanged(EventArgs e)
  {
    if ( Mutex ) return;
    Mutex = true;
    bool isSeparator = SelectedIndex >= 0 && (string)Items[SelectedIndex] == Globals.ListSeparator;
    if ( isSeparator ) SelectedIndex = SelectedIndexLast;
    SelectedIndexPrevious = SelectedIndexLast;
    SelectedIndexLast = SelectedIndex;
    if ( !isSeparator ) base.OnSelectedIndexChanged(e);
    Mutex = false;
  }

}
