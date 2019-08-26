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
/// <edited> 2019-08 </edited>
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Form for viewing the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class PreferencesForm : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static internal PreferencesForm Instance { get; private set; }

    /// <summary>
    /// Indicate the main form.
    /// </summary>
    static private MainForm MainForm;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static PreferencesForm()
    {
      MainForm = MainForm.Instance;
      Instance = new PreferencesForm();
    }

    public int OldShabatDay { get; private set; }
    public float OldLatitude { get; private set; }
    public float OldLongitude { get; private set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    private PreferencesForm()
    {
      InitializeComponent();
      LoadDays();
      LoadEvents();
      LoadFonts();
      BindingSettings.DataSource = Program.Settings;
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for shown events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_Shown(object sender, EventArgs e)
    {
      OldShabatDay = Program.Settings.ShabatDay;
      OldLatitude = Program.Settings.Latitude;
      OldLongitude = Program.Settings.Longitude;
      switch ( Program.Settings.TrayIconClickOpen )
      {
        case TrayIconClickOpen.MainForm:
          RadioButtonMainForm.Select();
          break;
        case TrayIconClickOpen.NavigationForm:
          RadioButtonNavigationForm.Select();
          break;
      }
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( RadioButtonMainForm.Checked )
        Program.Settings.TrayIconClickOpen = TrayIconClickOpen.MainForm;
      else
      if ( RadioButtonNavigationForm.Checked )
        Program.Settings.TrayIconClickOpen = TrayIconClickOpen.NavigationForm;
      Program.Settings.ShabatDay = (int)( (DayOfWeekItem)EditShabatDay.SelectedItem ).Day;
      Program.Settings.ReminderInterval = (int)EditTimerInterval.Value;
      for ( int index = 0; index < EditEvents.Items.Count; index++ )
        try
        {
          string name = "TorahEventRemind" + ( (TorahEventItem)EditEvents.Items[index] ).Event.ToString();
          Program.Settings[name] = EditEvents.GetItemChecked(index);
        }
        catch
        {
        }
      Program.Settings.Store();
    }

    /// <summary>
    /// Event handler. Called by ActionUsePersonalShabat for click event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionUsePersonalShabat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      DateTime date = DateTime.Now;
      var form = new SelectDayForm();
      form.Text = Localizer.SelectBirthdayText.GetLang();
      if ( form.ShowDialog() == DialogResult.Cancel ) return;
      date = form.MonthCalendar.SelectionStart;
      Program.Settings.ShabatDay = (int)date.AddDays(-1).DayOfWeek;
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
      var control = sender as Control;
      if ( control == null ) return;
      foreach ( Binding binding in control.DataBindings )
        binding.WriteValue();
      MainForm.UpdateTextCalendar();
    }

    /// <summary>
    /// Event handler. Called by PanelBackColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PanelBackColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = PanelBackColor2.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelBackColor2.BackColor = DialogColor.Color;
      MainForm.CalendarText.BackColor = DialogColor.Color;
    }

    /// <summary>
    /// Event handler. Called by PanelTextColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PanelTextColor_Click(object sender, EventArgs e)
    {
      DialogColor.Color = PanelTextColor2.BackColor;
      if ( DialogColor.ShowDialog() == DialogResult.Cancel ) return;
      PanelTextColor2.BackColor = DialogColor.Color;
      MainForm.CalendarText.ForeColor = DialogColor.Color;
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

    /// <summary>
    /// Event handler. Called by ActionUseSystemColors for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionUseSystemColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
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
      Program.Settings.Store();
      MainForm.Instance.IsGenerating = true;
      Cursor = Cursors.WaitCursor;
      MainForm.Instance.Cursor = Cursors.WaitCursor;
      Enabled = false;
      MainForm.Instance.PanelViewMonth.Parent = null;
      try
      {
        MainForm.Instance.CalendarMonth.CurrentDayColor = PanelCurrentDayColor.BackColor;
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
      PanelFullMoonColor.BackColor = Color.DarkGoldenrod;
      UpdateCalendarMonth();
    }

    private void remindShabat_ValueChanged(object sender, EventArgs e)
    {
      if ( sender == EditRemindShabat )
      {
        remindShabatOnlyLightCheckBox.Enabled = EditRemindShabat.Checked;
        LabelRemindShabatHoursBefore.Enabled = EditRemindShabat.Checked;
        remindShabatHoursBeforeNumericUpDown.Enabled = EditRemindShabat.Checked;
        LabelRemindShabatEveryMinutes.Enabled = EditRemindShabat.Checked;
        remindShabatEveryMinutesNumericUpDown.Enabled = EditRemindShabat.Checked;
      }
    }

    private void EditTimerEnabled_CheckedChanged(object sender, EventArgs e)
    {
      LabelTimerInterval.Enabled = EditTimerEnabled.Checked;
      EditTimerInterval.Enabled = EditTimerEnabled.Checked;
      EditEvents.Enabled = EditTimerEnabled.Checked;
    }

    /// <summary>
    /// Loads the days.
    /// </summary>
    private void LoadDays()
    {
      foreach ( DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)) )
      {
        var item = new DayOfWeekItem() { Text = Localizer.DayOfWeekText.GetLang(day), Day = day };
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
            var item = new TorahEventItem() { Text = Localizer.TorahEventText.GetLang(type), Event = type };
            int index = EditEvents.Items.Add(item);
            if ( (bool)Program.Settings["TorahEventRemind" + type.ToString()] )
              EditEvents.SetItemChecked(index, true);
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

    /// <summary>
    /// provide day of week item.
    /// </summary>
    private class TorahEventItem
    {

      /// <summary>
      /// Indicate the text of the day.
      /// </summary>
      public string Text { get; set; }

      /// <summary>
      /// Indicate the day of week enum value.
      /// </summary>
      public TorahEventType Event { get; set; }

      /// <summary>
      /// Return a <see cref="T:System.String" /> that represents the day.
      /// </summary>
      public override string ToString() { return Text; }

    }

  }

}
