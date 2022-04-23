/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  [SuppressMessage("Design", "GCop132:Since the type is inferred, use 'var' instead", Justification = "Anti-pattern on numeric types and strings")]
  [SuppressMessage("Design", "GCop176:This anonymous method should not contain complex code, Instead call other focused methods to perform the complex logic", Justification = "<En attente>")]
  private void ExportPrintMonth(ExportInterval interval)
  {
    var current = MonthlyCalendar.CalendarDate;
    int countPages = 0;
    bool askToContinue = true;
    bool multi = interval.IsDefined;
    if ( multi )
    {
      MonthlyCalendar.CalendarDate = interval.Start.Value;
      countPages = interval.MonthsCount;
    }
    int margin = Settings.PrintingMargin;
    int margin2 = margin + margin;
    double ratio = (double)MonthlyCalendar.Height / MonthlyCalendar.Width;
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
            Application.OpenForms.GetAll().LastOrDefault().Popup();
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
        using var bitmap = MonthlyCalendar.GetBitmap();
        int delta = !redone ? 0 : e.PageBounds.Height / 2;
        e.Graphics.DrawImage(bitmap, margin, margin + delta, bounds.Width - margin2, bounds.Height - margin2);
        if ( multi )
        {
          MonthlyCalendar.CalendarDate = MonthlyCalendar.CalendarDate.AddMonths(1);
          if ( MonthlyCalendar.CalendarDate <= interval.End )
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
            MonthlyCalendar.CalendarDate = interval.Start.Value;
            e.HasMorePages = false;
          }
        }
        else
          e.HasMorePages = false;
      }
    });
    //
    MonthlyCalendar.CalendarDate = current;
  }

}
