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

  private readonly Regex RegExForStringToColor
    = new(@"A=(?<Alpha>\d+),\s*R=(?<Red>\d+),\s*G=(?<Green>\d+),\s*B=(?<Blue>\d+)",
          RegexOptions.None,
          TimeSpan.FromSeconds(1));

  private CsvOptions CsvOptions = new(nameof(DateBookmarkRow), Globals.CSVSeparator, 5)
  {
    IncludeHeaderNames = true,
    DateFormat = "yyyy-MM-dd HH:mm",
    Encoding = Encoding.UTF8
  };

  private bool RunDialog(FileDialog dialog, string filename, NullSafeOfStringDictionary<DataExportTarget> board)
  {
    dialog.FileName = filename;
    for ( int index = 0; index < board.Count; index++ )
      if ( Program.BoardExportTargets.ElementAt(index).Key == Settings.ExportDataPreferredTarget )
        dialog.FilterIndex = index + 1;
    return dialog.ShowDialog() == DialogResult.OK;
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP017:Prefer using", Justification = "N/A (switch)")]
  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  private void DoActionExport()
  {
    if ( !RunDialog(SaveBookmarksDialog, TableName, Program.GridExportTargets) ) return;
    string filePath = SaveBookmarksDialog.FileName;

    using var table = DBApp.DateBookmarks.ToDataTable();
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
    if ( !RunDialog(OpenBookmarksDialog, string.Empty, Program.BoardExportTargets) ) return;
    try
    {
      ActionClear_Click(this, null);
      string extension = Path.GetExtension(OpenBookmarksDialog.FileName);
      var selected = Program.BoardExportTargets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.TXT:
          importTXT(File.ReadAllLines(OpenBookmarksDialog.FileName));
          break;
        case DataExportTarget.CSV:
          importCSV();
          break;
        case DataExportTarget.JSON:
          importJSON(JsonConvert.DeserializeObject<DataSet>(File.ReadAllText(OpenBookmarksDialog.FileName)));
          break;
        default:
          throw new AdvNotImplementedException(selected);
      }
      UpdateControls();
    }
    catch ( AbortException )
    {
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(ex.Message);
    }
    //
    void importTXT(string[] lines)
    {
      for ( int index = 0; index < lines.Length; index++ )
      {
        var date = DateTime.MinValue;
        try { date = SQLiteDate.ToDateTime(lines[index]); }
        catch { }
        //ListBox.Items.Add(new DateBookmarkItem(date, "")); // TODO get memos
      }
    }
    //
    void importCSV()
    {
      using var table = CsvEngine.CsvToDataTable(OpenBookmarksDialog.FileName, CsvOptions);
      foreach ( DataRow row in table.Rows )
      {
        DateTime.TryParse((string)row[1], out var date);
        var memo = (string)row[2];
        var color = Program.Settings.DateBookmarkDefaultTextColor;
        var match = RegExForStringToColor.Match((string)row[4]);
        if ( match.Success )
        {
          int alpha = int.Parse(match.Groups["Alpha"].Value);
          int red = int.Parse(match.Groups["Red"].Value);
          int green = int.Parse(match.Groups["Green"].Value);
          int blue = int.Parse(match.Groups["Blue"].Value);
          color = Color.FromArgb(alpha, red, green, blue);
        }
        var bookmark = new DateBookmarkRow(date, memo, color);
        DBApp.Connection.Insert(bookmark);
        DBApp.DateBookmarks.Add(bookmark);
      }
      BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
      Modified = true;
      UpdateControls();
    }
    //
    void importJSON(DataSet dataset)
    {
      int count = dataset.Tables[0].Rows.Count;
      //for ( int index = 0; index < count; index++ )
      //  .Add(new DateBookmarkItem((DateTime)dataset.Tables[0].Rows[index][0],
      //                    (string)dataset.Tables[0].Rows[index][1]));
    }
  }

}
