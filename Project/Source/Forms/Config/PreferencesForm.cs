/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-10 </edited>
using System;
using System.Xml;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Form for viewing the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm : Form
  {

    const int RemindShabatHoursBeforeMin = 1;
    const int RemindShabatHoursBeforeMax = 12;
    const int RemindShabatHoursBeforeValue = 6;
    const int RemindShabatEveryMinutesMin = 5;
    const int RemindShabatEveryMinutesMax = 60;
    const int RemindShabatEveryMinutesValue = 15;
    const int RemindCelebrationBeforeMin = 1;
    const int RemindCelebrationBeforeMax = 60;
    const int RemindCelebrationBeforeValue = 7;
    const int RemindCelebrationHoursBeforeMin = 1;
    const int RemindCelebrationHoursBeforeMax = 24;
    const int RemindCelebrationHoursBeforeValue = 6;
    const int RemindCelebrationEveryMinutesMin = 5;
    const int RemindCelebrationEveryMinutesMax = 60;
    const int RemindCelebrationEveryMinutesValue = 15;

    static private bool LanguageChanged;
    static private bool DoReset;

    static public bool Run()
    {
      MainForm.Instance.TimerReminder.Enabled = false;
      string lang = Program.Settings.Language;
      var form = new PreferencesForm();
      form.ShowDialog();
      while ( LanguageChanged || DoReset )
      {
        NavigationForm.Instance.Close();
        LanguageChanged = false;
        DoReset = false;
        form = new PreferencesForm();
        form.ShowDialog();
      }
      MainForm.Instance.Refresh();
      MainForm.Instance.TimerReminder.Enabled = Program.Settings.ReminderCelebrationsEnabled || Program.Settings.ReminderShabatEnabled;
      return form.Reseted
          || form.OldShabatDay != Program.Settings.ShabatDay
          || form.OldLatitude != Program.Settings.GPSLatitude
          || form.OldLongitude != Program.Settings.GPSLongitude
          || form.OldReminderUseColors != Program.Settings.UseColors
          || form.OldReminderShabatDayColor != Program.Settings.EventColorShabat
          || form.OldReminderCurrentDayColor != Program.Settings.EventColorTorah
          || form.OldUseMoonDays != Program.Settings.TorahEventsCountAsMoon
          || lang != Program.Settings.Language;
    }

    public Color OldReminderCurrentDayColor { get; private set; }
    public Color OldReminderShabatDayColor { get; private set; }
    public bool OldReminderUseColors { get; private set; }
    public int OldShabatDay { get; private set; }
    public string OldLatitude { get; private set; }
    public string OldLongitude { get; private set; }
    public bool OldUseMoonDays { get; private set; }
    public bool Reseted = false;

    /// <summary>
    /// Default constructor.
    /// </summary>
    private PreferencesForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      LoadDays();
      LoadEvents();
      LoadFonts();
      EditTimerInterval.Minimum = RemindCelebrationBeforeMin;
      EditTimerInterval.Maximum = RemindCelebrationBeforeMax;
      EditTimerInterval.Value = RemindCelebrationBeforeValue;
      EditRemindShabatHoursBefore.Minimum = RemindShabatHoursBeforeMin;
      EditRemindShabatHoursBefore.Maximum = RemindShabatHoursBeforeMax;
      EditRemindShabatHoursBefore.Value = RemindShabatHoursBeforeValue;
      EditRemindShabatEveryMinutes.Minimum = RemindShabatEveryMinutesMin;
      EditRemindShabatEveryMinutes.Maximum = RemindShabatEveryMinutesMax;
      EditRemindShabatEveryMinutes.Value = RemindShabatEveryMinutesValue;
      EditRemindCelebrationHoursBefore.Minimum = RemindCelebrationHoursBeforeMin;
      EditRemindCelebrationHoursBefore.Maximum = RemindCelebrationHoursBeforeMax;
      EditRemindCelebrationHoursBefore.Value = RemindCelebrationHoursBeforeValue;
      EditRemindCelebrationEveryMinutes.Minimum = RemindCelebrationEveryMinutesMin;
      EditRemindCelebrationEveryMinutes.Maximum = RemindCelebrationEveryMinutesMax;
      EditRemindCelebrationEveryMinutes.Value = RemindCelebrationEveryMinutesValue;
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_Shown(object sender, EventArgs e)
    {
      if ( Program.Settings.FirstLaunch )
      {
        Program.Settings.FirstLaunch = false;
        DisplayManager.ShowAdvert(Translations.OmerMoon.GetLang());
      }
      if ( Program.Settings.GPSLatitude == "" || Program.Settings.GPSLongitude == "" )
        ActionGetGPS_LinkClicked(null, null);
      UpdateLanguagesButtons();
      foreach ( var item in EditFontName.Items )
        if ( (string)item == Program.Settings.FontName )
        {
          EditFontName.SelectedItem = item;
          break;
        }
      EditLoomingDelay.Value = Program.Settings.BalloonLoomingDelay;
      EditGPSLongitude.Text = Program.Settings.GPSLongitude;
      EditGPSLatitude.Text = Program.Settings.GPSLatitude;
      EditBalloon.Checked = Program.Settings.BalloonEnabled;
      EditBalloonAutoHide.Checked = Program.Settings.BalloonAutoHide;
      EditShowReminderInTaskBar.Checked = Program.Settings.ShowReminderInTaskBar;
      EditFontSize.Value = Program.Settings.FontSize;
      EditUseMoonDays.Checked = Program.Settings.TorahEventsCountAsMoon;
      EditTimerEnabled.Checked = Program.Settings.ReminderCelebrationsEnabled;
      EditStartupHide.Checked = Program.Settings.StartupHide;
      EditShowMonthDayToolTip.Checked = Program.Settings.MonthViewSunToolTips;
      EditCheckUpdateAtStartup.Checked = Program.Settings.CheckUpdateAtStartup;
      EditRemindShabat.Checked = Program.Settings.ReminderShabatEnabled;
      EditRemindShabatOnlyLight.Checked = Program.Settings.RemindShabatOnlyLight;
      EditTimerInterval.Value = Program.Settings.ReminderCelebrationsInterval;
      EditRemindShabatHoursBefore.Value = Program.Settings.RemindShabatHoursBefore;
      EditRemindShabatEveryMinutes.Value = Program.Settings.RemindShabatEveryMinutes;
      EditRemindCelebrationHoursBefore.Value = Program.Settings.RemindCelebrationHoursBefore;
      EditRemindCelebrationEveryMinutes.Value = Program.Settings.RemindCelebrationEveryMinutes;
      PanelTopColor.BackColor = Program.Settings.NavigateTopColor;
      PanelMiddleColor.BackColor = Program.Settings.NavigateMiddleColor;
      PanelBottomColor.BackColor = Program.Settings.NavigateBottomColor;
      PanelTextColor.BackColor = Program.Settings.TextColor;
      PanelBackColor.BackColor = Program.Settings.TextBackground;
      PanelCurrentDayColor.BackColor = Program.Settings.CurrentDayForeColor;
      PanelCurrentDayBackColor.BackColor = Program.Settings.CurrentDayBackColor;
      PanelTorahEventColor.BackColor = Program.Settings.CalendarColorTorahEvent;
      PanelSeasonEventColor.BackColor = Program.Settings.CalendarColorSeason;
      PanelMoonEventColor.BackColor = Program.Settings.CalendarColorMoon;
      PanelFullMoonColor.BackColor = Program.Settings.CalendarColorFullMoon;
      PanelEventColorTorah.BackColor = Program.Settings.EventColorTorah;
      PanelEventColorSeason.BackColor = Program.Settings.EventColorSeason;
      PanelEventColorShabat.BackColor = Program.Settings.EventColorShabat;
      PanelEventColorNewMonth.BackColor = Program.Settings.EventColorMonth;
      PanelEventColorNext.BackColor = Program.Settings.EventColorNext;
      EditReminderUseColors.Checked = Program.Settings.UseColors;
      OldReminderCurrentDayColor = Program.Settings.EventColorTorah;
      OldReminderUseColors = Program.Settings.UseColors;
      OldReminderShabatDayColor = Program.Settings.EventColorShabat;
      OldShabatDay = Program.Settings.ShabatDay;
      OldLatitude = Program.Settings.GPSLatitude;
      OldLongitude = Program.Settings.GPSLongitude;
      OldUseMoonDays = Program.Settings.TorahEventsCountAsMoon;
      EditGPSLatitude.Text = OldLatitude.ToString();
      EditGPSLongitude.Text = OldLongitude.ToString();
      LabelCountryCity.Text = Program.Settings.GPSCountry + ", " + Program.Settings.GPSCity;
      if ( Program.Settings.TimeZone != "" )
      {
        foreach ( var item in TimeZoneInfo.GetSystemTimeZones() )
          if ( Program.Settings.TimeZone == item.Id )
            LabelCountryCity.Text += ", " + item.DisplayName;
      }
      switch ( Program.Settings.TrayIconClickOpen )
      {
        case TrayIconClickOpen.MainForm:
          SelectOpenMainForm.Select();
          break;
        case TrayIconClickOpen.NavigationForm:
          SelectOpenNavigationForm.Select();
          break;
      }
      EditRemindShabat_ValueChanged(null, null);
      EditTimerEnabled_CheckedChanged(null, null);
      ActiveControl = EditShabatDay;
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( DoReset ) return;
      NavigationForm.Instance.Hide();
      try
      {
        var v1 = (float)XmlConvert.ToDouble(EditGPSLatitude.Text);
        var v2 = (float)XmlConvert.ToDouble(EditGPSLongitude.Text);
      }
      catch
      {
        DisplayManager.ShowError("Invalid GPS coordonates.");
        e.Cancel = true;
        return;
      }
      if ( SelectOpenMainForm.Checked )
        Program.Settings.TrayIconClickOpen = TrayIconClickOpen.MainForm;
      else
      if ( SelectOpenNavigationForm.Checked )
        Program.Settings.TrayIconClickOpen = TrayIconClickOpen.NavigationForm;
      Program.Settings.ShabatDay = (int)( (DayOfWeekItem)EditShabatDay.SelectedItem ).Day;
      Program.Settings.ReminderCelebrationsInterval = (int)EditTimerInterval.Value;
      for ( int index = 0; index < EditEvents.Items.Count; index++ )
        try
        {
          string name = "TorahEventRemind" + ( (TorahEventItem)EditEvents.Items[index] ).Event.ToString();
          Program.Settings[name] = EditEvents.GetItemChecked(index);
        }
        catch
        {
        }
      for ( int index = 0; index < EditEventsDay.Items.Count; index++ )
        try
        {
          string name = "TorahEventRemindDay" + ( (TorahEventItem)EditEventsDay.Items[index] ).Event.ToString();
          Program.Settings[name] = EditEventsDay.GetItemChecked(index);
        }
        catch
        {
        }
      Program.Settings.BalloonLoomingDelay = (int)EditLoomingDelay.Value;
      Program.Settings.GPSLatitude = EditGPSLatitude.Text;
      Program.Settings.GPSLongitude = EditGPSLongitude.Text;
      Program.Settings.BalloonEnabled = EditBalloon.Checked;
      Program.Settings.BalloonAutoHide = EditBalloonAutoHide.Checked;
      Program.Settings.ShowReminderInTaskBar = EditShowReminderInTaskBar.Checked;
      Program.Settings.FontSize = (int)EditFontSize.Value;
      Program.Settings.ReminderCelebrationsEnabled = EditTimerEnabled.Checked;
      Program.Settings.StartupHide = EditStartupHide.Checked;
      Program.Settings.MonthViewSunToolTips = EditShowMonthDayToolTip.Checked;
      Program.Settings.CheckUpdateAtStartup = EditCheckUpdateAtStartup.Checked;
      Program.Settings.TorahEventsCountAsMoon = EditUseMoonDays.Checked;
      Program.Settings.ReminderShabatEnabled = EditRemindShabat.Checked;
      Program.Settings.RemindShabatOnlyLight = EditRemindShabatOnlyLight.Checked;
      Program.Settings.ReminderCelebrationsInterval = EditTimerInterval.Value;
      Program.Settings.RemindShabatHoursBefore = EditRemindShabatHoursBefore.Value;
      Program.Settings.RemindShabatEveryMinutes = EditRemindShabatEveryMinutes.Value;
      Program.Settings.RemindCelebrationHoursBefore = EditRemindCelebrationHoursBefore.Value;
      Program.Settings.RemindCelebrationEveryMinutes = EditRemindCelebrationEveryMinutes.Value;
      Program.Settings.NavigateTopColor = PanelTopColor.BackColor;
      Program.Settings.NavigateMiddleColor = PanelMiddleColor.BackColor;
      Program.Settings.NavigateBottomColor = PanelBottomColor.BackColor;
      Program.Settings.TextColor = PanelTextColor.BackColor;
      Program.Settings.TextBackground = PanelBackColor.BackColor;
      Program.Settings.CurrentDayForeColor = PanelCurrentDayColor.BackColor;
      Program.Settings.CurrentDayBackColor = PanelCurrentDayBackColor.BackColor;
      Program.Settings.CalendarColorTorahEvent = PanelTorahEventColor.BackColor;
      Program.Settings.CalendarColorSeason = PanelSeasonEventColor.BackColor;
      Program.Settings.CalendarColorMoon = PanelMoonEventColor.BackColor;
      Program.Settings.CalendarColorFullMoon = PanelFullMoonColor.BackColor;
      Program.Settings.EventColorTorah = PanelEventColorTorah.BackColor;
      Program.Settings.EventColorSeason = PanelEventColorSeason.BackColor;
      Program.Settings.EventColorShabat = PanelEventColorShabat.BackColor;
      Program.Settings.EventColorMonth = PanelEventColorNewMonth.BackColor;
      Program.Settings.EventColorNext = PanelEventColorNext.BackColor;
      Program.Settings.UseColors = EditReminderUseColors.Checked;
      Program.Settings.Store();
    }

    private void ActionResetSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(Translations.ResetPreferences.GetLang()) ) return;
      string country = Program.Settings.GPSCountry;
      string city = Program.Settings.GPSCity;
      string lat = Program.Settings.GPSLatitude;
      string lng = Program.Settings.GPSLongitude;
      int shabat = EditShabatDay.SelectedIndex;
      Program.Settings.Reset();
      Program.Settings.UpgradeResetRequiredV3_6 = false;
      DoReset = true;
      Reseted = true;
      Program.Settings.GPSCountry = country;
      Program.Settings.GPSCity = city;
      Program.Settings.GPSLatitude = lat;
      Program.Settings.GPSLongitude = lng;
      Program.Settings.ShabatDay = shabat;
      Program.Settings.RestoreMainForm();
      Program.Settings.Language = Localizer.Language;
      Close();
    }

    private void EditBalloon_CheckedChanged(object sender, EventArgs e)
    {
      EditBalloonAutoHide.Enabled = EditBalloon.Checked;
      LabelLoomingDelay.Enabled = EditBalloon.Checked;
      EditLoomingDelay.Enabled = EditBalloon.Checked;
    }

    private void ActionGetGPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      var form = new SelectCityForm();
      if ( form.ShowDialog() != DialogResult.OK ) return;
      EditGPSLatitude.Text = form.Latitude;
      EditGPSLongitude.Text = form.Longitude;
      LabelCountryCity.Text = Program.Settings.GPSCountry + ", " + Program.Settings.GPSCity;
      Program.Settings.GPSLatitude = form.Latitude;
      Program.Settings.GPSLongitude = form.Longitude;
      Program.Settings.GPSCountry = form.Country;
      Program.Settings.GPSCity = form.City;
      Program.Settings.Save();
      if ( form.EditTimeZone.SelectedItem != null )
      {
        Program.Settings.TimeZone = ( (TimeZoneInfo)form.EditTimeZone.SelectedItem ).Id;
        LabelCountryCity.Text += ", " + ( (TimeZoneInfo)form.EditTimeZone.SelectedItem ).DisplayName;
      }
    }

    /// <summary>
    /// Event handler. Called by ActionUsePersonalShabat for click event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionUsePersonalShabat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(Translations.PersonalShabatNotice.GetLang()) ) return;
      DateTime date = DateTime.Now;
      var formDate = new SelectDayForm();
      formDate.Text = Translations.SelectBirthday.GetLang();
      if ( formDate.ShowDialog() != DialogResult.OK ) return;
      date = formDate.MonthCalendar.SelectionStart.Date;
      var formTime = new SelectBirthTime();
      if ( formTime.ShowDialog() != DialogResult.OK ) return;
      var ephemeris = AstronomyUtility.GetSunMoonEphemeris(date);
      var time = formTime.EditTime.Value.TimeOfDay;
      if ( time >= new TimeSpan(0, 0, 0) && time < ephemeris.Sunset )
        date = date.AddDays(-1);
      Program.Settings.ShabatDay = (int)date.DayOfWeek;
      foreach ( DayOfWeekItem day in EditShabatDay.Items )
        if ( (DayOfWeek)Program.Settings.ShabatDay == day.Day )
          EditShabatDay.SelectedItem = day;
    }

    /// <summary>
    /// Event handler. Called by EditFontName and editFontSize for changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void EitFontName_Changed(object sender, EventArgs e)
    {
      Program.Settings.FontName = EditFontName.Text;
      MainForm.Instance.UpdateTextCalendar();
    }

    /// <summary>
    /// Event handler. Called by PanelBackColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PanelBackColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = PanelBackColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelBackColor.BackColor = DialogColor.Color;
      MainForm.Instance.CalendarText.BackColor = DialogColor.Color;
    }

    /// <summary>
    /// Event handler. Called by PanelTextColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PanelTextColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = PanelTextColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelTextColor.BackColor = DialogColor.Color;
      MainForm.Instance.CalendarText.ForeColor = DialogColor.Color;
    }

    /// <summary>
    /// Event handler. Called by PanelTopColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PanelTopColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = PanelTopColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelTopColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelTop.BackColor = PanelTopColor.BackColor;
    }

    /// <summary>
    /// Event handler. Called by PanelMiddleColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PanelMiddleColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = PanelMiddleColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelMiddleColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelMiddle.BackColor = PanelMiddleColor.BackColor;
    }

    /// <summary>
    /// Event handler. Called by PanelBottomColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PanelBottomColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = PanelBottomColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelBottomColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelBottom.BackColor = PanelBottomColor.BackColor;
    }

    private void PanelEventColorShabat_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = PanelEventColorShabat.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelEventColorShabat.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelEventColorNext_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = PanelEventColorNext.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelEventColorNext.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelEventColorNewMonth_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = PanelEventColorNewMonth.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelEventColorNewMonth.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelEventColorSeason_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = PanelEventColorSeason.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelEventColorSeason.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelEventColorTorah_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = PanelEventColorTorah.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelEventColorTorah.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    /// <summary>
    /// Event handler. Called by ActionUseSystemColors for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionUseSystemColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( NavigationForm.Instance != null )
        NavigationForm.Instance.Show();
      PanelTopColor.BackColor = SystemColors.Control;
      PanelMiddleColor.BackColor = SystemColors.Control;
      PanelBottomColor.BackColor = SystemColors.Control;
      NavigationForm.Instance.PanelTop.BackColor = PanelTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = PanelMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = PanelBottomColor.BackColor;
    }

    /// <summary>
    /// Event handler. Called by ActionUseBlackAndWhiteColors for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionUseBlackAndWhiteColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      NavigationForm.Instance.Show();
      PanelTopColor.BackColor = Color.White;
      PanelMiddleColor.BackColor = Color.Gainsboro;
      PanelBottomColor.BackColor = Color.White;
      NavigationForm.Instance.PanelTop.BackColor = PanelTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = PanelMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = PanelBottomColor.BackColor;
    }

    /// <summary>
    /// Event handler. Called by ActionUseDefaultColors for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionUseDefaultColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      NavigationForm.Instance.Show();
      PanelTopColor.BackColor = Color.LemonChiffon;
      PanelMiddleColor.BackColor = Color.AliceBlue;
      PanelBottomColor.BackColor = Color.Honeydew;
      NavigationForm.Instance.PanelTop.BackColor = PanelTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = PanelMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = PanelBottomColor.BackColor;
    }

    private void UpdateCalendarMonth()
    {
      PreferencesForm_FormClosing(null, null);
      MainForm.Instance.IsGenerating = true;
      Cursor = Cursors.WaitCursor;
      MainForm.Instance.Cursor = Cursors.WaitCursor;
      Enabled = false;
      MainForm.Instance.PanelViewMonth.Parent = null;
      try
      {
        MainForm.Instance.CalendarMonth.CurrentDayForeColor = PanelCurrentDayColor.BackColor;
        MainForm.Instance.CalendarMonth.CurrentDayBackColor = PanelCurrentDayBackColor.BackColor;
        MainForm.Instance.CalendarMonth.LoadPresetHolidays = false;
        MainForm.Instance.FillMonths();
      }
      finally
      {
        Enabled = true;
        Cursor = Cursors.Default;
        MainForm.Instance.Cursor = Cursors.Default;
        MainForm.Instance.IsGenerating = false;
        MainForm.Instance.SetView(Program.Settings.CurrentView, true);
        MainForm.Instance.UpdateButtons();
      }
    }

    /// <summary>
    /// Event handler. Called by PanelCurrentDayColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PanelCurrentDayColor_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = PanelCurrentDayColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelCurrentDayColor.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelCurrentDayBackColor_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = PanelCurrentDayBackColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelCurrentDayBackColor.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelTorahEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = PanelTorahEventColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelTorahEventColor.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelSeasonEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = PanelSeasonEventColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelSeasonEventColor.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelMoonEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = PanelMoonEventColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelMoonEventColor.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void PanelFullMoonColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = PanelFullMoonColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelFullMoonColor.BackColor = DialogColor.Color;
      UpdateCalendarMonth();
    }

    private void ActionRestoreCalendarColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      PanelCurrentDayColor.BackColor = Color.Red;
      PanelTorahEventColor.BackColor = Color.DarkRed;
      PanelSeasonEventColor.BackColor = Color.DarkGreen;
      PanelMoonEventColor.BackColor = Color.DarkBlue;
      PanelFullMoonColor.BackColor = Color.FromArgb(150, 100, 0);
      UpdateCalendarMonth();
    }

    private void EditRemindShabat_ValueChanged(object sender, EventArgs e)
    {
      EditRemindShabatOnlyLight.Enabled = EditRemindShabat.Checked;
      LabelRemindShabatHoursBefore.Enabled = EditRemindShabat.Checked;
      EditRemindShabatHoursBefore.Enabled = EditRemindShabat.Checked;
      LabelRemindShabatEveryMinutes.Enabled = EditRemindShabat.Checked;
      EditRemindShabatEveryMinutes.Enabled = EditRemindShabat.Checked;
    }

    private void EditTimerEnabled_CheckedChanged(object sender, EventArgs e)
    {
      LabelTimerInterval.Enabled = EditTimerEnabled.Checked;
      EditTimerInterval.Enabled = EditTimerEnabled.Checked;
      EditEvents.Enabled = EditTimerEnabled.Checked;
      LabelRemindCelebrationHoursBefore.Enabled = EditTimerEnabled.Checked;
      EditRemindCelebrationHoursBefore.Enabled = EditTimerEnabled.Checked;
      LabelRemindCelebrationEveryMinutes.Enabled = EditTimerEnabled.Checked;
      EditRemindCelebrationEveryMinutes.Enabled = EditTimerEnabled.Checked;
    }

    /// <summary>
    /// Loads the days.
    /// </summary>
    private void LoadDays()
    {
      foreach ( DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)) )
      {
        var item = new DayOfWeekItem() { Text = Translations.DayOfWeek.GetLang(day), Day = day };
        EditShabatDay.Items.Add(item);
        if ( (DayOfWeek)Program.Settings.ShabatDay == day )
          EditShabatDay.SelectedItem = item;
      }
    }

    /// <summary>
    /// Loads the events.
    /// </summary>
    private void LoadEvents()
    {
      foreach ( TorahEventType type in Enum.GetValues(typeof(TorahEventType)) )
        if ( type != TorahEventType.None )
          try
          {
            var item = new TorahEventItem() { Text = Translations.TorahEvent.GetLang(type), Event = type };
            int index = EditEvents.Items.Add(item);
            if ( (bool)Program.Settings["TorahEventRemind" + type.ToString()] )
              EditEvents.SetItemChecked(index, true);
            index = EditEventsDay.Items.Add(item);
            if ( (bool)Program.Settings["TorahEventRemindDay" + type.ToString()] )
              EditEventsDay.SetItemChecked(index, true);
          }
          catch
          {
          }
    }

    /// <summary>
    /// Loads the fonts.
    /// <remarks>
    /// Tips taken from http://stackoverflow.com/questions/224865/how-do-i-get-all-installed-fixed-width-fonts/225027
    /// </remarks>
    /// </summary>
    private void LoadFonts()
    {
      EditFontName.Size = new Size(150, EditFontName.Size.Height);
      foreach ( var item in new InstalledFontCollection().Families )
        if ( item.Name == "Bitstream Vera Sans Mono" || item.Name == "Droid Sans Mono" )
          EditFontName.Items.Add(item.Name);
        else
        if ( item.IsStyleAvailable(FontStyle.Regular) && !item.Name.StartsWith("Webdings") )
          using ( var font = new Font(item, 10) )
          {
            float delta = TextRenderer.MeasureText("|" + MainForm.Instance.MoonNewText + "ABCDE", font).Width
                        - TextRenderer.MeasureText("|" + " abcde", font).Width;
            if ( Math.Abs(delta) < float.Epsilon * 2 )
              EditFontName.Items.Add(item.Name);
          }
    }

    private void UpdateLanguagesButtons()
    {
      MainForm.Instance.CalendarMonth._btnToday.ButtonText = Translations.Today.GetLang();
      if ( Program.Settings.Language == "en" )
      {
        ActionSelectLangEN.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangFR.BackColor = SystemColors.Control;
      }
      if ( Program.Settings.Language == "fr" )
      {
        ActionSelectLangFR.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangEN.BackColor = SystemColors.Control;
      }
    }

    private void ActionSelectLangEN_Click(object sender, EventArgs e)
    {
      Program.Settings.Language = "en";
      Program.ApplyCurrentLanguage();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      Close();
    }

    private void ActionSelectLangFR_Click(object sender, EventArgs e)
    {
      Program.Settings.Language = "fr";
      Program.ApplyCurrentLanguage();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      Close();
    }

    /// <summary>
    /// provide day of week item.
    /// </summary>
    private class DayOfWeekItem
    {

      /// <summary>
      /// Indicate the text of the day.
      /// </summary>
      public string Text { get; set; }

      /// <summary>
      /// Indicate the day of week enum value.
      /// </summary>
      public DayOfWeek Day { get; set; }

      /// <summary>
      /// Return a <see cref="T:System.String" /> that represents the day.
      /// </summary>
      public override string ToString() { return Text; }

    }

  }

}
