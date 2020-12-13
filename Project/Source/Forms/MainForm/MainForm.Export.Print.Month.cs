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
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void ExportPrintMonth()
    {
      ExportPrintRun(true, (s, e) =>
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

  }

}
