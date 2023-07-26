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

  private void ImportJSON()
  {
    DateBookmarkRow bookmark = null;
    int indexRecord = 0;
    LastErrors.Clear();
    var dataset = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText(OpenBookmarksDialog.FileName),
                                                         new JsonSerializerSettings
                                                         {
                                                           Error = (_, e) =>
                                                           {
                                                             AddLastEddor(e.ErrorContext.Error.Message);
                                                             e.ErrorContext.Handled = true;
                                                           }
                                                         });
    foreach ( DataRow row in dataset.Tables[0].Rows )
    {
      indexRecord++;
      if ( !ProcessData(TitleDate,
                        indexRecord,
                        row[ImportColumnIndexDate],
                        data => bookmark = new DateBookmarkRow((DateTime)data)) )
        continue;
      ProcessData(TitleMemo, indexRecord, row[ImportColumnIndexMemo], data => bookmark.Memo = (string)data);
      ProcessData(TitleColor, indexRecord, row[ImportColumnIndexColor], data =>
      {
        string[] rgbComponents = ( (string)data ).Split(',');
        int red = int.Parse(rgbComponents[0].Trim());
        int green = int.Parse(rgbComponents[1].Trim());
        int blue = int.Parse(rgbComponents[2].Trim());
        bookmark.Color = Color.FromArgb(red, green, blue);
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
