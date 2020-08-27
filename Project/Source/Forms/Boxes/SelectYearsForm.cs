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
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectYearsForm : Form
  {

    private bool Mutex;
    private int CurrentYear;

    public SelectYearsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      foreach ( int value in Program.PredefinedYearsIntervals )
        if ( value <= Program.Settings.GenerateIntervalMaximum )
        {
          var item = new ToolStripMenuItem();
          item.Text = Translations.PredefinedYearsInterval.GetLang(value);
          item.Tag = value.ToString();
          item.Click += PredefinedYearsItem_Click;
          MenuPredefinedYears.Items.Add(item);
        }
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
        throw new Exception("Current year is not supported");
      var year = MainForm.Instance.YearFirst == 0
               ? CurrentYear
               : MainForm.Instance.YearFirst;
      EditYearFirst.Minimum = CurrentYear + min - max + 1;
      EditYearFirst.Maximum = CurrentYear;
      EditYearLast.Minimum = CurrentYear + min;
      EditYearLast.Maximum = CurrentYear + max - 1;
      if ( EditYearFirst.Minimum < yearMin + 1 ) EditYearFirst.Minimum = yearMin + 1;
      if ( EditYearLast.Maximum > yearMax - 1 ) EditYearLast.Maximum = yearMax - 1;
      Mutex = false;
      EditYearFirst.Value = year;
      EditYearLast.Value = MainForm.Instance.YearLast == 0
                         ? year + Program.GenerateIntervalDefault - 1
                         : MainForm.Instance.YearLast;
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

    private void PredefinedYearsItem_Click(object sender, EventArgs e)
    {
      EditYearFirst.Value = CurrentYear;
      EditYearLast.Value = CurrentYear + int.Parse((string)( sender as ToolStripMenuItem ).Tag) - 1;
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

    private void ActionOk_Click(object sender, EventArgs e)
    {
      var diff = EditYearLast.Value - EditYearFirst.Value + 1;
      for ( int index = Program.BigCalendarLevels.Length - 1; index >= 0; index-- )
        if ( diff > Program.BigCalendarLevels[index] )
        {
          string text = Translations.AskToGenerateBigCalendar[index].GetLang(Program.BigCalendarLevels[index], diff);
          if ( !DisplayManager.QueryYesNo(text) )
            return;
          break;
        }
      DialogResult = DialogResult.OK;
      ActionCancel.Enabled = true;
    }

  }

}
