/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2021-02 </edited>
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide win forms helper.
  /// </summary>
  static class FormsHelper
  {

    static public IEnumerable<Form> ToList(this FormCollection forms)
    {
      foreach ( Form form in forms )
        yield return form;
    }

    static public IEnumerable<T> GetAllControls<T>(this Control control)
    {
      var controls = control.Controls.OfType<T>();
      return control.Controls.Cast<Control>()
                             .SelectMany(c => c.GetAllControls<T>())
                             .Concat(controls);
    }

    /// <summary>
    /// Apply localized resources.
    /// </summary>
    static public void Apply(this ComponentResourceManager resources, Control.ControlCollection controls)
    {
      SystemManager.TryCatchManage(() =>
      {
        foreach ( Control control in controls )
        {
          if ( control is Label )
            resources.ApplyResources(control, control.Name);
          Apply(resources, control.Controls);
        }
      });
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
      var area = SystemInformation.WorkingArea;
      switch ( location )
      {
        case ControlLocation.TopLeft:
          form.Location = new Point(area.Left, area.Top);
          break;
        case ControlLocation.TopRight:
          form.Location = new Point(area.Left + area.Width - form.Width, area.Top);
          break;
        case ControlLocation.BottomLeft:
          form.Location = new Point(area.Left, area.Top + area.Height - form.Height);
          break;
        case ControlLocation.BottomRight:
          form.Location = new Point(area.Left + area.Width - form.Width, area.Top + area.Height - form.Height);
          break;
        case ControlLocation.Center:
          form.Center(area);
          break;
        case ControlLocation.Fixed:
          form.CenterToMainFormElseScreen();
          break;
        case ControlLocation.Loose:
          break;
        default:
          throw new NotImplementedExceptionEx(location);
      }
    }

    /// <summary>
    /// Center a form beside the main form if visible and not minimized else center to screen.
    /// </summary>
    /// <param name="form">The form.</param>
    static public void CenterToMainFormElseScreen(this Form form)
    {
      if ( form == null ) return;
      var area = Globals.MainForm != null
              && Globals.MainForm != form
              && Globals.MainForm.Visible
              && Globals.MainForm.WindowState != FormWindowState.Minimized
                 ? Globals.MainForm.Bounds
                 : SystemInformation.WorkingArea;
      form.Center(area);
    }

    /// <summary>
    /// Center a form beside a form or the main form if visible and not minimized else center to screen.
    /// </summary>
    /// <param name="form">The form.</param>
    /// <param name="source">The source form.</param>
    static public void CenterToFormElseMainFormElseScreen(this Form form, Form source)
    {
      if ( form == null ) return;
      if ( source != null
        && source.Visible
        && source.WindowState != FormWindowState.Minimized )
        form.Center(source.Bounds);
      else
        form.CenterToMainFormElseScreen();
    }

    /// <summary>
    /// Center a form in an area.
    /// </summary>
    /// <param name="form">The form.</param>
    /// <param name="area">The area.</param>
    static public void Center(this Form form, Rectangle area)
    {
      if ( form == null ) return;
      form.Location = new Point(area.Left + area.Width / 2 - form.Width / 2,
                                area.Top + area.Height / 2 - form.Height / 2);
    }

    /// <summary>
    /// Check if location is in the screen else center to main form else to screen.
    /// </summary>
    /// <param name="form">The form.</param>
    static public void CheckLocationOrCenterToMainFormElseScreen(this Form form)
    {
      if ( form == null ) return;
      if ( form.Location.X < 0 || form.Location.Y < 0
        || form.Left > SystemInformation.WorkingArea.Width - form.Width / 2
        || form.Top > SystemInformation.WorkingArea.Height - form.Height / 2 )
        form.CenterToMainFormElseScreen();
    }

    /// <summary>
    /// Restore a minimized form.
    /// </summary>
    /// <param name="form">The form.</param>
    static public void Restore(this Form form)
    {
      if ( form.Visible && form.WindowState == FormWindowState.Minimized )
        NativeMethods.ShowWindow(form.Handle, NativeMethods.SW_RESTORE);
    }

    delegate void PopupMethod(Form form, Form sender, bool dialog);

    /// <summary>
    /// Popup a form not visible, visible in background or minimized to be visible on top.
    /// </summary>
    /// <param name="form">The form.</param>
    /// <param name="sender">The form to center on.</param>
    /// <param name="dialog">True if show dialog.</param>
    static public void Popup(this Form form, Form sender = null, bool dialog = false)
    {
      if ( form == null || form.IsDisposed ) return;
      if ( form.InvokeRequired )
      {
        var method = new PopupMethod(Popup);
        form.Invoke(method, new object[] { form, sender, dialog });
        return;
      }
      if ( form.Visible )
        if ( !dialog )
        {
          form.Restore();
          if ( sender != null ) form.CenterToFormElseMainFormElseScreen(sender);
          form.ForceBringToFront();
        }
        else
        {
          if ( sender != null ) form.CenterToFormElseMainFormElseScreen(sender);
          if ( !form.Modal )
          {
            form.Visible = false;
            form.ShowDialog();
          }
          else
            form.ForceBringToFront();
        }
      else
      if ( dialog )
        form.ShowDialog();
      else
      {
        if ( sender != null ) form.CenterToFormElseMainFormElseScreen(sender);
        form.Show();
      }
      form.Activate();
    }

    static public void ForceBringToFront(this Form form)
    {
      var temp = form.TopMost;
      form.TopMost = true;
      form.BringToFront();
      form.TopMost = temp;
    }

    /// <summary>
    /// Duplicate menu subitems.
    /// </summary>
    static public void DuplicateTo(this ToolStripDropDownButton source, ToolStripMenuItem destination, bool noshortcuts = true)
    {
      var items = new List<ToolStripItem>();
      foreach ( ToolStripItem item in source.DropDownItems )
        if ( item.Tag == null || !( item.Tag is int ) || (int)item.Tag != int.MinValue )
          if ( item is ToolStripMenuItem menuItem )
          {
            var newitem = menuItem.Clone();
            if ( noshortcuts ) newitem.ShortcutKeys = Keys.None;
            items.Add(newitem);
          }
          else
          if ( item is ToolStripSeparator )
            items.Add(new ToolStripSeparator());
      destination.DropDownItems.Clear();
      destination.DropDownItems.AddRange(items.ToArray());
    }

    static public Icon GetIcon(this Image image)
    {
      return Icon.FromHandle(new Bitmap(image).GetHicon());
    }

    static public Icon GetIcon(this ToolStripItem item)
    {
      return Icon.FromHandle(new Bitmap(item.Image).GetHicon());
    }

    static public Icon GetBySize(this Icon icon, int width, int height)
    {
      return icon.GetBySize(new Size(width, height));
    }

    static public Icon GetBySize(this Icon icon, Size size)
    {
      using ( var stream = new MemoryStream() )
      {
        icon.Save(stream);
        stream.Position = 0;
        return new Icon(stream, size);
      }
    }

    /// <summary>
    /// Get a bitmap of a control.
    /// </summary>
    /// <param name="control">The control</param>
    /// <returns>The bitmap.</returns>
    static public Bitmap GetBitmap(this Control control)
    {
      if ( control == null ) return null;
      var bitmap = new Bitmap(control.Width, control.Height);
      control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));
      return bitmap;
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

    /// <summary>
    /// Apply "justify" to the text of a control.
    /// </summary>
    static public void SetTextJustified(this Control control, string text, int width)
    {
      control.Text = JustifyParagraph(text, width, control.Font);
    }
    // https://stackoverflow.com/questions/37155195/how-to-justify-text-in-a-label#47470191
    static public string JustifyParagraph(string text, int width, Font font)
    {
      string result = string.Empty;
      List<string> ParagraphsList = new List<string>();
      ParagraphsList.AddRange(text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList());
      int checkoverflow = 0;
      foreach ( string Paragraph in ParagraphsList )
      {
        string line = string.Empty;
        int ParagraphWidth = TextRenderer.MeasureText(Paragraph, font).Width;
        if ( ParagraphWidth > width )
        {
          string[] Words = Paragraph.Split(' ');
          line = Words[0] + (char)32;
          for ( int x = 1; x < Words.Length; x++ )
          {
            string tmpLine = line + ( Words[x] + (char)32 );
            if ( TextRenderer.MeasureText(tmpLine, font).Width > width )
            {
              // TODO hack to solve freezing bug when word has no space 
              if ( checkoverflow++ > 50 )
              {
                DebugManager.Trace(LogTraceEvent.Error, $"Stack Overflow in {nameof(JustifyParagraph)}:{Globals.NL2}{text}");
                return text;
              }
              result += Justify(line.TrimEnd()) + "\r\n";
              line = string.Empty;
              --x;
            }
            else
              line += ( Words[x] + (char)32 );
          }
          if ( line.Length > 0 ) result += line + "\r\n";
        }
        else
          result += Paragraph + "\r\n";
      }
      return result.TrimEnd(new[] { '\r', '\n' });
      string Justify(string str)
      {
        char SpaceChar = (char)0x200A;
        List<string> WordsList = str.Split((char)32).ToList();
        if ( WordsList.Capacity < 2 ) return str;
        int NumberOfWords = WordsList.Capacity - 1;
        int WordsWidth = TextRenderer.MeasureText(str.Replace(" ", string.Empty), font).Width;
        int SpaceCharWidth = TextRenderer.MeasureText(WordsList[0] + SpaceChar, font).Width
                           - TextRenderer.MeasureText(WordsList[0], font).Width;
        int AverageSpace = ( ( width - WordsWidth ) / NumberOfWords ) / SpaceCharWidth;
        float AdjustSpace = ( width - ( WordsWidth + ( AverageSpace * NumberOfWords * SpaceCharWidth ) ) );
        return ( (Func<string>)( () => {
          string Spaces = string.Empty;
          string AdjustedWords = string.Empty;
          for ( int h = 0; h < AverageSpace; h++ )
            Spaces += SpaceChar;
          foreach ( string Word in WordsList )
          {
            AdjustedWords += Word + Spaces;
            if ( AdjustSpace > 0 )
            {
              AdjustedWords += SpaceChar;
              AdjustSpace -= SpaceCharWidth;
            }
          }
          return AdjustedWords.TrimEnd();
        } ) )();
      }
    }

  }

}
