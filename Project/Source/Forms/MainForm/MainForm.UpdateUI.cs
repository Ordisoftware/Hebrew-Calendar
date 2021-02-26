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
/// <edited> 2021-01 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
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

    /// <summary>
    /// Bring to front improved.
    /// </summary>
    public new void BringToFront()
    {
      var temp = TopMost;
      TopMost = true;
      base.BringToFront();
      TopMost = temp;
    }

    /// <summary>
    /// Center the form to the screen.
    /// </summary>
    protected internal new void CenterToScreen()
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
        if ( sender != null && sender is ToolStripMenuItem menuItem )
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
    /// Update form title bar and sub-title texts.
    /// </summary>
    private void UpdateTitles()
    {
      Text = Globals.AssemblyTitle;
      new Task(() =>
      {
        string str;
        if ( !string.IsNullOrEmpty(Program.Settings.GPSCountry) && !string.IsNullOrEmpty(Program.Settings.GPSCity) )
        {
          str = $"{Program.Settings.GPSCountry} - {Program.Settings.GPSCity}".ToUpper();
          this.SyncUI(() => LabelSubTitleGPS.Text = str);
        }
        str = AppTranslations.MainFormSubTitleOmer[Settings.TorahEventsCountAsMoon].GetLang().ToUpper();
        this.SyncUI(() => LabelSubTitleOmer.Text = str);
        var parashah = GetWeeklyParashah();
        if ( parashah != null )
        {
          str = Text + " - Parashah " + parashah.ToStringLinked().ToUpper();
          this.SyncUI(() => Text = str);
        }
      }).Start();
    }

    /// <summary>
    /// Update the buttons.
    /// </summary>
    internal void UpdateButtons()
    {
      SystemManager.TryCatchManage(() =>
      {
        if ( LoadingForm.Instance.Visible ) LoadingForm.Instance.Hide();
        MenuTray.Enabled = Globals.IsReady && !Globals.IsGenerating;
        ToolStrip.Enabled = !Globals.IsGenerating;
        ActionSaveToFile.Enabled = DataSet.LunisolarDays.Count > 0;
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
    internal void UpdateCalendarMonth(bool doFill)
    {
      Globals.IsGenerating = true;
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      Enabled = false;
      PanelViewMonth.Parent = null;
      try
      {
        InitializeCalendarUI();
        if ( doFill ) FillMonths();
      }
      finally
      {
        Enabled = true;
        Cursor = cursor;
        Globals.IsGenerating = false;
        SetView(Settings.CurrentView, true);
        UpdateButtons();
      }
    }

  }

}
