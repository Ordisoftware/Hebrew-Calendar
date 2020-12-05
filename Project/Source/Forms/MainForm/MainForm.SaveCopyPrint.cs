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
using System.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void DoExport(ExportAction action, NullSafeDictionary<ViewMode, Func<bool>> process, Action after)
    {
      ViewMode available = ViewMode.None;
      foreach (var item in process.Where(p => p.Value != null) )
        available |= item.Key;
      var view = Settings.CurrentView;
      if ( Settings.SelectViewToExport )
        if ( !SelectViewForm.Run(action, ref view, available) )
          return;
      if ( process[view] == null )
        throw new NotImplementedExceptionEx(Settings.CurrentView.ToStringFull());
      if ( process[view].Invoke() )
        after?.Invoke();
    }

    private void DoSave()
    {
      string filePath = "";
      var process = new NullSafeDictionary<ViewMode, Func<bool>>
      {
        [ViewMode.Text] = () =>
        {
          if ( SaveFileDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveFileDialog.FileName;
          File.WriteAllText(filePath, CalendarText.Text);
          return true;
        },
        [ViewMode.Month] = () =>
        {
          if ( SaveImageDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveImageDialog.FileName;
          try
          {
            CalendarMonth.ShowTodayButton = false;
            CalendarMonth.ShowArrowControls = false;
            CalendarMonth.GetBitmap().Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            return true;
          }
          finally
          {
            CalendarMonth.ShowTodayButton = true;
            CalendarMonth.ShowArrowControls = true;
          }
        },
        [ViewMode.Grid] = () =>
        {
          var content = GenerateReportCSV();
          if ( content == null ) return false;
          if ( SaveCSVDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveCSVDialog.FileName;
          File.WriteAllText(filePath, content.ToString());
          return true;
        }
      };
      Action after = () =>
      {
        DisplayManager.ShowSuccessOrSound(AppTranslations.ViewSavedToFile.GetLang(filePath),
                                          Globals.KeyboardSoundFilePath);
        if ( Settings.AutoOpenExportFolder )
          SystemManager.RunShell(Path.GetDirectoryName(filePath));
        if ( Settings.AutoOpenExportedFile )
          SystemManager.RunShell(filePath);
      };
      DoExport(ExportAction.File, process, after);
    }

    private void DoCopy()
    {
      var process = new NullSafeDictionary<ViewMode, Func<bool>>
      {
        [ViewMode.Text] = () =>
        {
          Clipboard.SetText(CalendarText.Text);
          return true;
        },
        [ViewMode.Month] = () =>
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
        [ViewMode.Grid] = () =>
        {
          Clipboard.SetText(GenerateReportCSV().ToString());
          return true;
        },
      };
      Action after = () =>
      {
        DisplayManager.ShowSuccessOrSound(AppTranslations.ViewCopiedToClipboard.GetLang(),
                                          Globals.ClipboardSoundFilePath);
      };
      DoExport(ExportAction.Clipboard, process, after);
    }

    private void DoPrint()
    {
      var process = new NullSafeDictionary<ViewMode, Func<bool>>
      {
        [ViewMode.Text] = () => { DoPrintTextReport(); return true; },
        [ViewMode.Month] = () =>{ DoPrintMonth(); return true; },
        [ViewMode.Grid] = null
      };
      DoExport(ExportAction.Print, process, null);
    }

    private int PrinterCurrentLine;

    const int PrintAskToContinueTrigger = 50;

    private void DoPrintTextReport()
    {
      var formatString = new StringFormat();
      var font = new Font(CalendarText.Font.Name, Settings.PrintingMargin > 75 ? 6 : 7);
      float fontHeight = -1;
      float marginLeft = -1;
      float marginTop = -1;
      int linesPerPage = -1;
      int countPages = -1;
      int countTotalLines = CalendarText.Lines.Length;
      bool askToContinue = true;
      PrinterCurrentLine = 0;
      RunPrint(false, (s, e) =>
      {
        float posY = 0;
        int countLinesInPage = 0;
        if ( fontHeight == -1 )
          fontHeight = font.GetHeight(e.Graphics);
        if ( marginLeft == -1 )
          marginLeft = e.MarginBounds.Left;
        if ( marginTop == -1 )
          marginTop = e.MarginBounds.Top;
        if ( linesPerPage == -1 )
          linesPerPage = (int)( e.MarginBounds.Height / font.GetHeight(e.Graphics) );
        if ( countPages == -1 )
          countPages = (int)Math.Round((double)countTotalLines / linesPerPage, MidpointRounding.AwayFromZero);
        if ( askToContinue )
          if ( Settings.PrintPageCountWarning > 0 && countPages > Settings.PrintPageCountWarning )
            if ( !DisplayManager.QueryYesNo(SysTranslations.AskToPrintLotsOfPages.GetLang(countPages)) )
            {
              e.HasMorePages = false;
              return;
            }
            else
            {
              var form = Application.OpenForms.ToList().LastOrDefault();
              form.Popup();
              askToContinue = false;
            }
          else
            askToContinue = false;
        while ( countLinesInPage < linesPerPage && PrinterCurrentLine < countTotalLines )
        {
          string line = CalendarText.Lines[PrinterCurrentLine];
          posY = marginTop + countLinesInPage * fontHeight;
          e.Graphics.DrawString(line, font, Brushes.Black, marginLeft, posY);
          countLinesInPage++;
          PrinterCurrentLine++;
        }
        e.HasMorePages = PrinterCurrentLine < countTotalLines;
        System.Threading.Thread.Sleep(10);
        Application.DoEvents();
      });
    }

    private void DoPrintMonth()
    {
      RunPrint(true, (s, e) =>
      {
        int margin = Settings.PrintingMargin;
        int margin2 = margin + margin;
        var bitmap = CalendarMonth.GetBitmap();
        var bounds = e.PageBounds;
        double ratio = (double)CalendarMonth.Height / CalendarMonth.Width;
        bounds.Height = (int)( bounds.Width * ratio );
        if ( bounds.Height > e.PageBounds.Height )
        {
          ratio = 1 / ratio;
          bounds.Height = e.PageBounds.Height;
          bounds.Width = (int)( bounds.Height * ratio );
        }
        e.Graphics.DrawImage(bitmap, margin, margin, bounds.Width - margin2, bounds.Height - margin2);
      });
    }

    private void RunPrint(bool landscape, PrintPageEventHandler action)
    {
      try
      {
        CalendarMonth.ShowTodayButton = false;
        CalendarMonth.ShowArrowControls = false;
        ActionPrint.Visible = false;
        ActionPrint.Visible = true;
        ToolStrip.Enabled = false;
        MenuTray.Enabled = false;
        DoPrint(landscape, (s, e) =>
        {
          action(s, e);
        });
      }
      finally
      {
        CalendarMonth.ShowTodayButton = true;
        CalendarMonth.ShowArrowControls = true;
        ToolStrip.Enabled = true;
        MenuTray.Enabled = true;
      }
    }

    private void DoPrint(bool landscape, PrintPageEventHandler action)
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
