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
/// <edited> 2021-07 </edited>
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text;

namespace Ordisoftware.Core
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
    /// Get active form else last opened else main form.
    /// </summary>
    static public Form GetActiveForm()
    {
      return Form.ActiveForm ?? Application.OpenForms.All().LastOrDefault() ?? Globals.MainForm;
    }

    /// <summary>
    /// Get a list of open forms.
    /// </summary>
    static public void CloseAll(Func<Form, bool> keep = null)
    {
      var list = keep == null
                 ? Application.OpenForms.All(form => form.Visible).Reverse().ToList()
                 : Application.OpenForms.All(form => form.Visible && !keep(form)).Reverse().ToList();
      foreach ( Form form in list ) SystemManager.TryCatch(() => form.Close());
    }

    /// <summary>
    /// Get all apened forms.
    /// </summary>
    static public IEnumerable<Form> All(this FormCollection forms, Func<Form, bool> select = null)
    {
      if ( select == null )
        foreach ( Form form in forms )
          yield return form;
      else
        foreach ( Form form in forms )
          if ( select(form) )
            yield return form;
    }

    /// <summary>
    /// Get all controls of a control.
    /// </summary>
    static public IEnumerable<T> GetAllControls<T>(this Control control)
    {
      var controls = control.Controls.OfType<T>();
      return control.Controls.Cast<Control>()
                             .SelectMany(c => c.GetAllControls<T>())
                             .Concat(controls);
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
          throw new AdvancedNotImplementedException(location);
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

    /// <summary>
    /// Force bring to front.
    /// </summary>
    static public void ForceBringToFront(this Form form)
    {
      var temp = form.TopMost;
      form.TopMost = true;
      form.BringToFront();
      form.TopMost = temp;
    }

    /// <summary>
    /// Ensure drop down menu items are displayed on the same screen.
    /// https://stackoverflow.com/questions/26587843/prevent-toolstripmenuitems-from-jumping-to-second-screen
    /// </summary>
    static public void SetDropDownOpening(this ToolStrip toolstrip, EventHandler action = null)
    {
      if ( action == null ) action = MenuItemDropDownOpening;
      var items1 = toolstrip.Items.OfType<ToolStripDropDownButton>().ToList();
      var items2 = items1.SelectMany(item => item.DropDownItems.OfType<ToolStripMenuItem>()).ToList();
      items1.ForEach(item => { if ( item.HasDropDownItems ) item.DropDownOpening += action; });
      items2.ForEach(item => { if ( item.HasDropDownItems ) item.DropDownOpening += action; });
    }

    /// <summary>
    /// Ensure drop down menu items are displayed on the same screen.
    /// https://stackoverflow.com/questions/26587843/prevent-toolstripmenuitems-from-jumping-to-second-screen
    /// </summary>
    static public void MenuItemDropDownOpening(object sender, EventArgs e)
    {
      if ( !( sender is ToolStripMenuItem menuItem ) || !menuItem.HasDropDownItems ) return;
      Rectangle Bounds = menuItem.GetCurrentParent().Bounds;
      Screen CurrentScreen = Screen.FromPoint(Bounds.Location);
      int MaxWidth = 0;
      foreach ( var subitem in menuItem.DropDownItems.OfType<ToolStripMenuItem>() )
        MaxWidth = Math.Max(subitem.Width, MaxWidth);
      MaxWidth += 10;
      int FarRight = Bounds.Right + MaxWidth;
      int CurrentMonitorRight = CurrentScreen.Bounds.Right;
      if ( FarRight > CurrentMonitorRight )
        menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
      else
        menuItem.DropDownDirection = ToolStripDropDownDirection.Right;
    }

    /// <summary>
    /// Duplicate menu subitems.
    /// </summary>
    static public void DuplicateTo(this ToolStripDropDownButton source, ToolStripMenuItem destination, bool noshortcuts = true)
    {
      var items = new List<ToolStripItem>();
      foreach ( ToolStripItem item in source.DropDownItems )
        if ( !( item.Tag is int ) || (int)item.Tag != int.MinValue )
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

    /// <summary>
    /// Get an icon from an image.
    /// </summary>
    static public Icon GetIcon(this Image image)
    {
      return Icon.FromHandle(new Bitmap(image).GetHicon());
    }

    /// <summary>
    /// Get an icon from a ToolStripItem image.
    /// </summary>
    static public Icon GetIcon(this ToolStripItem item)
    {
      return Icon.FromHandle(new Bitmap(item.Image).GetHicon());
    }

    /// <summary>
    /// Get an icon from an icon by size.
    /// </summary>
    static public Icon GetBySize(this Icon icon, int width, int height)
    {
      return icon.GetBySize(new Size(width, height));
    }

    /// <summary>
    /// Get an icon from an icon by size.
    /// </summary>
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

    static public void SetBackColor(this DataGridView grid, Color color)
    {
      for ( int row = 0; row < grid.Rows.Count; row++ )
        for ( int col = 0; col < grid.Columns.Count; col++ )
          grid[col, row].Style.BackColor = color;
    }

    static public List<Point> GetGridPoints(this Control control, int margin = 15)
    {
      int widthDiv2 = control.Width / 2;
      int heightDiv2 = control.Height / 2;
      int widthDiv4 = widthDiv2 / 4;
      int heightDiv4 = heightDiv2 / 4;
      var points = new List<Point>
      {
        // Center
        new Point(control.Left + widthDiv2, control.Top + heightDiv2),
        // Corners
        new Point(control.Left + margin, control.Top + margin),
        new Point(control.Right - margin, control.Top + margin),
        new Point(control.Left + margin, control.Bottom - margin),
        new Point(control.Right - margin, control.Bottom - margin),
        // Borders
        new Point(control.Left + widthDiv4, control.Top + heightDiv4),
        new Point(control.Right - widthDiv4, control.Top + heightDiv4),
        new Point(control.Left + widthDiv4, control.Bottom - heightDiv4),
        new Point(control.Right - widthDiv4, control.Bottom - heightDiv4),
        // Inner
        new Point(control.Left + widthDiv2, control.Top + margin),
        new Point(control.Left + widthDiv2, control.Bottom - margin),
        new Point(control.Left + margin, control.Top + heightDiv2),
        new Point(control.Right - margin, control.Top + heightDiv2)
      };
      return points;
    }

    /// <summary>
    /// Indicate if a control is visible on the screen over others.
    /// https://stackoverflow.com/questions/1649959/how-to-check-if-window-is-really-visible-in-windows-forms
    /// </summary>
    static public bool IsVisibleOnTop(this Control control, int requiredPercent = 100, int margin = 15)
    {
      if ( !control.Visible ) return false;
      var controls = control.GetAllControls<Control>().Select(c => c.Handle).ToList();
      var points = control.GetGridPoints(margin);
      bool all = requiredPercent == 100;
      int found = 0;
      int required = points.Count;
      if ( !all ) required = required * requiredPercent / 100;
      foreach ( var point in points )
      {
        var handle = NativeMethods.WindowFromPoint(new NativeMethods.PointStruct(point.X, point.Y));
        if ( handle == control.Handle || controls.Contains(handle) )
        {
          if ( ++found == required ) return true;
        }
        else
        {
          if ( all ) return false;
        }
      }
      return false;
    }

    static public void SetTextJustified(this Control control, string text, int width)
    {
      control.Text = JustifyParagraph(text, width, control.Font);
    }

    /// <summary>
    /// Apply "justify" to the text of a control.
    /// </summary>
    // https://stackoverflow.com/questions/37155195/how-to-justify-text-in-a-label#47470191
    static public string JustifyParagraph(string text, int width, Font font)
    {
      var result = new StringBuilder();
      List<string> ParagraphsList = new List<string>();
      ParagraphsList.AddRange(text.Split(new[] { Globals.NL }, StringSplitOptions.None).ToList());
      int checkoverflow = 0;
      foreach ( string Paragraph in ParagraphsList )
      {
        var line = new StringBuilder();
        int ParagraphWidth = TextRenderer.MeasureText(Paragraph, font).Width;
        if ( ParagraphWidth > width )
        {
          string[] Words = Paragraph.Split(' ');
          line.Append(Words[0] + ' ');
          for ( int x = 1; x < Words.Length; x++ )
          {
            string tmpLine = line + ( Words[x] + (char)32 );
            if ( TextRenderer.MeasureText(tmpLine, font).Width > width )
            {
              // TODO improve this hack solving freezing when word has no space
              if ( checkoverflow++ > 50 )
              {
                DebugManager.Trace(LogTraceEvent.Error, $"Stack Overflow in {nameof(JustifyParagraph)}:{Globals.NL2}{text}");
                return text;
              }
              result.Append(Justify(line.ToString().TrimEnd()) + Globals.NL);
              line.Clear();
              --x;
            }
            else
              line.Append(Words[x] + ' ');
          }
          if ( line.Length > 0 ) result.Append(line + Globals.NL);
        }
        else
          result.Append(Paragraph + Globals.NL);
      }
      return result.ToString().TrimEnd(Globals.NL.ToCharArray());
      string Justify(string str)
      {
        char SpaceChar = (char)0x200A;
        List<string> WordsList = str.Split(' ').ToList();
        if ( WordsList.Capacity < 2 ) return str;
        int NumberOfWords = WordsList.Capacity - 1;
        int WordsWidth = TextRenderer.MeasureText(str.Replace(" ", string.Empty), font).Width;
        int SpaceCharWidth = TextRenderer.MeasureText(WordsList[0] + SpaceChar, font).Width
                           - TextRenderer.MeasureText(WordsList[0], font).Width;
        int AverageSpace = ( ( width - WordsWidth ) / NumberOfWords ) / SpaceCharWidth;
        float AdjustSpace = ( width - ( WordsWidth + ( AverageSpace * NumberOfWords * SpaceCharWidth ) ) );
        return ( (Func<string>)( () =>
        {
          var Spaces = new StringBuilder();
          var AdjustedWords = new StringBuilder();
          for ( int h = 0; h < AverageSpace; h++ )
            Spaces.Append(SpaceChar);
          foreach ( string Word in WordsList )
          {
            AdjustedWords.Append(Word + Spaces);
            if ( AdjustSpace > 0 )
            {
              AdjustedWords.Append(SpaceChar);
              AdjustSpace -= SpaceCharWidth;
            }
          }
          return AdjustedWords.ToString().TrimEnd();
        } ) )();
      }
    }

  }

  /// <summary>
  /// Custom ToolStrip renderer
  /// https://stackoverflow.com/questions/2097164/how-to-change-system-windows-forms-toolstripbutton-highlight-background-color-wh#2097341
  /// </summary>
  public class CheckedButtonsToolStripRenderer : ToolStripProfessionalRenderer
  {
    protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
    {
      if ( e.Item is ToolStripButton button && button.Checked )
      {
        var bounds = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
        e.Graphics.FillRectangle(SystemBrushes.ControlLight, bounds);
        e.Graphics.DrawRectangle(SystemPens.ControlDark, bounds);
      }
      else
        base.OnRenderButtonBackground(e);
    }
  }

}
