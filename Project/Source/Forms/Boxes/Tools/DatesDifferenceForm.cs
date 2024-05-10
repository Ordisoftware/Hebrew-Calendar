/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-04 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class DatesDifferenceForm : Form
{

  static public DatesDifferenceForm Instance { get; private set; }

  static private ApplicationDatabase DBApp => ApplicationDatabase.Instance;

  static DatesDifferenceForm()
  {
    Instance = new DatesDifferenceForm();
  }

  static public void Run(Tuple<DateTime, DateTime> dates = null, bool initOnly = false, bool ensureOrder = false)
  {
    if ( dates is not null )
    {
      if ( ensureOrder )
        if ( dates.Item1 < dates.Item2 )
        {
          Instance.DateStart.SelectionStart = dates.Item1;
          Instance.DateEnd.SelectionStart = dates.Item2;
        }
        else
        {
          Instance.DateStart.SelectionStart = dates.Item2;
          Instance.DateEnd.SelectionStart = dates.Item1;
        }
    }
    else
    if ( Instance.EditAutoSetRightToToday.Checked )
      Instance.DateEnd.SelectionStart = DateTime.Today;
    Instance.DateStart.Tag = Instance.DateStart.SelectionStart;
    Instance.DateEnd.Tag = Instance.DateEnd.SelectionStart;
    Instance.DateChanged(true);
    if ( !initOnly ) Instance.Popup();
  }

  private DatesDifferenceItem Stats;

  private Button CurrentBookmarkButton;

  private DatesDifferenceForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    DateStart.MinDate = AstronomyHelper.LunisolarCalendar.MinSupportedDateTime;
    DateStart.MaxDate = AstronomyHelper.LunisolarCalendar.MaxSupportedDateTime;
    DateEnd.MinDate = AstronomyHelper.LunisolarCalendar.MinSupportedDateTime;
    DateEnd.MaxDate = AstronomyHelper.LunisolarCalendar.MaxSupportedDateTime;
    DatePickerStart.MinDate = AstronomyHelper.LunisolarCalendar.MinSupportedDateTime;
    DatePickerStart.MaxDate = AstronomyHelper.LunisolarCalendar.MaxSupportedDateTime;
    DatePickerEnd.MinDate = AstronomyHelper.LunisolarCalendar.MinSupportedDateTime;
    DatePickerEnd.MaxDate = AstronomyHelper.LunisolarCalendar.MaxSupportedDateTime;
  }

  private void DateDiffForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
    LoadMenuBookmarks(this);
  }

  internal void LoadMenuBookmarks(Form caller)
  {
    DateBookmarkRow.LoadMenuBookmarks(MenuBookmarks.Items, ActionGotoBookmark_MouseUp);
    if ( caller != MainForm.Instance ) MainForm.Instance.LoadMenuBookmarks(this);
  }

  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "Analysis error")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "Analysis error")]
  public void Relocalize()
  {
    if ( !Globals.IsReady ) return;
    var date1 = DateStart.SelectionStart;
    var date2 = DateEnd.SelectionStart;
    bool isVisible = Instance.Visible;
    var location = Instance.Location;
    Instance = new DatesDifferenceForm();
    Run(new Tuple<DateTime, DateTime>(date1, date2), true);
    Instance.DateStart.Tag = date1;
    Instance.DateEnd.Tag = date2;
    Instance.DateChanged(true);
    AllowClose = true;
    Close();
    if ( isVisible )
    {
      Instance.Show();
      Instance.Location = location;
    }
  }

  private bool AllowClose;

  private void DatesDiffCalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if ( AllowClose ) return;
    e.Cancel = true;
    Hide();
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void ActionGotoBookmark_MouseUp(object sender, MouseEventArgs e)
  {
    DateBookmarkRow.MenuItemMouseUp(this, (ToolStripMenuItem)sender, e.Button, LoadMenuBookmarks, bookmark =>
    {
      if ( CurrentBookmarkButton == ActionGoToBookmarkStart )
        DateStart.SelectionStart = bookmark.Date;
      else
      if ( CurrentBookmarkButton == ActionGoToBookmarkEnd )
        DateEnd.SelectionStart = bookmark.Date;
    });
  }

  private void ActionSaveBookmark_Click(object sender, EventArgs e)
  {
    DateTime date;
    if ( sender == ActionSaveBookmarkStart )
      date = DateStart.SelectionStart;
    else
      if ( sender == ActionSaveBookmarkEnd )
      date = DateEnd.SelectionStart;
    else
      return;
    DateBookmarkRow.CreateFromUserInput(date);
    LoadMenuBookmarks(this);
  }

  private void ActionBookmarksButton_Click(object sender, EventArgs e)
  {
    var control = sender as Button;
    CurrentBookmarkButton = control;
    MenuBookmarks.Show(control, new Point(0, control.Height));
  }

  private void ActionManageBookmarks_Click(object sender, EventArgs e)
  {
    Enabled = false;
    try
    {
      ManageBookmarksForm.Run();
      LoadMenuBookmarks(this);
    }
    finally
    {
      Enabled = true;
    }
  }

  private void ActionHelp_Click(object sender, EventArgs e)
  {
    MessageBoxEx.ShowDialogOrSystem(AppTranslations.NoticeDatesDifferenceTitle,
                                    AppTranslations.NoticeDatesDifference,
                                    width: MessageBoxEx.DefaultWidthMedium);
  }

  private void ActionSwapDates_Click(object sender, EventArgs e)
  {
    (DateEnd.SelectionStart, DateStart.SelectionStart) = (DateStart.SelectionStart, DateEnd.SelectionStart);
  }

  private void DatePickerStart_ValueChanged(object sender, EventArgs e)
  {
    DateStart.SelectionStart = DatePickerStart.Value.Date;
  }

  private void DatePickerEnd_ValueChanged(object sender, EventArgs e)
  {
    DateEnd.SelectionStart = DatePickerEnd.Value.Date;
  }

  private void DateStart_DateChanged(object sender, DateRangeEventArgs e)
  {
    DatePickerStart.Value = DateStart.SelectionStart.Date;
    DateChanged();
  }

  private void DateEnd_DateChanged(object sender, DateRangeEventArgs e)
  {
    DatePickerEnd.Value = DateEnd.SelectionStart.Date;
    DateChanged();
  }

  private void DateChanged(bool force = false)
  {
    if ( DateStart.Tag is null ) return;
    bool b1 = (DateTime)DateStart.Tag != DateStart.SelectionStart;
    bool b2 = (DateTime)DateEnd.Tag != DateEnd.SelectionStart;
    if ( b1 ) DateStart.Tag = DateStart.SelectionStart;
    if ( b2 ) DateEnd.Tag = DateEnd.SelectionStart;
    if ( !force && !b1 && !b2 ) return;
    var cursor = Cursor;
    Cursor = Cursors.WaitCursor;
    try
    {
      if ( Stats is null )
      {
        Stats = new DatesDifferenceItem(this, DateStart.SelectionStart, DateEnd.SelectionStart);
        DatesDifferenceItemBindingSource.DataSource = Stats;
      }
      else
      {
        Stats.SetDates(this, DateStart.SelectionStart, DateEnd.SelectionStart);
        DatesDifferenceItemBindingSource.ResetBindings(false);
      }
    }
    finally
    {
      Cursor = cursor;
    }
    var dateStart = DateStart.SelectionStart;
    var dateEnd = DateEnd.SelectionStart;
    ActionSaveBookmarkStart.Enabled = DBApp.DateBookmarks.Find(item => item.Date == dateStart) is null;
    ActionSaveBookmarkEnd.Enabled = DBApp.DateBookmarks.Find(item => item.Date == dateEnd) is null;
  }

  private void ActionOpenCalc_Click(object sender, EventArgs e)
  {
    MainForm.Instance.ActionOpenCalculator.PerformClick();
  }

}
