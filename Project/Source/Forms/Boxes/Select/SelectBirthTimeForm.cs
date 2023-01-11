/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2019-10 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class SelectBirthTimeForm : Form
{

  static public bool Run(out TimeSpan time)
  {
    using var form = new SelectBirthTimeForm();
    bool result = form.ShowDialog() == DialogResult.OK;
    time = result ? form.EditTime.Value.TimeOfDay : TimeSpan.MinValue;
    return result;
  }

  private SelectBirthTimeForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
  }

}
