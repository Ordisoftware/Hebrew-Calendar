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
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void ExportPrintMonth(int? year1, int? year2)
    {
      var current = CalendarMonth.CalendarDate;
      int countPages = 0;
      bool askToContinue = true;
      bool multi = year1.HasValue && year2.HasValue;
      if ( multi )
      {
        CalendarMonth.CalendarDate = new DateTime(year1.Value, 1, 1);
        countPages = ( year2.Value - year1.Value ) * 12;
      }
      int margin = Settings.PrintingMargin;
      int margin2 = margin + margin;
      double ratio = (double)CalendarMonth.Height / CalendarMonth.Width;
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
              var form = Application.OpenForms.ToList().LastOrDefault();
              form?.Popup();
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
        TwoPerPage:
        var bitmap = CalendarMonth.GetBitmap();
        int delta = !redone ? 0 : e.PageBounds.Height / 2;
        e.Graphics.DrawImage(bitmap, margin, margin + delta, bounds.Width - margin2, bounds.Height - margin2);
        if ( multi )
          if ( !( CalendarMonth.CalendarDate.Year == year2.Value && CalendarMonth.CalendarDate.Month == 12 ) )
          {
            CalendarMonth.CalendarDate = CalendarMonth.CalendarDate.AddMonths(1);
            e.HasMorePages = true;
            if ( !redone && !e.PageSettings.Landscape )
            {
              redone = true;
              goto TwoPerPage;
            }
          }
          else
          {
            CalendarMonth.CalendarDate = new DateTime(year1.Value, 1, 1);
            e.HasMorePages = false;
          }
        else
          e.HasMorePages = false;
      });
      CalendarMonth.CalendarDate = current;
    }

  }

}