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
/// <created> 2023-06 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase
{

  private void ImportFileBookmarksIfNeeded()
  {
    if ( File.Exists(Program.DateBookmarksFilePath) && DateBookmarks.Count == 0 )
    {
      bool hasErrors = false;
      var bookmarks = File.ReadLines(Program.DateBookmarksFilePath)
                          .Select(line => getBookmark(line))
                          .Where(bookmark => bookmark.Date != DateTime.MinValue);
      if ( !bookmarks.Any() ) return;
      foreach ( var bookmark in bookmarks )
      {
        Connection.Insert(bookmark);
        DateBookmarks.Add(bookmark);
      }
      LoadBookmarks();
      if ( DisplayManager.QueryYesNo(AppTranslations.BookmarksFileToTableHasErrorsElseSuccess[hasErrors].GetLang()) )
        SystemManager.RunShell(Path.GetDirectoryName(Program.DateBookmarksFilePath));
      //
      DateBookmarkRow getBookmark(string line)
      {
        string[] parts = line.SplitNoEmptyLines("=>");
        DateTime date;
        string memo = string.Empty;
        try
        {
          date = parts.Length >= 1 ? SQLiteDate.ToDateTime(parts[0].Substring(0, 10)) : DateTime.MinValue;
        }
        catch
        {
          hasErrors = true;
          date = DateTime.MinValue;
          DisplayManager.ShowError("Invalid date bookmark:" + Globals.NL2 + line);
        }
        if ( parts.Length >= 2 ) memo = parts[1];
        return new DateBookmarkRow { Date = date, Memo = memo };
      }
    }
  }

}
