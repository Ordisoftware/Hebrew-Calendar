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
/// <created> 2019-01 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    const int PrintAskToContinueTrigger = 10;   // TODO option
    private int PrinterCurrentLine;

    private void ExportPrint()
    {
      var process = new NullSafeDictionary<ViewMode, Func<bool>>
      {
        [ViewMode.Text] = () => { ExportPrintTextReport(); return true; },
        [ViewMode.Month] = () => { ExportPrintMonth(); return true; },
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
      bool finished = false;
      bool mutex = false;
      using ( var document = new PrintDocument() )
      {
        document.PrintPage += action;
        document.DefaultPageSettings.Landscape = landscape;
        document.DefaultPageSettings.Margins = new Margins(margin, margin, margin, margin);
        var timer = new Timer();
        timer.Interval = 250;
        timer.Tick += print;
        timer.Start();
        while ( !finished ) Application.DoEvents();
        void printed(object sender, PrintPageEventArgs e)
        {
          if ( !e.HasMorePages )
            DisplayManager.ShowSuccessOrSound(AppTranslations.ViewPrinted.GetLang(), Globals.PrinterSoundFilePath);
        }
        void print(object sender, EventArgs e)
        {
          timer.Stop();
          PrintDialog.Document = document;
          if ( PrintDialog.ShowDialog(this) == DialogResult.OK )
            SystemManager.TryCatchManage(() =>
            {
              if ( Settings.ShowPrintPreviewDialog )
              {
                var preview = new PrintPreviewDialog();
                ( (Form)preview ).WindowState = FormWindowState.Maximized;
                ( (Form)preview ).ShowInTaskbar = true;
                ( (Form)preview ).Icon = Icon;
                preview.Document = document;
                preview.ShowIcon = true;
                preview.PrintPreviewControl.Zoom = 1;
                preview.PrintPreviewControl.UseAntiAlias = true;
                if ( preview.Controls.Count >= 2 )
                {
                  var toolstrip = preview.Controls[1] as ToolStrip;
                  if ( toolstrip != null && toolstrip.Items.Count > 1 )
                    toolstrip.Items[0].Click += (_s, _e) =>
                    {
                      if ( mutex ) return;
                      document.PrintPage += printed;
                      mutex = true;
                    };
                }
                preview.ShowDialog();
              }
              else
              {
                document.PrintPage += printed;
                document.Print();
              }
            });
          finished = true;
        }
      }

    }

  }

}