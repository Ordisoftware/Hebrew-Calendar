﻿/// <license>
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
/// <edited> 2021-10 </edited>
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provides win forms helper.
  /// </summary>
  static class FormsHelper
  {

    /// <summary>
    /// Applies localized resources.
    /// </summary>
    static public void ApplyResources(this ComponentResourceManager resources, Control.ControlCollection controls)
    {
      foreach ( Control control in controls )
        SystemManager.TryCatch(() =>
        {
          if ( control is Label )
            resources.ApplyResources(control, control.Name);
          resources.ApplyResources(control.Controls);
        });
    }

    /// <summary>
    /// Gets active form else last opened else main form.
    /// </summary>
    static public Form GetActiveForm()
    {
      return Form.ActiveForm ?? Application.OpenForms.GetAll().LastOrDefault() ?? Globals.MainForm;
    }

    /// <summary>
    /// Gets a list of open forms.
    /// </summary>
    static public void CloseAll(Func<Form, bool> keep = null)
    {
      var list = keep == null
                 ? Application.OpenForms.GetAll(form => form.Visible).Reverse().ToList()
                 : Application.OpenForms.GetAll(form => form.Visible && !keep(form)).Reverse().ToList();
      foreach ( Form form in list ) SystemManager.TryCatch(() => form.Close());
    }

    /// <summary>
    /// Gets all opened forms.
    /// </summary>
    static public IEnumerable<Form> GetAll(this FormCollection forms, Func<Form, bool> select = null)
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
    /// Gets all controls of a control.
    /// </summary>
    static public IEnumerable<T> GetAll<T>(this Control control)
    {
      var controls = control.Controls.OfType<T>();
      return control.Controls.Cast<Control>().SelectMany(c => c.GetAll<T>()).Concat(controls);
    }

    /// <summary>
    /// Gets all components of a form.
    /// </summary>
    static public IEnumerable<Component> GetComponents(this Form form)
    {
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
      const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
      return from field in form.GetType().GetFields(flags)
             where typeof(Component).IsAssignableFrom(field.FieldType)
             let component = (Component)field.GetValue(form)
             where component != null
             select component;
    }

    /// <summary>
    /// Gets a IEnumerable from a ToolStripItemCollection.
    /// </summary>
    static public IEnumerable<ToolStripItem> ToEnumerable(this ToolStripItemCollection collection, Func<ToolStripItem, bool> predicate = null)
    {
      var result = collection.Cast<ToolStripItem>();
      if ( predicate != null ) result = result.Where(predicate);
      return result;
    }

    /// <summary>
    /// Sets a form location.
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
      if ( source?.Visible == true && source.WindowState != FormWindowState.Minimized )
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
    /// Checks if location is in the screen else center to main form else to screen.
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
      if ( form?.IsDisposed != false ) return;
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
    /// </summary>
    static public void InitDropDowns(this Form form)
    {
      var list = form.GetComponents().ToList();
      foreach ( ToolStrip instance in list.OfType<ToolStrip>() )
        instance.SetDropDownOpening();
      foreach ( ContextMenuStrip instance in list.OfType<ContextMenuStrip>() )
        instance.SetDropDownOpening();
    }

    /// <summary>
    /// Duplicate menu subitems.
    /// </summary>
    static public void DuplicateTo(this ToolStripDropDownItem source, ToolStripMenuItem destination, bool noshortcuts = true)
    {
      var items = new List<ToolStripItem>();
      foreach ( ToolStripItem item in source.DropDownItems )
        if ( item.Tag is not int || (int)item.Tag != int.MinValue )
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
    /// Duplicate menu subitems.
    /// </summary>
    static public void DuplicateTo(this ContextMenuStrip source, ToolStripMenuItem destination, bool noshortcuts = true)
    {
      var items = new List<ToolStripItem>();
      foreach ( ToolStripItem item in source.Items )
        if ( item.Tag is not int || (int)item.Tag != int.MinValue )
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
    /// Gets an icon from an image.
    /// </summary>
    static public Icon GetIcon(this Image image)
    {
      return Icon.FromHandle(new Bitmap(image).GetHicon());
    }

    /// <summary>
    /// Gets an icon from a ToolStripItem image.
    /// </summary>
    static public Icon GetIcon(this ToolStripItem item)
    {
      return Icon.FromHandle(new Bitmap(item.Image).GetHicon());
    }

    /// <summary>
    /// Gets an icon from an icon by size.
    /// </summary>
    static public Icon GetBySize(this Icon icon, int width, int height)
    {
      return icon.GetBySize(new Size(width, height));
    }

    /// <summary>
    /// Gets an icon from an icon by size.
    /// </summary>
    static public Icon GetBySize(this Icon icon, Size size)
    {
      using var stream = new MemoryStream();
      icon.Save(stream);
      stream.Position = 0;
      return new Icon(stream, size);
    }

    /// <summary>
    /// Gets a bitmap of a control.
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
    /// Sets the color of the background.
    /// </summary>
    /// <param name="grid">The grid.</param>
    /// <param name="color">The color.</param>
    static public void SetBackColor(this DataGridView grid, Color color)
    {
      for ( int row = 0; row < grid.Rows.Count; row++ )
        for ( int col = 0; col < grid.Columns.Count; col++ )
          grid[col, row].Style.BackColor = color;
    }

    /// <summary>
    /// Sets the text justified.
    /// </summary>
    /// <param name="control">The control.</param>
    /// <param name="text">The text.</param>
    /// <param name="width">The width.</param>
    static public void SetTextJustified(this Control control, string text, int width)
    {
      control.Text = StackMethods.JustifyParagraph(text, width, control.Font);
    }

    /// <summary>
    /// Gets the grid points.
    /// </summary>
    /// <param name="control">The control.</param>
    /// <param name="margin">The margin.</param>
    static public List<Point> GetGridPoints(this Control control, int margin = 15)
    {
      int widthDiv2 = control.Width / 2;
      int heightDiv2 = control.Height / 2;
      int widthDiv4 = widthDiv2 / 4;
      int heightDiv4 = heightDiv2 / 4;
      return new List<Point>
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
    }

  }

}