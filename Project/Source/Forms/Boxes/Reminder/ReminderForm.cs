/// <license>
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class ReminderForm : Form
{

  #region Static Constructor and Run

  static private readonly Properties.Settings Settings = Program.Settings;

  static private readonly Image Image;

  static ReminderForm()
  {
    try
    {
      Image = Image.FromFile(Program.ApplicationImage64FilePath);
    }
    catch ( FileNotFoundException )
    {
      DisplayManager.ShowError(SysTranslations.FileNotFound.GetLang(Program.ApplicationImage64FilePath));
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(SysTranslations.LoadFileError.GetLang(Program.ApplicationImage64FilePath, ex.Message));
    }
  }

  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  [SuppressMessage("Performance", "U2U1203:Use foreach efficiently", Justification = "The collection is modified")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  static public void Run(LunisolarDayRow row, TorahCelebrationDay celebration, ReminderTimes times)
  {
    bool isShabat = celebration == TorahCelebrationDay.Shabat;
    bool doLockSession;
    var dateNow = DateTime.Now;
    doLockSession = dateNow >= times.DateStart && dateNow <= times.DateEnd;
    bool isLockSessionIcon = doLockSession && Settings.ReminderShowLockoutIcon;
    try
    {
      ReminderForm form = null;
      if ( isShabat && MainForm.Instance.ShabatForm is not null )
      {
        Flash(MainForm.Instance.ShabatForm);
        return;
      }
      else
      if ( celebration != TorahCelebrationDay.None )
      {
        if ( MainForm.Instance.RemindCelebrationDayForms.TryGetValue(celebration, out form) )
        {
          Flash(form);
          return;
        }
      }
      else
      if ( !isShabat )
      {
        foreach ( var item in MainForm.Instance.RemindCelebrationDayForms )
          if ( (DateTime)item.Value.Tag == row.Date )
            return;
        foreach ( var item in MainForm.Instance.RemindCelebrationForms )
          if ( (DateTime)item.Tag == row.Date )
          {
            Flash(item);
            return;
          }
      }
      form = new ReminderForm
      {
        IsShabat = isShabat,
        Celebration = TorahCelebrationSettings.Convert(row.TorahEvent)
      };
      var date = row.Date;
      form.LabelTitle.Text = isShabat
        ? HebrewTranslations.Shabat
        : AppTranslations.GetCelebrationDayDisplayText(celebration == TorahCelebrationDay.None
          ? row.TorahEvent
          : celebration);
      form.LabelDate.Text = isShabat
        ? date.ToLongDateString().Titleize()
        : row.DayAndMonthWithYearText;
      string textDateStart = AppTranslations.DaysOfWeek.GetLang(times.DateStart.DayOfWeek);
      string textDateEnd = AppTranslations.DaysOfWeek.GetLang(times.DateEnd.DayOfWeek);
      form.LabelStartTime.Text = $"{textDateStart} {times.TimeStart:hh\\:mm}";
      form.LabelEndTime.Text = $"{textDateEnd} {times.TimeEnd:hh\\:mm}";
      form.LabelStartDay.Text = times.DateStart.ToString("d MMM yyyy");
      form.LabelEndDay.Text = times.DateEnd.ToString("d MMM yyyy");
      int leftLabelArrow = form.LabelStartTime.Left + form.LabelStartTime.Width;
      int leftLabelEndTime = leftLabelArrow + form.LabelArrow.Width;
      form.LabelArrow.Left = leftLabelArrow;
      form.LabelEndTime.Left = leftLabelEndTime;
      form.LabelEndDay.Left = leftLabelEndTime;
      form.LabelDate.Tag = date;
      form.Tag = row.Date;
      form.Text = " " + form.LabelTitle.Text;
      if ( isShabat )
      {
        if ( Settings.CalendarShowParashah && Settings.ReminderShabatShowParashah )
        {
          var rowParashah = row.GetParashahReadingDay();
          if ( rowParashah is not null )
          {
            form.LabelParashahValue.Text = rowParashah.GetParashahText(Settings.ParashahCaptionWithBookAndRef);
            form.LabelParashahValue.Tag = row;
            form.LabelParashahValue.Visible = true;
          }
          else
          {
            form.Celebration = TorahCelebration.Shabat;
            form.LabelParashahValue.Text = form.ActionViewParashot.Text;
            form.LabelParashahValue.Tag = null;
          }
        }
        else
        {
          form.LabelParashahValue.Text = string.Empty;
          form.Height -= form.LabelParashahValue.Height;
          form.ActionLockout.Top -= (int)( form.LabelParashahValue.Height * 0.75 );
        }
      }
      form.ActionLockout.Visible = isLockSessionIcon;
      form.LabelTitle.ForeColor = Settings.CalendarColorTorahEvent;
      form.LabelDate.LinkColor = Settings.CalendarColorMoon;
      form.LabelDate.ActiveLinkColor = Settings.CalendarColorMoon;
      form.LabelStartTime.ForeColor = Settings.MonthViewTextColor;
      form.LabelEndTime.ForeColor = Settings.MonthViewTextColor;
      form.LabelStartDay.ForeColor = Settings.MonthViewTextColor;
      form.LabelEndDay.ForeColor = Settings.MonthViewTextColor;
      form.LabelParashahValue.LinkColor = Settings.CalendarColorMoon;
      if ( Settings.UseColors )
        form.BackColor = doLockSession ? Settings.EventColorTorah : Settings.EventColorNext;
      if ( isShabat )
        MainForm.Instance.ShabatForm = form;
      else
      if ( celebration != TorahCelebrationDay.None )
      {
        foreach ( var item in MainForm.Instance.RemindCelebrationForms.ToList() )
          if ( (DateTime)item.Tag == row.Date )
          {
            item.Close();
            break;
          }
        MainForm.Instance.RemindCelebrationDayForms.Add(celebration, form);
      }
      else
        MainForm.Instance.RemindCelebrationForms.Add(form);
      SetFormsLocation();
      form.Show();
      form.BringToFront();
      Application.DoEvents();
      BringMainForm();
    }
    finally
    {
      if ( doLockSession && Settings.AutoLockSession )
        LockSessionForm.Run();
    }
  }

  #endregion

  #region Static Multi-Box Management

  static private void BringMainForm()
  {
    if ( MainForm.Instance.Visible && MainForm.Instance.WindowState != FormWindowState.Minimized )
      MainForm.Instance.MenuShowHide_Click(null, null);
    Application.DoEvents();
  }

  [SuppressMessage("Design", "GCop129:Change to an instance method, instead of taking a parameter '{0}' with the same type as the class.", Justification = "Need static")]
  static private void Flash(ReminderForm form)
  {
    form.Hide();
    Thread.Sleep(500);
    form.Show();
    form.BringToFront();
    DoSound();
    BringMainForm();
  }

  [SuppressMessage("Correctness", "SS018:Add cases for missing enum member.", Justification = "N/A")]
  static private void SetFormsLocation()
  {
    var list = new List<ReminderForm>();
    if ( MainForm.Instance.ShabatForm is not null )
      list.Add(MainForm.Instance.ShabatForm);
    list.AddRange(MainForm.Instance.RemindCelebrationDayForms.Values);
    list.AddRange(MainForm.Instance.RemindCelebrationForms);
    var location = Settings.ReminderBoxDesktopLocation;
    int posY = 0;
    int posX = 0;
    bool first = true;
    foreach ( var form in list.OrderBy(f => f.Tag) )
    {
      if ( first )
      {
        form.SetLocation(location);
        posY = form.Top;
        posX = form.Left;
        first = false;
        continue;
      }
      switch ( location )
      {
        case ControlLocation.TopLeft:
        case ControlLocation.TopRight:
          posY += form.Height;
          form.Location = new Point(posX, posY);
          break;
        case ControlLocation.BottomLeft:
        case ControlLocation.BottomRight:
          posY -= form.Height;
          form.Location = new Point(posX, posY);
          break;
        default:
          throw new AdvNotImplementedException(location);
      }
    }
  }

  #endregion

  #region Instance Form Management

  protected override bool ShowWithoutActivation => true;

  private bool IsShabat;

  private TorahCelebration Celebration;

  private ReminderForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    ShowInTaskbar = Settings.ShowReminderInTaskBar;
    if ( Image is not null ) PictureBox.Image = Image;
    InitializeMenus();
    this.InitDropDowns();
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "<En attente>")]
  private void ReminderForm_Load(object sender, EventArgs e)
  {
    PowerAction[] avoid = [PowerAction.LogOff, PowerAction.Restart];
    foreach ( var value in SystemManager.GetAvailablePowerActions().Where(a => !avoid.Contains(a)) )
    {
      var item = (ToolStripMenuItem)ContextMenuLockout.Items.Add(SysTranslations.PowerActionText.GetLang(value));
      item.Tag = value;
      item.Click += (senderItemClick, _) =>
      {
        var action = (PowerAction)( (ToolStripItem)senderItemClick ).Tag;
        SystemManager.DoPowerAction(action, Settings.LockSessionConfirmLogOffOrMore);
      };
      if ( Settings.LockSessionDefaultAction == value )
        item.Image = MenuDefaultLockout.Image;
    }
  }

  private void ReminderForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    if ( IsShabat )
      MainForm.Instance.ShabatForm = null;
    else
    {
      MainForm.Instance.RemindCelebrationForms.Remove(this);
      var key = MainForm.Instance.RemindCelebrationDayForms.FirstOrDefault(x => x.Value == this).Key;
      MainForm.Instance.RemindCelebrationDayForms.Remove(key);
    }
    SetFormsLocation();
  }

  private void ReminderForm_Shown(object sender, EventArgs e)
  {
    DoSound();
  }

  #endregion

  #region Context Menu Parashah

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

  #endregion

  #region Instance User Interactions

  [SuppressMessage("Correctness", "SS018:Add cases for missing enum member.", Justification = "N/A")]
  static private void DoSound()
  {
    switch ( Settings.ReminderBoxSoundSource )
    {
      case SoundSource.Dialog:
        DisplayManager.DoSound(Settings.ReminderBoxSoundDialog);
        break;
      case SoundSource.Application:
        new SoundItem(Settings.ReminderBoxSoundApplication).Play();
        break;
      case SoundSource.Windows:
        new SoundItem(Settings.ReminderBoxSoundWindows).Play();
        break;
      case SoundSource.Custom:
        new SoundItem(Settings.ReminderBoxSoundPath).Play();
        break;
      default:
        throw new AdvNotImplementedException(Settings.ReminderBoxSoundSource);
    }
    Application.DoEvents();
    if ( Settings.ReminderBoxSoundSource != SoundSource.None )
      Thread.Sleep(400);
  }

  private void Form_Click(object sender, EventArgs e)
  {
    if ( Settings.ReminderFormCloseOnClick )
      Close();
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void PictureBox_Click(object sender, EventArgs e)
  {
    LabelDate_LinkClicked(sender, new LinkLabelLinkClickedEventArgs(null, MouseButtons.Left));
  }

  private void LabelDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if ( LabelDate.Tag is null ) return;
    bool useLeftClick = Settings.BoxesRetakeFocusAfterDateClick;
    bool retakeFocus = ( useLeftClick && e.Button == MouseButtons.Left )
                    || ( !useLeftClick && e.Button == MouseButtons.Right );
    MainForm.Instance.GoToDate((DateTime)LabelDate.Tag, true, false, false, retakeFocus ? this : null);
  }

  private void ActionSetupSound_Click(object sender, EventArgs e)
  {
    SelectSoundForm.Run(true);
  }

  private void ActionPreferences_Click(object sender, EventArgs e)
  {
    int index = IsShabat ? PreferencesForm.TabIndexShabat : PreferencesForm.TabIndexCelebrations;
    MainForm.Instance.ActionPreferences_Click(index, null);
  }

  private void LabelParashahValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if ( LabelParashahValue.Tag is null )
    {
      ActiveControl = null;
      if ( Celebration == TorahCelebration.Shabat )
        ParashotForm.Run();
      else
      {
        CelebrationVersesBoardForm.Run(Celebration,
                                       nameof(Settings.CelebrationVersesBoardFormLocation),
                                       nameof(Settings.CelebrationVersesBoardFormClientSize),
                                       Settings.OpenVerseOnlineURL,
                                       Settings.DoubleClickOnVerseOpenDefaultReader,
                                       value => Settings.DoubleClickOnVerseOpenDefaultReader = value);
      }
    }
    else
    if ( e.Button == MouseButtons.Left )
      ActionViewParashahDescription_Click(this, e);
  }

  private void ActionViewParashahDescription_Click(object sender, EventArgs e)
  {
    if ( !ApplicationDatabase.Instance.ShowWeeklyParashahDescription() )
      ActionViewParashahInfos.Enabled = false;
  }

  private void ActionViewParashot_Click(object sender, EventArgs e)
  {
    ParashotForm.Run(ApplicationDatabase.Instance.GetWeeklyParashah().Factory);
  }

  private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    HebrewTools.OpenHebrewWordsGoToVerse(ApplicationDatabase.Instance.GetWeeklyParashah().Factory.FullReferenceBegin);
  }

  private void ActionLockout_Click(object sender, EventArgs e)
  {
    ContextMenuLockout.Show(ActionLockout, new Point(0, ActionLockout.Height));
  }

  #endregion

}
