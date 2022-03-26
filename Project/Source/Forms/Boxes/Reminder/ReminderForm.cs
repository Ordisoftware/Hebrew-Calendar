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
/// <created> 2019-01 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ReminderForm : Form
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

  [SuppressMessage("Performance", "U2U1203:Use foreach efficiently", Justification = "The collection is modified")]
  static public void Run(LunisolarDay row, TorahCelebrationDay celebration, ReminderTimes times)
  {
    bool isShabat = celebration == TorahCelebrationDay.Shabat;
    bool doLockSession;
    var dateNow = DateTime.Now;
    doLockSession = dateNow >= times.DateStart && dateNow <= times.DateEnd;
    bool isLockSessionIcon = doLockSession && Program.Settings.ReminderShowLockoutIcon;
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
        Celebration = row.TorahEvent
      };
      var date = row.Date;
      form.LabelTitle.Text = isShabat
                             ? AppTranslations.Shabat.GetLang()
                             : AppTranslations.TorahCelebrationDays.GetLang(celebration == TorahCelebrationDay.None
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
        if ( Program.Settings.CalendarShowParashah && Program.Settings.ReminderShabatShowParashah )
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
            form.Celebration = TorahCelebrationDay.Shabat;
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
      form.LabelTitle.ForeColor = Program.Settings.CalendarColorTorahEvent;
      form.LabelDate.LinkColor = Program.Settings.CalendarColorMoon;
      form.LabelDate.ActiveLinkColor = Program.Settings.CalendarColorMoon;
      form.LabelStartTime.ForeColor = Program.Settings.MonthViewTextColor;
      form.LabelEndTime.ForeColor = Program.Settings.MonthViewTextColor;
      form.LabelStartDay.ForeColor = Program.Settings.MonthViewTextColor;
      form.LabelEndDay.ForeColor = Program.Settings.MonthViewTextColor;
      form.LabelParashahValue.LinkColor = Program.Settings.CalendarColorMoon;
      if ( Program.Settings.UseColors )
        form.BackColor = doLockSession ? Program.Settings.EventColorTorah : Program.Settings.EventColorNext;
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
      if ( doLockSession && Program.Settings.AutoLockSession )
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

  static private void Flash(ReminderForm form)
  {
    form.Hide();
    Thread.Sleep(500);
    form.Show();
    form.BringToFront();
    DoSound();
    BringMainForm();
  }

  static private void SetFormsLocation()
  {
    var list = new List<ReminderForm>();
    if ( MainForm.Instance.ShabatForm is not null )
      list.Add(MainForm.Instance.ShabatForm);
    foreach ( var item in MainForm.Instance.RemindCelebrationDayForms )
      list.Add(item.Value);
    foreach ( ReminderForm item in MainForm.Instance.RemindCelebrationForms )
      list.Add(item);
    var location = Program.Settings.ReminderBoxDesktopLocation;
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
          throw new AdvancedNotImplementedException(location);
      }
    }
  }

  #endregion

  #region Instance Form Management

  protected override bool ShowWithoutActivation => true;

  private bool IsShabat;

  private TorahCelebrationDay Celebration;

  private ReminderForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    ShowInTaskbar = Program.Settings.ShowReminderInTaskBar;
    if ( Image is not null ) PictureBox.Image = Image;
    InitializeParashahMenu();
    this.InitDropDowns();
  }

  private void ReminderForm_Load(object sender, EventArgs e)
  {
    PowerAction[] avoid = { PowerAction.LogOff, PowerAction.Restart };
    foreach ( var value in SystemManager.GetAvailablePowerActions().Where(a => !avoid.Contains(a)) )
    {
      var item = (ToolStripMenuItem)ContextMenuLockout.Items.Add(SysTranslations.PowerActionText.GetLang(value));
      item.Tag = value;
      item.Click += (_s, _) =>
      {
        var action = (PowerAction)( (ToolStripItem)_s ).Tag;
        SystemManager.DoPowerAction(action, Program.Settings.LockSessionConfirmLogOffOrMore);
      };
      if ( Program.Settings.LockSessionDefaultAction == value )
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

  private void InitializeParashahMenu()
  {
    ActionStudyOnline.InitializeFromProviders(HebrewGlobals.WebProvidersParashah, (sender, _) =>
    {
      var menuitem = (ToolStripMenuItem)sender;
      var day = (LunisolarDay)LabelParashahValue.Tag;
      HebrewTools.OpenParashahProvider((string)menuitem.Tag,
                                       ParashotFactory.Instance.Get(day.ParashahID),
                                       day.HasLinkedParashah);
    });
    ActionOpenVerseOnline.InitializeFromProviders(HebrewGlobals.WebProvidersBible, (sender, _) =>
    {
      var menuitem = (ToolStripMenuItem)sender;
      var day = (LunisolarDay)LabelParashahValue.Tag;
      var parashah = ParashotFactory.Instance.Get(day.ParashahID);
      string verse = $"{(int)parashah.Book}.{parashah.VerseBegin}";
      HebrewTools.OpenBibleProvider((string)menuitem.Tag, verse);
    });
  }

  #endregion

  #region Instance User Interactions

  static private void DoSound()
  {
    switch ( Program.Settings.ReminderBoxSoundSource )
    {
      case SoundSource.Dialog:
        DisplayManager.DoSound(Program.Settings.ReminderBoxSoundDialog);
        break;
      case SoundSource.Application:
        new SoundItem(Program.Settings.ReminderBoxSoundApplication).Play();
        break;
      case SoundSource.Windows:
        new SoundItem(Program.Settings.ReminderBoxSoundWindows).Play();
        break;
      case SoundSource.Custom:
        new SoundItem(Program.Settings.ReminderBoxSoundPath).Play();
        break;
    }
    Application.DoEvents();
    if ( Program.Settings.ReminderBoxSoundSource != SoundSource.None )
      Thread.Sleep(400);
  }

  private void Form_Click(object sender, EventArgs e)
  {
    if ( Program.Settings.ReminderFormCloseOnClick )
      Close();
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void PictureBox_Click(object sender, EventArgs e)
  {
    LabelDate_LinkClicked(sender, null);
  }

  private void LabelDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if ( LabelDate.Tag is null ) return;
    MainForm.Instance.GoToDate((DateTime)LabelDate.Tag, true, false, false, this);
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
      if ( Celebration == TorahCelebrationDay.Shabat )
        ParashotForm.Run();
      else
        CelebrationVersesBoardForm.Run(Celebration);
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
    HebrewTools.OpenHebrewWordsGoToVerse(ApplicationDatabase.Instance.GetWeeklyParashah().Factory.FullReferenceBegin,
                                         Settings.HebrewWordsExe);
  }

  private void ActionLockout_Click(object sender, EventArgs e)
  {
    ContextMenuLockout.Show(ActionLockout, new Point(0, ActionLockout.Height));
  }

  #endregion

}
