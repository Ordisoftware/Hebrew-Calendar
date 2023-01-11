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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

class DateBookmarks
{

  private readonly string FilePath;

  private DateTime[] Items = new DateTime[Program.Settings.DateBookmarksCount];

  public int MaxCount
  {
    get
    {
      for ( int index = Items.Length - 1; index >= 0; index-- )
        if ( Items[index] != DateTime.MinValue )
          return index + 1;
      return 0;
    }
  }

  public DateTime this[int index]
  {
    get => Items[index];
    set
    {
      Items[index] = value;
      // TODO auto sort bookmarks if ( Program.Settings.AutoSortBookmarks )
      //  Array.Sort(Items, (dateFirst, dateLast) =>
      //  {
      //    if ( dateFirst == DateTime.MinValue ) dateFirst = DateTime.MaxValue;
      //    if ( dateLast == DateTime.MinValue ) dateLast = DateTime.MaxValue;
      //    return dateFirst.CompareTo(dateLast);
      //  });
      Save();
    }
  }

  public void Resize(int size)
  {
    Array.Resize(ref Items, size);
    Save();
  }

  [SuppressMessage("Performance", "CA1806:Ne pas ignorer les résultats des méthodes", Justification = "N/A")]
  private void Load()
  {
    SystemManager.TryCatchManage(() =>
    {
      if ( !File.Exists(FilePath) ) return;
      var lines = File.ReadAllLines(FilePath);
      if ( lines.Length > Items.Length )
      {
        Array.Resize(ref Items, lines.Length);
        Program.Settings.DateBookmarksCount = lines.Length;
        Program.Settings.Save();
      }
      int index = 0;
      foreach ( string item in lines )
      {
        if ( item.Length == 0 )
          continue;
        DateTime date;
        try
        {
          date = SQLiteDate.ToDateTime(item);
        }
        catch
        {
          DateTime.TryParse(item, out date);
        }
        Items[index] = date;
        if ( ++index >= Program.Settings.DateBookmarksCount )
          break;
      }
    });
  }

  private void Save()
  {
    SystemManager.TryCatchManage(() =>
    {
      var items = new List<string>();
      foreach ( var item in Items )
        items.Add(SQLiteDate.ToString(item));
      File.WriteAllLines(FilePath, items);
    });
  }

  public DateBookmarks(string filePath)
  {
    FilePath = filePath;
    Load();
  }

}
