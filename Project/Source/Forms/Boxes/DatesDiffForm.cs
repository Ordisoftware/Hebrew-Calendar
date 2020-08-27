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
/// <created> 2020-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class DatesDiffForm : Form
  {

    static public void Run(Tuple<DateTime, DateTime> dates = null)
    {
      var form = new DatesDiffForm();
      if ( dates != null )
      {
        form.MonthCalendar1.SelectionStart = dates.Item1;
        form.MonthCalendar2.SelectionStart = dates.Item2;
      }
      form.MonthCalendar1.Tag = form.MonthCalendar1.SelectionStart;
      form.MonthCalendar2.Tag = form.MonthCalendar2.SelectionStart;
      form.DateChanged(true);
      form.ShowDialog();
    }

    private DatesDiffItem Stats;

    private DatesDiffForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      MonthCalendar1.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
      MonthCalendar1.MaxDate = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime;
      MonthCalendar2.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
      MonthCalendar2.MaxDate = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime;
      DateTimePicker1.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
      DateTimePicker1.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
      DateTimePicker2.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
      DateTimePicker2.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
    }

    private void DateDiffForm_Load(object sender, EventArgs e)
    {
      if ( Location.X < 0 || Location.Y < 0 )
        this.CenterToMainFormElseScreen();
    }

    private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
      MonthCalendar1.SelectionStart = DateTimePicker1.Value.Date;
    }

    private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
    {
      MonthCalendar2.SelectionStart = DateTimePicker2.Value.Date;
    }

    private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
      DateTimePicker1.Value = MonthCalendar1.SelectionStart.Date;
      DateChanged();
    }

    private void MonthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
    {
      DateTimePicker2.Value = MonthCalendar2.SelectionStart.Date;
      DateChanged();
    }

    private void DateChanged(bool force = false)
    {
      bool b1 = (DateTime)MonthCalendar1.Tag != MonthCalendar1.SelectionStart;
      bool b2 = (DateTime)MonthCalendar2.Tag != MonthCalendar2.SelectionStart;
      if ( b1 ) MonthCalendar1.Tag = MonthCalendar1.SelectionStart;
      if ( b2 ) MonthCalendar2.Tag = MonthCalendar2.SelectionStart;
      if ( !force && !b1 && !b2 ) return;
      var diff = Math.Abs((decimal)( MonthCalendar1.SelectionStart - MonthCalendar2.SelectionStart ).TotalDays);
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      try
      {
        if ( Stats == null )
        {
          Stats = new DatesDiffItem(this, MonthCalendar1.SelectionStart, MonthCalendar2.SelectionStart);
          datesDiffItemBindingSource.DataSource = Stats;
        }
        else
        {
          Stats.SetDates(this, MonthCalendar1.SelectionStart, MonthCalendar2.SelectionStart);
          datesDiffItemBindingSource.ResetBindings(false);
        }
      }
      finally
      {
        Cursor = cursor;
      }
    }

  }

}
