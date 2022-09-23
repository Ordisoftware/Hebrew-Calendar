/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class MainForm
{

  private void DoBookmarksMouseUp(object sender, MouseEventArgs e)
  {
    var menuitem = (ToolStripMenuItem)sender;
    var control = CurrentBookmarkMenu;
    if ( e.Button == MouseButtons.Right && control == ContextMenuDaySaveBookmark
      && !menuitem.Text.EndsWith(")", StringComparison.Ordinal) )
    {
      var date = Program.DateBookmarks[(int)menuitem.Tag].ToLongDateString();
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmark.GetLang(date)) )
        return;
      menuitem.Text = $"{(int)menuitem.Tag + 1:00}. {SysTranslations.EmptySlot.GetLang()}";
      ContextMenuDayGoToBookmark.DropDownItems[(int)menuitem.Tag].Text = menuitem.Text;
      ContextMenuDayGoToBookmark.DropDownItems[(int)menuitem.Tag].Enabled = false;
      Program.DateBookmarks[(int)menuitem.Tag] = DateTime.MinValue;
      SystemManager.TryCatch(Settings.Save);

    }
    else
    if ( e.Button == MouseButtons.Left )
    {
      if ( control == ContextMenuDaySaveBookmark )
        setBookmark();
      else
      if ( DateTime.TryParse(menuitem.Text.Substring(3), out DateTime date) )
        if ( control == ContextMenuDayGoToBookmark )
          GoToDate(date);
    }
    DatesDiffCalculatorForm.Instance.LoadMenuBookmarks(this);
    //
    void setBookmark()
    {
      var dateNew = ContextMenuDayCurrentEvent.Date;
      for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
      {
        var date = Program.DateBookmarks[index];
        if ( dateNew == date ) return;
      }
      var dateOld = Program.DateBookmarks[(int)menuitem.Tag];
      if ( dateOld != DateTime.MinValue
        && !DisplayManager.QueryYesNo(SysTranslations.AskToReplaceBookmark.GetLang(dateOld.ToShortDateString(),
                                                                                   dateNew.ToShortDateString())) )
        return;
      menuitem.Text = $"{(int)menuitem.Tag + 1:00}. {dateNew.ToLongDateString()}";
      ContextMenuDayGoToBookmark.DropDownItems[(int)menuitem.Tag].Text = menuitem.Text;
      ContextMenuDayGoToBookmark.DropDownItems[(int)menuitem.Tag].Enabled = true;
      Program.DateBookmarks[(int)menuitem.Tag] = ContextMenuDayCurrentEvent.Date;
      SystemManager.TryCatch(Settings.Save);
    }
  }

}
