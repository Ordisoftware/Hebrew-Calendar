﻿/// <license>
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
/// <created> 2021-09 </created>
/// <edited> 2021-09 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// The application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class MainForm
  {

    private void DoCalendarMonth_MouseClick(object sender, MouseEventArgs e)
    {
      var dayEvent = CalendarMonth.CalendarEvents.FirstOrDefault(item => item.EventArea.Contains(e.X, e.Y));
      if ( dayEvent == null ) return;
      var dayRow = ApplicationDatabase.Instance.LunisolarDays.FirstOrDefault(day => day.Date == dayEvent.Date);
      if ( dayRow == null ) return;
      bool showContextMenu = true;// CalendarMonth.CalendarDate.Month == dayRow.Date.Month;
      if ( e.Button == MouseButtons.Left )
      {
        if ( e.Clicks > 1 )
          switch ( Settings.CalendarDoubleClickAction )
          {
            case CalendarDoubleClickAction.SetActive:
              GoToDate(dayRow.Date);
              break;
            case CalendarDoubleClickAction.Select:
              if ( showContextMenu ) DateSelected = dayRow.Date;
              break;
          }
        else
        if ( e.Clicks == 1 )
        {
          bool valid = false;
          if ( Settings.MonthViewChangeDayOnClick || ModifierKeys.HasFlag(Keys.Shift) )
          {
            GoToDate(dayRow.Date);
            valid = true;
          }
          if ( ( showContextMenu || valid ) && ModifierKeys.HasFlag(Keys.Control) )
          {
            DateSelected = dayRow.Date;
            if ( CalendarMonth.CalendarDate.Month != dayRow.Date.Month )
              GoToDate(dayRow.Date);
          }
          else
          if ( !showContextMenu && ModifierKeys.HasFlag(Keys.Control) )
          {
            GoToDate(dayRow.Date);
            DateSelected = dayRow.Date;
          }
        }
      }
      else
      if ( showContextMenu && e.Button == MouseButtons.Right )
      {
        ContextMenuDayCurrentEvent = dayRow;
        ContextMenuStripDay.Show(Cursor.Position);
      }
    }

    private void DoContextMenuStripDay_Opened(object sender, EventArgs e)
    {
      // Day
      var date = Program.Settings.TorahEventsCountAsMoon
             ? ContextMenuDayCurrentEvent.Moonrise ?? ContextMenuDayCurrentEvent.Date
             : ContextMenuDayCurrentEvent.Sunrise ?? ContextMenuDayCurrentEvent.Date;
      var rowDay = ApplicationDatabase.Instance.GetDay(date);
      ContextMenuDayDate.Text = rowDay?.DayAndMonthWithYearText ?? SysTranslations.NullSlot.GetLang();
      ContextMenuDayParashah.Enabled = false;
      // Celebration
      string celebration = AppTranslations.TorahCelebrationDays[ContextMenuDayCurrentEvent.TorahEvent].GetLang();
      string weeklong = ContextMenuDayCurrentEvent.GetWeekLongCelebrationIntermediateDay();
      bool isNoCelebration = celebration.IsNullOrEmpty();
      bool isNoWeekLong = weeklong.IsNullOrEmpty();
      bool isNoEvent = isNoCelebration && isNoWeekLong;
      bool isSimhatTorah = ContextMenuDayCurrentEvent.TorahEvent == TorahCelebrationDay.SoukotD8 && !Settings.UseSimhatTorahOutside;
      if ( !isNoEvent || isSimhatTorah )
        if (!isNoWeekLong)
          ContextMenuDayDate.Text += " - " + weeklong;
        else
          ContextMenuDayDate.Text += " - " + celebration;
      // Parashah 
      if ( Settings.CalendarShowParashah )
        if ( isNoEvent || isSimhatTorah )
        {
          var parashah = ParashotFactory.Instance.Get(rowDay?.GetParashahReadingDay()?.ParashahID);
          if ( parashah != null )
          {
            ContextMenuDayDate.Text += " - " + parashah.ToStringShort(false, rowDay.HasLinkedParashah);
            ContextMenuDayParashah.Enabled = true;
          }
        }
      // Times
      ContextMenuDaySetAsActive.Enabled = ContextMenuDayCurrentEvent.Date != CalendarMonth.CalendarDate.Date;
      ContextMenuDayClearSelection.Enabled = DateSelected.HasValue && DateSelected != DateTime.Today;
      ContextMenuDaySelectDate.Enabled = ( !DateSelected.HasValue && DateTime.Today != ContextMenuDayCurrentEvent.Date )
                                          || ( DateSelected.HasValue && DateSelected != ContextMenuDayCurrentEvent.Date );
      ContextMenuDayGoToToday.Enabled = CalendarMonth.CalendarDate.Date != DateTime.Today;
      ContextMenuDayGoToSelected.Enabled = DateSelected.HasValue
                                           && DateSelected.Value != ContextMenuDayCurrentEvent.Date;
      ContextMenuDayDatesDiffToToday.Enabled = ContextMenuDayCurrentEvent.Date != DateTime.Today;
      ContextMenuDayDatesDiffToSelected.Enabled = DateSelected.HasValue
                                                  && ContextMenuDaySelectDate.Enabled && DateSelected != DateTime.Today;
      if ( Settings.TorahEventsCountAsMoon )
      {
        ContextMenuDayMoonrise.Visible = false;
        ContextMenuDayMoonset.Visible = false;
        ContextMenuDaySunrise.Visible = !ContextMenuDayCurrentEvent?.SunriseAsString.IsNullOrEmpty() ?? false;
        ContextMenuDaySunset.Visible = !ContextMenuDayCurrentEvent?.SunsetAsString.IsNullOrEmpty() ?? false;
        ContextMenuDaySunrise.Text = AppTranslations.Sunrise.GetLang(ContextMenuDayCurrentEvent?.SunriseAsString ?? "-");
        ContextMenuDaySunset.Text = AppTranslations.Sunset.GetLang(ContextMenuDayCurrentEvent?.SunsetAsString ?? "-");
      }
      else
      {
        ContextMenuDaySunrise.Visible = false;
        ContextMenuDaySunset.Visible = false;
        if ( ContextMenuDayCurrentEvent.MoonriseOccuring == MoonriseOccuring.AfterSet )
        {
          ContextMenuDayMoonrise.Visible = ContextMenuDayCurrentEvent.Moonset != null;
          if ( ContextMenuDayMoonrise.Visible )
            ContextMenuDayMoonrise.Text = AppTranslations.Moonset.GetLang(ContextMenuDayCurrentEvent?.MoonsetAsString ?? "-");
          ContextMenuDayMoonset.Visible = ContextMenuDayCurrentEvent.MoonriseOccuring != MoonriseOccuring.NextDay;
          if ( ContextMenuDayMoonset.Visible )
            ContextMenuDayMoonset.Text = AppTranslations.Moonrise.GetLang(ContextMenuDayCurrentEvent?.MoonriseAsString ?? "-");
          ContextMenuDayMoonrise.ImageIndex = 3;
          ContextMenuDayMoonset.ImageIndex = 2;
        }
        else
        {
          ContextMenuDayMoonrise.Visible = ContextMenuDayCurrentEvent.MoonriseOccuring != MoonriseOccuring.NextDay;
          if ( ContextMenuDayMoonrise.Visible )
            ContextMenuDayMoonrise.Text = AppTranslations.Moonrise.GetLang(ContextMenuDayCurrentEvent?.MoonriseAsString ?? "-");
          ContextMenuDayMoonset.Visible = ContextMenuDayCurrentEvent.Moonset != null;
          if ( ContextMenuDayMoonset.Visible )
            ContextMenuDayMoonset.Text = AppTranslations.Moonset.GetLang(ContextMenuDayCurrentEvent?.MoonsetAsString ?? "-");
          ContextMenuDayMoonrise.ImageIndex = 2;
          ContextMenuDayMoonset.ImageIndex = 3;
        }
      }
      ContextMenuDayTimesSeparator.Visible = ContextMenuDaySunrise.Visible || ContextMenuDaySunset.Visible
                                          || ContextMenuDayMoonrise.Visible || ContextMenuDayMoonset.Visible;
    }

  }

}
