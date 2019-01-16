/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2019-01 </edited>
using System;
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

    public int OldShabatDay;
    public float OldLatitude;
    public float OldLongitude;

    /// <summary>
    /// Default constructor.
    /// </summary>
    private PreferencesForm()
    {
      InitializeComponent();
      LoadFonts();
      LoadDays();
      bindingSettings.DataSource = Program.Settings;
  }

  /// <summary>
  /// Event handler. Called by PreferencesForm for shown events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void PreferencesForm_Shown(object sender, EventArgs e)
    {
      TopMost = MainForm.TopMost;
      OldShabatDay = Program.Settings.ShabatDay;
      OldLatitude = Program.Settings.Latitude;
      OldLongitude = Program.Settings.Longitude;
    }

    /// <summary>
    /// Event handler. Called by PreferencesForm for closing events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Program.Settings.ShabatDay = (int)( (DayOfWeekItem)editShabatDay.SelectedItem ).Day;
      Program.Settings.Save();
    }

    /// <summary>
    /// Event handler. Called by editFontName and editFontSize for changed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void editFont_Changed(object sender, EventArgs e)
    {
      var control = sender as Control;
      if ( control == null ) return;
      control.DataBindings.WriteValues();
      MainForm.UpdateTextCalendar();
    }

    /// <summary>
    /// Event handler. Called by panelBackColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void panelBackColor_Click(object sender, EventArgs e)
    {
      dialogColor.Color = panelBackColor.BackColor;
      if ( dialogColor.ShowDialog() == DialogResult.Cancel ) return;
      panelBackColor.BackColor = dialogColor.Color;
      MainForm.calendarText.BackColor = dialogColor.Color;
    }

    /// <summary>
    /// Event handler. Called by panelTextColor for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void panelTextColor_Click(object sender, EventArgs e)
    {
      dialogColor.Color = panelTextColor.BackColor;
      if ( dialogColor.ShowDialog() == DialogResult.Cancel ) return;
      panelTextColor.BackColor = dialogColor.Color;
      MainForm.calendarText.ForeColor = dialogColor.Color;
    }

    /// <summary>
    /// Event handler. Called by actionUsePersonalShabat for click event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void actionUsePersonalShabat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      DateTime date = DateTime.Now;
      var form = new SelectDayForm();
      form.Text = "Select birthday";
      form.ShowDialog();
      date = form.monthCalendar.SelectionStart;
      Program.Settings.ShabatDay = (int)date.AddDays(-1).DayOfWeek;
      foreach ( DayOfWeekItem item in editShabatDay.Items)
      {
        if ( (DayOfWeek)Program.Settings.ShabatDay == item.Day ) editShabatDay.SelectedItem = item;
      }
    }

    /// <summary>
    /// Loads the days.
    /// </summary>
    private void LoadDays()
    {
      foreach ( DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)) )
      {
        var item = new DayOfWeekItem() { Text = LocalizerHelper.DayOfWeekText.GetLang(day), Day = day };
        editShabatDay.Items.Add(item);
        if ( (DayOfWeek)Program.Settings.ShabatDay == day ) editShabatDay.SelectedItem = item;
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
      editFontName.Size = new Size(150, editFontName.Size.Height);
      foreach ( var item in new InstalledFontCollection().Families )
        if ( item.Name == "Bitstream Vera Sans Mono" || item.Name == "Droid Sans Mono" )
          editFontName.Items.Add(item.Name);
        else
        if ( item.IsStyleAvailable(FontStyle.Regular) && !item.Name.StartsWith("Webdings") )
          using ( var font = new Font(item, 10) )
          {
            float delta = TextRenderer.MeasureText("|" + MainForm.Instance.MoonNewText + "ABCDE", font).Width
                        - TextRenderer.MeasureText("|" + " abcde", font).Width;
            if ( Math.Abs(delta) < float.Epsilon * 2 )
              editFontName.Items.Add(item.Name);
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

  }

}
