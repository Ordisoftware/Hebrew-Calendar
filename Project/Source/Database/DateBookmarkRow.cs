/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2012-2023 Olivier Rogier.
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
/// <edited> 2023-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using SQLite;
using Equin.ApplicationFramework;

[Serializable]
[Table("DateBookmarks")]
public class DateBookmarkRow
{

  public const char MemoSeparator = '-';

  [PrimaryKey]
  public Guid ID { get; set; } = Guid.NewGuid();

  [NotNull]
  public DateTime Date { get; set; } = DateTime.Now;

  [NotNull]
  public string Memo { get; set; } = string.Empty;

  public override string ToString()
  {
    string result = Date.ToLongDateString();
    if ( !Memo.IsNullOrEmpty() ) result += $" {MemoSeparator} {Memo}";
    return result;
  }

  public DateBookmarkRow()
  {
  }

  public DateBookmarkRow(DateTime date, string memo)
  {
    Date = date;
    Memo = memo;
  }

  public DateBookmarkRow(DateBookmarkRow item)
  {
    Date = item.Date;
    Memo = item.Memo;
  }

  static public DateBookmarkRow CreateFromUserInput(DateTime date,
                                                    bool beginTransaction = false,
                                                    BindingListView<DateBookmarkRow> list = null)
  {
    string memo = string.Empty;
    string title = SysTranslations.Memo.GetLang();
    string caption = date.ToLongDateString();
    if ( DisplayManager.QueryValue(title, caption, ref memo) == InputValueResult.Cancelled ) return null;
    if ( beginTransaction ) ApplicationDatabase.Instance.BeginTransaction();
    if ( list is not null )
    {
      var objectview = list.AddNew();
      objectview.Object.Date = date;
      objectview.Object.Memo = memo;
      ApplicationDatabase.Instance.Connection.Insert(objectview.Object);
      ApplicationDatabase.Instance.DateBookmarks.Add(objectview.Object);
      return objectview.Object;
    }
    else
    {
      var bookmark = new DateBookmarkRow(date, memo);
      ApplicationDatabase.Instance.Connection.Insert(bookmark);
      ApplicationDatabase.Instance.DateBookmarks.Add(bookmark);
      return bookmark;
    }
  }

}
