/// <license>
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
/// <created> 2016-04 </created>
/// <edited> 2020-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class PreferencesForm
{

  /// <summary>
  /// Process the command key.
  /// </summary>
  /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    if ( keyData >= Keys.F1 && keyData < Keys.F1 + TabControl.TabCount )
    {
      TabControl.SelectTab(keyData - Keys.F1);
      return true;
    }
    if ( keyData == ( Keys.Control | Keys.Tab ) )
    {
      if ( TabControl.SelectedIndex == TabControl.TabCount - 1 )
        TabControl.SelectedIndex = 0;
      else
        TabControl.SelectedIndex++;
      return true;
    }
    if ( keyData == ( Keys.Control | Keys.Shift | Keys.Tab ) )
    {
      if ( TabControl.SelectedIndex == 0 )
        TabControl.SelectedIndex = TabControl.TabCount - 1;
      else
        TabControl.SelectedIndex--;
      return true;
    }
    return base.ProcessCmdKey(ref msg, keyData);
  }

}
