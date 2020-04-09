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
/// <edited> 2019-10 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectYearsForm : Form
  {

    public const int GenerateIntervalPeriod = 120;
    public const int GenerateIntervalDefault = 5;
    public const int GenerateIntervalMin = 2;
    public const int GenerateIntervalMax = 10;

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
      if ( EditYearFirst.Value < AstronomyUtility.LunisolerCalendar.MinSupportedDateTime.Year + 1 )
        EditYearFirst.Value = AstronomyUtility.LunisolerCalendar.MinSupportedDateTime.Year + 1;
      if ( EditYearFirst.Value > Year )
        EditYearFirst.Value = Year;
      if ( EditYearLast.Value - EditYearFirst.Value > GenerateIntervalPeriod )
        EditYearLast.Value = EditYearFirst.Value + GenerateIntervalPeriod;
    }

    private void EditYearLast_ValueChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      if ( EditYearLast.Value > AstronomyUtility.LunisolerCalendar.MaxSupportedDateTime.Year - 1 )
        EditYearLast.Value = AstronomyUtility.LunisolerCalendar.MaxSupportedDateTime.Year - 1;
      if ( EditYearLast.Value < Year + GenerateIntervalMin )
        EditYearLast.Value = Year + GenerateIntervalMin;
      if ( EditYearLast.Value - EditYearFirst.Value > GenerateIntervalPeriod )
        EditYearFirst.Value = EditYearLast.Value - GenerateIntervalPeriod;
    }

    private void ActionOk_Click(object sender, EventArgs e)
    {
      if ( EditYearLast.Value - EditYearFirst.Value > GenerateIntervalMax )
        if ( !DisplayManager.QueryYesNo(Translations.AskToGenerateBigCalendar.GetLang(GenerateIntervalMax)) )
          return;
      DialogResult = DialogResult.OK;
    }

  }

}
