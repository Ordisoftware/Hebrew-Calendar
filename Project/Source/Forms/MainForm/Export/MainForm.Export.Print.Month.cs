/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
      countPages = Settings.PrintImageInLandscape
        ? interval.MonthsCount
        : interval.MonthsCount / 2;
    }
    int marginTopLeft = Settings.PrintingMargin;
    int marginRightBottom = marginTopLeft + marginTopLeft;
    bool centerImage = Settings.PrintImageCenterOnPage;
    int warningTrigger = Settings.PrintPageCountWarning;
    double ratio = (double)MonthlyCalendar.Height / MonthlyCalendar.Width;
    //
    ExportPrintRun(Settings.PrintImageInLandscape, (s, e) =>
    {
      if ( askToContinue )
        if ( warningTrigger > 0 && countPages > warningTrigger )
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
      int maxWidth = e.PageBounds.Width;
      int maxHeight = e.PageSettings.Landscape
        ? e.PageBounds.Height
        : e.PageBounds.Height / 2;
      if ( bounds.Height > maxHeight && bounds.Width <= maxWidth )
      {
        bounds.Width = (int)( bounds.Width * ratio );
        bounds.Height = maxHeight;
      }
      else
      if ( bounds.Width > maxWidth && bounds.Height <= maxHeight )
      {
        bounds.Height = (int)( bounds.Height * ratio );
        bounds.Width = maxWidth;
      }
      else
      if ( bounds.Width > maxWidth && bounds.Height > maxHeight )
      {
        var bounds1 = new Rectangle();
        var bounds2 = new Rectangle();
        bounds1.Width = (int)( bounds.Width * ratio );
        bounds1.Height = maxHeight;
        bounds2.Height = (int)( bounds.Height * ratio );
        bounds2.Width = maxWidth;
        if ( bounds1.Width <= maxWidth && bounds1.Height <= maxHeight )
          bounds = bounds1;
        else
        if ( bounds2.Width <= maxWidth && bounds2.Height <= maxHeight )
          bounds = bounds2;
        else
          DebugManager.Trace(LogTraceEvent.Error, "Error on resize image in ExportPrintMonth");
      }
      bool isSecondImage = false;
      process();
      //
      void process()
      {
        using var bitmap = MonthlyCalendar.GetBitmap();
        int marginLeft = 0;
        int marginTop = 0;
        int secondImageHeightOffset = !isSecondImage ? 0 : maxHeight;
        if ( centerImage )
        {
          marginLeft = ( maxWidth - bounds.Width ) / 2;
          marginTop = ( maxHeight - bounds.Height ) / 2;
        }
        e.Graphics.DrawImage(bitmap,
                             marginTopLeft + marginLeft,
                             marginTopLeft + marginTop + secondImageHeightOffset,
                             bounds.Width - marginRightBottom,
                             bounds.Height - marginRightBottom);
        if ( multi )
        {
          MonthlyCalendar.CalendarDate = MonthlyCalendar.CalendarDate.AddMonths(1);
          if ( MonthlyCalendar.CalendarDate <= interval.End )
          {
            e.HasMorePages = true;
            if ( !isSecondImage && !e.PageSettings.Landscape )
            {
              isSecondImage = true;
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
