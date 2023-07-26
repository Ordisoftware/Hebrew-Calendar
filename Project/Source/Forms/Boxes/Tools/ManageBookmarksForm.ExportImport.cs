/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ManageBookmarksForm : Form
{

  private const string TableName = "Date Bookmarks";

  private const int ExportColumnIndexID = 0;
  private const int ExportColumnIndexColorAsInt = 3;

  private const int ImportColumnsCount = 3;
  private const int ImportColumnIndexDate = 0;
  private const int ImportColumnIndexMemo = 1;
  private const int ImportColumnIndexColor = 2;

  private readonly Regex RegExForStringToColor
    = new(@"A=(?<Alpha>\d+),\s*R=(?<Red>\d+),\s*G=(?<Green>\d+),\s*B=(?<Blue>\d+)",
          RegexOptions.None,
          TimeSpan.FromSeconds(1));

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP017:Prefer using", Justification = "N/A (switch)")]
  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  private void DoActionExport()
  {
    if ( !SaveBookmarksDialog.Run(TableName, Settings.ExportDataPreferredTarget, Program.GridExportTargets) )
      return;
    string filePath = SaveBookmarksDialog.FileName;
    using var table = DBApp.DateBookmarks.ToDataTable(ApplicationDatabase.DateBookmarksTableName);
    table.Columns.RemoveAt(ExportColumnIndexColorAsInt);
    table.Columns.RemoveAt(ExportColumnIndexID);
    table.Export(SaveBookmarksDialog.FileName, Program.GridExportTargets);
    DisplayManager.ShowSuccessOrSound(SysTranslations.DataSavedToFile.GetLang(filePath),
                                      Globals.KeyboardSoundFilePath);
    if ( Settings.AutoOpenExportFolder )
      SystemManager.RunShell(Path.GetDirectoryName(filePath));
    if ( Settings.AutoOpenExportedFile )
      SystemManager.RunShell(filePath);
    EditBookmarks.Focus();
  }

  private void DoActionImport()
  {
    if ( !OpenBookmarksDialog.Run(string.Empty, Settings.ExportDataPreferredTarget, Program.BoardExportTargets) )
      return;
    try
    {
      ActionClear_Click(this, null);
      string extension = Path.GetExtension(OpenBookmarksDialog.FileName);
      var selected = Program.BoardExportTargets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.TXT:
          ImportTXT(File.ReadAllLines(OpenBookmarksDialog.FileName));
          break;
        case DataExportTarget.CSV:
          ImportCSV();
          break;
        case DataExportTarget.JSON:
          ImportJSON(JsonConvert.DeserializeObject<DataSet>(File.ReadAllText(OpenBookmarksDialog.FileName)));
          break;
        default:
          throw new AdvNotImplementedException(selected);
      }
      BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
      Modified = true;
    }
    catch ( AbortException )
    {
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(ex.Message);
    }
  }

  private void ImportTXT(string[] lines)
  {
    for ( int index = 0; index < lines.Length; index++ )
    {
      var date = DateTime.MinValue;
      try { date = SQLiteDate.ToDateTime(lines[index]); }
      catch { }
      var bookmark = new DateBookmarkRow() { Date = date };
      DBApp.Connection.Insert(bookmark);
      DBApp.DateBookmarks.Add(bookmark);
    }
  }

  private void ImportCSV()
  {
    var options = DataTableHelper.CreateCsvOptions<DateBookmarkRow>(ImportColumnsCount);
    using var table = CsvEngine.CsvToDataTable(OpenBookmarksDialog.FileName, options);
    foreach ( DataRow row in table.Rows )
    {
      DateTime.TryParse((string)row[ImportColumnIndexDate], out var date);
      var bookmark = new DateBookmarkRow
      {
        Date = date,
        Memo = (string)row[ImportColumnIndexMemo]
      };
      var match = RegExForStringToColor.Match((string)row[ImportColumnIndexColor]);
      if ( match.Success )
        SystemManager.TryCatch(() =>
        {
          int alpha = int.Parse(match.Groups["Alpha"].Value);
          int red = int.Parse(match.Groups["Red"].Value);
          int green = int.Parse(match.Groups["Green"].Value);
          int blue = int.Parse(match.Groups["Blue"].Value);
          bookmark.Color = Color.FromArgb(alpha, red, green, blue);
        });
      DBApp.Connection.Insert(bookmark);
      DBApp.DateBookmarks.Add(bookmark);
    }
  }

  private void ImportJSON(DataSet dataset)
  {
    int count = dataset.Tables[0].Rows.Count;
    for ( int index = 0; index < count; index++ )
    {
      var bookmark = new DateBookmarkRow
      {
        Date = (DateTime)dataset.Tables[0].Rows[index][ImportColumnIndexDate],
        Memo = (string)dataset.Tables[0].Rows[index][ImportColumnIndexMemo],
      };
      SystemManager.TryCatch(() =>
      {
        string[] rgbComponents = ( (string)dataset.Tables[0].Rows[index][ImportColumnIndexColor] ).Split(',');
        int red = int.Parse(rgbComponents[0].Trim());
        int green = int.Parse(rgbComponents[1].Trim());
        int blue = int.Parse(rgbComponents[2].Trim());
        bookmark.Color = Color.FromArgb(red, green, blue);
      });
      DBApp.Connection.Insert(bookmark);
      DBApp.DateBookmarks.Add(bookmark);
    }
  }

}
