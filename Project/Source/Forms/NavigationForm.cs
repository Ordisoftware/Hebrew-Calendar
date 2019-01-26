/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-01 </edited>
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  public partial class NavigationForm : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static internal NavigationForm Instance { get; private set; }

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
          string strDate = SQLiteUtility.GetDate(value);
          var row = ( from day in MainForm.Instance.LunisolarCalendar.LunisolarDays
                      where day.Date == strDate
                      select day ).Single() as Data.LunisolarCalendar.LunisolarDaysRow;
          LabelDate.Text = value.ToLongDateString();
          string strMonth = Localizer.BabylonianHebrewMonthText[row.LunarMonth];
          LabelLunarMonthValue.Text = strMonth + " #" + row.LunarMonth.ToString();
          LabelLunarDayValue.Text = "Day #" + row.LunarDay.ToString();
          if ( value.DayOfWeek == (DayOfWeek)Program.Settings.ShabatDay )
            LabelLunarDayValue.Text += " (Shabat)";
          LabelSunriseValue.Text = row.Sunrise.ToString();
          LabelSunsetValue.Text = row.Sunset.ToString();
          LabelMoonriseValue.Text = row.Moonrise.ToString();
          LabelMoonsetValue.Text = row.Moonset.ToString();
          LabelEventSeasonValue.Text = Localizer.SeasonEventText.GetLang((SeasonChangeType)row.SeasonChange);
          if ( LabelEventSeasonValue.Text == "" ) LabelEventSeasonValue.Text = "-";
          LabelEventTorahValue.Text = Localizer.TorahEventText.GetLang((TorahEventType)row.TorahEvents);
          if ( LabelEventTorahValue.Text == "" ) LabelEventTorahValue.Text = "-";
          var rowNext = ( from day in MainForm.Instance.LunisolarCalendar.LunisolarDays
                          where SQLiteUtility.GetDate(day.Date) > value && day.TorahEvents > 0
                          select day ).FirstOrDefault() as Data.LunisolarCalendar.LunisolarDaysRow;
          if ( rowNext != null )
          {
            var date = SQLiteUtility.GetDate(rowNext.Date);
            LabelTorahNextValue.Text = Localizer.TorahEventText.GetLang((TorahEventType)rowNext.TorahEvents);
            LabelTorahNextDateValue.Text = date.ToLongDateString();
            LabelTorahNext.Tag = date;
          }
          else
          {
            LabelTorahNextValue.Text = "-";
            LabelTorahNextDateValue.Text = "";
            LabelTorahNext.Tag = null;
          }
          var image = MoonPhase.MoonPhaseImage.Draw(value.Year, value.Month, value.Day, 200, 200);
          PictureMoon.Image = ResizeImage(image, 100, 100);
          if ( (MoonriseType)row.MoonriseType == MoonriseType.AfterSet )
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
          MainForm.Instance.GoToDate(value);
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

    private NavigationForm()
    {
      InitializeComponent();
      Text = Core.DisplayManager.Title;
      PanelTop.BackColor = Program.Settings.NavigateTopColor;
      PanelMiddle.BackColor = Program.Settings.NavigateMiddleColor;
      PanelBottom.BackColor = Program.Settings.NavigateBottomColor;
      int left = SystemInformation.WorkingArea.Left;
      int top = SystemInformation.WorkingArea.Top;
      int width = SystemInformation.WorkingArea.Width;
      int height = SystemInformation.WorkingArea.Height;
      Location = new Point(left + width - Width, top + height - Height);
    }

    /// <summary>
    /// Process the command key.
    /// </summary>
    /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if ( keyData != Keys.Escape ) return base.ProcessCmdKey(ref msg, keyData);
      Hide();
      return true;
    }

    private void ShowDayForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void buttonSelectDay_Click(object sender, EventArgs e)
    {
      var form = new SelectDayForm();
      form.TopMost = true;
      if ( form.ShowDialog() == DialogResult.OK )
        Date = form.MonthCalendar.SelectionStart;
      else
        try
        {
          ActiveControl = LabelDate;
        }
        catch
        {
        }
    }

    private void buttonPreviousDay_Click(object sender, EventArgs e)
    {
      Date = _Date.AddDays(-1);
    }

    private void buttonNextDay_Click(object sender, EventArgs e)
    {
      Date = _Date.AddDays(1);
    }

    private void LabelTorahNextDateValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( LabelTorahNext.Tag == null ) return;
      Date = (DateTime)LabelTorahNext.Tag;
    }

    /// <summary>
    /// Resize an image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The image resized.</returns>
    private Bitmap ResizeImage(Image image, int width, int height)
    {
      var destRect = new Rectangle(0, 0, width, height);
      var destImage = new Bitmap(width, height);
      destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
      using ( var graphics = Graphics.FromImage(destImage) )
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        using ( var wrapMode = new ImageAttributes() )
        {
          wrapMode.SetWrapMode(WrapMode.TileFlipXY);
          graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        }
      }
      return destImage;
    }

  }

}
