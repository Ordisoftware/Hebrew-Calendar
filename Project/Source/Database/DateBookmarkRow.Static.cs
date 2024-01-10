/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2012-2024 Olivier Rogier.
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

using Equin.ApplicationFramework;

public partial class DateBookmarkRow
{

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "N/A")]
  static public void LoadMenuBookmarks(ToolStripItemCollection items, MouseEventHandler action)
  {
    if ( items is null ) return;
    items.Clear();
    var bookmarks = ApplicationDatabase.Instance.DateBookmarksAsBindingListView;
    bool onlyDatesWithinCalendar = items == MainForm.Instance.MenuBookmarks.Items;
    string digits = bookmarks.Count < 10 ? "0" : bookmarks.Count < 100 ? "00" : bookmarks.Count < 1000 ? "000" : "0000";
    int index = 0;
    foreach ( var bookmark in bookmarks )
    {
      index++;
      var menuitem = items.Add($"{index.ToString(digits)}. {bookmark}");
      menuitem.ForeColor = bookmark.Color;
      menuitem.MouseUp += action;
      menuitem.Tag = bookmark;
      if ( onlyDatesWithinCalendar )
        if ( bookmark.Date < MainForm.Instance.DateFirst || bookmark.Date > MainForm.Instance.DateLast )
          menuitem.Enabled = false;
    }
  }

  static public void MenuItemMouseUp(Form form,
                                     ToolStripMenuItem menuItem,
                                     MouseButtons button,
                                     Action<Form> reload,
                                     Action<DateBookmarkRow> onLeftClick)
  {
    if ( menuItem?.Tag is not DateBookmarkRow bookmark ) return;
    if ( button == MouseButtons.Right )
    {
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmark.GetLang(bookmark.ToString())) )
        return;
      ApplicationDatabase.Instance.Connection.Delete(bookmark);
      ApplicationDatabase.Instance.DateBookmarks.Remove(bookmark);
      reload(form);
    }
    else
    if ( button == MouseButtons.Left )
      onLeftClick(bookmark);
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
