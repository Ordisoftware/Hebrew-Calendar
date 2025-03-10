﻿/// <license>
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
/// <created> 2021-09 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
public partial class MainForm
{

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  private void DoCalendarMonth_MouseClick(object sender, MouseEventArgs e)
  {
    var dayEvent = MonthlyCalendar.CalendarEvents.Find(item => item.EventArea.Contains(e.X, e.Y));
    if ( dayEvent is null ) return;
    var dayRow = DBApp.LunisolarDays.Find(day => day.Date == dayEvent.Date);
    if ( dayRow is null ) return;
    if ( e.Button == MouseButtons.Left )
    {
      if ( e.Clicks > 1 )
        switch ( Settings.CalendarDoubleClickAction )
        {
          case CalendarDoubleClickAction.ContextMenu:
            ContextMenuDayCurrentEvent = dayRow;
            ContextMenuStripDay.Show(Cursor.Position);
            break;
          case CalendarDoubleClickAction.SetActive:
            GoToDate(dayRow.Date);
            break;
          case CalendarDoubleClickAction.Select:
            DateSelected = dayRow.Date;
            if ( MonthlyCalendar.CalendarDate.Month != dayRow.Date.Month )
              GoToDate(dayRow.Date);
            break;
          case CalendarDoubleClickAction.Nothing:
            break;
          default:
            throw new AdvNotImplementedException(Settings.CalendarDoubleClickAction);
        }
      else
      if ( e.Clicks == 1 )
      {
        if ( ModifierKeys.HasFlag(Keys.Control) )
        {
          DateSelected = dayRow.Date;
          if ( MonthlyCalendar.CalendarDate.Month != dayRow.Date.Month )
            GoToDate(dayRow.Date);
        }
        else
        if ( Settings.MonthViewChangeDayOnClick || ModifierKeys.HasFlag(Keys.Shift) )
          GoToDate(dayRow.Date);
      }
    }
    else
    if ( e.Button == MouseButtons.Right )
    {
      ContextMenuDayCurrentEvent = dayRow;
      ContextMenuStripDay.Show(Cursor.Position);
    }
  }

  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  private void DoContextMenuStripDay_Opened(object sender, EventArgs e)
  {
    // Day
    var date = Settings.TorahEventsCountAsMoon
      ? ContextMenuDayCurrentEvent.Moonrise ?? ContextMenuDayCurrentEvent.Date
      : ContextMenuDayCurrentEvent.Sunrise ?? ContextMenuDayCurrentEvent.Date;
    var rowDay = DBApp.GetDay(date);
    if ( rowDay is null ) return;
    ContextMenuDayDate.Text = rowDay?.DayAndMonthWithYearText ?? SysTranslations.NullSlot.GetLang();
    ContextMenuDayParashah.Enabled = false;
    ContextMenuDayParashah.Visible = Settings.CalendarShowParashah;
    ContextMenuDayParashah.Text = new System.Resources.ResourceManager(typeof(MainForm)).GetString("ContextMenuDayParashah.Text");
    var weeklong = rowDay?.GetWeekLongCelebrationIntermediateDay();
    var torahEvent = ( weeklong?.Event ) ?? TorahCelebration.None;
    if ( torahEvent == TorahCelebration.None )
      torahEvent = rowDay is not null ? TorahCelebrationSettings.Convert(rowDay.TorahEvent) : TorahCelebration.None;
    // Celebration
    string torahEventText = rowDay.TorahEventText;
    if ( torahEventText.Length == 0 )
    {
      var rowOmerDay = DBApp.GetDay(rowDay.Date);
      if ( rowOmerDay is not null )
        (torahEvent, _, torahEventText) = rowOmerDay.GetWeekLongCelebrationIntermediateDay();
    }
    if ( torahEvent != TorahCelebration.None )
    {
      ContextMenuDayDate.Text += $" - {torahEventText}";
      string celebrationName = HebrewTranslations.GetCelebrationDisplayText(torahEvent);
      ContextMenuDayCelebrationVersesBoard.Text = AppTranslations.VersesAboutCurrentCelebration.GetLang(celebrationName);
      ContextMenuDayCelebrationVersesBoard.Tag = torahEvent;
    }
    else
    {
      var rowNextCelebration = DBApp.GetCurrentOrNextCelebration(date);
      if ( rowNextCelebration is not null )
      {
        var weeklongNext = rowNextCelebration?.GetWeekLongCelebrationIntermediateDay();
        var torahEventNext = weeklongNext.Value.Event;
        if ( torahEventNext == TorahCelebration.None )
          torahEventNext = TorahCelebrationSettings.Convert(rowNextCelebration.TorahEvent);
        if ( torahEventNext != TorahCelebration.None )
        {
          string celebrationName = HebrewTranslations.GetCelebrationDisplayText(torahEventNext);
          ContextMenuDayCelebrationVersesBoard.Text = AppTranslations.VersesAboutNextCelebration.GetLang(celebrationName);
          ContextMenuDayCelebrationVersesBoard.Tag = torahEventNext;
        }
      }
    }
    // Parashah 
    if ( Settings.CalendarShowParashah )
    {
      var dayParashah = rowDay?.GetParashahReadingDay();
      bool isSimhatTorah1 = rowDay?.TorahEvent == TorahCelebrationDay.SoukotD8 && !Settings.UseSimhatTorahOutside;
      bool isSimhatTorah2 = DBApp.GetDay(date.AddDays(-1)).TorahEvent == TorahCelebrationDay.SoukotD8 && Settings.UseSimhatTorahOutside;
      bool show1 = weeklong?.Event != TorahCelebration.Pessah;
      bool show2 = !( weeklong?.Event == TorahCelebration.Soukot && dayParashah?.ParashahID == "1.1" );
      if ( ( show1 && show2 ) || isSimhatTorah1 || isSimhatTorah2 || rowDay == dayParashah )
      {
        var parashah = ParashotFactory.Instance.Get(dayParashah?.ParashahID);
        if ( dayParashah is not null && parashah is not null )
        {
          string captionParashah = parashah.ToStringShort(false, dayParashah.HasLinkedParashah);
          ContextMenuDayDate.Text += $" - {captionParashah}";
          ContextMenuDayParashah.Text = $"{HebrewTranslations.Parashah} {captionParashah}";
          ContextMenuDayParashah.Enabled = true;
        }
      }
    }
    // Activated and selected days
    ContextMenuDaySetAsActive.Enabled = ContextMenuDayCurrentEvent.Date != MonthlyCalendar.CalendarDate.Date;
    ContextMenuDayClearSelection.Enabled = DateSelected is not null && DateSelected != DateTime.Today;
    ContextMenuDaySelectDate.Enabled = ( DateSelected is null && DateTime.Today != ContextMenuDayCurrentEvent.Date )
                                        || ( DateSelected is not null && DateSelected != ContextMenuDayCurrentEvent.Date );
    ContextMenuDayGoToToday.Enabled = MonthlyCalendar.CalendarDate.Date != DateTime.Today;
    ContextMenuDayGoToSelected.Enabled = DateSelected is not null
                                         && DateSelected != ContextMenuDayCurrentEvent.Date;
    ContextMenuDayDatesDiffToToday.Enabled = ContextMenuDayCurrentEvent.Date != DateTime.Today;
    ContextMenuDayDatesDiffToSelected.Enabled = DateSelected is not null
                                                && ContextMenuDaySelectDate.Enabled && DateSelected != DateTime.Today;
    // Ephemeris
    ContextMenuDaySunrise.Visible = !ContextMenuDayCurrentEvent?.SunriseAsString.IsNullOrEmpty() ?? false;
    ContextMenuDaySunset.Visible = !ContextMenuDayCurrentEvent?.SunsetAsString.IsNullOrEmpty() ?? false;
    ContextMenuDaySunrise.Text = AppTranslations.Sunrise.GetLang(ContextMenuDayCurrentEvent?.SunriseAsString ?? "-");
    ContextMenuDaySunset.Text = AppTranslations.Sunset.GetLang(ContextMenuDayCurrentEvent?.SunsetAsString ?? "-");
    if ( ContextMenuDayCurrentEvent.MoonriseOccurring == MoonriseOccurring.AfterSet )
    {
      ContextMenuDayMoonrise.Visible = ContextMenuDayCurrentEvent.Moonset is not null;
      if ( ContextMenuDayMoonrise.Visible )
        ContextMenuDayMoonrise.Text = AppTranslations.Moonset.GetLang(ContextMenuDayCurrentEvent?.MoonsetAsString ?? "-");
      ContextMenuDayMoonset.Visible = ContextMenuDayCurrentEvent.MoonriseOccurring != MoonriseOccurring.NextDay;
      if ( ContextMenuDayMoonset.Visible )
        ContextMenuDayMoonset.Text = AppTranslations.Moonrise.GetLang(ContextMenuDayCurrentEvent?.MoonriseAsString ?? "-");
      ContextMenuDayMoonrise.ImageIndex = 3;
      ContextMenuDayMoonset.ImageIndex = 2;
    }
    else
    {
      ContextMenuDayMoonrise.Visible = ContextMenuDayCurrentEvent.MoonriseOccurring != MoonriseOccurring.NextDay;
      if ( ContextMenuDayMoonrise.Visible )
        ContextMenuDayMoonrise.Text = AppTranslations.Moonrise.GetLang(ContextMenuDayCurrentEvent?.MoonriseAsString ?? "-");
      ContextMenuDayMoonset.Visible = ContextMenuDayCurrentEvent.Moonset is not null;
      if ( ContextMenuDayMoonset.Visible )
        ContextMenuDayMoonset.Text = AppTranslations.Moonset.GetLang(ContextMenuDayCurrentEvent?.MoonsetAsString ?? "-");
      ContextMenuDayMoonrise.ImageIndex = 2;
      ContextMenuDayMoonset.ImageIndex = 3;
    }
    // Bookmarks
    date = rowDay.Date;
    ContextMenuDaySaveBookmark.Enabled = DBApp.DateBookmarks.Find(item => item.Date == date) is null;
    ContextMenuDayGoToBookmark.Enabled = DBApp.DateBookmarks.Count > 0;
  }

}
