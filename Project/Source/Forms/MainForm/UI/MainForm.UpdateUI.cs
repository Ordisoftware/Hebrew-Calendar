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
/// <created> 2016-04 </created>
/// <edited> 2021-09 </edited>
using System;
using System.Drawing;
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

    private bool DoScreenPositionMutex;

    private string TitleGPS = "";
    private string TitleOmer = "";

    /// <summary>
    /// Center the form to the screen.
    /// </summary>
    public new void CenterToScreen()
    {
      base.CenterToScreen();
    }

    /// <summary>
    /// Execute the screen location operation.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    protected void DoScreenPosition(object sender, EventArgs e)
    {
      if ( DoScreenPositionMutex ) return;
      try
      {
        DoScreenPositionMutex = true;
        if ( sender is ToolStripMenuItem menuItem )
        {
          var list = ( (ToolStripMenuItem)menuItem.OwnerItem ).DropDownItems;
          foreach ( ToolStripMenuItem item in list )
            item.Checked = item == menuItem;
        }
        if ( Globals.IsReady ) Settings.Store();
        this.SetLocation(Settings.MainFormPosition);
      }
      finally
      {
        DoScreenPositionMutex = false;
      }
    }

    /// <summary>
    /// Enable double-buffering.
    /// </summary>
    protected override CreateParams CreateParams
    {
      get
      {
        var cp = base.CreateParams;
        if ( Settings.WindowsDoubleBufferingEnabled )
          switch ( Settings.CurrentView )
          {
            case ViewMode.Text:
            case ViewMode.Month:
              cp.ExStyle |= 0x02000000; // + WS_EX_COMPOSITED
              //cp.Style &= ~0x02000000;  // - WS_CLIPCHILDREN
              break;
          }
        return cp;
      }
    }

    private bool UpdateTitlesMutex;

    /// <summary>
    /// Update form title bar and sub-title texts.
    /// </summary>
    private void UpdateTitles(bool force = false)
    {
      if ( !Globals.IsReady || Globals.IsGenerating ) return;
      if ( UpdateTitlesMutex ) return;
      UpdateTitlesMutex = true;
      try
      {
        string str;
        Text = Globals.AssemblyTitle;
        SystemManager.TryCatch(() =>
        {
          // Subtitle
          LabelSubTitleCalendar.Text = AppTranslations.Subtitle.GetLang();
          // Today
          if ( Settings.MainFormTitleBarShowToday )
            Text += " - " + ( ApplicationDatabase.Instance.GetToday()?.DayAndMonthWithYearText ?? SysTranslations.NullSlot.GetLang() );
          // GPS
          if ( !force && !TitleGPS.IsNullOrEmpty() )
            str = TitleGPS;
          else
            if ( !string.IsNullOrEmpty(Settings.GPSCountry) && !string.IsNullOrEmpty(Settings.GPSCity) )
            str = $"{Settings.GPSCountry} - {Settings.GPSCity}".ToUpper();
          else
            str = "GPS " + SysTranslations.UndefinedSlot.GetLang().ToUpper();
          LabelSubTitleGPS.Text = str;
          // Omer
          if ( !force && !TitleOmer.IsNullOrEmpty() )
            str = TitleOmer;
          else
            str = AppTranslations.MainFormSubTitleOmer[Settings.TorahEventsCountAsMoon].GetLang().ToUpper();
          LabelSubTitleOmer.Text = str;
          // Parashah
          if ( Settings.MainFormTitleBarShowWeeklyParashah )
          {
            var weekParashah = ApplicationDatabase.Instance.GetWeeklyParashah();
            if ( weekParashah.Factory != null )
            {
              ActionWeeklyParashah.Enabled = true;
              if ( MenuTools.DropDownItems.Count > 0 )
                MenuTools.DropDownItems[0].Enabled = true;
              str = weekParashah.Factory.ToStringShort(Program.Settings.ParashahCaptionWithBookAndRef,
                                                       weekParashah.Day.HasLinkedParashah);
              Text += " - Parashah " + str.ToUpper();
            }
            else
            {
              ActionWeeklyParashah.Enabled = false;
              if ( MenuTools.DropDownItems.Count > 0 )
                MenuTools.DropDownItems[0].Enabled = false;
            }
          }
        });
      }
      finally
      {
        UpdateTitlesMutex = false;
      }
    }

    /// <summary>
    /// Update the buttons.
    /// </summary>
    public void UpdateButtons()
    {
      SystemManager.TryCatchManage(() =>
      {
        if ( LoadingForm.Instance.Visible ) LoadingForm.Instance.Hide();
        MenuTray.Enabled = Globals.IsReady && !Globals.IsGenerating;
        ToolStrip.Enabled = !Globals.IsGenerating;
        ActionSaveToFile.Enabled = LunisolarDays.Count > 0;
        ActionCopyToClipboard.Enabled = ActionSaveToFile.Enabled;
        ActionPrint.Enabled = ActionSaveToFile.Enabled && Settings.CurrentView != ViewMode.Grid;
        ActionSearchEvent.Enabled = ActionSaveToFile.Enabled;
        ActionSearchMonth.Enabled = ActionSaveToFile.Enabled;
        ActionSearchDay.Enabled = ActionSaveToFile.Enabled;
        ActionNavigate.Enabled = ActionSaveToFile.Enabled;
        ActionViewCelebrations.Enabled = ActionSaveToFile.Enabled;
        Refresh();
      });
    }

    /// <summary>
    /// Update the text view aspect.
    /// </summary>
    public void UpdateTextCalendar()
    {
      CalendarText.Font = new Font(Settings.FontName, Settings.FontSize);
    }

    /// <summary>
    /// Update the month view.
    /// </summary>
    public void UpdateCalendarMonth(bool doFill)
    {
      Globals.IsGenerating = true;
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      bool formEnabled = Enabled;
      ToolStrip.Enabled = false;
      PanelViewMonth.Parent = null;
      try
      {
        InitializeCalendarUI();
        if ( doFill ) FillMonths();
      }
      finally
      {
        ToolStrip.Enabled = formEnabled;
        Cursor = cursor;
        Globals.IsGenerating = false;
        SetView(Settings.CurrentView, true);
        UpdateButtons();
      }
    }

    private void UpdateContextMenuStripDay()
    {
      var date = Program.Settings.TorahEventsCountAsMoon
             ? ContextMenuDayCurrentEvent.Moonrise ?? ContextMenuDayCurrentEvent.Date
             : ContextMenuDayCurrentEvent.Sunrise ?? ContextMenuDayCurrentEvent.Date;
      var rowDay = ApplicationDatabase.Instance.GetDay(date);
      ContextMenuDayDate.Text = rowDay?.DayAndMonthWithYearText ?? SysTranslations.NullSlot.GetLang();
      ContextMenuDayParashah.Enabled = false;
      if ( Settings.CalendarShowParashah )
        if ( ContextMenuDayCurrentEvent.TorahEvent == TorahCelebrationDay.None )
          if ( ContextMenuDayCurrentEvent.GetWeekLongCelebrationIntermediateDay().IsNullOrEmpty() )
          {
            var parashah = ParashotFactory.Instance.Get(rowDay?.GetParashahReadingDay()?.ParashahID);
            if ( parashah != null )
            {
              ContextMenuDayDate.Text += " - " + parashah.ToStringShort(false, rowDay.HasLinkedParashah);
              ContextMenuDayParashah.Enabled = true;
            }
          }
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
