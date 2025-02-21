/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
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
/// <edited> 2023-09 </edited>
namespace Ordisoftware.Core;

using System.Drawing.Text;

/// <summary>
/// Provides a solid brushes buffer.
/// </summary>
static public class SolidBrushesPool
{
  [SuppressMessage("Performance", "U2U1211:Avoid memory leaks", Justification = "N/A")]
  static private readonly Dictionary<Color, SolidBrush> Items = [];
  static public void Clear()
  {
    foreach ( var item in Items )
      item.Value.Dispose();
  }
  static public Brush Get(Color color)
  {

    if ( Items.TryGetValue(color, out var result) )
      return result;
    else
    {
      var brush = new SolidBrush(color);
      Items.Add(color, brush);
      return brush;
    }
  }
}

/// <summary>
/// Provides a pens buffer.
/// </summary>
static public class PensPool
{
  [SuppressMessage("Performance", "U2U1211:Avoid memory leaks", Justification = "N/A")]
  static private readonly Dictionary<Color, Pen> Items = [];
  static public void Clear()
  {
    foreach ( var item in Items )
      item.Value.Dispose();
  }
  static public Pen Get(Color color)
  {

    if ( Items.TryGetValue(color, out var result) )
      return result;
    else
    {
      var pen = new Pen(color);
      Items.Add(color, pen);
      return pen;
    }
  }
}

/// <summary>
/// Provides win forms helper.
/// </summary>
static class FormsHelper
{

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "N/A")]
  static public readonly List<FontFamily> InstalledFonts
    = [.. new InstalledFontCollection().Families.OrderBy(font => font.Name),];

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
    List<Form> list = keep is null
      ? [.. Application.OpenForms.GetAll(form => form.Visible).Reverse()]
      : [.. Application.OpenForms.GetAll(form => form.Visible && !keep(form)).Reverse()];
    foreach ( Form form in list )
      SystemManager.TryCatch(form.Close);
  }

  /// <summary>
  /// Gets all opened forms.
  /// </summary>
  [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "Error")]
  static public IEnumerable<Form> GetAll(this FormCollection forms, Func<Form, bool> select = null)
  {
    if ( select is null )
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
  /// A Control extension method that dispose all controls.
  /// </summary>
  /// <param name="control">The control.</param>
  static public void DisposeAllControls(this Control control)
  {
    if ( control is null ) return;
    control.SuspendLayout();
    try
    {
      while ( control.Controls.Count > 0 )
        control.Controls[0].Dispose();
    }
    finally
    {
      control.ResumeLayout();
    }
  }

  /// <summary>
  /// Gets all components of a form.
  /// </summary>
  [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "N/A")]
  static public IEnumerable<Component> GetComponents(this Form form)
  {
    const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    return from field in form.GetType().GetFields(flags)
           where typeof(Component).IsAssignableFrom(field.FieldType)
           let component = (Component)field.GetValue(form)
           where component is not null
           select component;
  }

  /// <summary>
  /// Gets a IEnumerable from a ToolStripItemCollection.
  /// </summary>
  static public IEnumerable<ToolStripItem> ToEnumerable(this ToolStripItemCollection collection, Func<ToolStripItem, bool> predicate = null)
  {
    var result = collection.Cast<ToolStripItem>();
    if ( predicate is not null ) result = result.Where(predicate);
    return result;
  }

  /// <summary>
  /// Sets a form location.
  /// </summary>
  /// <param name="form">The form.</param>
  /// <param name="location">The location.</param>
  static public void SetLocation(this Form form, ControlLocation location)
  {
    if ( form is null ) return;
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
        throw new AdvNotImplementedException(location);
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
    if ( form is null ) return;
    var area = Globals.MainForm is not null
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
  [SuppressMessage("Roslynator", "RCS1146:Use conditional access.", Justification = "N/A")]
  static public void CenterToFormElseMainFormElseScreen(this Form form, Form source)
  {
    if ( form is null ) return;
    if ( source is not null && source.Visible && source.WindowState != FormWindowState.Minimized )
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
    if ( form is null ) return;
    form.Location = new Point(area.Left + area.Width / 2 - form.Width / 2,
                              area.Top + area.Height / 2 - form.Height / 2);
  }

  /// <summary>
  /// Checks if location is in the screen else center to main form else to screen.
  /// </summary>
  static public void CheckLocationOrCenterToMainFormElseScreen(this Form form, bool includeZero = false)
  {
    int min = includeZero ? 1 : 0;
    if ( form is null ) return;
    if ( form.Location.X < min || form.Location.Y < min
      || form.Left > SystemInformation.WorkingArea.Width - form.Width / 2
      || form.Top > SystemInformation.WorkingArea.Height - form.Height / 2 )
      form.CenterToMainFormElseScreen();
  }

  /// <summary>
  /// Restore a minimized form.
  /// </summary>
  /// <param name="form">The form.</param>
  [SuppressMessage("Performance", "CA1806:Ne pas ignorer les résultats des méthodes", Justification = "N/A")]
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
    if ( form is null ) return;
    if ( form.IsDisposed ) return;
    if ( form.InvokeRequired )
    {
      form.Invoke(new PopupMethod(Popup), form, sender, dialog);
      return;
    }
    if ( form.Visible )
      if ( !dialog )
      {
        form.Restore();
        if ( sender is not null ) form.CenterToFormElseMainFormElseScreen(sender);
        form.ForceBringToFront();
      }
      else
      {
        if ( sender is not null ) form.CenterToFormElseMainFormElseScreen(sender);
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
      if ( sender is not null ) form.CenterToFormElseMainFormElseScreen(sender);
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
    form.Activate();
  }

  /// <summary>
  /// Loads fonts names into a combo box.
  /// </summary>
  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "Analysis error")]
  [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "N/A")]
  static public void LoadFonts(this ComboBox control, string nameSelected, Func<FontFamily, bool> filter = null)
  {
    foreach ( var font in filter is null ? InstalledFonts : InstalledFonts.Where(filter) )
    {
      int index = control.Items.Add(font.Name);
      if ( font.Name == nameSelected )
        control.SelectedIndex = index;
    }
  }

  /// <summary>
  /// Loads fonts names into a list box.
  /// </summary>
  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "Analysis error")]
  [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "N/A")]
  static public void LoadFonts(this ListBox control, string nameSelected, Func<FontFamily, bool> filter = null)
  {
    foreach ( var font in filter is null ? InstalledFonts : InstalledFonts.Where(filter) )
    {
      int index = control.Items.Add(font.Name);
      if ( font.Name == nameSelected )
        control.SelectedIndex = index;
    }
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
  static public void DuplicateTo(this ToolStripDropDownItem source, ToolStripMenuItem destination, bool noShortcuts = true)
  {
    var items = new List<ToolStripItem>();
    foreach ( ToolStripItem item in source.DropDownItems )
      if ( item.Tag is not int || (int)item.Tag != int.MinValue )
        if ( item is ToolStripMenuItem menuItem )
        {
          var newitem = menuItem.Clone();
          if ( noShortcuts ) newitem.ShortcutKeys = Keys.None;
          items.Add(newitem);
        }
        else
        if ( item is ToolStripSeparator )
          items.Add(new ToolStripSeparator());
    destination.DropDownItems.Clear();
    destination.DropDownItems.AddRange([.. items]);
  }

  /// <summary>
  /// Duplicate menu sub-items.
  /// </summary>
  static public void DuplicateTo(this ContextMenuStrip source, ToolStripMenuItem destination, bool noShortcuts = true)
  {
    var items = new List<ToolStripItem>();
    foreach ( ToolStripItem item in source.Items )
      if ( item.Tag is not int || (int)item.Tag != int.MinValue )
        if ( item is ToolStripMenuItem menuItem )
        {
          var newitem = menuItem.Clone();
          if ( noShortcuts ) newitem.ShortcutKeys = Keys.None;
          items.Add(newitem);
        }
        else
        if ( item is ToolStripSeparator )
          items.Add(new ToolStripSeparator());
    destination.DropDownItems.Clear();
    destination.DropDownItems.AddRange([.. items]);
  }

  /// <summary>
  /// Gets an icon from an image.
  /// </summary>
  static public Icon GetIcon(this Image image)
  {
    using var bitmap = new Bitmap(image);
    return Icon.FromHandle(bitmap.GetHicon());
  }

  /// <summary>
  /// Gets an icon from a ToolStripItem image.
  /// </summary>
  static public Icon GetIcon(this ToolStripItem item)
  {
    using var bitmap = new Bitmap(item.Image);
    return Icon.FromHandle(bitmap.GetHicon());
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
    if ( control is null ) return null;
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
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  static public List<Point> GetGridPoints(this Control control, int margin = 15)
  {
    int widthDiv2 = control.Width / 2;
    int heightDiv2 = control.Height / 2;
    int widthDiv4 = widthDiv2 / 4;
    int heightDiv4 = heightDiv2 / 4;
    return
    [
      // Center
      new(control.Left + widthDiv2, control.Top + heightDiv2),
      // Corners
      new(control.Left + margin, control.Top + margin),
      new(control.Right - margin, control.Top + margin),
      new(control.Left + margin, control.Bottom - margin),
      new(control.Right - margin, control.Bottom - margin),
      // Borders
      new(control.Left + widthDiv4, control.Top + heightDiv4),
      new(control.Right - widthDiv4, control.Top + heightDiv4),
      new(control.Left + widthDiv4, control.Bottom - heightDiv4),
      new(control.Right - widthDiv4, control.Bottom - heightDiv4),
      // Inner
      new(control.Left + widthDiv2, control.Top + margin),
      new(control.Left + widthDiv2, control.Bottom - margin),
      new(control.Left + margin, control.Top + heightDiv2),
      new(control.Right - margin, control.Top + heightDiv2)
    ];
  }

}
