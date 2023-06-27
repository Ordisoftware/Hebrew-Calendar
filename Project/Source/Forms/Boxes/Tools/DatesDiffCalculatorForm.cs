/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2023-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class DatesDiffCalculatorForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  static public DatesDiffCalculatorForm Instance { get; private set; }

  static DatesDiffCalculatorForm()
  {
    Instance = new DatesDiffCalculatorForm();
  }

  // TODO refactor
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "<En attente>")]
  static public void LoadMenuBookmarks(ToolStripItemCollection items, MouseEventHandler action)
  {
    bool onlyCalendar = items == MainForm.Instance.MenuBookmarks.Items;
    items.Clear();
    for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
    {
      var bookmark = Program.DateBookmarks[index];
      string dateText = bookmark is null ? SysTranslations.EmptySlot.GetLang() : bookmark.ToString();
      var menuitem = items.Add($"{index + 1:00}. {dateText}");
      menuitem.MouseUp += action;
      menuitem.Tag = index;
      if ( onlyCalendar && bookmark is not null )
        if ( bookmark.Date < MainForm.Instance.DateFirst || bookmark.Date > MainForm.Instance.DateLast )
          menuitem.Enabled = false;
    }
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

  private DatesDiffCalculatorForm()
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
    LoadMenuBookmarks(MenuBookmarks.Items, Bookmarks_MouseUp);
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
    Instance = new DatesDiffCalculatorForm();
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

  private void Bookmarks_MouseUp(object sender, MouseEventArgs e)
  {
    var menuitem = (ToolStripMenuItem)sender;
    var control = CurrentBookmarkButton;
    if ( e.Button == MouseButtons.Right )
    {
      if ( control == ActionSetBookmarkStart || control == ActionSetBookmarkEnd )
        if ( !menuitem.Text.EndsWith(")", StringComparison.Ordinal) )
        {
          string date = Program.DateBookmarks[(int)menuitem.Tag].Date.ToLongDateString();
          if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmark.GetLang(date)) )
            return;
          menuitem.Text = $"{(int)menuitem.Tag + 1:00}. {SysTranslations.EmptySlot.GetLang()}";
          Program.DateBookmarks[(int)menuitem.Tag] = null;
          Program.DateBookmarks.ApplyAutoSort();
          SystemManager.TryCatch(Settings.Save);
        }
    }
    else
    if ( e.Button == MouseButtons.Left )
    {
      if ( control == ActionSetBookmarkStart )
        setBookmark(DateStart);
      else
      if ( control == ActionSetBookmarkEnd )
        setBookmark(DateEnd);
      else
      {
        var partDate = menuitem.Text.Skip(3).TakeWhile(c => c != DateBookmarkItem.MemoSeparator);
        if ( DateTime.TryParse(new string(partDate.ToArray()), out DateTime date) )
          if ( control == ActionUseBookmarkStart )
            DateStart.SelectionStart = date;
          else
          if ( control == ActionUseBookmarkEnd )
            DateEnd.SelectionStart = date;
      }
    }
    MainForm.Instance.LoadMenuBookmarks(this);
    // TODO refactor with mainform.bookmarks
    void setBookmark(MonthCalendar calendar)
    {
      var dateNew = calendar.SelectionStart.Date;
      for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
      {
        var bookmark = Program.DateBookmarks[index];
        if ( bookmark is not null && dateNew == bookmark.Date ) return;
      }
      var bookmarkOld = Program.DateBookmarks[(int)menuitem.Tag];
      if ( bookmarkOld is not null )
      {
        string date1 = bookmarkOld.Date.ToShortDateString();
        string date2 = dateNew.ToShortDateString();
        string msg = SysTranslations.AskToReplaceBookmark.GetLang(date1, date2);
        if ( !DisplayManager.QueryYesNo(msg) ) return;
      }
      string memo = string.Empty;
      if ( DisplayManager.QueryValue(SysTranslations.Memo.GetLang(),
                                     dateNew.ToLongDateString(),
                                     ref memo) == InputValueResult.Cancelled )
        return;
      Program.DateBookmarks[(int)menuitem.Tag] = new DateBookmarkItem(dateNew, memo);
      Program.DateBookmarks.ApplyAutoSort();
      SystemManager.TryCatch(Settings.Save);
      LoadMenuBookmarks(this);
    }
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
      if ( ManageBookmarksForm.Run() )
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
        DatesDiffItemBindingSource.DataSource = Stats;
      }
      else
      {
        Stats.SetDates(this, DateStart.SelectionStart, DateEnd.SelectionStart);
        DatesDiffItemBindingSource.ResetBindings(false);
      }
    }
    finally
    {
      Cursor = cursor;
    }
  }

  private void ActionOpecCalc_Click(object sender, EventArgs e)
  {
    MainForm.Instance.ActionOpenCalculator.PerformClick();
  }

}
