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
/// <edited> 2020-04 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectYearsForm : Form
  {

    public const int GenerateIntervalPeriod = 120;
    public const int GenerateIntervalDefault = 5;
    public const int GenerateIntervalMin = 2;
    public const int GenerateIntervalMax1 = 10;
    public const int GenerateIntervalMax2 = 20;
    public const int GenerateIntervalMax3 = 40;
    public const int GenerateIntervalMax4 = 80;

    private bool Mutex;
    private int Year;

    public SelectYearsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void SelectYearsRangeForm_Load(object sender, EventArgs e)
    {
      Mutex = true;
      Year = DateTime.Today.AddYears(-1).Year;
      EditYearFirst.Minimum = Year - GenerateIntervalPeriod;
      EditYearFirst.Maximum = Year + GenerateIntervalPeriod;
      EditYearLast.Minimum = Year - GenerateIntervalPeriod;
      EditYearLast.Maximum = Year + GenerateIntervalPeriod;
      EditYearFirst.Value = Year;
      EditYearLast.Value = Year + GenerateIntervalDefault - 1;
      Mutex = false;
    }

    private void EditYearFirst_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( EditYearFirst.Value < AstronomyHelper.LunisolerCalendar.MinSupportedDateTime.Year + 1 )
        EditYearFirst.Value = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime.Year + 1;
      if ( EditYearFirst.Value > Year )
        EditYearFirst.Value = Year;
      if ( EditYearLast.Value - EditYearFirst.Value > GenerateIntervalPeriod )
        EditYearLast.Value = EditYearFirst.Value + GenerateIntervalPeriod;
    }

    private void EditYearLast_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( EditYearLast.Value > AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime.Year - 1 )
        EditYearLast.Value = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime.Year - 1;
      if ( EditYearLast.Value < Year + GenerateIntervalMin )
        EditYearLast.Value = Year + GenerateIntervalMin;
      if ( EditYearLast.Value - EditYearFirst.Value > GenerateIntervalPeriod )
        EditYearFirst.Value = EditYearLast.Value - GenerateIntervalPeriod;
    }

    private void ActionOk_Click(object sender, EventArgs e)
    {
      var diff = EditYearLast.Value - EditYearFirst.Value;
      if ( diff >= GenerateIntervalMax4 )
      {
        if ( !DisplayManager.QueryYesNo(Translations.AskToGenerateBigCalendar4.GetLang(GenerateIntervalMax4, diff)) )
          return;
      }
      else
      if ( diff >= GenerateIntervalMax3 )
      {
        if ( !DisplayManager.QueryYesNo(Translations.AskToGenerateBigCalendar3.GetLang(GenerateIntervalMax3, diff)) )
          return;
      }
      else
      if ( diff >= GenerateIntervalMax2 )
      {
        if ( !DisplayManager.QueryYesNo(Translations.AskToGenerateBigCalendar2.GetLang(GenerateIntervalMax2, diff)) )
          return;
      }
      else
      if ( diff >= GenerateIntervalMax1 )
      {
        if ( !DisplayManager.QueryYesNo(Translations.AskToGenerateBigCalendar1.GetLang(GenerateIntervalMax1, diff)) )
          return;
      }
      DialogResult = DialogResult.OK;
      ActionCancel.Enabled = true;
    }

    private void SelectYearsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( e.CloseReason != CloseReason.UserClosing ) return;
      if ( !ActionCancel.Enabled ) e.Cancel = true;
    }
  }

}
