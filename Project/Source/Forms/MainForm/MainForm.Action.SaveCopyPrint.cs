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
        if ( !SelectViewForm.Run(ref view, SysTranslations.TitlePrint.GetLang()) )
          return;
      switch ( view )
      {
        case ViewMode.Text:
          break;
        case ViewMode.Month:
          PrintMonthView();
          break;
        case ViewMode.Grid:
          break;
        default:
          throw new NotImplementedExceptionEx(Settings.CurrentView.ToStringFull());
      }
    }

    private void PrintMonthView()
    {
      bool finished = true;
      try
      {
        CalendarMonth.ShowTodayButton = false;
        CalendarMonth.ShowArrowControls = false;
        ActionPrint.Visible = false;
        ActionPrint.Visible = true;
        ToolStrip.Enabled = false;
        MenuTray.Enabled = false;
        var bitmap = CalendarMonth.GetBitmap().Resize(1000, CalendarMonth.Height * 1000 / CalendarMonth.Width);
        using ( var document = new PrintDocument() )
        {
          document.DefaultPageSettings.Landscape = true;
          document.PrintPage += (s, ev) => ev.Graphics.DrawImage(bitmap, 75, 75);
          PrintDialog.Document = document;
          var timer = new Timer();
          timer.Interval = 250;
          timer.Tick += (_s, _e) =>
          {
            timer.Stop();
            if ( PrintDialog.ShowDialog(this) == DialogResult.OK )
              SystemManager.TryCatchManage(() =>
              {
                document.Print();
                DisplayManager.ShowSuccessOrSound(AppTranslations.ViewPrinted.GetLang(),
                                                  Globals.PrinterSoundFilePath);
              });
            finished = true;
          };
          finished = false;
          timer.Start();
          while ( !finished ) Application.DoEvents();
        }
      }
      finally
      {
        CalendarMonth.ShowTodayButton = true;
        CalendarMonth.ShowArrowControls = true;
        ToolStrip.Enabled = true;
        MenuTray.Enabled = true;
      }
    }

  }

}
