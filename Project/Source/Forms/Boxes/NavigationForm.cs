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
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class NavigationForm : Form
  {

    static public NavigationForm Instance { get; internal set; }

    static NavigationForm()
    {
      Instance = new NavigationForm();
    }

    public DateTime Date
    {
      get { return _Date; }
      set
      {
        try
        {
          string strText = value.ToString();
          strText = strText.Remove(strText.Length - 3, 3);
          string strDate = SQLiteDate.ToString(value);
          var row = ( from day in MainForm.Instance.DataSet.LunisolarDays
                      where day.Date == strDate
                      select day ).Single();
          LabelDate.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLongDateString());
          string strMonth = Program.MoonMonthsNames[row.LunarMonth];
          LabelLunarMonthValue.Text = strMonth + " #" + row.LunarMonth.ToString();
          LabelLunarDayValue.Text = Translations.NavigationDay.GetLang() + row.LunarDay.ToString();
          if ( value.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
            LabelLunarDayValue.Text += " (Shabat)";
          LabelSunriseValue.Text = row.Sunrise.ToString();
          LabelSunsetValue.Text = row.Sunset.ToString();
          LabelMoonriseValue.Text = row.Moonrise.ToString();
          LabelMoonsetValue.Text = row.Moonset.ToString();
          LabelEventSeasonValue.Text = Translations.SeasonEvent.GetLang((SeasonChange)row.SeasonChange);
          if ( LabelEventSeasonValue.Text == "" ) LabelEventSeasonValue.Text = "-";
          LabelEventTorahValue.Text = Translations.TorahEvent.GetLang((TorahEvent)row.TorahEvents);
          if ( LabelEventTorahValue.Text == "" ) LabelEventTorahValue.Text = "-";
          var rowNext = ( from day in MainForm.Instance.DataSet.LunisolarDays
                          where SQLiteDate.ToDateTime(day.Date) > value && day.TorahEvents > 0
                          select day ).FirstOrDefault();
          if ( rowNext != null )
          {
            var date = SQLiteDate.ToDateTime(rowNext.Date);
            LabelTorahNextValue.Text = Translations.TorahEvent.GetLang((TorahEvent)rowNext.TorahEvents);
            LabelTorahNextDateValue.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(date.ToLongDateString());
            LabelTorahNext.Tag = date;
          }
          else
          {
            LabelTorahNextValue.Text = "-";
            LabelTorahNextDateValue.Text = "";
            LabelTorahNext.Tag = null;
          }
          var image = MostafaKaisoun.MoonPhaseImage.Draw(value.Year, value.Month, value.Day, 200, 200);
          PictureMoon.Image = image.Resize(100, 100);
          if ( (MoonRise)row.MoonriseType == MoonRise.AfterSet )
          {
            LabelMoonrise.Top = 125;
            LabelMoonriseValue.Top = 125;
            LabelMoonset.Top = 105;
            LabelMoonsetValue.Top = 105;
          }
          else
          {
            LabelMoonrise.Top = 105;
            LabelMoonriseValue.Top = 105;
            LabelMoonset.Top = 125;
            LabelMoonsetValue.Top = 125;
          }
          _Date = value;
        }
        catch
        {
        }
        finally
        {
          try
          {
            ActiveControl = LabelDate;
          }
          catch
          {
          }
        }
      }
    }

    private DateTime _Date;

    internal NavigationForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      Text = HebrewCommon.DisplayManager.Title;
      PanelTop.BackColor = Program.Settings.NavigateTopColor;
      PanelMiddle.BackColor = Program.Settings.NavigateMiddleColor;
      PanelBottom.BackColor = Program.Settings.NavigateBottomColor;
      this.SetLocation(ControlLocation.BottomRight);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch ( keyData )
      {
        case Keys.Escape:
          Hide();
          return true;
        case Keys.Left:
          ActionPreviousDay.PerformClick();
          return true;
        case Keys.Right:
          ActionNextDay.PerformClick();
          return true;
        case Keys.Up:
          ActionSelectDay.PerformClick();
          return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ShowDayForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void ActionSelectDay_Click(object sender, EventArgs e)
    {
      var form = new SelectDayForm();
      form.TopMost = true;
      if ( form.ShowDialog() == DialogResult.OK )
        MainForm.Instance.GoToDate(form.MonthCalendar.SelectionStart);
      else
        try
        {
          ActiveControl = LabelDate;
        }
        catch
        {
        }
    }

    private void ActionPreviousDay_Click(object sender, EventArgs e)
    {
      MainForm.Instance.GoToDate(_Date.AddDays(-1));
    }

    private void ActionNextDay_Click(object sender, EventArgs e)
    {
      MainForm.Instance.GoToDate(_Date.AddDays(1));
    }

    private void LabelTorahNextDateValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( LabelTorahNext.Tag == null ) return;
      MainForm.Instance.GoToDate((DateTime)LabelTorahNext.Tag);
    }

  }

}
