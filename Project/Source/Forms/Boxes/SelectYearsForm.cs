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
/// <edited> 2020-08 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class SelectYearsForm : Form
  {

    static public bool Run(bool canCancel, out int first, out int last)
    {
      using ( var form = new SelectYearsForm() )
      {
        first = 0;
        last = 0;
        if ( !canCancel ) form.ActionCancel.Enabled = false;
        if ( form.ShowDialog() == DialogResult.Cancel ) return false;
        first = (int)form.EditYearFirst.Value;
        last = (int)form.EditYearLast.Value;
        return true;
      }
    }

    private bool Mutex;

    private int CurrentYear;

    private SelectYearsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      YearsIntervalItem.InitializeMenu(MenuPredefinedYears,
                                       Program.Settings.GenerateIntervalMaximum,
                                       PredefinedYearsItem_Click);
    }

    private void SelectYearsRangeForm_Load(object sender, EventArgs e)
    {
      Mutex = true;
      int yearMin = AstronomyHelper.LunisolerCalendar.MinCalendarYear;
      int yearMax = AstronomyHelper.LunisolerCalendar.MaxCalendarYear;
      int min = Program.GenerateIntervalMinimum;
      int max = Program.Settings.GenerateIntervalMaximum;
      CurrentYear = DateTime.Today.AddYears(-1).Year;
      if ( CurrentYear < yearMin || CurrentYear + min - 1 > yearMax )
        throw new ArgumentOutOfRangeException(Translations.NotSupportedYear.GetLang(CurrentYear));
      EditYearFirst.Minimum = CurrentYear + min - max + 1;
      EditYearFirst.Maximum = CurrentYear;
      EditYearLast.Minimum = CurrentYear + min;
      EditYearLast.Maximum = CurrentYear + max - 1;
      if ( EditYearFirst.Minimum < yearMin + 1 ) EditYearFirst.Minimum = yearMin + 1;
      if ( EditYearLast.Maximum > yearMax - 1 ) EditYearLast.Maximum = yearMax - 1;
      Mutex = false;
      if ( MainForm.Instance.YearFirst != 0 && MainForm.Instance.YearLast != 0 )
      {
        EditYearFirst.Value = MainForm.Instance.YearFirst;
        EditYearLast.Value = MainForm.Instance.YearLast;
      }
      else
        ActionDefaultInterval.PerformClick();
    }

    private void SelectYearsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing ) return;
      if ( !ActionCancel.Enabled ) e.Cancel = true;
    }

    private void ActionPrefefinedInterval_Click(object sender, EventArgs e)
    {
      MenuPredefinedYears.Show(ActionPrefefinedInterval, new Point(0, ActionPrefefinedInterval.Height));
    }

    private void ActionDefaultInterval_Click(object sender, EventArgs e)
    {
      var interval = new YearsIntervalItem(Program.Settings.AutoGenerateYearsInternal);
      EditYearFirst.Value = CurrentYear - interval.YearsBefore;
      EditYearLast.Value = CurrentYear + interval.YearsAfter - 1;
    }

    private void PredefinedYearsItem_Click(object sender, EventArgs e)
    {
      var interval = (YearsIntervalItem)( sender as ToolStripMenuItem ).Tag;
      decimal first = CurrentYear - interval.YearsBefore;
      if ( first < EditYearFirst.Minimum ) first = EditYearFirst.Minimum;
      if ( first > EditYearFirst.Maximum ) first = EditYearFirst.Maximum;
      EditYearFirst.Value = first;
      decimal last = CurrentYear + interval.YearsAfter - 1;
      if ( last < EditYearLast.Minimum ) last = EditYearLast.Minimum;
      if ( last > EditYearLast.Maximum ) last = EditYearLast.Maximum;
      EditYearLast.Value = last;
    }

    private void EditYearFirst_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( EditYearLast.Value - EditYearFirst.Value >= Program.Settings.GenerateIntervalMaximum )
        EditYearLast.Value = EditYearFirst.Value + Program.Settings.GenerateIntervalMaximum - 1;
    }

    private void EditYearLast_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( EditYearLast.Value - EditYearFirst.Value >= Program.Settings.GenerateIntervalMaximum )
        EditYearFirst.Value = EditYearLast.Value - Program.Settings.GenerateIntervalMaximum + 1;
    }

    private void ActionOK_Click(object sender, EventArgs e)
    {
      var diff = EditYearLast.Value - EditYearFirst.Value + 1;
      if ( Program.Settings.BigCalendarWarningEnabled )
        for ( int index = Program.BigCalendarLevels.Length - 1; index >= 0; index-- )
          if ( diff > Program.BigCalendarLevels[index] )
          {
            string text = Translations.AskToGenerateBigCalendar[index].GetLang(Program.BigCalendarLevels[index], diff);
            if ( !DisplayManager.QueryYesNo(text) )
            {
              DialogResult = DialogResult.None;
              return;
            }
            break;
          }
      ActionCancel.Enabled = true;
    }

  }

}
