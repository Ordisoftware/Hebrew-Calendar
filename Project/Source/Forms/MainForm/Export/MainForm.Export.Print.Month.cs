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
/// <created> 2019-01 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class MainForm
  {

    private void ExportPrintMonth(ExportInterval interval)
    {
      var current = CalendarMonth.CalendarDate;
      int countPages = 0;
      bool askToContinue = true;
      bool multi = interval.IsDefined;
      if ( multi )
      {
        CalendarMonth.CalendarDate = interval.Start.Value;
        countPages = interval.MonthsCount;
      }
      int margin = Settings.PrintingMargin;
      int margin2 = margin + margin;
      double ratio = (double)CalendarMonth.Height / CalendarMonth.Width;
      //
      ExportPrintRun(Settings.PrintImageInLandscape, (s, e) =>
      {
        if ( askToContinue )
          if ( Settings.PrintPageCountWarning > 0 && countPages > Settings.PrintPageCountWarning )
            if ( !DisplayManager.QueryYesNo(SysTranslations.AskToPrintLotsOfPages.GetLang(countPages)) )
            {
              e.HasMorePages = false;
              return;
            }
            else
            {
              Application.OpenForms.All().LastOrDefault().Popup();
              askToContinue = false;
            }
          else
            askToContinue = false;
        var bounds = e.PageBounds;
        bounds.Height = (int)( bounds.Width * ratio );
        if ( bounds.Height > e.PageBounds.Height )
        {
          ratio = 1 / ratio;
          bounds.Height = e.PageBounds.Height;
          bounds.Width = (int)( bounds.Height * ratio );
        }
        bool redone = false;
        process();
        //
        void process()
        {
          var bitmap = CalendarMonth.GetBitmap();
          int delta = !redone ? 0 : e.PageBounds.Height / 2;
          e.Graphics.DrawImage(bitmap, margin, margin + delta, bounds.Width - margin2, bounds.Height - margin2);
          if ( multi )
          {
            CalendarMonth.CalendarDate = CalendarMonth.CalendarDate.AddMonths(1);
            if ( CalendarMonth.CalendarDate <= interval.End.Value )
            {
              e.HasMorePages = true;
              if ( !redone && !e.PageSettings.Landscape )
              {
                redone = true;
                process();
              }
            }
            else
            {
              CalendarMonth.CalendarDate = interval.Start.Value;
              e.HasMorePages = false;
            }
          }
          else
            e.HasMorePages = false;
        }
      });
      //
      CalendarMonth.CalendarDate = current;
    }

  }

}
