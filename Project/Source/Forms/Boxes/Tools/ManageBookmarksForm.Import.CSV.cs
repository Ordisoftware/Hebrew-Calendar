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

  private void ImportCSV()
  {
    DateBookmarkRow bookmark = null;
    int indexRecord = 0;
    LastErrors.Clear();
    var options = DataTableHelper.CreateCsvOptions<DateBookmarkRow>(ImportColumnsCount);
    using var table = CsvEngine.CsvToDataTable(OpenBookmarksDialog.FileName, options);
    foreach ( DataRow row in table.Rows )
    {
      indexRecord++;
      if ( !ProcessData(TitleDate,
                        indexRecord,
                        row[ImportColumnIndexDate],
                        data => bookmark = new DateBookmarkRow(DateTime.Parse((string)data))) )
        continue;
      ProcessData(TitleMemo, indexRecord, row[ImportColumnIndexMemo], data => bookmark.Memo = (string)data);
      ProcessData(TitleColor, indexRecord, row[ImportColumnIndexColor], data =>
      {
        var match = RegExForStringToColor.Match((string)data);
        if ( !match.Success ) throw new Exception();
        int alpha = int.Parse(match.Groups["Alpha"].Value);
        int red = int.Parse(match.Groups["Red"].Value);
        int green = int.Parse(match.Groups["Green"].Value);
        int blue = int.Parse(match.Groups["Blue"].Value);
        bookmark.Color = Color.FromArgb(alpha, red, green, blue);
      });
      try
      {
        DBApp.Connection.Insert(bookmark);
        DBApp.DateBookmarks.Add(bookmark);
      }
      catch ( Exception ex )
      {
        AddLastEddor(ex.Message);
      }
    }
    ShowErrors();
  }

}
