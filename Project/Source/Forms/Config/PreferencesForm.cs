/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm : Form
  {

    private bool IsReady;
    public int OldShabatDay { get; private set; }
    public string OldLatitude { get; private set; }
    public string OldLongitude { get; private set; }
    public string OldTimeZone { get; private set; }
    public bool OldUseMoonDays { get; private set; }
    public bool MustRefreshMonthView { get; private set; }

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
      EditMaxYearsInterval.Minimum = Program.GenerateIntervalMaximumLow;
      EditMaxYearsInterval.Maximum = Program.GenerateIntervalMaximumHigh;
      EditReminderCelebrationsInterval.Minimum = RemindCelebrationBeforeMin;
      EditReminderCelebrationsInterval.Maximum = RemindCelebrationBeforeMax;
      EditReminderCelebrationsInterval.Value = RemindCelebrationBeforeValue;
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
      EditAutoLockSessionTimeOut.Minimum = RemindAutoLockTimeOutMin;
      EditAutoLockSessionTimeOut.Maximum = RemindAutoLockTimeOutMax;
      EditAutoLockSessionTimeOut.Value = RemindAutoLockTimeOutValue;
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_Load(object sender, EventArgs e)
    {
      this.CenterToMainFormElseScreen();
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_Shown(object sender, EventArgs e)
    {
      TopMost = MainForm.Instance.TopMost;
      BringToFront();
      DoFormShown(sender, e);
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( e.CloseReason != CloseReason.None && e.CloseReason != CloseReason.UserClosing ) return;
      DoFormClosing(sender, e);
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
      foreach ( TorahEvent type in Enum.GetValues(typeof(TorahEvent)) )
        if ( type != TorahEvent.None )
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
    /// From http://stackoverflow.com/questions/224865/how-do-i-get-all-installed-fixed-width-fonts/225027
    /// </remarks>
    /// </summary>
    private void LoadFonts()
    {
      string[] list = { "Bitstream Vera Sans Mono", "Consolas", "Courier New", "Droid Sans Mono", "Lucida Console" };
      foreach ( var item in new InstalledFontCollection().Families.OrderBy(f => f.Name) )
        if ( list.Contains(item.Name) )
          EditFontName.Items.Add(item.Name);
      /*// Removed because MeasureText is very slow on Windows 10
        foreach ( var item in new InstalledFontCollection().Families )
        if ( item.Name == "Bitstream Vera Sans Mono" || item.Name == "Droid Sans Mono" )
          EditFontName.Items.Add(item.Name);
        else
        if ( item.IsStyleAvailable(FontStyle.Regular) && !item.Name.StartsWith("Webdings") )
          using ( var font = new Font(item, 10) )
          {
            float delta = 0;// TextRenderer.MeasureText("|" + MainForm.Instance.MoonNewText + "ABCDE", font).Width
                            //- TextRenderer.MeasureText("|" + " abcde", font).Width;
            if ( Math.Abs(delta) < float.Epsilon * 2 )
              EditFontName.Items.Add(item.Name);
          }*/
    }

    private void ActionResetSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(Translations.AskToResetPreferences.GetLang()) ) return;
      MainForm.Instance.MenuShowHide_Click(null, null);
      MoonMonthsForm.Instance.Hide();
      StatisticsForm.Instance.Hide();
      string country = Program.Settings.GPSCountry;
      string city = Program.Settings.GPSCity;
      string lat = Program.Settings.GPSLatitude;
      string lng = Program.Settings.GPSLongitude;
      string timezone = Program.Settings.TimeZone;
      var bookmark1 = Program.Settings.DateBookmark1;
      var bookmark2 = Program.Settings.DateBookmark2;
      var bookmark3 = Program.Settings.DateBookmark3;
      var bookmark4 = Program.Settings.DateBookmark4;
      var bookmark5 = Program.Settings.DateBookmark5;
      int shabat = EditShabatDay.SelectedIndex;
      Program.Settings.Reset();
      Program.Settings.UpgradeResetRequiredV3_0 = false;
      Program.Settings.UpgradeResetRequiredV3_6 = false;
      Program.Settings.UpgradeResetRequiredV4_1 = false;
      Program.Settings.FirstLaunchV4 = false;
      Program.Settings.Save();
      DoReset = true;
      Reseted = true;
      Program.Settings.GPSCountry = country;
      Program.Settings.GPSCity = city;
      Program.Settings.GPSLatitude = lat;
      Program.Settings.GPSLongitude = lng;
      Program.Settings.TimeZone = timezone;
      Program.Settings.ShabatDay = shabat;
      Program.Settings.RestoreMainForm();
      Program.Settings.Language = Languages.Current;
      Program.Settings.DateBookmark1 = bookmark1;
      Program.Settings.DateBookmark2 = bookmark2;
      Program.Settings.DateBookmark3 = bookmark3;
      Program.Settings.DateBookmark4 = bookmark4;
      Program.Settings.DateBookmark5 = bookmark5;
      Close();
    }

    private void ActionGetGPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      var form = new SelectCityForm();
      if ( form.ShowDialog() != DialogResult.OK ) return;
      EditGPSLatitude.Text = form.Latitude;
      EditGPSLongitude.Text = form.Longitude;
      Program.Settings.GPSLatitude = form.Latitude;
      Program.Settings.GPSLongitude = form.Longitude;
      Program.Settings.GPSCountry = form.Country;
      Program.Settings.GPSCity = form.City;
      Program.Settings.Save();
      if ( form.EditTimeZone.SelectedItem != null )
        Program.Settings.TimeZone = ( (TimeZoneInfo)form.EditTimeZone.SelectedItem ).Id;
      EditTimeZone.Text = Program.GPSText;
      MainForm.Instance.InitializeCurrentTimeZone();
    }

    private void ActionPersonalShabatHelp_Click(object sender, EventArgs e)
    {
      Program.ShabatNoticeForm.ShowDialog();
    }

    private void ActionCountAsMoonHelp_Click(object sender, EventArgs e)
    {
      Program.CelebrationsNoticeForm.ShowDialog();
    }

    private void ActionUsePersonalShabat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      DateTime date = DateTime.Today;
      var formDate = new SelectDayForm();
      formDate.Text = Translations.SelectBirthday.GetLang();
      if ( formDate.ShowDialog() != DialogResult.OK ) return;
      date = formDate.MonthCalendar.SelectionStart.Date;
      var formTime = new SelectBirthTime();
      if ( formTime.ShowDialog() != DialogResult.OK ) return;
      var time = formTime.EditTime.Value.TimeOfDay;
      if ( time >= new TimeSpan(0, 0, 0) && time < Dates.Get(date).Ephemerisis.Sunset )
        date = date.AddDays(-1);
      Program.Settings.ShabatDay = (int)date.DayOfWeek;
      foreach ( DayOfWeekItem day in EditShabatDay.Items )
        if ( (DayOfWeek)Program.Settings.ShabatDay == day.Day )
          EditShabatDay.SelectedItem = day;
    }

    private void ActionSelectLangEN_Click(object sender, EventArgs e)
    {
      if ( Program.Settings.Language == Languages.EN ) return;
      Program.Settings.Language = Languages.EN;
      Program.UpdateLocalization();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      Close();
    }

    private void ActionSelectLangFR_Click(object sender, EventArgs e)
    {
      if ( Program.Settings.Language == Languages.FR ) return;
      Program.Settings.Language = Languages.FR;
      Program.UpdateLocalization();
      UpdateLanguagesButtons();
      LanguageChanged = true;
      Close();
    }

    private void UpdateLanguagesButtons()
    {
      MainForm.Instance.CalendarMonth._btnToday.ButtonText = Translations.Today.GetLang();
      if ( Program.Settings.Language == Languages.EN )
      {
        ActionSelectLangEN.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangFR.BackColor = SystemColors.Control;
      }
      if ( Program.Settings.Language == Languages.FR )
      {
        ActionSelectLangFR.BackColor = SystemColors.ControlLightLight;
        ActionSelectLangEN.BackColor = SystemColors.Control;
      }
    }

    private void ActionMoonDayTextFormatHelp_Click(object sender, EventArgs e)
    {
      DisplayManager.ShowInformation(Translations.NoticeMoonDayTextFormat.GetLang());
    }

    private void ActionMoonDayTextFormatReset_Click(object sender, EventArgs e)
    {
      MenuSelectMoonDayTextFormat.Show(ActionMoonDayTextFormatReset, new Point(0, ActionMoonDayTextFormatReset.Height));
    }

    private void MenuSelectMoonDayTextFormat_Click(object sender, EventArgs e)
    {
      EditMoonDayTextFormat.Text = (string)( sender as ToolStripMenuItem ).Tag;
    }

    private void EditMoonDayTextFormat_TextChanged(object sender, EventArgs e)
    {
      if ( IsReady ) MustRefreshMonthView = true;
    }

    private void EitReportFont_Changed(object sender, EventArgs e)
    {
      if ( !IsReady ) return;
      Program.Settings.FontName = EditFontName.Text;
      Program.Settings.FontSize = (int)EditFontSize.Value;
      MainForm.Instance.UpdateTextCalendar();
    }

    private void EditDebuggerEnabled_CheckedChanged(object sender, EventArgs e)
    {
      Debugger.Active = EditDebuggerEnabled.Checked;
    }

    private void EditRemindAutoLock_CheckedChanged(object sender, EventArgs e)
    {
      LabelRemindAutoLockTimeOut.Enabled = EditAutoLockSession.Checked;
      EditAutoLockSessionTimeOut.Enabled = EditAutoLockSession.Checked;
    }

    private void EditRemindShabat_ValueChanged(object sender, EventArgs e)
    {
      EditRemindShabatOnlyLight.Enabled = EditReminderShabatEnabled.Checked;
      LabelRemindShabatHoursBefore.Enabled = EditReminderShabatEnabled.Checked;
      EditRemindShabatHoursBefore.Enabled = EditReminderShabatEnabled.Checked;
      LabelRemindShabatEveryMinutes.Enabled = EditReminderShabatEnabled.Checked;
      EditRemindShabatEveryMinutes.Enabled = EditReminderShabatEnabled.Checked;
    }

    private void EditTimerEnabled_CheckedChanged(object sender, EventArgs e)
    {
      LabelTimerInterval.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditReminderCelebrationsInterval.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditEvents.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditEventsDay.Enabled = EditReminderCelebrationsEnabled.Checked;
      LabelRemindCelebrationHoursBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditRemindCelebrationHoursBefore.Enabled = EditReminderCelebrationsEnabled.Checked;
      LabelRemindCelebrationEveryMinutes.Enabled = EditReminderCelebrationsEnabled.Checked;
      EditRemindCelebrationEveryMinutes.Enabled = EditReminderCelebrationsEnabled.Checked;
    }

    private void EditBalloon_CheckedChanged(object sender, EventArgs e)
    {
      EditBalloonAutoHide.Enabled = EditBalloon.Checked;
      LabelLoomingDelay.Enabled = EditBalloon.Checked;
      EditBalloonLoomingDelay.Enabled = EditBalloon.Checked;
    }

    private void ActionUseSystemColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( NavigationForm.Instance != null )
        NavigationForm.Instance.Show();
      EditNavigateTopColor.BackColor = SystemColors.Control;
      EditNavigateMiddleColor.BackColor = SystemColors.Control;
      EditNavigateBottomColor.BackColor = SystemColors.Control;
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    }

    private void ActionUseBlackAndWhiteColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      NavigationForm.Instance.Show();
      EditNavigateTopColor.BackColor = Color.White;
      EditNavigateMiddleColor.BackColor = Color.Gainsboro;
      EditNavigateBottomColor.BackColor = Color.White;
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    }

    private void ActionUseDefaultColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      NavigationForm.Instance.Show();
      EditNavigateTopColor.BackColor = Color.LemonChiffon;
      EditNavigateMiddleColor.BackColor = Color.AliceBlue;
      EditNavigateBottomColor.BackColor = Color.Honeydew;
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    }

    private void ActionMonthViewThemeLight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      EditCurrentDayForeColor.BackColor = Color.White;
      EditCurrentDayBackColor.BackColor = Color.FromArgb(200, 0, 0);
      EditCalendarColorTorahEvent.BackColor = Color.DarkRed;
      EditCalendarColorSeason.BackColor = Color.DarkGreen;
      EditCalendarColorMoon.BackColor = Color.DarkBlue;
      EditCalendarColorFullMoon.BackColor = Color.FromArgb(150, 100, 0);
      EditEventColorTorah.BackColor = Color.FromArgb(255, 255, 230);
      EditEventColorSeason.BackColor = Color.FromArgb(245, 255, 240);
      EditEventColorShabat.BackColor = Color.FromArgb(243, 243, 243);
      EditEventColorMonth.BackColor = Color.AliceBlue;
      EditEventColorNext.BackColor = Color.WhiteSmoke;
      EditCalendarColorEmpty.BackColor = Color.White;
      EditCalendarColorDefaultText.BackColor = Color.Black;
      EditCalendarColorNoDay.BackColor = Color.FromArgb(250, 250, 250);
      MustRefreshMonthView = true;
    }

    private void ActionMonthViewThemeDark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      EditCurrentDayForeColor.BackColor = Color.Black;
      EditCurrentDayBackColor.BackColor = Color.White;
      EditCalendarColorTorahEvent.BackColor = Color.Red;
      EditCalendarColorSeason.BackColor = Color.LightGreen;
      EditCalendarColorMoon.BackColor = Color.LightBlue;
      EditCalendarColorFullMoon.BackColor = Color.FromArgb(150, 100, 0);
      EditEventColorTorah.BackColor = Color.Red;
      EditEventColorSeason.BackColor = Color.LightGreen;
      EditEventColorShabat.BackColor = Color.LightGray;
      EditEventColorMonth.BackColor = Color.LightBlue;
      EditEventColorNext.BackColor = Color.WhiteSmoke;
      EditCalendarColorEmpty.BackColor = Color.Black;
      EditCalendarColorDefaultText.BackColor = Color.White;
      EditCalendarColorNoDay.BackColor = Color.FromArgb(50, 50, 50);
      MustRefreshMonthView = true;
    }

    private void PanelTextColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditTextColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditTextColor.BackColor = DialogColor.Color;
      MainForm.Instance.CalendarText.ForeColor = DialogColor.Color;
    }

    private void PanelBackColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditTextBackground.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditTextBackground.BackColor = DialogColor.Color;
      MainForm.Instance.CalendarText.BackColor = DialogColor.Color;
    }

    private void PanelTopColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = EditNavigateTopColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditNavigateTopColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
    }

    private void PanelMiddleColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = EditNavigateMiddleColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditNavigateMiddleColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
    }

    private void PanelBottomColor_MouseClick(object sender, MouseEventArgs e)
    {
      NavigationForm.Instance.Show();
      DialogColor.Color = EditNavigateBottomColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditNavigateBottomColor.BackColor = DialogColor.Color;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    }

    private void PanelEventColorTorah_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorTorah.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorTorah.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelEventColorSeason_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorSeason.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorSeason.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelEventColorShabat_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorShabat.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorShabat.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelEventColorNewMonth_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorMonth.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorMonth.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelEventColorNext_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditEventColorNext.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditEventColorNext.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelCurrentDayColor_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCurrentDayForeColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCurrentDayForeColor.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelCurrentDayBackColor_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCurrentDayBackColor.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCurrentDayBackColor.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelTorahEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditCalendarColorTorahEvent.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorTorahEvent.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelSeasonEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditCalendarColorSeason.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorSeason.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelMoonEventColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditCalendarColorMoon.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorMoon.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void PanelFullMoonColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = EditCalendarColorFullMoon.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorFullMoon.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void EditCalendarColorEmpty_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCalendarColorEmpty.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorEmpty.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void EditCalendarColorDefaultText_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCalendarColorDefaultText.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorDefaultText.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void EditCalendarColorNoDay_MouseClick(object sender, MouseEventArgs e)
    {
      DialogColor.Color = EditCalendarColorNoDay.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      EditCalendarColorNoDay.BackColor = DialogColor.Color;
      MustRefreshMonthView = true;
    }

    private void EditMonthViewSunToolTips_CheckedChanged(object sender, EventArgs e)
    {
      MustRefreshMonthView = true;
    }

    private void EditUseColors_CheckedChanged(object sender, EventArgs e)
    {
      MustRefreshMonthView = true;
    }
    private void EditMonthViewFontSize_ValueChanged(object sender, EventArgs e)
    {
      MustRefreshMonthView = EditMonthViewFontSize.Value != Program.Settings.MonthViewFontSize;
    }

    private void ActionSelectHebrewLettersPath_Click(object sender, EventArgs e)
    {
      try { OpenFileDialog.InitialDirectory = Path.GetDirectoryName(EditHebrewLettersPath.Text); }
      catch { }
      try { OpenFileDialog.FileName = Path.GetFileName(EditHebrewLettersPath.Text); }
      catch { }
      if ( OpenFileDialog.ShowDialog() == DialogResult.OK )
        EditHebrewLettersPath.Text = OpenFileDialog.FileName;
    }

    private void SelectOpenNavigationForm_CheckedChanged(object sender, EventArgs e)
    {
      EditBalloon.Enabled = !SelectOpenNavigationForm.Checked;
      EditBalloonAutoHide.Enabled = EditBalloon.Enabled;
      LabelLoomingDelay.Enabled = EditBalloon.Enabled;
      EditBalloonLoomingDelay.Enabled = EditBalloon.Enabled;
    }

  }

}
