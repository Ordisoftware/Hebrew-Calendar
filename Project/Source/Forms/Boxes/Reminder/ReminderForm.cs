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
/// <created> 2019-01 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EnumsNET;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class ReminderForm : Form
  {

    static private Image Image;

    static ReminderForm()
    {
      try
      {
        Image = Image.FromFile(Program.ApplicationImage64FilePath);
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(SysTranslations.LoadFileError.GetLang(Program.ApplicationImage64FilePath, ex.Message));
      }
    }

    static public void Run(LunisolarDay row, TorahEvent torahevent, ReminderTimes times)
    {
      bool isShabat = torahevent == TorahEvent.Shabat;
      bool doLockSession = false;
      var dateNow = DateTime.Now;
      if ( times.DateStart != null && times.DateEnd != null )
        doLockSession = dateNow >= times.DateStart && dateNow <= times.DateEnd;
      try
      {
        ReminderForm form = null;
        if ( isShabat && MainForm.Instance.ShabatForm != null )
        {
          Flash(MainForm.Instance.ShabatForm);
          return;
        }
        else
        if ( torahevent != TorahEvent.None )
        {
          if ( MainForm.Instance.RemindCelebrationDayForms.ContainsKey(torahevent) )
          {
            Flash(MainForm.Instance.RemindCelebrationDayForms[torahevent]);
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
        form = new ReminderForm();
        var date = row.Date;
        form.LabelTitle.Text = isShabat
                               ? "Shabat"
                               : AppTranslations.TorahEvent.GetLang(torahevent == TorahEvent.None
                                                                    ? row.TorahEvent
                                                                    : torahevent);
        form.LabelDate.Text = isShabat
                              ? date.ToLongDateString().Titleize()
                              : row.DayAndMonthWithYearText;
        if ( times.DateStart != null && times.DateEnd != null )
        {
          form.LabelStartTime.Text = AppTranslations.DayOfWeek.GetLang(times.DateStart.DayOfWeek) + " " + times.TimeStart.ToString(@"hh\:mm");
          form.LabelEndTime.Text = AppTranslations.DayOfWeek.GetLang(times.DateEnd.DayOfWeek) + " " + times.TimeEnd.ToString(@"hh\:mm");
          if ( Program.Settings.ReminderBoxShowFullDates )
          {
            form.LabelStartDay.Text = times.DateStart.ToString("d MMM yyyy");
            form.LabelEndDay.Text = times.DateEnd.ToString("d MMM yyyy");
          }
          else
            form.Height -= form.LabelStartDay.Height;
        }
        int left = form.LabelStartTime.Left + form.LabelStartTime.Width;
        int left2 = left + form.LabelArrow.Width;
        form.LabelArrow.Left = left;
        form.LabelEndTime.Left = left2;
        form.LabelEndDay.Left = left2;
        form.LabelDate.Tag = date;
        form.Tag = row.Date;
        form.Text = " " + form.LabelTitle.Text;
        form.LabelParashahValue.Text = "";
        form.LabelParashahValue.Tag = null;
        if ( isShabat )
        {
          form.LabelTitle.Text += " " + row.DayAndMonthText;
          if ( Program.Settings.ReminderShabatShowParashah )
          {
            var rowParashah = row.GetParashahReadingDay();
            if ( rowParashah != null )
            {
              var parashah = ParashotFactory.Get(rowParashah.ParashahID);
              form.LabelParashahValue.Text = rowParashah.ParashahText;
              form.LabelParashahValue.Tag = row;
              form.LabelParashahValue.Enabled = true;
            }
            else
              form.LabelParashahValue.Enabled = false;
          }
        }
        form.LabelTitle.ForeColor = Program.Settings.CalendarColorTorahEvent;
        form.LabelDate.LinkColor = Program.Settings.CalendarColorMoon;
        form.LabelDate.ActiveLinkColor = Program.Settings.CalendarColorMoon;
        form.LabelStartTime.ForeColor = Program.Settings.MonthViewTextColor;
        if ( Program.Settings.UseColors )
          form.BackColor = doLockSession ? Program.Settings.EventColorTorah : Program.Settings.EventColorNext;
        form.IsShabat = isShabat;
        if ( isShabat )
          MainForm.Instance.ShabatForm = form;
        else
        if ( torahevent != TorahEvent.None )
        {
          foreach ( var item in MainForm.Instance.RemindCelebrationForms.ToList() )
            if ( (DateTime)item.Tag == row.Date )
            {
              item.Close();
              break;
            }
          MainForm.Instance.RemindCelebrationDayForms.Add(torahevent, form);
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

    static private void BringMainForm()
    {
      if ( MainForm.Instance.Visible && MainForm.Instance.WindowState != FormWindowState.Minimized )
        MainForm.Instance.MenuShowHide_Click(null, null);
      Application.DoEvents();
    }

    static private void Flash(ReminderForm form)
    {
      form.Hide();
      System.Threading.Thread.Sleep(500);
      form.Show();
      form.BringToFront();
      form.DoSound();
      BringMainForm();
    }

    static private void SetFormsLocation()
    {
      var list = new List<ReminderForm>();
      if ( MainForm.Instance.ShabatForm != null )
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

    protected override bool ShowWithoutActivation => true;

    private bool IsShabat;

    private ReminderForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ShowInTaskbar = Program.Settings.ShowReminderInTaskBar;
      if ( Image != null ) PictureBox.Image = Image;
      InitializeMenu();
    }

    private void ReminderForm_Load(object sender, EventArgs e)
    {
      PowerActions[] avoid = { PowerActions.LogOff, PowerActions.Restart };
      foreach ( var value in Enums.GetValues<PowerActions>().Skip(1).Where(a => !avoid.Contains(a)) )
      {
        var item = (ToolStripMenuItem)ContextMenuStripLockout.Items.Add(SysTranslations.PowerActionText.GetLang(value));
        item.Tag = value;
        item.Click += (_s, _e) =>
        {
          var action = (PowerActions)( (ToolStripItem)_s ).Tag;
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

    private void InitializeMenu()
    {
      ActionStudyOnline.InitializeFromProviders(HebrewGlobals.WebProvidersParashah, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var parashah = ParashotFactory.Get(( (LunisolarDay)LabelParashahValue.Tag ).ParashahID);
        HebrewTools.OpenParashahProvider((string)menuitem.Tag, parashah, true);
      });
      ActionOpenVerseOnline.InitializeFromProviders(HebrewGlobals.WebProvidersBible, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var parashah = (Parashah)LabelParashahValue.Tag;
        string verse = $"{(int)parashah.Book + 1}.{parashah.VerseBegin}";
        HebrewTools.OpenBibleProvider((string)menuitem.Tag, verse);
      });
    }

    private void DoSound()
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
        System.Threading.Thread.Sleep(400);
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

    private void LabelDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( LabelDate.Tag == null ) return;
      MainForm.Instance.GoToDate((DateTime)LabelDate.Tag, true, false, false, this);
    }

    private void ActionSetup_Click(object sender, EventArgs e)
    {
      SelectSoundForm.Run(true);
    }

    private void ActionViewParashot_Click(object sender, EventArgs e)
    {
      ParashotForm.Run(ApplicationDatabase.Instance.GetWeeklyParashah());
    }

    private void LabelParashahValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( e.Button == MouseButtons.Left )
        if ( LabelParashahValue.Tag != null )
          ParashotForm.Run(ParashotFactory.Get(( (LunisolarDay)LabelParashahValue.Tag ).ParashahID));
    }

    private void ActionViewParashahInfos_Click(object sender, EventArgs e)
    {
      if ( !ApplicationDatabase.Instance.ShowWeeklyParashahInformation() )
        ActionViewParashahInfos.Enabled = false;
    }

    private void ActionLockout_Click(object sender, EventArgs e)
    {
      ContextMenuStripLockout.Show(ActionLockout, new Point(0, ActionLockout.Height));
    }

  }

}
