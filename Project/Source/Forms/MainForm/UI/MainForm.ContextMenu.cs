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
/// <created> 2021-09 </created>
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
public partial class MainForm
{

  private void DoCalendarMonth_MouseClick(object sender, MouseEventArgs e)
  {
    var dayEvent = CalendarMonth.CalendarEvents.Find(item => item.EventArea.Contains(e.X, e.Y));
    if ( dayEvent is null ) return;
    var dayRow = ApplicationDatabase.Instance.LunisolarDays.Find(day => day.Date == dayEvent.Date);
    if ( dayRow is null ) return;
    if ( e.Button == MouseButtons.Left )
    {
      if ( e.Clicks > 1 )
        switch ( Settings.CalendarDoubleClickAction )
        {
          case CalendarDoubleClickAction.SetActive:
            GoToDate(dayRow.Date);
            break;
          case CalendarDoubleClickAction.Select:
            DateSelected = dayRow.Date;
            if ( CalendarMonth.CalendarDate.Month != dayRow.Date.Month )
              GoToDate(dayRow.Date);
            break;
        }
      else
      if ( e.Clicks == 1 )
      {
        if ( ModifierKeys.HasFlag(Keys.Control) )
        {
          DateSelected = dayRow.Date;
          if ( CalendarMonth.CalendarDate.Month != dayRow.Date.Month )
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

  private void DoContextMenuStripDay_Opened(object sender, EventArgs e)
  {
    // Day
    var date = Program.Settings.TorahEventsCountAsMoon
               ? ContextMenuDayCurrentEvent.Moonrise ?? ContextMenuDayCurrentEvent.Date
               : ContextMenuDayCurrentEvent.Sunrise ?? ContextMenuDayCurrentEvent.Date;
    var rowDay = ApplicationDatabase.Instance.GetDay(date);
    ContextMenuDayDate.Text = rowDay?.DayAndMonthWithYearText ?? SysTranslations.NullSlot.GetLang();
    ContextMenuDayParashah.Enabled = false;
    ContextMenuDayParashah.Visible = Settings.CalendarShowParashah;
    ContextMenuDayParashah.Text = new System.Resources.ResourceManager(GetType()).GetString("ContextMenuDayParashah.Text");
    var weeklong = rowDay?.GetWeekLongCelebrationIntermediateDay();
    var torahevent = ( weeklong?.Event ) ?? TorahCelebration.None;
    if ( torahevent == TorahCelebration.None )
      torahevent = rowDay is not null ? TorahCelebrationSettings.Convert(rowDay.TorahEvent) : TorahCelebration.None;
    // Celebration
    if ( torahevent != TorahCelebration.None )
    {
      string nameCelebration = AppTranslations.TorahCelebrations.GetLang(torahevent);
      ContextMenuDayDate.Text += $" - {nameCelebration}";
      ContextMenuDayCelebrationVersesBoard.Text = AppTranslations.VersesAboutCurrentCelebration.GetLang(nameCelebration);
    }
    else
    {
      var rowNextCelebration = ApplicationDatabase.Instance.GetCurrentOrNextCelebration(date);
      if ( rowNextCelebration is not null )
      {
        var weeklongNext = rowNextCelebration?.GetWeekLongCelebrationIntermediateDay();
        var toraheventNext = weeklongNext.Value.Event;
        if ( toraheventNext == TorahCelebration.None )
          toraheventNext = TorahCelebrationSettings.Convert(rowNextCelebration.TorahEvent);
        if ( toraheventNext != TorahCelebration.None )
        {
          string nameCelebrationNext = AppTranslations.TorahCelebrations.GetLang(toraheventNext);
          ContextMenuDayCelebrationVersesBoard.Text = AppTranslations.VersesAboutNextCelebration.GetLang(nameCelebrationNext);
        }
      }
    }
    // Parashah 
    if ( Settings.CalendarShowParashah )
    {
      var dayParashah = rowDay?.GetParashahReadingDay();
      bool isSimhatTorah1 = rowDay?.TorahEvent == TorahCelebrationDay.SoukotD8 && !Settings.UseSimhatTorahOutside;
      bool isSimhatTorah2 = ApplicationDatabase.Instance.GetDay(date.AddDays(-1)).TorahEvent == TorahCelebrationDay.SoukotD8 && Settings.UseSimhatTorahOutside;
      bool show1 = weeklong?.Event != TorahCelebration.Pessah;
      bool show2 = !( weeklong?.Event == TorahCelebration.Soukot && dayParashah?.ParashahID == "1.1" );
      if ( ( show1 && show2 ) || isSimhatTorah1 || isSimhatTorah2 || rowDay == dayParashah )
      {
        var parashah = ParashotFactory.Instance.Get(dayParashah?.ParashahID);
        if ( parashah is not null )
        {
          string captionParashah = parashah.ToStringShort(false, dayParashah.HasLinkedParashah);
          ContextMenuDayDate.Text += $" - {captionParashah}";
          ContextMenuDayParashah.Text = $"Parashah {captionParashah}";
          ContextMenuDayParashah.Enabled = true;
        }
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
      if ( ContextMenuDayCurrentEvent.MoonriseOccuring == MoonriseOccurring.AfterSet )
      {
        ContextMenuDayMoonrise.Visible = ContextMenuDayCurrentEvent.Moonset is not null;
        if ( ContextMenuDayMoonrise.Visible )
          ContextMenuDayMoonrise.Text = AppTranslations.Moonset.GetLang(ContextMenuDayCurrentEvent?.MoonsetAsString ?? "-");
        ContextMenuDayMoonset.Visible = ContextMenuDayCurrentEvent.MoonriseOccuring != MoonriseOccurring.NextDay;
        if ( ContextMenuDayMoonset.Visible )
          ContextMenuDayMoonset.Text = AppTranslations.Moonrise.GetLang(ContextMenuDayCurrentEvent?.MoonriseAsString ?? "-");
        ContextMenuDayMoonrise.ImageIndex = 3;
        ContextMenuDayMoonset.ImageIndex = 2;
      }
      else
      {
        ContextMenuDayMoonrise.Visible = ContextMenuDayCurrentEvent.MoonriseOccuring != MoonriseOccurring.NextDay;
        if ( ContextMenuDayMoonrise.Visible )
          ContextMenuDayMoonrise.Text = AppTranslations.Moonrise.GetLang(ContextMenuDayCurrentEvent?.MoonriseAsString ?? "-");
        ContextMenuDayMoonset.Visible = ContextMenuDayCurrentEvent.Moonset is not null;
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
