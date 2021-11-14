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
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide years interval item.
  /// </summary>
  class YearsIntervalItem
  {

    public int YearsBefore { get; }
    public int YearsAfter { get; }
    public int Length { get; }
    public int OriginalValue { get; }

    public YearsIntervalItem(int length)
    {
      OriginalValue = length;
      if ( length >= 0 )
      {
        YearsBefore = 0;
        YearsAfter = length;
        Length = length;
      }
      else
      {
        length = -length;
        YearsBefore = length;
        YearsAfter = length;
        Length = length + length;
      }
    }

    static public void InitializeMenu(ContextMenuStrip menu, int max, EventHandler handler)
    {
      menu.Items.Clear();
      foreach ( int value in Program.PredefinedYearsIntervals )
      {
        var interval = new YearsIntervalItem(value);
        if ( interval.Length <= max && interval.Length <= Program.Settings.GenerateIntervalMaximum )
        {
          var item = new ToolStripMenuItem
          {
            Text = value >= 0
                   ? AppTranslations.PredefinedYearsIntervalAfter.GetLang(value)
                   : AppTranslations.PredefinedYearsIntervalBeforeAndAfter.GetLang(-value),
            Tag = interval
          };
          item.Click += handler;
          menu.Items.Add(item);
        }
      }

    }

  }

}
