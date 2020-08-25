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
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private void DoCalculateDateDiff()
    {
      var formDate = new SelectDayForm();
      if ( !Visible )
      {
        formDate.StartPosition = FormStartPosition.CenterScreen;
        formDate.ShowInTaskbar = true;
      }
      formDate.Text = Translations.FirstDay.GetLang();
      if ( formDate.ShowDialog() != DialogResult.OK ) return;
      var date1 = formDate.MonthCalendar.SelectionStart.Date;
      formDate.Text = Translations.LastDay.GetLang();
      if ( formDate.ShowDialog() != DialogResult.OK ) return;
      var date2 = formDate.MonthCalendar.SelectionStart.Date;
      if ( date1 > date2 )
      {
        var temp = date2;
        date2 = date1;
        date1 = temp;
      }
      int diffSolar = ( date2 - date1 ).Days + 1;
      int diffMoon = 0;
      if ( date1 >= DateFirst && date2 <= DateLast )
        for ( DateTime date = date1; date <= date2; date = date.AddDays(1) )
          if ( DataSet.LunisolarDays.FindByDate(SQLite.GetDate(date)).Moonrise != "" )
            diffMoon++;
      string str = ActionCalculateDateDiff.Text
                 + Environment.NewLine + Environment.NewLine
                 + $"{date1.ToShortDateString()} -> {date2.ToShortDateString()}"
                 + Environment.NewLine + Environment.NewLine
                 + Translations.DiffDatesSolarCount.GetLang(diffSolar)
                 + Environment.NewLine + Environment.NewLine;
      if ( diffMoon != 0 )
        str += Translations.DiffDatesMoonCount.GetLang(diffMoon);
      else
        str += Translations.DiffDatesMoonOutOfRange.GetLang(DateFirst.Year, DateLast.Year);
      DisplayManager.Show(str);
    }

  }

}
