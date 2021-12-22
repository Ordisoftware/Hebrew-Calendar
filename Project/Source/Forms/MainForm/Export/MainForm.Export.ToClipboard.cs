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
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private void ExportToClipboard()
  {
    var process = new ExportActions
    {
      [ViewMode.Text] = (interval) =>
      {
        return ProcessTextExport(interval, lines =>
        {
          Clipboard.SetText(string.Join(Globals.NL, lines));
          return true;
        });
      },
      [ViewMode.Month] = (_) =>
      {
        try
        {
          Globals.IsPrinting = true;
          CalendarMonth.ShowTodayButton = false;
          CalendarMonth.ShowArrowControls = false;
          Clipboard.SetImage(CalendarMonth.GetBitmap());
          return true;
        }
        finally
        {
          Globals.IsPrinting = false;
          CalendarMonth.ShowTodayButton = true;
          CalendarMonth.ShowArrowControls = true;
        }
      },
      [ViewMode.Grid] = (interval) =>
      {
        switch ( Settings.ExportDataPreferredTarget )
        {
          case DataExportTarget.CSV:
            Clipboard.SetText(ExportSaveCSV(interval));
            break;
          case DataExportTarget.JSON:
            Clipboard.SetText(ExportSaveJSON(interval));
            break;
          default:
            throw new AdvancedNotImplementedException(Settings.ExportDataPreferredTarget);
        }
        return true;
      },
    };
    //
    static void after(ViewMode view)
    {
      DisplayManager.ShowSuccessOrSound(SysTranslations.ViewCopiedToClipboard.GetLang(),
                                        view == ViewMode.Month ? Globals.ScreenshotSoundFilePath
                                                               : Globals.ClipboardSoundFilePath);
    }
    DoExport(ExportAction.CopyToClipboard, process, after);
  }

}
