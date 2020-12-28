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
/// <created> 2020-04 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MoonMonthsForm : Form
  {

    private Color[] ColorsSystem = new Color[]
    {
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText,
      SystemColors.ControlText
    };

    private Color[] ColorsPastel = new Color[]
    {
      Color.FromArgb(255, 230, 80),
      Color.FromArgb(255, 230, 80),
      Color.FromArgb(255, 230, 80),
      Color.Orchid,
      Color.Orchid,
      Color.Orchid,
      Color.SpringGreen,
      Color.SpringGreen,
      Color.SpringGreen,
      Color.White,
      Color.White,
      Color.White,
      Color.White
    };

    private Color[] ColorsFlashy = new Color[]
    {
      Color.Yellow,
      Color.Yellow,
      Color.Yellow,
      Color.Fuchsia,
      Color.Fuchsia,
      Color.Fuchsia,
      Color.Lime,
      Color.Lime,
      Color.Lime,
      Color.White,
      Color.White,
      Color.White,
      Color.White
    };

  }

}
