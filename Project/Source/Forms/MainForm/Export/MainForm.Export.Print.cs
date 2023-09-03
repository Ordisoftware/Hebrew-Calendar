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
/// <created> 2019-01 </created>
/// <edited> 2023-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.Drawing.Printing;
using CoolPrintPreview;

partial class MainForm
{

  private int PrinterCurrentLine;

  private void ExportPrint()
  {
    var process = new ExportActions
    {
      [ViewMode.Text] = (interval) =>
      {
        return ProcessTextExport(interval, lines =>
        {
          ExportPrintTextReport(lines);
          return true;
        });
      },
      [ViewMode.Month] = (interval) =>
      {
        ExportPrintMonth(interval);
        return true;
      },
      [ViewMode.Grid] = null
    };
    DoExport(ExportAction.Print, process, null);
  }

  [SuppressMessage("Style", "GCop408:Flag or switch parameters (bool) should go after all non-optional parameters. If the boolean parameter is not a flag or switch, split the method into two different methods, each doing one thing.", Justification = "Opinion")]
  private void ExportPrintRun(bool landscape, PrintPageEventHandler action)
  {
    FreezeUI();
    try
    {
      Globals.IsPrinting = true;
      MonthlyCalendar.ShowTodayButton = false;
      MonthlyCalendar.ShowArrowControls = false;
      ActionPrint.Visible = false;
      ActionPrint.Visible = true;
      ExportPrintRunAction(landscape, (s, e) => action(s, e));
    }
    finally
    {
      Globals.IsPrinting = false;
      MonthlyCalendar.ShowTodayButton = true;
      MonthlyCalendar.ShowArrowControls = true;
      RestoreUI();
    }
  }

  [SuppressMessage("Style", "GCop408:Flag or switch parameters (bool) should go after all non-optional parameters. If the boolean parameter is not a flag or switch, split the method into two different methods, each doing one thing.", Justification = "Opinion")]
  private void ExportPrintRunAction(bool landscape, PrintPageEventHandler action)
  {
    int margin = Settings.PrintingMargin;
    using var document = new PrintDocument();
    document.PrintPage += action;
    document.DefaultPageSettings.Landscape = landscape;
    document.DefaultPageSettings.Margins = new Margins(margin, margin, margin, margin);
    if ( Settings.ShowPrintPreviewDialog )
    {
      using var preview = new CoolPrintPreviewDialog
      {
        WindowState = FormWindowState.Maximized,
        ShowInTaskbar = true,
        ShowIcon = true,
        Icon = Icon,
        Document = document
      };
      preview.ShowDialog(this);
    }
    else
    {
      using var dialog = new PrintDialog
      {
        UseEXDialog = false,
        Document = document
      };
      if ( dialog.ShowDialog(this) == DialogResult.OK )
      {
        document.PrintPage += printed;
        document.Print();
      }
    }
    //
    void printed(object sender, PrintPageEventArgs e)
    {
      if ( !e.HasMorePages )
        DisplayManager.ShowSuccessOrSound(SysTranslations.ViewPrinted.GetLang(), Globals.PrinterSoundFilePath);
    }

  }

}
