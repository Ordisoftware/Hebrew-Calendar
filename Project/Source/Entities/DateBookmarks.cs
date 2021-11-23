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
/// <created> 2020-09 </created>
/// <edited> 2021-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

class DateBookmarks
{

  private string FilePath { get; }

  private DateTime[] Items = new DateTime[Program.Settings.DateBookmarksCount];

  public DateTime this[int index]
  {
    get { return Items[index]; }
    set { Items[index] = value; Save(); }
  }

  public void Resize(int size)
  {
    Array.Resize(ref Items, size);
    Save();
  }

  private void Load()
  {
    SystemManager.TryCatchManage(() =>
    {
      if ( !File.Exists(FilePath) ) return;
      int index = 0;
      foreach ( string item in File.ReadAllLines(FilePath) )
      {
        if ( item.Length == 0 )
          continue;
        DateTime date = DateTime.MinValue;
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
