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
/// <created> 2016-04 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private void DoBookmarksMouseUp(object sender, MouseEventArgs e)
  {
    /*var menuitem = (ToolStripMenuItem)sender;
    var control = CurrentBookmarkMenu;
    if ( e.Button == MouseButtons.Right && control == ContextMenuDaySaveBookmark
      && !menuitem.Text.EndsWith(")", StringComparison.Ordinal) )
    {
      var date = Program.DateBookmarks[(int)menuitem.Tag].Date.ToLongDateString();
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmark.GetLang(date)) )
        return;
      menuitem.Text = $"{(int)menuitem.Tag + 1:00}. {SysTranslations.EmptySlot.GetLang()}";
      ContextMenuDayGoToBookmark.DropDownItems[(int)menuitem.Tag].Text = menuitem.Text;
      ContextMenuDayGoToBookmark.DropDownItems[(int)menuitem.Tag].Enabled = false;
      Program.DateBookmarks[(int)menuitem.Tag] = null;
      Program.DateBookmarks.ApplyAutoSort();
      SystemManager.TryCatch(Settings.Save);
      LoadMenuBookmarks(this);
    }
    else
    if ( e.Button == MouseButtons.Left )
    {
      if ( control == ContextMenuDaySaveBookmark )
        setBookmark();
      else
      {
        var partDate = menuitem.Text.Skip(3).TakeWhile(c => c != DateBookmarkItem.MemoSeparator);
        if ( DateTime.TryParse(new string(partDate.ToArray()), out DateTime date) )
          if ( control == ContextMenuDayGoToBookmark )
            GoToDate(date);
      }
    }
    DatesDiffCalculatorForm.Instance.LoadMenuBookmarks(this);
    // TODO refactor with datediffcalc form
    void setBookmark()
    {
      var dateNew = ContextMenuDayCurrentEvent.Date;
      for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
      {
        var bookmark = Program.DateBookmarks[index];
        if ( bookmark is not null && dateNew == bookmark.Date ) return;
      }
      var bookmarkOld = Program.DateBookmarks[(int)menuitem.Tag];
      if ( bookmarkOld is not null )
      {
        string date1 = bookmarkOld.Date.ToShortDateString();
        string date2 = dateNew.ToShortDateString();
        string msg = SysTranslations.AskToReplaceBookmark.GetLang(date1, date2);
        if ( !DisplayManager.QueryYesNo(msg) ) return;
      }
      string memo = string.Empty;
      if ( DisplayManager.QueryValue(SysTranslations.Memo.GetLang(),
                                     dateNew.ToLongDateString(),
                                     ref memo) == InputValueResult.Cancelled )
        return;
      Program.DateBookmarks[(int)menuitem.Tag] = new DateBookmarkItem(dateNew, memo);
      Program.DateBookmarks.ApplyAutoSort();
      SystemManager.TryCatch(Settings.Save);
      LoadMenuBookmarks(this);
    }*/
  }

}
