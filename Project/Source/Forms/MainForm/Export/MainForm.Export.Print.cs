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
/// <created> 2019-01 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Ordisoftware.Core;
using CoolPrintPreview;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private int PrinterCurrentLine;

    private void ExportPrint()
    {
      var process = new ExportActions()
      {
        [ViewMode.Text] = (interval) => { ExportPrintTextReport(interval); return true; },
        [ViewMode.Month] = (interval) => { ExportPrintMonth(interval); return true; },
        [ViewMode.Grid] = null
      };
      DoExport(ExportAction.Print, process, null);
    }

    private void ExportPrintRun(bool landscape, PrintPageEventHandler action)
    {
      try
      {
        CalendarMonth.ShowTodayButton = false;
        CalendarMonth.ShowArrowControls = false;
        ActionPrint.Visible = false;
        ActionPrint.Visible = true;
        ToolStrip.Enabled = false;
        MenuTray.Enabled = false;
        ExportPrintRunAction(landscape, (s, e) => action(s, e));
      }
      finally
      {
        CalendarMonth.ShowTodayButton = true;
        CalendarMonth.ShowArrowControls = true;
        ToolStrip.Enabled = true;
        MenuTray.Enabled = true;
      }
    }

    private void ExportPrintRunAction(bool landscape, PrintPageEventHandler action)
    {
      int margin = Settings.PrintingMargin;
      using ( var document = new PrintDocument() )
      {
        document.PrintPage += action;
        document.DefaultPageSettings.Landscape = landscape;
        document.DefaultPageSettings.Margins = new Margins(margin, margin, margin, margin);
        if ( Settings.ShowPrintPreviewDialog )
        {
          var preview = new CoolPrintPreviewDialog();
          preview.WindowState = FormWindowState.Maximized;
          preview.ShowInTaskbar = true;
          preview.ShowIcon = true;
          preview.Icon = Icon;
          preview.Document = document;
          preview.ShowDialog(this);
        }
        else
        {
          var dialog = new PrintDialog();
          dialog.UseEXDialog = false;
          dialog.Document = document;
          if ( dialog.ShowDialog(this) == DialogResult.OK )
          {
            document.PrintPage += printed;
            document.Print();
          }
        }
        void printed(object sender, PrintPageEventArgs e)
        {
          if ( !e.HasMorePages )
            DisplayManager.ShowSuccessOrSound(SysTranslations.ViewPrinted.GetLang(), Globals.PrinterSoundFilePath);
        }
      }

    }

  }

}
