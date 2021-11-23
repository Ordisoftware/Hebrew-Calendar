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
/// <created> 2020-12 </created>
/// <edited> 2021-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

partial class MainForm
{

  private void ExportPrintTextReport(ExportInterval interval)
  {
    var lines = GetTextReportLines(interval).ToList();
    var font = new Font(CalendarText.Font.Name, Settings.PrintingMargin > 75 ? 6 : 7);
    float fontHeight = -1;
    float marginLeft = -1;
    float marginTop = -1;
    int linesPerPage = -1;
    int countPages = -1;
    int countTotalLines = lines.Count;
    bool askToContinue = true;
    PrinterCurrentLine = 0;
    ExportPrintRun(false, (s, e) =>
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
            Application.OpenForms.GetAll().LastOrDefault()?.Popup();
            askToContinue = false;
          }
        else
          askToContinue = false;
      while ( countLinesInPage < linesPerPage && PrinterCurrentLine < countTotalLines )
      {
        string line = lines[PrinterCurrentLine];
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

}
