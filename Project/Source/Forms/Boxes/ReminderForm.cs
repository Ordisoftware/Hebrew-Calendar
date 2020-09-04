/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class ReminderForm : Form
  {

    static public void Run(Data.DataSet.LunisolarDaysRow row,
                           bool isShabat, 
                           TorahEvent torahevent,
                           ReminderTimes times)
    {
      bool doLockSession = false;
      var dateNow = DateTime.Now;
      if ( times.dateStart != null && times.dateEnd != null )
        doLockSession = dateNow >= times.dateStart && dateNow <= times.dateEnd;
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
        {
          foreach ( var item in MainForm.Instance.RemindCelebrationDayForms )
            if ( (string)item.Value.Tag == row.Date )
              return;
          foreach ( var item in MainForm.Instance.RemindCelebrationForms )
            if ( (string)item.Tag == row.Date )
            {
              Flash(item);
              return;
            }
        }
        form = new ReminderForm();
        var date = SQLiteDate.ToDateTime(row.Date);
        form.LabelTitle.Text = !isShabat
                               ? Translations.TorahEvent.GetLang((TorahEvent)row.TorahEvents)
                               : "Shabat";
        form.LabelDate.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(date.ToLongDateString());
        if ( times.dateStart != null && times.dateEnd != null )
          form.LabelHours.Text = Translations.DayOfWeek.GetLang(times.dateStart.Value.DayOfWeek) + " " +
                                 times.timeStart + " ➜ " +
                                 Translations.DayOfWeek.GetLang(times.dateEnd.Value.DayOfWeek) + " " +
                                 times.timeEnd;
        form.LabelDate.Tag = date;
        form.SetLocation(ControlLocation.BottomRight);
        form.Tag = row.Date;
        form.Text = " " + form.LabelTitle.Text;
        form.LabelTitle.ForeColor = Program.Settings.CalendarColorTorahEvent;
        form.LabelDate.LinkColor = Program.Settings.CalendarColorMoon;
        form.LabelDate.ActiveLinkColor = Program.Settings.CalendarColorMoon;
        if ( Program.Settings.UseColors )
          form.BackColor = doLockSession ? Program.Settings.EventColorTorah : Program.Settings.EventColorNext;
        form.IsShabat = isShabat;
        if ( isShabat )
          MainForm.Instance.ShabatForm = form;
        else
        if ( torahevent != TorahEvent.None )
        {
          foreach ( var item in MainForm.Instance.RemindCelebrationForms.ToList() )
            if ( (string)item.Tag == row.Date )
            {
              item.Close();
              break;
            }
          MainForm.Instance.RemindCelebrationDayForms.Add(torahevent, form);
        }
        else
          MainForm.Instance.RemindCelebrationForms.Add(form);
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
      if ( LockSessionForm.Instance?.Visible ?? false)
      {
        LockSessionForm.Instance.Focus();
        LockSessionForm.Instance.BringToFront();
      }

    }

    static private void Flash(Form form)
    {
      form.Hide();
      System.Threading.Thread.Sleep(500);
      form.Show();
      form.BringToFront();
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
      int dy = 0;
      int y = SystemInformation.WorkingArea.Top + SystemInformation.WorkingArea.Height;
      foreach ( var item in list.OrderBy(f => f.Tag) )
      {
        item.Location = new Point(item.Left, y - item.Height - dy);
        dy += item.Height;
      }
    }

    protected override bool ShowWithoutActivation => true;

    private bool IsShabat;

    private ReminderForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ShowInTaskbar = Program.Settings.ShowReminderInTaskBar;
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
      SetFormsLocation();
    }

    private void Form_Click(object sender, EventArgs e)
    {
      if (Program.Settings.ReminderFormCloseOnClick)
        Close();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void LabelDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( LabelDate.Tag == null ) return;
      MainForm.Instance.MenuShowHide_Click(null, null); 
      MainForm.Instance.GoToDate((DateTime)LabelDate.Tag);
      Form_Click(null, null);
    }

  }

}
