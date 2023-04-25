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
/// <created> 2020-09 </created>
/// <edited> 2023-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed record class DateBookmarkItem(DateTime Date, string Memo);

sealed class DateBookmarks
{

  static private readonly Properties.Settings Settings = Program.Settings;

  private readonly string FilePath;

  public NullSafeList<DateBookmarkItem> Items { get; private set; } = new(Settings.DateBookmarksCount);

  public DateBookmarkItem this[int index]
  {
    get => Items[index];
    set
    {
      Items[index] = value;
      Save();
    }
  }

  public int MinListSize
  {
    get
    {
      for ( int index = Items.Count - 1; index >= 0; index-- )
        if ( Items[index] is not null )
          return index + 1;
      return 0;
    }
  }

  public void ApplyAutoSort()
  {
    if ( !Settings.AutoSortBookmarks ) return;
    Items.Sort((itemFirst, itemLast) =>
    {
      if ( itemFirst is null ) return 1;
      if ( itemLast is null ) return -1;
      return itemFirst.Date.CompareTo(itemLast.Date);
    });
    Save();
  }

  [SuppressMessage("Performance", "CA1806:Ne pas ignorer les résultats des méthodes", Justification = "N/A")]
  private void Load()
  {
    SystemManager.TryCatchManage(() =>
    {
      if ( !File.Exists(FilePath) ) return;
      var values = new NullSafeOfStringDictionary<string>();
      values.LoadKeyValuePairs(FilePath, "=>");
      values.Remove("0001-01-01");
      if ( values.Count > Settings.DateBookmarksCount )
      {
        Settings.DateBookmarksCount = values.Count;
        Settings.Save();
      }
      Items = new NullSafeList<DateBookmarkItem>(values.Select(item => createBookmark(item.Key, item.Value)));
      ApplyAutoSort();
    });
    //
    DateBookmarkItem createBookmark(string date, string memo)
    {
      try
      {
        return new DateBookmarkItem(SQLiteDate.ToDateTime(date), memo);
      }
      catch
      {
        try
        {
          return new DateBookmarkItem(DateTime.Parse(date), memo);
        }
        catch
        {
          return null;
        }
      }
    }
  }

  private void Save()
  {
    SystemManager.TryCatchManage(() =>
    {
      var dic = Items.Where(item => item is not null)
                     .ToDictionary(item => SQLiteDate.ToString(item.Date), item => item.Memo);
      var values = new NullSafeOfStringDictionary<string>(dic);
      values.SaveKeyValuePairs(FilePath, "=>");
    });
  }

  public DateBookmarks(string filePath)
  {
    FilePath = filePath;
    Load();
  }

}
