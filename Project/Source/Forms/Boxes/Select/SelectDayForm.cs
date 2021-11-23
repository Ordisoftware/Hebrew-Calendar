/// <license>
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
/// <edited> 2020-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class SelectDayForm : Form
{

  static public bool Run(string title, ref DateTime date, bool topmost = false, bool isOnlyAvailable = false, bool isGotoRealtime = false)
  {
    using var form = new SelectDayForm();
    if ( isOnlyAvailable )
    {
      form.MonthCalendar.MinDate = MainForm.Instance.DateFirst;
      form.MonthCalendar.MaxDate = MainForm.Instance.DateLast;
    }
    else
    {
      form.MonthCalendar.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
      form.MonthCalendar.MaxDate = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime;
    }
    if ( date < form.MonthCalendar.MinDate ) date = form.MonthCalendar.MinDate;
    if ( date > form.MonthCalendar.MaxDate ) date = form.MonthCalendar.MaxDate;
    form.MonthCalendar.SelectionStart = date;
    form.MonthCalendar.FirstDayOfWeek = (Day)Program.Settings.ShabatDay;
    form.CurrentDay = MainForm.Instance.CurrentDay;
    if ( !title.IsNullOrEmpty() )
      form.Text = title;
    else
      form.MonthCalendar.SelectionStart = form.CurrentDay.Date;
    form.IsGotoRealtime = isGotoRealtime;
    form.TopMost = topmost;
    bool result = form.ShowDialog() == DialogResult.OK;
    date = result ? form.MonthCalendar.SelectionStart : DateTime.MinValue;
    return result;
  }

  private bool IsGotoRealtime;

  private LunisolarDay CurrentDay;

  private SelectDayForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
  }

  private void SelectDayForm_Shown(object sender, EventArgs e)
  {
    MonthCalendar_DateChanged(null, null);
  }

  private void ActionCancel_Click(object sender, EventArgs e)
  {
    if ( IsGotoRealtime && CurrentDay != null )
      MainForm.Instance.GoToDate(CurrentDay.Date);
  }

  private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
  {
    if ( !IsGotoRealtime ) return;
    var date = MonthCalendar.SelectionStart;
    if ( MonthCalendar.SelectionStart < MainForm.Instance.DateFirst )
      date = MainForm.Instance.DateFirst;
    else
    if ( MonthCalendar.SelectionStart > MainForm.Instance.DateLast )
      date = MainForm.Instance.DateLast;
    MainForm.Instance.GoToDate(date);
  }

}
