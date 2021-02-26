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
/// <created> 2020-08 </created>
/// <edited> 2021-02 </edited>
using System;
using System.Linq;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class EditDateBookmarksForm : Form
  {

    private const string TableName = "Date Bookmarks";

    private class DateItem
    {
      public DateTime Date { get; set; }
      public override string ToString()
      {
        return Date == DateTime.MinValue ? SysTranslations.EmptySlot.GetLang() : Date.ToLongDateString();
      }
    }

    static public bool Run()
    {
      using ( var form = new EditDateBookmarksForm() )
        return form.ShowDialog() == DialogResult.OK;
    }

    private EditDateBookmarksForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      SaveBookmarksDialog.InitialDirectory = Program.Settings.GetExportDirectory();
      OpenBookmarksDialog.InitialDirectory = SaveBookmarksDialog.InitialDirectory;
      SaveBookmarksDialog.Filter = Program.BoardExportTargets.CreateFilters();
      OpenBookmarksDialog.Filter = SaveBookmarksDialog.Filter;
    }

    private void ManageDateBookmarks_Load(object sender, EventArgs e)
    {
      this.CenterToFormElseMainFormElseScreen(DatesDiffCalculatorForm.Instance);
      ListBox.Items.Clear();
      for ( int index = 0; index < Program.Settings.DateBookmarksCount; index++ )
        ListBox.Items.Add(new DateItem { Date = Program.DateBookmarks[index] });
      ListBox.SelectedIndex = 0;
      ActiveControl = ListBox;
    }

    private void ManageDateBookmarks_FormClosed(object sender, FormClosedEventArgs e)
    {
      if ( DialogResult != DialogResult.OK ) return;
      for ( int index = 0; index < Program.Settings.DateBookmarksCount; index++ )
        Program.DateBookmarks[index] = ( (DateItem)ListBox.Items[index] ).Date;
      Program.Settings.Save();
    }

    private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      ActionUp.Enabled = ListBox.SelectedIndex != 0;
      ActionDown.Enabled = ListBox.SelectedIndex != ListBox.Items.Count - 1;
      ActionDelete.Enabled = ListBox.SelectedIndex >= 0
                          && ( (DateItem)ListBox.Items[ListBox.SelectedIndex] ).Date != DateTime.MinValue;
    }

    private void ActionClear_Click(object sender, EventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmarkAll.GetLang()) ) return;
      for ( int index = 0; index < ListBox.Items.Count; index++ )
        ListBox.Items[index] = new DateItem { Date = DateTime.MinValue };
    }

    private void ActionDelete_Click(object sender, EventArgs e)
    {
      ListBox.Items[ListBox.SelectedIndex] = new DateItem { Date = DateTime.MinValue };
      ListBox.Focus();
    }

    private void ActionUp_Click(object sender, EventArgs e)
    {
      MoveSelectedItem(ListBox, -1);
      ListBox.Focus();
    }

    private void ActionDown_Click(object sender, EventArgs e)
    {
      MoveSelectedItem(ListBox, 1);
      ListBox.Focus();
    }

    // https://stackoverflow.com/questions/4796109/how-to-move-item-in-listbox-up-and-down#9684966
    static void MoveSelectedItem(ListBox listBox, int direction)
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

    // https://stackoverflow.com/questions/3012647/custom-listbox-sorting#3013558
    private void ActionSort_Click(object sender, EventArgs e)
    {
      bool swapped;
      do
      {
        int counter = ListBox.Items.Count - 1;
        swapped = false;
        while ( counter > 0 )
        {
          var date1 = ( (DateItem)ListBox.Items[counter] ).Date;
          var date2 = ( (DateItem)ListBox.Items[counter - 1] ).Date;
          if ( date1 == DateTime.MinValue ) date1 = DateTime.MaxValue;
          if ( date2 == DateTime.MinValue ) date2 = DateTime.MaxValue;
          if ( date1.CompareTo(date2) == -1 )
          {
            object temp = ListBox.Items[counter];
            ListBox.Items[counter] = ListBox.Items[counter - 1];
            ListBox.Items[counter - 1] = temp;
            swapped = true;
          }
          counter -= 1;
        }
      }
      while ( swapped );
      ListBox_SelectedIndexChanged(null, null);
      ListBox.Focus();
    }

    private void ActionExport_Click(object sender, EventArgs e)
    {
      SaveBookmarksDialog.FileName = TableName;
      for ( int index = 0; index < Program.BoardExportTargets.Count; index++ )
        if ( Program.BoardExportTargets.ElementAt(index).Key == Program.Settings.ExportDataPreferredTarget )
          SaveBookmarksDialog.FilterIndex = index + 1;
      if ( SaveBookmarksDialog.ShowDialog() != DialogResult.OK ) return;
      string extension = Path.GetExtension(SaveBookmarksDialog.FileName);
      var selected = Program.BoardExportTargets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.TXT:
          using ( var stream = File.CreateText(SaveBookmarksDialog.FileName) )
            foreach ( DateItem item in ListBox.Items )
              stream.WriteLine(SQLiteDate.ToString(item.Date));
          break;
        case DataExportTarget.CSV:
          using ( var stream = File.CreateText(SaveBookmarksDialog.FileName) )
          {
            stream.WriteLine("Date");
            foreach ( DateItem item in ListBox.Items )
              stream.WriteLine(SQLiteDate.ToString(item.Date));
          }
          break;
        case DataExportTarget.JSON:
          var data = ListBox.Items.Cast<DateItem>().Select(item => new { item.Date });
          var dataset = new DataSet(Globals.AssemblyTitle);
          dataset.Tables.Add(data.ToDataTable(TableName));
          string str = JsonConvert.SerializeObject(dataset, Formatting.Indented);
          File.WriteAllText(SaveBookmarksDialog.FileName, str, Encoding.UTF8);
          dataset.Tables.Clear();
          dataset.Dispose();
          break;
        default:
          throw new NotImplementedExceptionEx(selected);
      }
    }

    private void ActionImport_Click(object sender, EventArgs e)
    {
      OpenBookmarksDialog.FileName = string.Empty;
      for ( int index = 0; index < Program.BoardExportTargets.Count; index++ )
        if ( Program.BoardExportTargets.ElementAt(index).Key == Program.Settings.ExportDataPreferredTarget )
          OpenBookmarksDialog.FilterIndex = index + 1;
      if ( OpenBookmarksDialog.ShowDialog() != DialogResult.OK ) return;
      string extension = Path.GetExtension(OpenBookmarksDialog.FileName);
      var selected = Program.BoardExportTargets.First(p => p.Value == extension).Key;
      int indexListBox = 0;
      string[] lines;
      try
      {
        switch ( selected )
        {
          case DataExportTarget.TXT:
            lines = File.ReadAllLines(OpenBookmarksDialog.FileName);
            foreach ( string line in lines )
            {
              if ( indexListBox > ListBox.Items.Count ) break;
              var date = DateTime.MinValue;
              try { date = SQLiteDate.ToDateTime(line); }
              catch { }
              ListBox.Items[indexListBox++] = new DateItem { Date = date };
            }
            break;
          case DataExportTarget.CSV:
            lines = File.ReadAllLines(OpenBookmarksDialog.FileName);
            foreach ( string line in lines.Skip(1) )
            {
              if ( indexListBox > ListBox.Items.Count ) break;
              var date = DateTime.MinValue;
              try { date = SQLiteDate.ToDateTime(line); }
              catch { }
              ListBox.Items[indexListBox++] = new DateItem { Date = date };
            }
            break;
          case DataExportTarget.JSON:
            string str = File.ReadAllText(OpenBookmarksDialog.FileName);
            var dataset = JsonConvert.DeserializeObject<DataSet>(str);
            foreach ( DataRow row in dataset.Tables[0].Rows )
            {
              if ( indexListBox > ListBox.Items.Count ) break;
              ListBox.Items[indexListBox++] = new DateItem { Date = (DateTime)row[0] };
            }
            break;
          default:
            throw new NotImplementedExceptionEx(selected);
        }
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(ex.Message);
      }

    }

  }

}
