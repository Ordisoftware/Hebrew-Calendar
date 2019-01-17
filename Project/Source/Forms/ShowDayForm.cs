/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
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

  public partial class ShowDayForm : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static internal ShowDayForm Instance { get; private set; }

    static ShowDayForm()
    {
      Instance = new ShowDayForm();
    }

    public DateTime Date
    {
      get { return _Date; }
      set
      {
        string strText = value.ToString();
        strText = strText.Remove(strText.Length - 3, 3);
        string strDate = SQLiteUtility.GetDate(value.Year, value.Month, value.Day);
        var item = ( from day in MainForm.Instance.lunisolarCalendar.LunisolarDays
                     where day.Date == strDate
                     select day ).Single() as Data.LunisolarCalendar.LunisolarDaysRow;
        labelDate.Text = value.ToLongDateString();
        string strMonth = AstronomyUtility.BabylonianHebrewMonthNames[item.LunarMonth];
        labelLunarMonthValue.Text = strMonth + " #" + item.LunarMonth.ToString();
        labelLunarDayValue.Text = "Day #" + item.LunarDay.ToString();
        labelSunriseValue.Text = item.Sunrise.ToString();
        labelSunsetValue.Text = item.Sunset.ToString();
        labelMoonriseValue.Text = item.Moonrise.ToString();
        labelMoonsetValue.Text = item.Moonset.ToString();
        labelEventSeasonValue.Text = TorahCelebrations.SeasonEventNames.GetLang((SeasonChangeType)item.SeasonChange);
        if ( labelEventSeasonValue.Text == "" ) labelEventSeasonValue.Text = "-";
        labelEventTorahValue.Text = TorahCelebrations.TorahEventNames.GetLang((TorahEventType)item.TorahEvents);
        if ( labelEventTorahValue.Text == "" ) labelEventTorahValue.Text = "-";
        var image = MoonPhase.MoonPhaseImage.Draw(value.Year, value.Month, value.Day, 200, 200);
        pictureMoon.Image = ResizeImage(image, 100, 100);
        if ( (MoonriseType)item.MoonriseType == MoonriseType.AfterSet )
        {
          labelMoonrise.Top = 125;
          labelMoonriseValue.Top = 125;
          labelMoonset.Top = 105;
          labelMoonsetValue.Top = 105;
        }
        else
        {
          labelMoonrise.Top = 105;
          labelMoonriseValue.Top = 105;
          labelMoonset.Top = 125;
          labelMoonsetValue.Top = 125;
        }
        _Date = value;
        try
        {
          ActiveControl = labelDate;
        }
        catch
        {
        }
      }
    }

    private DateTime _Date;

    public ShowDayForm()
    {
      InitializeComponent();
      Text = Core.DisplayManager.Title;
      int left = SystemInformation.WorkingArea.Left;
      int top = SystemInformation.WorkingArea.Top;
      int width = SystemInformation.WorkingArea.Width;
      int height = SystemInformation.WorkingArea.Height;
      Location = new Point(left + width - Width, top + height - Height);
    }

    private void ShowDayForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void buttonSelectDay_Click(object sender, EventArgs e)
    {
      try
      {
        DateTime date;
        var form = new SelectDayForm();
        form.TopMost = true;
        if ( form.ShowDialog() != DialogResult.OK ) return;
        Date = form.monthCalendar.SelectionStart;
      }
      catch
      {
      }
    }

    private void buttonPreviousDay_Click(object sender, EventArgs e)
    {
      try
      {
        Date = _Date.AddDays(-1);
      }
      catch
      {
      }
    }

    private void buttonNextDay_Click(object sender, EventArgs e)
    {
      try
      {
        Date = _Date.AddDays(1);
      }
      catch
      {
      }
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
