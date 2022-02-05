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
/// <created> 2020-04 </created>
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class DatesDiffCalculatorForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  static public DatesDiffCalculatorForm Instance { get; private set; }

  static DatesDiffCalculatorForm()
  {
    Instance = new DatesDiffCalculatorForm();
  }

  static public void LoadMenuBookmarks(ToolStripItemCollection items, MouseEventHandler action)
  {
    bool onlyCalendar = items == MainForm.Instance.MenuBookmarks.Items;
    items.Clear();
    for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
    {
      var date = Program.DateBookmarks[index];
      string s = date == DateTime.MinValue ? SysTranslations.EmptySlot.GetLang() : date.ToLongDateString();
      var menuitem = items.Add($"{index + 1:00}. {s}");
      menuitem.MouseUp += action;
      menuitem.Tag = index;
      if ( onlyCalendar && date != DateTime.MinValue )
        if ( date < MainForm.Instance.DateFirst || date > MainForm.Instance.DateLast )
          menuitem.Enabled = false;
    }
  }

  static public void Run(Tuple<DateTime, DateTime> dates = null, bool initonly = false, bool ensureOrder = false)
  {
    if ( dates is not null )
    {
      if ( ensureOrder )
        if ( dates.Item1 < dates.Item2 )
        {
          Instance.MonthCalendar1.SelectionStart = dates.Item1;
          Instance.MonthCalendar2.SelectionStart = dates.Item2;
        }
        else
        {
          Instance.MonthCalendar1.SelectionStart = dates.Item2;
          Instance.MonthCalendar2.SelectionStart = dates.Item1;
        }
    }
    else
    if ( Instance.EditAutoSetRightToToday.Checked )
      Instance.MonthCalendar2.SelectionStart = DateTime.Today;
    Instance.MonthCalendar1.Tag = Instance.MonthCalendar1.SelectionStart;
    Instance.MonthCalendar2.Tag = Instance.MonthCalendar2.SelectionStart;
    Instance.DateChanged(true);
    if ( !initonly ) Instance.Popup();
  }

  private DatesDiffItem Stats;
  private Button CurrentBookmarkButton;

  private DatesDiffCalculatorForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    MonthCalendar1.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
    MonthCalendar1.MaxDate = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime;
    MonthCalendar2.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
    MonthCalendar2.MaxDate = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime;
    DateTimePicker1.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
    DateTimePicker1.MaxDate = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime;
    DateTimePicker2.MinDate = AstronomyHelper.LunisolerCalendar.MinSupportedDateTime;
    DateTimePicker2.MaxDate = AstronomyHelper.LunisolerCalendar.MaxSupportedDateTime;
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

  public void Relocalize()
  {
    if ( !Globals.IsReady ) return;
    var date1 = MonthCalendar1.SelectionStart;
    var date2 = MonthCalendar2.SelectionStart;
    bool isVisible = Instance.Visible;
    var location = Instance.Location;
    Instance.Dispose();
    Instance = new DatesDiffCalculatorForm();
    Run(new Tuple<DateTime, DateTime>(date1, date2), true);
    Instance.MonthCalendar1.Tag = date1;
    Instance.MonthCalendar2.Tag = date2;
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
        if ( !menuitem.Text.EndsWith(")") )
        {
          var date = Program.DateBookmarks[(int)menuitem.Tag].ToLongDateString();
          if ( !DisplayManager.QueryYesNo(SysTranslations.AskToDeleteBookmark.GetLang(date)) )
            return;
          menuitem.Text = $"{(int)menuitem.Tag + 1:00}. { SysTranslations.EmptySlot.GetLang()}";
          Program.DateBookmarks[(int)menuitem.Tag] = DateTime.MinValue;
          SystemManager.TryCatch(Settings.Save);
        }
    }
    else
    if ( e.Button == MouseButtons.Left )
    {
      if ( control == ActionSetBookmarkStart )
        setBookmark(MonthCalendar1);
      else
      if ( control == ActionSetBookmarkEnd )
        setBookmark(MonthCalendar2);
      else
      if ( DateTime.TryParse(menuitem.Text.Substring(3), out DateTime date) )
        if ( control == ActionUseBookmarkStart )
          MonthCalendar1.SelectionStart = date;
        else
        if ( control == ActionUseBookmarkEnd )
          MonthCalendar2.SelectionStart = date;
    }
    MainForm.Instance.LoadMenuBookmarks(this);
    //
    void setBookmark(MonthCalendar calendar)
    {
      var dateNew = calendar.SelectionStart.Date;
      for ( int index = 0; index < Settings.DateBookmarksCount; index++ )
      {
        var date = Program.DateBookmarks[index];
        if ( dateNew == date ) return;
      }
      var dateOld = Program.DateBookmarks[(int)menuitem.Tag];
      if ( dateOld != DateTime.MinValue )
      {
        string date1 = dateOld.ToShortDateString();
        string date2 = dateNew.ToShortDateString();
        string msg = SysTranslations.AskToReplaceBookmark.GetLang(date1, date2);
        if ( !DisplayManager.QueryYesNo(msg) ) return;
      }
      menuitem.Text = $"{(int)menuitem.Tag + 1:00}. { dateNew.ToLongDateString()}";
      Program.DateBookmarks[(int)menuitem.Tag] = dateNew.Date;
      SystemManager.TryCatch(Settings.Save);
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
      if ( EditDateBookmarksForm.Run() )
        LoadMenuBookmarks(this);
    }
    finally
    {
      Enabled = true;
    }
  }

  private void ActionHelp_Click(object sender, EventArgs e)
  {
    MessageBoxEx.ShowDialogOrSystem(AppTranslations.NoticeDatesDiffTitle,
                                    AppTranslations.NoticeDatesDiff,
                                    width: MessageBoxEx.DefaultWidthMedium);
  }

  private void ActionSwapDates_Click(object sender, EventArgs e)
  {
    var temp = MonthCalendar1.SelectionStart;
    MonthCalendar1.SelectionStart = MonthCalendar2.SelectionStart;
    MonthCalendar2.SelectionStart = temp;
  }

  private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
  {
    MonthCalendar1.SelectionStart = DateTimePicker1.Value.Date;
  }

  private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
  {
    MonthCalendar2.SelectionStart = DateTimePicker2.Value.Date;
  }

  private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
  {
    DateTimePicker1.Value = MonthCalendar1.SelectionStart.Date;
    DateChanged();
  }

  private void MonthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
  {
    DateTimePicker2.Value = MonthCalendar2.SelectionStart.Date;
    DateChanged();
  }

  private void DateChanged(bool force = false)
  {
    if ( MonthCalendar1.Tag is null ) return;
    bool b1 = (DateTime)MonthCalendar1.Tag != MonthCalendar1.SelectionStart;
    bool b2 = (DateTime)MonthCalendar2.Tag != MonthCalendar2.SelectionStart;
    if ( b1 ) MonthCalendar1.Tag = MonthCalendar1.SelectionStart;
    if ( b2 ) MonthCalendar2.Tag = MonthCalendar2.SelectionStart;
    if ( !force && !b1 && !b2 ) return;
    var cursor = Cursor;
    Cursor = Cursors.WaitCursor;
    try
    {
      if ( Stats is null )
      {
        Stats = new DatesDiffItem(this, MonthCalendar1.SelectionStart, MonthCalendar2.SelectionStart);
        DatesDiffItemBindingSource.DataSource = Stats;
      }
      else
      {
        Stats.SetDates(this, MonthCalendar1.SelectionStart, MonthCalendar2.SelectionStart);
        DatesDiffItemBindingSource.ResetBindings(false);
      }
    }
    finally
    {
      Cursor = cursor;
    }
  }

}
