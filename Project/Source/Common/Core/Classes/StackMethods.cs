using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ordisoftware.Core
{

  static class StackMethods
  {

    #region Enums

    /// From https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-public enum-value-in-c-sharp
    static public T Next<T>(this T value, params T[] skip) where T : Enum
    {
      var result = Enum.GetValues(value.GetType()).Cast<T>().Concat(new[] { default(T) })
                       .SkipWhile(e => !value.Equals(e))
                       .Skip(1)
                       .First();
      foreach ( T item in skip )
        if ( item.Equals(result) )
          result = result.Next(skip);
      return result;
    }

    /// From https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-public enum-value-in-c-sharp
    static public T Previous<T>(this T value, params T[] skip) where T : Enum
    {
      var result = Enum.GetValues(value.GetType()).Cast<T>().Concat(new[] { default(T) })
                       .Reverse()
                       .SkipWhile(e => !value.Equals(e))
                       .Skip(1)
                       .First();
      foreach ( T item in skip )
        if ( item.Equals(result) )
          result = result.Previous(skip);
      return result;
    }

    #endregion

    #region Numbers

    /// <summary>
    /// Create a readable string from a size in bytes.
    /// </summary>
    /// From https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc
    static public string FormatBytesSize(this ulong bytes)
    {
      string suffix = SysTranslations.MemorySizeSuffix.GetLang();
      ulong unit = 1024;
      if ( bytes < unit ) return $"{bytes} {suffix}";
      var exp = (int)( Math.Log(bytes) / Math.Log(unit) );
      string result = $"{bytes / Math.Pow(unit, exp):F2} {( "KMGTPEZY" )[exp - 1]}i{suffix}";
      return result.Replace(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator + "00", string.Empty);
    }

    #endregion

    #region Text

    /// <summary>
    /// Apply "justify" to the text of a control.
    /// </summary>
    /// From https://stackoverflow.com/questions/37155195/how-to-justify-text-in-a-label#47470191
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

    #endregion

    #region Bitmaps

    /// <summary>
    /// Resize an image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The image resized.</returns>
    /// From Stack Overflow
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

    #endregion

    #region WinForms Controls

    /// <summary>
    /// Indicate if a control is visible on the screen over others.
    /// </summary>
    /// From https://stackoverflow.com/questions/1649959/how-to-check-if-window-is-really-visible-in-windows-forms
    static public bool IsVisibleOnTop(this Control control, int requiredPercent = 100, int margin = 15)
    {
      if ( !control.Visible ) return false;
      var controls = control.GetAll<Control>().Select(c => c.Handle).ToList();
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

    #endregion

    #region WinForms Menus DropDown

    /// <summary>
    /// Ensure drop down menu items are displayed on the same screen.
    /// </summary>
    /// From https://stackoverflow.com/questions/26587843/prevent-toolstripmenuitems-from-jumping-to-second-screen
    static public void SetDropDownOpening(this ToolStrip toolstrip, EventHandler action = null)
    {
      if ( action == null ) action = MenuItemDropDownOpening;
      var items1 = toolstrip.Items.OfType<ToolStripDropDownButton>().ToList();
      var items2 = items1.SelectMany(item => item.DropDownItems.OfType<ToolStripMenuItem>()).ToList();
      var items3 = items2.SelectMany(item => item.DropDownItems.OfType<ToolStripMenuItem>()).ToList();
      items1.ForEach(item => { if ( item.HasDropDownItems ) item.DropDownOpening += action; });
      items2.ForEach(item => { if ( item.HasDropDownItems ) item.DropDownOpening += action; });
      items3.ForEach(item => { if ( item.HasDropDownItems ) item.DropDownOpening += action; });
    }

    /// <summary>
    /// Ensure drop down menu items are displayed on the same screen.
    /// </summary>
    /// From https://stackoverflow.com/questions/26587843/prevent-toolstripmenuitems-from-jumping-to-second-screen
    static public void SetDropDownOpening(this ContextMenuStrip menu, EventHandler action = null)
    {
      if ( action == null ) action = MenuItemDropDownOpening;
      var items1 = menu.Items.OfType<ToolStripMenuItem>().ToList();
      var items2 = items1.SelectMany(item => item.DropDownItems.OfType<ToolStripMenuItem>()).ToList();
      var items3 = items2.SelectMany(item => item.DropDownItems.OfType<ToolStripMenuItem>()).ToList();
      items1.ForEach(item => { if ( item.HasDropDownItems ) item.DropDownOpening += action; });
      items2.ForEach(item => { if ( item.HasDropDownItems ) item.DropDownOpening += action; });
      items3.ForEach(item => { if ( item.HasDropDownItems ) item.DropDownOpening += action; });
    }

    /// <summary>
    /// Ensure drop down menu items are displayed on the same screen.
    /// </summary>
    /// From https://stackoverflow.com/questions/26587843/prevent-toolstripmenuitems-from-jumping-to-second-screen
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

    #endregion

    #region WinForms ListBox

    /// From https://stackoverflow.com/questions/4796109/how-to-move-item-in-listbox-up-and-down#9684966
    static public void MoveSelectedItem(this ListBox listBox, int direction)
    {
      if ( listBox.SelectedItem == null || listBox.SelectedIndex < 0 ) return;
      int newIndex = listBox.SelectedIndex + direction;
      if ( newIndex < 0 || newIndex >= listBox.Items.Count ) return;
      object selected = listBox.SelectedItem;
      var checkedListBox = listBox as CheckedListBox;
      var checkState = CheckState.Unchecked;
      if ( checkedListBox != null ) checkState = checkedListBox.GetItemCheckState(checkedListBox.SelectedIndex);
      listBox.Items.Remove(selected);
      listBox.Items.Insert(newIndex, selected);
      listBox.SetSelected(newIndex, true);
      if ( checkedListBox != null ) checkedListBox.SetItemCheckState(newIndex, checkState);
    }

    /// From https://stackoverflow.com/questions/3012647/custom-listbox-sorting#3013558
    static public void Sort(this ListBox listBox, Func<object, object, int> compare)
    {
      bool swapped;
      do
      {
        int counter = listBox.Items.Count - 1;
        swapped = false;
        while ( counter > 0 )
        {
          if ( compare(listBox.Items[counter], listBox.Items[counter - 1]) == -1 )
          {
            object temp = listBox.Items[counter];
            listBox.Items[counter] = listBox.Items[counter - 1];
            listBox.Items[counter - 1] = temp;
            swapped = true;
          }
          counter -= 1;
        }
      }
      while ( swapped );
    }

    #endregion 

    #region DataTable

    /// <summary>
    /// Convert a collection of T to a DataTable.
    /// </summary>
    /// From https://stackoverflow.com/questions/4460654/best-practice-convert-linq-query-result-to-a-datatable-without-looping#31586395
    static public DataTable ToDataTable<T>(this IEnumerable<T> list, string name = "") where T : class
    {
      if ( list == null ) return null;
      var table = new DataTable();
      table.TableName = name;
      PropertyInfo[] columns = null;
      foreach ( T item in list )
      {
        if ( columns == null )
        {
          columns = item.GetType().GetProperties();
          foreach ( var column in columns )
          {
            var colType = column.PropertyType;
            if ( colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>) )
              colType = colType.GetGenericArguments()[0];
            table.Columns.Add(new DataColumn(column.Name, colType));
          }
        }
        var row = table.NewRow();
        foreach ( var column in columns )
          row[column.Name] = column.GetValue(item, null) ?? DBNull.Value;
        table.Rows.Add(row);
      }
      return table;
    }

    /// From https://stackoverflow.com/questions/6295161/how-to-build-a-datatable-from-a-datagridview#13344318
    static public DataTable ToDataTable(this DataGridView datagridview, string name = "", bool IgnoreHiddenColumns = false)
    {
      try
      {
        var table = new DataTable(name);
        foreach ( DataGridViewColumn column in datagridview.Columns )
        {
          if ( IgnoreHiddenColumns && !column.Visible ) continue;
          table.Columns.Add(column.Name, column.ValueType);
          table.Columns[column.Name].Caption = column.HeaderText;
        }
        foreach ( DataGridViewRow rowGrid in datagridview.Rows )
        {
          var rowTable = table.NewRow();
          foreach ( DataColumn column in table.Columns )
            rowTable[column.ColumnName] = rowGrid.Cells[column.ColumnName].Value;
          table.Rows.Add(rowTable);
        }
        return table;
      }
      catch { return null; }
    }

    #endregion 

    #region Resources

    /// <summary>
    /// Purge images from localized resource form code files.
    /// </summary>
    /// From https://stackoverflow.com/questions/15340615/resx-form-icon-cascade-updates#42977949
    static public void PurgeResourceImages(string title, string sourcepath, ref bool conditional)
    {
      try
      {
        if ( !Directory.Exists(sourcepath) ) return;
        string path = sourcepath;
        string[] files = Directory.GetFiles(path, "*fr.resx", SearchOption.AllDirectories);
        foreach ( string file in files )
        {
          var xdoc = XDocument.Load(file);
          var elements = xdoc.Root.Elements("data");
          var items = elements.Where(item => ( (string)item.Attribute("name") ).Contains(".Image")).ToList();
          if ( items.Count > 0 )
          {
            if ( !conditional )
            {
              MessageBox.Show("Purge *fr.resx images and exit.", title);
              conditional = true;
            }
            foreach ( var item in items )
              item.Remove();
            xdoc.Save(file);
          }
        }
      }
      catch ( Exception ex )
      {
        MessageBox.Show(ex.Message, title);
        conditional = true;
      }
      if ( conditional )
        Environment.Exit(0);
    }

    #endregion 

    #region WinTaskBar

    /// <summary>
    /// Get task bar coordonates.
    /// </summary>
    /// From https://stackoverflow.com/questions/3677182/taskbar-location
    static public Rectangle GetTaskbarCoordonates()
    {
      var data = new NativeMethods.APPBARDATA();
      data.cbSize = Marshal.SizeOf(data);
      IntPtr retval = NativeMethods.SHAppBarMessage(NativeMethods.ABM_GETTASKBARPOS, ref data);
      if ( retval == IntPtr.Zero )
        throw new Win32Exception("Windows Taskbar Error in " + nameof(GetTaskbarCoordonates));
      return new Rectangle(data.rc.left, data.rc.top, data.rc.right - data.rc.left, data.rc.bottom - data.rc.top);
    }

    #endregion

    #region Assembly

    /// From https://stackoverflow.com/questions/1600962/displaying-the-build-date
    static public DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
    {
      var filePath = assembly.Location;
      const int c_PeHeaderOffset = 60;
      const int c_LinkerTimestampOffset = 8;
      var buffer = new byte[2048];
      using ( var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read) )
        stream.Read(buffer, 0, 2048);
      var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
      var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
      var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      var linkTimeUtc = epoch.AddSeconds(secondsSince1970);
      var tz = target ?? TimeZoneInfo.Local;
      var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);
      return localTime;
    }

    #endregion

    #region Stack Trace

    static private Dictionary<string, string> AlreadyAcessedVarNames
      = new Dictionary<string, string>();

    /// From https://stackoverflow.com/questions/72121/finding-the-variable-name-passed-to-a-function/21219225#21219225
    static public string NameOfFromStack(this object instance, int level = 1)
    {
      try
      {
        var frame = new StackTrace(true).GetFrame(level);
        string filePath = frame.GetFileName();
        int lineNumber = frame.GetFileLineNumber();
        string id = filePath + lineNumber;
        if ( AlreadyAcessedVarNames.ContainsKey(id) )
          return AlreadyAcessedVarNames[id];
        using ( var file = new StreamReader(filePath) )
        {
          for ( int i = 0; i < lineNumber - 1; i++ )
            file.ReadLine();
          string line = file.ReadLine();
          string name = line.Split('(', ')')[1].TrimEnd(' ', ',');
          AlreadyAcessedVarNames.Add(id, name);
          return name;
        }
      }
      catch
      {
        return SysTranslations.ErrorSlot.GetLang();
      }
    }

    #endregion

  }

  /// <summary>
  /// Custom ToolStrip renderer
  /// </summary>
  /// From https://stackoverflow.com/questions/2097164/how-to-change-system-windows-forms-toolstripbutton-highlight-background-color-wh#2097341
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
