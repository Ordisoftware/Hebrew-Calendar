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
/// <edited> 2020-11 </edited>
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void DoSave()
    {
      string filePath = "";
      var view = Settings.CurrentView;
      if ( Settings.SelectViewToExport )
        if ( !SelectViewForm.Run(ref view, SysTranslations.TitleSaveToFile.GetLang()) )
          return;
      switch ( view )
      {
        case ViewMode.Text:
          if ( SaveFileDialog.ShowDialog() != DialogResult.OK ) return;
          filePath = SaveFileDialog.FileName;
          File.WriteAllText(filePath, CalendarText.Text);
          break;
        case ViewMode.Month:
          if ( SaveImageDialog.ShowDialog() != DialogResult.OK ) return;
          filePath = SaveImageDialog.FileName;
          try
          {
            CalendarMonth.ShowTodayButton = false;
            CalendarMonth.ShowArrowControls = false;
            CalendarMonth.GetBitmap().Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
          }
          finally
          {
            CalendarMonth.ShowTodayButton = true;
            CalendarMonth.ShowArrowControls = true;
          }
          break;
        case ViewMode.Grid:
          var content = GenerateReportCSV();
          if ( content == null ) return;
          if ( SaveCSVDialog.ShowDialog() != DialogResult.OK ) return;
          filePath = SaveCSVDialog.FileName;
          File.WriteAllText(filePath, content.ToString());
          break;
        default:
          throw new NotImplementedExceptionEx(Settings.CurrentView.ToStringFull());
      }
      DisplayManager.ShowSuccessOrSound(AppTranslations.ViewSavedToFile.GetLang(filePath),
                                        Globals.KeyboardSoundFilePath);
      if ( Settings.AutoOpenExportFolder )
        SystemManager.RunShell(Path.GetDirectoryName(filePath));
      if ( Settings.AutoOpenExportedFile )
        SystemManager.RunShell(filePath);
    }

    private void DoCopy()
    {
      var view = Settings.CurrentView;
      if ( Settings.SelectViewToExport )
        if ( !SelectViewForm.Run(ref view, SysTranslations.TitleCopyToClipboard.GetLang()) )
          return;
      switch ( view )
      {
        case ViewMode.Text:
          Clipboard.SetText(CalendarText.Text);
          break;
        case ViewMode.Month:
          try
          {
            CalendarMonth.ShowTodayButton = false;
            CalendarMonth.ShowArrowControls = false;
            Clipboard.SetImage(CalendarMonth.GetBitmap());
          }
          finally
          {
            CalendarMonth.ShowTodayButton = true;
            CalendarMonth.ShowArrowControls = true;
          }
          break;
        case ViewMode.Grid:
          Clipboard.SetText(GenerateReportCSV().ToString());
          break;
        default:
          throw new NotImplementedExceptionEx(Settings.CurrentView.ToStringFull());
      }
      DisplayManager.ShowSuccessOrSound(AppTranslations.ViewCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
    }

    private void DoPrint()
    {
      var view = Settings.CurrentView;
      if ( Settings.SelectViewToExport )
        if ( !SelectViewForm.Run(ref view, SysTranslations.TitlePrint.GetLang(), ViewMode.Month | ViewMode.Text) )
          return;
      switch ( view )
      {
        case ViewMode.Text:
          PrinterCurrentLine = 0;
          DoPrintTextReport();
          break;
        case ViewMode.Month:
          DoPrintMonth();
          break;
        case ViewMode.Grid:
        default:
          throw new NotImplementedExceptionEx(view.ToStringFull());
      }
    }

    private int PrinterCurrentLine;

    private void DoPrintTextReport()
    {
      bool askToContinue = true;
      var font = new Font(CalendarText.Font.Name, 7);
      RunPrint(false, (s, e) =>
      {
        float marginLeft = e.MarginBounds.Left;
        float marginTop = e.MarginBounds.Top;
        float posY = 0;
        int linesPerPage = (int)(e.MarginBounds.Height / font.GetHeight(e.Graphics));
        int countLinesInPage = 0;
        int countPages = (int)Math.Round((double)CalendarText.Lines.Length / linesPerPage, MidpointRounding.AwayFromZero);
        if ( askToContinue && countPages > 20 )
          if ( !DisplayManager.QueryYesNo("There are " + countPages + " pages." + Globals.NL2 + SysTranslations.AskToContinue.GetLang()) )
          {
            e.HasMorePages = false;
            return;
          }
          else
            askToContinue = false;
        while ( countLinesInPage < linesPerPage && PrinterCurrentLine < CalendarText.Lines.Length )
        {
          string line = CalendarText.Lines[PrinterCurrentLine];
          posY = marginTop + ( countLinesInPage * font.GetHeight(e.Graphics) );
          e.Graphics.DrawString(line, font, Brushes.Black, marginLeft, posY, new StringFormat());
          countLinesInPage++;
          PrinterCurrentLine++;
        }
        e.HasMorePages = PrinterCurrentLine < CalendarText.Lines.Length;
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
