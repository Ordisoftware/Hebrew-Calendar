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
    private string TitleParashah = "";

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
        Text = Globals.AssemblyTitle;
        SystemManager.TryCatch(() =>
        {
          // Subtitle
          LabelSubTitleCalendar.Text = AppTranslations.Subtitle.GetLang();
          // Today
          if ( Settings.MainFormTitleBarShowToday )
            Text += " - " + ( ApplicationDatabase.Instance.GetToday()?.DayAndMonthWithYearText ?? SysTranslations.NullSlot.GetLang() );
          // GPS
          if ( force || TitleGPS.IsNullOrEmpty() )
            if ( !string.IsNullOrEmpty(Settings.GPSCountry) && !string.IsNullOrEmpty(Settings.GPSCity) )
              TitleGPS = $"{Settings.GPSCountry} - {Settings.GPSCity}".ToUpper();
            else
              TitleGPS = "GPS " + SysTranslations.UndefinedSlot.GetLang().ToUpper();
          LabelSubTitleGPS.Text = TitleGPS;
          // Omer
          if ( force || TitleOmer.IsNullOrEmpty() )
            TitleOmer = AppTranslations.MainFormSubTitleOmer[Settings.TorahEventsCountAsMoon].GetLang().ToUpper();
          LabelSubTitleOmer.Text = TitleOmer;
          // Parashah
          if ( Settings.MainFormTitleBarShowWeeklyParashah )
          {
            if ( force || TitleParashah.IsNullOrEmpty() )
            {
              var weekParashah = ApplicationDatabase.Instance.GetWeeklyParashah();
              if ( weekParashah.Factory != null )
              {
                ActionWeeklyParashah.Enabled = true;
                if ( MenuTools.DropDownItems.Count > 0 )
                  MenuTools.DropDownItems[0].Enabled = true;
                TitleParashah = weekParashah.Factory.ToStringShort(Program.Settings.ParashahCaptionWithBookAndRef,
                                                                   weekParashah.Day.HasLinkedParashah);
                TitleParashah = " - Parashah " + TitleParashah.ToUpper();
              }
              else
              {
                TitleParashah = string.Empty;
                ActionWeeklyParashah.Enabled = false;
                if ( MenuTools.DropDownItems.Count > 0 )
                  MenuTools.DropDownItems[0].Enabled = false;
              }
            }
            Text += TitleParashah;
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

  }

}
