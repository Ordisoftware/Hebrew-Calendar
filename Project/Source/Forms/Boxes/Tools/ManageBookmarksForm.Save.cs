/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ManageBookmarksForm : Form
{

  private const string TableName = "Date Bookmarks";

  private bool RunDialog(FileDialog dialog, string filename)
  {
    dialog.FileName = filename;
    for ( int index = 0; index < Program.BoardExportTargets.Count; index++ )
      if ( Program.BoardExportTargets.ElementAt(index).Key == Settings.ExportDataPreferredTarget )
        dialog.FilterIndex = index + 1;
    return dialog.ShowDialog() == DialogResult.OK;
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP017:Prefer using", Justification = "N/A (switch)")]
  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  private void DoActionExport_Click(object sender, EventArgs e)
  {
    if ( !RunDialog(SaveBookmarksDialog, TableName) ) return;
    try
    {
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
          throw new AdvNotImplementedException(selected);
      }
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(ex.Message);
    }
  }

  private void DoActionImport_Click(object sender, EventArgs e)
  {
    if ( !RunDialog(OpenBookmarksDialog, string.Empty) ) return;
    try
    {
      ListBox.Items.Clear();
      string extension = Path.GetExtension(OpenBookmarksDialog.FileName);
      var selected = Program.BoardExportTargets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.TXT:
          importTextOrCSV(File.ReadAllLines(OpenBookmarksDialog.FileName));
          break;
        case DataExportTarget.CSV:
          importTextOrCSV(File.ReadAllLines(OpenBookmarksDialog.FileName).Skip(1).ToArray());
          break;
        case DataExportTarget.JSON:
          importJSON(JsonConvert.DeserializeObject<DataSet>(File.ReadAllText(OpenBookmarksDialog.FileName)));
          break;
        default:
          throw new AdvNotImplementedException(selected);
      }
      //
      for ( int index = ListBox.Items.Count; index < Settings.DateBookmarksCount; index++ )
        ListBox.Items.Add(new DateItem { Date = DateTime.MinValue });
      //
      ActionClear.Enabled = ListBox.Items.Count > 0;
      ActionSort.Enabled = ListBox.Items.Count > 0;
    }
    catch ( AbortException )
    {
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(ex.Message);
    }
    //
    int checkCount(int count)
    {
      if ( count > PreferencesForm.DateBookmarksCountInterval.Item2 )
      {
        var message = SysTranslations.ImportBookmarksTooManyBookmarks;
        DisplayManager.ShowWarning(message.GetLang(PreferencesForm.DateBookmarksCountInterval.Item2,
                                                   count,
                                                   OpenBookmarksDialog.FileName));
        count = PreferencesForm.DateBookmarksCountInterval.Item2;
      }
      if ( count > Settings.DateBookmarksCount )
      {
        Program.DateBookmarks.Resize(count);
        Settings.DateBookmarksCount = count;
        Settings.Save();
      }
      return count;
    }
    //
    void importTextOrCSV(string[] lines)
    {
      int count = checkCount(lines.Length);
      for ( int index = 0; index < count; index++ )
      {
        var date = DateTime.MinValue;
        try { date = SQLiteDate.ToDateTime(lines[index]); }
        catch { }
        ListBox.Items.Add(new DateItem { Date = date });
      }
    }
    //
    void importJSON(DataSet dataset)
    {
      int count = checkCount(dataset.Tables[0].Rows.Count);
      for ( int index = 0; index < count; index++ )
        ListBox.Items.Add(new DateItem { Date = (DateTime)dataset.Tables[0].Rows[index][0] });
    }
  }

}
