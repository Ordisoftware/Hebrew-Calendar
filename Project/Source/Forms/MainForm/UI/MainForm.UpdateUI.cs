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
/// <edited> 2022-02 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.Resources;

/// <summary>
/// The application's main form.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
public partial class MainForm
{

  private bool DoScreenPositionMutex;
  private bool UpdateTitlesMutex;


  private string TitleGPS = "";
  private string TitleOmer = "";
  private string TitleParashah = "";
  private string TitleCelebration = "";

  /// <summary>
  /// Enables double-buffering.
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

  /// <summary>
  /// Centers the form to the screen.
  /// </summary>
  public new void CenterToScreen()
  {
    base.CenterToScreen();
  }

  /// <summary>
  /// Executes the screen location operation.
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
        foreach ( ToolStripMenuItem item in ( (ToolStripMenuItem)menuItem.OwnerItem ).DropDownItems )
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
  /// Updates form title bar and sub-title texts.
  /// </summary>
  private void UpdateTitles(bool force = false)
  {
    if ( !Globals.IsReady || Globals.IsGenerating ) return;
    if ( UpdateTitlesMutex ) return;
    UpdateTitlesMutex = true;
    LunisolarDay today = null;
    try
    {
      Text = Globals.AssemblyTitle;
      SystemManager.TryCatch(() =>
      {
        // Subtitle
        LabelSubTitleCalendar.Text = AppTranslations.Subtitle.GetLang();
        // GPS
        if ( force || TitleGPS.IsNullOrEmpty() )
          if ( !string.IsNullOrEmpty(Settings.GPSCountry) && !string.IsNullOrEmpty(Settings.GPSCity) )
            TitleGPS = $"{Settings.GPSCountry} - {Settings.GPSCity}".ToUpper();
          else
            TitleGPS = "GPS " + SysTranslations.UndefinedSlot.GetLang().ToUpper();
        LabelSubTitleGPS.Text = TitleGPS;
        // Omer
        if ( force || TitleOmer.IsNullOrEmpty() )
          TitleOmer = Settings.UseSodHaibour
                      ? AppTranslations.MainFormSubTitleSod.GetLang().ToUpper()
                      : AppTranslations.MainFormSubTitleOmer[Settings.TorahEventsCountAsMoon].GetLang().ToUpper();
        LabelSubTitleOmer.Text = TitleOmer;
        // Today
        if ( Settings.MainFormTitleBarShowToday )
          Text += " - " + ( ApplicationDatabase.Instance.GetToday()?.DayAndMonthWithYearText
                          ?? SysTranslations.NullSlot.GetLang() );
        // Celebration
        if ( Settings.MainFormTitleBarShowCelebration )
        {
          if ( force || TitleCelebration.IsNullOrEmpty() )
          {
            today = ApplicationDatabase.Instance.GetToday();
            TitleCelebration = today?.GetWeekLongCelebrationIntermediateDay().Text ?? string.Empty;
            if ( !TitleCelebration.IsNullOrEmpty() )
              TitleCelebration = " - " + TitleCelebration;
          }
          Text += TitleCelebration;
        }
        // Parashah
        if ( Settings.CalendarShowParashah && Settings.MainFormTitleBarShowWeeklyParashah )
        {
          if ( force || TitleParashah.IsNullOrEmpty() )
          {
            var weekParashah = ApplicationDatabase.Instance.GetWeeklyParashah();
            if ( weekParashah.Factory is not null )
            {
              if ( MenuTools.DropDownItems.Count > 0 )
                MenuTools.DropDownItems[0].Enabled = true;
              var parashah = weekParashah.Factory;
              if ( today is null ) today = ApplicationDatabase.Instance.GetToday();
              TitleParashah = parashah.ToStringShort(Program.Settings.ParashahCaptionWithBookAndRef,
                                                     today.HasLinkedParashah);
              TitleParashah = $"Parashah {TitleParashah}";
              ActionWeeklyParashah.Text = $"Parashah {parashah.ToStringShort(false, true)}";
              ActionWeeklyParashah.Enabled = true;
            }
            else
            {
              TitleParashah = string.Empty;
              ActionWeeklyParashah.Enabled = false;
              ActionWeeklyParashah.Text = new ResourceManager(GetType()).GetString("ActionWeeklyParashah.Text");
              if ( MenuTools.DropDownItems.Count > 0 )
                MenuTools.DropDownItems[0].Enabled = false;
            }
          }
          if ( !TitleParashah.IsEmpty() ) Text += $" - {TitleParashah/*.ToUpper()*/}";
        }
        ActionWeeklyParashah.Visible = Settings.CalendarShowParashah;
      });
    }
    finally
    {
      UpdateTitlesMutex = false;
    }
  }

  /// <summary>
  /// Updates the text view aspect.
  /// </summary>
  public void UpdateTextCalendar()
  {
    CalendarText.Font = new Font(Settings.FontName, Settings.FontSize);
  }

  /// <summary>
  /// Updates the buttons.
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
  /// Updates the month view.
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

}
