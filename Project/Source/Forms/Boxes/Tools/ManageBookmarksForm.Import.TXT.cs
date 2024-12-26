/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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

  private void ImportTXT()
  {
    DateBookmarkRow bookmark;
    int indexLine = 0;
    LastErrors.Clear();
    foreach ( var line in File.ReadAllLines(OpenBookmarksDialog.FileName) )
    {
      indexLine++;
      try
      {
        bookmark = new DateBookmarkRow(SQLiteDate.ToDateTime(line));
      }
      catch
      {
        AddLastEddor(SysTranslations.ErrorInFile.GetLang(string.Empty, indexLine, line));
        continue;
      }
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
