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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class DatesDiffForm : Form
  {

    static public void Run(Tuple<DateTime, DateTime> date = null)
    {
      var form = new DatesDiffForm();
      if ( date != null )
      {
        form.MonthCalendar1.SelectionStart = date.Item1;
        form.MonthCalendar2.SelectionStart = date.Item2;
        form.ActionCalculate_Click(null, null);
      }
      form.ShowDialog();
    }

    private DatesDiffForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void DateDiffForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
    }

    private void ActionCalculate_Click(object sender, EventArgs e)
    {
      var stats = new DatesDiffItem(MonthCalendar1.SelectionStart, MonthCalendar2.SelectionStart);
      try
      {
        Cursor = Cursors.WaitCursor;
        textBox1.Text = $"{stats.Dates.Item1.ToShortDateString()} -> {stats.Dates.Item2.ToShortDateString()}"
                      + Environment.NewLine + Environment.NewLine
                      + Translations.DiffDatesSolarDaysCount.GetLang(stats.SolarDays) + Environment.NewLine
                      + Translations.DiffDatesSolarWeeksCount.GetLang(stats.SolarWeeks) + Environment.NewLine
                      + Translations.DiffDatesSolarMonthsCount.GetLang(stats.SolarMonths) + Environment.NewLine
                      + Environment.NewLine
                      + Translations.DiffDatesMoonDaysCount.GetLang(stats.MoonDays) + Environment.NewLine
                      + Translations.DiffDatesMoonLunationCount.GetLang(stats.Lunations)/* + Environment.NewLine
                      + Translations.DiffDatesMoonLunationCount.GetLang(stats.MoonYears)*/;
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }
  }

}
