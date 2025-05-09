﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2024-01 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class NavigationForm : Form
{

  private const string NoDataField = "-";

  static private readonly Properties.Settings Settings = Program.Settings;

  static public NavigationForm Instance { get; private set; }

  static readonly private int PanelAllExceptParashahTopDefault;
  static readonly private int PanelAllExceptParashahOffset;

  static NavigationForm()
  {
    Instance = new NavigationForm();
    Instance.Relocalize();
    PanelAllExceptParashahTopDefault = Instance.PanelAllExceptParashah.Top;
    PanelAllExceptParashahOffset = PanelAllExceptParashahTopDefault - Instance.LabelParashah.Top;
  }

  private List<LunisolarDayRow> LunisolarDays => ApplicationDatabase.Instance.LunisolarDays;

  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  public DateTime Date
  {
    get => _Date;
    set
    {
      try
      {
        ActiveControl = LabelDate;
        var row = LunisolarDays.Single(day => day.Date == value);
        LabelDate.Text = value.ToLongDateString().Titleize();
        string strMonth = HebrewTranslations.GetLunarMonthDisplayText(row.LunarMonth);
        bool isShabat = value.DayOfWeek == (DayOfWeek)Settings.ShabatDay;
        //
        LabelLunarMonthValue.Text = AppTranslations.NavigationMonth.GetLang(row.LunarMonth);
        LabelLunarMonthName.Text = $"({strMonth.ToUpper()})";
        LabelLunarDayValue.Text = AppTranslations.NavigationDay.GetLang(row.LunarDay);
        LabelLunarDayEvent.Text = isShabat ? $"({HebrewTranslations.Shabat.ToUpper()})" : string.Empty;
        int left = LabelLunarMonthValue.Left + Math.Max(LabelLunarMonthValue.Width, LabelLunarDayValue.Width);
        LabelLunarMonthName.Left = left;
        LabelLunarDayEvent.Left = left;
        LabelSunriseValue.Text = row.SunriseAsString;
        LabelSunsetValue.Text = row.SunsetAsString;
        LabelMoonriseValue.Text = row.MoonriseAsString;
        LabelMoonsetValue.Text = row.MoonsetAsString;
        LabelMoonriseValue.Visible = row.Moonrise is not null;
        LabelMoonrise.Visible = row.Moonrise is not null;
        LabelMoonsetValue.Visible = row.Moonset is not null;
        LabelMoonset.Visible = row.Moonset is not null;
        //
        LabelEventSeasonValue.Text = AppTranslations.GetSeasonChangeDisplayText(row.SeasonChange);
        if ( LabelEventSeasonValue.Text.Length == 0 )
          LabelEventSeasonValue.Text = NoDataField;
        //
        string torahEventText = row.TorahEventText;
        if ( torahEventText.Length == 0 )
        {
          var rowOmerDay = ApplicationDatabase.Instance.GetDay(row.Date);
          if ( rowOmerDay is null )
            torahEventText = NoDataField;
          else
          {
            var (torahEvent, _, text) = rowOmerDay.GetWeekLongCelebrationIntermediateDay();
            torahEventText = torahEvent != TorahCelebration.None ? text : NoDataField;
          }
        }
        LabelEventTorahValue.Text = torahEventText;
        //
        var rowNext = LunisolarDays.Find(day => day.Date > value && day.TorahEvent != TorahCelebrationDay.None);
        if ( rowNext is not null )
        {
          var date = rowNext.Date;
          LabelTorahNextValue.Text = rowNext.TorahEventText;
          LabelTorahNextDateValue.Text = date.ToLongDateString().Titleize();
          LabelTorahNextDateValue.Tag = date;
        }
        else
        {
          LabelTorahNextValue.Text = NoDataField;
          LabelTorahNextDateValue.Text = string.Empty;
          LabelTorahNextDateValue.Tag = null;
        }
        //
        var today = ApplicationDatabase.Instance.GetToday();
        LabelCurrentDayValue.Text = today is not null
                                    ? today.DayAndMonthWithYearText
                                    : SysTranslations.NullSlot.GetLang();
        LabelCurrentDayValue.Tag = today?.Date;
        LabelParashahValue.Text = NoDataField;
        LabelParashahValue.Tag = null;
        var rowParashah = row.GetParashahReadingDay();
        bool isPessah = row.LunarMonth == TorahCelebrationSettings.PessahMonth
                     && row.LunarDay >= TorahCelebrationSettings.PessahStartDay
                     && row.LunarDay <= TorahCelebrationSettings.PessahEndDay;
        bool isSoukot = row.LunarMonth == TorahCelebrationSettings.YomsMonth
                     && row.LunarDay >= TorahCelebrationSettings.SoukotStartDay
                     && ( ( Settings.UseSimhatTorahOutside && row.LunarDay <= TorahCelebrationSettings.SoukotEndDay )
                       || ( row.LunarDay < TorahCelebrationSettings.SoukotEndDay ) );
        LabelParashahValue.Enabled = rowParashah is not null && !isPessah && !isSoukot;
        if ( LabelParashahValue.Enabled && rowParashah is not null )
        {
          LabelParashahValue.Text = rowParashah.GetParashahText(Settings.ParashahCaptionWithBookAndRef);
          LabelParashahValue.Tag = rowParashah;
        }
        //
        var image = MostafaKaisoun.MoonPhaseImage.Draw(value.Year, value.Month, value.Day, 200, 200);
        PictureMoon.Image = image.Resize(100, 100);
        if ( row.MoonriseOccurring == MoonriseOccurring.AfterSet )
        {
          LabelMoonrise.Top = 125;
          LabelMoonriseValue.Top = 125;
          LabelMoonset.Top = 105;
          LabelMoonsetValue.Top = 105;
        }
        else
        {
          LabelMoonrise.Top = 105;
          LabelMoonriseValue.Top = 105;
          LabelMoonset.Top = 125;
          LabelMoonsetValue.Top = 125;
        }
        if ( Settings.CalendarShowParashah && !LabelParashah.Enabled )
        {
          Top -= PanelAllExceptParashahOffset;
          Height += PanelAllExceptParashahOffset;
          LabelParashah.Enabled = true;
          LabelParashah.Visible = true;
          LabelParashahValue.Visible = true;
          PanelAllExceptParashah.Top = PanelAllExceptParashahTopDefault;
        }
        else
        if ( !Settings.CalendarShowParashah && LabelParashah.Enabled )
        {
          LabelParashah.Visible = false;
          LabelParashah.Enabled = false;
          LabelParashahValue.Visible = false;
          PanelAllExceptParashah.Top = LabelParashah.Top;
          Height -= PanelAllExceptParashahOffset;
          Top += PanelAllExceptParashahOffset;
        }
        _Date = value;
      }
      catch
      {
      }
    }
  }

  private DateTime _Date;

  public void SetColors(Color colorTop, Color colorMiddle, Color colorBottom)
  {
    PanelTop.BackColor = colorTop;
    PanelMiddle.BackColor = colorMiddle;
    PanelBottom.BackColor = colorBottom;
  }

  private NavigationForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    Text = DisplayManager.Title;
    SetColors(Settings.NavigateTopColor, Settings.NavigateMiddleColor, Settings.NavigateBottomColor);
    InitializeMenus();
    this.InitDropDowns();
  }

  public void ShowPopup(bool bringToFront = false)
  {
    SetLocation();
    Show();
    if ( bringToFront )
      BringToFront();
  }

  private void SetLocation()
  {
    var style = DisplayManager.GetTaskBarAnchorStyle();
    switch ( style )
    {
      case AnchorStyles.None:
        break;
      case AnchorStyles.Top:
        this.SetLocation(ControlLocation.TopRight);
        break;
      case AnchorStyles.Left:
        this.SetLocation(ControlLocation.BottomLeft);
        break;
      case AnchorStyles.Bottom:
      case AnchorStyles.Right:
        this.SetLocation(ControlLocation.BottomRight);
        break;
      default:
        throw new AdvNotImplementedException(style);
    }
  }

  public void Relocalize()
  {
    Date = _Date;
    if ( Settings.NavigationWindowUseUnicodeIcons )
    {
      Instance.ActionClose.Text = "X";
      Instance.ActionDatesDiff.Text = "∑";
      Instance.ActionNextDay.Text = ">";
      Instance.ActionPreviousDay.Text = "<";
      Instance.ActionSelectDay.Text = "...";
      Instance.ActionSettings.Text = "⚙";
      Instance.ActionViewCalendar.Text = "📅";
    }
    else
    {
      Instance.ActionClose.Text = "X";
      Instance.ActionDatesDiff.Text = "D";
      Instance.ActionNextDay.Text = ">";
      Instance.ActionPreviousDay.Text = "<";
      Instance.ActionSelectDay.Text = "...";
      Instance.ActionSettings.Text = "O";
      Instance.ActionViewCalendar.Text = "C";
    }
  }

  [SuppressMessage("Correctness", "SS018:Add cases for missing enum member.", Justification = "N/A")]
  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    switch ( keyData )
    {
      case Keys.Escape:
        Hide();
        return true;
      case Keys.Left:
        ActionPreviousDay.PerformClick();
        return true;
      case Keys.Right:
        ActionNextDay.PerformClick();
        return true;
      case Keys.Up:
        ActionSelectDay.PerformClick();
        return true;
      case Keys.NumPad0:
        MainForm.Instance.GoToDate(DateTime.Today);
        return true;
      default:
        return base.ProcessCmdKey(ref msg, keyData);
    }
  }

  private void ShowDayForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    MainForm.Instance.TimerBalloon.Stop();
    e.Cancel = true;
    Hide();
  }

  private (LunisolarDayRow Day, Parashah Parashah) GetDayAndParashah()
  {
    var day = (LunisolarDayRow)LabelParashahValue.Tag;
    var parashah = ParashotFactory.Instance.Get(day.ParashahID);
    return (day, parashah);
  }

  private void InitializeMenus()
  {
    ActionStudyOnline.Initialize(HebrewGlobals.WebProvidersParashah,
                                 (sender, _) => DoStudy((string)( (ToolStripMenuItem)sender ).Tag));
    ActionOpenVerseOnline.Initialize(HebrewGlobals.WebProvidersBible,
                                     (sender, _) => DoRead((string)( (ToolStripMenuItem)sender ).Tag));
  }

  private void DoStudy(string url)
  {
    (LunisolarDayRow day, Parashah parashah) = GetDayAndParashah();
    HebrewTools.OpenParashahProvider(url, parashah, day.HasLinkedParashah);
  }

  private void DoRead(string url)
  {
    HebrewTools.OpenBibleProvider(url, GetDayAndParashah().Parashah.FullReferenceBegin);
  }

  private void ActionVerseReadDefault_Click(object sender, EventArgs e)
  {
    DoRead(Settings.OpenVerseOnlineURL);
  }

  private void ActionSelectDay_Click(object sender, EventArgs e)
  {
    ActiveControl = LabelDate;
    var date = DateTime.Today;
    if ( SelectDayForm.Run(null, ref date, true, true) )
      MainForm.Instance.GoToDate(date, true, true, true);
  }

  private void ActionPreviousDay_Click(object sender, EventArgs e)
  {
    MainForm.Instance.GoToDate(_Date.AddDays(-1), true, true, true);
  }

  private void ActionNextDay_Click(object sender, EventArgs e)
  {
    MainForm.Instance.GoToDate(_Date.AddDays(1), true, true, true);
  }

  private void LabelDay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if ( sender is LinkLabel label && label.Tag is not null )
      MainForm.Instance.GoToDate((DateTime)label.Tag, true, true, true);
  }

  private void LabelParashahValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if ( e.Button == MouseButtons.Left )
      if ( LabelParashahValue.Tag is not null )
        ActionViewParashahDescription_Click(sender, e);
  }

  private void ActionViewParashahDescription_Click(object sender, EventArgs e)
  {
    if ( LabelParashahValue.Tag is LunisolarDayRow day )
    {
      var parashah = ParashotFactory.Instance.Get(day.ParashahID);
      MainForm.UserParashot.ShowDescription(parashah, day.HasLinkedParashah, () => ParashotForm.Run(parashah));
    }
  }

  private void ActionViewParashot_Click(object sender, EventArgs e)
  {
    if ( LabelParashahValue.Tag is LunisolarDayRow day )
      ParashotForm.Run(ParashotFactory.Instance.Get(day.ParashahID));
  }

  private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    if ( LabelParashahValue.Tag is LunisolarDayRow day )
      HebrewTools.OpenHebrewWordsGoToVerse(ParashotFactory.Instance.Get(day.ParashahID).FullReferenceBegin);
  }

  private void PictureMoon_Click(object sender, EventArgs e)
  {
    ActionViewCalendar_Click(sender, null);
  }

  private void ActionViewCalendar_Click(object sender, EventArgs e)
  {
    ActiveControl = LabelDate;
    MainForm.Instance.MenuShowHide_Click(null, null);
    MainForm.Instance.Refresh();
    if ( e is not null && Settings.NavigationWindowCloseOnShowMainForm )
      Close();
    else
      this.Popup();
  }

  private void ActionDatesDiff_Click(object sender, EventArgs e)
  {
    ActiveControl = LabelDate;
    DatesDifferenceForm.Run();
  }

  private void ActionSettings_Click(object sender, EventArgs e)
  {
    ActiveControl = LabelDate;
    MainForm.Instance.ActionPreferences_Click(PreferencesForm.TabIndexNavigation, null);
    TopMost = false;
    TopMost = true;
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

}
