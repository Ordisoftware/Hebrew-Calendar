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
/// <edited> 2021-04 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class NavigationForm : Form
  {

    private const string NoDataField = "-";

    static public NavigationForm Instance { get; private set; }

    static NavigationForm()
    {
      Instance = new NavigationForm();
    }

    private Data.DataSet.LunisolarDaysDataTable LunisolarDays = MainForm.Instance.DataSet.LunisolarDays;

    public DateTime Date
    {
      get => _Date;
      set
      {
        try
        {
          string strText = value.ToString();
          strText = strText.Remove(strText.Length - 3, 3);
          string strDate = SQLiteDate.ToString(value);
          var row = LunisolarDays.Single(day => day.Date == strDate);
          LabelDate.Text = value.ToLongDateString().Titleize();
          string strMonth = HebrewMonths.Transliterations[row.LunarMonth];
          LabelLunarMonthValue.Text = AppTranslations.NavigationMonth.GetLang(row.LunarMonth) + " " + strMonth.ToUpper();
          LabelLunarDayValue.Text = AppTranslations.NavigationDay.GetLang(row.LunarDay);
          if ( value.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
            LabelLunarDayValue.Text += " SHABAT";
          LabelSunriseValue.Text = row.Sunrise.ToString();
          LabelSunsetValue.Text = row.Sunset.ToString();
          LabelMoonriseValue.Text = row.Moonrise.ToString();
          LabelMoonsetValue.Text = row.Moonset.ToString();
          LabelMoonriseValue.Visible = !row.Moonrise.IsNullOrEmpty();
          LabelMoonrise.Visible = !row.Moonrise.IsNullOrEmpty();
          LabelMoonsetValue.Visible = !row.Moonset.IsNullOrEmpty();
          LabelMoonset.Visible = !row.Moonset.IsNullOrEmpty();
          LabelEventSeasonValue.Text = AppTranslations.SeasonChange.GetLang(row.SeasonChangeAsEnum);
          if ( LabelEventSeasonValue.Text == string.Empty ) LabelEventSeasonValue.Text = NoDataField;
          LabelEventTorahValue.Text = row.TorahEventText;
          if ( LabelEventTorahValue.Text == string.Empty )
            LabelEventTorahValue.Text = NoDataField;
          var rowNext = LunisolarDays.FirstOrDefault(day => day.DateAsDateTime > value && day.TorahEvents > 0);
          if ( rowNext != null )
          {
            var date = rowNext.DateAsDateTime;
            LabelTorahNextValue.Text = rowNext.TorahEventText;
            LabelTorahNextDateValue.Text = date.ToLongDateString().Titleize();
            LabelTorahNextDateValue.Tag = date;
          }
          else
          {
            LabelTorahNextValue.Text = NoDataField;
            LabelTorahNextDateValue.Text = string.Empty;
            LabelTorahNextDateValue.Tag = null;
          }
          var today = MainForm.Instance.DataSet.LunisolarDays.GetToday();
          LabelCurrentDayValue.Text = today != null ? today.DayAndMonthWithYearText : SysTranslations.NullSlot.GetLang();
          LabelCurrentDayValue.Tag = today?.DateAsDateTime;
          LabelParashahValue.Text = NoDataField;
          LabelParashahValue.Tag = null;
          var rowParashah = row.GetParashahReadingDay();
          bool isPessah = row.LunarMonth == TorahCelebrations.PessahMonth
                       && row.LunarDay >= TorahCelebrations.PessahStartDay
                       && row.LunarDay <= TorahCelebrations.PessahEndDay;
          bool isSoukot = row.LunarMonth == TorahCelebrations.YomsMonth
                       && row.LunarDay >= TorahCelebrations.SoukotStartDay
                       && (
                            ( Program.Settings.UseSimhatTorahOutside && row.LunarDay <= TorahCelebrations.SoukotEndDay )
                            || row.LunarDay < TorahCelebrations.SoukotEndDay
                          );
          LabelParashahValue.Enabled = rowParashah != null && !isPessah && !isSoukot;
          if ( LabelParashahValue.Enabled && rowParashah != null )
          {
            LabelParashahValue.Text = rowParashah.ParashahText;
            LabelParashahValue.Tag = ParashotTable.GetDefaultByID(rowParashah.ParashahID);
          }
          var image = MostafaKaisoun.MoonPhaseImage.Draw(value.Year, value.Month, value.Day, 200, 200);
          PictureMoon.Image = image.Resize(100, 100);
          if ( row.MoonriseOccuringAsEnum == MoonRiseOccuring.AfterSet )
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
          SystemManager.TryCatch(() => { ActiveControl = LabelDate; });
        }
      }
    }

    private DateTime _Date;

    private NavigationForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      Text = DisplayManager.Title;
      PanelTop.BackColor = Program.Settings.NavigateTopColor;
      PanelMiddle.BackColor = Program.Settings.NavigateMiddleColor;
      PanelBottom.BackColor = Program.Settings.NavigateBottomColor;
    }

    public void ShowPopup(bool bringToFront = false)
    {
      SetLocation();
      Show();
      if ( bringToFront )
        BringToFront();
    }

    private void SetLocation()
    {
      var anchor = DisplayManager.GetTaskbarAnchorStyle();
      switch ( anchor )
      {
        case AnchorStyles.Top:
          this.SetLocation(ControlLocation.TopRight);
          break;
        case AnchorStyles.Left:
          this.SetLocation(ControlLocation.BottomLeft);
          break;
        default:
          this.SetLocation(ControlLocation.BottomRight);
          break;
      }
    }

    public void Relocalize()
    {
      Date = _Date;
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
      MainForm.Instance.TimerBallon.Stop();
      e.Cancel = true;
      Hide();
    }

    private void ActionSelectDay_Click(object sender, EventArgs e)
    {
      var date = DateTime.Today;
      if ( SelectDayForm.Run(null, ref date, true, true) )
        MainForm.Instance.GoToDate(date);
      else
        SystemManager.TryCatch(() => { ActiveControl = LabelDate; });
    }

    private void ActionPreviousDay_Click(object sender, EventArgs e)
    {
      MainForm.Instance.GoToDate(_Date.AddDays(-1));
    }

    private void ActionNextDay_Click(object sender, EventArgs e)
    {
      MainForm.Instance.GoToDate(_Date.AddDays(1));
    }

    private void LabelDay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( sender is LinkLabel label && label.Tag != null )
        MainForm.Instance.GoToDate((DateTime)label.Tag);
    }

    private void LabelParashahValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( LabelParashahValue.Tag != null )
        ParashotForm.Run((Parashah)LabelParashahValue.Tag);
    }

  }

}
