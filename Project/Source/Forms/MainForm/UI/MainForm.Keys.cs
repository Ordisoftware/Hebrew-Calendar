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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  /// <summary>
  /// Process the command key.
  /// </summary>
  /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  [SuppressMessage("Design", "GCop135:{0}", Justification = "N/A")]
  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    if ( Globals.IsReady )
      switch ( keyData )
      {
        // Top menu system
        case Keys.Alt | Keys.S:
          ActionSettings.ShowDropDown();
          return true;
        case Keys.Alt | Keys.I:
          ActionInformation.ShowDropDown();
          return true;
        case Keys.F9:
          ActionPreferences.PerformClick();
          return true;
        case Keys.Alt | Keys.Control | Keys.F4:
          MenuExit.PerformClick();
          return true;
        case Keys.Escape:
          if ( EditESCtoExit.Checked ) Close();
          return true;
        // Change view
        case Keys.Control | Keys.Shift | Keys.Tab:
          SetView(Settings.CurrentView.Previous(ViewMode.None));
          return true;
        case Keys.Control | Keys.Tab:
          SetView(Settings.CurrentView.Next(ViewMode.None));
          return true;
        case Keys.Alt | Keys.V:
          ActionSelectView.ShowDropDown();
          return true;
        // Top menu system
        case Keys.Alt | Keys.T:
          ActionTools.ShowDropDown();
          return true;
        case Keys.Alt | Keys.L:
          if ( ActionWebLinks.Enabled )
            ActionWebLinks.ShowDropDown();
          return true;
        // Top menu actions
        case Keys.F4:
          ActionViewNextCelebrations.PerformClick();
          return true;
        case Keys.F5:
          ActionSearchEvent.PerformClick();
          return true;
        case Keys.F6:
          ActionSearchLunarMonth.PerformClick();
          return true;
        case Keys.F7:
          ActionSearchGregorianMonth.PerformClick();
          return true;
        case Keys.F8:
        case Keys.Control | Keys.N:
          ActionNavigate.PerformClick();
          return true;
        // Weekly parashah
        case Keys.Alt | Keys.P:
          if ( !ActionWeeklyParashah.Enabled || ActionWeeklyParashah.DropDownItems.Count <= 0 ) break;
          ActionTools.ShowDropDown();
          ActionWeeklyParashah.ShowDropDown();
          ActionWeeklyParashah.DropDownItems[0].Select();
          return true;
        // Export
        case Keys.Control | Keys.S:
          ActionSaveToFile.PerformClick();
          return true;
        case Keys.Control | Keys.C:
          ActionCopyToClipboard.PerformClick();
          return true;
        case Keys.Control | Keys.P:
          ActionPrint.PerformClick();
          return true;
        // Search
        case Keys.Control | Keys.D:
          ActionSearchDay.PerformClick();
          return true;
        case Keys.NumPad0:
        case Keys.Control | Keys.T:
          GoToDate(DateTime.Today);
          return true;
        case Keys.Decimal:
        case Keys.Control | Keys.B:
          if ( DateSelected is not null )
            GoToDate(DateSelected.Value);
          else
            GoToDate(DateTime.Today);
          return true;
        // Context menu
        case Keys.Apps:
          if ( Settings.CurrentView != ViewMode.Month ) break;
          SystemManager.InputSimulator.Mouse.RightButtonClick();
          return true;
      }
    // Gregorian navigation
    if ( Settings.CurrentView == ViewMode.Month && CurrentDay is not null )
      switch ( keyData )
      {
        case Keys.Control | Keys.Home:
          searchEvent(true, v => v < 0);
          return true;
        case Keys.Control | Keys.End:
          searchEvent(false, v => v >= 0);
          return true;
        case Keys.Control | Keys.Left:
          searchEvent(false, v => v < 0);
          return true;
        case Keys.Control | Keys.Right:
          searchEvent(true, v => v >= 0);
          return true;
        case Keys.Home:
          GoToDate(new DateTime(YearFirst, 1, 1));
          return true;
        case Keys.End:
          GoToDate(new DateTime(YearLast, 12, 1));
          return true;
        case Keys.Up:
        case Keys.PageUp:
          GoToDate(CurrentDay.Date.AddYears(-1));
          return true;
        case Keys.Down:
        case Keys.PageDown:
          GoToDate(CurrentDay.Date.AddYears(1));
          return true;
        case Keys.Left:
          GoToDate(CurrentDay.Date.AddMonths(-1));
          return true;
        case Keys.Right:
          GoToDate(CurrentDay.Date.AddMonths(1));
          return true;
        case Keys.Subtract:
        case Keys.Shift | Keys.Left:
          GoToDate(CurrentDay.Date.AddDays(-1));
          return true;
        case Keys.Add:
        case Keys.Shift | Keys.Right:
          GoToDate(CurrentDay.Date.AddDays(+1));
          return true;
        case Keys.Shift | Keys.Up:
          GoToDate(CurrentDay.Date.AddDays(-Globals.DaysOfWeekCount));
          return true;
        case Keys.Shift | Keys.Down:
          GoToDate(CurrentDay.Date.AddDays(+Globals.DaysOfWeekCount));
          return true;
      }
    void searchEvent(bool isFuture, Func<int, bool> check)
    {
      var date = CurrentDay.Date.Change(day: 1);
      if ( isFuture ) date = date.AddMonths(1);
      var query = from day in LunisolarDays
                  where check(day.Date.CompareTo(date)) && ( day.HasTorahEvent || day.HasSeasonChange ) && !day.IsNewYear
                  select day;
      var found = isFuture ? query.FirstOrDefault() : query.LastOrDefault();
      if ( found is not null ) GoToDate(found.Date);
    }
    // Lunar navigation
    if ( Settings.CurrentView == ViewMode.Month && CurrentDay is not null )
      switch ( keyData )
      {
        case Keys.Up | Keys.Alt:
        case Keys.PageUp | Keys.Alt:
          moveToYearOfLunarDay(CurrentDay.Date, -1);
          return true;
        case Keys.Down | Keys.Alt:
        case Keys.PageDown | Keys.Alt:
          moveToYearOfLunarDay(CurrentDay.Date, +1);
          return true;
        case Keys.Left | Keys.Alt:
          moveToMonthOfLunarDay(CurrentDay.Date, -1);
          return true;
        case Keys.Right | Keys.Alt:
          moveToMonthOfLunarDay(CurrentDay.Date, +1);
          return true;
      }
    void moveToYearOfLunarDay(DateTime date, int deltaYear)
    {
      var row = LunisolarDays.Find(day => day.Date == date);
      if ( row is null ) return;
      int dayLunar = row.LunarDay;
      int monthLunar = row.LunarMonth;
      int year = row.Date.Year + deltaYear;
      row = LunisolarDays.Find(day => day.Date.Year == year && day.LunarMonth == monthLunar && day.LunarDay == dayLunar);
      if ( row is not null ) GoToDate(row.Date);
    }
    void moveToMonthOfLunarDay(DateTime date, int deltaMonth)
    {
      var row = LunisolarDays.Find(day => day.Date == date);
      if ( row is null ) return;
      int dayLunar = row.LunarDay;
      int index = LunisolarDays.FindIndex(day => day.Date == date);
      if ( index == -1 ) return;
      int indexEnd = deltaMonth > 0 ? LunisolarDays.Count : -1;
      index += deltaMonth;
      if ( !index.IsInRange(0, LunisolarDays.Count - 1) ) return;
      do
      {
        row = LunisolarDays[index];
        if ( row.LunarDay == dayLunar )
        {
          GoToDate(row.Date);
          break;
        }
        index += deltaMonth;
      }
      while ( index != indexEnd );
    }
    return base.ProcessCmdKey(ref msg, keyData);
  }

}
