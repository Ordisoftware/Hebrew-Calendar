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
      var process = new ExportActions
      {
        [ViewMode.Text] = (interval) =>
        {
          Clipboard.SetText(string.Join(Globals.NL, GetTextReportLines(interval)));
          return true;
        },
        [ViewMode.Month] = (interval) =>
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
        [ViewMode.Grid] = (interval) =>
        {
          switch ( Settings.ExportDataPreferredTarget )
          {
            case DataExportTarget.CSV:
              Clipboard.SetText(ExportSaveCSV(interval).ToString());
              break;
            case DataExportTarget.JSON:
              Clipboard.SetText(ExportSaveJSON(interval).ToString());
              break;
            default:
              throw new NotImplementedExceptionEx(Settings.ExportDataPreferredTarget);
          }
          return true;
        },
      };
      Action<ViewMode> after = (view) =>
      {
        DisplayManager.ShowSuccessOrSound(SysTranslations.ViewCopiedToClipboard.GetLang(),
                                          view == ViewMode.Month ? Globals.SnapshotSoundFilePath
                                                                 : Globals.ClipboardSoundFilePath);
      };
      DoExport(ExportAction.CopyToClipboard, process, after);
    }

  }

}
