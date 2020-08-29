/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2020-08 </edited>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide win forms helper.
  /// </summary>
  static class FormsHelper
  {

    /// <summary>
    /// Apply localized resources.
    /// </summary>
    static public void Apply(this ComponentResourceManager resources, Control.ControlCollection controls)
    {
      try
      {
        foreach ( Control control in controls )
        {
          if ( control is Label )
            resources.ApplyResources(control, control.Name);
          Apply(resources, control.Controls);
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Center a form to screen.
    /// </summary>
    /// <param name="form">The form.</param>
    static public void CenterToScreen(this Form form)
    {
      SetLocation(form, ControlLocation.Center);
    }

    /// <summary>
    /// Set a form location.
    /// </summary>
    /// <param name="form">The form.</param>
    /// <param name="location">The location.</param>
    static public void SetLocation(this Form form, ControlLocation location)
    {
      if ( form == null ) return;
      Rectangle area = SystemInformation.WorkingArea;
      if ( location == ControlLocation.TopLeft )
        form.Location = new Point(area.Left, area.Top);
      else
      if ( location == ControlLocation.TopRight )
        form.Location = new Point(area.Left + area.Width - form.Width, area.Top);
      else
      if ( location == ControlLocation.BottomLeft )
        form.Location = new Point(area.Left, area.Top + area.Height - form.Height);
      else
      if ( location == ControlLocation.BottomRight )
        form.Location = new Point(area.Left + area.Width - form.Width, area.Top + area.Height - form.Height);
      else
      if ( location == ControlLocation.Center )
        form.Location = new Point(area.Left + area.Width / 2 - form.Width / 2,
                                  area.Top + area.Height / 2 - form.Height / 2);
      else
      if ( location == ControlLocation.Fixed )
        form.CenterToMainFormElseScreen();
    }

    /// <summary>
    /// Center a form beside the main form if visible and not minimized else center to screen.
    /// </summary>
    /// <param name="form">The form.</param>
    static public void CenterToMainFormElseScreen(this Form form)
    {
      if ( form == null ) return;
      Rectangle area = Globals.MainForm != null
                    && Globals.MainForm != form
                    && Globals.MainForm.Visible
                    && Globals.MainForm.WindowState != FormWindowState.Minimized
                     ? Globals.MainForm.Bounds
                     : SystemInformation.WorkingArea;
      form.Location = new Point(area.Left + area.Width / 2 - form.Width / 2,
                                area.Top + area.Height / 2 - form.Height / 2);
    }

    /// <summary>
    /// Duplicate menu content.
    /// </summary>
    static public void DuplicateTo(this ToolStripDropDownButton source, ToolStripMenuItem destination)
    {
      int count = 0;
      var items = new ToolStripItem[source.DropDownItems.Count];
      foreach ( ToolStripItem item in source.DropDownItems )
        if ( item is ToolStripMenuItem )
          items[count++] = ( (ToolStripMenuItem)item ).Clone();
        else
        if ( item is ToolStripSeparator )
          items[count++] = new ToolStripSeparator();
      destination.DropDownItems.Clear();
      destination.DropDownItems.AddRange(items);
    }

    /// <summary>
    /// Resize an image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The image resized.</returns>
    static public Bitmap Resize(this Image image, int width, int height)
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
