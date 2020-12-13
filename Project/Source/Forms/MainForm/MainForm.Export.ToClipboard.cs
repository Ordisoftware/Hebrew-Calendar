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
/// <created> 2016-04 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void ExportToClipboard()
    {
      var process = new NullSafeDictionary<ViewMode, Func<int?, int?, bool>>
      {
        [ViewMode.Text] = (year1, year2) =>
        {
          Clipboard.SetText(CalendarText.Text);
          return true;
        },
        [ViewMode.Month] = (year1, year2) =>
        {
          try
          {
            CalendarMonth.ShowTodayButton = false;
            CalendarMonth.ShowArrowControls = false;
            Clipboard.SetImage(CalendarMonth.GetBitmap());
            return true;
          }
          finally
          {
            CalendarMonth.ShowTodayButton = true;
            CalendarMonth.ShowArrowControls = true;
          }
        },
        [ViewMode.Grid] = (year1, year2) =>
        {
          Clipboard.SetText(GenerateReportCSV().ToString());
          return true;
        },
      };
      Action<ViewMode> after = (view) =>
      {
        DisplayManager.ShowSuccessOrSound(AppTranslations.ViewCopiedToClipboard.GetLang(),
                                          view == ViewMode.Month ? Globals.SnapshotSoundFilePath
                                                                 : Globals.ClipboardSoundFilePath);
      };
      DoExport(ExportAction.Clipboard, process, after);
    }

  }

}